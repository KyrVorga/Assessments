namespace AdminClient
{
    partial class MainForm
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
            bookingsButton = new Button();
            clientsButton = new Button();
            PetsButton = new Button();
            RoomsButton = new Button();
            searchButton = new Button();
            filtersPanel1 = new Controls.FiltersPanel();
            tasksButton = new Button();
            veterinarianButton = new Button();
            taskList = new ListBox();
            SuspendLayout();
            // 
            // bookingsButton
            // 
            bookingsButton.Location = new Point(22, 623);
            bookingsButton.Name = "bookingsButton";
            bookingsButton.Size = new Size(137, 29);
            bookingsButton.TabIndex = 2;
            bookingsButton.Text = "Bookings";
            bookingsButton.UseVisualStyleBackColor = true;
            bookingsButton.Click += bookingsButton_Click;
            // 
            // clientsButton
            // 
            clientsButton.Location = new Point(166, 623);
            clientsButton.Name = "clientsButton";
            clientsButton.Size = new Size(137, 29);
            clientsButton.TabIndex = 3;
            clientsButton.Text = "Clients";
            clientsButton.UseVisualStyleBackColor = true;
            clientsButton.Click += clientsButton_Click;
            // 
            // PetsButton
            // 
            PetsButton.Location = new Point(310, 623);
            PetsButton.Name = "PetsButton";
            PetsButton.Size = new Size(137, 29);
            PetsButton.TabIndex = 4;
            PetsButton.Text = "Pets";
            PetsButton.UseVisualStyleBackColor = true;
            PetsButton.Click += PetsButton_Click;
            // 
            // RoomsButton
            // 
            RoomsButton.Location = new Point(454, 623);
            RoomsButton.Name = "RoomsButton";
            RoomsButton.Size = new Size(137, 29);
            RoomsButton.TabIndex = 5;
            RoomsButton.Text = "Rooms";
            RoomsButton.UseVisualStyleBackColor = true;
            RoomsButton.Click += RoomsButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(603, 553);
            searchButton.Margin = new Padding(2, 3, 2, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(119, 29);
            searchButton.TabIndex = 10;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // filtersPanel1
            // 
            filtersPanel1.FilterActions = null;
            filtersPanel1.Location = new Point(443, 17);
            filtersPanel1.Name = "filtersPanel1";
            filtersPanel1.Size = new Size(448, 530);
            filtersPanel1.TabIndex = 11;
            // 
            // tasksButton
            // 
            tasksButton.Location = new Point(596, 623);
            tasksButton.Name = "tasksButton";
            tasksButton.Size = new Size(137, 29);
            tasksButton.TabIndex = 12;
            tasksButton.Text = "Tasks";
            tasksButton.UseVisualStyleBackColor = true;
            tasksButton.Click += tasksButton_Click;
            // 
            // veterinarianButton
            // 
            veterinarianButton.Location = new Point(739, 623);
            veterinarianButton.Name = "veterinarianButton";
            veterinarianButton.Size = new Size(137, 29);
            veterinarianButton.TabIndex = 13;
            veterinarianButton.Text = "Veterinarians";
            veterinarianButton.UseVisualStyleBackColor = true;
            veterinarianButton.Click += veterinarianButton_Click;
            // 
            // taskList
            // 
            taskList.FormattingEnabled = true;
            taskList.ItemHeight = 20;
            taskList.Location = new Point(11, 17);
            taskList.Margin = new Padding(1);
            taskList.Name = "taskList";
            taskList.Size = new Size(427, 564);
            taskList.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 664);
            Controls.Add(veterinarianButton);
            Controls.Add(tasksButton);
            Controls.Add(filtersPanel1);
            Controls.Add(searchButton);
            Controls.Add(RoomsButton);
            Controls.Add(PetsButton);
            Controls.Add(clientsButton);
            Controls.Add(bookingsButton);
            Controls.Add(taskList);
            Margin = new Padding(1);
            Name = "MainForm";
            Text = "Mainform";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private ListBox bookingsList;
        private Button bookingsButton;
        private Button clientsButton;
        private Button PetsButton;
        private Button RoomsButton;
        private Button searchButton;
        private Controls.FiltersPanel filtersPanel1;
        private Button tasksButton;
        private Button veterinarianButton;
        private ListBox taskList;
    }
}