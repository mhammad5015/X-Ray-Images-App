namespace X_Ray_Images_Project
{
    partial class searchForm
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
            textBoxFolderPath = new TextBox();
            buttonBrowse = new Button();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            numericUpDownMinSize = new NumericUpDown();
            numericUpDownMaxSize = new NumericUpDown();
            buttonSearch = new Button();
            listBoxResults = new ListBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxSize).BeginInit();
            SuspendLayout();
            // 
            // textBoxFolderPath
            // 
            textBoxFolderPath.Location = new Point(14, 14);
            textBoxFolderPath.Margin = new Padding(4, 3, 4, 3);
            textBoxFolderPath.Name = "textBoxFolderPath";
            textBoxFolderPath.Size = new Size(349, 23);
            textBoxFolderPath.TabIndex = 10;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(371, 12);
            buttonBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(88, 27);
            buttonBrowse.TabIndex = 0;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(14, 55);
            dateTimePickerStart.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(233, 23);
            dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(254, 55);
            dateTimePickerEnd.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(233, 23);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // numericUpDownMinSize
            // 
            numericUpDownMinSize.Location = new Point(14, 97);
            numericUpDownMinSize.Margin = new Padding(4, 3, 4, 3);
            numericUpDownMinSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownMinSize.Name = "numericUpDownMinSize";
            numericUpDownMinSize.Size = new Size(140, 23);
            numericUpDownMinSize.TabIndex = 4;
            // 
            // numericUpDownMaxSize
            // 
            numericUpDownMaxSize.Location = new Point(161, 97);
            numericUpDownMaxSize.Margin = new Padding(4, 3, 4, 3);
            numericUpDownMaxSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownMaxSize.Name = "numericUpDownMaxSize";
            numericUpDownMaxSize.Size = new Size(140, 23);
            numericUpDownMaxSize.TabIndex = 5;
            numericUpDownMaxSize.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(371, 93);
            buttonSearch.Margin = new Padding(4, 3, 4, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(88, 27);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // listBoxResults
            // 
            listBoxResults.FormattingEnabled = true;
            listBoxResults.ItemHeight = 15;
            listBoxResults.Location = new Point(14, 138);
            listBoxResults.Margin = new Padding(4, 3, 4, 3);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(466, 184);
            listBoxResults.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(316, 101);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "KB";
            // 
            // searchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 337);
            Controls.Add(label1);
            Controls.Add(listBoxResults);
            Controls.Add(buttonSearch);
            Controls.Add(numericUpDownMaxSize);
            Controls.Add(numericUpDownMinSize);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxFolderPath);
            Margin = new Padding(4, 3, 4, 3);
            Name = "searchForm";
            Text = "searchForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownMinSize;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSize;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBoxResults;
        private Label label1;
    }
}