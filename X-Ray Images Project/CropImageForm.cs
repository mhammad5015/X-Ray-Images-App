using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class CropImageForm : Form
    {
        private Bitmap originalImage;
        private Bitmap croppedImage;
        private Bitmap resizedImage;
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
                resizedImage = ResizeImage(originalImage, pictureBoxOriginal.Width, pictureBoxOriginal.Height);
                pictureBoxOriginal.Image = resizedImage;
                pictureBoxCropped.Image = null;
            }
        }

        public Bitmap ResizeImage(Bitmap originalImage, int targetWidth, int targetHeight)
        {
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
            }
            return resizedImage;
        }

        private void pictureBoxOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && originalImage != null)
            {
                isDragging = true;
                startPoint = e.Location;
                cropRect = new Rectangle(startPoint, new Size());
            }
        }

        private void pictureBoxOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalImage == null || !isDragging) return;

            int x = Math.Min(startPoint.X, e.X);
            int y = Math.Min(startPoint.Y, e.Y);
            int width = Math.Abs(startPoint.X - e.X);
            int height = Math.Abs(startPoint.Y - e.Y);

            cropRect = new Rectangle(x, y, width, height);
            pictureBoxOriginal.Invalidate();
        }

        private void pictureBoxOriginal_MouseUp(object sender, MouseEventArgs e)
        {
            if (originalImage == null) return;

            isDragging = false;

        }

        private void pictureBoxOriginal_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            if (isDragging)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, cropRect);
                }
            }
        }

        private void btnCropImage_Click(object sender, EventArgs e)
        {
            if (originalImage != null && cropRect.Width > 0 && cropRect.Height > 0)
            {
                Rectangle actualCropRect = GetActualRectangle(cropRect, pictureBoxOriginal, originalImage);
                croppedImage = CropImage(originalImage, actualCropRect);
                resizedImage = ResizeImage(croppedImage, pictureBoxCropped.Width, pictureBoxCropped.Height);
                pictureBoxCropped.Image = resizedImage;
            }
        }

        private Rectangle GetActualRectangle(Rectangle cropRect, PictureBox pictureBox, Bitmap originalImage)
        {
            Rectangle actualArea = PictureBoxToImage(cropRect, pictureBoxOriginal);
            return actualArea;
        }

        private Point PictureBoxToImage(Point pt, PictureBox pictureBox)
        {
            float xRatio = (float)originalImage.Width / pictureBox.ClientSize.Width;
            float yRatio = (float)originalImage.Height / pictureBox.ClientSize.Height;
            return new Point((int)(pt.X * xRatio), (int)(pt.Y * yRatio));
        }

        private System.Drawing.Rectangle PictureBoxToImage(System.Drawing.Rectangle rect, PictureBox pictureBox)
        {
            Point topLeft = PictureBoxToImage(rect.Location, pictureBox);
            Point bottomRight = PictureBoxToImage(new Point(rect.Right, rect.Bottom), pictureBox);
            return new System.Drawing.Rectangle(topLeft, new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));
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

        private void saveCropedBtn_Click(object sender, EventArgs e)
        {
            if (croppedImage == null)
            {
                MessageBox.Show("There is no cropped image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp",
                Title = "Save Cropped Image"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                ImageFormat imageFormat = ImageFormat.Png;

                switch (fileExtension)
                {
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                }

                croppedImage.Save(saveFileDialog.FileName, imageFormat);
                MessageBox.Show("Croped Image saved successfully", "X-Ray Crop Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
