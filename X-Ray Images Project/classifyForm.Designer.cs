namespace X_Ray_Images_Project
{
    partial class classifyForm
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
            buttonLoadImage = new Button();
            pictureBox = new PictureBox();
            buttonClassify = new Button();
            textBoxClassification = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // buttonLoadImage
            // 
            buttonLoadImage.Location = new Point(150, 8);
            buttonLoadImage.Name = "buttonLoadImage";
            buttonLoadImage.Size = new Size(100, 23);
            buttonLoadImage.TabIndex = 1;
            buttonLoadImage.Text = "Load Image";
            buttonLoadImage.UseVisualStyleBackColor = true;
            buttonLoadImage.Click += buttonLoadImage_Click;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(10, 40);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(400, 333);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            // 
            // buttonClassify
            // 
            buttonClassify.Location = new Point(15, 385);
            buttonClassify.Name = "buttonClassify";
            buttonClassify.Size = new Size(123, 23);
            buttonClassify.TabIndex = 4;
            buttonClassify.Text = "Classify";
            buttonClassify.UseVisualStyleBackColor = true;
            buttonClassify.Click += buttonClassify_Click;
            // 
            // textBoxClassification
            // 
            textBoxClassification.Location = new Point(144, 385);
            textBoxClassification.Name = "textBoxClassification";
            textBoxClassification.ReadOnly = true;
            textBoxClassification.Size = new Size(260, 23);
            textBoxClassification.TabIndex = 6;
            // 
            // classifyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 420);
            Controls.Add(buttonClassify);
            Controls.Add(textBoxClassification);
            Controls.Add(pictureBox);
            Controls.Add(buttonLoadImage);
            Name = "classifyForm";
            Text = "X-ray Image Classifier";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonLoadImage;
        private PictureBox pictureBox;
        private Button buttonClassify;
        private TextBox textBoxClassification;

#endregion
    }
}