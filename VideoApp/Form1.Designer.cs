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
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
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
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            this.btnScaleSelection = new System.Windows.Forms.Button();
            this.lblScaleRatio = new System.Windows.Forms.Label();
            this.txtScaleRatio = new System.Windows.Forms.TextBox();
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
            this.btnBernsen = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCamera
            // 
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
            // btnGetFromTxt
            // 
            this.btnGetFromTxt.Location = new System.Drawing.Point(578, 540);
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
            this.btnMakePhoto.Size = new System.Drawing.Size(75, 34);
            this.btnMakePhoto.TabIndex = 2;
            this.btnMakePhoto.Text = "Make photo";
            this.btnMakePhoto.UseVisualStyleBackColor = true;
            this.btnMakePhoto.Click += new System.EventHandler(this.btnMakePhoto_Click);
            // 
            // btnConnectCamera
            // 
            this.btnConnectCamera.Location = new System.Drawing.Point(12, 495);
            this.btnConnectCamera.Name = "btnConnectCamera";
            this.btnConnectCamera.Size = new System.Drawing.Size(75, 34);
            this.btnConnectCamera.TabIndex = 3;
            this.btnConnectCamera.Text = "Connect camera";
            this.btnConnectCamera.UseVisualStyleBackColor = true;
            this.btnConnectCamera.Click += new System.EventHandler(this.btnConnectCamera_Click);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.Location = new System.Drawing.Point(578, 498);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(74, 36);
            this.btnSaveToTxt.TabIndex = 4;
            this.btnSaveToTxt.Text = "Save image to txt";
            this.btnSaveToTxt.UseVisualStyleBackColor = true;
            this.btnSaveToTxt.Click += new System.EventHandler(this.btnSaveImageToTxt_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(509, 498);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(66, 33);
            this.btnResize.TabIndex = 5;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(506, 535);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(60, 13);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "New width:";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(506, 576);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(64, 13);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "New height:";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(509, 553);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(57, 20);
            this.textWidth.TabIndex = 8;
            this.textWidth.Text = "300";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(509, 593);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(57, 20);
            this.textHeight.TabIndex = 9;
            this.textHeight.Text = "300";
            // 
            // pictureBoxTest
            // 
            this.pictureBoxTest.Location = new System.Drawing.Point(668, 12);
            this.pictureBoxTest.Name = "pictureBoxTest";
            this.pictureBoxTest.Size = new System.Drawing.Size(332, 480);
            this.pictureBoxTest.TabIndex = 10;
            this.pictureBoxTest.TabStop = false;
            // 
            // btnScaleSelection
            // 
            this.btnScaleSelection.Location = new System.Drawing.Point(925, 498);
            this.btnScaleSelection.Name = "btnScaleSelection";
            this.btnScaleSelection.Size = new System.Drawing.Size(75, 29);
            this.btnScaleSelection.TabIndex = 11;
            this.btnScaleSelection.Text = "Scale";
            this.btnScaleSelection.UseVisualStyleBackColor = true;
            this.btnScaleSelection.Click += new System.EventHandler(this.btnScaleSelection_Click);
            // 
            // lblScaleRatio
            // 
            this.lblScaleRatio.AutoSize = true;
            this.lblScaleRatio.Location = new System.Drawing.Point(922, 530);
            this.lblScaleRatio.Name = "lblScaleRatio";
            this.lblScaleRatio.Size = new System.Drawing.Size(60, 13);
            this.lblScaleRatio.TabIndex = 12;
            this.lblScaleRatio.Text = "Scale ratio:";
            // 
            // txtScaleRatio
            // 
            this.txtScaleRatio.Location = new System.Drawing.Point(925, 547);
            this.txtScaleRatio.Name = "txtScaleRatio";
            this.txtScaleRatio.Size = new System.Drawing.Size(75, 20);
            this.txtScaleRatio.TabIndex = 13;
            // 
            // btnAffineTranslate
            // 
            this.btnAffineTranslate.Location = new System.Drawing.Point(417, 498);
            this.btnAffineTranslate.Name = "btnAffineTranslate";
            this.btnAffineTranslate.Size = new System.Drawing.Size(86, 33);
            this.btnAffineTranslate.TabIndex = 14;
            this.btnAffineTranslate.Text = "Affine translate";
            this.btnAffineTranslate.UseVisualStyleBackColor = true;
            this.btnAffineTranslate.Click += new System.EventHandler(this.btnAffineTranslate_Click);
            // 
            // lblTranslateX
            // 
            this.lblTranslateX.AutoSize = true;
            this.lblTranslateX.Location = new System.Drawing.Point(417, 534);
            this.lblTranslateX.Name = "lblTranslateX";
            this.lblTranslateX.Size = new System.Drawing.Size(61, 13);
            this.lblTranslateX.TabIndex = 15;
            this.lblTranslateX.Text = "Translate X";
            // 
            // txtTranslateX
            // 
            this.txtTranslateX.Location = new System.Drawing.Point(420, 553);
            this.txtTranslateX.Name = "txtTranslateX";
            this.txtTranslateX.Size = new System.Drawing.Size(83, 20);
            this.txtTranslateX.TabIndex = 16;
            this.txtTranslateX.Text = "100";
            // 
            // txtTranslateY
            // 
            this.txtTranslateY.Location = new System.Drawing.Point(420, 593);
            this.txtTranslateY.Name = "txtTranslateY";
            this.txtTranslateY.Size = new System.Drawing.Size(83, 20);
            this.txtTranslateY.TabIndex = 18;
            this.txtTranslateY.Text = "100";
            // 
            // lblTranslateY
            // 
            this.lblTranslateY.AutoSize = true;
            this.lblTranslateY.Location = new System.Drawing.Point(418, 575);
            this.lblTranslateY.Name = "lblTranslateY";
            this.lblTranslateY.Size = new System.Drawing.Size(61, 13);
            this.lblTranslateY.TabIndex = 17;
            this.lblTranslateY.Text = "Translate Y";
            // 
            // btnAffineRotate
            // 
            this.btnAffineRotate.Location = new System.Drawing.Point(336, 498);
            this.btnAffineRotate.Name = "btnAffineRotate";
            this.btnAffineRotate.Size = new System.Drawing.Size(75, 33);
            this.btnAffineRotate.TabIndex = 19;
            this.btnAffineRotate.Text = "Affine rotate";
            this.btnAffineRotate.UseVisualStyleBackColor = true;
            this.btnAffineRotate.Click += new System.EventHandler(this.btnAffineRotate_Click);
            // 
            // btnAffineScale
            // 
            this.btnAffineScale.Location = new System.Drawing.Point(255, 499);
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
            this.lblScaleX.Location = new System.Drawing.Point(255, 534);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(44, 13);
            this.lblScaleX.TabIndex = 21;
            this.lblScaleX.Text = "Scale X";
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(258, 551);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(72, 20);
            this.txtScaleX.TabIndex = 22;
            this.txtScaleX.Text = "2";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(258, 593);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(72, 20);
            this.txtScaleY.TabIndex = 24;
            this.txtScaleY.Text = "2";
            // 
            // lblScaleY
            // 
            this.lblScaleY.AutoSize = true;
            this.lblScaleY.Location = new System.Drawing.Point(255, 576);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(44, 13);
            this.lblScaleY.TabIndex = 23;
            this.lblScaleY.Text = "Scale X";
            // 
            // btnSimpleBinarize
            // 
            this.btnSimpleBinarize.Location = new System.Drawing.Point(841, 499);
            this.btnSimpleBinarize.Name = "btnSimpleBinarize";
            this.btnSimpleBinarize.Size = new System.Drawing.Size(75, 25);
            this.btnSimpleBinarize.TabIndex = 25;
            this.btnSimpleBinarize.Text = "Binarize";
            this.btnSimpleBinarize.UseVisualStyleBackColor = true;
            this.btnSimpleBinarize.Click += new System.EventHandler(this.btnSimpleBinarize_Click);
            // 
            // btnNiblack
            // 
            this.btnNiblack.Location = new System.Drawing.Point(841, 526);
            this.btnNiblack.Name = "btnNiblack";
            this.btnNiblack.Size = new System.Drawing.Size(75, 22);
            this.btnNiblack.TabIndex = 26;
            this.btnNiblack.Text = "Niblack";
            this.btnNiblack.UseVisualStyleBackColor = true;
            this.btnNiblack.Click += new System.EventHandler(this.btnNiblack_Click);
            // 
            // btnBernsen
            // 
            this.btnBernsen.Location = new System.Drawing.Point(841, 551);
            this.btnBernsen.Name = "btnBernsen";
            this.btnBernsen.Size = new System.Drawing.Size(75, 23);
            this.btnBernsen.TabIndex = 27;
            this.btnBernsen.Text = "Bernsen";
            this.btnBernsen.UseVisualStyleBackColor = true;
            this.btnBernsen.Click += new System.EventHandler(this.btnBernsen_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Location = new System.Drawing.Point(841, 576);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(75, 23);
            this.btnAverage.TabIndex = 28;
            this.btnAverage.Text = "Average";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 625);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.btnBernsen);
            this.Controls.Add(this.btnNiblack);
            this.Controls.Add(this.btnSimpleBinarize);
            this.Controls.Add(this.txtScaleY);
            this.Controls.Add(this.lblScaleY);
            this.Controls.Add(this.txtScaleX);
            this.Controls.Add(this.lblScaleX);
            this.Controls.Add(this.btnAffineScale);
            this.Controls.Add(this.btnAffineRotate);
            this.Controls.Add(this.txtTranslateY);
            this.Controls.Add(this.lblTranslateY);
            this.Controls.Add(this.txtTranslateX);
            this.Controls.Add(this.lblTranslateX);
            this.Controls.Add(this.btnAffineTranslate);
            this.Controls.Add(this.txtScaleRatio);
            this.Controls.Add(this.lblScaleRatio);
            this.Controls.Add(this.btnScaleSelection);
            this.Controls.Add(this.pictureBoxTest);
            this.Controls.Add(this.textHeight);
            this.Controls.Add(this.textWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnSaveToTxt);
            this.Controls.Add(this.btnConnectCamera);
            this.Controls.Add(this.btnMakePhoto);
            this.Controls.Add(this.btnGetFromTxt);
            this.Controls.Add(this.pictureBoxCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
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
        private System.Windows.Forms.Button btnScaleSelection;
        private System.Windows.Forms.Label lblScaleRatio;
        private System.Windows.Forms.TextBox txtScaleRatio;
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
        private System.Windows.Forms.Button btnBernsen;
        private System.Windows.Forms.Button btnAverage;
    }
}

