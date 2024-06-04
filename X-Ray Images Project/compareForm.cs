using System;
using System.Drawing;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class compareForm : Form
    {
        private Bitmap firstImage;
        private Bitmap secondImage;
        private Bitmap ResizedImage1;
        private Bitmap ResizedImage2;

        public compareForm()
        {
            InitializeComponent();
        }

        private void Load1stImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    firstImage = new Bitmap(openFileDialog.FileName);
                    ResizedImage1 = ResizeImage(firstImage, firstImagePicBox.Width, firstImagePicBox.Height);
                    firstImagePicBox.Image = ResizedImage1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
                }
            }
        }

        private void Load2ndImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    secondImage = new Bitmap(openFileDialog.FileName);
                    ResizedImage2 = ResizeImage(secondImage, secondImagePicBox.Width, secondImagePicBox.Height);
                    secondImagePicBox.Image = ResizedImage2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
                }
            }
        }

        private Bitmap ResizeImage(Bitmap image, int targetWidth, int targetHeight)
        {
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, targetWidth, targetHeight);
            }
            return resizedImage;
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            if (firstImage == null || secondImage == null)
            {
                MessageBox.Show("Please load both images before comparing.");
                return;
            }

            double avgIntensity1 = CalculateAverageIntensity(firstImage);
            double avgIntensity2 = CalculateAverageIntensity(secondImage);

            double threshold = 0.01;

            string result;
            double difference = Math.Abs(avgIntensity1 - avgIntensity2);

            if (difference < threshold)
            {
                result = "There is no significant difference between the images.";
            }
            else if (avgIntensity1 > avgIntensity2)
            {
                result = "There is progress in treatment.";
            }
            else
            {
                result = "There is a progression of the disease.";
            }

            MessageBox.Show(result);
        }

        private double CalculateAverageIntensity(Bitmap image)
        {
            double totalIntensity = 0;
            int width = image.Width;
            int height = image.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    double intensity = (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0;
                    totalIntensity += intensity;
                }
            }

            return totalIntensity / (width * height);
        }
    }
}
