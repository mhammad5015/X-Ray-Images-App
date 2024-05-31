using System;
using System.Drawing;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class CropImageForm : Form
    {
        private Bitmap originalImage;
        private Rectangle cropRect;
        private Point startPoint;
        private bool isDragging = false;

        public CropImageForm()
        {
            InitializeComponent();
        }
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                pictureBoxOriginal.Image = originalImage;
                pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBoxOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            if (originalImage == null) return;

            isDragging = true;
            startPoint = e.Location;
            cropRect = new Rectangle(e.X, e.Y, 0, 0);
        }

        private void pictureBoxOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalImage == null || !isDragging) return;

            Point endPoint = e.Location;
            cropRect = new Rectangle(
                Math.Min(startPoint.X, endPoint.X),
                Math.Min(startPoint.Y, endPoint.Y),
                Math.Abs(startPoint.X - endPoint.X),
                Math.Abs(startPoint.Y - endPoint.Y));

            pictureBoxOriginal.Invalidate(); // Force the PictureBox to repaint to show the updated rectangle
        }

        private void pictureBoxOriginal_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            if (isDragging)
            {
                // Draw the crop rectangle
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, cropRect);
                }
            }
        }

        private void pictureBoxOriginal_MouseUp(object sender, MouseEventArgs e)
        {
            if (originalImage == null) return;

            isDragging = false;
          
        }

        private void btnCropImage_Click(object sender, EventArgs e)
        {
            if (originalImage != null && cropRect.Width > 0 && cropRect.Height > 0)
            {
                Rectangle actualCropRect = GetActualRectangle(cropRect, pictureBoxOriginal, originalImage);
                Bitmap croppedImage = CropImage(originalImage, actualCropRect);
                pictureBoxCropped.Image = croppedImage;
                pictureBoxCropped.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private Rectangle GetActualRectangle(Rectangle cropRect, PictureBox pictureBox, Bitmap originalImage)
        {
            float xRatio = (float)originalImage.Width / pictureBox.ClientSize.Width;
            float yRatio = (float)originalImage.Height / pictureBox.ClientSize.Height;

            // Center the image in the PictureBox
            int offsetX = (pictureBox.ClientSize.Width - (int)(originalImage.Width / Math.Min(xRatio, yRatio))) / 2;
            int offsetY = (pictureBox.ClientSize.Height - (int)(originalImage.Height / Math.Min(xRatio, yRatio))) / 2;

            int x = (int)((cropRect.X - offsetX) * xRatio);
            int y = (int)((cropRect.Y - offsetY) * yRatio);
            int width = (int)(cropRect.Width * xRatio);
            int height = (int)(cropRect.Height * yRatio);

            return new Rectangle(x, y, width, height);
        }

        private Bitmap CropImage(Bitmap image, Rectangle cropRect)
        {
            Bitmap cropped = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(image, new Rectangle(0, 0, cropped.Width, cropped.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            return cropped;
        }
    }
}




