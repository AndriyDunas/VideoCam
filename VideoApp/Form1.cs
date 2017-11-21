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
        private WebCam camera;

        System.Timers.Timer aTimer;
        private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        bool writingToFile = false;

        private System.Drawing.Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        Color etalonColor = Color.LimeGreen;
        Color candidateColor = Color.DarkOrange;
        Color colorToFillRecognized;

        Graphics recGraphics;
        Bitmap recBitmap;

        int[][] imageMatrix;
        int[][] recImageMatrix;

        int[][][] etalon3040Matrix;
        int[][][] candidate3040Matrix;

        string[] ClassesArray = new string[100];

        enum Coords
        {
            X = 0,
            Y,
            Z
        };

        double[][] affineMulMatrix;
        double[] pointVector;

        public Form1()
        {
            InitializeComponent();
            camera = new WebCam();
            aTimer = new System.Timers.Timer();

            Rect = new Rectangle();
            selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

            affineMulMatrix = new double[3][];
            pointVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                affineMulMatrix[i] = new double[3];
            }

            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 3000;
            //aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {

        }

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

        private void btnSaveImageToTxt_Click(object sender, EventArgs e)
        {
            if (!writingToFile)
            {
                StoreFrame(camera);
            }
            backgroundWorker1.CancelAsync();
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

            //affineMulMatrix[0][0] = cosalpha;
            //affineMulMatrix[0][1] = sinalpha;
            //affineMulMatrix[1][0] = -sinalpha;
            //affineMulMatrix[1][1] = cosalpha;

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

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private void btnSimpleBinarize_Click(object sender, EventArgs e)
        {
            btnSimpleBinarize.BackColor = Color.LightGreen;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            int treshold = Convert.ToInt32(textBoxSimpleBinTreshold.Text);
            pictureBoxCamera.Image = SegmentImageWithGlobalTreshold(default_image, treshold);
        }

        private void Niblack(Bitmap default_image, Bitmap new_image)
        {
            int height = default_image.Height;
            int width = default_image.Width;

            int w = Convert.ToInt32(textBoxNiblackStep.Text);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; ++y)
                {
                    double averageM = 0;
                    int totalWindowIntencity = 0;
                    int numberOfProcessedPixels = 0;

                    for (int i = x - w / 2; i < x + w / 2; i++)
                    {
                        for (int j = y - w / 2; j < y + w / 2; j++)
                        {
                            if (i < 0 || i >= width || j < 0 || j >= height)
                            {
                                continue;
                            }
                            else
                            {
                                totalWindowIntencity += GetIntensityOfPixel(default_image, i, j);
                                numberOfProcessedPixels++;
                            }
                        }
                    }
                    averageM = totalWindowIntencity / numberOfProcessedPixels;

                    double sumOfWindow = 0;
                    double averageS = 0;
                    numberOfProcessedPixels = 0;

                    for (int i = x - w / 2; i < x + w / 2; i++)
                    {
                        for (int j = y - w / 2; j < y + w / 2; j++)
                        {
                            if (i < 0 || i >= width || j < 0 || j >= height)
                            {
                                break;
                            }
                            else
                            {
                                double intencity = GetIntensityOfPixel(default_image, i, j);
                                double pow = Math.Pow(intencity - averageM, 2.0);
                                sumOfWindow += pow;
                                numberOfProcessedPixels++;
                            }
                        }
                    }
                    averageS = Math.Sqrt(sumOfWindow / numberOfProcessedPixels);

                    int localIntencity = GetIntensityOfPixel(default_image, x, y);
                    double k = localIntencity <= 127 ? -0.2 : 0.2;
                    double local_treshold = averageM + k * averageS;
                    if (localIntencity <= local_treshold)
                    {
                        new_image.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        new_image.SetPixel(x, y, Color.White);
                    }
                }
            }
        }

        private void btnNiblack_Click(object sender, EventArgs e)
        {
            btnNiblack.BackColor = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            Bitmap new_image = new Bitmap(default_image);
            Niblack(default_image, new_image);
            pictureBoxCamera.Image = new_image;
        }

        private int OtsuTreshold(int[] data)
        {
            // Otsu's threshold algorithm
            // C++ code by Jordan Bevik <Jordan.Bevic@qtiworld.com>
            // ported to ImageJ plugin by G.Landini
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

        private int YenTreshold(int[] data)
        {
            // Implements Yen  thresholding method
            // 1) Yen J.C., Chang F.J., and Chang S. (1995) "A New Criterion 
            //    for Automatic Multilevel Thresholding" IEEE Trans. on Image 
            //    Processing, 4(3): 370-378
            // 2) Sezgin M. and Sankur B. (2004) "Survey over Image Thresholding 
            //    Techniques and Quantitative Performance Evaluation" Journal of 
            //    Electronic Imaging, 13(1): 146-165
            //    http://citeseer.ist.psu.edu/sezgin04survey.html
            //
            // M. Emre Celebi
            // 06.15.2007
            // Ported to ImageJ plugin by G.Landini from E Celebi's fourier_0.8 routines
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
            //  Zack, G. W., Rogers, W. E. and Latt, S. A., 1977,
            //  Automatic Measurement of Sister Chromatid Exchange Frequency,
            // Journal of Histochemistry and Cytochemistry 25 (7), pp. 741-753
            //
            //  modified from Johannes Schindelin plugin
            // 
            // find min and max
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

            // The Triangle algorithm cannot tell whether the data is skewed to one side or another.
            // This causes a problem as there are 2 possible thresholds between the max and the 2 extremes
            // of the histogram.
            // Here I propose to find out to which side of the max point the data is furthest, and use that as
            //  the other extreme.
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

        private void btnToDefaultImage_Click(object sender, EventArgs e)
        {
            if (camera.IsConnected())
            {
                backgroundWorker1.CancelAsync();
            }
            pictureBoxCamera.Image = VideoApp.Properties.Resources.digits;
        }

        public Bitmap MedianFilter(Bitmap sourceBitmap, int matrixSize, int bias = 0, bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
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
            bool brushWhite = false;
            Moving moving = Moving.RIGHT;
            //int number = 0;


            //for (int y = 10; y < height - 10; y++)
            //{
            //    for (int x = 10; x < width - 10; x++)
            //    {
            //        if (imageMatrix[x][y] == 1)
            //        {
            //            int xloc = x;
            //            int yloc = y;
            //            moving = Moving.RIGHT;
            //            number = 0;

            //            do
            //            {
            //                int intencity_right = imageMatrix[xloc + 1][yloc];
            //                int intencity_down = imageMatrix[xloc][yloc + 1];
            //                int intencity_left = imageMatrix[xloc - 1][yloc];
            //                int intencity_up = imageMatrix[xloc][yloc - 1];
            //                int intencity_right_up = imageMatrix[xloc + 1][yloc - 1];
            //                int intencity_left_up = imageMatrix[xloc - 1][yloc - 1];
            //                int intencity_down_right = imageMatrix[xloc + 1][yloc + 1];
            //                int intencity_left_down = imageMatrix[xloc - 1][yloc + 1];

            //                if (moving == Moving.RIGHT)
            //                {
            //                    if (intencity_down == 1 && intencity_right == 0)
            //                    {
            //                        yloc++;
            //                        number++;
            //                        moving = Moving.DOWN;
            //                    }
            //                    else if (intencity_up == 1 && intencity_left_up == 0)
            //                    {
            //                        yloc--;
            //                        number++;
            //                        moving = Moving.UP;
            //                    }
            //                    else if (intencity_right == 1)
            //                    {
            //                        xloc++;
            //                        number++;
            //                    }
            //                }
            //                else if (moving == Moving.DOWN)
            //                {
            //                    if (intencity_right == 1 && intencity_right_up == 0)
            //                    {
            //                        xloc++;
            //                        number++;
            //                        moving = Moving.RIGHT;
            //                    }
            //                    else if (intencity_left == 1 && intencity_down == 0)
            //                    {
            //                        xloc--;
            //                        number++;
            //                        moving = Moving.LEFT;
            //                    }
            //                    else if (intencity_down == 1)
            //                    {
            //                        yloc++;
            //                        number++;
            //                    }
            //                }
            //                else if (moving == Moving.LEFT)
            //                {
            //                    if (intencity_down == 1 && intencity_down_right == 0)
            //                    {
            //                        yloc++;
            //                        number++;
            //                        moving = Moving.DOWN;
            //                    }
            //                    else if (intencity_up == 1 && intencity_left == 0)
            //                    {
            //                        yloc--;
            //                        number++;
            //                        moving = Moving.UP;
            //                    }
            //                    else if (intencity_left == 1)
            //                    {
            //                        xloc--;
            //                        number++;
            //                    }
            //                }
            //                else if (moving == Moving.UP)
            //                {
            //                    if (intencity_right == 1 && intencity_up == 0)
            //                    {
            //                        xloc++;
            //                        number++;
            //                        moving = Moving.RIGHT;
            //                    }
            //                    else if (intencity_left == 1 && intencity_left_down == 0)
            //                    {
            //                        xloc--;
            //                        number++;
            //                        moving = Moving.LEFT;
            //                    }
            //                    else if (intencity_up == 1)
            //                    {
            //                        yloc--;
            //                        number++;
            //                    }
            //                }

            //                if (number == 14)
            //                    break;
                            
            //            } while (xloc != x || yloc != y);

            //            if (number < 14)
            //                new_image.SetPixel(x, y, Color.DarkOrange);
            //        }
            //    }
            //}

            int NumberTres = 3;//Convert.ToInt32(textBoxPixelsTres.Text);

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




            //for (int x = w / 2; x < width; x += w)
            //{
            //    for (int y = w / 2; y < height; y += w)
            //    {
            //        int numberOfBlackPixelsLeft = 0;
            //        int numberOfBlackPixelsRight = 0;
            //        int numberOfBlackPixelsTop = 0;
            //        int numberOfBlackPixelsDown = 0;
            //        for (int i = x - w / 2; i < x; i++)
            //        {
            //            for (int j = y - w / 2; j < y + w / 2; j++)
            //            {
            //                if (GetIntensityOfPixel(default_image, i, j) <= 127)
            //                {
            //                    numberOfBlackPixelsLeft++;
            //                }
            //            }
            //        }
            //        for (int i = x; i < x + w / 2; i++)
            //        {
            //            for (int j = y - w / 2; j < y + w / 2; j++)
            //            {
            //                if (GetIntensityOfPixel(default_image, i, j) <= 127)
            //                {
            //                    numberOfBlackPixelsRight++;
            //                }
            //            }
            //        }
            //        for (int i = x - w / 2; i < x + w / 2; i++)
            //        {
            //            for (int j = y - w / 2; j < y; j++)
            //            {
            //                if (GetIntensityOfPixel(default_image, i, j) <= 127)
            //                {
            //                    numberOfBlackPixelsTop++;
            //                }
            //            }
            //        }
            //        for (int i = x - w / 2; i < x + w / 2; i++)
            //        {
            //            for (int j = y; j < y + w / 2; j++)
            //            {
            //                if (GetIntensityOfPixel(default_image, i, j) <= 127)
            //                {
            //                    numberOfBlackPixelsDown++;
            //                }
            //            }
            //        }
            //        int tres = 8;

            //        if (numberOfBlackPixelsLeft < tres && numberOfBlackPixelsRight < tres && numberOfBlackPixelsTop < tres && numberOfBlackPixelsDown < tres)
            //        {
            //            brushWhite = true;
            //        }



            //        if (brushWhite)
            //        {
            //            for (int i = x - w / 2; i < x + w / 2; i++)
            //            {
            //                for (int j = y - w / 2; j < y + w / 2; j++)
            //                {
            //                    if (i < width && j < height)
            //                        new_image.SetPixel(i, j, Color.White);
            //                }
            //            }
            //            brushWhite = false;
            //            continue;
            //        }
            //    }
            //}
        }

        private void btnNPixelsFilter_Click(object sender, EventArgs e)
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            Bitmap new_image = default_image;
            NPixelsFilter(default_image, new_image);
            pictureBoxCamera.Image = new_image;
        }

        enum Moves
        {
            Right = 0,
            Down,
            Left,
            Up
        };

        enum Moving
        {
            RIGHT_DOWN = 0,
            LEFT_DOWN,
            LEFT_UP,
            RIGHT_UP,
            RIGHT,
            LEFT,
            UP,
            DOWN
        };

        private void MakeCounters(Bitmap _image)
        {
            int width = _image.Width;
            int height = _image.Height;

            recImageMatrix = new int[_image.Width][];
            for (int i = 0; i < _image.Width; i++)
            {
                recImageMatrix[i] = new int[_image.Height];
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                    recImageMatrix[i][j] = 0;
            }




            int ymin = 1000, ymax = 0, xmin = 1000, xmax = 0;
            int recognizedElementNumber = 1;

            Moving moving = Moving.RIGHT;

            for (int y = 10; y < height-5; y++)
            {
                for (int x = 10; x < width-5; x++)
                {
                    if (imageMatrix[x][y] == 1 && recImageMatrix[x][y] == 0)
                    {
                        recImageMatrix[x][y] = recognizedElementNumber;
                        
                        int xloc = x;
                        int yloc = y;
                        moving = Moving.RIGHT;

                        ymax = 0;
                        xmin = 1000;
                        xmax = 0;

                        ymin = y;
                        do
                        {
                            int intencity_right = imageMatrix[xloc + 1][yloc];
                            int intencity_down = imageMatrix[xloc][yloc + 1];
                            int intencity_left = imageMatrix[xloc - 1][yloc];
                            int intencity_up = imageMatrix[xloc][yloc - 1];
                            int intencity_right_up = imageMatrix[xloc + 1][yloc - 1];
                            int intencity_left_up = imageMatrix[xloc - 1][yloc - 1];
                            int intencity_down_right = imageMatrix[xloc + 1][yloc + 1];
                            int intencity_left_down = imageMatrix[xloc - 1][yloc + 1];

                            if (moving == Moving.RIGHT)
                            {
                                if (intencity_down == 1 && intencity_right == 0)
                                {
                                    yloc++;
                                    _image.SetPixel(xloc, yloc, Color.Red);
                                    moving = Moving.DOWN;
                                }
                                else if (intencity_up == 1 && intencity_left_up == 0)
                                {
                                    yloc--;
                                    _image.SetPixel(xloc, yloc, Color.Red);
                                    moving = Moving.UP;
                                }
                                else if (intencity_right == 1)
                                {
                                    xloc++;
                                    _image.SetPixel(xloc, yloc, Color.Red);
                                }
                            }
                            else if (moving == Moving.DOWN)
                            {
                                if (intencity_right == 1 && intencity_right_up == 0)
                                {
                                    xloc++;
                                    _image.SetPixel(xloc, yloc, Color.Green);
                                    moving = Moving.RIGHT;
                                }
                                else if (intencity_left == 1 && intencity_down == 0)
                                {
                                    xloc--;
                                    _image.SetPixel(xloc, yloc, Color.Green);
                                    moving = Moving.LEFT;
                                }
                                else if (intencity_down == 1)
                                {
                                    yloc++;
                                    _image.SetPixel(xloc, yloc, Color.Green);
                                }
                            }
                            else if (moving == Moving.LEFT)
                            {
                                if (intencity_down == 1 && intencity_down_right == 0)
                                {
                                    yloc++;
                                    _image.SetPixel(xloc, yloc, Color.Yellow);
                                    moving = Moving.DOWN;
                                }
                                else if (intencity_up == 1 && intencity_left == 0)
                                {
                                    yloc--;
                                    _image.SetPixel(xloc, yloc, Color.Yellow);
                                    moving = Moving.UP;
                                }
                                else if (intencity_left == 1)
                                {
                                    xloc--;
                                    _image.SetPixel(xloc, yloc, Color.Yellow);
                                }
                            }
                            else if (moving == Moving.UP)
                            {
                                if (intencity_right == 1 && intencity_up == 0)
                                {
                                    xloc++;
                                    _image.SetPixel(xloc, yloc, Color.Blue);
                                    moving = Moving.RIGHT;
                                }
                                else if (intencity_left == 1 && intencity_left_down == 0)
                                {
                                    xloc--;
                                    _image.SetPixel(xloc, yloc, Color.Blue);
                                    moving = Moving.LEFT;
                                }
                                else if (intencity_up == 1)
                                {
                                    yloc--;
                                    _image.SetPixel(xloc, yloc, Color.Blue);
                                }
                            }
                            recImageMatrix[xloc][yloc] = recognizedElementNumber;

                            if (yloc > ymax) ymax = yloc;
                            if (xloc > xmax) xmax = xloc;
                            if (xloc < xmin) xmin = xloc;

                        } while (xloc != x || yloc != y);

                        for (int a = xmin; a < xmax; a++)
                            for (int b = ymin; b < ymax; b++)
                                if (imageMatrix[a][b] == 1)
                                {
                                    recImageMatrix[a][b] = recognizedElementNumber;
                                    _image.SetPixel(a, b, colorToFillRecognized);
                                }
                        recognizedElementNumber++;
                        DrawRecognized(_image, xmin, xmax, ymin, ymax);
                    }
                }
            }

        }

        private void Recognize(Bitmap _image)
        {
            MakeCounters(_image);
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            colorToFillRecognized = etalonColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            PrepareGraphics(default_image);
            Recognize(default_image);
            
            defaultWidthOffset = 0;
            
            recGraphics.Dispose();

            pictureBoxTest.Image = recBitmap;

            int countOfElems = 1;


            etalon3040Matrix = new int[20][][];
            for (int i = 0; i < 20; i++)
            {
                etalon3040Matrix[i] = new int[30][];
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                    etalon3040Matrix[i][j] = new int[40];
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    for (int k = 0; k < 40; k++)
                    {
                        etalon3040Matrix[i][j][k] = 0;
                    }
                }
            }

            for (int glob = 0; glob < 5; glob++)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        int intencity = GetIntensityOfPixel(recBitmap, glob*30 + i, j);
                        if (intencity <= 230)
                        {
                            etalon3040Matrix[glob][i][j] = countOfElems;
                        }
                    }
                }
                countOfElems++;
            }
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

        private int defaultWidthOffset = 0;
        private int defaultHeightOffset = 0;

        private void DrawRecognized(Bitmap default_image, int xmin, int xmax, int ymin, int ymax)
        {
            //draw the original image on the new image
            recGraphics.DrawImage(default_image, new Rectangle(defaultWidthOffset, defaultHeightOffset, 30, 40),
               xmin, ymin, xmax-xmin+1, ymax-ymin+1, GraphicsUnit.Pixel);

            defaultWidthOffset += 30;
            //defaultHeightOffset += 40;
        }

        private int imageClass = 0;

        private void btnSetClass_Click(object sender, EventArgs e)
        {
            ClassesArray[imageClass] = textBoxClassName.Text;
        }

        private void pictureBoxTest_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            

            imageClass = etalon3040Matrix[coordinates.X / 30][coordinates.X % 30][coordinates.Y];
            MessageBox.Show(string.Format("X: {0} Y: {1}", coordinates.X, coordinates.Y));
        }

        private void btnRecognizeCandidate_Click(object sender, EventArgs e)
        {
            colorToFillRecognized = candidateColor;
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            PrepareGraphics(default_image);
            Recognize(default_image);           
            defaultWidthOffset = 0;
            recGraphics.Dispose();

            pictureBoxCandidateTest.Image = recBitmap;

            int countOfElems = 1;

            candidate3040Matrix = new int[20][][];
            for (int i = 0; i < 20; i++)
            {
                candidate3040Matrix[i] = new int[30][];
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                    candidate3040Matrix[i][j] = new int[40];
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    for (int k = 0; k < 40; k++)
                    {
                        candidate3040Matrix[i][j][k] = 0;
                    }
                }
            }

            for (int glob = 0; glob < 5; glob++)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        int intencity = GetIntensityOfPixel(recBitmap, glob * 30 + i, j);
                        if (intencity <= 230)
                        {
                            candidate3040Matrix[glob][i][j] = countOfElems;
                        }
                    }
                }
                countOfElems++;
            }

        }

        private double MSEComparation()
        {
            double totalKorr = 0.0;

            Bitmap etalonBitmap = new Bitmap(pictureBoxTest.Image);
            Bitmap candidateBitmap = new Bitmap(pictureBoxCandidateTest.Image);

            for (int glob = 0; glob < 5; glob++)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        int intencityCandidate = GetIntensityOfPixel(candidateBitmap, glob * 30 + i, j);
                        int intencityEtalon = GetIntensityOfPixel(etalonBitmap, glob * 30 + i, j);
                        double intencityPow = Math.Pow(Math.Abs(intencityCandidate - intencityEtalon), 2.0);
                        totalKorr += intencityPow;
                    }
                }
            }

            double mseDev = totalKorr / (5*40*30);

            textBoxDeviation.Text = Convert.ToString(mseDev);

            return mseDev;
        }

        private void btnMSE_Click(object sender, EventArgs e)
        {
            double dev = MSEComparation();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxCamera_Click(object sender, EventArgs e)
        {

        }

        private void lblDeviation_Click(object sender, EventArgs e)
        {

        }

    }
}