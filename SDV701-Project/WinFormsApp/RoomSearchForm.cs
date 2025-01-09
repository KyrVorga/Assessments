namespace AdminClient
{
    /// <summary>
    /// Represents a search form for rooms. This form allows users to search for and add new rooms.
    /// </summary>
    public partial class RoomSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomSearchForm"/> class.
        /// </summary>
        public RoomSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Room and lock it
            SetEntitySelector("Room");
            DisableEntitySelector();
        }

        /// <summary>
        /// Handles the New button click event. This method creates a new instance of <see cref="RoomForm"/>
        /// and displays it to the user for creating a new room. If the room is successfully created, it updates
        /// the search list to include the new room.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
        {
            // Create a RoomForm and display to the user
            var roomForm = new RoomForm();
            var result = roomForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Room
            SetSelectedEntity(roomForm.Room);

            // Update the list to include the new Room
            LoadEntities();
        }
    }
}
