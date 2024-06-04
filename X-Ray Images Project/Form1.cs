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
using NAudio.Lame;
using Point = System.Drawing.Point;
using YourNamespace;
using System.IO.Compression;
using AForge.Math.Geometry;

namespace X_Ray_Images_Project
{
    public partial class Form1 : Form
    {
        private Bitmap originalRadiograph;
        private Bitmap resizedImage;
        private Bitmap coloredImage;
        private Bitmap resizedColoredImage;
        private List<System.Drawing.Rectangle> selectedRectangles = new List<System.Drawing.Rectangle>();
        private List<System.Drawing.Rectangle> selectedTriangles = new List<System.Drawing.Rectangle>();
        private List<System.Drawing.Rectangle> selectedCircles = new List<System.Drawing.Rectangle>();
        private List<Tuple<System.Drawing.Rectangle, ShapeType>> selectedAreas = new List<Tuple<System.Drawing.Rectangle, ShapeType>>();
        private HashSet<Point> coloredPixels = new HashSet<Point>();
        private System.Drawing.Rectangle selectedArea;
        private bool isSelecting;
        private Point startPoint;

        // Variables for audio recording
        private WaveInEvent waveIn;
        private WaveFileWriter writer;
        private string outputFilename;

        private Document reportDocument;
        private MemoryStream reportStream;

