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
        public Bitmap MedianFilter(Bitmap sourceBitmap, int matrixSize, int bias = 0, bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;
            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;
            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;
                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
                            neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset));
                        }
                    }
                    neighbourPixels.Sort();
                    middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            UpdateImageMatrix(resultBitmap);
            
            return resultBitmap;
        }

        private void btnMedianFilter_Click(object sender, EventArgs e)
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int medianFilterStep = Convert.ToInt32(textBoxMedianFilterStep.Text);
            Bitmap result_image = MedianFilter(default_image, medianFilterStep);
            pictureBoxCamera.Image = result_image;
        }

        private void NPixelsFilter(Bitmap default_image, Bitmap new_image)
        {
            int height = default_image.Height;
            int width = default_image.Width;

            int w = Convert.ToInt32(textBoxNPixels.Text);

            int NumberTres = 4;//Convert.ToInt32(textBoxPixelsTres.Text);

            for (int x = w / 2; x < width; x += w)
            {
                for (int y = w / 2; y < height; y += w)
                {
                    int numberOfBlackPixelsDown = 0;
                    for (int i = x - w / 2; i < x + w / 2; i++)
                    {
                        for (int j = y - w / 2; j < y + w / 2; j++)
                        {
                            if (GetIntensityOfPixel(default_image, i, j) <= 127)
                            {
                                numberOfBlackPixelsDown++;
                            }
                        }
                    }

                    if (numberOfBlackPixelsDown < NumberTres)
                    {
                        for (int i = x - w / 2; i < x + w / 2; i++)
                        {
                            for (int j = y - w / 2; j < y + w / 2; j++)
                            {
                                if (i < width && j < height)
                                    new_image.SetPixel(i, j, Color.White);
                            }
                        }
                    }
                }
            }
            UpdateImageMatrix(new_image);
        }

        private void btnNPixelsFilter_Click(object sender, EventArgs e)
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            Bitmap new_image = default_image;
            NPixelsFilter(default_image, new_image);
            pictureBoxCamera.Image = new_image;
        }
    }
}