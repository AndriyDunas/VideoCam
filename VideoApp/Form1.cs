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
using System.IO;
using System.Threading;

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private WebCam camera;

        System.Timers.Timer aTimer;
        private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        bool writingToFile = false;

        public Form1()
        {
            InitializeComponent();
            camera = new WebCam();

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 3000;
            aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                //button1.Text = "&Disconnect";
                //backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                if (!writingToFile)
                {
                    StoreFrame(camera);
                }
                //backgroundWorker1.CancelAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Color> pixels = new List<Color>();
            Bitmap bmp = new Bitmap(50, 50);

            using (var reader = new StreamReader("bmpmap.txt"))
            {
                string all = reader.ReadToEnd();
                char[] separator = {'\r', '\n', ' '};
                string[] words = all.Split(separator);

                for (int i = 0; words.Length - i > 2 ; i += 2)
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
                    bmp.SetPixel(x, y, pixels[50*y + x]); 
                }
            }
            pictureBox1.Image = bmp;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (!backgroundWorker1.CancellationPending)
            //{
            //    camera.Update();
            //    pictureBox1.Image = camera.GetBitmap();
            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //camera.Disconnect();
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
                for (int y = 0; y < 50; y++)
                {
                    for (int x = 0; x < 50; ++x)
                    {
                        Color color = bmp.GetPixel(x, y);
                        WritePixelToFile(color, y, x);
                    }
                }
                
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
    }
}
