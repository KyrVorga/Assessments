using RestAPIClient;
using System.Data;
using WinFormsApp;

namespace AdminClient.Controls.Searches
{
    /// <summary>
    /// Represents a control for searching and displaying trait entities.
    /// </summary>
    public partial class TraitSearchControl : SearchControl, ISearchControl
    {
        private ITraitClient _traitClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TraitSearchControl"/> class.
        /// </summary>
        public TraitSearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the API client required for trait data retrieval.
        /// </summary>
        public void InitializeAPIClients()
        {
            _traitClient = new TraitClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Asynchronously loads and displays trait entities.
        /// </summary>
        public async void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            // Retrieve the list of traits.
            var traits = await _traitClient.SearchAsync(filters);
            entities = traits;

            // Create a display list of traits.
            var traitDisplayList = traits.Select(trait =>
            {
                return new
                {
                    trait.ID,
                    trait.Name
                };
            }).ToList();

            // Update the data grid view.
            dataGridView1.DataSource = traitDisplayList;

            // Set the ID column to be invisible.
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
