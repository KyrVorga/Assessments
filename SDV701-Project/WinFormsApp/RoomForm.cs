using Models;
using RestAPIClient;
using SharedLibrary;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing a room entity.
    /// </summary>
    public partial class RoomForm : Form, IEntityForm
    {
        private readonly bool isEditMode = false;
        private readonly RoomModel _roomToUpdate;

        /// <summary>
        /// Gets the room model associated with this form.
        /// </summary>
        public RoomModel Room { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for room operations.
        /// </summary>
        public IAPIClient<RoomModel> APIClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomForm"/> class for creating a new room.
        /// </summary>
        public RoomForm()
        {
            InitializeComponent();
            PopulateComboBoxes();

            APIClient = new RoomClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomForm"/> class for editing an existing room.
        /// </summary>
        /// <param name="room">The room to be edited.</param>
        public RoomForm(RoomModel room) : this()
        {

            if (room.ID != null && room.ID > 0)
            {
                _roomToUpdate = room;

                roomNumeric.Value = room.Number;
                sizeComboBox.Text = room.GetSizeType().ToString();
                qualityComboBox.Text = room.Quality;
                statusComboBox.Text = room.GetStatusType().ToString();
                notesTextBox.Text = room.Notes;

                isEditMode = true;
            }
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, creates or updates the room entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Create a new room model
            var room = new RoomModel
            {
                Number = (int)roomNumeric.Value,
                Size = sizeComboBox.Text,
                Quality = qualityComboBox.Text,
                Notes = notesTextBox.Text,
            };

            // Set the status type based on status combo box
            var selectedStatus = (StatusEnum)statusComboBox.SelectedItem;
            room.SetStatusType(selectedStatus);

            int responseCode;

            // Update the room if in edit mode, otherwise add a new room 
            if (isEditMode)
            {
                room.ID = _roomToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(room);
            }
            else
            {
                responseCode = await APIClient.AddAsync(room);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                Room = room;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the room.");
            }
        }

        /// <summary>
        /// Returns the API client associated with this form.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }

        /// <summary>
        /// Populates the combo boxes with available options.
        /// </summary>
        private void PopulateComboBoxes()
        {
            statusComboBox.DataSource = Enum.GetValues(typeof(StatusEnum));
            sizeComboBox.DataSource = Enum.GetValues(typeof(SizeEnum));
            qualityComboBox.DataSource = Enum.GetValues(typeof(QualityEnum));
        }

        /// <summary>
        /// Handles the Cancel button click event. Closes the form without saving.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
