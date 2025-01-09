namespace AdminClient.Controls
{
    partial class DateRangeFilter
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
            TimeFrom = new DateTimePicker();
            TimeUntil = new DateTimePicker();
            joiningLabel = new Label();
            operand = new ComboBox();
            displayLabel = new Label();
            SuspendLayout();
            // 
            // TimeFrom
            // 
            TimeFrom.Format = DateTimePickerFormat.Short;
            TimeFrom.Location = new Point(152, 28);
            TimeFrom.Margin = new Padding(2);
            TimeFrom.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            TimeFrom.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            TimeFrom.Name = "TimeFrom";
            TimeFrom.Size = new Size(124, 27);
            TimeFrom.TabIndex = 0;
            // 
            // TimeUntil
            // 
            TimeUntil.Format = DateTimePickerFormat.Short;
            TimeUntil.Location = new Point(307, 28);
            TimeUntil.Margin = new Padding(2);
            TimeUntil.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            TimeUntil.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            TimeUntil.Name = "TimeUntil";
            TimeUntil.Size = new Size(124, 27);
            TimeUntil.TabIndex = 1;
            // 
            // joiningLabel
            // 
            joiningLabel.AutoSize = true;
            joiningLabel.Location = new Point(280, 33);
            joiningLabel.Margin = new Padding(2, 0, 2, 0);
            joiningLabel.Name = "joiningLabel";
            joiningLabel.Size = new Size(23, 20);
            joiningLabel.TabIndex = 2;
            joiningLabel.Text = "to";
            // 
            // operand
            // 
            operand.FormattingEnabled = true;
            operand.Location = new Point(2, 28);
            operand.Margin = new Padding(2, 3, 2, 3);
            operand.Name = "operand";
            operand.Size = new Size(146, 28);
            operand.TabIndex = 4;
            operand.Text = "Within Range";
            operand.SelectedIndexChanged += operand_SelectedIndexChanged;
            // 
            // displayLabel
            // 
            displayLabel.AutoSize = true;
            displayLabel.Location = new Point(3, 5);
            displayLabel.Name = "displayLabel";
            displayLabel.Size = new Size(92, 20);
            displayLabel.TabIndex = 5;
            displayLabel.Text = "displayLabel";
            // 
            // DateRangeFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(displayLabel);
            Controls.Add(operand);
            Controls.Add(joiningLabel);
            Controls.Add(TimeUntil);
            Controls.Add(TimeFrom);
            Margin = new Padding(2);
            Name = "DateRangeFilter";
            Size = new Size(468, 59);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker TimeFrom;
        private DateTimePicker TimeUntil;
        private Label joiningLabel;
        private ComboBox operand;
        private Label displayLabel;
    }
}
