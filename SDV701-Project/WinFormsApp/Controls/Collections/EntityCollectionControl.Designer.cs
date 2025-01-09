namespace AdminClient.Controls.Collections
{
    partial class EntityCollectionControl<TModel, TForm, TEditForm>
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
            addButton = new Button();
            removeButton = new Button();
            listBox1 = new ListBox();
            editButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // addButton
            // 
            addButton.Location = new Point(3, 188);
            addButton.Name = "addButton";
            addButton.Size = new Size(77, 29);
            addButton.TabIndex = 2;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(169, 188);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(77, 29);
            removeButton.TabIndex = 3;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(3, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(244, 144);
            listBox1.TabIndex = 4;
            // 
            // editButton
            // 
            editButton.Location = new Point(86, 188);
            editButton.Name = "editButton";
            editButton.Size = new Size(77, 29);
            editButton.TabIndex = 5;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // EntityCollectionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editButton);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Name = "EntityCollectionControl";
            Size = new Size(250, 226);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button addButton;
        private Button removeButton;
        protected ListBox listBox1;
        private Button editButton;
    }
}
