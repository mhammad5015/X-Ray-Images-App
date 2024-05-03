//namespace X_Ray_Images_Project
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";

//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    string imageLocation = openFileDialog.FileName;
//                    inputImage.ImageLocation = imageLocation;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"An error occurred: {ex.Message}");
//                }
//            }
//        }
//    }
//}

using System;
using System.Drawing;
using System.Windows.Forms;

//namespace X_Ray_Images_Project
//{
//    public partial class Form1 : Form
//    {
//        private Bitmap originalRadiograph; // Store the original radiograph image
//        private Rectangle selectedArea; // Store the selected area by the mouse

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";

//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    string imageLocation = openFileDialog.FileName;
//                    inputImage.ImageLocation = imageLocation;

//                    // Load the original radiograph
//                    originalRadiograph = new Bitmap(imageLocation);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"An error occurred: {ex.Message}");
//                }
//            }
//        }

//        private void inputImage_MouseDown(object sender, MouseEventArgs e)
//        {
//            // Start selecting the affected area
//            selectedArea = new Rectangle(e.Location, new Size(0, 0));
//        }

//        private void inputImage_MouseMove(object sender, MouseEventArgs e)
//        {
//            if (e.Button == MouseButtons.Left)
//            {
//                // Update the selected area while moving the mouse
//                selectedArea.Width = e.X - selectedArea.X;
//                selectedArea.Height = e.Y - selectedArea.Y;

//                inputImage.Refresh(); // Refresh the picture box to draw the rectangle
//            }
//        }

//        private void inputImage_MouseUp(object sender, MouseEventArgs e)
//        {
//            // Finish selecting the affected area
//            selectedArea.Width = e.X - selectedArea.X;
//            selectedArea.Height = e.Y - selectedArea.Y;

//            // Perform affected area identification
//            Rectangle[] affectedAreas = IdentifyAffectedAreas(selectedArea);

//            // Draw rectangles around the affected areas
//            using (Graphics graphics = Graphics.FromImage(originalRadiograph))
//            {
//                Pen pen = new Pen(Color.Red, 2);
//                foreach (Rectangle area in affectedAreas)
//                {
//                    graphics.DrawRectangle(pen, area);
//                }
//            }

//            // Update the picture box with the modified radiograph
//            inputImage.Image = originalRadiograph;
//            inputImage.Refresh(); // Refresh the picture box to display the modified radiograph
//        }

//        private Rectangle[] IdentifyAffectedAreas(Rectangle selectedArea)
//        {
//            // Add your implementation here to identify the affected areas within the selectedArea
//            // using image processing techniques or machine learning algorithms

//            // For demonstration purposes, we'll assume the selectedArea itself is the affected area
//            return new Rectangle[] { selectedArea };
//        }

//        private void inputImage_Paint(object sender, PaintEventArgs e)
//        {
//            // Draw the selected area rectangle on the picture box
//            if (selectedArea.Width > 0 && selectedArea.Height > 0)
//            {
//                e.Graphics.DrawRectangle(Pens.Blue, selectedArea);
//            }
//        }

//        private void btnIdentifyAffectedAreas_Click(object sender, EventArgs e)
//        {
//            // Handle the button click event to identify affected areas
//            // You can add your logic here to perform the identification
//            // For example, you can call the IdentifyAffectedAreas() method
//            // and display the results in a message box or any other way you prefer.
//            MessageBox.Show("Identifying affected areas...");
//        }
//    }
//}

using System;
using System.Drawing;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;

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
                    MessageBox.Show("Image loaded successfully.");
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
                selectedArea = new Rectangle(e.Location, new Size());
                isSelecting = true;
            }
        }

        private void inputImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isSelecting)
            {
                selectedArea.Width = e.X - selectedArea.Left;
                selectedArea.Height = e.Y - selectedArea.Top;
                inputImage.Invalidate();  // Force the PictureBox to be redrawn
            }
        }

        private void inputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                selectedArea.Width = e.X - selectedArea.Left;
                selectedArea.Height = e.Y - selectedArea.Top;
                isSelecting = false;
                inputImage.Invalidate();  // Force refresh to clear the temporary rectangle
            }
        }

        private void inputImage_Paint(object sender, PaintEventArgs e)
        {
            if (isSelecting || (selectedArea.Width > 0 && selectedArea.Height > 0))
            {
                e.Graphics.DrawRectangle(Pens.Blue, selectedArea);
            }
        }

        private void inputImage_Click(object sender, EventArgs e)
        {

        }   
    }
}

