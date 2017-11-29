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
        private int[] GetImageHistogram(Bitmap _image)
        {
            int width = _image.Width;
            int height = _image.Height;
            int histSize = 256;
            int[] hist = new int[histSize];

            for (int i = 0; i < histSize; i++)
            {
                hist[i] = 0;
            }

            /* Считаем сколько каких полутонов */
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    hist[GetIntensityOfPixel(_image, x, y)]++;
                }
            }
            return hist;
        }

        private int GetIntensityOfPixel(Bitmap image, int x, int y)
        {
            Color color = image.GetPixel(x, y);

            byte[] rgb = new byte[3];
            rgb[0] = color.R;
            rgb[1] = color.G;
            rgb[2] = color.B;

            int uintR = Convert.ToInt32(rgb[0]);
            int uintG = Convert.ToInt32(rgb[1]);
            int uintB = Convert.ToInt32(rgb[2]);

            return (uintR + uintG + uintB) / 3;
        }

        private Bitmap SegmentImageWithGlobalTreshold(Bitmap sourceBitmap, int _treshold)
        {
            imageMatrix = new int[sourceBitmap.Width][];
            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                imageMatrix[i] = new int[sourceBitmap.Height];
            }

            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int byteOffset = 0;

            for (int offsetY = 0; offsetY < sourceBitmap.Height; offsetY++)
            {
                for (int offsetX = 0; offsetX < sourceBitmap.Width; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    Int32 pixelValue = BitConverter.ToInt32(pixelBuffer, byteOffset);
                    byte[] pixel = BitConverter.GetBytes(pixelValue);
                    Int32 pixelBright = (pixel[0] + pixel[1] + pixel[2]) / 3;

                    if (pixelBright < _treshold)
                    {
                        resultBuffer[byteOffset] = 0;
                        resultBuffer[byteOffset + 1] = 0;
                        resultBuffer[byteOffset + 2] = 0;
                        resultBuffer[byteOffset + 3] = 255;
                        imageMatrix[offsetX][offsetY] = 1;
                    }
                    else
                    {
                        resultBuffer[byteOffset] = 255;
                        resultBuffer[byteOffset + 1] = 255;
                        resultBuffer[byteOffset + 2] = 255;
                        resultBuffer[byteOffset + 3] = 255;
                        imageMatrix[offsetX][offsetY] = 0;
                    }
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }
}