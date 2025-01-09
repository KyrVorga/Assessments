namespace AdminClient.Controls
{
    partial class EnumerableFilter
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
            operand = new ComboBox();
            filterValueComboBox = new ComboBox();
            SuspendLayout();
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(2, 0);
            filterLabel.Margin = new Padding(2, 0, 2, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(80, 20);
            filterLabel.TabIndex = 3;
            filterLabel.Text = "filterName";
            // 
            // operand
            // 
            operand.FormattingEnabled = true;
            operand.Location = new Point(2, 23);
            operand.Margin = new Padding(2, 3, 2, 3);
            operand.Name = "operand";
            operand.Size = new Size(85, 28);
            operand.TabIndex = 2;
            // 
            // filterValueComboBox
            // 
            filterValueComboBox.FormattingEnabled = true;
            filterValueComboBox.Location = new Point(92, 23);
            filterValueComboBox.Name = "filterValueComboBox";
            filterValueComboBox.Size = new Size(231, 28);
            filterValueComboBox.TabIndex = 4;
            // 
            // EnumerableFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filterValueComboBox);
            Controls.Add(filterLabel);
            Controls.Add(operand);
            Name = "EnumerableFilter";
            Size = new Size(326, 56);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label filterLabel;
        private ComboBox operand;
        private ComboBox filterValueComboBox;
    }
}
