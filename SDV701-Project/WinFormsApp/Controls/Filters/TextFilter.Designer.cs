namespace AdminClient.Controls
{
    partial class TextFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filterLabel = new Label();
            filterValue = new TextBox();
            operand = new ComboBox();
            SuspendLayout();
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(2, 0);
            filterLabel.Margin = new Padding(2, 0, 2, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(50, 20);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "label1";
            // 
            // filterValue
            // 
            filterValue.Location = new Point(156, 22);
            filterValue.Margin = new Padding(2);
            filterValue.Name = "filterValue";
            filterValue.Size = new Size(200, 27);
            filterValue.TabIndex = 1;
            // 
            // operand
            // 
            operand.FormattingEnabled = true;
            operand.Location = new Point(2, 21);
            operand.Margin = new Padding(2, 3, 2, 3);
            operand.Name = "operand";
            operand.Size = new Size(150, 28);
            operand.TabIndex = 2;
            // 
            // TextFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(operand);
            Controls.Add(filterValue);
            Controls.Add(filterLabel);
            Margin = new Padding(2);
            Name = "TextFilter";
            Size = new Size(358, 52);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label filterLabel;
        private TextBox filterValue;
        private ComboBox operand;
    }
}
