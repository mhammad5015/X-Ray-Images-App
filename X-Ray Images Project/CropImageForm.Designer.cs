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
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxCropped = new System.Windows.Forms.PictureBox();
            this.btnCropImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCropped)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 41);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginal_MouseDown);
            this.pictureBoxOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginal_MouseMove);
            this.pictureBoxOriginal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginal_MouseUp);
            this.pictureBoxOriginal.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOriginal_Paint);
            // 
            // pictureBoxCropped
            // 
            this.pictureBoxCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCropped.Location = new System.Drawing.Point(318, 41);
            this.pictureBoxCropped.Name = "pictureBoxCropped";
            this.pictureBoxCropped.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCropped.TabIndex = 2;
            this.pictureBoxCropped.TabStop = false;
            // 
            // btnCropImage
            // 
            this.btnCropImage.Location = new System.Drawing.Point(543, 12);
            this.btnCropImage.Name = "btnCropImage";
            this.btnCropImage.Size = new System.Drawing.Size(75, 23);
            this.btnCropImage.TabIndex = 3;
            this.btnCropImage.Text = "Crop Image";
            this.btnCropImage.UseVisualStyleBackColor = true;
            this.btnCropImage.Click += new System.EventHandler(this.btnCropImage_Click);
            // 
            // CropImageForm
            // 
            this.ClientSize = new System.Drawing.Size(630, 353);
            this.Controls.Add(this.btnCropImage);
            this.Controls.Add(this.pictureBoxCropped);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "CropImageForm";
            this.Text = "Crop Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCropped)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxCropped;
        private System.Windows.Forms.Button btnCropImage;
    }
}
