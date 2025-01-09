namespace AdminClient
{
    partial class BirdForm
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
            sexComboBox = new ComboBox();
            birthYearNumeric = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            colourTextBox = new TextBox();
            speciesTextBox = new TextBox();
            label2 = new Label();
            nameTextBox = new TextBox();
            label1 = new Label();
            petsPanel = new Panel();
            veterinarianCollectionConcreteControl1 = new Controls.Collections.VeterinarianCollectionConcreteControl();
            clientCollectionConcreteControl1 = new Controls.Collections.ClientCollectionConcreteControl();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)birthYearNumeric).BeginInit();
            petsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(418, 478);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 35;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(79, 478);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(12, 350);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 33;
            notesTextBox.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 327);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 32;
            label6.Text = "Notes";
            // 
            // sexComboBox
            // 
            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sexComboBox.FormattingEnabled = true;
            sexComboBox.Location = new Point(12, 285);
            sexComboBox.Name = "sexComboBox";
            sexComboBox.Size = new Size(151, 28);
            sexComboBox.TabIndex = 31;
            // 
            // birthYearNumeric
            // 
            birthYearNumeric.Location = new Point(12, 219);
            birthYearNumeric.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            birthYearNumeric.Minimum = new decimal(new int[] { 1990, 0, 0, 0 });
            birthYearNumeric.Name = "birthYearNumeric";
            birthYearNumeric.Size = new Size(150, 27);
            birthYearNumeric.TabIndex = 30;
            birthYearNumeric.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 262);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 29;
            label5.Text = "Sex";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 196);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 28;
            label4.Text = "Year of Birth";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 27;
            label3.Text = "Colour";
            // 
            // colourTextBox
            // 
            colourTextBox.Location = new Point(12, 154);
            colourTextBox.Name = "colourTextBox";
            colourTextBox.Size = new Size(280, 27);
            colourTextBox.TabIndex = 26;
            // 
            // speciesTextBox
            // 
            speciesTextBox.Location = new Point(12, 92);
            speciesTextBox.Name = "speciesTextBox";
            speciesTextBox.Size = new Size(280, 27);
            speciesTextBox.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 24;
            label2.Text = "Species";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 29);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(280, 27);
            nameTextBox.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 22;
            label1.Text = "Name";
            // 
            // petsPanel
            // 
            petsPanel.Controls.Add(veterinarianCollectionConcreteControl1);
            petsPanel.Controls.Add(clientCollectionConcreteControl1);
            petsPanel.Location = new Point(343, 28);
            petsPanel.Name = "petsPanel";
            petsPanel.Size = new Size(280, 444);
            petsPanel.TabIndex = 37;
            // 
            // veterinarianCollectionConcreteControl1
            // 
            veterinarianCollectionConcreteControl1.Location = new Point(13, 220);
            veterinarianCollectionConcreteControl1.Name = "veterinarianCollectionConcreteControl1";
            veterinarianCollectionConcreteControl1.Size = new Size(255, 221);
            veterinarianCollectionConcreteControl1.TabIndex = 1;
            // 
            // clientCollectionConcreteControl1
            // 
            clientCollectionConcreteControl1.Location = new Point(13, 0);
            clientCollectionConcreteControl1.Name = "clientCollectionConcreteControl1";
            clientCollectionConcreteControl1.Size = new Size(254, 282);
            clientCollectionConcreteControl1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(343, 5);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 36;
            label7.Text = "Owners";
            // 
            // BirdForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 535);
            Controls.Add(petsPanel);
            Controls.Add(label7);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label6);
            Controls.Add(sexComboBox);
            Controls.Add(birthYearNumeric);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(colourTextBox);
            Controls.Add(speciesTextBox);
            Controls.Add(label2);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "BirdForm";
            Text = "BirdForm";
            Load += BirdForm_Load;
            ((System.ComponentModel.ISupportInitialize)birthYearNumeric).EndInit();
            petsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private RichTextBox notesTextBox;
        private Label label6;
        private ComboBox sexComboBox;
        private NumericUpDown birthYearNumeric;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox colourTextBox;
        private TextBox speciesTextBox;
        private Label label2;
        private TextBox nameTextBox;
        private Label label1;
        private Panel petsPanel;
        private Controls.Collections.VeterinarianCollectionConcreteControl veterinarianCollectionConcreteControl1;
        private Controls.Collections.ClientCollectionConcreteControl clientCollectionConcreteControl1;
        private Label label7;
    }
}