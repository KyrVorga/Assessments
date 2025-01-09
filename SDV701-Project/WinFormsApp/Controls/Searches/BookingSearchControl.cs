using AdminClient.Controls.Searches;
using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control for searching and displaying booking entities.
    /// </summary>
    public partial class BookingSearchControl : SearchControl, ISearchControl
    {
        private IBookingClient _bookingClient;
        private IClientClient _clientClient;
        private IRoomClient _roomClient;
        private IPetClient _petClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingSearchControl"/> class.
        /// </summary>
        public BookingSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _bookingClient = new BookingClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _roomClient = new RoomClient(Program.Configuration, new HttpClient());
            _petClient = new PetClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays booking entities along with their associated clients, pets, and rooms.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Retrieve the list of bookings.
            var bookings = await _bookingClient.SearchAsync(filters);
            entities = bookings;

            // Get the other needed entities.
            var clients = await _clientClient.ListAsync();
            var rooms = await _roomClient.ListAsync();
            var pets = await _petClient.ListAsync();

            // Create a list of objects to display the bookings.
            var bookingDisplayList = bookings.Select(booking =>
            {
                // Get the names of the client, pet, and room of the booking.
                var clientName = clients.FirstOrDefault(client => client.ID == booking.ClientID)?.Name ?? "None";
                var petName = pets.FirstOrDefault(pet => pet.ID == booking.PetID)?.Name ?? "None";
                var roomNumber = rooms.FirstOrDefault(room => room.ID == booking.RoomID)?.Number ?? null;

                return new
                {
                    booking.ID,
                    booking.CheckIn,
                    booking.CheckOut,
                    ClientName = clientName,
                    PetName = petName,
                    RoomNumber = roomNumber
                };
            }).ToList();

            // Update the data grid view.
            dataGridView1.DataSource = bookingDisplayList;

            // Set the ID column to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
