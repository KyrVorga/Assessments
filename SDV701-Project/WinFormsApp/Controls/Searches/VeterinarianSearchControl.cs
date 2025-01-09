using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls.Searches
{
    /// <summary>
    /// Represents a control for searching and displaying veterinarian entities.
    /// </summary>
    public partial class VeterinarianSearchControl : SearchControl, ISearchControl
    {
        private IVeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianSearchControl"/> class.
        /// </summary>
        public VeterinarianSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API client required for veterinarian data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays veterinarian entities.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Load the veterinarian entities.
            var vets = await _veterinarianClient.SearchAsync(filters);
            entities = vets;

            // Display the veterinarian entities in the DataGridView.
            var vetDisplayList = vets.Select(vet =>
            {
                return new
                {
                    vet.ID,
                    vet.Name,
                    vet.ContactPerson,
                    vet.Phone,
                    vet.Email,
                    vet.Address
                };
            }).ToList();

            dataGridView1.DataSource = vetDisplayList;

            // Set the ID column to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
