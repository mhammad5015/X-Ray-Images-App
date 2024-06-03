namespace YourNamespace
{
    partial class ShareForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonShareOnTelegramBot;

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
            this.buttonShareOnTelegramBot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShareOnTelegramBot
            // 
            this.buttonShareOnTelegramBot.Location = new System.Drawing.Point(12, 12);
            this.buttonShareOnTelegramBot.Name = "buttonShareOnTelegramBot";
            this.buttonShareOnTelegramBot.Size = new System.Drawing.Size(200, 23);
            this.buttonShareOnTelegramBot.TabIndex = 0;
            this.buttonShareOnTelegramBot.Text = "Share on Telegram Bot";
            this.buttonShareOnTelegramBot.UseVisualStyleBackColor = true;
            this.buttonShareOnTelegramBot.Click += new System.EventHandler(this.buttonShareOnTelegramBot_Click);
            // 
            // ShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 46);
            this.Controls.Add(this.buttonShareOnTelegramBot);
            this.Name = "ShareForm";
            this.Text = "Share Files";
            this.ResumeLayout(false);

        }
    }
}
