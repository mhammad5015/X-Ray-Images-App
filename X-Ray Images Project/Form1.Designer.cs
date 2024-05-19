namespace X_Ray_Images_Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            coloredPictureBox = new PictureBox();
            comboColorMap = new ComboBox();
            label1 = new Label();
            saveImage = new Button();
            btnUndo = new Button();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coloredPictureBox).BeginInit();
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
            inputImage.BorderStyle = BorderStyle.Fixed3D;
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
            // coloredPictureBox
            // 
            coloredPictureBox.BorderStyle = BorderStyle.Fixed3D;
            coloredPictureBox.Location = new Point(450, 94);
            coloredPictureBox.Margin = new Padding(4, 3, 4, 3);
            coloredPictureBox.Name = "coloredPictureBox";
            coloredPictureBox.Size = new Size(404, 354);
            coloredPictureBox.TabIndex = 6;
            coloredPictureBox.TabStop = false;
            // 
            // comboColorMap
            // 
            comboColorMap.DropDownStyle = ComboBoxStyle.DropDownList;
            comboColorMap.FormattingEnabled = true;
            comboColorMap.Items.AddRange(new object[] { "Hot", "Cool", "Jet" });
            comboColorMap.Location = new Point(115, 53);
            comboColorMap.SelectedIndex = 0;
            comboColorMap.Name = "comboColorMap";
            comboColorMap.Size = new Size(115, 23);
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
            saveImage.Location = new Point(450, 463);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(198, 29);
            saveImage.TabIndex = 5;
            saveImage.Text = "Save Image";
            saveImage.UseVisualStyleBackColor = true;
            saveImage.Click += saveImage_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(274, 53);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(132, 23);
            btnUndo.TabIndex = 7;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 504);
            Controls.Add(btnUndo);
            Controls.Add(saveImage);
            Controls.Add(coloredPictureBox);
            Controls.Add(label1);
            Controls.Add(comboColorMap);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "X-Ray Images Project";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)coloredPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox inputImage;
        private System.Windows.Forms.PictureBox coloredPictureBox;
        private System.Windows.Forms.ComboBox comboColorMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveImage;
        private Button btnUndo;
    }
}
