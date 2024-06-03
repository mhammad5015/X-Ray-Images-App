using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace YourNamespace
{
    public partial class ShareForm : Form
    {
        private string filePath;
        private string botToken = "7187708880:AAHTQoaHOrIALlM7TcngJ6v3-Y8GKY07ECk"; // تأكد من إدخال التوكن الصحيح

        public ShareForm(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private async void buttonShareOnTelegramBot_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string chatId = await GetChatId();
                if (!string.IsNullOrEmpty(chatId))
                {
                    await ShareOnTelegramBot(filePath, chatId);
                }
                else
                {
                    MessageBox.Show("Could not retrieve chat ID.");
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}");
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

        private async Task ShareOnTelegramBot(string filePath, string chatId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        form.Add(new StringContent(chatId), "chat_id");
                        var fileStream = new FileStream(filePath, FileMode.Open);
                        form.Add(new StreamContent(fileStream), "document", Path.GetFileName(filePath));

                        var response = await httpClient.PostAsync($"https://api.telegram.org/bot{botToken}/sendDocument", form);
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase})");
                        }
                        MessageBox.Show("File shared successfully on Telegram Bot!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sharing file: {ex.Message}");
            }
        }
    }
}
