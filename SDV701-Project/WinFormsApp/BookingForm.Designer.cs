namespace AdminClient
{
    partial class BookingForm
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
            clientSearchButton = new Button();
            label1 = new Label();
            clientTextBox = new TextBox();
            petTextBox = new TextBox();
            label2 = new Label();
            petSearchButton = new Button();
            roomTextBox = new TextBox();
            label3 = new Label();
            roomSearchButton = new Button();
            cancelButton = new Button();
            saveButton = new Button();
            notesTextBox = new RichTextBox();
            label6 = new Label();
            label4 = new Label();
            checkInDateTime = new DateTimePicker();
            checkOutDateTime = new DateTimePicker();
            label5 = new Label();
            SuspendLayout();
            // 
            // clientSearchButton
            // 
            clientSearchButton.Location = new Point(198, 35);
            clientSearchButton.Name = "clientSearchButton";
            clientSearchButton.Size = new Size(94, 29);
            clientSearchButton.TabIndex = 0;
            clientSearchButton.Text = "Search";
            clientSearchButton.UseVisualStyleBackColor = true;
            clientSearchButton.Click += clientSearchButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 1;
            label1.Text = "Client";
            // 
            // clientTextBox
            // 
            clientTextBox.Location = new Point(12, 35);
            clientTextBox.Name = "clientTextBox";
            clientTextBox.Size = new Size(180, 27);
            clientTextBox.TabIndex = 2;
            // 
            // petTextBox
            // 
            petTextBox.Location = new Point(12, 104);
            petTextBox.Name = "petTextBox";
            petTextBox.Size = new Size(180, 27);
            petTextBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 4;
            label2.Text = "Pet";
            // 
            // petSearchButton
            // 
            petSearchButton.Location = new Point(198, 104);
            petSearchButton.Name = "petSearchButton";
            petSearchButton.Size = new Size(94, 29);
            petSearchButton.TabIndex = 3;
            petSearchButton.Text = "Search";
            petSearchButton.UseVisualStyleBackColor = true;
            petSearchButton.Click += petSearchButton_Click;
            // 
            // roomTextBox
            // 
            roomTextBox.Location = new Point(12, 179);
            roomTextBox.Name = "roomTextBox";
            roomTextBox.Size = new Size(180, 27);
            roomTextBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 156);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 7;
            label3.Text = "Room";
            // 
            // roomSearchButton
            // 
            roomSearchButton.Location = new Point(198, 179);
            roomSearchButton.Name = "roomSearchButton";
            roomSearchButton.Size = new Size(94, 29);
            roomSearchButton.TabIndex = 6;
            roomSearchButton.Text = "Search";
            roomSearchButton.UseVisualStyleBackColor = true;
            roomSearchButton.Click += roomSearchButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(161, 526);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 39;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(12, 526);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 38;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(12, 394);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 37;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 371);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 36;
            label6.Text = "Notes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 228);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 40;
            label4.Text = "Check In";
            // 
            // checkInDateTime
            // 
            checkInDateTime.CustomFormat = "dddd dd/MM/yyyy hh:mm tt";
            checkInDateTime.Format = DateTimePickerFormat.Custom;
            checkInDateTime.Location = new Point(12, 251);
            checkInDateTime.Name = "checkInDateTime";
            checkInDateTime.Size = new Size(280, 27);
            checkInDateTime.TabIndex = 41;
            // 
            // checkOutDateTime
            // 
            checkOutDateTime.CustomFormat = "dddd dd/MM/yyyy hh:mm tt";
            checkOutDateTime.Format = DateTimePickerFormat.Custom;
            checkOutDateTime.Location = new Point(12, 325);
            checkOutDateTime.Name = "checkOutDateTime";
            checkOutDateTime.Size = new Size(280, 27);
            checkOutDateTime.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 302);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 42;
            label5.Text = "Check Out";
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 577);
            Controls.Add(checkOutDateTime);
            Controls.Add(label5);
            Controls.Add(checkInDateTime);
            Controls.Add(label4);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(roomTextBox);
            Controls.Add(label3);
            Controls.Add(roomSearchButton);
            Controls.Add(petTextBox);
            Controls.Add(label2);
            Controls.Add(petSearchButton);
            Controls.Add(clientTextBox);
            Controls.Add(label1);
            Controls.Add(clientSearchButton);
            Name = "BookingForm";
            Text = "BookingForm";
            Load += BookingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientSearchButton;
        private Label label1;
        private TextBox clientTextBox;
        private TextBox petTextBox;
        private Label label2;
        private Button petSearchButton;
        private TextBox roomTextBox;
        private Label label3;
        private Button roomSearchButton;
        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private Label label4;
        private DateTimePicker checkInDateTime;
        private DateTimePicker checkOutDateTime;
        private Label label5;
    }
}