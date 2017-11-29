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
        private int defaultWidthOffset = 0;
        private int defaultHeightOffset = 0;

        private int imageClass = 0;

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

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
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
                            if (xloc <= 0 || yloc <= 0 || xloc >= width - 1 || yloc >= height - 1)
                            {
                                break;
                            }

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
                        int intencity = GetIntensityOfPixel(recBitmap, glob * 30 + i, j);
                        if (intencity <= 230)
                        {
                            etalon3040Matrix[glob][i][j] = countOfElems;
                        }
                    }
                }
                countOfElems++;
            }
        }

        private void DrawRecognized(Bitmap default_image, int xmin, int xmax, int ymin, int ymax)
        {
            recGraphics.DrawImage(default_image, new Rectangle(defaultWidthOffset, defaultHeightOffset, 30, 40),
               xmin, ymin, xmax - xmin + 1, ymax - ymin + 1, GraphicsUnit.Pixel);

            defaultWidthOffset += 30;
            //defaultHeightOffset += 40;
        }

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
    }
}