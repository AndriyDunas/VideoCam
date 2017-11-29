using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetriCam;
using AForge.Video.DirectShow;
using System.Timers;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                camera.Update();
                pictureBoxCamera.Image = camera.GetBitmap();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            camera.Disconnect();
        }

        /// <summary>
        /// Get a Bitmap object (if supported) from the camera and store it as "bitmap.bmp" in the current directory.
        /// </summary>
        /// <param name="camera">Camera from which frame is stored.</param>
        private void StoreFrame(IMetriCamera camera)
        {
            if (camera is IProvidesBitmapOutput)
            {
                writingToFile = true;

                List<Color> pixels = new List<Color>();
                Bitmap bmp = ((IProvidesBitmapOutput)camera).GetBitmap();

                bmp.Save("photo.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                File.Create("photo.txt").Close();
                for (int y = 0; y < 50; y++)
                {
                    for (int x = 0; x < 50; ++x)
                    {
                        Color color = bmp.GetPixel(x, y);
                        WritePixelToFile(color, y, x);
                    }
                }
                writingToFile = false;
            }
        }

        private void btnMakePhoto_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                Bitmap bmp = ((IProvidesBitmapOutput)camera).GetBitmap();
                backgroundWorker1.CancelAsync();
                pictureBoxCamera.Image = bmp;
            }
        }

        private void btnConnectCamera_Click(object sender, EventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public Image ResizeCamera(Image originalImage, int w, int h)
        {
            //Original Image attributes
            int originalWidth = originalImage.Width;
            int originalHeight = originalImage.Height;

            // Figure out the ratio
            double ratioX = (double)w / (double)originalWidth;
            double ratioY = (double)h / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            Image thumbnail = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            graphic.Clear(Color.Transparent);
            graphic.DrawImage(originalImage, 0, 0, newWidth, newHeight);

            return thumbnail;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Image resizedImage = ResizeCamera(pictureBoxCamera.Image, Convert.ToInt32(textWidth.Text), Convert.ToInt32(textHeight.Text));
            pictureBoxCamera.Image = resizedImage;
        }

        private void pictureBoxCamera_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            Invalidate();
        }

        private void pictureBoxCamera_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pictureBoxCamera.Invalidate();
        }

        private void pictureBoxCamera_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBoxCamera.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        public Image DrawSelection(Image image, System.Drawing.Rectangle sourceRect)
        {
            Image thumbnail = new Bitmap(sourceRect.Width, sourceRect.Height);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.Clear(Color.Transparent);
            graphic.DrawImage(image, 0.0f, 0.0f, sourceRect, System.Drawing.GraphicsUnit.Pixel);
            return thumbnail;
        }

        private void pictureBoxCamera_MouseUp(object sender, MouseEventArgs e)
        {
            Image drawed = DrawSelection(pictureBoxCamera.Image, Rect);
            pictureBoxTest.Image = drawed;
        }
    }
}