namespace AdminClient.Controls
{
    partial class FiltersPanel
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
            label1 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(2, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 32);
            label1.TabIndex = 13;
            label1.Text = "Filters";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(2, 36);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 500);
            panel1.TabIndex = 12;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(422, 6);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(30, 27);
            button1.TabIndex = 11;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(230, 5);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 28);
            comboBox1.TabIndex = 10;
            // 
            // FiltersPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "FiltersPanel";
            Size = new Size(456, 540);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
    }
}
