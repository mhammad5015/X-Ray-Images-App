
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NAudio.Wave;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge;
using Point = System.Drawing.Point;
namespace X_Ray_Images_Project
{
    public partial class Form1 : Form
    {
        private Bitmap originalRadiograph;
        private Bitmap resizedImage;
        private Bitmap coloredImage;
        private Bitmap resizedColoredImage;
        private List<System.Drawing.Rectangle> selectedAreas = new List<System.Drawing.Rectangle>();
        private HashSet<Point> coloredPixels = new HashSet<Point>();
        private System.Drawing.Rectangle selectedArea;
        private bool isSelecting;
        private Point startPoint;

        // Variables for audio recording
        private WaveInEvent waveIn;
        private WaveFileWriter writer;
        private string outputFilename;

        public Form1()
        {
            InitializeComponent();
            stopButton.Enabled = false;
            playButton.Enabled = false;
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
                    coloredImage = new Bitmap(originalRadiograph);
                    resizedColoredImage = ResizeImage(coloredImage, coloredPictureBox.Width, coloredPictureBox.Height);
                    inputImage.Image = resizedImage;
                    coloredPictureBox.Image = resizedColoredImage;
                    selectedAreas.Clear();
                    coloredPixels.Clear();
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

        private void inputImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && originalRadiograph != null)
            {
                startPoint = e.Location;
                selectedArea = new System.Drawing.Rectangle(startPoint, new Size());
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

                selectedArea = new System.Drawing.Rectangle(x, y, width, height);
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
                coloredPictureBox.Invalidate();
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

        private Point PictureBoxToImage(Point pt, PictureBox pictureBox)
        {
            float xRatio = (float)originalRadiograph.Width / pictureBox.ClientSize.Width;
            float yRatio = (float)originalRadiograph.Height / pictureBox.ClientSize.Height;
            return new Point((int)(pt.X * xRatio), (int)(pt.Y * yRatio));
        }

        private System.Drawing.Rectangle PictureBoxToImage(System.Drawing.Rectangle rect, PictureBox pictureBox)
        {
            Point topLeft = PictureBoxToImage(rect.Location, pictureBox);
            Point bottomRight = PictureBoxToImage(new Point(rect.Right, rect.Bottom), pictureBox);
            return new System.Drawing.Rectangle(topLeft, new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));
        }

