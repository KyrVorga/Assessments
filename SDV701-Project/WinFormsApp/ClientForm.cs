using Models;
using RestAPIClient;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing client entities.
    /// </summary>
    public partial class ClientForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets the client model associated with the form.
        /// </summary>
        public ClientModel Client { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for client data operations.
        /// </summary>
        /// 
        public IAPIClient<ClientModel> APIClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly ClientModel _clientToUpdate;
        private readonly CatClient _catClient;
        private readonly BirdClient _birdClient;
        private readonly IList<int> _petIDs = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientForm"/> class for creating a new client.
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();
            APIClient = new ClientClient(Program.Configuration, new HttpClient());
            _catClient = new CatClient(Program.Configuration, new HttpClient());
            _birdClient = new BirdClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientForm"/> class for editing an existing client.
        /// </summary>
        /// <param name="client">The client to be edited.</param>
        public ClientForm(ClientModel client) : this()
        {

            // Check if the client has an ID
            if (client.ID > 0)
            {
                _clientToUpdate = client;

                nameTextBox.Text = client.Name;
                phoneTextBox.Text = client.Phone;
                emailTextBox.Text = client.Email;
                addressTextBox.Text = client.Address;

                // Check if the client has notes
                if (client.Notes != null && client.Notes.Length > 0)
                {
                    notesTextBox.Text = client.Notes;
                }

                // Check if the client has pet IDs
                if (client.PetIDs != null && client.PetIDs.Count > 0)
                {
                    _petIDs = client.PetIDs;
                }

                isEditMode = true;
            }
        }

        /// <summary>
        /// Handles the Save button click event. Constructs a client model from the form fields and either creates or updates the client entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Create a new client model
            var client = new ClientModel
            {
                Name = nameTextBox.Text,
                Phone = phoneTextBox.Text,
                Email = emailTextBox.Text,
                Address = addressTextBox.Text,
                Notes = notesTextBox.Text,
            };

            // Holds cat and bird IDs
            var petIDs = new List<int>();

            // Get the cats and add them to the client
            var cats = catCollectionConcreteControl.Entities;
            foreach (var cat in cats)
            {
                petIDs.Add(cat.ID);
            }

            // Get the cats and add them to the client
            var birds = birdCollectionConcreteControl1.Entities;
            foreach (var bird in birds)
            {
                petIDs.Add(bird.ID);
            }

            client.PetIDs = petIDs;

            int responseCode;

            // Update the client if in edit mode, otherwise add a new one
            if (isEditMode)
            {
                // Add the ID to the client
                client.ID = _clientToUpdate.ID;

                // Update the client
                responseCode = await APIClient.UpdateAsync(client);
            }
            else
            {
                // Create the client
                responseCode = await APIClient.AddAsync(client);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the client.");
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
        /// Gets the API client used for data operations.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }

        /// <summary>
        /// Handles the form load event. Initializes the form with data for the specified client, if in edit mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void ClientForm_Load(object sender, EventArgs e)
        {
            // Create a set of filter criteria
            Dictionary<string, List<FilterCriteria>> filters = new Dictionary<string, List<FilterCriteria>>
            {
                { "ID", new List<FilterCriteria>() }
            };

            // Create a filter criteria for each pet ID, and add it to the filters list of ID
            foreach (var petID in _petIDs)
            {
                filters["ID"].Add(
                    new FilterCriteria
                    {
                        FilterName = "ID",
                        Value = petID.ToString(),
                        Operation = "Equal"
                    }
                );
            }

            // Search for the pets
            var cats = await _catClient.SearchAsync(filters);
            var birds = await _birdClient.SearchAsync(filters);

            // Add the pets to the petsPanel
            catCollectionConcreteControl.PopulateList(cats);
            birdCollectionConcreteControl1.PopulateList(birds);

        }
    }
}
