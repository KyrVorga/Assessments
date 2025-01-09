namespace AdminClient.Controls
{
    partial class NumericFilter
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
            operand = new ComboBox();
            filterLabel = new Label();
            filterValue = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)filterValue).BeginInit();
            SuspendLayout();
            // 
            // operand
            // 
            operand.FormattingEnabled = true;
            operand.Location = new Point(2, 23);
            operand.Margin = new Padding(2, 3, 2, 3);
            operand.Name = "operand";
            operand.Size = new Size(85, 28);
            operand.TabIndex = 0;
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(2, 0);
            filterLabel.Margin = new Padding(2, 0, 2, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(80, 20);
            filterLabel.TabIndex = 1;
            filterLabel.Text = "filterName";
            // 
            // filterValue
            // 
            filterValue.Location = new Point(91, 23);
            filterValue.Margin = new Padding(2, 3, 2, 3);
            filterValue.Name = "filterValue";
            filterValue.Size = new Size(144, 27);
            filterValue.TabIndex = 2;
            // 
            // NumericFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filterValue);
            Controls.Add(filterLabel);
            Controls.Add(operand);
            Margin = new Padding(2, 3, 2, 3);
            Name = "NumericFilter";
            Size = new Size(241, 52);
            ((System.ComponentModel.ISupportInitialize)filterValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox operand;
        private Label filterLabel;
        private NumericUpDown filterValue;
    }
}
