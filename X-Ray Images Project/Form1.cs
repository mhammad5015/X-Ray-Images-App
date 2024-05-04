using System;
using System.Drawing;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class Form1 : Form
    {
        private Bitmap originalRadiograph;
        private Rectangle selectedArea;
        private bool isSelecting;
        private Point startPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    inputImage.Image = (Bitmap)originalRadiograph.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
                }
            }
        }

        private void inputImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                selectedArea = new Rectangle(startPoint, new Size());
                isSelecting = true;
            }
        }

        private void inputImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(startPoint.X - e.X);
                int height = Math.Abs(startPoint.Y - e.Y);

                // Update the selected area
                selectedArea = new Rectangle(x, y, width, height);
                inputImage.Invalidate();  // Force the PictureBox to be redrawn
            }
        }


        private void inputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                isSelecting = false;
                ApplyColorMapping();  // Apply color mapping to the selected area
                inputImage.Invalidate();  // Force refresh to clear the temporary rectangle
            }
        }

        private void inputImage_Paint(object sender, PaintEventArgs e)
        {
            if (isSelecting || (selectedArea.Width > 0 && selectedArea.Height > 0))
            {
                e.Graphics.DrawRectangle(Pens.Yellow, selectedArea);
            }
        }

        private Color MapColor(int grayscaleValue)
        {
            // Map grayscale value to a color gradient from black to green and white to red
            int red = grayscaleValue < 128 ? 255 : 255 - (grayscaleValue - 128) * 2;
            int green = grayscaleValue < 128 ? grayscaleValue * 2 : 255;
            return Color.FromArgb(red, green, 0);
        }

        private void ApplyColorMapping()
        {
            if (originalRadiograph != null)
            {
                // Ensure the selected area is valid
                if (selectedArea.Width > 0 && selectedArea.Height > 0)
                {
                    // Iterate through the selected area and apply color mapping
                    for (int y = selectedArea.Top; y < selectedArea.Bottom; y++)
                    {
                        for (int x = selectedArea.Left; x < selectedArea.Right; x++)
                        {
                            Color originalColor = originalRadiograph.GetPixel(x, y);
                            int grayscaleValue = (int)(originalColor.GetBrightness() * 255); // Convert to grayscale value
                            Color newColor = MapColor(grayscaleValue);
                            originalRadiograph.SetPixel(x, y, newColor);
                        }
                    }
                    // Update the PictureBox to display the modified image
                    inputImage.Image = (Bitmap)originalRadiograph.Clone();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
