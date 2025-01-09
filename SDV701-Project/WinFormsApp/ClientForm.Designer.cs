namespace AdminClient
{
    partial class ClientForm
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
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            label2 = new Label();
            emailTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            addressTextBox = new RichTextBox();
            notesTextBox = new RichTextBox();
            label5 = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            petsPanel = new Panel();
            catCollectionConcreteControl = new Controls.Collections.CatCollectionConcreteControl();
            label6 = new Label();
            birdCollectionConcreteControl1 = new Controls.Collections.BirdCollectionConcreteControl();
            petsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 11);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(13, 34);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(280, 27);
            nameTextBox.TabIndex = 1;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(13, 97);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(280, 27);
            phoneTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 74);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "Phone";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(13, 160);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(280, 27);
            emailTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 137);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 197);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 6;
            label4.Text = "Address";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(13, 220);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(280, 112);
            addressTextBox.TabIndex = 7;
            addressTextBox.Text = "";
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(13, 366);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(280, 112);
            notesTextBox.TabIndex = 9;
            notesTextBox.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 343);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 8;
            label5.Text = "Notes";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(80, 494);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 38);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(419, 494);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(131, 38);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // petsPanel
            // 
            petsPanel.Controls.Add(birdCollectionConcreteControl1);
            petsPanel.Controls.Add(catCollectionConcreteControl);
            petsPanel.Location = new Point(348, 34);
            petsPanel.Name = "petsPanel";
            petsPanel.Size = new Size(280, 444);
            petsPanel.TabIndex = 14;
            // 
            // catCollectionConcreteControl
            // 
            catCollectionConcreteControl.Location = new Point(12, 0);
            catCollectionConcreteControl.Name = "catCollectionConcreteControl";
            catCollectionConcreteControl.Size = new Size(256, 222);
            catCollectionConcreteControl.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(348, 11);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 12;
            label6.Text = "Pets";
            // 
            // birdCollectionConcreteControl1
            // 
            birdCollectionConcreteControl1.Location = new Point(12, 216);
            birdCollectionConcreteControl1.Name = "birdCollectionConcreteControl1";
            birdCollectionConcreteControl1.Size = new Size(256, 225);
            birdCollectionConcreteControl1.TabIndex = 1;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 540);
            Controls.Add(petsPanel);
            Controls.Add(label6);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(label5);
            Controls.Add(addressTextBox);
            Controls.Add(label4);
            Controls.Add(emailTextBox);
            Controls.Add(label3);
            Controls.Add(phoneTextBox);
            Controls.Add(label2);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            petsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameTextBox;
        private TextBox phoneTextBox;
        private Label label2;
        private TextBox emailTextBox;
        private Label label3;
        private Label label4;
        private RichTextBox addressTextBox;
        private RichTextBox notesTextBox;
        private Label label5;
        private Button saveButton;
        private Button cancelButton;
        private Panel petsPanel;
        private Label label6;
        private Controls.Collections.CatCollectionConcreteControl catCollectionConcreteControl;
        private Controls.Collections.BirdCollectionConcreteControl birdCollectionConcreteControl1;
    }
}