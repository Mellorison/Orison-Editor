using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace OrisonEditor
{
    public partial class ImagePreviewer : UserControl
    {
        private Bitmap bitmap;
        private Rectangle clipRect;

        public ImagePreviewer()
        {
            InitializeComponent();
        }

        public bool LoadImage(string path, Rectangle? clip = null)
        {
            if (File.Exists(path))
            {
                bitmap = new Bitmap(path);
                clipRect = clip ?? new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                pictureBox.Refresh();
                return true;
            }
            else
            {
                ClearImage();
                return false;
            }
        }

        public void LoadImage(Bitmap bmp, Rectangle? clip = null)
        {
            bitmap = bmp;
            clipRect = clip ?? new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            pictureBox.Refresh();
        }

        public void SetClip(Rectangle r)
        {
            clipRect = r;
            pictureBox.Refresh();
        }

        public void ClearImage()
        {
            bitmap = null;
            pictureBox.Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (bitmap != null)
            {
                if (clipRect.Width > ClientSize.Width || clipRect.Height > ClientSize.Height)
                {
                    float scale = Math.Min(ClientSize.Width / (float)clipRect.Width, ClientSize.Height / (float)clipRect.Height);
                    int destWidth = (int)(clipRect.Width * scale);
                    int destHeight = (int)(clipRect.Height * scale);
                    g.DrawImage(bitmap,
                        new Rectangle(pictureBox.ClientSize.Width / 2 - destWidth / 2, pictureBox.ClientSize.Height / 2 - destHeight / 2, destWidth, destHeight),
                        clipRect, GraphicsUnit.Pixel);
                }
                else
                    g.DrawImage(bitmap,
                        pictureBox.ClientSize.Width / 2 - clipRect.Width / 2, pictureBox.ClientSize.Height / 2 - clipRect.Height / 2,
                        clipRect, GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(DrawUtil.ImgBroken,
                    new Point(pictureBox.ClientSize.Width / 2 - DrawUtil.ImgBroken.Width / 2, pictureBox.ClientSize.Height / 2 - DrawUtil.ImgBroken.Height / 2));
            }
        }

        public int ImageWidth
        {
            get
            {
                if (bitmap == null)
                    return -1;
                else 
                    return clipRect.Width;
            }
        }

        public int ImageHeight
        {
            get
            {
                if (bitmap == null)
                    return -1;
                else
                    return clipRect.Height;
            }
        }

        public bool BitmapValid { get { return bitmap != null; } }
    }
}
