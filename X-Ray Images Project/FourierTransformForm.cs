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
    public partial class FourierTransformForm : Form
    {
        private Bitmap resizedImage;
        public FourierTransformForm()
        {
            InitializeComponent();
        }
        public void SetTransformedImage(Bitmap transformedImage)
        {
            resizedImage = ResizeImage(transformedImage, transformedPictureBox.Width, transformedPictureBox.Height);
            transformedPictureBox.Image = resizedImage;
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
    }
}
