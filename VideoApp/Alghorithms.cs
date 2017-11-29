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
        private int YenTreshold(int[] data)
        {
            int threshold;
            int ih, it;
            double crit;
            double max_crit;
            double[] norm_histo = new double[256]; /* normalized histogram */
            double[] P1 = new double[256]; /* cumulative normalized histogram */
            double[] P1_sq = new double[256];
            double[] P2_sq = new double[256];

            double total = 0;
            for (ih = 0; ih < 256; ih++)
                total += data[ih];

            for (ih = 0; ih < 256; ih++)
                norm_histo[ih] = data[ih] / total;

            P1[0] = norm_histo[0];
            for (ih = 1; ih < 256; ih++)
                P1[ih] = P1[ih - 1] + norm_histo[ih];

            P1_sq[0] = norm_histo[0] * norm_histo[0];
            for (ih = 1; ih < 256; ih++)
                P1_sq[ih] = P1_sq[ih - 1] + norm_histo[ih] * norm_histo[ih];

            P2_sq[255] = 0.0;
            for (ih = 254; ih >= 0; ih--)
                P2_sq[ih] = P2_sq[ih + 1] + norm_histo[ih + 1] * norm_histo[ih + 1];

            /* Find the threshold that maximizes the criterion */
            threshold = -1;
            max_crit = Double.MinValue;
            for (it = 0; it < 256; it++)
            {
                // NOTE: in original algorithm used value -1 instead 2
                crit = -1.0 * ((P1_sq[it] * P2_sq[it]) > 0.0 ? Math.Log(P1_sq[it] * P2_sq[it]) : 0.0) + 2 * ((P1[it] * (1.0 - P1[it])) > 0.0 ? Math.Log(P1[it] * (1.0 - P1[it])) : 0.0);
                if (crit > max_crit)
                {
                    max_crit = crit;
                    threshold = it;
                }
            }
            return threshold;
        }

        private void btnYen_Click(object sender, EventArgs e)
        {
            btnYen.BackColor = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int[] hist = GetImageHistogram(default_image);
            int treshold = YenTreshold(hist);
            pictureBoxCamera.Image = SegmentImageWithGlobalTreshold(default_image, treshold);
        }

        int TriangleTreshold(int[] data, int length)
        {
            int min = 0, dmax = 0, max = 0, min2 = 0;
            for (int i = 0; i < length; i++)
            {
                if (data[i] > 0)
                {
                    min = i;
                    break;
                }
            }
            if (min > 0) min--; // line to the (p==0) point, not to data[min]

            for (int i = 255; i > 0; i--)
            {
                if (data[i] > 0)
                {
                    min2 = i;
                    break;
                }
            }
            if (min2 < 255) min2++; // line to the (p==0) point, not to data[min]

            for (int i = 0; i < 256; i++)
            {
                if (data[i] > dmax)
                {
                    max = i;
                    dmax = data[i];
                }
            }
            // find which is the furthest side
            //IJ.log(""+min+" "+max+" "+min2);
            bool inverted = false;
            if ((max - min) < (min2 - max))
            {
                // reverse the histogram
                //IJ.log("Reversing histogram.");
                inverted = true;
                int left = 0;          // index of leftmost element
                int right = 255; // index of rightmost element
                while (left < right)
                {
                    // exchange the left and right elements
                    int temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;
                    // move the bounds toward the center
                    left++;
                    right--;
                }
                min = 255 - min2;
                max = 255 - max;
            }

            if (min == max)
            {
                //IJ.log("Triangle:  min == max.");
                return min;
            }

            // describe line by nx * x + ny * y - d = 0
            double nx, ny, d;
            // nx is just the max frequency as the other point has freq=0
            nx = data[max];   //-min; // data[min]; //  lowest value bmin = (p=0)% in the image
            ny = min - max;
            d = Math.Sqrt(nx * nx + ny * ny);
            nx /= d;
            ny /= d;
            d = nx * min + ny * data[min];

            // find split point
            int split = min;
            double splitDistance = 0;
            for (int i = min + 1; i <= max; i++)
            {
                double newDistance = nx * i + ny * data[i] - d;
                if (newDistance > splitDistance)
                {
                    split = i;
                    splitDistance = newDistance;
                }
            }
            split--;

            if (inverted)
            {
                // The histogram might be used for something else, so let's reverse it back
                int left = 0;
                int right = 255;
                while (left < right)
                {
                    int temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;
                    left++;
                    right--;
                }
                return (255 - split);
            }
            else
                return split;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            btnTriangle.BackColor = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int[] hist = GetImageHistogram(default_image);
            int treshold = TriangleTreshold(hist, hist.GetLength(0));
            pictureBoxCamera.Image = SegmentImageWithGlobalTreshold(default_image, treshold);
        }

        private void btnSimpleBinarize_Click(object sender, EventArgs e)
        {
            btnSimpleBinarize.BackColor = Color.LightGreen;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int treshold = Convert.ToInt32(textBoxSimpleBinTreshold.Text);
            pictureBoxCamera.Image = SegmentImageWithGlobalTreshold(default_image, treshold);
        }

        private Bitmap Niblack(Bitmap sourceBitmap)
        {
            int w = Convert.ToInt32(textBoxNiblackStep.Text) / 2;

            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;

            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            int[,] intencityArray = new int[width, height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            for (int offsetY = 0; offsetY < height; offsetY++)
            {
                for (int offsetX = 0; offsetX < width; offsetX++)
                {
                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;
                    Int32 pixelValue = BitConverter.ToInt32(pixelBuffer, byteOffset);
                    byte[] pixel = BitConverter.GetBytes(pixelValue);
                    Int32 pixelBright = (pixel[0] + pixel[1] + pixel[2]) / 3;
                    intencityArray[offsetX, offsetY] = pixelBright;
                }
            }

            for (int offsetY = w; offsetY < height - w; offsetY++)
            {
                for (int offsetX = w; offsetX < width - w; offsetX++)
                {
                    double averageM = 0;
                    int totalWindowIntencity = 0;
                    int numberOfProcessedPixels = 0;

                    for (int i = offsetX - w; i < offsetX + w; i++)
                    {
                        for (int j = offsetY - w; j < offsetY + w; j++)
                        {
                            totalWindowIntencity += intencityArray[i, j];
                            numberOfProcessedPixels++;
                        }
                    }
                    averageM = totalWindowIntencity / numberOfProcessedPixels;

                    double sumOfWindow = 0;
                    double averageS = 0;
                    numberOfProcessedPixels = 0;

                    for (int i = offsetX - w; i < offsetX + w; i++)
                    {
                        for (int j = offsetY - w; j < offsetY + w; j++)
                        {
                            double pow = Math.Pow(intencityArray[i, j] - averageM, 2.0);
                            sumOfWindow += pow;
                            numberOfProcessedPixels++;
                        }
                    }

                    averageS = Math.Sqrt(sumOfWindow / numberOfProcessedPixels);
                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;
                    int localBright = intencityArray[offsetX, offsetY];

                    double k = localBright <= 127 ? -0.2 : 0.2;
                    double local_treshold = averageM + k * averageS;
                    if (localBright <= local_treshold)
                    {
                        resultBuffer[byteOffset] = 0;
                        resultBuffer[byteOffset + 1] = 0;
                        resultBuffer[byteOffset + 2] = 0;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                    else
                    {
                        resultBuffer[byteOffset] = 255;
                        resultBuffer[byteOffset + 1] = 255;
                        resultBuffer[byteOffset + 2] = 255;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                }
            }

            Bitmap resultBitmap = new Bitmap(width, height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private void btnNiblack_Click(object sender, EventArgs e)
        {
            btnNiblack.BackColor = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            pictureBoxCamera.Image = Niblack(default_image);
        }

        private int OtsuTreshold(int[] data)
        {
            int k, treshold;  // k = the current threshold; kStar = optimal threshold
            double N1, N;    // N1 = # points with intensity <=k; N = total number of points
            double BCV, BCVmax; // The current Between Class Variance and maximum BCV
            double num, denom;  // temporary bookeeping
            double Sk;  // The total intensity for all histogram points <=k
            double S, L = 256; // The total intensity of the image

            // Initialize values:
            S = N = 0;
            for (k = 0; k < L; k++)
            {
                S += (double)k * data[k];   // Total histogram intensity
                N += data[k];       // Total number of data points
            }

            Sk = 0;
            N1 = data[0]; // The entry for zero intensity
            BCV = 0;
            BCVmax = 0;
            treshold = 0;

            // Look at each possible threshold value,
            // calculate the between-class variance, and decide if it's a max
            for (k = 1; k < L - 1; k++)
            { // No need to check endpoints k = 0 or k = L-1
                Sk += (double)k * data[k];
                N1 += data[k];

                // The float casting here is to avoid compiler warning about loss of precision and
                // will prevent overflow in the case of large saturated images
                denom = (double)(N1) * (N - N1); // Maximum value of denom is (N^2)/4 =  approx. 3E10

                if (denom != 0)
                {
                    // Float here is to avoid loss of precision when dividing
                    num = ((double)N1 / N) * S - Sk;  // Maximum value of num =  255*N = approx 8E7
                    BCV = (num * num) / denom;
                }
                else
                    BCV = 0;

                if (BCV >= BCVmax)
                { // Assign the best threshold found so far
                    BCVmax = BCV;
                    treshold = k;
                }
            }
            // kStar += 1;  // Use QTI convention that intensity -> 1 if intensity >= k
            // (the algorithm was developed for I-> 1 if I <= k.)
            return treshold;
        }

        private void btnOtsu_Click(object sender, EventArgs e)
        {
            btnOtsu.BackColor = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int[] hist = GetImageHistogram(default_image);
            int treshold = OtsuTreshold(hist);
            pictureBoxCamera.Image = SegmentImageWithGlobalTreshold(default_image, treshold);
        }
    }
}