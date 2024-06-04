

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Image;
using Newtonsoft.Json.Linq;

namespace YourNamespace
{
    public partial class ShareForm : Form
    {
        private string savedImagePath;
        private string savedAudioPath;
        private string _savedImagePath;
        private string _savedAudioPath;
        private string botToken = "7187708880:AAHTQoaHOrIALlM7TcngJ6v3-Y8GKY07ECk";

        public ShareForm(string savedImagePath, string savedAudioPath)
        {
            InitializeComponent();
            _savedImagePath = savedImagePath;
            _savedAudioPath = savedAudioPath;

        }

        private async Task ShareFileOnTelegramBot(string filePath, string fileType)
        {
            string chatId = await GetChatId();
            if (!string.IsNullOrEmpty(chatId))
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var form = new MultipartFormDataContent())
                        {
                            form.Add(new StringContent(chatId), "chat_id");
                            var fileStream = new FileStream(filePath, FileMode.Open);
                            form.Add(new StreamContent(fileStream), fileType, Path.GetFileName(filePath));
                            string apiMethod = fileType == "audio" ? "sendAudio" : "sendDocument";
                            var response = await httpClient.PostAsync($"https://api.telegram.org/bot{botToken}/{apiMethod}", form);
                            if (!response.IsSuccessStatusCode)
                            {
                                throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase})");
                            }
                            MessageBox.Show($"{fileType} shared successfully on Telegram Bot!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sharing {fileType}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Could not retrieve chat ID.");
            }
        }

        private async Task<string> GetChatId()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://api.telegram.org/bot{botToken}/getUpdates");
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase})");
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);
                    var results = json["result"] as JArray;
                    if (results != null && results.Count > 0)
                    {
                        var chatId = results[0]["message"]?["chat"]?["id"]?.ToString();
                        return chatId;
                    }
                    else
                    {
                        MessageBox.Show("No messages found for the bot. Please send a message to the bot first.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving chat ID: {ex.Message}");
                return null;
            }
        }

        private async void buttonShareImageOnTelegramBot_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_savedImagePath) && File.Exists(_savedImagePath))
            {
                await ShareFileOnTelegramBot(_savedImagePath, "document");
            }
            else
            {
                MessageBox.Show("No image file selected or file does not exist.");
            }
        }

        private async void buttonShareAudioOnTelegramBot_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.wma";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _savedAudioPath = openFileDialog.FileName;
                MessageBox.Show($"Audio file selected: {_savedAudioPath}");
                await ShareFileOnTelegramBot(_savedAudioPath, "audio");
            }
        }
    }
}





