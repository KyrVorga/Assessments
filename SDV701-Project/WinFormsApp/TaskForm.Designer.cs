namespace AdminClient
{
    partial class TaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            cancelButton = new Button();
            saveButton = new Button();
            notesTextBox = new RichTextBox();
            label6 = new Label();
            typeComboBox = new ComboBox();
            quantityNumeric = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            nameTextBox = new TextBox();
            label1 = new Label();
            measurementComboBox = new ComboBox();
            label8 = new Label();
            scheduleCollectionControl1 = new Controls.Collections.ScheduleCollectionControl();
            ((System.ComponentModel.ISupportInitialize)quantityNumeric).BeginInit();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(421, 424);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 35;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(87, 424);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(12, 292);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 33;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 269);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 32;
            label6.Text = "Notes";
            // 
            // typeComboBox
            // 
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(12, 100);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(151, 28);
            typeComboBox.TabIndex = 31;
            // 
            // quantityNumeric
            // 
            quantityNumeric.Location = new Point(12, 227);
            quantityNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            quantityNumeric.Name = "quantityNumeric";
            quantityNumeric.Size = new Size(150, 27);
            quantityNumeric.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 77);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 29;
            label5.Text = "Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 204);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 28;
            label4.Text = "Quantity";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 38);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(280, 27);
            nameTextBox.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 22;
            label1.Text = "Name";
            // 
            // measurementComboBox
            // 
            measurementComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            measurementComboBox.FormattingEnabled = true;
            measurementComboBox.Location = new Point(12, 161);
            measurementComboBox.Name = "measurementComboBox";
            measurementComboBox.Size = new Size(151, 28);
            measurementComboBox.TabIndex = 39;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 138);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 38;
            label8.Text = "Measurement";
            // 
            // scheduleCollectionControl1
            // 
            scheduleCollectionControl1.Location = new Point(361, 77);
            scheduleCollectionControl1.Name = "scheduleCollectionControl1";
            scheduleCollectionControl1.Size = new Size(259, 222);
            scheduleCollectionControl1.TabIndex = 0;
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 486);
            Controls.Add(scheduleCollectionControl1);
            Controls.Add(measurementComboBox);
            Controls.Add(label8);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(typeComboBox);
            Controls.Add(quantityNumeric);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "TaskForm";
            Text = "TaskForm";
            Load += TaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)quantityNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private ComboBox typeComboBox;
        private NumericUpDown quantityNumeric;
        private Label label5;
        private Label label4;
        private TextBox nameTextBox;
        private Label label1;
        private ComboBox measurementComboBox;
        private Label label8;
        private Controls.Collections.ScheduleCollectionControl scheduleCollectionControl1;
    }
}