        private string savedImagePath;
        private string savedAudioPath;
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
                    coloredImage = new Bitmap(originalRadiograph);
                    resizedColoredImage = ResizeImage(coloredImage, coloredPictureBox.Width, coloredPictureBox.Height);
                    inputImage.Image = resizedImage;
                    coloredPictureBox.Image = resizedColoredImage;
                    selectedAreas.Clear();
                    selectedCircles.Clear();
                    selectedTriangles.Clear();
                    selectedRectangles.Clear();
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
                if (currentShape == ShapeType.Circle)
                {
                    int diameter = Math.Min(Math.Abs(startPoint.X - e.X), Math.Abs(startPoint.Y - e.Y));
                    int x = startPoint.X < e.X ? startPoint.X : startPoint.X - diameter;
                    int y = startPoint.Y < e.Y ? startPoint.Y : startPoint.Y - diameter;
                    selectedArea = new System.Drawing.Rectangle(x, y, diameter, diameter);
                }
                else
                {
                    int x = Math.Min(startPoint.X, e.X);
                    int y = Math.Min(startPoint.Y, e.Y);
                    int width = Math.Abs(startPoint.X - e.X);
                    int height = Math.Abs(startPoint.Y - e.Y);
                    selectedArea = new System.Drawing.Rectangle(x, y, width, height);
                }
                inputImage.Invalidate();
            }
        }


        private void inputImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                isSelecting = false;

                if (currentShape == ShapeType.Circle)
                {
                    int diameter = Math.Min(Math.Abs(startPoint.X - e.X), Math.Abs(startPoint.Y - e.Y));
                    int x = startPoint.X < e.X ? startPoint.X : startPoint.X - diameter;
                    int y = startPoint.Y < e.Y ? startPoint.Y : startPoint.Y - diameter;
                    selectedArea = new System.Drawing.Rectangle(x, y, diameter, diameter);
                }
                else
                {
                    int x = Math.Min(startPoint.X, e.X);
                    int y = Math.Min(startPoint.Y, e.Y);
                    int width = Math.Abs(startPoint.X - e.X);
                    int height = Math.Abs(startPoint.Y - e.Y);
                    selectedArea = new System.Drawing.Rectangle(x, y, width, height);
                }

                switch (currentShape)
                {
                    case ShapeType.Rectangle:
                        selectedRectangles.Add(selectedArea);
                        selectedAreas.Add(Tuple.Create(selectedArea, ShapeType.Rectangle));
                        break;
                    case ShapeType.Triangle:
                        selectedTriangles.Add(selectedArea);
                        selectedAreas.Add(Tuple.Create(selectedArea, ShapeType.Triangle));
                        break;
                    case ShapeType.Circle:
                        selectedCircles.Add(selectedArea);
                        selectedAreas.Add(Tuple.Create(selectedArea, ShapeType.Circle));
                        break;
                }

                ApplyColorMapping();
                inputImage.Invalidate();
                coloredPictureBox.Invalidate();
            }
        }

        private void inputImage_Paint(object sender, PaintEventArgs e)
        {
            foreach (var area in selectedRectangles)
            {
                DrawShape(e.Graphics, area, ShapeType.Rectangle, Pens.Yellow);
            }

            foreach (var area in selectedTriangles)
            {
                DrawShape(e.Graphics, area, ShapeType.Triangle, Pens.Yellow);
            }

            foreach (var area in selectedCircles)
            {
                DrawShape(e.Graphics, area, ShapeType.Circle, Pens.Yellow);
            }

            if (isSelecting)
            {
                DrawShape(e.Graphics, selectedArea, currentShape, Pens.Yellow);
            }
        }

        public enum ShapeType
        {
            Rectangle,
            Triangle,
            Circle
        }
        private ShapeType currentShape = ShapeType.Rectangle;
        private void comboSelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboSelectShape.SelectedItem.ToString())
            {
                case "Rectangle":
                    currentShape = ShapeType.Rectangle;
                    break;
                case "Triangle":
                    currentShape = ShapeType.Triangle;
                    break;
                case "Circle":
                    currentShape = ShapeType.Circle;
                    break;
            }
        }

        private void DrawShape(Graphics g, System.Drawing.Rectangle rect, ShapeType shape, Pen pen)
        {
            switch (shape)
            {
                case ShapeType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ShapeType.Triangle:
                    Point p1 = new Point(rect.Left + rect.Width / 2, rect.Top);
                    Point p2 = new Point(rect.Left, rect.Bottom);
                    Point p3 = new Point(rect.Right, rect.Bottom);
                    g.DrawPolygon(pen, new Point[] { p1, p2, p3 });
                    break;
                case ShapeType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void ApplyColorMapping()
        {
            if (originalRadiograph != null)
            {
                foreach (var area in selectedRectangles)
                {
                    System.Drawing.Rectangle actualArea = PictureBoxToImage(area, inputImage);
                    ApplyColorMappingToRectangle(actualArea);
                }

                foreach (var area in selectedTriangles)
                {
                    System.Drawing.Rectangle actualArea = PictureBoxToImage(area, inputImage);
                    ApplyColorMappingToTriangle(actualArea);
                }

                foreach (var area in selectedCircles)
                {
                    System.Drawing.Rectangle actualArea = PictureBoxToImage(area, inputImage);
                    ApplyColorMappingToCircle(actualArea);
                }

                resizedColoredImage = ResizeImage(coloredImage, coloredPictureBox.Width, coloredPictureBox.Height);
                coloredPictureBox.Image = resizedColoredImage;
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



        private void ApplyColorMappingToRectangle(System.Drawing.Rectangle rect)
        {
            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    ApplyColorToPoint(x, y);
                }
            }
        }

        private void ApplyColorMappingToTriangle(System.Drawing.Rectangle rect)
        {
            Point p1 = new Point(rect.Left + rect.Width / 2, rect.Top);
            Point p2 = new Point(rect.Left, rect.Bottom);
            Point p3 = new Point(rect.Right, rect.Bottom);
            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    if (IsPointInTriangle(new Point(x, y), p1, p2, p3))
                    {
                        ApplyColorToPoint(x, y);
                    }
                }
            }
        }

        private void ApplyColorMappingToCircle(System.Drawing.Rectangle rect)
        {
            Point center = new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
            int radius = Math.Min(rect.Width, rect.Height) / 2;
            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    if (IsPointInCircle(new Point(x, y), center, radius))
                    {
                        ApplyColorToPoint(x, y);
                    }
                }
            }
        }

        private bool IsPointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            // Implement point-in-triangle test using barycentric coordinates
            float dX = pt.X - v3.X;
            float dY = pt.Y - v3.Y;
            float dX21 = v3.X - v2.X;
            float dY12 = v2.Y - v3.Y;
            float D = dY12 * (v1.X - v3.X) + dX21 * (v1.Y - v3.Y);
            float s = dY12 * dX + dX21 * dY;
            float t = (v3.Y - v1.Y) * dX + (v1.X - v3.X) * dY;
            if (D < 0)
                return s <= 0 && t <= 0 && s + t >= D;
            return s >= 0 && t >= 0 && s + t <= D;
        }

        private bool IsPointInCircle(Point pt, Point center, int radius)
        {
            return (pt.X - center.X) * (pt.X - center.X) + (pt.Y - center.Y) * (pt.Y - center.Y) <= radius * radius;
        }

        private void ApplyColorToPoint(int x, int y)
        {
            if (x >= 0 && x < coloredImage.Width && y >= 0 && y < coloredImage.Height)
            {
                Point point = new Point(x, y);
                if (!coloredPixels.Contains(point))
                {
                    Color originalColor = originalRadiograph.GetPixel(x, y);
                    int grayscaleValue = (int)(originalColor.GetBrightness() * 255);
                    Color newColor = MapColor(grayscaleValue);
                    coloredImage.SetPixel(x, y, newColor);
                    coloredPixels.Add(point);
                }
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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (selectedAreas.Count > 0)
            {
                // Get the last added area and shape type
                var lastAreaInfo = selectedAreas[selectedAreas.Count - 1];
                selectedAreas.RemoveAt(selectedAreas.Count - 1);

                System.Drawing.Rectangle lastArea = lastAreaInfo.Item1;
                ShapeType lastShape = lastAreaInfo.Item2;

                // Remove the last area from the shape-specific list
                switch (lastShape)
                {
                    case ShapeType.Rectangle:
                        selectedRectangles.Remove(lastArea);
                        break;
                    case ShapeType.Triangle:
                        selectedTriangles.Remove(lastArea);
                        break;
                    case ShapeType.Circle:
                        selectedCircles.Remove(lastArea);
                        break;
                }

                // Clear the colors in the last area
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


        private void saveImage_Click(object sender, EventArgs e)
        {
            if (coloredImage != null)
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

                        using (Bitmap bitmap = new Bitmap(coloredImage.Width, coloredImage.Height))
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                graphics.DrawImage(coloredImage, new Point(0, 0));

                                string commentText = commentTextBox.Text;
                                System.Drawing.Font font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
                                Color textColor = Color.Red;
                                PointF textLocation = new PointF(10, coloredImage.Height - 40);

                                using (Brush textBrush = new SolidBrush(textColor))
                                {
                                    graphics.DrawString(commentText, font, textBrush, textLocation);
                                }
                            }

                            bitmap.Save(saveFileDialog.FileName, format);
                            savedImagePath = saveFileDialog.FileName;
                            MessageBox.Show("Image saved successfully with comment", "X-Ray", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void compressSaveButton_Click(object sender, EventArgs e)
        {
            if (coloredImage != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "ZIP Files|*.zip",
                    Title = "Save Compressed Image As"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
                        CompressAndSaveImage(coloredImage, tempFilePath);
                        CompressImageToZip(tempFilePath, saveFileDialog.FileName);
                        File.Delete(tempFilePath);
                        MessageBox.Show("Image saved and compressed successfully.", "Save and Compress", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No colored image to save. Please load and process an image first.", "Save and Compress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompressAndSaveImage(Bitmap image, string filePath)
        {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            image.Save(filePath, jpgEncoder, myEncoderParameters);
        }

        private void CompressImageToZip(string imageFilePath, string zipFilePath)
        {
            using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(imageFilePath, Path.GetFileName(imageFilePath));
                }
            }
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
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
                Bitmap tempImage = new Bitmap(coloredImage);

                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    using (System.Drawing.Font arialFont = new System.Drawing.Font("Arial", 40)) 
                    {
                        SizeF textSize = g.MeasureString(commentTextBox.Text, arialFont);
                        float x = 10;
                        float y = tempImage.Height - textSize.Height - 10;

                        g.DrawString(commentTextBox.Text, arialFont, Brushes.Red, new PointF(x, y));
                    }
                }

                resizedColoredImage = ResizeImage(tempImage, coloredPictureBox.Width, coloredPictureBox.Height);
                coloredPictureBox.Image = resizedColoredImage;

                tempImage.Dispose();
            }
        }

        private void openRecordFormButton_Click(object sender, EventArgs e)
        {
            RecordForm recordForm = new RecordForm();
            recordForm.Show();
        }



        private Document doc;
        private MemoryStream pdfStream;
        private void createReportButton_Click(object sender, EventArgs e)
        {
            // Initialize the document and memory stream
            doc = new Document(PageSize.A4);
            pdfStream = new MemoryStream();
            PdfWriter.GetInstance(doc, pdfStream);
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
            // Add age
            if (!string.IsNullOrEmpty(ageTextBox.Text))
            {
                iTextSharp.text.Font ageFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph age = new Paragraph("Age: " + ageTextBox.Text, ageFont);
                age.Alignment = Element.ALIGN_LEFT;
                doc.Add(age);
                doc.Add(new Paragraph("\n"));
            }
            // Add gender
            if (genderComboBox.SelectedItem != null)
            {
                iTextSharp.text.Font genderFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph gender = new Paragraph("Gender: " + genderComboBox.SelectedItem.ToString(), genderFont)
                {
                    Alignment = Element.ALIGN_LEFT
                };
                doc.Add(gender);
                doc.Add(new Paragraph("\n"));
            }
            // Add space
            doc.Add(new Paragraph("\n"));
            // Add comment
            if (!string.IsNullOrEmpty(commentTextBox.Text))
            {
                iTextSharp.text.Font commentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph comment = new Paragraph("Comment: " + commentTextBox.Text, commentFont);
                comment.Alignment = Element.ALIGN_LEFT;
                doc.Add(comment);
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
            // Finalize the document
            doc.Close();
            MessageBox.Show("Medical report created successfully. You can now save or compress the report.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveReportButton_Click(object sender, EventArgs e)
        {
            if (pdfStream != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Save Medical Report"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, pdfStream.ToArray());
                        MessageBox.Show("Report saved successfully.", "Save Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the report: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No report to save. Please create a report first.", "Save Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void compressAndSaveButton_Click(object sender, EventArgs e)
        {
            if (pdfStream != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "ZIP Files|*.zip",
                    Title = "Save Compressed Medical Report"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                        File.WriteAllBytes(tempFilePath, pdfStream.ToArray());
                        CompressToZip(tempFilePath, saveFileDialog.FileName);
                        File.Delete(tempFilePath);
                        MessageBox.Show("Report compressed and saved successfully.", "Compress and Save Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while compressing and saving the report: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No report to compress and save. Please create a report first.", "Compress and Save Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompressToZip(string filePath, string zipFilePath)
        {
            using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                }
            }
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
            Grayscale filter1 = new Grayscale(0.2125, 0.7154, 0.0721);

            Bitmap grayImage = filter1.Apply(originalImage);

            int newWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(grayImage.Width, 2)));
            int newHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(grayImage.Height, 2)));

            ResizeBilinear resizeFilter = new ResizeBilinear(newWidth, newHeight);
            Bitmap resizedImage = resizeFilter.Apply(grayImage);

            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);

            complexImage.ForwardFourierTransform();

            FrequencyFilter highPassFilter = new FrequencyFilter(new IntRange(10, Math.Max(newWidth, newHeight) / 2));
            highPassFilter.Apply(complexImage);

            complexImage.BackwardFourierTransform();

            Bitmap filteredImage = complexImage.ToBitmap();

            // Enhance contrast
            ContrastStretch contrastStretch = new ContrastStretch();
            contrastStretch.ApplyInPlace(filteredImage);

            // Sharpen the image to highlight details
            Sharpen sharpenFilter = new Sharpen();
            sharpenFilter.ApplyInPlace(filteredImage);

            return filteredImage;
        }

        private void buttonOpenShareForm_Click(object sender, EventArgs e)
        {
            ShareForm shareForm = new ShareForm(savedImagePath, savedAudioPath);
            shareForm.Show();
        }
    }
}