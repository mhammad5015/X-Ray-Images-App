using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace X_Ray_Images_Project
{
    public partial class Form1 : Form
    {
        private Bitmap originalRadiograph;
        private Bitmap resizedImage;
        private List<Rectangle> selectedAreas = new List<Rectangle>();
        private HashSet<Point> coloredPixels = new HashSet<Point>();
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
                    resizedImage = ResizeImage(originalRadiograph, inputImage.Width, inputImage.Height);
                    inputImage.Image = resizedImage;
                    selectedAreas.Clear();
                    coloredPixels.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
                }
            }
        }

        private Bitmap ResizeImage(Bitmap originalImage, int targetWidth, int targetHeight)
        {
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
            }
            return resizedImage;
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

                selectedArea = new Rectangle(x, y, width, height);
                inputImage.Invalidate();
            }
        }

        private void inputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                isSelecting = false;
                selectedAreas.Add(selectedArea);
                ApplyColorMapping();
                inputImage.Invalidate();
            }
        }

        private void inputImage_Paint(object sender, PaintEventArgs e)
        {
            foreach (var area in selectedAreas)
            {
                e.Graphics.DrawRectangle(Pens.Yellow, area);
            }
            if (isSelecting)
            {
                e.Graphics.DrawRectangle(Pens.Yellow, selectedArea);
            }
        }

        private Point PictureBoxToImage(Point pt)
        {
            float xRatio = (float)originalRadiograph.Width / inputImage.ClientSize.Width;
            float yRatio = (float)originalRadiograph.Height / inputImage.ClientSize.Height;
            return new Point((int)(pt.X * xRatio), (int)(pt.Y * yRatio));
        }

        private Rectangle PictureBoxToImage(Rectangle rect)
        {
            Point topLeft = PictureBoxToImage(rect.Location);
            Point bottomRight = PictureBoxToImage(new Point(rect.Right, rect.Bottom));
            return new Rectangle(topLeft, new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));
        }

        private void ApplyColorMapping()
        {
            if (originalRadiograph != null)
            {
                foreach (var area in selectedAreas)
                {
                    Rectangle actualArea = PictureBoxToImage(area);
                    for (int y = actualArea.Top; y < actualArea.Bottom; y++)
                    {
                        for (int x = actualArea.Left; x < actualArea.Right; x++)
                        {
                            Point point = new Point(x, y);
                            if (!coloredPixels.Contains(point))
                            {
                                if (x >= 0 && x < originalRadiograph.Width && y >= 0 && y < originalRadiograph.Height)
                                {
                                    Color originalColor = originalRadiograph.GetPixel(x, y);
                                    int grayscaleValue = (int)(originalColor.GetBrightness() * 255);
                                    Color newColor = MapColor(grayscaleValue);
                                    originalRadiograph.SetPixel(x, y, newColor);
                                    coloredPixels.Add(point);
                                }
                            }
                        }
                    }
                }
                resizedImage = ResizeImage(originalRadiograph, inputImage.Width, inputImage.Height);
                inputImage.Image = resizedImage;
            }
        }

        private Color MapColor(int grayscaleValue)
        {
            string colorMapType = comboColorMap.SelectedItem.ToString();

            switch (colorMapType)
            {
                case "Hot":
                    int red = grayscaleValue < 128 ? 0 : 255;
                    int green = grayscaleValue < 128 ? grayscaleValue * 2 : 255;
                    return Color.FromArgb(red, green, 255 - grayscaleValue);
                case "Cool":
                    int blue = grayscaleValue < 128 ? 255 : 0;
                    int green1 = grayscaleValue < 128 ? 255 - grayscaleValue * 2 : 0;
                    return Color.FromArgb(0, green1, blue);
                case "Jet":
                    if (grayscaleValue < 64)
                        return Color.FromArgb(0, 0, (int)(4 * grayscaleValue));
                    else if (grayscaleValue < 128)
                        return Color.FromArgb(0, (int)(4 * (grayscaleValue - 64)), 255);
                    else if (grayscaleValue < 192)
                        return Color.FromArgb((int)(4 * (grayscaleValue - 128)), 255, (int)(255 - 4 * (grayscaleValue - 128)));
                    else
                        return Color.FromArgb(255, (int)(255 - 4 * (grayscaleValue - 192)), 0);
                default:
                    return Color.FromArgb(grayscaleValue, grayscaleValue, grayscaleValue);
            }
        }


        private void comboColorMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedArea.Width > 0 && selectedArea.Height > 0)
            {
                ApplyColorMapping();
                inputImage.Invalidate();
            }
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            if (originalRadiograph != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Jpeg;
                        if (saveFileDialog.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            format = ImageFormat.Png;
                        }
                        originalRadiograph.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("message saved successfully", "X-Ray", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
