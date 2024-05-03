namespace X_Ray_Images_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            inputImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(254, 234);
            button1.Name = "button1";
            button1.Size = new Size(136, 33);
            button1.TabIndex = 0;
            button1.Text = "upload image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // inputImage
            // 
            inputImage.BackColor = SystemColors.ButtonFace;
            inputImage.BorderStyle = BorderStyle.FixedSingle;
            inputImage.Location = new Point(220, 75);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(216, 132);
            inputImage.SizeMode = PictureBoxSizeMode.Zoom;
            inputImage.TabIndex = 1;
            inputImage.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(661, 421);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Name = "Form1";
            Text = "X-Ray Images";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox inputImage;
    }
}
