namespace AdminClient
{
    partial class ManageForm
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
            newEntityButton = new Button();
            modifyEntityButton = new Button();
            deleteEntityButton = new Button();
            applyFiltersbutton = new Button();
            SuspendLayout();
            // 
            // newEntityButton
            // 
            newEntityButton.Location = new Point(15, 564);
            newEntityButton.Name = "newEntityButton";
            newEntityButton.Size = new Size(140, 30);
            newEntityButton.TabIndex = 6;
            newEntityButton.Text = "New";
            newEntityButton.UseVisualStyleBackColor = true;
            newEntityButton.Click += newEntityButton_Click;
            // 
            // modifyEntityButton
            // 
            modifyEntityButton.Location = new Point(171, 564);
            modifyEntityButton.Name = "modifyEntityButton";
            modifyEntityButton.Size = new Size(140, 30);
            modifyEntityButton.TabIndex = 7;
            modifyEntityButton.Text = "Modify";
            modifyEntityButton.UseVisualStyleBackColor = true;
            modifyEntityButton.Click += modifyEntityButton_Click;
            // 
            // deleteEntityButton
            // 
            deleteEntityButton.Location = new Point(330, 564);
            deleteEntityButton.Name = "deleteEntityButton";
            deleteEntityButton.Size = new Size(140, 30);
            deleteEntityButton.TabIndex = 8;
            deleteEntityButton.Text = "Delete";
            deleteEntityButton.UseVisualStyleBackColor = true;
            deleteEntityButton.Click += deleteEntityButton_Click;
            // 
            // applyFiltersbutton
            // 
            applyFiltersbutton.Location = new Point(953, 564);
            applyFiltersbutton.Name = "applyFiltersbutton";
            applyFiltersbutton.Size = new Size(140, 30);
            applyFiltersbutton.TabIndex = 9;
            applyFiltersbutton.Text = "Search";
            applyFiltersbutton.UseVisualStyleBackColor = true;
            applyFiltersbutton.Click += applyFiltersbutton_Click;
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 601);
            Controls.Add(applyFiltersbutton);
            Controls.Add(deleteEntityButton);
            Controls.Add(modifyEntityButton);
            Controls.Add(newEntityButton);
            Name = "ManageForm";
            Text = "ManageForm";
            Controls.SetChildIndex(entitySelector, 0);
            Controls.SetChildIndex(newEntityButton, 0);
            Controls.SetChildIndex(modifyEntityButton, 0);
            Controls.SetChildIndex(deleteEntityButton, 0);
            Controls.SetChildIndex(applyFiltersbutton, 0);
            ResumeLayout(false);
        }

        #endregion

        private Button newEntityButton;
        private Button modifyEntityButton;
        private Button deleteEntityButton;
        private Button applyFiltersbutton;
    }
}