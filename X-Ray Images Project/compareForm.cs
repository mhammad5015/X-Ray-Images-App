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
            if (firstImage != null && secondImage != null)
            {
                string result = CompareImages(ResizedImage1, ResizedImage2);
                MessageBox.Show(result, "Comparison Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please load both images before comparing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CompareImages(Bitmap image1, Bitmap image2)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                return "Images must be of the same dimensions for comparison.";
            }

            long totalDifference = 0;
            for (int y = 0; y < image1.Height; y++)
            {
                for (int x = 0; x < image1.Width; x++)
                {
                    Color color1 = image1.GetPixel(x, y);
                    Color color2 = image2.GetPixel(x, y);

                    int diffR = Math.Abs(color1.R - color2.R);
                    int diffG = Math.Abs(color1.G - color2.G);
                    int diffB = Math.Abs(color1.B - color2.B);

                    totalDifference += diffR + diffG + diffB;
                }
            }

            double avgDifference = totalDifference / (double)(image1.Width * image1.Height * 3);

            if (avgDifference < 10)
            {
                return "No significant change detected.";
            }
            else if (avgDifference < 50)
            {
                return "Mild changes detected, indicating possible progress or deterioration.";
            }
            else
            {
                return "Significant changes detected, indicating clear progress or deterioration.";
            }
        }
    }
}
