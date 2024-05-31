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
        public classifyForm()
        {
            InitializeComponent();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedRectangle);
                }
            }
        }

        private string ClassifyRegion(Rectangle region, Bitmap image)
        {
            // Placeholder function: replace with actual classification logic
            Random random = new Random();
            int severity = random.Next(0, 3);
            switch (severity)
            {
                case 0:
                    return "Mild";
                case 1:
                    return "Moderate";
                case 2:
                    return "Severe";
                default:
                    return "Unknown";
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

            string result = ClassifyRegion(region, image);
            textBoxClassification.Text = result;
        }
    }
}
