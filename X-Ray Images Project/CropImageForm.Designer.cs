namespace X_Ray_Images_Project
{
    partial class CropImageForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLoadImage = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxCropped = new PictureBox();
            btnCropImage = new Button();
            saveCropedBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCropped).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(104, 12);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(116, 23);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxOriginal.Location = new Point(12, 41);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(300, 300);
            pictureBoxOriginal.TabIndex = 1;
            pictureBoxOriginal.TabStop = false;
            pictureBoxOriginal.Paint += pictureBoxOriginal_Paint;
            pictureBoxOriginal.MouseDown += pictureBoxOriginal_MouseDown;
            pictureBoxOriginal.MouseMove += pictureBoxOriginal_MouseMove;
            pictureBoxOriginal.MouseUp += pictureBoxOriginal_MouseUp;
            // 
            // pictureBoxCropped
            // 
            pictureBoxCropped.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCropped.Location = new Point(318, 41);
            pictureBoxCropped.Name = "pictureBoxCropped";
            pictureBoxCropped.Size = new Size(300, 300);
            pictureBoxCropped.TabIndex = 2;
            pictureBoxCropped.TabStop = false;
            // 
            // btnCropImage
            // 
            btnCropImage.Location = new Point(407, 12);
            btnCropImage.Name = "btnCropImage";
            btnCropImage.Size = new Size(116, 23);
            btnCropImage.TabIndex = 3;
            btnCropImage.Text = "Crop Image";
            btnCropImage.UseVisualStyleBackColor = true;
            btnCropImage.Click += btnCropImage_Click;
            // 
            // saveCropedBtn
            // 
            saveCropedBtn.Location = new Point(254, 347);
            saveCropedBtn.Name = "saveCropedBtn";
            saveCropedBtn.Size = new Size(116, 23);
            saveCropedBtn.TabIndex = 4;
            saveCropedBtn.Text = "Save";
            saveCropedBtn.UseVisualStyleBackColor = true;
            saveCropedBtn.Click += saveCropedBtn_Click;
            // 
            // CropImageForm
            // 
            ClientSize = new Size(630, 380);
            Controls.Add(saveCropedBtn);
            Controls.Add(btnCropImage);
            Controls.Add(pictureBoxCropped);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(btnLoadImage);
            Name = "CropImageForm";
            Text = "Crop Image";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCropped).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxCropped;
        private System.Windows.Forms.Button btnCropImage;
        private Button saveCropedBtn;
    }
}
