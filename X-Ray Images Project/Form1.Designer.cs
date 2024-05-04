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

        private void InitializeComponent()
        {
            button1 = new Button();
            inputImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(115, 14);
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
            inputImage.TabIndex = 2;
            inputImage.TabStop = false;
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
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "X-Ray Images Project";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ResumeLayout(false);
        }

        private Button button1;
        private PictureBox inputImage;  
    }
}
