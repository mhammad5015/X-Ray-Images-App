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
            compareBtn = new Button();
            searchBtn = new Button();
            classifyBtn = new Button();
            btnOpenCropForm = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxTransformed = new PictureBox();
            commentTextBox = new TextBox();
            recordButton = new Button();
            stopButton = new Button();
            playButton = new Button();
            createReportButton = new Button();
            label2 = new Label();
            FourierTransformBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coloredPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTransformed).BeginInit();
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
            saveImage.Location = new Point(732, 457);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(123, 29);
            saveImage.TabIndex = 5;
            saveImage.Text = "Save Image";
            saveImage.UseVisualStyleBackColor = true;
            saveImage.Click += saveImage_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(274, 53);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(144, 23);
            btnUndo.TabIndex = 7;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // compareBtn
            // 
            compareBtn.Location = new Point(274, 12);
            compareBtn.Name = "compareBtn";
            compareBtn.Size = new Size(144, 27);
            compareBtn.TabIndex = 8;
            compareBtn.Text = "Compare Images";
            compareBtn.UseVisualStyleBackColor = true;
            compareBtn.Click += compareBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(450, 49);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(144, 27);
            searchBtn.TabIndex = 9;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // classifyBtn
            // 
            classifyBtn.Location = new Point(450, 12);
            classifyBtn.Name = "classifyBtn";
            classifyBtn.Size = new Size(144, 27);
            classifyBtn.TabIndex = 10;
            classifyBtn.Text = "Classify";
            classifyBtn.UseVisualStyleBackColor = true;
            classifyBtn.Click += classifyBtn_Click;
            // 
            // btnOpenCropForm
            // 
            btnOpenCropForm.Location = new Point(636, 12);
            btnOpenCropForm.Name = "btnOpenCropForm";
            btnOpenCropForm.Size = new Size(150, 23);
            btnOpenCropForm.TabIndex = 4;
            btnOpenCropForm.Text = "Open Crop Form";
            btnOpenCropForm.UseVisualStyleBackColor = true;
            btnOpenCropForm.Click += btnOpenCropForm_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(12, 41);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(400, 400);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 5;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxTransformed
            // 
            pictureBoxTransformed.Location = new Point(418, 41);
            pictureBoxTransformed.Name = "pictureBoxTransformed";
            pictureBoxTransformed.Size = new Size(400, 400);
            pictureBoxTransformed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTransformed.TabIndex = 6;
            pictureBoxTransformed.TabStop = false;
            // 
            // commentTextBox
            // 
            commentTextBox.Location = new Point(524, 461);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(190, 23);
            commentTextBox.TabIndex = 1;
            commentTextBox.TextChanged += commentTextBox_TextChanged;
            // 
            // recordButton
            // 
            recordButton.Location = new Point(14, 463);
            recordButton.Name = "recordButton";
            recordButton.Size = new Size(75, 23);
            recordButton.TabIndex = 11;
            recordButton.Text = "Record";
            recordButton.UseVisualStyleBackColor = true;
            recordButton.Click += recordButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(95, 463);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 12;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // playButton
            // 
            playButton.Location = new Point(176, 463);
            playButton.Name = "playButton";
            playButton.Size = new Size(75, 23);
            playButton.TabIndex = 13;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // createReportButton
            // 
            createReportButton.Location = new Point(743, 492);
            createReportButton.Name = "createReportButton";
            createReportButton.Size = new Size(100, 23);
            createReportButton.TabIndex = 15;
            createReportButton.Text = "Create Report";
            createReportButton.UseVisualStyleBackColor = true;
            createReportButton.Click += createReportButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(432, 465);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 16;
            label2.Text = "Add Comment";
            // 
            // FourierTransformBtn
            // 
            FourierTransformBtn.Location = new Point(636, 49);
            FourierTransformBtn.Name = "FourierTransformBtn";
            FourierTransformBtn.Size = new Size(150, 27);
            FourierTransformBtn.TabIndex = 17;
            FourierTransformBtn.Text = "Fourier Transform ";
            FourierTransformBtn.UseVisualStyleBackColor = true;
            FourierTransformBtn.Click += FourierTransformBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 523);
            Controls.Add(FourierTransformBtn);
            Controls.Add(label2);
            Controls.Add(classifyBtn);
            Controls.Add(searchBtn);
            Controls.Add(compareBtn);
            Controls.Add(btnUndo);
            Controls.Add(saveImage);
            Controls.Add(coloredPictureBox);
            Controls.Add(label1);
            Controls.Add(comboColorMap);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Controls.Add(btnOpenCropForm);
            Controls.Add(commentTextBox);
            Controls.Add(recordButton);
            Controls.Add(stopButton);
            Controls.Add(playButton);
            Controls.Add(createReportButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "X-Ray Images Project";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)coloredPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTransformed).EndInit();
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
        private Button compareBtn;
        private Button searchBtn;
        private Button classifyBtn;
        private System.Windows.Forms.Button btnOpenCropForm;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxTransformed;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button undoButton;

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
      

        private System.Windows.Forms.Button createReportButton;
        private Label label2;
        private Button FourierTransformBtn;
    }
}



