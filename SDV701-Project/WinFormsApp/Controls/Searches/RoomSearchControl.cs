using AdminClient.Controls.Searches;
using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control for searching and displaying room entities.
    /// </summary>
    public partial class RoomSearchControl : SearchControl, ISearchControl
    {
        private IRoomClient _roomClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomSearchControl"/> class.
        /// </summary>
        public RoomSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API client required for room data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _roomClient = new RoomClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays room entities.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Load the rooms.
            var rooms = await _roomClient.SearchAsync(filters);
            entities = rooms;

            // Display the rooms in the data grid view.
            var roomDisplayList = rooms.Select(room =>
            {
                return new
                {
                    room.ID,
                    room.Number,
                    room.Size,
                    room.Quality,
                    room.Status,
                };
            }).ToList();

            // Update the data grid view.
            dataGridView1.DataSource = roomDisplayList;

            // Set the ID column to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
