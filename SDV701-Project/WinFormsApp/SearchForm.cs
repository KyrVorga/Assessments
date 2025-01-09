using Models;

namespace AdminClient
{
    /// <summary>
    /// Represents a base form for search functionality within the application.
    /// This form allows users to search for and select entities.
    /// </summary>
    public partial class SearchForm : ManageBaseForm
    {
        /// <summary>
        /// Gets or sets the selected entity model.
        /// </summary>
        public IEntityModel Entity { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchForm"/> class.
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Confirm button click event. Validates the selection
        /// and closes the form with a DialogResult of OK.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            // Ensure that an item is selected, and only one item is selected
            var selectedEntity = (IEntityModel)GetSelectedEntity();
            if (selectedEntity == null)
            {
                MessageBox.Show("Please select an entity to add");
                return;
            }

            // Store the selected item for retrieval by the calling form
            SetSelectedEntity(selectedEntity);
            DialogResult = DialogResult.OK; // Indicate success
            Close();
        }

        /// <summary>
        /// Sets the selected entity model. This method is intended to be overridden
        /// <param name="entity">The entity model to set as selected.</param>
        protected virtual void SetSelectedEntity(IEntityModel entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Handles the Cancel button click event. Closes the form without making a selection.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the New button click event. This method is intended to be overridden
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void newButton_Click(object sender, EventArgs e)
        {

        }
    }
}
