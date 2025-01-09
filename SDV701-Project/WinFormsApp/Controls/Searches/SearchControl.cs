using Models;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents the base class for search controls used to display and interact with a collection of entities.
    /// </summary>
    public partial class SearchControl : UserControl
    {
        /// <summary>
        /// Holds the collection of entities displayed by the control.
        /// </summary>
        protected IEnumerable<IEntityModel> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchControl"/> class.
        /// </summary>
        public SearchControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieves the entity selected by the user in the UI.
        /// </summary>
        /// <returns>The selected entity, or null if no entity is selected.</returns>
        public object GetSelectedEntity()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return null;
            }

            // Get the ID of the selected entity
            var selectedEntityID = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

            // Return the original Model object with the selected ID
            return entities.FirstOrDefault(entity => entity.ID == selectedEntityID);
        }
    }
}
