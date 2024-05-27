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
    public partial class searchForm : Form
    {
        public searchForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolderPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string folderPath = textBoxFolderPath.Text;
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Please select a valid folder.");
                return;
            }

            DateTime startDate = dateTimePickerStart.Value.Date; // Only use the date part
            DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1).AddTicks(-1); // End of the day

            long minSize = (long)numericUpDownMinSize.Value * 1024; // Converting KB to Bytes
            long maxSize = (long)numericUpDownMaxSize.Value * 1024; // Converting KB to Bytes

            listBoxResults.Items.Clear();

            var images = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                                  .Where(file => new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" }
                                  .Contains(Path.GetExtension(file).ToLower()))
                                  .Select(file => new FileInfo(file))
                                  .Where(fileInfo => fileInfo.Length >= minSize && fileInfo.Length <= maxSize)
                                  .Where(fileInfo => fileInfo.LastWriteTime >= startDate && fileInfo.LastWriteTime <= endDate);

            foreach (var image in images)
            {
                listBoxResults.Items.Add(image.FullName);
            }
        }
    }
}
