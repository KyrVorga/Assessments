using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls.Searches
{
    /// <summary>
    /// Represents a control for searching and displaying pet entities.
    /// </summary>
    public partial class PetSearchControl : SearchControl, ISearchControl
    {
        private IPetClient _petClient;
        private IClientClient _clientClient;
        private IVeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetSearchControl"/> class.
        /// </summary>
        public PetSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _petClient = new PetClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays pet entities along with their associated owners and veterinarians.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Retrieve pets, clients, and veterinarians.
            var pets = await _petClient.SearchAsync(filters);
            entities = pets;

            var clients = await _clientClient.ListAsync();
            var veterinarians = await _veterinarianClient.ListAsync();

            // Display pets along with their owners and veterinarians.
            var petDisplayList = pets.Select(pet =>
            {
                // Retrieve client and veterinarian names.
                var clientNames = pet.OwnerIDs.Select(clientID =>
                                   clients.FirstOrDefault(client => client.ID == clientID)?.Name ?? "None").ToList();

                var veterinarianNames = pet.VeterinarianIDs.Select(veterinarianID =>
                                                  veterinarians.FirstOrDefault(veterinarian => veterinarian.ID == veterinarianID)?.Name ?? "None").ToList();

                return new
                {
                    pet.ID,
                    pet.Name,
                    pet.Colour,
                    pet.Sex,
                    OwnerNames = string.Join(", ", clientNames),
                    VeterinarianNames = string.Join(", ", veterinarianNames)
                };
            }).ToList();

            // Update the data grid view.
            dataGridView1.DataSource = petDisplayList;

            // Set columns to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
