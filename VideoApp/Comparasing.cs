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
using Lomont;

namespace VideoApp
{
    public partial class Form1 : Form
    {
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

            double mseDev = totalKorr / (5 * 40 * 30);

            textBoxDeviation.Text = Convert.ToString(mseDev);

            return mseDev;
        }

        private void btnMSE_Click(object sender, EventArgs e)
        {
            double dev = MSEComparation();
        }

        private void btnSSIM_Click(object sender, EventArgs e)
        {
            SSIM ssim = new SSIM();
            Bitmap etalonBitmap = new Bitmap(pictureBoxTest.Image);
            Bitmap candidateBitmap = new Bitmap(pictureBoxCandidateTest.Image);
            double dev = ssim.Index(etalonBitmap, candidateBitmap);
            textBoxDeviationSSIM.Text = Convert.ToString(dev);
        }
    }
}