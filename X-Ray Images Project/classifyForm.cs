using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class classifyForm : Form
    {
        private Rectangle selectedRectangle;
        private Point startPoint;
        private Bitmap originalRadiograph;
        private Bitmap resizedImage;
        public classifyForm()
        {
            InitializeComponent();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalRadiograph = new Bitmap(openFileDialog.FileName);
                    resizedImage = ResizeImage(originalRadiograph, pictureBox.Width, pictureBox.Height);
                    pictureBox.Image = resizedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
                }
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

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && originalRadiograph != null)
            {
                startPoint = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && originalRadiograph != null)
            {
                Point endPoint = e.Location;
                selectedRectangle = new Rectangle(
                    Math.Min(startPoint.X, endPoint.X),
                    Math.Min(startPoint.Y, endPoint.Y),
                    Math.Abs(startPoint.X - endPoint.X),
                    Math.Abs(startPoint.Y - endPoint.Y));
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                using Pen pen = new Pen(Color.Green, 2);
                e.Graphics.DrawRectangle(pen, selectedRectangle);
            }
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            if (selectedRectangle == null || selectedRectangle.Width == 0 || selectedRectangle.Height == 0)
            {
                MessageBox.Show("Please select a region on the image.");
                return;
            }

            Bitmap image = new Bitmap(pictureBox.Image);
            Rectangle region = new Rectangle(
                selectedRectangle.X * image.Width / pictureBox.Width,
                selectedRectangle.Y * image.Height / pictureBox.Height,
                selectedRectangle.Width * image.Width / pictureBox.Width,
                selectedRectangle.Height * image.Height / pictureBox.Height);

            // Ensure the region is within the image bounds
            region.X = Math.Max(0, region.X);
            region.Y = Math.Max(0, region.Y);
            region.Width = Math.Min(image.Width - region.X, region.Width);
            region.Height = Math.Min(image.Height - region.Y, region.Height);

            string result = ClassifyRegion(region, image);
            textBoxClassification.Text = result;
        }

        private string ClassifyRegion(Rectangle region, Bitmap image)
        {
            int totalIntensity = 0;
            int pixelCount = 0;

            int startX = Math.Max(0, region.X);
            int startY = Math.Max(0, region.Y);
            int endX = Math.Min(image.Width, region.X + region.Width);
            int endY = Math.Min(image.Height, region.Y + region.Height);

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int intensity = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; 
                    totalIntensity += intensity;
                    pixelCount++;
                }
            }

            if (pixelCount == 0) return "Invalid region";

            int averageIntensity = totalIntensity / pixelCount;

            if (averageIntensity > 200)
                return "severe medical condition";
            else if (averageIntensity >= 100)
                return "Medium medical condition";
            else
                return "Mild medical condition";
        }
    }
}
