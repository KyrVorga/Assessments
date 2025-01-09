namespace AdminClient
{
    /// <summary>
    /// Represents a search form specifically for searching and adding pets.
    /// </summary>
    public partial class PetSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetSearchForm"/> class.
        /// </summary>
        public PetSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Pet and lock it
            SetEntitySelector("Pet");
            DisableEntitySelector();

            // Fill the type combo box with the Pet types
            addNewTypeCombo.Items.Add("Cat");
            addNewTypeCombo.Items.Add("Bird");
            // Set the default type to Cat
            addNewTypeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the New button click event to create a new pet entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
        {
            // Pick which new entity method based on type combo box
            if (addNewTypeCombo.Text == "Cat")
            {
                NewCat();
            }
            else if (addNewTypeCombo.Text == "Bird")
            {
                NewBird();
            }
            else
            {
                MessageBox.Show("Please select a type to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Update the list to include the new Pet
            LoadEntities();
        }

        /// <summary>
        /// Creates a new Cat entity and displays the Cat form for user input.
        /// </summary>
        public void NewCat()
        {
            // Create a CatForm and display to the user
            var catForm = new CatForm();
            var result = catForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Cat
            SetSelectedEntity(catForm.Cat);
        }

        /// <summary>
        /// Creates a new Bird entity and displays the Bird form for user input.
        /// </summary>
        public void NewBird()
        {
            // Create a BirdForm and display to the user
            var birdForm = new BirdForm();
            var result = birdForm.ShowDialog();

            // If the result is bad, return
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the selected entity to the Bird
            SetSelectedEntity(birdForm.Bird);
        }
    }
}
