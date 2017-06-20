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

            using (var reader = new StreamReader("bmpmap.txt"))
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
            //button1.Text = "&Connect";
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

                bmp.Save("example.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                File.Create("bmpmap.txt").Close();
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
            using (var writer = new StreamWriter("bmpmap.txt", append: true))
            {
                writer.WriteLine("{0} {1} {2}", binaryR, binaryG, binaryB);
            }
            waitHandle.Set();
        }

        private void btnMakePhoto_Click(object sender, EventArgs e)
        {
            Bitmap bmp = ((IProvidesBitmapOutput)camera).GetBitmap();
            backgroundWorker1.CancelAsync();
            pictureBoxCamera.Image = bmp;
        }

        private void btnConnectCamera_Click(object sender, EventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                //button1.Text = "&Disconnect";
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

        public Image Resize(Image originalImage, int w, int h)
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
            Image resizedImage = Resize(pictureBoxCamera.Image, Convert.ToInt32(textWidth.Text), Convert.ToInt32(textHeight.Text));
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

        private void btnScaleSelection_Click(object sender, EventArgs e)
        {
            Image original = pictureBoxTest.Image;
            pictureBoxTest.Image = Resize(original, original.Width * Convert.ToInt32(txtScaleRatio.Text), original.Height * Convert.ToInt32(txtScaleRatio.Text));
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
                    //default_image.SetPixel(x, y, Color.Transparent);
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
            int sizeOfImage = 100;

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

        private void SimpleBinarize()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);
            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < 480; ++y)
                {
                    int intensityOfPixel = GetIntensityOfPixel(default_image, x, y);
                    int isBlack = intensityOfPixel >= 127 ? 0 : 1;
                    if (isBlack == 1)
                    {
                        default_image.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        default_image.SetPixel(x, y, Color.White);
                    }
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void btnSimpleBinarize_Click(object sender, EventArgs e)
        {
            SimpleBinarize();
        }

        private void Niblack()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);

            int w = 480; // size of image
            double k = 0.2; // or -0.2
            int averageM = 0;
            double averageBias = 0.0;

            int[] intensities = new int[w * w];

            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < w; ++y)
                {
                    int intensity = GetIntensityOfPixel(default_image, x, y);
                    averageM += intensity;
                    averageBias += (intensity * intensity);
                    intensities[x * w + y] = intensity;
                }
            }
            averageM /= (640 * w);
            averageBias = Math.Sqrt(averageBias / (w * w));

            for (int i = 0; i < w * w; i++)
            {
                int intensity = intensities[i];
                k = intensity >= 127 ? 0.2 : -0.2;
                double local_treshold = averageM + (k * averageBias);
                if (intensity <= local_treshold)
                {
                    default_image.SetPixel(i / w, i % w, Color.White);
                }
                else
                {
                    default_image.SetPixel(i / w, i % w, Color.Black);
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void btnNiblack_Click(object sender, EventArgs e)
        {
            Niblack();
        }

        private byte MaxInByteArr(byte[] array, int size)
        {
            byte max = array[0];
            for (int i = 1; i < size; i++)
            {
                max = Math.Max(max, array[i]);
            }
            return max;
        }

        private byte MinInByteArr(byte[] array, int size)
        {
            byte min = array[0];
            for (int i = 1; i < size; i++)
            {
                min = Math.Min(min, array[i]);
            }
            return min;
        }

        private void Bernsen()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);

            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < 480; ++y)
                {
                    Color color = default_image.GetPixel(x, y);

                    byte[] rgb = new byte[3];
                    rgb[0] = color.R;
                    rgb[1] = color.G;
                    rgb[2] = color.B;

                    byte maxIntensity = MaxInByteArr(rgb, 3);
                    byte minIntensity = MinInByteArr(rgb, 3);
                    int average = (Convert.ToInt32(maxIntensity) + Convert.ToInt32(minIntensity)) / 2;

                    int isBlack = average <= 127 ? 1 : 0;
                    if (isBlack == 1)
                    {
                        default_image.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        default_image.SetPixel(x, y, Color.White);
                    }
                }
            }
            pictureBoxCamera.Image = default_image;
        }

        private void btnBernsen_Click(object sender, EventArgs e)
        {
            Bernsen();
        }

        private void Average()
        {
            Bitmap default_image = new Bitmap(pictureBoxCamera.Image);

            int totalIntensity = 0;
            int[] intensities = new int[640 * 480];

            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < 480; ++y)
                {
                    int intensity = GetIntensityOfPixel(default_image, x, y);
                    totalIntensity += intensity;
                    intensities[x * 480 + y] = intensity;
                }
            }
            int treshold = totalIntensity / (640 * 480);

            for (int i = 0; i < 640 * 480; i++)
            {
                if (intensities[i] <= treshold)
                {
                    default_image.SetPixel(i / 480, i % 480, Color.Black);
                }
                else
                {
                    default_image.SetPixel(i / 480, i % 480, Color.White);
                }
            }

            pictureBoxCamera.Image = default_image;
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            Average();
        }

    }
}