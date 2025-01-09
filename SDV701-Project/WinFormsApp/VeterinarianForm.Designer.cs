namespace AdminClient
{
    partial class VeterinarianForm
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
            contactTextBox = new TextBox();
            label2 = new Label();
            businessTextBox = new TextBox();
            label1 = new Label();
            addressTextBox = new RichTextBox();
            label7 = new Label();
            emailTextBox = new TextBox();
            label8 = new Label();
            phoneTextBox = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(388, 466);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 35;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(70, 466);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(323, 169);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 33;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(323, 146);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 32;
            label6.Text = "Notes";
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(12, 100);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(280, 27);
            contactTextBox.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 24;
            label2.Text = "Contact Person";
            // 
            // businessTextBox
            // 
            businessTextBox.Location = new Point(12, 37);
            businessTextBox.Name = "businessTextBox";
            businessTextBox.Size = new Size(280, 27);
            businessTextBox.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 22;
            label1.Text = "Business";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(12, 169);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(280, 112);
            addressTextBox.TabIndex = 41;
            addressTextBox.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 146);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 40;
            label7.Text = "Address";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(323, 100);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(280, 27);
            emailTextBox.TabIndex = 39;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(323, 77);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 38;
            label8.Text = "Email";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(323, 37);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(280, 27);
            phoneTextBox.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(323, 14);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 36;
            label9.Text = "Phone";
            // 
            // VeterinarianForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 515);
            Controls.Add(addressTextBox);
            Controls.Add(label7);
            Controls.Add(emailTextBox);
            Controls.Add(label8);
            Controls.Add(phoneTextBox);
            Controls.Add(label9);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(contactTextBox);
            Controls.Add(label2);
            Controls.Add(businessTextBox);
            Controls.Add(label1);
            Name = "VeterinarianForm";
            Text = "VeterinarianForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private TextBox contactTextBox;
        private Label label2;
        private TextBox businessTextBox;
        private Label label1;
        private RichTextBox addressTextBox;
        private Label label7;
        private TextBox emailTextBox;
        private Label label8;
        private TextBox phoneTextBox;
        private Label label9;
    }
}