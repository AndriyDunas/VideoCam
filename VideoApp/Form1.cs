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

        Bitmap originalImage;


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

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;

        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //aTimer.Enabled = false;
            originalImage = new Bitmap(pictureBoxCamera.Image);
            btnSimpleBinarize_Click(null, null);
            Thread.Sleep(1500);

            pictureBoxCamera.Image = originalImage;
            Thread.Sleep(1500);
            btnNiblack_Click(null, null);
            Thread.Sleep(1500);

            pictureBoxCamera.Image = originalImage;
            Thread.Sleep(1500);
            btnOtsu_Click(null, null);
            Thread.Sleep(1500);

            pictureBoxCamera.Image = originalImage;
            Thread.Sleep(1500);
            btnYen_Click(null, null);
            Thread.Sleep(1500);

            pictureBoxCamera.Image = originalImage;
            Thread.Sleep(1500);
            btnTriangle_Click(null, null);
            Thread.Sleep(1500);

            //pictureBoxCamera.Image = originalImage;
        }

        private void btnDemonstrateMethods_Click(object sender, EventArgs e)
        {
            aTimer.Enabled = true;
        }


    }
}