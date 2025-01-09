namespace AdminClient
{
    partial class TraitForm
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
            nameTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(161, 226);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 35;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(12, 226);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(12, 98);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 33;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 75);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 32;
            label6.Text = "Description";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 31);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(280, 27);
            nameTextBox.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 22;
            label1.Text = "Name";
            // 
            // TraitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 286);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "TraitForm";
            Text = "TraitForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private TextBox nameTextBox;
        private Label label1;
    }
}