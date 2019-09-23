using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData.Layers;
using System.Windows.Forms;
using System.Diagnostics;
using OrisonEditor.LevelEditors.Actions;
using OrisonEditor.LevelEditors.Tools;
using OrisonEditor.LevelEditors.Resizers;
using System.Drawing; 

namespace OrisonEditor.LevelEditors.LayerEditors
{
    public abstract class LayerEditor
    {
        public const int LAYER_ABOVE_ALPHA = 128;

        public Layer Layer { get; private set; }
        public LevelEditor LevelEditor { get; private set; }
        public Point MouseSnapPosition { get; private set; }
        public PointF DrawOffset { get; private set; }

        public LayerEditor(LevelEditor levelEditor, Layer layer)
        {
            LevelEditor = levelEditor;
            Layer = layer;
        }

        public virtual void UpdateDrawOffset(Point cameraPos)
        {
            DrawOffset = new PointF(cameraPos.X - cameraPos.X * Layer.Definition.ScrollFactor.X, cameraPos.Y - cameraPos.Y * Layer.Definition.ScrollFactor.Y);
        }

        public void DrawHandler(Graphics graphics, bool current, bool fullAlpha)
        {
            graphics.TranslateTransform(DrawOffset.X, DrawOffset.Y);
            Draw(graphics, current, fullAlpha);
            graphics.TranslateTransform(-DrawOffset.X, -DrawOffset.Y);

            if (current && Orison.ToolsWindow.CurrentTool != null)
                Orison.ToolsWindow.CurrentTool.Draw(graphics);
        }

        public abstract void Draw(Graphics graphics, bool current, bool fullAlpha);

        #region Input Events

        public virtual void OnKeyDown(Keys key)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
                Orison.ToolsWindow.CurrentTool.OnKeyDown(key);
        }

        public void OnKeyUp(Keys key)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
                Orison.ToolsWindow.CurrentTool.OnKeyUp(key);
        }

        public void OnMouseLeftClick(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseLeftClick(location);
            }
        }

        public void OnMouseLeftDown(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseLeftDown(location);
            }
        }

        public void OnMouseLeftUp(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseLeftUp(location);
            }
        }

        public void OnMouseRightClick(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseRightClick(location);
            }
        }

        public void OnMouseRightDown(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseRightDown(location);
            }
        }

        public void OnMouseRightUp(Point location)
        {
            if (Orison.ToolsWindow.CurrentTool != null)
            {
                location.X -= (int)DrawOffset.X;
                location.Y -= (int)DrawOffset.Y;
                Orison.ToolsWindow.CurrentTool.OnMouseRightUp(location);
            }
        }

        public void OnMouseMove(Point location)
        {
            location.X -= (int)DrawOffset.X;
            location.Y -= (int)DrawOffset.Y;

            MouseSnapPosition = Layer.Definition.SnapToGrid(LevelEditor.MousePosition);

            if (Orison.ToolsWindow.CurrentTool != null)
                Orison.ToolsWindow.CurrentTool.OnMouseMove(location);
        }

        #endregion

        #region Action Hooks

        public virtual Resizer GetResizer() { return null; }

        public virtual bool CanCopyOrCut { get { return false; } }
        public virtual void Copy() { }
        public virtual void Cut() { }

        public virtual bool CanSelectAll { get { return false; } }
        public virtual void SelectAll() { }

        public virtual bool CanDeselect { get { return false; } }
        public virtual void Deselect() { }

        #endregion

        #region Utilities

        public Rectangle GetVisibleArea(Graphics graphics)
        {
            PointF topLeft = graphics.ClipBounds.Location;
            PointF bottomRight = new PointF(graphics.ClipBounds.Right, graphics.ClipBounds.Bottom);

            return new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)(bottomRight.X - topLeft.X), (int)(bottomRight.Y - topLeft.Y));
        }

        public Rectangle GetVisibleGridArea(Graphics graphics)
        {
            PointF topLeft = graphics.ClipBounds.Location;
            PointF bottomRight = new PointF(graphics.ClipBounds.Right, graphics.ClipBounds.Bottom);

            int x = (int)Math.Max(0, topLeft.X / Layer.Definition.Grid.Width);
            int y = (int)Math.Max(0, topLeft.Y / Layer.Definition.Grid.Height);

            return new Rectangle(x, y,
                    (int)Math.Min(LevelEditor.Level.Bounds.Width / Layer.Definition.Grid.Width, bottomRight.X / Layer.Definition.Grid.Width + 1) - x,
                    (int)Math.Min(LevelEditor.Level.Bounds.Height / Layer.Definition.Grid.Height, bottomRight.Y / Layer.Definition.Grid.Height + 1) - y
                );
        }

        #endregion
    }
}
