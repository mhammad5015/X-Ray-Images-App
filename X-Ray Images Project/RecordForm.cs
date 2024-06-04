using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Lame;

namespace X_Ray_Images_Project
{
    public partial class RecordForm : Form
    {
        private string tempFilename;
        private WaveInEvent waveIn;
        private WaveFileWriter writer;
        private string _savedAudioPath;

        public RecordForm()
        {
            InitializeComponent();
            // Initial state of buttons
            stopButton.Enabled = false;
            playButton.Enabled = false;
            saveButton.Enabled = false;
            compressButton.Enabled = false;
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            tempFilename = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");
            StartRecording(tempFilename);
            // Enable buttons when recording starts
            stopButton.Enabled = true;
            playButton.Enabled = true;
            saveButton.Enabled = true;
            compressButton.Enabled = true;
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "MP3 Files|*.mp3",
                Title = "Save Compressed Audio As"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilename = tempFilename;
                StartRecording(outputFilename, saveFileDialog.FileName);
            }
        }

        private void StartRecording(string wavFileName, string mp3FileName = null)
        {
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += (s, e) => OnRecordingStopped(mp3FileName);
            writer = new WaveFileWriter(wavFileName, waveIn.WaveFormat);
            waveIn.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            writer.Flush();
        }

        private void OnRecordingStopped(string mp3FileName = null)
        {
            writer?.Dispose();
            writer = null;
            waveIn?.Dispose();
            waveIn = null;

            if (!string.IsNullOrEmpty(mp3FileName))
            {
                CompressToMp3(tempFilename, mp3FileName);
            }
        }

        private void CompressToMp3(string wavFileName, string mp3FileName)
        {
            using (var reader = new AudioFileReader(wavFileName))
            using (var writer = new LameMP3FileWriter(mp3FileName, reader.WaveFormat, LAMEPreset.STANDARD))
            {
                reader.CopyTo(writer);
            }

            // Optionally delete the WAV file after compression
            if (File.Exists(wavFileName))
            {
                File.Delete(wavFileName);
            }

            MessageBox.Show("Recording saved and compressed successfully.", "Save and Compress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            waveIn?.StopRecording();
            // Disable buttons when recording stops
            stopButton.Enabled = true;
            playButton.Enabled =true;
            saveButton.Enabled = true;
            compressButton.Enabled = true;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tempFilename) && File.Exists(tempFilename))
            {
                using (var audioFile = new AudioFileReader(tempFilename))
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "MP3 Files|*.mp3",
                Title = "Save Audio As"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(tempFilename, saveFileDialog.FileName, true);
                _savedAudioPath = saveFileDialog.FileName;
                MessageBox.Show("Recording saved successfully.", "Save Audio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

