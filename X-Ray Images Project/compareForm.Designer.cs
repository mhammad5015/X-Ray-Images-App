namespace X_Ray_Images_Project
{
    partial class compareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            Load1stImageBtn = new Button();
            secondImagePicBox = new PictureBox();
            firstImagePicBox = new PictureBox();
            Load2ndImageBtn = new Button();
            compareBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)secondImagePicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)firstImagePicBox).BeginInit();
            SuspendLayout();
            // 
            // Load1stImageBtn
            // 
            Load1stImageBtn.Location = new Point(194, 17);
            Load1stImageBtn.Name = "Load1stImageBtn";
            Load1stImageBtn.Size = new Size(121, 23);
            Load1stImageBtn.TabIndex = 0;
            Load1stImageBtn.Text = "Load 1st Image";
            Load1stImageBtn.UseVisualStyleBackColor = true;
            Load1stImageBtn.Click += Load1stImageBtn_Click;
            // 
            // secondImagePicBox
            // 
            secondImagePicBox.BorderStyle = BorderStyle.Fixed3D;
            secondImagePicBox.Location = new Point(509, 53);
            secondImagePicBox.Margin = new Padding(4, 3, 4, 3);
            secondImagePicBox.Name = "secondImagePicBox";
            secondImagePicBox.Size = new Size(456, 397);
            secondImagePicBox.TabIndex = 7;
            secondImagePicBox.TabStop = false;
            // 
            // firstImagePicBox
            // 
            firstImagePicBox.BorderStyle = BorderStyle.Fixed3D;
            firstImagePicBox.Location = new Point(24, 53);
            firstImagePicBox.Margin = new Padding(4, 3, 4, 3);
            firstImagePicBox.Name = "firstImagePicBox";
            firstImagePicBox.Size = new Size(456, 397);
            firstImagePicBox.TabIndex = 8;
            firstImagePicBox.TabStop = false;
            // 
            // Load2ndImageBtn
            // 
            Load2ndImageBtn.Location = new Point(666, 17);
            Load2ndImageBtn.Name = "Load2ndImageBtn";
            Load2ndImageBtn.Size = new Size(121, 23);
            Load2ndImageBtn.TabIndex = 9;
            Load2ndImageBtn.Text = "Load 2nd Image";
            Load2ndImageBtn.UseVisualStyleBackColor = true;
            Load2ndImageBtn.Click += Load2ndImageBtn_Click;
            // 
            // compareBtn
            // 
            compareBtn.Location = new Point(399, 466);
            compareBtn.Name = "compareBtn";
            compareBtn.Size = new Size(193, 24);
            compareBtn.TabIndex = 10;
            compareBtn.Text = "Compare";
            compareBtn.UseVisualStyleBackColor = true;
            compareBtn.Click += compareBtn_Click;
            // 
            // compareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 502);
            Controls.Add(compareBtn);
            Controls.Add(Load2ndImageBtn);
            Controls.Add(firstImagePicBox);
            Controls.Add(secondImagePicBox);
            Controls.Add(Load1stImageBtn);
            Name = "compareForm";
            Text = "compareForm";
            ((System.ComponentModel.ISupportInitialize)secondImagePicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)firstImagePicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Load1stImageBtn;
        private PictureBox secondImagePicBox;
        private PictureBox firstImagePicBox;
        private Button Load2ndImageBtn;
        private Button compareBtn;
    }
}