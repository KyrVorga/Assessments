namespace AdminClient
{
    /// <summary>
    /// Represents a search form for veterinarians. This form allows users to search for and add new veterinarians.
    /// </summary>
    public partial class VeterinarianSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VeterinarianSearchForm"/> class.
        /// </summary>
        public VeterinarianSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Veterinarian and lock it
            SetEntitySelector("Veterinarian");
            DisableEntitySelector();
        }

        /// <summary>
        /// Handles the New button click event. This method creates a new instance of <see cref="VeterinarianForm"/>
        /// and displays it to the user for creating a new veterinarian. If the veterinarian is successfully created, it updates
        /// the search list to include the new veterinarian.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
        {
            // Create a VeterinarianForm and display to the user
            var veterinarianForm = new VeterinarianForm();
            var result = veterinarianForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Veterinarian
            SetSelectedEntity(veterinarianForm.Veterinarian);

            // Update the list to include the new Veterinarian
            LoadEntities();
        }
    }
}
