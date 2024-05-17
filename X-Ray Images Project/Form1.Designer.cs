namespace X_Ray_Images_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            button1 = new Button();
            inputImage = new PictureBox();
            comboColorMap = new ComboBox();
            label1 = new Label();
            saveImage = new Button();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 12);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(198, 27);
            button1.TabIndex = 1;
            button1.Text = "Open Radiograph";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // inputImage
            // 
            inputImage.Location = new Point(14, 94);
            inputImage.Margin = new Padding(4, 3, 4, 3);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(404, 354);
            inputImage.TabIndex = 2;
            inputImage.TabStop = false;
            inputImage.Paint += inputImage_Paint;
            inputImage.MouseDown += inputImage_MouseDown;
            inputImage.MouseMove += inputImage_MouseMove;
            inputImage.MouseUp += inputImage_MouseUp;
            // 
            // comboColorMap
            // 
            comboColorMap.DropDownStyle = ComboBoxStyle.DropDownList;
            comboColorMap.FormattingEnabled = true;
            comboColorMap.Items.AddRange(new object[] { "Hot", "Cool", "Jet" });
            comboColorMap.Location = new Point(115, 53);
            comboColorMap.SelectedIndex = 0;
            comboColorMap.Name = "comboColorMap";
            comboColorMap.Size = new Size(121, 23);
            comboColorMap.TabIndex = 3;
            comboColorMap.SelectedIndexChanged += comboColorMap_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 56);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 4;
            label1.Text = "Select ColorMap";
            // 
            // saveImage
            // 
            saveImage.Location = new Point(32, 463);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(198, 29);
            saveImage.TabIndex = 5;
            saveImage.Text = "Save Image";
            saveImage.UseVisualStyleBackColor = true;
            saveImage.Click += saveImage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 504);
            Controls.Add(saveImage);
            Controls.Add(label1);
            Controls.Add(comboColorMap);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "X-Ray Images Project";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
        private PictureBox inputImage;
        private ComboBox comboColorMap;
        private Label label1;
        private Button saveImage;
    }
}
