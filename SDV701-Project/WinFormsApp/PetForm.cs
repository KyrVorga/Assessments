using Models;
using RestAPIClient;
using SharedLibrary;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing a pet entity.
    /// </summary>
    public partial class PetForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets the pet model associated with this form.
        /// </summary>
        public PetModel Pet { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for pet operations.
        /// </summary>
        public IAPIClient<PetModel> APIClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly PetModel _petToUpdate;
        private readonly IList<int> _ownerIDs = new List<int>();
        private readonly IList<int> _veterinarianIDs = new List<int>();
        private readonly ClientClient _clientClient;
        private readonly VeterinarianClient _veterinarianClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetForm"/> class for creating a new pet.
        /// </summary>
        public PetForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            APIClient = new PetClient(Program.Configuration, new HttpClient());
            _clientClient = new ClientClient(Program.Configuration, new HttpClient());
            _veterinarianClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PetForm"/> class for editing an existing pet.
        /// </summary>
        /// <param name="pet">The pet to be edited.</param>
        public PetForm(PetModel pet) : this()
        {

            if (pet.ID != null && pet.ID > 0)
            {
                _petToUpdate = pet;

                nameTextBox.Text = pet.Name;
                colourTextBox.Text = pet.Colour;
                sexComboBox.Text = pet.Sex;
                notesTextBox.Text = pet.Notes;

                // Set the birth year if it has a value
                if (pet.YearOfBirth.HasValue)
                {
                    birthYearNumeric.Value = pet.YearOfBirth.Value;
                }

                // Check if the pet has owner IDs
                if (pet.OwnerIDs != null && pet.OwnerIDs.Count > 0)
                {
                    _ownerIDs = pet.OwnerIDs;
                }
                
                // Check if the pet has veterinarian IDs
                if (pet.VeterinarianIDs != null && pet.VeterinarianIDs.Count > 0)
                {
                    _veterinarianIDs = pet.VeterinarianIDs;
                }

                isEditMode = true;
            }
        }

        /// <summary>
        /// Populates the sex combo box with available options.
        /// </summary>
        public void PopulateComboBoxes()
        {
            sexComboBox.Items.AddRange(Enum.GetNames(typeof(PetSexEnum)));
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, creates or updates the pet entity.
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
            if (string.IsNullOrWhiteSpace(breedTextBox.Text))
            {
                MessageBox.Show("Please select a breed for the pet.");
            }
            if (string.IsNullOrWhiteSpace(colourTextBox.Text))
            {
                MessageBox.Show("Please add a colour for the pet.");
            }


            // Create a new pet model
            var pet = new PetModel
            {
                Name = nameTextBox.Text,
                YearOfBirth = (int?)birthYearNumeric.Value,
                Sex = sexComboBox.Text,
                Colour = colourTextBox.Text,
                Notes = notesTextBox.Text,
            };

            // Get the owners from the clientCollectionControl
            var owners = clientCollectionConcreteControl1.Entities;
            var ownerIDs = new List<int>();

            // Get the IDs of the owners
            foreach (var owner in owners)
            {
                ownerIDs.Add(owner.ID);
            }

            pet.OwnerIDs = ownerIDs;

            // Get the veterinarians from the veterinarianCollectionControl
            var veterinarians = veterinarianCollectionConcreteControl1.Entities;
            var veterinarianIDs = new List<int>();

            // Get the IDs of the veterinarians
            foreach (var veterinarian in veterinarians)
            {
                veterinarianIDs.Add(veterinarian.ID);
            }

            pet.VeterinarianIDs = veterinarianIDs;


            int responseCode;

            // Update the pet if in edit mode, otherwise add a new one
            if (isEditMode)
            {
                pet.ID = _petToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(pet);
            }
            else
            {
                responseCode = await APIClient.AddAsync(pet);
            }

            // Check if the response code is good
            if (responseCode > 0)
            {
                Pet = pet;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the pet.");
            }
        }

        /// <summary>
        /// Returns the API client associated with this form.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }

        /// <summary>
        /// Handles the Cancel button click event. Closes the form without saving.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the form's Load event. Initializes the form with data for the specified pet.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void PetForm_Load(object sender, EventArgs e)
        {
            // Create a set of filter criteria for owners 
            Dictionary<string, List<FilterCriteria>> ownerFilters = new Dictionary<string, List<FilterCriteria>>
            {
                { "ID", new List<FilterCriteria>() }
            };


            // Create a filter criteria for each owner ID
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

            // Create a filter criteria for each veterinarian ID
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
