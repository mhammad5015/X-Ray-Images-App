
namespace YourNamespace
{
    partial class ShareForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonShareImageOnTelegramBot;
        private System.Windows.Forms.Button buttonShareAudioOnTelegramBot;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonShareImageOnTelegramBot = new Button();
            buttonShareAudioOnTelegramBot = new Button();
            SuspendLayout();
            // 
            // buttonShareImageOnTelegramBot
            // 
            buttonShareImageOnTelegramBot.Location = new Point(14, 14);
            buttonShareImageOnTelegramBot.Margin = new Padding(4, 3, 4, 3);
            buttonShareImageOnTelegramBot.Name = "buttonShareImageOnTelegramBot";
            buttonShareImageOnTelegramBot.Size = new Size(233, 27);
            buttonShareImageOnTelegramBot.TabIndex = 0;
            buttonShareImageOnTelegramBot.Text = "Share Image on Telegram Bot";
            buttonShareImageOnTelegramBot.UseVisualStyleBackColor = true;
            buttonShareImageOnTelegramBot.Click += buttonShareImageOnTelegramBot_Click;
            // 
            // buttonShareAudioOnTelegramBot
            // 
            buttonShareAudioOnTelegramBot.Location = new Point(14, 57);
            buttonShareAudioOnTelegramBot.Name = "buttonShareAudioOnTelegramBot";
            buttonShareAudioOnTelegramBot.Size = new Size(233, 27);
            buttonShareAudioOnTelegramBot.TabIndex = 1;
            buttonShareAudioOnTelegramBot.Text = "Share Audio on Telegram Bot";
            buttonShareAudioOnTelegramBot.UseVisualStyleBackColor = true;
            buttonShareAudioOnTelegramBot.Click += buttonShareAudioOnTelegramBot_Click;
            // 
            // ShareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 99);
            Controls.Add(buttonShareImageOnTelegramBot);
            Controls.Add(buttonShareAudioOnTelegramBot);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ShareForm";
            Text = "Share Files";
            ResumeLayout(false);
        }
    }
}
