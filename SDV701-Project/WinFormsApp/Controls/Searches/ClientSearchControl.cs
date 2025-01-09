using AdminClient.Controls.Searches;
using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control for searching and displaying client entities.
    /// </summary>
    public partial class ClientSearchControl : SearchControl, ISearchControl
    {
        private IClientClient _clientClient;
        private IPetClient _petClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSearchControl"/> class.
        /// </summary>
        public ClientSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _petClient = new PetClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays client entities along with their associated pets.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            
            // Get the clients and pets. If filters are provided, apply them.
            var clients = await _clientClient.SearchAsync(filters);
            entities = clients;

            var pets = await _petClient.ListAsync();

            // Create a list of clients and their pet names.
            var clientDisplayList = clients.Select(client =>
            {
                // Get the pet names of the client.
                var petNames = client.PetIDs.Select(petID =>
                    pets.FirstOrDefault(pet => pet.ID == petID)?.Name ?? "None").ToList();

                return new
                {
                    client.ID,
                    client.Name,
                    client.Phone,
                    client.Email,
                    client.Address,
                    PetNames = string.Join(", ", petNames)
                };
            }).ToList();

            // Update the data grid view.
            dataGridView1.DataSource = clientDisplayList;

            // Set the ID column to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
