using AdminClient.Controls.Searches;
using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control for searching and displaying cat entities.
    /// </summary>
    public partial class CatSearchControl : SearchControl, ISearchControl
    {
        private ICatClient _catClient;
        private IClientClient _clientClient;
        private IVeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatSearchControl"/> class.
        /// </summary>
        public CatSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API clients required for data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _catClient = new CatClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays cat entities along with their associated owners and veterinarians.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Get all of the needed entities
            var cats = await _catClient.SearchAsync(filters);
            entities = cats;

            var clients = await _clientClient.ListAsync();
            var veterinarians = await _veterinarianClient.ListAsync();

            // Create a list of objects to display the cats with owners and veterinarians
            var catDisplayList = cats.Select(cat =>
            {
                // Get the names of the clients and veterinarians of the cat
                var clientNames = cat.OwnerIDs.Select(clientID =>
                                   clients.FirstOrDefault(client => client.ID == clientID)?.Name ?? "None").ToList();

                var veterinarianNames = cat.VeterinarianIDs.Select(veterinarianID =>
                                                  veterinarians.FirstOrDefault(veterinarian => veterinarian.ID == veterinarianID)?.Name ?? "None").ToList();

                return new
                {
                    cat.ID,
                    cat.Name,
                    cat.Breed,
                    cat.Colour,
                    cat.Sex,
                    OwnerNames = string.Join(", ", clientNames),
                    VeterinarianNames = string.Join(", ", veterinarianNames)
                };
            }).ToList();

            // Update the data grid view
            dataGridView1.DataSource = catDisplayList;

            // Set columns to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
