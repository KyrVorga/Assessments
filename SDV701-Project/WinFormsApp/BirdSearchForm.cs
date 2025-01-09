namespace AdminClient
{
    /// <summary>
    /// Represents a form for searching and managing bird entities.
    /// </summary>
    public partial class BirdSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirdSearchForm"/> class.
        /// </summary>
        public BirdSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Bird and lock it
            SetEntitySelector("Bird");
            DisableEntitySelector();
        }

        /// <summary>
        /// Handles the New button click event. Opens a form for creating a new bird entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
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

            // Update the list to include the new Bird
            LoadEntities();
        }
    }
}
