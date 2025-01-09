namespace AdminClient
{
    partial class RoomForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            roomNumeric = new NumericUpDown();
            sizeComboBox = new ComboBox();
            qualityComboBox = new ComboBox();
            notesTextBox = new RichTextBox();
            cancelButton = new Button();
            saveButton = new Button();
            statusComboBox = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)roomNumeric).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Room Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 74);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 1;
            label2.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 2;
            label3.Text = "Quality";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 280);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 3;
            label4.Text = "Notes";
            // 
            // roomNumeric
            // 
            roomNumeric.Location = new Point(12, 32);
            roomNumeric.Name = "roomNumeric";
            roomNumeric.Size = new Size(73, 27);
            roomNumeric.TabIndex = 1;
            // 
            // sizeComboBox
            // 
            sizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sizeComboBox.FormattingEnabled = true;
            sizeComboBox.Location = new Point(13, 97);
            sizeComboBox.Name = "sizeComboBox";
            sizeComboBox.Size = new Size(280, 28);
            sizeComboBox.TabIndex = 2;
            // 
            // qualityComboBox
            // 
            qualityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityComboBox.FormattingEnabled = true;
            qualityComboBox.Location = new Point(12, 162);
            qualityComboBox.Name = "qualityComboBox";
            qualityComboBox.Size = new Size(280, 28);
            qualityComboBox.TabIndex = 3;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(13, 303);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 4;
            notesTextBox.Text = "";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(162, 459);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(13, 459);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(12, 232);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(280, 28);
            statusComboBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 209);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 7;
            label5.Text = "Status";
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 511);
            Controls.Add(statusComboBox);
            Controls.Add(label5);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(qualityComboBox);
            Controls.Add(sizeComboBox);
            Controls.Add(roomNumeric);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RoomForm";
            Text = "RoomForm";
            ((System.ComponentModel.ISupportInitialize)roomNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown roomNumeric;
        private ComboBox sizeComboBox;
        private ComboBox qualityComboBox;
        private RichTextBox notesTextBox;
        private Button cancelButton;
        private Button saveButton;
        private ComboBox statusComboBox;
        private Label label5;
    }
}