namespace AdminClient
{
    /// <summary>
    /// Represents a form for searching and managing cat entities.
    /// </summary>
    public partial class CatSearchForm : SearchForm, ISearchForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatSearchForm"/> class.
        /// </summary>
        public CatSearchForm()
        {
            InitializeComponent();

            // Set the entity selector to Cat and lock it
            SetEntitySelector("Cat");
            DisableEntitySelector();
        }

        /// <summary>
        /// Handles the New button click event. Opens a form for creating a new cat entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void newButton_Click(object sender, EventArgs e)
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

            // Update the list to include the new Cat
            LoadEntities();
        }
    }
}
