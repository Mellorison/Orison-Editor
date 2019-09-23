using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;
using OrisonEditor.Definitions.ValueDefinitions;

namespace OrisonEditor.Definitions
{
    public class EntityDefinition
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public int Limit;
        [XmlAttribute]
        public bool ResizableX;
        [XmlAttribute]
        public bool ResizableY;
        [XmlAttribute]
        public bool Rotatable;
        [XmlAttribute]
        public float RotateIncrement;

        public Size Size;
        public Point Origin;
        public EntityImageDefinition ImageDefinition;
        public List<ValueDefinition> ValueDefinitions;
        public EntityNodesDefinition NodesDefinition;

        private Bitmap bitmap;
        private Bitmap buttonBitmap;

        public EntityDefinition()
        {
            Limit = -1;
            Size = new Size(16, 16);
            RotateIncrement = 15;

            ValueDefinitions = new List<ValueDefinition>();

            ImageDefinition.ImagePath = "";
            ImageDefinition.RectColor = new OrisonColor(255, 0, 0);

            NodesDefinition.Limit = -1;
        }

        public EntityDefinition Clone()
        {
            EntityDefinition def = new EntityDefinition();
            def.Name = Name;
            def.Limit = Limit;
            def.ResizableX = ResizableX;
            def.ResizableY = ResizableY;
            def.Rotatable = Rotatable;
            def.RotateIncrement = RotateIncrement;
            def.Size = Size;
            def.Origin = Origin;
            def.ImageDefinition = ImageDefinition;
            def.ValueDefinitions = new List<ValueDefinition>();
            def.NodesDefinition = NodesDefinition;
            foreach (var d in ValueDefinitions)
                def.ValueDefinitions.Add(d.Clone());
            return def;
        }

        public void Draw(Graphics graphics, Point position, Size size, float angle, DrawUtil.AlphaMode alphaMode)
        {
            //Do transformations for position and rotation
            graphics.TranslateTransform(position.X, position.Y);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-Origin.X, -Origin.Y);

            //Draw the actual entity
            if (ImageDefinition.DrawMode == EntityImageDefinition.DrawModes.Rectangle)
            {
                DrawUtil.EntityRectBrush.Color = Color.FromArgb(DrawUtil.AlphaInts[(int)alphaMode], ImageDefinition.RectColor);
                graphics.FillRectangle(DrawUtil.EntityRectBrush, new Rectangle(0, 0, size.Width, size.Height));
            }
            else if (ImageDefinition.Tiled)
            {
                Rectangle drawTo = Rectangle.Empty;
                for (drawTo.X = 0; drawTo.X < size.Width; drawTo.X += bitmap.Width)
                {
                    drawTo.Width = Math.Min(bitmap.Width, size.Width - drawTo.X);
                    for (drawTo.Y = 0; drawTo.Y < size.Height; drawTo.Y += bitmap.Height)
                    {
                        drawTo.Height = Math.Min(bitmap.Height, size.Height - drawTo.Y);
                        graphics.DrawImage(bitmap, drawTo, 0, 0, drawTo.Width, drawTo.Height, GraphicsUnit.Pixel, DrawUtil.AlphaAttributes[(int)alphaMode]);
                    }
                }
            }
            else
                graphics.DrawImage(bitmap, new Rectangle(0, 0, size.Width, size.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, DrawUtil.AlphaAttributes[(int)alphaMode]);

            //Undo the transformations
            graphics.TranslateTransform(Origin.X, Origin.Y);
            graphics.RotateTransform(-angle);
            graphics.TranslateTransform(-position.X, -position.Y);
        }

        public void Draw(Graphics graphics, Point position, float angle, DrawUtil.AlphaMode alphaMode)
        {
            Draw(graphics, position, Size, angle, alphaMode);
        }

        public void GenerateImages()
        {
            //Dispose old stuff
            if (bitmap != null)
                bitmap.Dispose();
            if (buttonBitmap != null && buttonBitmap != bitmap)
                buttonBitmap.Dispose();

            //Generate the in-editor image
            switch (ImageDefinition.DrawMode)
            {
                case EntityImageDefinition.DrawModes.Rectangle:
                    Bitmap b = new Bitmap(Size.Width, Size.Height);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.FillRectangle(new SolidBrush(ImageDefinition.RectColor), new Rectangle(0, 0, Size.Width, Size.Height));
                    }
                    bitmap = b;
                    break;

                case EntityImageDefinition.DrawModes.Image:
                    if (!File.Exists(Path.Combine(Orison.Project.SavedDirectory, ImageDefinition.ImagePath)))
                        bitmap = null;
                    else
                        bitmap = new Bitmap(Path.Combine(Orison.Project.SavedDirectory, ImageDefinition.ImagePath));
                    break;
            }

            //Generate the button image
            if (bitmap == null)
                buttonBitmap = null;
            else if (ImageDefinition.Tiled && ImageDefinition.DrawMode == EntityImageDefinition.DrawModes.Image)
            {
                buttonBitmap = new Bitmap(Size.Width, Size.Height);
                using (Graphics g = Graphics.FromImage(buttonBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImageUnscaledAndClipped(bitmap, new Rectangle(0, 0, Size.Width, Size.Height));
                }
            }
            else
                buttonBitmap = bitmap;
        }

        public Bitmap ButtonBitmap { get { return buttonBitmap; } }
    }

    [XmlRoot("Image")]
    public struct EntityImageDefinition
    {
        public enum DrawModes { Rectangle, Image };

        [XmlAttribute]
        public DrawModes DrawMode;
        [XmlAttribute]
        public string ImagePath;
        [XmlAttribute]
        public bool Tiled;

        public OrisonColor RectColor;
    }

    [XmlRoot("Nodes")]
    public struct EntityNodesDefinition
    {
        public enum PathMode { None, Path, Circuit, Fan };

        [XmlAttribute]
        public bool Enabled;
        [XmlAttribute]
        public int Limit;
        [XmlAttribute]
        public PathMode DrawMode;
        [XmlAttribute]
        public bool Ghost;
    }
}
