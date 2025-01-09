namespace AdminClient
{
    partial class ScheduleForm
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
            cancelButton = new Button();
            saveButton = new Button();
            notesTextBox = new RichTextBox();
            label6 = new Label();
            frequencyComboBox = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            repetitionComboBox = new ComboBox();
            label3 = new Label();
            timePicker = new DateTimePicker();
            frequencyPanel = new FlowLayoutPanel();
            repetitionPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(415, 376);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 35;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(77, 376);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(12, 233);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 33;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 210);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 32;
            label6.Text = "Notes";
            // 
            // frequencyComboBox
            // 
            frequencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            frequencyComboBox.FormattingEnabled = true;
            frequencyComboBox.Location = new Point(12, 34);
            frequencyComboBox.Name = "frequencyComboBox";
            frequencyComboBox.Size = new Size(151, 28);
            frequencyComboBox.TabIndex = 31;
            frequencyComboBox.SelectedIndexChanged += frequencyComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 11);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 29;
            label5.Text = "Frequency";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 141);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 24;
            label2.Text = "Time";
            // 
            // repetitionComboBox
            // 
            repetitionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            repetitionComboBox.FormattingEnabled = true;
            repetitionComboBox.Location = new Point(12, 97);
            repetitionComboBox.Name = "repetitionComboBox";
            repetitionComboBox.Size = new Size(151, 28);
            repetitionComboBox.TabIndex = 38;
            repetitionComboBox.SelectedIndexChanged += repetitionComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 37;
            label3.Text = "Repetition";
            // 
            // timePicker
            // 
            timePicker.CustomFormat = "hh:mm tt";
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.Location = new Point(12, 164);
            timePicker.Name = "timePicker";
            timePicker.ShowUpDown = true;
            timePicker.Size = new Size(150, 27);
            timePicker.TabIndex = 40;
            // 
            // frequencyPanel
            // 
            frequencyPanel.FlowDirection = FlowDirection.TopDown;
            frequencyPanel.Location = new Point(327, 12);
            frequencyPanel.Name = "frequencyPanel";
            frequencyPanel.Size = new Size(311, 218);
            frequencyPanel.TabIndex = 42;
            // 
            // repetitionPanel
            // 
            repetitionPanel.Location = new Point(327, 236);
            repetitionPanel.Name = "repetitionPanel";
            repetitionPanel.Size = new Size(311, 109);
            repetitionPanel.TabIndex = 43;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 421);
            Controls.Add(repetitionPanel);
            Controls.Add(frequencyPanel);
            Controls.Add(timePicker);
            Controls.Add(repetitionComboBox);
            Controls.Add(label3);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(frequencyComboBox);
            Controls.Add(label5);
            Controls.Add(label2);
            Name = "ScheduleForm";
            Text = "ScheduleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private ComboBox frequencyComboBox;
        private Label label5;
        private Label label2;
        private ComboBox repetitionComboBox;
        private Label label3;
        private DateTimePicker timePicker;
        private FlowLayoutPanel frequencyPanel;
        private FlowLayoutPanel repetitionPanel;
    }
}