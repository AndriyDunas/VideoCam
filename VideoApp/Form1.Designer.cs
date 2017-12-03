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
            this.btnAffineScale = new System.Windows.Forms.Button();
            this.lblScaleX = new System.Windows.Forms.Label();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.lblScaleY = new System.Windows.Forms.Label();
            this.btnSimpleBinarize = new System.Windows.Forms.Button();
            this.btnNiblack = new System.Windows.Forms.Button();
            this.btnOtsu = new System.Windows.Forms.Button();
            this.btnYen = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.buttonRotatedPlus3 = new System.Windows.Forms.Button();
            this.btnRotatedMinus2 = new System.Windows.Forms.Button();
            this.btnSetImage1 = new System.Windows.Forms.Button();
            this.btnGraysclae = new System.Windows.Forms.Button();
            this.lblClassName = new System.Windows.Forms.Label();
            this.btnSetClass = new System.Windows.Forms.Button();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
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
            this.btnRecognizeCandidate = new System.Windows.Forms.Button();
            this.btnMSE = new System.Windows.Forms.Button();
            this.textBoxDeviation = new System.Windows.Forms.TextBox();
            this.lblDeviation = new System.Windows.Forms.Label();
            this.pictureBoxCandidateTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAffineRotate = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSSIM = new System.Windows.Forms.Button();
            this.textBoxDeviationSSIM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAdjustMetod = new System.Windows.Forms.Button();
            this.btnDemonstrateMethods = new System.Windows.Forms.Button();
            this.btnVeryLow = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHigh = new System.Windows.Forms.Button();
            this.btnVeryHigh = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandidateTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetFromTxt
            // 
            this.btnGetFromTxt.Location = new System.Drawing.Point(229, 304);
            this.btnGetFromTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetFromTxt.Name = "btnGetFromTxt";
            this.btnGetFromTxt.Size = new System.Drawing.Size(100, 43);
            this.btnGetFromTxt.TabIndex = 1;
            this.btnGetFromTxt.Text = "Get image from txt";
            this.btnGetFromTxt.UseVisualStyleBackColor = true;
            this.btnGetFromTxt.Visible = false;
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
            this.btnMakePhoto.Location = new System.Drawing.Point(9, 61);
            this.btnMakePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakePhoto.Name = "btnMakePhoto";
            this.btnMakePhoto.Size = new System.Drawing.Size(122, 45);
            this.btnMakePhoto.TabIndex = 2;
            this.btnMakePhoto.Text = "Зробити фото";
            this.btnMakePhoto.UseVisualStyleBackColor = true;
            this.btnMakePhoto.Click += new System.EventHandler(this.btnMakePhoto_Click);
            // 
            // btnConnectCamera
            // 
            this.btnConnectCamera.Location = new System.Drawing.Point(9, 12);
            this.btnConnectCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectCamera.Name = "btnConnectCamera";
            this.btnConnectCamera.Size = new System.Drawing.Size(122, 45);
            this.btnConnectCamera.TabIndex = 3;
            this.btnConnectCamera.Text = "Камера";
            this.btnConnectCamera.UseVisualStyleBackColor = true;
            this.btnConnectCamera.Click += new System.EventHandler(this.btnConnectCamera_Click);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.Location = new System.Drawing.Point(229, 255);
            this.btnSaveToTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(99, 44);
            this.btnSaveToTxt.TabIndex = 4;
            this.btnSaveToTxt.Text = "Save image to txt";
            this.btnSaveToTxt.UseVisualStyleBackColor = true;
            this.btnSaveToTxt.Visible = false;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveImageToTxt_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(4, 198);
            this.btnResize.Margin = new System.Windows.Forms.Padding(4);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(109, 41);
            this.btnResize.TabIndex = 5;
            this.btnResize.Text = "Перетворити";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(0, 243);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(59, 17);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "Ширина";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(0, 294);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(55, 17);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "Висота";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(4, 266);
            this.textWidth.Margin = new System.Windows.Forms.Padding(4);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(75, 22);
            this.textWidth.TabIndex = 8;
            this.textWidth.Text = "300";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(4, 315);
            this.textHeight.Margin = new System.Windows.Forms.Padding(4);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(75, 22);
            this.textHeight.TabIndex = 9;
            this.textHeight.Text = "300";
            // 
            // btnAffineTranslate
            // 
            this.btnAffineTranslate.Location = new System.Drawing.Point(113, 34);
            this.btnAffineTranslate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineTranslate.Name = "btnAffineTranslate";
            this.btnAffineTranslate.Size = new System.Drawing.Size(143, 39);
            this.btnAffineTranslate.TabIndex = 14;
            this.btnAffineTranslate.Text = "Масштабування";
            this.btnAffineTranslate.UseVisualStyleBackColor = true;
            this.btnAffineTranslate.Click += new System.EventHandler(this.btnAffineTranslate_Click);
            // 
            // lblTranslateX
            // 
            this.lblTranslateX.AutoSize = true;
            this.lblTranslateX.Location = new System.Drawing.Point(108, 77);
            this.lblTranslateX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTranslateX.Name = "lblTranslateX";
            this.lblTranslateX.Size = new System.Drawing.Size(17, 17);
            this.lblTranslateX.TabIndex = 15;
            this.lblTranslateX.Text = "X";
            // 
            // txtTranslateX
            // 
            this.txtTranslateX.Location = new System.Drawing.Point(112, 100);
            this.txtTranslateX.Margin = new System.Windows.Forms.Padding(4);
            this.txtTranslateX.Name = "txtTranslateX";
            this.txtTranslateX.Size = new System.Drawing.Size(144, 22);
            this.txtTranslateX.TabIndex = 16;
            this.txtTranslateX.Text = "100";
            // 
            // txtTranslateY
            // 
            this.txtTranslateY.Location = new System.Drawing.Point(112, 149);
            this.txtTranslateY.Margin = new System.Windows.Forms.Padding(4);
            this.txtTranslateY.Name = "txtTranslateY";
            this.txtTranslateY.Size = new System.Drawing.Size(144, 22);
            this.txtTranslateY.TabIndex = 18;
            this.txtTranslateY.Text = "100";
            // 
            // lblTranslateY
            // 
            this.lblTranslateY.AutoSize = true;
            this.lblTranslateY.Location = new System.Drawing.Point(109, 127);
            this.lblTranslateY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTranslateY.Name = "lblTranslateY";
            this.lblTranslateY.Size = new System.Drawing.Size(17, 17);
            this.lblTranslateY.TabIndex = 17;
            this.lblTranslateY.Text = "Y";
            // 
            // btnAffineScale
            // 
            this.btnAffineScale.Location = new System.Drawing.Point(4, 34);
            this.btnAffineScale.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineScale.Name = "btnAffineScale";
            this.btnAffineScale.Size = new System.Drawing.Size(100, 39);
            this.btnAffineScale.TabIndex = 20;
            this.btnAffineScale.Text = "Збільшення";
            this.btnAffineScale.UseVisualStyleBackColor = true;
            this.btnAffineScale.Click += new System.EventHandler(this.btnAffineScale_Click);
            // 
            // lblScaleX
            // 
            this.lblScaleX.AutoSize = true;
            this.lblScaleX.Location = new System.Drawing.Point(4, 77);
            this.lblScaleX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(17, 17);
            this.lblScaleX.TabIndex = 21;
            this.lblScaleX.Text = "X";
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(6, 100);
            this.txtScaleX.Margin = new System.Windows.Forms.Padding(4);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(95, 22);
            this.txtScaleX.TabIndex = 22;
            this.txtScaleX.Text = "2";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(7, 149);
            this.txtScaleY.Margin = new System.Windows.Forms.Padding(4);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(95, 22);
            this.txtScaleY.TabIndex = 24;
            this.txtScaleY.Text = "2";
            // 
            // lblScaleY
            // 
            this.lblScaleY.AutoSize = true;
            this.lblScaleY.Location = new System.Drawing.Point(4, 128);
            this.lblScaleY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(17, 17);
            this.lblScaleY.TabIndex = 23;
            this.lblScaleY.Text = "Y";
            // 
            // btnSimpleBinarize
            // 
            this.btnSimpleBinarize.Location = new System.Drawing.Point(139, 12);
            this.btnSimpleBinarize.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleBinarize.Name = "btnSimpleBinarize";
            this.btnSimpleBinarize.Size = new System.Drawing.Size(110, 45);
            this.btnSimpleBinarize.TabIndex = 25;
            this.btnSimpleBinarize.Text = "Бінаризатор";
            this.btnSimpleBinarize.UseVisualStyleBackColor = true;
            this.btnSimpleBinarize.Click += new System.EventHandler(this.btnSimpleBinarize_Click);
            // 
            // btnNiblack
            // 
            this.btnNiblack.Location = new System.Drawing.Point(257, 12);
            this.btnNiblack.Margin = new System.Windows.Forms.Padding(4);
            this.btnNiblack.Name = "btnNiblack";
            this.btnNiblack.Size = new System.Drawing.Size(100, 45);
            this.btnNiblack.TabIndex = 26;
            this.btnNiblack.Text = "Метод Ніблака";
            this.btnNiblack.UseVisualStyleBackColor = true;
            this.btnNiblack.Click += new System.EventHandler(this.btnNiblack_Click);
            // 
            // btnOtsu
            // 
            this.btnOtsu.Location = new System.Drawing.Point(365, 12);
            this.btnOtsu.Margin = new System.Windows.Forms.Padding(4);
            this.btnOtsu.Name = "btnOtsu";
            this.btnOtsu.Size = new System.Drawing.Size(111, 45);
            this.btnOtsu.TabIndex = 29;
            this.btnOtsu.Text = "Метод Оцу";
            this.btnOtsu.UseVisualStyleBackColor = true;
            this.btnOtsu.Click += new System.EventHandler(this.btnOtsu_Click);
            // 
            // btnYen
            // 
            this.btnYen.Location = new System.Drawing.Point(365, 61);
            this.btnYen.Margin = new System.Windows.Forms.Padding(4);
            this.btnYen.Name = "btnYen";
            this.btnYen.Size = new System.Drawing.Size(111, 39);
            this.btnYen.TabIndex = 31;
            this.btnYen.Text = "Метод Єна";
            this.btnYen.UseVisualStyleBackColor = true;
            this.btnYen.Click += new System.EventHandler(this.btnYen_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(365, 106);
            this.btnTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(111, 46);
            this.btnTriangle.TabIndex = 33;
            this.btnTriangle.Text = "Метод трикутника";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // buttonRotatedPlus3
            // 
            this.buttonRotatedPlus3.Location = new System.Drawing.Point(118, 340);
            this.buttonRotatedPlus3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotatedPlus3.Name = "buttonRotatedPlus3";
            this.buttonRotatedPlus3.Size = new System.Drawing.Size(100, 40);
            this.buttonRotatedPlus3.TabIndex = 59;
            this.buttonRotatedPlus3.Text = "Поворот+3";
            this.buttonRotatedPlus3.UseVisualStyleBackColor = true;
            // 
            // btnRotatedMinus2
            // 
            this.btnRotatedMinus2.Location = new System.Drawing.Point(118, 293);
            this.btnRotatedMinus2.Margin = new System.Windows.Forms.Padding(4);
            this.btnRotatedMinus2.Name = "btnRotatedMinus2";
            this.btnRotatedMinus2.Size = new System.Drawing.Size(100, 39);
            this.btnRotatedMinus2.TabIndex = 58;
            this.btnRotatedMinus2.Text = "Поворот+2";
            this.btnRotatedMinus2.UseVisualStyleBackColor = true;
            // 
            // btnSetImage1
            // 
            this.btnSetImage1.Location = new System.Drawing.Point(118, 242);
            this.btnSetImage1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetImage1.Name = "btnSetImage1";
            this.btnSetImage1.Size = new System.Drawing.Size(100, 41);
            this.btnSetImage1.TabIndex = 57;
            this.btnSetImage1.Text = "Поворот+1";
            this.btnSetImage1.UseVisualStyleBackColor = true;
            // 
            // btnGraysclae
            // 
            this.btnGraysclae.Location = new System.Drawing.Point(228, 355);
            this.btnGraysclae.Margin = new System.Windows.Forms.Padding(4);
            this.btnGraysclae.Name = "btnGraysclae";
            this.btnGraysclae.Size = new System.Drawing.Size(100, 36);
            this.btnGraysclae.TabIndex = 56;
            this.btnGraysclae.Text = "Чорно-біле";
            this.btnGraysclae.UseVisualStyleBackColor = true;
            this.btnGraysclae.Visible = false;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(216, 409);
            this.lblClassName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(40, 17);
            this.lblClassName.TabIndex = 47;
            this.lblClassName.Text = "Клас";
            this.lblClassName.Visible = false;
            // 
            // btnSetClass
            // 
            this.btnSetClass.Location = new System.Drawing.Point(220, 460);
            this.btnSetClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetClass.Name = "btnSetClass";
            this.btnSetClass.Size = new System.Drawing.Size(99, 31);
            this.btnSetClass.TabIndex = 49;
            this.btnSetClass.Text = "Призначити";
            this.btnSetClass.UseVisualStyleBackColor = true;
            this.btnSetClass.Visible = false;
            this.btnSetClass.Click += new System.EventHandler(this.btnSetClass_Click);
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(220, 428);
            this.textBoxClassName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(99, 22);
            this.textBoxClassName.TabIndex = 48;
            this.textBoxClassName.Visible = false;
            // 
            // lblSimpleBinarizeTreshold
            // 
            this.lblSimpleBinarizeTreshold.AutoSize = true;
            this.lblSimpleBinarizeTreshold.Location = new System.Drawing.Point(136, 61);
            this.lblSimpleBinarizeTreshold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSimpleBinarizeTreshold.Name = "lblSimpleBinarizeTreshold";
            this.lblSimpleBinarizeTreshold.Size = new System.Drawing.Size(42, 17);
            this.lblSimpleBinarizeTreshold.TabIndex = 36;
            this.lblSimpleBinarizeTreshold.Text = "Поріг";
            // 
            // textBoxSimpleBinTreshold
            // 
            this.textBoxSimpleBinTreshold.Location = new System.Drawing.Point(139, 84);
            this.textBoxSimpleBinTreshold.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSimpleBinTreshold.Name = "textBoxSimpleBinTreshold";
            this.textBoxSimpleBinTreshold.Size = new System.Drawing.Size(109, 22);
            this.textBoxSimpleBinTreshold.TabIndex = 37;
            this.textBoxSimpleBinTreshold.Text = "127";
            // 
            // lblNiblackStep
            // 
            this.lblNiblackStep.AutoSize = true;
            this.lblNiblackStep.Location = new System.Drawing.Point(256, 61);
            this.lblNiblackStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNiblackStep.Name = "lblNiblackStep";
            this.lblNiblackStep.Size = new System.Drawing.Size(44, 17);
            this.lblNiblackStep.TabIndex = 38;
            this.lblNiblackStep.Text = "Крок:";
            // 
            // textBoxNiblackStep
            // 
            this.textBoxNiblackStep.Location = new System.Drawing.Point(260, 84);
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
            this.btnMedianFilter.Size = new System.Drawing.Size(100, 32);
            this.btnMedianFilter.TabIndex = 40;
            this.btnMedianFilter.Text = "Медіанний";
            this.btnMedianFilter.UseVisualStyleBackColor = true;
            this.btnMedianFilter.Click += new System.EventHandler(this.btnMedianFilter_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxMedianFilterStep);
            this.panel1.Controls.Add(this.lblStep);
            this.panel1.Controls.Add(this.btnMedianFilter);
            this.panel1.Location = new System.Drawing.Point(854, 330);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 93);
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
            this.lblStep.Size = new System.Drawing.Size(44, 17);
            this.lblStep.TabIndex = 41;
            this.lblStep.Text = "Крок:";
            // 
            // btnNPixelsFilter
            // 
            this.btnNPixelsFilter.Location = new System.Drawing.Point(4, 4);
            this.btnNPixelsFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnNPixelsFilter.Name = "btnNPixelsFilter";
            this.btnNPixelsFilter.Size = new System.Drawing.Size(101, 32);
            this.btnNPixelsFilter.TabIndex = 42;
            this.btnNPixelsFilter.Text = "N-фільтр";
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
            this.panel2.Size = new System.Drawing.Size(132, 92);
            this.panel2.TabIndex = 45;
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(8, 23);
            this.btnRecognize.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(171, 44);
            this.btnRecognize.TabIndex = 46;
            this.btnRecognize.Text = "Еталон";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // btnRecognizeCandidate
            // 
            this.btnRecognizeCandidate.Location = new System.Drawing.Point(9, 73);
            this.btnRecognizeCandidate.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognizeCandidate.Name = "btnRecognizeCandidate";
            this.btnRecognizeCandidate.Size = new System.Drawing.Size(171, 42);
            this.btnRecognizeCandidate.TabIndex = 50;
            this.btnRecognizeCandidate.Text = "Тестовий зразок";
            this.btnRecognizeCandidate.UseVisualStyleBackColor = true;
            this.btnRecognizeCandidate.Click += new System.EventHandler(this.btnRecognizeCandidate_Click);
            // 
            // btnMSE
            // 
            this.btnMSE.Location = new System.Drawing.Point(193, 73);
            this.btnMSE.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSE.Name = "btnMSE";
            this.btnMSE.Size = new System.Drawing.Size(124, 42);
            this.btnMSE.TabIndex = 52;
            this.btnMSE.Text = "MSE";
            this.btnMSE.UseVisualStyleBackColor = true;
            this.btnMSE.Click += new System.EventHandler(this.btnMSE_Click);
            // 
            // textBoxDeviation
            // 
            this.textBoxDeviation.Location = new System.Drawing.Point(193, 44);
            this.textBoxDeviation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeviation.Name = "textBoxDeviation";
            this.textBoxDeviation.Size = new System.Drawing.Size(124, 22);
            this.textBoxDeviation.TabIndex = 54;
            // 
            // lblDeviation
            // 
            this.lblDeviation.AutoSize = true;
            this.lblDeviation.Location = new System.Drawing.Point(191, 23);
            this.lblDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviation.Name = "lblDeviation";
            this.lblDeviation.Size = new System.Drawing.Size(67, 17);
            this.lblDeviation.TabIndex = 55;
            this.lblDeviation.Text = "Похибка:";
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
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Тестовий зразок:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Еталон:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnGraysclae);
            this.panel4.Controls.Add(this.buttonRotatedPlus3);
            this.panel4.Controls.Add(this.btnGetFromTxt);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnSaveToTxt);
            this.panel4.Controls.Add(this.lblClassName);
            this.panel4.Controls.Add(this.btnRotatedMinus2);
            this.panel4.Controls.Add(this.btnSetClass);
            this.panel4.Controls.Add(this.btnAffineScale);
            this.panel4.Controls.Add(this.textBoxClassName);
            this.panel4.Controls.Add(this.btnSetImage1);
            this.panel4.Controls.Add(this.btnAffineTranslate);
            this.panel4.Controls.Add(this.lblTranslateX);
            this.panel4.Controls.Add(this.btnResize);
            this.panel4.Controls.Add(this.txtTranslateX);
            this.panel4.Controls.Add(this.lblTranslateY);
            this.panel4.Controls.Add(this.labelWidth);
            this.panel4.Controls.Add(this.txtTranslateY);
            this.panel4.Controls.Add(this.labelHeight);
            this.panel4.Controls.Add(this.btnAffineRotate);
            this.panel4.Controls.Add(this.textWidth);
            this.panel4.Controls.Add(this.lblScaleX);
            this.panel4.Controls.Add(this.textHeight);
            this.panel4.Controls.Add(this.txtScaleX);
            this.panel4.Controls.Add(this.lblScaleY);
            this.panel4.Controls.Add(this.txtScaleY);
            this.panel4.Location = new System.Drawing.Point(1211, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 523);
            this.panel4.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(-1, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(343, 23);
            this.label7.TabIndex = 50;
            this.label7.Text = "Афінні перетворення";
            // 
            // btnAffineRotate
            // 
            this.btnAffineRotate.Location = new System.Drawing.Point(118, 198);
            this.btnAffineRotate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAffineRotate.Name = "btnAffineRotate";
            this.btnAffineRotate.Size = new System.Drawing.Size(100, 39);
            this.btnAffineRotate.TabIndex = 19;
            this.btnAffineRotate.Text = "Поворот";
            this.btnAffineRotate.UseVisualStyleBackColor = true;
            this.btnAffineRotate.Click += new System.EventHandler(this.btnAffineRotate_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.btnSSIM);
            this.panel5.Controls.Add(this.textBoxDeviationSSIM);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnRecognize);
            this.panel5.Controls.Add(this.btnRecognizeCandidate);
            this.panel5.Controls.Add(this.btnMSE);
            this.panel5.Controls.Add(this.textBoxDeviation);
            this.panel5.Controls.Add(this.lblDeviation);
            this.panel5.Location = new System.Drawing.Point(712, 182);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(482, 121);
            this.panel5.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(-4, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(485, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = " Розпізнавання";
            // 
            // btnSSIM
            // 
            this.btnSSIM.Location = new System.Drawing.Point(325, 73);
            this.btnSSIM.Margin = new System.Windows.Forms.Padding(4);
            this.btnSSIM.Name = "btnSSIM";
            this.btnSSIM.Size = new System.Drawing.Size(111, 42);
            this.btnSSIM.TabIndex = 56;
            this.btnSSIM.Text = "SSIM";
            this.btnSSIM.UseVisualStyleBackColor = true;
            this.btnSSIM.Click += new System.EventHandler(this.btnSSIM_Click);
            // 
            // textBoxDeviationSSIM
            // 
            this.textBoxDeviationSSIM.Location = new System.Drawing.Point(325, 44);
            this.textBoxDeviationSSIM.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeviationSSIM.Name = "textBoxDeviationSSIM";
            this.textBoxDeviationSSIM.Size = new System.Drawing.Size(111, 22);
            this.textBoxDeviationSSIM.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Похибка:";
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
            // btnAdjustMetod
            // 
            this.btnAdjustMetod.Location = new System.Drawing.Point(712, 438);
            this.btnAdjustMetod.Name = "btnAdjustMetod";
            this.btnAdjustMetod.Size = new System.Drawing.Size(132, 46);
            this.btnAdjustMetod.TabIndex = 69;
            this.btnAdjustMetod.Text = "Підбір методу";
            this.btnAdjustMetod.UseVisualStyleBackColor = true;
            this.btnAdjustMetod.Click += new System.EventHandler(this.btnAdjustMetod_Click);
            // 
            // btnDemonstrateMethods
            // 
            this.btnDemonstrateMethods.Location = new System.Drawing.Point(854, 438);
            this.btnDemonstrateMethods.Name = "btnDemonstrateMethods";
            this.btnDemonstrateMethods.Size = new System.Drawing.Size(117, 46);
            this.btnDemonstrateMethods.TabIndex = 63;
            this.btnDemonstrateMethods.Text = "Демонстрація методів";
            this.btnDemonstrateMethods.UseVisualStyleBackColor = true;
            this.btnDemonstrateMethods.Click += new System.EventHandler(this.btnDemonstrateMethods_Click);
            // 
            // btnVeryLow
            // 
            this.btnVeryLow.Location = new System.Drawing.Point(5, 22);
            this.btnVeryLow.Name = "btnVeryLow";
            this.btnVeryLow.Size = new System.Drawing.Size(196, 34);
            this.btnVeryLow.TabIndex = 64;
            this.btnVeryLow.Text = "Дуже низька";
            this.btnVeryLow.UseVisualStyleBackColor = true;
            this.btnVeryLow.Click += new System.EventHandler(this.btnVeryLow_Click);
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(5, 58);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(196, 34);
            this.btnLow.TabIndex = 65;
            this.btnLow.Text = "Низька";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(5, 93);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(196, 34);
            this.btnMedium.TabIndex = 66;
            this.btnMedium.Text = "Середня";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.Location = new System.Drawing.Point(5, 131);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(196, 34);
            this.btnHigh.TabIndex = 67;
            this.btnHigh.Text = "Висока";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnVeryHigh
            // 
            this.btnVeryHigh.Location = new System.Drawing.Point(5, 169);
            this.btnVeryHigh.Name = "btnVeryHigh";
            this.btnVeryHigh.Size = new System.Drawing.Size(196, 34);
            this.btnVeryHigh.TabIndex = 68;
            this.btnVeryHigh.Text = "Дуже висока";
            this.btnVeryHigh.UseVisualStyleBackColor = true;
            this.btnVeryHigh.Click += new System.EventHandler(this.btnVeryHigh_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.btnVeryLow);
            this.panel7.Controls.Add(this.btnVeryHigh);
            this.panel7.Controls.Add(this.btnLow);
            this.panel7.Controls.Add(this.btnHigh);
            this.panel7.Controls.Add(this.btnMedium);
            this.panel7.Location = new System.Drawing.Point(988, 330);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(206, 208);
            this.panel7.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(-1, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "Яскравість";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(1202, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 548);
            this.label5.TabIndex = 70;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1564, 543);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdjustMetod);
            this.Controls.Add(this.btnDemonstrateMethods);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxCandidateTest);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxTest);
            this.Controls.Add(this.pictureBoxCamera);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Сегментація 2.5.1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandidateTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAffineScale;
        private System.Windows.Forms.Label lblScaleX;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.Label lblScaleY;
        private System.Windows.Forms.Button btnSimpleBinarize;
        private System.Windows.Forms.Button btnNiblack;
        private System.Windows.Forms.Button btnOtsu;
        private System.Windows.Forms.Button btnYen;
        private System.Windows.Forms.Button btnTriangle;
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
        private System.Windows.Forms.TextBox textBoxDeviation;
        private System.Windows.Forms.Label lblDeviation;
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
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRotatedPlus3;
        private System.Windows.Forms.Button btnRotatedMinus2;
        private System.Windows.Forms.Button btnSetImage1;
        private System.Windows.Forms.Button btnGraysclae;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAffineRotate;
        private System.Windows.Forms.Label label6;
    }
}