        private void ApplyColorMapping()
        {
            if (originalRadiograph != null)
            {
                foreach (var area in selectedAreas)
                {
                    System.Drawing.Rectangle actualArea = PictureBoxToImage(area, inputImage);
                    for (int y = actualArea.Top; y < actualArea.Bottom; y++)
                    {
                        for (int x = actualArea.Left; x < actualArea.Right; x++)
                        {
                            Point point = new Point(x, y);
                            if (!coloredPixels.Contains(point))
                            {
                                if (x >= 0 && x < coloredImage.Width && y >= 0 && y < coloredImage.Height)
                                {
                                    Color originalColor = originalRadiograph.GetPixel(x, y);
                                    int grayscaleValue = (int)(originalColor.GetBrightness() * 255);
                                    Color newColor = MapColor(grayscaleValue);
                                    coloredImage.SetPixel(x, y, newColor);
                                    coloredPixels.Add(point);
                                }
                            }
                        }
                    }
                }
                resizedColoredImage = ResizeImage(coloredImage, coloredPictureBox.Width, coloredPictureBox.Height);
                coloredPictureBox.Image = resizedColoredImage;
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
                coloredPictureBox.Invalidate();
            }
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            if (coloredImage != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // ÊÍÏíÏ äæÚ ÇáÕæÑÉ
                        ImageFormat format = ImageFormat.Jpeg;
                        if (saveFileDialog.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            format = ImageFormat.Png;
                        }

                        // ÅäÔÇÁ äÓÎÉ ãä ÇáÕæÑÉ áÅÖÇÝÉ ÇáäÕ
                        using (Bitmap bitmap = new Bitmap(coloredImage.Width, coloredImage.Height))
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                graphics.DrawImage(coloredImage, new Point(0, 0));

                                // ÅÚÏÇÏÇÊ ÇáäÕ
                                string commentText = commentTextBox.Text;
                                System.Drawing.Font font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
                                Color textColor = Color.Red; // áæä ÇáäÕ
                                PointF textLocation = new PointF(10, coloredImage.Height - 40); // ãæÞÚ ÇáäÕ Úáì ÇáÕæÑÉ

                                // ÑÓã ÇáäÕ Úáì ÇáÕæÑÉ
                                using (Brush textBrush = new SolidBrush(textColor))
                                {
                                    graphics.DrawString(commentText, font, textBrush, textLocation);
                                }
                            }

                            // ÍÝÙ ÇáÕæÑÉ ÇáãÚÏáÉ
                            bitmap.Save(saveFileDialog.FileName, format);
                            MessageBox.Show("Image saved successfully with comment", "X-Ray", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (selectedAreas.Count > 0)
            {
                System.Drawing.Rectangle lastArea = selectedAreas[selectedAreas.Count - 1];
                selectedAreas.RemoveAt(selectedAreas.Count - 1);

                System.Drawing.Rectangle actualArea = PictureBoxToImage(lastArea, inputImage);

                for (int y = actualArea.Top; y < actualArea.Bottom; y++)
                {
                    for (int x = actualArea.Left; x < actualArea.Right; x++)
                    {
                        Point point = new Point(x, y);
                        if (coloredPixels.Contains(point))
                        {
                            if (x >= 0 && x < originalRadiograph.Width && y >= 0 && y < originalRadiograph.Height)
                            {
                                Color originalColor = originalRadiograph.GetPixel(x, y);
                                coloredImage.SetPixel(x, y, originalColor);
                                coloredPixels.Remove(point);
                            }
                        }
                    }
                }

                resizedColoredImage = ResizeImage(coloredImage, coloredPictureBox.Width, coloredPictureBox.Height);
                coloredPictureBox.Image = resizedColoredImage;

                inputImage.Invalidate();
                coloredPictureBox.Invalidate();
            }
            else
            {
                MessageBox.Show("No more actions to undo.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            compareForm comp = new compareForm();
            comp.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            searchForm srch = new searchForm();
            srch.Show();
        }

        private void classifyBtn_Click(object sender, EventArgs e)
        {
            classifyForm classify = new classifyForm();
            classify.Show();
        }

        private void btnOpenCropForm_Click(object sender, EventArgs e)
        {
            CropImageForm cropImageForm = new CropImageForm();
            cropImageForm.ShowDialog();
        }

        private void commentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (coloredImage != null)
            {
                // Þã ÈÅäÔÇÁ äÓÎÉ ãä ÇáÕæÑÉ ÇáÃÕáíÉ áÅÖÇÝÉ ÇáäÕ ÚáíåÇ
                Bitmap tempImage = new Bitmap(coloredImage);

                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    using (System.Drawing.Font arialFont = new System.Drawing.Font("Arial", 40)) // ÊÛííÑ ÍÌã ÇáÎØ Åáì 40
                    {
                        // ÍÓÇÈ ãæÖÚ ÇáäÕ áíßæä Ýí ÃÓÝá ÇáÕæÑÉ
                        SizeF textSize = g.MeasureString(commentTextBox.Text, arialFont);
                        float x = 10;
                        float y = tempImage.Height - textSize.Height - 10; // æÖÚ ÇáäÕ Ýí ÃÓÝá ÇáÕæÑÉ ãÚ åÇãÔ 10 ÈßÓá

                        g.DrawString(commentTextBox.Text, arialFont, Brushes.Red, new PointF(x, y));
                    }
                }

                // Þã ÈÊÍÏíË ÇáÕæÑÉ Ýí PictureBox áÚÑÖ ÇáÊÚáíÞ
                resizedColoredImage = ResizeImage(tempImage, coloredPictureBox.Width, coloredPictureBox.Height);
                coloredPictureBox.Image = resizedColoredImage;

                // ÊÎáÕ ãä ÇáÕæÑÉ ÇáãÄÞÊÉ áÊÌäÈ ÊÓÑÈ ÇáÐÇßÑÉ
                tempImage.Dispose();
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "WAV Files|*.wav",
                Title = "Save Audio As"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFilename = saveFileDialog.FileName;
                waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(44100, 1);
                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                waveIn.StartRecording();

                stopButton.Enabled = true;
                playButton.Enabled = true;
            }
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            writer.Flush();
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            writer?.Dispose();
            writer = null;
            waveIn?.Dispose();
            waveIn = null;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            waveIn?.StopRecording();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputFilename) && File.Exists(outputFilename))
            {
                using (var audioFile = new AudioFileReader(outputFilename))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                MessageBox.Show("No audio to play. Please record audio first.", "Play Audio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveAudioButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputFilename) && File.Exists(outputFilename))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "WAV Files|*.wav";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(outputFilename, saveFileDialog.FileName, true);
                        MessageBox.Show("Audio saved successfully.", "Save Audio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No audio to save. Please record audio first.", "Save Audio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void createReportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save Medical Report"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateMedicalReport(saveFileDialog.FileName);
            }
        }

        private void CreateMedicalReport(string filename)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            // Add title
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph title = new Paragraph("Medical Report", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);

            // Add date
            iTextSharp.text.Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph date = new Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy"), dateFont)
            {
                Alignment = Element.ALIGN_RIGHT
            };
            doc.Add(date);

            // Add space
            doc.Add(new Paragraph("\n"));

            // Add comment
            if (!string.IsNullOrEmpty(commentTextBox.Text))
            {
                iTextSharp.text.Font commentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph comment = new Paragraph("Comment: " + commentTextBox.Text, commentFont);
                comment.Alignment = Element.ALIGN_LEFT;
                doc.Add(new Paragraph("Comment: " + commentTextBox.Text, commentFont));
                doc.Add(new Paragraph("\n"));
            }

            // Add X-ray image
            if (coloredImage != null)
            {
                iTextSharp.text.Image xrayImage;
                using (MemoryStream ms = new MemoryStream())
                {
                    coloredImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    xrayImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                }
                xrayImage.ScaleToFit(500f, 500f);
                xrayImage.Alignment = Element.ALIGN_CENTER;
                doc.Add(xrayImage);
            }

            // Add audio comment link
            if (!string.IsNullOrEmpty(outputFilename) && File.Exists(outputFilename))
            {
                iTextSharp.text.Font linkFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.UNDERLINE, BaseColor.BLUE);
                Anchor audioLink = new Anchor("Click here to listen to the audio comment", linkFont)
                {
                    Reference = outputFilename
                };
                doc.Add(audioLink);
            }

