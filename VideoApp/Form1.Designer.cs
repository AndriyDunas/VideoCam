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
            this.buttonRotatedPlus3 = new System.Windows.Forms.Button();
            this.btnRotatedMinus2 = new System.Windows.Forms.Button();
            this.pictureBoxCandidateTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSSIM = new System.Windows.Forms.Button();
            this.textBoxDeviationSSIM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDemonstrateMethods = new System.Windows.Forms.Button();
            this.btnVeryLow = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHigh = new System.Windows.Forms.Button();
            this.btnVeryHigh = new System.Windows.Forms.Button();
            this.btnAdjustMetod = new System.Windows.Forms.Button();
            this.panelUnused.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandidateTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetFromTxt
            // 
            this.btnGetFromTxt.Location = new System.Drawing.Point(125, 59);
            this.btnGetFromTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetFromTxt.Name = "btnGetFromTxt";
            this.btnGetFromTxt.Size = new System.Drawing.Size(100, 43);
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
            this.btnMakePhoto.Location = new System.Drawing.Point(8, 57);
            this.btnMakePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakePhoto.Name = "btnMakePhoto";
            this.btnMakePhoto.Size = new System.Drawing.Size(132, 36);
            this.btnMakePhoto.TabIndex = 2;
            this.btnMakePhoto.Text = "Make photo";
            this.btnMakePhoto.UseVisualStyleBackColor = true;
            this.btnMakePhoto.Click += new System.EventHandler(this.btnMakePhoto_Click);
            // 
            // btnConnectCamera
            // 
            this.btnConnectCamera.Location = new System.Drawing.Point(9, 11);
            this.btnConnectCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectCamera.Name = "btnConnectCamera";
            this.btnConnectCamera.Size = new System.Drawing.Size(132, 42);
            this.btnConnectCamera.TabIndex = 3;
            this.btnConnectCamera.Text = "Connect camera";
            this.btnConnectCamera.UseVisualStyleBackColor = true;
            this.btnConnectCamera.Click += new System.EventHandler(this.btnConnectCamera_Click);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.Location = new System.Drawing.Point(125, 10);
            this.btnSaveToTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(99, 44);
            this.btnSaveToTxt.TabIndex = 4;
            this.btnSaveToTxt.Text = "Save image to txt";
            this.btnSaveToTxt.UseVisualStyleBackColor = true;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveImageToTxt_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(8, 10);
            this.btnResize.Margin = new System.Windows.Forms.Padding(4);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(109, 41);
            this.btnResize.TabIndex = 5;
            this.btnResize.Text = "Resize image";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(4, 55);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(75, 17);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "New width:";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(4, 106);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(82, 17);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "New height:";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(8, 78);
            this.textWidth.Margin = new System.Windows.Forms.Padding(4);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(75, 22);
            this.textWidth.TabIndex = 8;
            this.textWidth.Text = "300";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(8, 127);
            this.textHeight.Margin = new System.Windows.Forms.Padding(4);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(75, 22);
            this.textHeight.TabIndex = 9;
            this.textHeight.Text = "300";
            // 
            // btnAffineTranslate
            // 
            this.btnAffineTranslate.Location = new System.Drawing.Point(113, 4);
            this.btnAffineTranslate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineTranslate.Name = "btnAffineTranslate";
            this.btnAffineTranslate.Size = new System.Drawing.Size(115, 39);
            this.btnAffineTranslate.TabIndex = 14;
            this.btnAffineTranslate.Text = "Affine translate";
            this.btnAffineTranslate.UseVisualStyleBackColor = true;
            this.btnAffineTranslate.Click += new System.EventHandler(this.btnAffineTranslate_Click);
            // 
            // lblTranslateX
            // 
            this.lblTranslateX.AutoSize = true;
            this.lblTranslateX.Location = new System.Drawing.Point(108, 47);
            this.lblTranslateX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTranslateX.Name = "lblTranslateX";
            this.lblTranslateX.Size = new System.Drawing.Size(81, 17);
            this.lblTranslateX.TabIndex = 15;
            this.lblTranslateX.Text = "Translate X";
            // 
            // txtTranslateX
            // 
            this.txtTranslateX.Location = new System.Drawing.Point(112, 70);
            this.txtTranslateX.Margin = new System.Windows.Forms.Padding(4);
            this.txtTranslateX.Name = "txtTranslateX";
            this.txtTranslateX.Size = new System.Drawing.Size(109, 22);
            this.txtTranslateX.TabIndex = 16;
            this.txtTranslateX.Text = "100";
            // 
            // txtTranslateY
            // 
            this.txtTranslateY.Location = new System.Drawing.Point(112, 119);
            this.txtTranslateY.Margin = new System.Windows.Forms.Padding(4);
            this.txtTranslateY.Name = "txtTranslateY";
            this.txtTranslateY.Size = new System.Drawing.Size(109, 22);
            this.txtTranslateY.TabIndex = 18;
            this.txtTranslateY.Text = "100";
            // 
            // lblTranslateY
            // 
            this.lblTranslateY.AutoSize = true;
            this.lblTranslateY.Location = new System.Drawing.Point(109, 97);
            this.lblTranslateY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTranslateY.Name = "lblTranslateY";
            this.lblTranslateY.Size = new System.Drawing.Size(81, 17);
            this.lblTranslateY.TabIndex = 17;
            this.lblTranslateY.Text = "Translate Y";
            // 
            // btnAffineRotate
            // 
            this.btnAffineRotate.Location = new System.Drawing.Point(236, 10);
            this.btnAffineRotate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineRotate.Name = "btnAffineRotate";
            this.btnAffineRotate.Size = new System.Drawing.Size(100, 41);
            this.btnAffineRotate.TabIndex = 19;
            this.btnAffineRotate.Text = "Affine rotate";
            this.btnAffineRotate.UseVisualStyleBackColor = true;
            this.btnAffineRotate.Click += new System.EventHandler(this.btnAffineRotate_Click);
            // 
            // btnAffineScale
            // 
            this.btnAffineScale.Location = new System.Drawing.Point(4, 4);
            this.btnAffineScale.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineScale.Name = "btnAffineScale";
            this.btnAffineScale.Size = new System.Drawing.Size(100, 39);
            this.btnAffineScale.TabIndex = 20;
            this.btnAffineScale.Text = "Affine scale";
            this.btnAffineScale.UseVisualStyleBackColor = true;
            this.btnAffineScale.Click += new System.EventHandler(this.btnAffineScale_Click);
            // 
            // lblScaleX
            // 
            this.lblScaleX.AutoSize = true;
            this.lblScaleX.Location = new System.Drawing.Point(4, 47);
            this.lblScaleX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(56, 17);
            this.lblScaleX.TabIndex = 21;
            this.lblScaleX.Text = "Scale X";
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(8, 68);
            this.txtScaleX.Margin = new System.Windows.Forms.Padding(4);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(95, 22);
            this.txtScaleX.TabIndex = 22;
            this.txtScaleX.Text = "2";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(8, 119);
            this.txtScaleY.Margin = new System.Windows.Forms.Padding(4);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(95, 22);
            this.txtScaleY.TabIndex = 24;
            this.txtScaleY.Text = "2";
            // 
            // lblScaleY
            // 
            this.lblScaleY.AutoSize = true;
            this.lblScaleY.Location = new System.Drawing.Point(4, 98);
            this.lblScaleY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(56, 17);
            this.lblScaleY.TabIndex = 23;
            this.lblScaleY.Text = "Scale Y";
            // 
            // btnSimpleBinarize
            // 
            this.btnSimpleBinarize.Location = new System.Drawing.Point(149, 11);
            this.btnSimpleBinarize.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleBinarize.Name = "btnSimpleBinarize";
            this.btnSimpleBinarize.Size = new System.Drawing.Size(100, 31);
            this.btnSimpleBinarize.TabIndex = 25;
            this.btnSimpleBinarize.Text = "Binarize";
            this.btnSimpleBinarize.UseVisualStyleBackColor = true;
            this.btnSimpleBinarize.Click += new System.EventHandler(this.btnSimpleBinarize_Click);
            // 
            // btnNiblack
            // 
            this.btnNiblack.Location = new System.Drawing.Point(257, 12);
            this.btnNiblack.Margin = new System.Windows.Forms.Padding(4);
            this.btnNiblack.Name = "btnNiblack";
            this.btnNiblack.Size = new System.Drawing.Size(100, 30);
            this.btnNiblack.TabIndex = 26;
            this.btnNiblack.Text = "Niblack";
            this.btnNiblack.UseVisualStyleBackColor = true;
            this.btnNiblack.Click += new System.EventHandler(this.btnNiblack_Click);
            // 
            // btnOtsu
            // 
            this.btnOtsu.Location = new System.Drawing.Point(365, 12);
            this.btnOtsu.Margin = new System.Windows.Forms.Padding(4);
            this.btnOtsu.Name = "btnOtsu";
            this.btnOtsu.Size = new System.Drawing.Size(100, 28);
            this.btnOtsu.TabIndex = 29;
            this.btnOtsu.Text = "Otsu";
            this.btnOtsu.UseVisualStyleBackColor = true;
            this.btnOtsu.Click += new System.EventHandler(this.btnOtsu_Click);
            // 
            // btnGraysclae
            // 
            this.btnGraysclae.Location = new System.Drawing.Point(4, 43);
            this.btnGraysclae.Margin = new System.Windows.Forms.Padding(4);
            this.btnGraysclae.Name = "btnGraysclae";
            this.btnGraysclae.Size = new System.Drawing.Size(100, 36);
            this.btnGraysclae.TabIndex = 30;
            this.btnGraysclae.Text = "Grayscale";
            this.btnGraysclae.UseVisualStyleBackColor = true;
            this.btnGraysclae.Click += new System.EventHandler(this.btnGraysclae_Click);
            // 
            // btnYen
            // 
            this.btnYen.Location = new System.Drawing.Point(365, 48);
            this.btnYen.Margin = new System.Windows.Forms.Padding(4);
            this.btnYen.Name = "btnYen";
            this.btnYen.Size = new System.Drawing.Size(100, 28);
            this.btnYen.TabIndex = 31;
            this.btnYen.Text = "Yen";
            this.btnYen.UseVisualStyleBackColor = true;
            this.btnYen.Click += new System.EventHandler(this.btnYen_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(365, 84);
            this.btnTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(100, 28);
            this.btnTriangle.TabIndex = 33;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnToDefaultImage
            // 
            this.btnToDefaultImage.Location = new System.Drawing.Point(8, 100);
            this.btnToDefaultImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnToDefaultImage.Name = "btnToDefaultImage";
            this.btnToDefaultImage.Size = new System.Drawing.Size(132, 41);
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
            this.panelUnused.Location = new System.Drawing.Point(1203, 15);
            this.panelUnused.Margin = new System.Windows.Forms.Padding(4);
            this.panelUnused.Name = "panelUnused";
            this.panelUnused.Size = new System.Drawing.Size(342, 160);
            this.panelUnused.TabIndex = 35;
            // 
            // lblSimpleBinarizeTreshold
            // 
            this.lblSimpleBinarizeTreshold.AutoSize = true;
            this.lblSimpleBinarizeTreshold.Location = new System.Drawing.Point(148, 46);
            this.lblSimpleBinarizeTreshold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSimpleBinarizeTreshold.Name = "lblSimpleBinarizeTreshold";
            this.lblSimpleBinarizeTreshold.Size = new System.Drawing.Size(68, 17);
            this.lblSimpleBinarizeTreshold.TabIndex = 36;
            this.lblSimpleBinarizeTreshold.Text = "Treshold:";
            // 
            // textBoxSimpleBinTreshold
            // 
            this.textBoxSimpleBinTreshold.Location = new System.Drawing.Point(152, 69);
            this.textBoxSimpleBinTreshold.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSimpleBinTreshold.Name = "textBoxSimpleBinTreshold";
            this.textBoxSimpleBinTreshold.Size = new System.Drawing.Size(96, 22);
            this.textBoxSimpleBinTreshold.TabIndex = 37;
            this.textBoxSimpleBinTreshold.Text = "127";
            // 
            // lblNiblackStep
            // 
            this.lblNiblackStep.AutoSize = true;
            this.lblNiblackStep.Location = new System.Drawing.Point(256, 46);
            this.lblNiblackStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNiblackStep.Name = "lblNiblackStep";
            this.lblNiblackStep.Size = new System.Drawing.Size(41, 17);
            this.lblNiblackStep.TabIndex = 38;
            this.lblNiblackStep.Text = "Step:";
            // 
            // textBoxNiblackStep
            // 
            this.textBoxNiblackStep.Location = new System.Drawing.Point(260, 69);
            this.textBoxNiblackStep.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNiblackStep.Name = "textBoxNiblackStep";
            this.textBoxNiblackStep.Size = new System.Drawing.Size(96, 22);
            this.textBoxNiblackStep.TabIndex = 39;
            this.textBoxNiblackStep.Text = "15";
            // 
            // btnMedianFilter
            // 
            this.btnMedianFilter.Location = new System.Drawing.Point(4, 4);
            this.btnMedianFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnMedianFilter.Name = "btnMedianFilter";
            this.btnMedianFilter.Size = new System.Drawing.Size(100, 28);
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
            this.panel1.Location = new System.Drawing.Point(832, 330);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 93);
            this.panel1.TabIndex = 41;
            // 
            // textBoxMedianFilterStep
            // 
            this.textBoxMedianFilterStep.Location = new System.Drawing.Point(9, 62);
            this.textBoxMedianFilterStep.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMedianFilterStep.Name = "textBoxMedianFilterStep";
            this.textBoxMedianFilterStep.Size = new System.Drawing.Size(93, 22);
            this.textBoxMedianFilterStep.TabIndex = 42;
            this.textBoxMedianFilterStep.Text = "3";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(5, 41);
            this.lblStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(41, 17);
            this.lblStep.TabIndex = 41;
            this.lblStep.Text = "Step:";
            // 
            // btnNPixelsFilter
            // 
            this.btnNPixelsFilter.Location = new System.Drawing.Point(4, 4);
            this.btnNPixelsFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnNPixelsFilter.Name = "btnNPixelsFilter";
            this.btnNPixelsFilter.Size = new System.Drawing.Size(101, 32);
            this.btnNPixelsFilter.TabIndex = 42;
            this.btnNPixelsFilter.Text = "N pixels filter";
            this.btnNPixelsFilter.UseVisualStyleBackColor = true;
            this.btnNPixelsFilter.Click += new System.EventHandler(this.btnNPixelsFilter_Click);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(4, 43);
            this.lblN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(22, 17);
            this.lblN.TabIndex = 43;
            this.lblN.Text = "N:";
            // 
            // textBoxNPixels
            // 
            this.textBoxNPixels.Location = new System.Drawing.Point(8, 62);
            this.textBoxNPixels.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNPixels.Name = "textBoxNPixels";
            this.textBoxNPixels.Size = new System.Drawing.Size(96, 22);
            this.textBoxNPixels.TabIndex = 44;
            this.textBoxNPixels.Text = "2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNPixelsFilter);
            this.panel2.Controls.Add(this.textBoxNPixels);
            this.panel2.Controls.Add(this.lblN);
            this.panel2.Location = new System.Drawing.Point(712, 330);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 92);
            this.panel2.TabIndex = 45;
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(4, 9);
            this.btnRecognize.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(171, 44);
            this.btnRecognize.TabIndex = 46;
            this.btnRecognize.Text = "Recognize etalon";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(173, 9);
            this.lblClassName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(85, 17);
            this.lblClassName.TabIndex = 47;
            this.lblClassName.Text = "Class name:";
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(177, 28);
            this.textBoxClassName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(107, 22);
            this.textBoxClassName.TabIndex = 48;
            // 
            // btnSetClass
            // 
            this.btnSetClass.Location = new System.Drawing.Point(177, 60);
            this.btnSetClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetClass.Name = "btnSetClass";
            this.btnSetClass.Size = new System.Drawing.Size(108, 31);
            this.btnSetClass.TabIndex = 49;
            this.btnSetClass.Text = "Set class";
            this.btnSetClass.UseVisualStyleBackColor = true;
            this.btnSetClass.Click += new System.EventHandler(this.btnSetClass_Click);
            // 
            // btnRecognizeCandidate
            // 
            this.btnRecognizeCandidate.Location = new System.Drawing.Point(4, 60);
            this.btnRecognizeCandidate.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognizeCandidate.Name = "btnRecognizeCandidate";
            this.btnRecognizeCandidate.Size = new System.Drawing.Size(171, 32);
            this.btnRecognizeCandidate.TabIndex = 50;
            this.btnRecognizeCandidate.Text = "Recognize candidate";
            this.btnRecognizeCandidate.UseVisualStyleBackColor = true;
            this.btnRecognizeCandidate.Click += new System.EventHandler(this.btnRecognizeCandidate_Click);
            // 
            // btnMSE
            // 
            this.btnMSE.Location = new System.Drawing.Point(293, 60);
            this.btnMSE.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSE.Name = "btnMSE";
            this.btnMSE.Size = new System.Drawing.Size(80, 32);
            this.btnMSE.TabIndex = 52;
            this.btnMSE.Text = "MSE";
            this.btnMSE.UseVisualStyleBackColor = true;
            this.btnMSE.Click += new System.EventHandler(this.btnMSE_Click);
            // 
            // btnSetImage1
            // 
            this.btnSetImage1.Location = new System.Drawing.Point(4, 7);
            this.btnSetImage1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetImage1.Name = "btnSetImage1";
            this.btnSetImage1.Size = new System.Drawing.Size(100, 28);
            this.btnSetImage1.TabIndex = 53;
            this.btnSetImage1.Text = "Rotated + 1";
            this.btnSetImage1.UseVisualStyleBackColor = true;
            this.btnSetImage1.Click += new System.EventHandler(this.btnSetImage1_Click);
            // 
            // textBoxDeviation
            // 
            this.textBoxDeviation.Location = new System.Drawing.Point(293, 28);
            this.textBoxDeviation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeviation.Name = "textBoxDeviation";
            this.textBoxDeviation.Size = new System.Drawing.Size(80, 22);
            this.textBoxDeviation.TabIndex = 54;
            // 
            // lblDeviation
            // 
            this.lblDeviation.AutoSize = true;
            this.lblDeviation.Location = new System.Drawing.Point(289, 7);
            this.lblDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviation.Name = "lblDeviation";
            this.lblDeviation.Size = new System.Drawing.Size(71, 17);
            this.lblDeviation.TabIndex = 55;
            this.lblDeviation.Text = "Deviation:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonRotatedPlus3);
            this.panel3.Controls.Add(this.btnRotatedMinus2);
            this.panel3.Controls.Add(this.btnSetImage1);
            this.panel3.Controls.Add(this.btnGraysclae);
            this.panel3.Location = new System.Drawing.Point(1203, 182);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 121);
            this.panel3.TabIndex = 56;
            // 
            // buttonRotatedPlus3
            // 
            this.buttonRotatedPlus3.Location = new System.Drawing.Point(220, 9);
            this.buttonRotatedPlus3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotatedPlus3.Name = "buttonRotatedPlus3";
            this.buttonRotatedPlus3.Size = new System.Drawing.Size(100, 28);
            this.buttonRotatedPlus3.TabIndex = 55;
            this.buttonRotatedPlus3.Text = "Rotated + 3";
            this.buttonRotatedPlus3.UseVisualStyleBackColor = true;
            this.buttonRotatedPlus3.Click += new System.EventHandler(this.buttonRotatedPlus3_Click);
            // 
            // btnRotatedMinus2
            // 
            this.btnRotatedMinus2.Location = new System.Drawing.Point(112, 7);
            this.btnRotatedMinus2.Margin = new System.Windows.Forms.Padding(4);
            this.btnRotatedMinus2.Name = "btnRotatedMinus2";
            this.btnRotatedMinus2.Size = new System.Drawing.Size(100, 28);
            this.btnRotatedMinus2.TabIndex = 54;
            this.btnRotatedMinus2.Text = "Rotated + 2";
            this.btnRotatedMinus2.UseVisualStyleBackColor = true;
            this.btnRotatedMinus2.Click += new System.EventHandler(this.btnRotatedMinus2_Click);
            // 
            // pictureBoxCandidateTest
            // 
            this.pictureBoxCandidateTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCandidateTest.Location = new System.Drawing.Point(20, 418);
            this.pictureBoxCandidateTest.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxCandidateTest.Name = "pictureBoxCandidateTest";
            this.pictureBoxCandidateTest.Size = new System.Drawing.Size(678, 71);
            this.pictureBoxCandidateTest.TabIndex = 51;
            this.pictureBoxCandidateTest.TabStop = false;
            // 
            // pictureBoxTest
            // 
            this.pictureBoxTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTest.Location = new System.Drawing.Point(19, 330);
            this.pictureBoxTest.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxTest.Name = "pictureBoxTest";
            this.pictureBoxTest.Size = new System.Drawing.Size(679, 64);
            this.pictureBoxTest.TabIndex = 10;
            this.pictureBoxTest.TabStop = false;
            this.pictureBoxTest.Click += new System.EventHandler(this.pictureBoxTest_Click);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCamera.Image = global::VideoApp.Properties.Resources.digits;
            this.pictureBoxCamera.Location = new System.Drawing.Point(16, 15);
            this.pictureBoxCamera.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(682, 289);
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 400);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Candidate recognizing:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Etalon recognizing:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnAffineScale);
            this.panel4.Controls.Add(this.btnAffineTranslate);
            this.panel4.Controls.Add(this.lblTranslateX);
            this.panel4.Controls.Add(this.txtTranslateX);
            this.panel4.Controls.Add(this.lblTranslateY);
            this.panel4.Controls.Add(this.txtTranslateY);
            this.panel4.Controls.Add(this.lblScaleX);
            this.panel4.Controls.Add(this.txtScaleX);
            this.panel4.Controls.Add(this.lblScaleY);
            this.panel4.Controls.Add(this.txtScaleY);
            this.panel4.Location = new System.Drawing.Point(1203, 330);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 160);
            this.panel4.TabIndex = 60;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnSSIM);
            this.panel5.Controls.Add(this.textBoxDeviationSSIM);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnRecognize);
            this.panel5.Controls.Add(this.btnRecognizeCandidate);
            this.panel5.Controls.Add(this.btnMSE);
            this.panel5.Controls.Add(this.lblClassName);
            this.panel5.Controls.Add(this.textBoxClassName);
            this.panel5.Controls.Add(this.textBoxDeviation);
            this.panel5.Controls.Add(this.btnSetClass);
            this.panel5.Controls.Add(this.lblDeviation);
            this.panel5.Location = new System.Drawing.Point(712, 182);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(482, 121);
            this.panel5.TabIndex = 61;
            // 
            // btnSSIM
            // 
            this.btnSSIM.Location = new System.Drawing.Point(381, 60);
            this.btnSSIM.Margin = new System.Windows.Forms.Padding(4);
            this.btnSSIM.Name = "btnSSIM";
            this.btnSSIM.Size = new System.Drawing.Size(80, 32);
            this.btnSSIM.TabIndex = 56;
            this.btnSSIM.Text = "SSIM";
            this.btnSSIM.UseVisualStyleBackColor = true;
            this.btnSSIM.Click += new System.EventHandler(this.btnSSIM_Click);
            // 
            // textBoxDeviationSSIM
            // 
            this.textBoxDeviationSSIM.Location = new System.Drawing.Point(381, 28);
            this.textBoxDeviationSSIM.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeviationSSIM.Name = "textBoxDeviationSSIM";
            this.textBoxDeviationSSIM.Size = new System.Drawing.Size(80, 22);
            this.textBoxDeviationSSIM.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Deviation:";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnYen);
            this.panel6.Controls.Add(this.btnMakePhoto);
            this.panel6.Controls.Add(this.btnConnectCamera);
            this.panel6.Controls.Add(this.btnSimpleBinarize);
            this.panel6.Controls.Add(this.btnNiblack);
            this.panel6.Controls.Add(this.btnOtsu);
            this.panel6.Controls.Add(this.btnTriangle);
            this.panel6.Controls.Add(this.btnToDefaultImage);
            this.panel6.Controls.Add(this.lblSimpleBinarizeTreshold);
            this.panel6.Controls.Add(this.textBoxNiblackStep);
            this.panel6.Controls.Add(this.textBoxSimpleBinTreshold);
            this.panel6.Controls.Add(this.lblNiblackStep);
            this.panel6.Location = new System.Drawing.Point(712, 15);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(482, 160);
            this.panel6.TabIndex = 62;
            // 
            // btnDemonstrateMethods
            // 
            this.btnDemonstrateMethods.Location = new System.Drawing.Point(712, 429);
            this.btnDemonstrateMethods.Name = "btnDemonstrateMethods";
            this.btnDemonstrateMethods.Size = new System.Drawing.Size(111, 60);
            this.btnDemonstrateMethods.TabIndex = 63;
            this.btnDemonstrateMethods.Text = "Demonstrate methods";
            this.btnDemonstrateMethods.UseVisualStyleBackColor = true;
            this.btnDemonstrateMethods.Click += new System.EventHandler(this.btnDemonstrateMethods_Click);
            // 
            // btnVeryLow
            // 
            this.btnVeryLow.Location = new System.Drawing.Point(950, 330);
            this.btnVeryLow.Name = "btnVeryLow";
            this.btnVeryLow.Size = new System.Drawing.Size(107, 34);
            this.btnVeryLow.TabIndex = 64;
            this.btnVeryLow.Text = "Very Low";
            this.btnVeryLow.UseVisualStyleBackColor = true;
            this.btnVeryLow.Click += new System.EventHandler(this.btnVeryLow_Click);
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(950, 366);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(107, 34);
            this.btnLow.TabIndex = 65;
            this.btnLow.Text = "Low";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(950, 401);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(107, 34);
            this.btnMedium.TabIndex = 66;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.Location = new System.Drawing.Point(950, 439);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(107, 34);
            this.btnHigh.TabIndex = 67;
            this.btnHigh.Text = "High";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnVeryHigh
            // 
            this.btnVeryHigh.Location = new System.Drawing.Point(950, 477);
            this.btnVeryHigh.Name = "btnVeryHigh";
            this.btnVeryHigh.Size = new System.Drawing.Size(107, 34);
            this.btnVeryHigh.TabIndex = 68;
            this.btnVeryHigh.Text = "Very High";
            this.btnVeryHigh.UseVisualStyleBackColor = true;
            this.btnVeryHigh.Click += new System.EventHandler(this.btnVeryHigh_Click);
            // 
            // btnAdjustMetod
            // 
            this.btnAdjustMetod.Location = new System.Drawing.Point(1078, 395);
            this.btnAdjustMetod.Name = "btnAdjustMetod";
            this.btnAdjustMetod.Size = new System.Drawing.Size(116, 46);
            this.btnAdjustMetod.TabIndex = 69;
            this.btnAdjustMetod.Text = "Adjust Method";
            this.btnAdjustMetod.UseVisualStyleBackColor = true;
            this.btnAdjustMetod.Click += new System.EventHandler(this.btnAdjustMetod_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 523);
            this.Controls.Add(this.btnAdjustMetod);
            this.Controls.Add(this.btnVeryHigh);
            this.Controls.Add(this.btnHigh);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.btnVeryLow);
            this.Controls.Add(this.btnDemonstrateMethods);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxCandidateTest);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUnused);
            this.Controls.Add(this.pictureBoxTest);
            this.Controls.Add(this.pictureBoxCamera);
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDemonstrateMethods;
        private System.Windows.Forms.Button btnSSIM;
        private System.Windows.Forms.TextBox textBoxDeviationSSIM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVeryLow;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Button btnVeryHigh;
        private System.Windows.Forms.Button btnAdjustMetod;
    }
}

