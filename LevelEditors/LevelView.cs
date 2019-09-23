using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using OrisonEditor.LevelData;

namespace OrisonEditor.LevelEditors
{
    public class LevelView
    {
        static public readonly Matrix Identity = new Matrix();
        static private readonly float[] ZOOMS = new float[] { .25f, .33f, .5f, .66f, 1, 1.25f, 1.5f, 2, 2.5f, 3 };
        private const float ZOOM_SPEED = 6;

        public LevelEditor LevelEditor { get; private set; }
        public Matrix Matrix { get; private set; }
        public Matrix Inverse { get; private set; }
        public float Zoom { get; private set; }

        private float targetZoom;
        private Size oldLevelSize;
        private Stopwatch stopwatch;
        private double lastTime;
        private PointF zoomAt;

        public LevelView(LevelEditor levelEditor)
        {
            LevelEditor = levelEditor;
            Matrix = new Matrix();
            Inverse = new Matrix();
            targetZoom = Zoom = 1;

            stopwatch = new Stopwatch();

            Center();
        }

        public void Update()
        {
            if (stopwatch.IsRunning)
            {
                double elapsed = stopwatch.Elapsed.TotalSeconds - lastTime;

                float oldZoom = Zoom;
                Zoom = Util.Approach(Zoom, targetZoom, (float)elapsed * ZOOM_SPEED);
                float scale = Zoom / oldZoom;
                lastTime = stopwatch.Elapsed.TotalSeconds;

                PointF at = ScreenToEditor(zoomAt);
                Matrix.Translate(at.X, at.Y);
                Matrix.Scale(scale, scale);
                Matrix.Translate(-at.X, -at.Y);
                UpdateInverse();

                LevelEditor.Invalidate();

                if (Zoom == targetZoom)
                    stopwatch.Stop();
            }
        }

        public void OnParentResized()
        {
            Pan(new Point((LevelEditor.Size.Width - oldLevelSize.Width) / 2, (LevelEditor.Size.Height - oldLevelSize.Height) / 2));
            oldLevelSize = LevelEditor.Size;
        }

        //Transforming points back and forth
        public PointF ScreenToEditor(PointF screenPos)
        {
            PointF[] points = new PointF[] { screenPos };
            Inverse.TransformPoints(points);
            return points[0];
        }

        public Point ScreenToEditor(Point screenPos)
        {
            Point[] points = new Point[] { screenPos };
            Inverse.TransformPoints(points);
            return points[0];
        }

        public PointF EditorToScreen(PointF editorPos)
        {
            PointF[] points = new PointF[] { editorPos };
            Matrix.TransformPoints(points);
            return points[0];
        }

        public Point EditorToScreen(Point editorPos)
        {
            Point[] points = new Point[] { editorPos };
            Matrix.TransformPoints(points);
            return points[0];
        }

        //Transformations
        public void Pan(PointF by)
        {
            PointF[] p = new PointF[] { by };
            Inverse.TransformVectors(p);
            by = p[0];

            Matrix.Translate(by.X, by.Y);
            UpdateInverse();
        }

        public void Center()
        {
            CenterOn(new PointF(LevelEditor.ClientSize.Width / 2, LevelEditor.ClientSize.Height / 2));
        }

        public void CenterOn(PointF on)
        {
            PointF target = new PointF(on.X - LevelEditor.Level.Size.Width / 2 * Zoom, on.Y - LevelEditor.Level.Size.Height / 2 * Zoom);
            target = ScreenToEditor(target);

            Matrix.Translate(target.X, target.Y);
            UpdateInverse();
        }

        private int GetZoomIndex()
        {
            for (int i = 0; i < ZOOMS.Length; i++)
                if (ZOOMS[i] == targetZoom)
                    return i;
            throw new Exception("Zoom exception!");
        }

        public void ZoomIn(PointF? zoomAt = null)
        {
            //Make sure you can zoom
            int at = GetZoomIndex();
            if (at == ZOOMS.Length - 1)
                return;

            //Set the zoom origin
            if (zoomAt.HasValue)
                this.zoomAt = zoomAt.Value;
            else
                this.zoomAt = EditorToScreen(LevelEditor.Level.Center);

            //Increase the target zoom
            targetZoom = ZOOMS[at + 1];
            Orison.MainWindow.ZoomLabel.Text = ZoomString;

            //Start the tween
            stopwatch.Restart();
            lastTime = 0;          
        }

        public void ZoomOut(PointF? zoomAt = null)
        {
            //Make sure you can zoom
            int at = GetZoomIndex();
            if (at == 0)
                return;

            //Set the zoom origin
            if (zoomAt.HasValue)
                this.zoomAt = zoomAt.Value;
            else
                this.zoomAt = EditorToScreen(LevelEditor.Level.Center);

            //Increase the target zoom
            targetZoom = ZOOMS[at - 1];
            Orison.MainWindow.ZoomLabel.Text = ZoomString;

            //Start the tween
            stopwatch.Restart();
            lastTime = 0;
        }

        public string ZoomString
        {
            get
            {
                return ((int)(targetZoom * 100)).ToString() + "%";
            }
        }

        private void UpdateInverse()
        {
            Inverse = Matrix.Clone();
            Inverse.Invert();
        }
    }
}
