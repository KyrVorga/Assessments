using Models;
using RestAPIClient;
using SharedLibrary;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing cat entities.
    /// </summary>
    public partial class CatForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets or sets the API client used for cat data operations.
        /// </summary>
        public IAPIClient<CatModel> APIClient { get; set; }

        /// <summary>
        /// Gets the cat model associated with the form.
        /// </summary>
        public CatModel Cat { get; private set; }

        private readonly bool isEditMode = false;
        private readonly CatModel _catToUpdate;
        private readonly IList<int> _ownerIDs = new List<int>();
        private readonly IList<int> _veterinarianIDs = new List<int>();
        private readonly ClientClient _clientClient;
        private readonly VeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatForm"/> class for creating a new cat.
        /// </summary>
        public CatForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            APIClient = new CatClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Populates the sex combo box with values from the PetSexEnum.
        /// </summary>
        public void PopulateComboBoxes()
        {
            sexComboBox.Items.AddRange(Enum.GetNames(typeof(PetSexEnum)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatForm"/> class for editing an existing cat.
        /// </summary>
        /// <param name="cat">The cat to be edited.</param>
        public CatForm(CatModel cat) : this()
        {
            if (cat.ID != null && cat.ID > 0)
            {
                _catToUpdate = cat;

                nameTextBox.Text = cat.Name;
                breedTextBox.Text = cat.Breed;
                colourTextBox.Text = cat.Colour;
                sexComboBox.Text = cat.Sex;
                notesTextBox.Text = cat.Notes;

                // Check if the year of birth is set
                if (cat.YearOfBirth.HasValue)
                {
                    birthYearNumeric.Value = cat.YearOfBirth.Value;
                }

                // Check if the cat has any owner IDs
                if (cat.OwnerIDs != null && cat.OwnerIDs.Count > 0)
                {
                    _ownerIDs = cat.OwnerIDs;
                }

                // Check if the cat has any veterinarian IDs=
                if (cat.VeterinarianIDs != null && cat.VeterinarianIDs.Count > 0)
                {
                    _veterinarianIDs = cat.VeterinarianIDs;
                }

                isEditMode = true;
            }
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, constructs a cat model from the form fields, and either creates or updates the cat entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Create a new cat model.
            var cat = new CatModel
            {
                Name = nameTextBox.Text,
                Breed = breedTextBox.Text,
                YearOfBirth = (int?)birthYearNumeric.Value,
                Sex = sexComboBox.Text,
                Colour = colourTextBox.Text,
                Notes = notesTextBox.Text,
            };

            // Get the owners and veterinarians from the collection controls
            var owners = clientCollectionConcreteControl1.Entities;
            var ownerIDs = new List<int>();

            // Add the owner IDs to the list
            foreach (var owner in owners)
            {
                ownerIDs.Add(owner.ID);
            }

            cat.OwnerIDs = ownerIDs;

            // Get the veterinarians from the collection control
            var veterinarians = veterinarianCollectionConcreteControl1.Entities;
            var veterinarianIDs = new List<int>();

            // Add the veterinarian IDs to the list
            foreach (var veterinarian in veterinarians)
            {
                veterinarianIDs.Add(veterinarian.ID);
            }

            cat.VeterinarianIDs = veterinarianIDs;


            int responseCode;

            // Update the cat if in edit mode, otherwise add a new cat
            if (isEditMode)
            {
                cat.ID = _catToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(cat);
            }
            else
            {
                responseCode = await APIClient.AddAsync(cat);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                Cat = cat;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the cat.");
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
        /// Handles the form load event. Initializes the form with data for the specified cat, if in edit mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void CatForm_Load(object sender, EventArgs e)
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

            // Add a filter criteria for each veterinarian ID
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
