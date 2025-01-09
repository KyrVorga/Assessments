using Models;
using RestAPIClient;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing booking entities.
    /// </summary>
    public partial class BookingForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets the booking model associated with the form.
        /// </summary>
        public BookingModel Booking { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for booking data operations.
        /// </summary>
        public IAPIClient<BookingModel> APIClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly BookingModel _bookingToUpdate;
        private ClientModel _client;
        private PetModel _pet;
        private RoomModel _room;
        private readonly int? _clientId;
        private readonly int? _petId;
        private readonly int? _roomId;

        private readonly ClientClient _clientClient;
        private readonly PetClient _petClient;
        private readonly RoomClient _roomClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingForm"/> class for creating a new booking.
        /// </summary>
        public BookingForm()
        {
            InitializeComponent();

            APIClient = new BookingClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _petClient = new PetClient(Program.Configuration, new HttpClient());
            _roomClient = new RoomClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingForm"/> class for editing an existing booking.
        /// </summary>
        /// <param name="booking">The booking to be edited.</param>
        public BookingForm(BookingModel booking) : this()
        {
            if (booking.ID != null && booking.ID > 0)
            {
                _bookingToUpdate = booking;

                _clientId = booking.ClientID;
                _petId = booking.PetID;
                _roomId = booking.RoomID;

                checkInDateTime.Value = booking.CheckIn;
                if (booking.CheckOut != null)
                {
                    checkOutDateTime.Value = (DateTime)booking.CheckOut;
                }


                isEditMode = true;
            }
        }

        /// <summary>
        /// Gets the API client used for data operations.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, constructs a booking model from the form fields, and either creates or updates the booking entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Ensure that all require fields have been filled
            if (_client == null || _pet == null || _room == null)
            {
                MessageBox.Show("Please select a client, pet and room.");
                return;
            }

            // Create a new booking model
            var booking = new BookingModel
            {
                ClientID = _client.ID,
                PetID = _pet.ID,
                RoomID = _room.ID,
                CheckIn = checkInDateTime.Value,
                Notes = notesTextBox.Text,
            };

            // Set the check out date if it is not null
            if (checkOutDateTime.Value != null)
            {
                booking.CheckOut = checkOutDateTime.Value;
            }

            int responseCode;

            // Update the booking if in edit mode, otherwise add a new one
            if (isEditMode)
            {
                booking.ID = _bookingToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(booking);
            }
            else
            {
                responseCode = await APIClient.AddAsync(booking);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                Booking = booking;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the booking.");
            }
        }

        /// <summary>
        /// Handles the Cancel button click event, closing the form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Handles the form load event. Initializes the form with data for the specified booking, if in edit mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void BookingForm_Load(object sender, EventArgs e)
        { 
            // if in edit mode, use the api clients to get the client, pet and room if the ids are there
            if (isEditMode)
            {
                if (_clientId != null)
                {
                    var client = await _clientClient.GetAsync(_clientId.Value);
                    Client(client);
                }

                if (_petId != null)
                {
                    var pet = await _petClient.GetAsync(_petId.Value);
                    Pet(pet);
                }

                if (_roomId != null)
                {
                    var room = await _roomClient.GetAsync(_roomId.Value);
                    Room(room);
                }
            }
        }
        
        /// <summary>
        /// Sets the client for the booking.
        /// </summary>
        /// <param name="client">The client model.</param>
        private void Client(ClientModel client)
        {
            // Set the client property
            _client = client;

            // Update the clientTextBox
            clientTextBox.Text = client.ToString();
        }

        /// <summary>
        /// Sets the pet for the booking.
        /// </summary>
        /// <param name="pet">The pet model.</param>
        private void Pet(PetModel pet)
        {
            // Set the pet property
            _pet = pet;

            // Update the petTextBox
            petTextBox.Text = pet.ToString();
        }

        /// <summary>
        /// Sets the room for the booking.
        /// </summary>
        /// <param name="room">The room model.</param>
        private void Room(RoomModel room)
        {
            // Set the room property
            _room = room;

            // Update the roomTextBox
            roomTextBox.Text = room.ToString();
        }

        /// <summary>
        /// Handles the client search button click event, opening a form to search for a client.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void clientSearchButton_Click(object sender, EventArgs e)
        {
            // Open the client search form
            ClientSearchForm clientSearchForm = new ClientSearchForm();
            DialogResult result = clientSearchForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Get the selected client
            var client = (ClientModel)clientSearchForm.GetSelectedEntity();
            if (client != null)
            {
                // Update the client property and clientTextBox
                clientTextBox.Text = client.ToString();
                Client(client);
            }
        }

        /// <summary>
        /// Handles the pet search button click event, opening a form to search for a pet.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void petSearchButton_Click(object sender, EventArgs e)
        {
            // Open the pet search form
            PetSearchForm petSearchForm = new PetSearchForm();
            DialogResult result = petSearchForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Get the selected pet
            var pet = (PetModel)petSearchForm.GetSelectedEntity();
            if (pet != null)
            {
                // Update the pet property and petTextBox
                petTextBox.Text = pet.ToString();
                Pet(pet);
            }
        }

        /// <summary>
        /// Handles the room search button click event, opening a form to search for a room.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void roomSearchButton_Click(object sender, EventArgs e)
        {
            // Open the room search form
            RoomSearchForm roomSearchForm = new RoomSearchForm();
            DialogResult result = roomSearchForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Get the selected room
            var room = (RoomModel)roomSearchForm.GetSelectedEntity();
            if (room != null)
            {
                // Update the room property and roomTextBox
                roomTextBox.Text = room.ToString();
                Room(room);
            }
        }
    }
}
