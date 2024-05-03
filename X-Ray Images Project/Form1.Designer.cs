//namespace X_Ray_Images_Project
//{
//    partial class Form1
//    {
//        /// <summary>
//        ///  Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        ///  Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        ///  Required method for Designer support - do not modify
//        ///  the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            button1 = new Button();
//            inputImage = new PictureBox();
//            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
//            SuspendLayout();
//            // 
//            // button1
//            // 
//            button1.Location = new Point(254, 234);
//            button1.Name = "button1";
//            button1.Size = new Size(136, 33);
//            button1.TabIndex = 0;
//            button1.Text = "upload image";
//            button1.UseVisualStyleBackColor = true;
//            button1.Click += button1_Click;
//            // 
//            // inputImage
//            // 
//            inputImage.BackColor = SystemColors.ButtonFace;
//            inputImage.BorderStyle = BorderStyle.FixedSingle;
//            inputImage.Location = new Point(220, 75);
//            inputImage.Name = "inputImage";
//            inputImage.Size = new Size(216, 132);
//            inputImage.SizeMode = PictureBoxSizeMode.Zoom;
//            inputImage.TabIndex = 1;
//            inputImage.TabStop = false;
//            // 
//            // Form1
//            // 
//            AutoScaleDimensions = new SizeF(7F, 15F);
//            AutoScaleMode = AutoScaleMode.Font;
//            BackColor = SystemColors.ActiveCaption;
//            ClientSize = new Size(661, 421);
//            Controls.Add(inputImage);
//            Controls.Add(button1);
//            Name = "Form1";
//            Text = "X-Ray Images";
//            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
//            ResumeLayout(false);
//        }

//        #endregion

//        private Button button1;
//        private PictureBox inputImage;
//    }
//}
//namespace X_Ray_Images_Project
//{
//    partial class Form1
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.btnIdentifyAffectedAreas = new System.Windows.Forms.Button();
//            this.button1 = new System.Windows.Forms.Button();
//            this.inputImage = new System.Windows.Forms.PictureBox();
//            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // btnIdentifyAffectedAreas
//            // 
//            this.btnIdentifyAffectedAreas.Location = new System.Drawing.Point(12, 12);
//            this.btnIdentifyAffectedAreas.Name = "btnIdentifyAffectedAreas";
//            this.btnIdentifyAffectedAreas.Size = new System.Drawing.Size(170, 23);
//            this.btnIdentifyAffectedAreas.TabIndex = 0;
//            this.btnIdentifyAffectedAreas.Text = "Identify Affected Areas";
//            this.btnIdentifyAffectedAreas.UseVisualStyleBackColor = true;
//            this.btnIdentifyAffectedAreas.Click += new System.EventHandler(this.btnIdentifyAffectedAreas_Click);
//            // 
//            // button1
//            // 
//            this.button1.Location = new System.Drawing.Point(188, 12);
//            this.button1.Name = "button1";
//            this.button1.Size = new System.Drawing.Size(170, 23);
//            this.button1.TabIndex = 1;
//            this.button1.Text = "Open Radiograph";
//            this.button1.UseVisualStyleBackColor = true;
//            this.button1.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // inputImage
//            // 
//            this.inputImage.Location = new System.Drawing.Point(12, 41);
//            this.inputImage.Name = "inputImage";
//            this.inputImage.Size = new System.Drawing.Size(346, 307);
//            this.inputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
//            this.inputImage.TabIndex = 2;
//            this.inputImage.TabStop = false;
//            this.inputImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inputImage_MouseDown);
//            this.inputImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.inputImage_MouseMove);
//            this.inputImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.inputImage_MouseUp);
//            this.inputImage.Paint += new System.Windows.Forms.PaintEventHandler(this.inputImage_Paint);
//            // 
//            // Form1
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(370, 360);
//            this.Controls.Add(this.inputImage);
//            this.Controls.Add(this.button1);
//            this.Controls.Add(this.btnIdentifyAffectedAreas);
//            this.Name = "Form1";
//            this.Text = "X-Ray Images Project";
//            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).EndInit();
//            this.ResumeLayout(false);

//        }

//        private System.Windows.Forms.Button btnIdentifyAffectedAreas;
//        private System.Windows.Forms.Button button1;
//        private System.Windows.Forms.PictureBox inputImage;
//    }
//}

namespace X_Ray_Images_Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnIdentifyAffectedAreas = new Button();
            button1 = new Button();
            inputImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            SuspendLayout();
            // 
            // btnIdentifyAffectedAreas
            // 
            btnIdentifyAffectedAreas.Location = new Point(14, 14);
            btnIdentifyAffectedAreas.Margin = new Padding(4, 3, 4, 3);
            btnIdentifyAffectedAreas.Name = "btnIdentifyAffectedAreas";
            btnIdentifyAffectedAreas.Size = new Size(198, 27);
            btnIdentifyAffectedAreas.TabIndex = 0;
            btnIdentifyAffectedAreas.Text = "Identify Affected Areas";
            btnIdentifyAffectedAreas.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(219, 14);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(198, 27);
            button1.TabIndex = 1;
            button1.Text = "Open Radiograph";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // inputImage
            // 
            inputImage.Location = new Point(14, 47);
            inputImage.Margin = new Padding(4, 3, 4, 3);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(404, 354);
            inputImage.SizeMode = PictureBoxSizeMode.Zoom;
            inputImage.TabIndex = 2;
            inputImage.TabStop = false;
            inputImage.Click += inputImage_Click;
            inputImage.Paint += inputImage_Paint;
            inputImage.MouseDown += inputImage_MouseDown;
            inputImage.MouseMove += inputImage_MouseMove;
            inputImage.MouseUp += inputImage_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 415);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Controls.Add(btnIdentifyAffectedAreas);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "X-Ray Images Project";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnIdentifyAffectedAreas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox inputImage;
    }
}
