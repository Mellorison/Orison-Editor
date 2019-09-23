using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using OrisonEditor.LevelEditors;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace OrisonEditor
{
    static public class Util
    {
        static public readonly ImageAttributes FullAlphaAttributes = CreateAlphaAttributes(1);
        static public readonly ImageAttributes HalfAlphaAttributes = CreateAlphaAttributes(.5f);
        static public readonly ImageAttributes QuarterAlphaAttributes = CreateAlphaAttributes(.25f);
        
        public const float UP = (float)(Math.PI * 1.5);
        public const float DOWN = (float)(Math.PI * .5);
        public const float RIGHT = 0;
        public const float LEFT = (float)Math.PI;
        public const float QUARTER = (float)(Math.PI / 2);
        public const float EIGHTH = (float)(Math.PI / 4);
        public const float DEGTORAD = (float)(Math.PI / 180.0);
        public const float RADTODEG = (float)(180.0 / Math.PI);

        #region Filepath Helpers

        static public string RelativePath(string absPath, string relTo)
        {
            string[] absDirs = absPath.Split(Path.DirectorySeparatorChar);
            string[] relDirs = relTo.Split(Path.DirectorySeparatorChar);

            // Get the shortest of the two paths
            int len = absDirs.Length < relDirs.Length ? absDirs.Length :
            relDirs.Length;

            // Use to determine where in the loop we exited
            int lastCommonRoot = -1;
            int index;

            // Find common root
            for (index = 0; index < len; index++)
            {
                if (absDirs[index] == relDirs[index]) 
                    lastCommonRoot = index;
                else 
                    break;
            }

            // If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base");
            }

            // Build up the relative path
            StringBuilder relativePath = new StringBuilder();

            // Add on the ..
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) 
                    relativePath.Append(".." + Path.DirectorySeparatorChar);
            }

            // Add on the folders
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + Path.DirectorySeparatorChar);
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);

            return relativePath.ToString();
        }

        static public string DirectoryPath(string filePath)
        {
            string d = Path.DirectorySeparatorChar + Path.GetFileName(filePath);
            return filePath.Remove(filePath.LastIndexOf(d));
        }

        #endregion

        #region Math Helpers

        static public int DistanceSquared(Point a, Point b)
        {
            return (b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y);
        }

        static public double Angle(Point a, Point b)
        {
            return Math.Atan2(b.Y - a.Y, b.X - a.X);
        }

        static public float Approach(float value, float target, float amount)
        {
            if (value > target)
                return Math.Max(target, value - amount);
            else
                return Math.Min(target, value + amount);
        }

        static public double AngleDifference(double a, double b)
        {
            double diff = b - a;
            while (diff > Math.PI)
                diff -= Math.PI * 2;
            while (diff < -Math.PI)
                diff += Math.PI * 2;
            return diff;
        }

        static public int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        static public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static public float Snap(float value, float increment)
        {
            return (float)Math.Round(value / increment, MidpointRounding.AwayFromZero) * increment;
        }

        static public int Wrap(int value, int max)
        {
            if (value < 0)
                value += (int)(Math.Ceiling((-value) / (float)max) * max);
            return value % max;
        }

        #endregion

        #region Input Helpers

        static public bool Ctrl
        {
            get
            {
                return (Control.ModifierKeys & Keys.Control) == Keys.Control;
            }
        }

        static public bool Shift
        {
            get
            {
                return (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
            }
        }

        static public bool Alt
        {
            get
            {
                return (Control.ModifierKeys & Keys.Alt) == Keys.Alt;
            }
        }

        #endregion

        #region ImageAttributes Helpers

        static public ColorMatrix CreateAlphaMatrix(float alpha)
        {
            return new ColorMatrix(new float[][] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, alpha, 0 }, new float[] { 0, 0, 0, 0, 1 } });
        }

        static public ImageAttributes CreateAlphaAttributes(float alpha)
        {
            ImageAttributes a = new ImageAttributes();
            a.SetColorMatrix(CreateAlphaMatrix(alpha));
            return a;
        }

        #endregion

        #region Matrix Extensions

        static public Point TransformPoint(this Matrix matrix, Point point)
        {
            Point[] p = new Point[] { point };
            matrix.TransformPoints(p);
            return p[0];
        }

        #endregion

        #region Color Extensions

        static public Color Invert(this Color color)
        {
            return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
        }

        #endregion

        #region Rectangle Extensions

        static public int Area(this Rectangle rect)
        {
            return rect.Width * rect.Height;
        }

        static public Rectangle Multiply(this Rectangle rect, int multX, int multY)
        {
            rect.X *= multX;
            rect.Width *= multX;
            rect.Y *= multY;
            rect.Height *= multY;

            return rect;
        }

        static public Rectangle Multiply(this Rectangle rect, float multX, float multY)
        {
            rect.X = (int)(rect.X * multX);
            rect.Width = (int)(rect.Width * multX);
            rect.Y = (int)(rect.Y * multY);
            rect.Height = (int)(rect.Height * multY);

            return rect;
        }

        #endregion

        #region RectangleF Extensions

        static public float Area(this RectangleF rect)
        {
            return rect.Width * rect.Height;
        }

        static public RectangleF Multiply(this RectangleF rect, int multX, int multY)
        {
            rect.X *= multX;
            rect.Width *= multX;
            rect.Y *= multY;
            rect.Height *= multY;

            return rect;
        }

        static public RectangleF Multiply(this RectangleF rect, float multX, float multY)
        {
            rect.X = (int)(rect.X * multX);
            rect.Width = (int)(rect.Width * multX);
            rect.Y = (int)(rect.Y * multY);
            rect.Height = (int)(rect.Height * multY);

            return rect;
        }

        #endregion

        #region Point Extensions

        static public PointF Add(this PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        static public PointF Subtract(this PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

        static public PointF Multiply(this PointF a, float b)
        {
            return new PointF(a.X * b, a.Y * b);
        }

        static public PointF Divide(this PointF a, float b)
        {
            return new PointF(a.X / b, a.Y / b);
        }

        static public Point Add(this Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        static public Point Subtract(this Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        #endregion
    }
}
