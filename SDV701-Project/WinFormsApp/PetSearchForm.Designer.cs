namespace AdminClient
{
    partial class PetSearchForm
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
            addNewTypeCombo = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(203, 15);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 10;
            label1.Text = "New Pet Type:";
            // 
            // addNewTypeCombo
            // 
            addNewTypeCombo.FormattingEnabled = true;
            addNewTypeCombo.Location = new Point(310, 12);
            addNewTypeCombo.Name = "addNewTypeCombo";
            addNewTypeCombo.Size = new Size(151, 28);
            addNewTypeCombo.TabIndex = 11;
            // 
            // PetSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1249, 600);
            Controls.Add(addNewTypeCombo);
            Controls.Add(label1);
            Name = "PetSearchForm";
            Text = "PetSearchForm";
            Controls.SetChildIndex(entitySelector, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(addNewTypeCombo, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox addNewTypeCombo;
    }
}