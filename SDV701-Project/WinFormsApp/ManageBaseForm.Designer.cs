namespace AdminClient
{
    partial class ManageBaseForm
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
            entitySelector = new ComboBox();
            filtersPanelControl = new Controls.FiltersPanel();
            searchPanel = new Panel();
            filterPanel = new Panel();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // entitySelector
            // 
            entitySelector.DropDownStyle = ComboBoxStyle.DropDownList;
            entitySelector.FormattingEnabled = true;
            entitySelector.Location = new Point(12, 12);
            entitySelector.Name = "entitySelector";
            entitySelector.Size = new Size(151, 28);
            entitySelector.TabIndex = 0;
            entitySelector.SelectedIndexChanged += entitySelector_SelectedIndexChanged;
            // 
            // filtersPanelControl
            // 
            filtersPanelControl.Dock = DockStyle.Fill;
            filtersPanelControl.FilterActions = null;
            filtersPanelControl.Location = new Point(0, 0);
            filtersPanelControl.Name = "filtersPanelControl";
            filtersPanelControl.Size = new Size(472, 546);
            filtersPanelControl.TabIndex = 5;
            // 
            // searchPanel
            // 
            searchPanel.Location = new Point(12, 46);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(764, 512);
            searchPanel.TabIndex = 7;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(filtersPanelControl);
            filterPanel.Location = new Point(782, 12);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(472, 546);
            filterPanel.TabIndex = 8;
            // 
            // ManageBaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 567);
            Controls.Add(filterPanel);
            Controls.Add(searchPanel);
            Controls.Add(entitySelector);
            Name = "ManageBaseForm";
            Text = "ManageBaseForm";
            filterPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Controls.ClientSearchControl clientSearchControl1;
        protected ComboBox entitySelector;
        private Panel filterPanel;
        private Controls.FiltersPanel filtersPanelControl;
        private Panel searchPanel;
    }
}