using Models;
using RestAPIClient;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing a veterinarian entity.
    /// </summary>
    public partial class VeterinarianForm : Form, IEntityForm
    {
        /// <summary>
        /// Gets the veterinarian model associated with this form.
        /// </summary>
        public VeterinarianModel Veterinarian { get; private set; }

        /// <summary>
        /// Gets or sets the API client used for veterinarian operations.
        /// </summary>
        public IAPIClient<VeterinarianModel> APIClient { get; set; }

        private readonly bool isEditMode = false;
        private readonly VeterinarianModel _veterinarianToUpdate;

        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianForm"/> class for creating a new veterinarian.
        /// </summary>
        public VeterinarianForm()
        {
            InitializeComponent();
            APIClient = new VeterinarianClient(Program.Configuration, new HttpClient());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianForm"/> class for editing an existing veterinarian.
        /// </summary>
        /// <param name="veterinarian">The veterinarian to be edited.</param>
        public VeterinarianForm(VeterinarianModel veterinarian) : this()
        {
            if (veterinarian.ID != null && veterinarian.ID > 0)
            {
                _veterinarianToUpdate = veterinarian;

                businessTextBox.Text = veterinarian.Name;
                phoneTextBox.Text = veterinarian.Phone;
                emailTextBox.Text = veterinarian.Email;
                addressTextBox.Text = veterinarian.Address;
                contactTextBox.Text = veterinarian.ContactPerson;
                notesTextBox.Text = veterinarian.Notes;

                isEditMode = true;
            }
        }

        /// <summary>
        /// Handles the Save button click event. Validates input, creates or updates the veterinarian entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            var veterinarian = new VeterinarianModel
            {
                Name = businessTextBox.Text,
                Phone = phoneTextBox.Text,
                Email = emailTextBox.Text,
                Address = addressTextBox.Text,
                ContactPerson = contactTextBox.Text,
                Notes = notesTextBox.Text
            };

            int responseCode;

            // If in edit mode, update the existing veterinarian, else add new one
            if (isEditMode)
            {
                veterinarian.ID = _veterinarianToUpdate.ID;
                responseCode = await APIClient.UpdateAsync(veterinarian);
            }
            else
            {
                responseCode = await APIClient.AddAsync(veterinarian);
            }

            if (responseCode > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save the veterinarian.");
            }
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
        /// Returns the API client associated with this form.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            return APIClient;
        }
    }
}
