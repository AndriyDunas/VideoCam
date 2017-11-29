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
        // get image from txt format and display on form
        private void btnGetImageFromTxt_Click(object sender, EventArgs e)
        {
            List<Color> pixels = new List<Color>();
            Bitmap bmp = new Bitmap(50, 50);

            using (var reader = new StreamReader("photo.txt"))
            {
                string all = reader.ReadToEnd();
                char[] separator = { '\r', '\n', ' ' };
                string[] words = all.Split(separator);

                for (int i = 0; words.Length - i > 2; i += 2)
                {
                    string binaryR = words[i];
                    string binaryG = words[++i];
                    string binaryB = words[++i];

                    Int32[] rgb = new Int32[3];
                    rgb[0] = Convert.ToInt32(binaryR, 2);
                    rgb[1] = Convert.ToInt32(binaryG, 2);
                    rgb[2] = Convert.ToInt32(binaryB, 2);

                    Color color = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    pixels.Add(color);
                }
            }

            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 50; ++x)
                {
                    bmp.SetPixel(x, y, pixels[50 * y + x]);
                }
            }
            pictureBoxCamera.Image = bmp;
        }

        private void WritePixelToFile(Color _color, int _y, int _x)
        {
            byte[] rgb = new byte[3];
            rgb[0] = _color.R;
            rgb[1] = _color.G;
            rgb[2] = _color.B;

            string binaryR = Convert.ToString(rgb[0], 2);
            string binaryG = Convert.ToString(rgb[1], 2);
            string binaryB = Convert.ToString(rgb[2], 2);

            waitHandle.WaitOne();
            using (var writer = new StreamWriter("photo.txt", append: true))
            {
                writer.WriteLine("{0} {1} {2}", binaryR, binaryG, binaryB);
            }
            waitHandle.Set();
        }

        private void btnSaveImageToTxt_Click(object sender, EventArgs e)
        {
            if (!writingToFile)
            {
                StoreFrame(camera);
            }
            backgroundWorker1.CancelAsync();
        }

        private void TranslateAffine()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);

            int sizeOfImage = 200;
            int transX = Convert.ToInt32(txtTranslateX.Text);
            int transY = Convert.ToInt32(txtTranslateY.Text);

            SetTranslationMatrix(transX, transY);

            for (int x = sizeOfImage - 1; x >= 0; x--)
            {
                for (int y = sizeOfImage - 1; y >= 0; y--)
                {
                    Color color = default_image.GetPixel(x, y);
                    default_image.SetPixel(x, y, Color.Transparent);
                    SetPointVector(x, y, 1.0);
                    MultiplyMatrices();
                    default_image.SetPixel((int)pointVector[(int)Coords.X], (int)pointVector[(int)Coords.Y], color);
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void RotateAffine()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);

            int sizeOfImage = 5;

            SetRotationMatrixbyAngle(90);

            for (int x = sizeOfImage + 100 - 1; x >= 100; x--)
            {
                for (int y = sizeOfImage + 100 - 1; y >= 100; y--)
                {
                    Color color = default_image.GetPixel(x, y);
                    SetPointVector(x, y, 1.0);
                    MultiplyMatrices();

                    int newX = Math.Abs((int)pointVector[(int)Coords.X]);
                    int newY = Math.Abs((int)pointVector[(int)Coords.Y]);
                    default_image.SetPixel(newX, newY, color);
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void ScaleAffine()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int sizeOfImage = 110;

            double scaleX = Convert.ToDouble(txtScaleX.Text);
            double scaleY = Convert.ToDouble(txtScaleY.Text);

            SetScalingMatrix(scaleX, scaleY);

            for (int x = sizeOfImage - 1; x >= 0; x--)
            {
                for (int y = sizeOfImage - 1; y >= 0; y--)
                {
                    Color color = default_image.GetPixel(x, y);
                    SetPointVector(x, y, 1.0);
                    MultiplyMatrices();
                    for (int i = 0; i < (Int32)scaleX + 1; i++)
                    {
                        for (int j = 0; j < (Int32)scaleY + 1; j++)
                        {
                            default_image.SetPixel((int)pointVector[(int)Coords.X] + i, (int)pointVector[(int)Coords.Y] + j, color);
                        }
                    }
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void SetUnit()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    affineMulMatrix[i][j] = 0.0;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                affineMulMatrix[i][i] = 1.0;
            }
        }

        private void SetTranslationMatrix(double tx, double ty)
        {
            SetUnit();
            affineMulMatrix[2][0] = tx;
            affineMulMatrix[2][1] = ty;
        }

        private void SetPointVector(double x, double y, double z)
        {
            pointVector[(int)Coords.X] = x;
            pointVector[(int)Coords.Y] = y;
            pointVector[(int)Coords.Z] = z;
        }

        /*
	Умножает текущую матрицу на матрицу, переданную в качестве параметра
*/
        private void MultiplyMatrices()
        {
            double[] temp = pointVector;
            double val; ;
            for (int i = 0; i < 3; i++)
            {
                val = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    val += temp[j] * affineMulMatrix[j][i];
                }
                pointVector[i] = val;
            }
        }

        private void btnAffineTranslate_Click(object sender, EventArgs e)
        {
            TranslateAffine();
        }

        private void SetRotationMatrixbyAngle(double alpha)
        {
            SetUnit();

            double sinalpha = Math.Sin(alpha);
            double cosalpha = Math.Cos(alpha);

            affineMulMatrix[0][0] = 0;
            affineMulMatrix[0][1] = 1;
            affineMulMatrix[1][0] = -1;
            affineMulMatrix[1][1] = 0;
        }

        private void btnAffineRotate_Click(object sender, EventArgs e)
        {
            RotateAffine();
        }

        private void SetScalingMatrix(double sx, double sy)
        {
            SetUnit();
            affineMulMatrix[0][0] = sx;
            affineMulMatrix[1][1] = sy;
        }

        private void btnAffineScale_Click(object sender, EventArgs e)
        {
            ScaleAffine();
        }


        private Bitmap GrayScale()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(default_image.Width, default_image.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
            new float[][] 
            {
                new float[] {.3f, .3f, .3f, 0, 0},
                new float[] {.59f, .59f, .59f, 0, 0},
                new float[] {.11f, .11f, .11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(default_image, new Rectangle(0, 0, default_image.Width, default_image.Height),
               0, 0, default_image.Width, default_image.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            pictureBoxCamera.Image = newBitmap;
            return newBitmap;
        }

        private void btnGraysclae_Click(object sender, EventArgs e)
        {
            GrayScale();
        }

        private void btnToDefaultImage_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                backgroundWorker1.CancelAsync();
            }
            pictureBoxCamera.Image = VideoApp.Properties.Resources.digits;
        }

        private void PrepareGraphics(Bitmap default_image)
        {
            //create a blank bitmap the same size as original
            recBitmap = new Bitmap(default_image.Width, default_image.Height);
            recGraphics = Graphics.FromImage(recBitmap);
            recGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            recGraphics.SmoothingMode = SmoothingMode.HighQuality;
            recGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            recGraphics.CompositingQuality = CompositingQuality.HighQuality;

            recGraphics.Clear(Color.Transparent);
        }

        private void btnSetImage1_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                backgroundWorker1.CancelAsync();
            }
            pictureBoxCamera.Image = VideoApp.Properties.Resources.digits_rotated_plus_1;
        }

        private void btnRotatedMinus2_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                backgroundWorker1.CancelAsync();
            }
            pictureBoxCamera.Image = VideoApp.Properties.Resources.digits_rotated_plus_2;
        }

        private void buttonRotatedPlus3_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                backgroundWorker1.CancelAsync();
            }
            pictureBoxCamera.Image = VideoApp.Properties.Resources.digits_rotated_plus_3;
        }
    }
}