namespace X_Ray_Images_Project
{
    partial class FourierTransformForm
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
            transformedPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)transformedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // transformedPictureBox
            // 
            transformedPictureBox.Dock = DockStyle.Fill;
            transformedPictureBox.Location = new Point(0, 0);
            transformedPictureBox.Margin = new Padding(4, 3, 4, 3);
            transformedPictureBox.Name = "transformedPictureBox";
            transformedPictureBox.Size = new Size(525, 462);
            transformedPictureBox.TabIndex = 0;
            transformedPictureBox.TabStop = false;
            // 
            // FourierTransformForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 462);
            Controls.Add(transformedPictureBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FourierTransformForm";
            Text = "Fourier Transform";
            ((System.ComponentModel.ISupportInitialize)transformedPictureBox).EndInit();
            ResumeLayout(false);
        }

        private PictureBox transformedPictureBox;

        #endregion
    }
}