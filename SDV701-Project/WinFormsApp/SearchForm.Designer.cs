namespace AdminClient
{
    partial class SearchForm
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
            confirmButton = new Button();
            cancelButton = new Button();
            newButton = new Button();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(12, 563);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(172, 29);
            confirmButton.TabIndex = 6;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(410, 564);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(172, 29);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // newButton
            // 
            newButton.Location = new Point(210, 563);
            newButton.Name = "newButton";
            newButton.Size = new Size(172, 29);
            newButton.TabIndex = 9;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 604);
            Controls.Add(newButton);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Name = "SearchForm";
            Text = "SearchForm";
            Controls.SetChildIndex(entitySelector, 0);
            Controls.SetChildIndex(confirmButton, 0);
            Controls.SetChildIndex(cancelButton, 0);
            Controls.SetChildIndex(newButton, 0);
            ResumeLayout(false);
        }

        #endregion

        private Button confirmButton;
        private Button cancelButton;
        private Button newButton;
    }
}