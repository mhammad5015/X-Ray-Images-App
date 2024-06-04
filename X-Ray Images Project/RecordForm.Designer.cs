namespace X_Ray_Images_Project
{
    partial class RecordForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recordButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(13, 13);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 23);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(94, 13);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(175, 13);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(13, 43);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 3;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // saveAudioButton_Click
            // 
            this.saveButton.Location = new System.Drawing.Point(94, 43);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.recordButton);
            this.Name = "RecordForm";
            this.Text = "Audio Recorder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button saveButton;
    }
}
