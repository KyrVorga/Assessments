using Models;
using RestAPIClient;
using SharedLibrary;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing bird entities.
    /// </summary>
    public partial class BirdForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets the bird model associated with the form.
        /// </summary>
        public BirdModel Bird { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for bird data operations.
        /// </summary>
        public IAPIClient<BirdModel> APIClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly BirdModel _birdToUpdate;
        private readonly IList<int> _ownerIDs = new List<int>();
        private readonly IList<int> _veterinarianIDs = new List<int>();
        private readonly ClientClient _clientClient;
        private readonly VeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdForm"/> class for creating a new bird.
        /// </summary>
        public BirdForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            APIClient = new BirdClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdForm"/> class for editing an existing bird.
        /// </summary>
        /// <param name="bird">The bird to be edited.</param>
        public BirdForm(BirdModel bird) : this()
        {
            if (bird.ID != null && bird.ID > 0)
            {
                _birdToUpdate = bird;

                nameTextBox.Text = bird.Name;
                speciesTextBox.Text = bird.Species;
                colourTextBox.Text = bird.Colour;
                sexComboBox.Text = bird.Sex;
                notesTextBox.Text = bird.Notes;

                if (bird.YearOfBirth.HasValue)
                {
                    birthYearNumeric.Value = bird.YearOfBirth.Value;
                }

                if (bird.OwnerIDs != null && bird.OwnerIDs.Count > 0)
                {
                    _ownerIDs = bird.OwnerIDs;
                }

                if (bird.VeterinarianIDs != null && bird.VeterinarianIDs.Count > 0)
                {
                    _veterinarianIDs = bird.VeterinarianIDs;
                }

                isEditMode = true;
            }
        }

        /// <summary>
        /// Populates the sex combo box with values from the PetSexEnum.
        /// </summary>
        public void PopulateComboBoxes()
        {
            sexComboBox.Items.AddRange(Enum.GetNames(typeof(PetSexEnum)));
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, constructs a bird model from the form fields, and either creates or updates the bird entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Ensure that all require fields have been filled
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please add a name for the pet.");
                return;
            }
            if (string.IsNullOrWhiteSpace(speciesTextBox.Text))
            {
                MessageBox.Show("Please select a species for the pet.");
            }
            if (string.IsNullOrWhiteSpace(colourTextBox.Text))
            {
                MessageBox.Show("Please add a colour for the pet.");
            }
            var bird = new BirdModel
            {
                Name = nameTextBox.Text,
                Species = speciesTextBox.Text,
                YearOfBirth = (int?)birthYearNumeric.Value,
                Sex = sexComboBox.Text,
                Colour = colourTextBox.Text,
                Notes = notesTextBox.Text,
            };

            var owners = clientCollectionConcreteControl1.Entities;
            var ownerIDs = new List<int>();
            foreach (var owner in owners)
            {
                ownerIDs.Add(owner.ID);
            }

            bird.OwnerIDs = ownerIDs;


            var veterinarians = veterinarianCollectionConcreteControl1.Entities;
            var veterinarianIDs = new List<int>();
            foreach (var veterinarian in veterinarians)
            {
                veterinarianIDs.Add(veterinarian.ID);
            }

            bird.VeterinarianIDs = veterinarianIDs;


            int responseCode;

            if (isEditMode)
            {
                bird.ID = _birdToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(bird);
            }
            else
            {
                responseCode = await APIClient.AddAsync(bird);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                Bird = bird;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the bird.");
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
        /// Handles the Cancel button click event, closing the form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Handles the form load event. Initializes the form with data for the specified bird, if in edit mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void BirdForm_Load(object sender, EventArgs e)
        {
            // Create a set of filter criteria for owners 
            Dictionary<string, List<FilterCriteria>> ownerFilters = new Dictionary<string, List<FilterCriteria>>
            {
                { "ID", new List<FilterCriteria>() }
            };


            // Create a filter criteria for each owner ID, and add it to the filters list of ID
            foreach (var ownerID in _ownerIDs)
            {
                ownerFilters["ID"].Add(
                    new FilterCriteria
                    {
                        FilterName = "ID",
                        Value = ownerID.ToString(),
                        Operation = "Equal"
                    }
                );
            }

            // Create a set of filters for the veterinarians
            Dictionary<string, List<FilterCriteria>> veterinarianFilters = new Dictionary<string, List<FilterCriteria>>
            {
                { "ID", new List<FilterCriteria>() }
            };

            foreach (var veterinarianID in _veterinarianIDs)
            {
                veterinarianFilters["ID"].Add(
                    new FilterCriteria
                    {
                        FilterName = "ID",
                        Value = veterinarianID.ToString(),
                        Operation = "Equal"
                    }
                );
            }

            // Search for the veterinarians
            var veterinarians = await _veterinarianClient.SearchAsync(veterinarianFilters);

            // Search for the pets
            var pets = await _clientClient.SearchAsync(ownerFilters);

            // Add the pets to the petsPanel
            clientCollectionConcreteControl1.PopulateList(pets);

            // Add the veterinarians to the veterinariansPanel
            veterinarianCollectionConcreteControl1.PopulateList(veterinarians);

        }
    }
}