            doc.Close();

            MessageBox.Show("Medical report created successfully.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            commentTextBox.TextChanged += new EventHandler(commentTextBox_TextChanged);
        }

        private void FourierTransformBtn_Click(object sender, EventArgs e)
        {
            if (originalRadiograph != null)
            {
                Bitmap transformedImage = ApplyFourierTransform(originalRadiograph);
                FourierTransformForm transForm = new FourierTransformForm();
                transForm.SetTransformedImage(transformedImage);
                transForm.Show();
            }
            else
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static Bitmap ApplyFourierTransform(Bitmap originalImage)
        {
            // Create grayscale filter (BT709)
            Grayscale filter1 = new Grayscale(0.2125, 0.7154, 0.0721);

            // Apply the filter
            Bitmap grayImage = filter1.Apply(originalImage);

            // Resize the image to the nearest power of 2 dimensions
            int newWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(grayImage.Width, 2)));
            int newHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(grayImage.Height, 2)));

            ResizeBilinear resizeFilter = new ResizeBilinear(newWidth, newHeight);
            Bitmap resizedImage = resizeFilter.Apply(grayImage);

            // Convert the resized image to a complex image
            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);

            // Perform forward Fourier transform
            complexImage.ForwardFourierTransform();

            // Apply a high-pass filter with more aggressive settings
            FrequencyFilter highPassFilter = new FrequencyFilter(new IntRange(10, Math.Max(newWidth, newHeight) / 2));
            highPassFilter.Apply(complexImage);

            // Perform the inverse Fourier transform
            complexImage.BackwardFourierTransform();

            // Convert the complex image back to a bitmap
            Bitmap filteredImage = complexImage.ToBitmap();

            // Enhance contrast
            ContrastStretch contrastStretch = new ContrastStretch();
            contrastStretch.ApplyInPlace(filteredImage);

            // Sharpen the image to highlight details
            Sharpen sharpenFilter = new Sharpen();
            sharpenFilter.ApplyInPlace(filteredImage);

            return filteredImage;
        }
    }
}