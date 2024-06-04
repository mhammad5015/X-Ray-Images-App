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
            compressSaveButton = new Button();
            btnUndo = new Button();
            compareBtn = new Button();
            searchBtn = new Button();
            classifyBtn = new Button();
            btnOpenCropForm = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxTransformed = new PictureBox();
            commentTextBox = new TextBox();
            openRecordFormButton = new Button();
            createReportButton = new Button();
            saveReportButton = new Button();
            compressAndSaveButton = new Button();
            label2 = new Label();
            FourierTransformBtn = new Button();
            buttonOpenShareForm = new Button();
            label3 = new Label();
            comboSelectShape = new ComboBox();
            ageTextBox = new TextBox();
            ageLabel = new Label();
            genderLabel = new Label();
            genderComboBox = new ComboBox();
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
            button1.Size = new Size(294, 27);
            button1.TabIndex = 0;
            button1.Text = "Open Radiograph";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // inputImage
            // 
            inputImage.BorderStyle = BorderStyle.Fixed3D;
            inputImage.Location = new Point(32, 94);
            inputImage.Margin = new Padding(4, 3, 4, 3);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(446, 389);
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
            coloredPictureBox.Location = new Point(511, 94);
            coloredPictureBox.Margin = new Padding(4, 3, 4, 3);
            coloredPictureBox.Name = "coloredPictureBox";
            coloredPictureBox.Size = new Size(446, 389);
            coloredPictureBox.TabIndex = 6;
            coloredPictureBox.TabStop = false;
            // 
            // comboColorMap
            // 
            comboColorMap.DropDownStyle = ComboBoxStyle.DropDownList;
            comboColorMap.FormattingEnabled = true;
            comboColorMap.Items.AddRange(new object[] { "Hot", "Cool", "Jet" });
            comboColorMap.Location = new Point(363, 53);
            comboColorMap.SelectedIndex = 0;
            comboColorMap.Name = "comboColorMap";
            comboColorMap.Size = new Size(115, 23);
            comboColorMap.TabIndex = 3;
            comboColorMap.SelectedIndexChanged += comboColorMap_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 56);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 4;
            label1.Text = "Select ColorMap";
            // 
            // saveImage
            // 
            saveImage.Location = new Point(834, 499);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(123, 29);
            saveImage.TabIndex = 5;
            saveImage.Text = "Save Image";
            saveImage.UseVisualStyleBackColor = true;
            saveImage.Click += saveImage_Click;
            // 
            // compressSaveButton
            // 
            compressSaveButton.Location = new Point(787, 536);
            compressSaveButton.Name = "compressSaveButton";
            compressSaveButton.Size = new Size(170, 29);
            compressSaveButton.TabIndex = 3;
            compressSaveButton.Text = "Compress and Save Image";
            compressSaveButton.UseVisualStyleBackColor = true;
            compressSaveButton.Click += compressSaveButton_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(363, 12);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(115, 27);
            btnUndo.TabIndex = 7;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // compareBtn
            // 
            compareBtn.Location = new Point(507, 12);
            compareBtn.Name = "compareBtn";
            compareBtn.Size = new Size(144, 27);
            compareBtn.TabIndex = 8;
            compareBtn.Text = "Compare Images";
            compareBtn.UseVisualStyleBackColor = true;
            compareBtn.Click += compareBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(657, 50);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(144, 27);
            searchBtn.TabIndex = 9;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // classifyBtn
            // 
            classifyBtn.Location = new Point(657, 12);
            classifyBtn.Name = "classifyBtn";
            classifyBtn.Size = new Size(144, 27);
            classifyBtn.TabIndex = 10;
            classifyBtn.Text = "Classify";
            classifyBtn.UseVisualStyleBackColor = true;
            classifyBtn.Click += classifyBtn_Click;
            // 
            // btnOpenCropForm
            // 
            btnOpenCropForm.Location = new Point(807, 12);
            btnOpenCropForm.Name = "btnOpenCropForm";
            btnOpenCropForm.Size = new Size(150, 27);
            btnOpenCropForm.TabIndex = 4;
            btnOpenCropForm.Text = "Crop Image";
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
            commentTextBox.Location = new Point(619, 502);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(190, 23);
            commentTextBox.TabIndex = 1;
            commentTextBox.TextChanged += commentTextBox_TextChanged;
            // 
            // openRecordFormButton
            // 
            openRecordFormButton.Location = new Point(507, 50);
            openRecordFormButton.Name = "openRecordFormButton";
            openRecordFormButton.Size = new Size(144, 27);
            openRecordFormButton.TabIndex = 5;
            openRecordFormButton.Text = "Voice Recorder";
            openRecordFormButton.UseVisualStyleBackColor = true;
            openRecordFormButton.Click += openRecordFormButton_Click;
            // 
            // createReportButton
            // 
            createReportButton.Location = new Point(32, 538);
            createReportButton.Name = "createReportButton";
            createReportButton.Size = new Size(127, 27);
            createReportButton.TabIndex = 15;
            createReportButton.Text = "Create Report";
            createReportButton.UseVisualStyleBackColor = true;
            createReportButton.Click += createReportButton_Click;
            // 
            // saveReportButton
            // 
            saveReportButton.Location = new Point(169, 538);
            saveReportButton.Name = "saveReportButton";
            saveReportButton.Size = new Size(129, 27);
            saveReportButton.TabIndex = 1;
            saveReportButton.Text = "Save Report";
            saveReportButton.UseVisualStyleBackColor = true;
            saveReportButton.Click += saveReportButton_Click;
            // 
            // compressAndSaveButton
            // 
            compressAndSaveButton.Location = new Point(308, 538);
            compressAndSaveButton.Name = "compressAndSaveButton";
            compressAndSaveButton.Size = new Size(170, 27);
            compressAndSaveButton.TabIndex = 2;
            compressAndSaveButton.Text = "Compress and Save Report ";
            compressAndSaveButton.UseVisualStyleBackColor = true;
            compressAndSaveButton.Click += compressAndSaveButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(527, 505);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 16;
            label2.Text = "Add Comment";
            // 
            // FourierTransformBtn
            // 
            FourierTransformBtn.Location = new Point(807, 50);
            FourierTransformBtn.Name = "FourierTransformBtn";
            FourierTransformBtn.Size = new Size(150, 27);
            FourierTransformBtn.TabIndex = 17;
            FourierTransformBtn.Text = "Fourier Transform ";
            FourierTransformBtn.UseVisualStyleBackColor = true;
            FourierTransformBtn.Click += FourierTransformBtn_Click;
            // 
            // buttonOpenShareForm
            // 
            buttonOpenShareForm.Location = new Point(619, 538);
            buttonOpenShareForm.Name = "buttonOpenShareForm";
            buttonOpenShareForm.Size = new Size(150, 27);
            buttonOpenShareForm.TabIndex = 1;
            buttonOpenShareForm.Text = "Open Share Form";
            buttonOpenShareForm.UseVisualStyleBackColor = true;
            buttonOpenShareForm.Click += buttonOpenShareForm_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 56);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 18;
            label3.Text = "Select Shape";
            // 
            // comboSelectShape
            // 
            comboSelectShape.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSelectShape.FormattingEnabled = true;
            comboSelectShape.Items.AddRange(new object[] { "Rectangle", "Triangle", "Circle" });
            comboSelectShape.Location = new Point(109, 53);
            comboSelectShape.Name = "comboSelectShape";
            comboSelectShape.SelectedIndex = 0;
            comboSelectShape.Size = new Size(121, 23);
            comboSelectShape.TabIndex = 19;
            comboSelectShape.SelectedIndexChanged += comboSelectShape_SelectedIndexChanged;
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(356, 503);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.Size = new Size(100, 23);
            ageTextBox.TabIndex = 0;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(322, 506);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(28, 15);
            ageLabel.TabIndex = 1;
            ageLabel.Text = "Age";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(30, 508);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(45, 15);
            genderLabel.TabIndex = 1;
            genderLabel.Text = "Gender";
            // 
            // genderComboBox
            // 
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female" });
            genderComboBox.Location = new Point(80, 503);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(150, 23);
            genderComboBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 592);
            Controls.Add(comboSelectShape);
            Controls.Add(label3);
            Controls.Add(FourierTransformBtn);
            Controls.Add(label2);
            Controls.Add(classifyBtn);
            Controls.Add(searchBtn);
            Controls.Add(compareBtn);
            Controls.Add(btnUndo);
            Controls.Add(saveImage);
            Controls.Add(compressSaveButton);
            Controls.Add(coloredPictureBox);
            Controls.Add(label1);
            Controls.Add(comboColorMap);
            Controls.Add(inputImage);
            Controls.Add(button1);
            Controls.Add(btnOpenCropForm);
            Controls.Add(commentTextBox);
            Controls.Add(openRecordFormButton);
            Controls.Add(createReportButton);
            Controls.Add(ageTextBox);
            Controls.Add(ageLabel);
            Controls.Add(genderLabel);
            Controls.Add(genderComboBox);
            Controls.Add(compressAndSaveButton);
            Controls.Add(saveReportButton);
            Controls.Add(buttonOpenShareForm);
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
        private System.Windows.Forms.Button compressSaveButton;

        private Button btnUndo;
        private Button compareBtn;
        private Button searchBtn;
        private Button classifyBtn;
        private System.Windows.Forms.Button btnOpenCropForm;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxTransformed;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button undoButton;

        private System.Windows.Forms.Button openRecordFormButton;

        private System.Windows.Forms.Button createReportButton;
        private System.Windows.Forms.Button saveReportButton;
        private System.Windows.Forms.Button compressAndSaveButton;
        private Label label2;
        private Button FourierTransformBtn;
    
        private System.Windows.Forms.Button buttonOpenShareForm;
        private Label label3;
        private ComboBox comboSelectShape;

        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Label genderLabel;


    }
}



