using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetriCam;
using AForge;
using AForge.Video.DirectShow;
using System.Timers;

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private WebCam camera;

        System.Timers.Timer aTimer;


        public Form1()
        {
            InitializeComponent();
            camera = new WebCam();

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                //button1.Text = "&Disconnect";
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                StoreFrame(camera);
                backgroundWorker1.CancelAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                button1.Text = "&Disconnect";
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                StoreFrame(camera);
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                camera.Update();
                pictureBox1.Image = camera.GetBitmap();
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
        /// <remarks>If the camera does not support Bitmap output, the frame from the active channel is fetched and converted to a bitmap.</remarks>
        private static void StoreFrame(IMetriCamera camera)
        {
            Bitmap bmp;
            if (camera is IProvidesBitmapOutput)
            {
                Console.WriteLine("Bitmap output is available.");
                bmp = ((IProvidesBitmapOutput)camera).GetBitmap();
            }
            else
            {
                Console.WriteLine("Bitmap output is not available. Converting active channel.");
                bmp = ConvertToBitmap(camera.GetActiveChannel());
            }
            bmp.Save("example.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Converts a 2-D float array to a grayscale Bitmap. The color depth is reduced to 8 bit.
        /// </summary>
        /// <param name="frame">Channel data.</param>
        /// <returns>Bitmap representation of the channel data.</returns>
        private static unsafe Bitmap ConvertToBitmap(float[,] frame)
        {
            float maxVal = float.MinValue;
            float minVal = float.MaxValue;
            // Find minimal and maximal gray value.
            for (int y = 0; y < frame.GetLength(0); y++)
            {
                for (int x = 0; x < frame.GetLength(1); x++)
                {
                    float val = frame[y, x];
                    if (val > maxVal)
                        maxVal = val;
                    if (val < minVal)
                        minVal = val;
                }
            }
            Bitmap result = new Bitmap(frame.GetLength(1), frame.GetLength(0), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, frame.GetLength(1), frame.GetLength(0));
            System.Drawing.Imaging.BitmapData bitmapData = result.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            // Scale the gray values to 8-bit range and store them in the bitmap memory.
            byte* bmpPtr = (byte*)bitmapData.Scan0;
            for (int y = 0; y < frame.GetLength(0); y++)
            {
                byte* linePtr = bmpPtr + bitmapData.Stride * y;
                for (int x = 0; x < frame.GetLength(1); x++)
                {
                    byte value = (byte)(byte.MaxValue * (frame[y, x] - minVal) / (maxVal - minVal));
                    *linePtr++ = value;
                    *linePtr++ = value;
                    *linePtr++ = value;
                }
            }
            result.UnlockBits(bitmapData);
            return result;
        }
    }
}
