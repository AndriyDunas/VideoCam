namespace VideoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetFromTxt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnMakePhoto = new System.Windows.Forms.Button();
            this.btnConnectCamera = new System.Windows.Forms.Button();
            this.btnSaveToTxt = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.btnAffineTranslate = new System.Windows.Forms.Button();
            this.lblTranslateX = new System.Windows.Forms.Label();
            this.txtTranslateX = new System.Windows.Forms.TextBox();
            this.txtTranslateY = new System.Windows.Forms.TextBox();
            this.lblTranslateY = new System.Windows.Forms.Label();
            this.btnAffineRotate = new System.Windows.Forms.Button();
            this.btnAffineScale = new System.Windows.Forms.Button();
            this.lblScaleX = new System.Windows.Forms.Label();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.lblScaleY = new System.Windows.Forms.Label();
            this.btnSimpleBinarize = new System.Windows.Forms.Button();
            this.btnNiblack = new System.Windows.Forms.Button();
            this.btnOtsu = new System.Windows.Forms.Button();
            this.btnGraysclae = new System.Windows.Forms.Button();
            this.btnYen = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnToDefaultImage = new System.Windows.Forms.Button();
            this.panelUnused = new System.Windows.Forms.Panel();
            this.lblSimpleBinarizeTreshold = new System.Windows.Forms.Label();
            this.textBoxSimpleBinTreshold = new System.Windows.Forms.TextBox();
            this.lblNiblackStep = new System.Windows.Forms.Label();
            this.textBoxNiblackStep = new System.Windows.Forms.TextBox();
            this.btnMedianFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxMedianFilterStep = new System.Windows.Forms.TextBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.btnNPixelsFilter = new System.Windows.Forms.Button();
            this.lblN = new System.Windows.Forms.Label();
            this.textBoxNPixels = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.lblClassName = new System.Windows.Forms.Label();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.btnSetClass = new System.Windows.Forms.Button();
            this.btnRecognizeCandidate = new System.Windows.Forms.Button();
            this.btnMSE = new System.Windows.Forms.Button();
            this.btnSetImage1 = new System.Windows.Forms.Button();
            this.textBoxDeviation = new System.Windows.Forms.TextBox();
            this.lblDeviation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRotatedMinus2 = new System.Windows.Forms.Button();
            this.buttonRotatedPlus3 = new System.Windows.Forms.Button();
            this.pictureBoxCandidateTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.textBoxPixelsTres = new System.Windows.Forms.TextBox();
            this.panelUnused.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandidateTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetFromTxt
            // 
            this.btnGetFromTxt.Location = new System.Drawing.Point(94, 48);
            this.btnGetFromTxt.Name = "btnGetFromTxt";
            this.btnGetFromTxt.Size = new System.Drawing.Size(75, 35);
            this.btnGetFromTxt.TabIndex = 1;
            this.btnGetFromTxt.Text = "Get image from txt";
            this.btnGetFromTxt.UseVisualStyleBackColor = true;
            this.btnGetFromTxt.Click += new System.EventHandler(this.btnGetImageFromTxt_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnMakePhoto
            // 
            this.btnMakePhoto.Location = new System.Drawing.Point(12, 530);
            this.btnMakePhoto.Name = "btnMakePhoto";
            this.btnMakePhoto.Size = new System.Drawing.Size(99, 34);
            this.btnMakePhoto.TabIndex = 2;
            this.btnMakePhoto.Text = "Make photo";
            this.btnMakePhoto.UseVisualStyleBackColor = true;
            this.btnMakePhoto.Click += new System.EventHandler(this.btnMakePhoto_Click);
            // 
            // btnConnectCamera
            // 
            this.btnConnectCamera.Location = new System.Drawing.Point(12, 495);
            this.btnConnectCamera.Name = "btnConnectCamera";
            this.btnConnectCamera.Size = new System.Drawing.Size(99, 34);
            this.btnConnectCamera.TabIndex = 3;
            this.btnConnectCamera.Text = "Connect camera";
            this.btnConnectCamera.UseVisualStyleBackColor = true;
            this.btnConnectCamera.Click += new System.EventHandler(this.btnConnectCamera_Click);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.Location = new System.Drawing.Point(94, 8);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(74, 36);
            this.btnSaveToTxt.TabIndex = 4;
            this.btnSaveToTxt.Text = "Save image to txt";
            this.btnSaveToTxt.UseVisualStyleBackColor = true;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveImageToTxt_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(6, 8);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(82, 33);
            this.btnResize.TabIndex = 5;
            this.btnResize.Text = "Resize image";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(3, 45);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(60, 13);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "New width:";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(3, 86);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(64, 13);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "New height:";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(6, 63);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(57, 20);
            this.textWidth.TabIndex = 8;
            this.textWidth.Text = "300";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(6, 103);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(57, 20);
            this.textHeight.TabIndex = 9;
            this.textHeight.Text = "300";
            // 
            // btnAffineTranslate
            // 
            this.btnAffineTranslate.Location = new System.Drawing.Point(568, 499);
            this.btnAffineTranslate.Name = "btnAffineTranslate";
            this.btnAffineTranslate.Size = new System.Drawing.Size(86, 32);
            this.btnAffineTranslate.TabIndex = 14;
            this.btnAffineTranslate.Text = "Affine translate";
            this.btnAffineTranslate.UseVisualStyleBackColor = true;
            this.btnAffineTranslate.Click += new System.EventHandler(this.btnAffineTranslate_Click);
            // 
            // lblTranslateX
            // 
            this.lblTranslateX.AutoSize = true;
            this.lblTranslateX.Location = new System.Drawing.Point(564, 534);
            this.lblTranslateX.Name = "lblTranslateX";
            this.lblTranslateX.Size = new System.Drawing.Size(61, 13);
            this.lblTranslateX.TabIndex = 15;
            this.lblTranslateX.Text = "Translate X";
            // 
            // txtTranslateX
            // 
            this.txtTranslateX.Location = new System.Drawing.Point(567, 553);
            this.txtTranslateX.Name = "txtTranslateX";
            this.txtTranslateX.Size = new System.Drawing.Size(83, 20);
            this.txtTranslateX.TabIndex = 16;
            this.txtTranslateX.Text = "100";
            // 
            // txtTranslateY
            // 
            this.txtTranslateY.Location = new System.Drawing.Point(567, 593);
            this.txtTranslateY.Name = "txtTranslateY";
            this.txtTranslateY.Size = new System.Drawing.Size(83, 20);
            this.txtTranslateY.TabIndex = 18;
            this.txtTranslateY.Text = "100";
            // 
            // lblTranslateY
            // 
            this.lblTranslateY.AutoSize = true;
            this.lblTranslateY.Location = new System.Drawing.Point(565, 575);
            this.lblTranslateY.Name = "lblTranslateY";
            this.lblTranslateY.Size = new System.Drawing.Size(61, 13);
            this.lblTranslateY.TabIndex = 17;
            this.lblTranslateY.Text = "Translate Y";
            // 
            // btnAffineRotate
            // 
            this.btnAffineRotate.Location = new System.Drawing.Point(177, 8);
            this.btnAffineRotate.Name = "btnAffineRotate";
            this.btnAffineRotate.Size = new System.Drawing.Size(75, 33);
            this.btnAffineRotate.TabIndex = 19;
            this.btnAffineRotate.Text = "Affine rotate";
            this.btnAffineRotate.UseVisualStyleBackColor = true;
            this.btnAffineRotate.Click += new System.EventHandler(this.btnAffineRotate_Click);
            // 
            // btnAffineScale
            // 
            this.btnAffineScale.Location = new System.Drawing.Point(486, 499);
            this.btnAffineScale.Name = "btnAffineScale";
            this.btnAffineScale.Size = new System.Drawing.Size(75, 32);
            this.btnAffineScale.TabIndex = 20;
            this.btnAffineScale.Text = "Affine scale";
            this.btnAffineScale.UseVisualStyleBackColor = true;
            this.btnAffineScale.Click += new System.EventHandler(this.btnAffineScale_Click);
            // 
            // lblScaleX
            // 
            this.lblScaleX.AutoSize = true;
            this.lblScaleX.Location = new System.Drawing.Point(486, 534);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(44, 13);
            this.lblScaleX.TabIndex = 21;
            this.lblScaleX.Text = "Scale X";
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(489, 551);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(72, 20);
            this.txtScaleX.TabIndex = 22;
            this.txtScaleX.Text = "2";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(489, 593);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(72, 20);
            this.txtScaleY.TabIndex = 24;
            this.txtScaleY.Text = "2";
            // 
            // lblScaleY
            // 
            this.lblScaleY.AutoSize = true;
            this.lblScaleY.Location = new System.Drawing.Point(486, 576);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(44, 13);
            this.lblScaleY.TabIndex = 23;
            this.lblScaleY.Text = "Scale Y";
            // 
            // btnSimpleBinarize
            // 
            this.btnSimpleBinarize.Location = new System.Drawing.Point(133, 498);
            this.btnSimpleBinarize.Name = "btnSimpleBinarize";
            this.btnSimpleBinarize.Size = new System.Drawing.Size(75, 25);
            this.btnSimpleBinarize.TabIndex = 25;
            this.btnSimpleBinarize.Text = "Binarize";
            this.btnSimpleBinarize.UseVisualStyleBackColor = true;
            this.btnSimpleBinarize.Click += new System.EventHandler(this.btnSimpleBinarize_Click);
            // 
            // btnNiblack
            // 
            this.btnNiblack.Location = new System.Drawing.Point(214, 499);
            this.btnNiblack.Name = "btnNiblack";
            this.btnNiblack.Size = new System.Drawing.Size(75, 22);
            this.btnNiblack.TabIndex = 26;
            this.btnNiblack.Text = "Niblack";
            this.btnNiblack.UseVisualStyleBackColor = true;
            this.btnNiblack.Click += new System.EventHandler(this.btnNiblack_Click);
            // 
            // btnOtsu
            // 
            this.btnOtsu.Location = new System.Drawing.Point(295, 499);
            this.btnOtsu.Name = "btnOtsu";
            this.btnOtsu.Size = new System.Drawing.Size(75, 23);
            this.btnOtsu.TabIndex = 29;
            this.btnOtsu.Text = "Otsu";
            this.btnOtsu.UseVisualStyleBackColor = true;
            this.btnOtsu.Click += new System.EventHandler(this.btnOtsu_Click);
            // 
            // btnGraysclae
            // 
            this.btnGraysclae.Location = new System.Drawing.Point(396, 498);
            this.btnGraysclae.Name = "btnGraysclae";
            this.btnGraysclae.Size = new System.Drawing.Size(84, 33);
            this.btnGraysclae.TabIndex = 30;
            this.btnGraysclae.Text = "Grayscale";
            this.btnGraysclae.UseVisualStyleBackColor = true;
            this.btnGraysclae.Click += new System.EventHandler(this.btnGraysclae_Click);
            // 
            // btnYen
            // 
            this.btnYen.Location = new System.Drawing.Point(295, 523);
            this.btnYen.Name = "btnYen";
            this.btnYen.Size = new System.Drawing.Size(75, 23);
            this.btnYen.TabIndex = 31;
            this.btnYen.Text = "Yen";
            this.btnYen.UseVisualStyleBackColor = true;
            this.btnYen.Click += new System.EventHandler(this.btnYen_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(295, 549);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(75, 23);
            this.btnTriangle.TabIndex = 33;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnToDefaultImage
            // 
            this.btnToDefaultImage.Location = new System.Drawing.Point(12, 565);
            this.btnToDefaultImage.Name = "btnToDefaultImage";
            this.btnToDefaultImage.Size = new System.Drawing.Size(99, 33);
            this.btnToDefaultImage.TabIndex = 34;
            this.btnToDefaultImage.Text = "Set default image";
            this.btnToDefaultImage.UseVisualStyleBackColor = true;
            this.btnToDefaultImage.Click += new System.EventHandler(this.btnToDefaultImage_Click);
            // 
            // panelUnused
            // 
            this.panelUnused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnused.Controls.Add(this.btnResize);
            this.panelUnused.Controls.Add(this.btnGetFromTxt);
            this.panelUnused.Controls.Add(this.btnSaveToTxt);
            this.panelUnused.Controls.Add(this.labelWidth);
            this.panelUnused.Controls.Add(this.labelHeight);
            this.panelUnused.Controls.Add(this.textWidth);
            this.panelUnused.Controls.Add(this.textHeight);
            this.panelUnused.Controls.Add(this.btnAffineRotate);
            this.panelUnused.Location = new System.Drawing.Point(810, 499);
            this.panelUnused.Name = "panelUnused";
            this.panelUnused.Size = new System.Drawing.Size(257, 130);
            this.panelUnused.TabIndex = 35;
            // 
            // lblSimpleBinarizeTreshold
            // 
            this.lblSimpleBinarizeTreshold.AutoSize = true;
            this.lblSimpleBinarizeTreshold.Location = new System.Drawing.Point(132, 526);
            this.lblSimpleBinarizeTreshold.Name = "lblSimpleBinarizeTreshold";
            this.lblSimpleBinarizeTreshold.Size = new System.Drawing.Size(51, 13);
            this.lblSimpleBinarizeTreshold.TabIndex = 36;
            this.lblSimpleBinarizeTreshold.Text = "Treshold:";
            // 
            // textBoxSimpleBinTreshold
            // 
            this.textBoxSimpleBinTreshold.Location = new System.Drawing.Point(135, 545);
            this.textBoxSimpleBinTreshold.Name = "textBoxSimpleBinTreshold";
            this.textBoxSimpleBinTreshold.Size = new System.Drawing.Size(73, 20);
            this.textBoxSimpleBinTreshold.TabIndex = 37;
            this.textBoxSimpleBinTreshold.Text = "127";
            // 
            // lblNiblackStep
            // 
            this.lblNiblackStep.AutoSize = true;
            this.lblNiblackStep.Location = new System.Drawing.Point(213, 526);
            this.lblNiblackStep.Name = "lblNiblackStep";
            this.lblNiblackStep.Size = new System.Drawing.Size(32, 13);
            this.lblNiblackStep.TabIndex = 38;
            this.lblNiblackStep.Text = "Step:";
            // 
            // textBoxNiblackStep
            // 
            this.textBoxNiblackStep.Location = new System.Drawing.Point(216, 545);
            this.textBoxNiblackStep.Name = "textBoxNiblackStep";
            this.textBoxNiblackStep.Size = new System.Drawing.Size(73, 20);
            this.textBoxNiblackStep.TabIndex = 39;
            this.textBoxNiblackStep.Text = "15";
            // 
            // btnMedianFilter
            // 
            this.btnMedianFilter.Location = new System.Drawing.Point(3, 3);
            this.btnMedianFilter.Name = "btnMedianFilter";
            this.btnMedianFilter.Size = new System.Drawing.Size(75, 23);
            this.btnMedianFilter.TabIndex = 40;
            this.btnMedianFilter.Text = "Median filter";
            this.btnMedianFilter.UseVisualStyleBackColor = true;
            this.btnMedianFilter.Click += new System.EventHandler(this.btnMedianFilter_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxMedianFilterStep);
            this.panel1.Controls.Add(this.lblStep);
            this.panel1.Controls.Add(this.btnMedianFilter);
            this.panel1.Location = new System.Drawing.Point(396, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 76);
            this.panel1.TabIndex = 41;
            // 
            // textBoxMedianFilterStep
            // 
            this.textBoxMedianFilterStep.Location = new System.Drawing.Point(7, 50);
            this.textBoxMedianFilterStep.Name = "textBoxMedianFilterStep";
            this.textBoxMedianFilterStep.Size = new System.Drawing.Size(71, 20);
            this.textBoxMedianFilterStep.TabIndex = 42;
            this.textBoxMedianFilterStep.Text = "3";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(4, 33);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(32, 13);
            this.lblStep.TabIndex = 41;
            this.lblStep.Text = "Step:";
            // 
            // btnNPixelsFilter
            // 
            this.btnNPixelsFilter.Location = new System.Drawing.Point(3, 3);
            this.btnNPixelsFilter.Name = "btnNPixelsFilter";
            this.btnNPixelsFilter.Size = new System.Drawing.Size(76, 26);
            this.btnNPixelsFilter.TabIndex = 42;
            this.btnNPixelsFilter.Text = "N pixels filter";
            this.btnNPixelsFilter.UseVisualStyleBackColor = true;
            this.btnNPixelsFilter.Click += new System.EventHandler(this.btnNPixelsFilter_Click);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(3, 39);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(18, 13);
            this.lblN.TabIndex = 43;
            this.lblN.Text = "N:";
            // 
            // textBoxNPixels
            // 
            this.textBoxNPixels.Location = new System.Drawing.Point(23, 36);
            this.textBoxNPixels.Name = "textBoxNPixels";
            this.textBoxNPixels.Size = new System.Drawing.Size(55, 20);
            this.textBoxNPixels.TabIndex = 44;
            this.textBoxNPixels.Text = "2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNPixelsFilter);
            this.panel2.Controls.Add(this.textBoxNPixels);
            this.panel2.Controls.Add(this.lblN);
            this.panel2.Location = new System.Drawing.Point(396, 619);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(84, 62);
            this.panel2.TabIndex = 45;
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(13, 625);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(75, 23);
            this.btnRecognize.TabIndex = 46;
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(692, 499);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(64, 13);
            this.lblClassName.TabIndex = 47;
            this.lblClassName.Text = "Class name:";
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(695, 516);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(91, 20);
            this.textBoxClassName.TabIndex = 48;
            // 
            // btnSetClass
            // 
            this.btnSetClass.Location = new System.Drawing.Point(695, 540);
            this.btnSetClass.Name = "btnSetClass";
            this.btnSetClass.Size = new System.Drawing.Size(75, 23);
            this.btnSetClass.TabIndex = 49;
            this.btnSetClass.Text = "Set class";
            this.btnSetClass.UseVisualStyleBackColor = true;
            this.btnSetClass.Click += new System.EventHandler(this.btnSetClass_Click);
            // 
            // btnRecognizeCandidate
            // 
            this.btnRecognizeCandidate.Location = new System.Drawing.Point(13, 656);
            this.btnRecognizeCandidate.Name = "btnRecognizeCandidate";
            this.btnRecognizeCandidate.Size = new System.Drawing.Size(125, 26);
            this.btnRecognizeCandidate.TabIndex = 50;
            this.btnRecognizeCandidate.Text = "Recognize candidate";
            this.btnRecognizeCandidate.UseVisualStyleBackColor = true;
            this.btnRecognizeCandidate.Click += new System.EventHandler(this.btnRecognizeCandidate_Click);
            // 
            // btnMSE
            // 
            this.btnMSE.Location = new System.Drawing.Point(144, 656);
            this.btnMSE.Name = "btnMSE";
            this.btnMSE.Size = new System.Drawing.Size(75, 26);
            this.btnMSE.TabIndex = 52;
            this.btnMSE.Text = "MSE";
            this.btnMSE.UseVisualStyleBackColor = true;
            this.btnMSE.Click += new System.EventHandler(this.btnMSE_Click);
            // 
            // btnSetImage1
            // 
            this.btnSetImage1.Location = new System.Drawing.Point(3, 6);
            this.btnSetImage1.Name = "btnSetImage1";
            this.btnSetImage1.Size = new System.Drawing.Size(75, 23);
            this.btnSetImage1.TabIndex = 53;
            this.btnSetImage1.Text = "Rotated + 1";
            this.btnSetImage1.UseVisualStyleBackColor = true;
            this.btnSetImage1.Click += new System.EventHandler(this.btnSetImage1_Click);
            // 
            // textBoxDeviation
            // 
            this.textBoxDeviation.Location = new System.Drawing.Point(810, 659);
            this.textBoxDeviation.Name = "textBoxDeviation";
            this.textBoxDeviation.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeviation.TabIndex = 54;
            // 
            // lblDeviation
            // 
            this.lblDeviation.AutoSize = true;
            this.lblDeviation.Location = new System.Drawing.Point(807, 643);
            this.lblDeviation.Name = "lblDeviation";
            this.lblDeviation.Size = new System.Drawing.Size(55, 13);
            this.lblDeviation.TabIndex = 55;
            this.lblDeviation.Text = "Deviation:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonRotatedPlus3);
            this.panel3.Controls.Add(this.btnRotatedMinus2);
            this.panel3.Controls.Add(this.btnSetImage1);
            this.panel3.Location = new System.Drawing.Point(1074, 498);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 131);
            this.panel3.TabIndex = 56;
            // 
            // btnRotatedMinus2
            // 
            this.btnRotatedMinus2.Location = new System.Drawing.Point(84, 6);
            this.btnRotatedMinus2.Name = "btnRotatedMinus2";
            this.btnRotatedMinus2.Size = new System.Drawing.Size(75, 23);
            this.btnRotatedMinus2.TabIndex = 54;
            this.btnRotatedMinus2.Text = "Rotated + 2";
            this.btnRotatedMinus2.UseVisualStyleBackColor = true;
            this.btnRotatedMinus2.Click += new System.EventHandler(this.btnRotatedMinus2_Click);
            // 
            // buttonRotatedPlus3
            // 
            this.buttonRotatedPlus3.Location = new System.Drawing.Point(165, 7);
            this.buttonRotatedPlus3.Name = "buttonRotatedPlus3";
            this.buttonRotatedPlus3.Size = new System.Drawing.Size(75, 23);
            this.buttonRotatedPlus3.TabIndex = 55;
            this.buttonRotatedPlus3.Text = "Rotated + 3";
            this.buttonRotatedPlus3.UseVisualStyleBackColor = true;
            this.buttonRotatedPlus3.Click += new System.EventHandler(this.buttonRotatedPlus3_Click);
            // 
            // pictureBoxCandidateTest
            // 
            this.pictureBoxCandidateTest.Location = new System.Drawing.Point(668, 257);
            this.pictureBoxCandidateTest.Name = "pictureBoxCandidateTest";
            this.pictureBoxCandidateTest.Size = new System.Drawing.Size(640, 235);
            this.pictureBoxCandidateTest.TabIndex = 51;
            this.pictureBoxCandidateTest.TabStop = false;
            // 
            // pictureBoxTest
            // 
            this.pictureBoxTest.Location = new System.Drawing.Point(668, 12);
            this.pictureBoxTest.Name = "pictureBoxTest";
            this.pictureBoxTest.Size = new System.Drawing.Size(640, 239);
            this.pictureBoxTest.TabIndex = 10;
            this.pictureBoxTest.TabStop = false;
            this.pictureBoxTest.Click += new System.EventHandler(this.pictureBoxTest_Click);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Image = global::VideoApp.Properties.Resources.digits;
            this.pictureBoxCamera.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;
            this.pictureBoxCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCamera_Paint);
            this.pictureBoxCamera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseDown);
            this.pictureBoxCamera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseMove);
            this.pictureBoxCamera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseUp);
            // 
            // textBoxPixelsTres
            // 
            this.textBoxPixelsTres.Location = new System.Drawing.Point(486, 656);
            this.textBoxPixelsTres.Name = "textBoxPixelsTres";
            this.textBoxPixelsTres.Size = new System.Drawing.Size(54, 20);
            this.textBoxPixelsTres.TabIndex = 57;
            this.textBoxPixelsTres.Text = "3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 695);
            this.Controls.Add(this.textBoxPixelsTres);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblDeviation);
            this.Controls.Add(this.textBoxDeviation);
            this.Controls.Add(this.btnMSE);
            this.Controls.Add(this.pictureBoxCandidateTest);
            this.Controls.Add(this.btnRecognizeCandidate);
            this.Controls.Add(this.btnSetClass);
            this.Controls.Add(this.textBoxClassName);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxNiblackStep);
            this.Controls.Add(this.lblNiblackStep);
            this.Controls.Add(this.textBoxSimpleBinTreshold);
            this.Controls.Add(this.lblSimpleBinarizeTreshold);
            this.Controls.Add(this.panelUnused);
            this.Controls.Add(this.btnToDefaultImage);
            this.Controls.Add(this.btnTriangle);
            this.Controls.Add(this.btnYen);
            this.Controls.Add(this.btnGraysclae);
            this.Controls.Add(this.btnOtsu);
            this.Controls.Add(this.btnNiblack);
            this.Controls.Add(this.btnSimpleBinarize);
            this.Controls.Add(this.txtScaleY);
            this.Controls.Add(this.lblScaleY);
            this.Controls.Add(this.txtScaleX);
            this.Controls.Add(this.lblScaleX);
            this.Controls.Add(this.btnAffineScale);
            this.Controls.Add(this.txtTranslateY);
            this.Controls.Add(this.lblTranslateY);
            this.Controls.Add(this.txtTranslateX);
            this.Controls.Add(this.lblTranslateX);
            this.Controls.Add(this.btnAffineTranslate);
            this.Controls.Add(this.pictureBoxTest);
            this.Controls.Add(this.btnConnectCamera);
            this.Controls.Add(this.btnMakePhoto);
            this.Controls.Add(this.pictureBoxCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelUnused.ResumeLayout(false);
            this.panelUnused.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandidateTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button btnGetFromTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMakePhoto;
        private System.Windows.Forms.Button btnConnectCamera;
        private System.Windows.Forms.Button btnSaveToTxt;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.PictureBox pictureBoxTest;
        private System.Windows.Forms.Button btnAffineTranslate;
        private System.Windows.Forms.Label lblTranslateX;
        private System.Windows.Forms.TextBox txtTranslateX;
        private System.Windows.Forms.TextBox txtTranslateY;
        private System.Windows.Forms.Label lblTranslateY;
        private System.Windows.Forms.Button btnAffineRotate;
        private System.Windows.Forms.Button btnAffineScale;
        private System.Windows.Forms.Label lblScaleX;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.Label lblScaleY;
        private System.Windows.Forms.Button btnSimpleBinarize;
        private System.Windows.Forms.Button btnNiblack;
        private System.Windows.Forms.Button btnOtsu;
        private System.Windows.Forms.Button btnGraysclae;
        private System.Windows.Forms.Button btnYen;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnToDefaultImage;
        private System.Windows.Forms.Panel panelUnused;
        private System.Windows.Forms.Label lblSimpleBinarizeTreshold;
        private System.Windows.Forms.TextBox textBoxSimpleBinTreshold;
        private System.Windows.Forms.Label lblNiblackStep;
        private System.Windows.Forms.TextBox textBoxNiblackStep;
        private System.Windows.Forms.Button btnMedianFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMedianFilterStep;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Button btnNPixelsFilter;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TextBox textBoxNPixels;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox textBoxClassName;
        private System.Windows.Forms.Button btnSetClass;
        private System.Windows.Forms.Button btnRecognizeCandidate;
        private System.Windows.Forms.PictureBox pictureBoxCandidateTest;
        private System.Windows.Forms.Button btnMSE;
        private System.Windows.Forms.Button btnSetImage1;
        private System.Windows.Forms.TextBox textBoxDeviation;
        private System.Windows.Forms.Label lblDeviation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRotatedMinus2;
        private System.Windows.Forms.Button buttonRotatedPlus3;
        private System.Windows.Forms.TextBox textBoxPixelsTres;
    }
}

