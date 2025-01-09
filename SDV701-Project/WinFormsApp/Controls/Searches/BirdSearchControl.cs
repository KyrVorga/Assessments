using AdminClient.Controls.Searches;
using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control for searching and displaying bird entities.
    /// </summary>
    public partial class BirdSearchControl : SearchControl, ISearchControl
    {
        private IBirdClient _birdClient;
        private IClientClient _clientClient;
        private IVeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdSearchControl"/> class.
        /// </summary>
        public BirdSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _birdClient = new BirdClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays bird entities along with their associated owners and veterinarians.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Get all of the needed entites
            var birds = await _birdClient.SearchAsync(filters);
            entities = birds;

            var clients = await _clientClient.ListAsync();
            var veterinarians = await _veterinarianClient.ListAsync();

            // Create a list of objects to display the birds with owners and veterinarians
            var birdDisplayList = birds.Select(bird =>
            {
                // Get the names of the clients and veterinarians associated with the bird
                var clientNames = bird.OwnerIDs.Select(clientID =>
                                   clients.FirstOrDefault(client => client.ID == clientID)?.Name ?? "None").ToList();

                var veterinarianNames = bird.VeterinarianIDs.Select(veterinarianID =>
                                                  veterinarians.FirstOrDefault(veterinarian => veterinarian.ID == veterinarianID)?.Name ?? "None").ToList();

                return new
                {
                    bird.ID,
                    bird.Name,
                    bird.Species,
                    bird.Colour,
                    bird.Sex,
                    OwnerNames = string.Join(", ", clientNames),
                    VeterinarianNames = string.Join(", ", veterinarianNames)
                };
            }).ToList();

            // Update the data grid view
            dataGridView1.DataSource = birdDisplayList;

            // Set columns to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
