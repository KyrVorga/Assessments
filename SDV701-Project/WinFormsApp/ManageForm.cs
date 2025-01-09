using AdminClient.Controls;
using Models;
using WinFormsApp;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for managing various entities such as clients, cats, birds, etc.
    /// </summary>
    public partial class ManageForm : ManageBaseForm
    {
        /// <summary>
        /// Represents a factory delegate for creating entity forms.
        /// </summary>
        /// <param name="entity">The entity for which to create the form.</param>
        /// <returns>An instance of a form for the specified entity.</returns>
        public delegate IEntityForm EntityFormFactory(object entity);

        private readonly Dictionary<Type, EntityFormFactory> _entityFormFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageForm"/> class.
        /// </summary>
        public ManageForm()
        {
            InitializeComponent();

            _entityFormFactories = new Dictionary<Type, EntityFormFactory>
           {
                { typeof(ClientModel), entity => new ClientForm(entity as ClientModel) },
                { typeof(CatModel), entity => new CatForm(entity as CatModel) },
                { typeof(BirdModel), entity => new BirdForm(entity as BirdModel) },
                { typeof(BookingModel), entity => new BookingForm(entity as BookingModel) },
                { typeof(RoomModel), entity => new RoomForm(entity as RoomModel) },
                { typeof(TaskModel), entity => new TaskForm(entity as TaskModel) },
                { typeof(VeterinarianModel), entity => new VeterinarianForm(entity as VeterinarianModel) }
           };
        }

        /// <summary>
        /// Handles the modify entity button click event. Opens a form for modifying the selected entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void modifyEntityButton_Click(object sender, EventArgs e)
        {
            var selectedEntity = GetSelectedEntity();
            if (selectedEntity == null)
            {
                MessageBox.Show("Please select an entity to modify");
                return;
            }

            if (_entityFormFactories.TryGetValue(selectedEntity.GetType(), out var formFactory))
            {
                var modifyForm = (Form)formFactory(selectedEntity);
                modifyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No form available for the selected type of item.");
            }
            LoadEntities();
        }

        /// <summary>
        /// Handles the new entity button click event. Opens a form for creating a new entity of the selected type.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void newEntityButton_Click(object sender, EventArgs e)
        {
            // Get the selected entity type from the entity selector
            var selectedEntityTypeName = entitySelector.SelectedItem.ToString();

            // Get the actual type from the dictionary
            if (!_entityTypeMappings.TryGetValue(selectedEntityTypeName, out var selectedEntityType))
            {
                MessageBox.Show("Please select a valid entity type");
                return;
            }

            // Get the form factory for the selected entity type
            if (_entityFormFactories.TryGetValue(selectedEntityType, out var formFactory))
            {
                // Create a new form for the selected entity type
                var newForm = (Form)formFactory(Activator.CreateInstance(selectedEntityType));
                var result = newForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadEntities();
                }
            }
            else
            {
                MessageBox.Show("No form available for the selected type of entity.");
            }
        }

        /// <summary>
        /// Handles the delete entity button click event. Deletes the selected entity after confirmation.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void deleteEntityButton_Click(object sender, EventArgs e)
        {
            // Get the selected entity
            var selectedEntity = GetSelectedEntity();
            if (selectedEntity == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            // show a confirmation dialog
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Unable to delete this type of item.");
            }

            // Get the type of the selected entity
            var entityType = selectedEntity.GetType();

            // Get the API client type for the selected entity
            if (_apiClientTypeMapping.TryGetValue(entityType, out var apiClientType))
            {
                // Use reflection to create an instance of the IAPIClient<TModel>
                var apiClient = Activator.CreateInstance(apiClientType, new object[] { Program.Configuration, new HttpClient() }) as dynamic;


                if (apiClient != null)
                {
                    // Cast the selected entity to the correct type
                    var castedEntity = (IEntityModel)selectedEntity;

                    // Delete the entity
                    var result = await apiClient.DeleteAsync(castedEntity.ID);
                    if (result)
                    {
                        MessageBox.Show("Item deleted successfully.");
                        LoadEntities();
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete the item.");
                    }
                }
                else
                {
                    MessageBox.Show("API client instantiation failed.");
                }
            }
            else
            {
                MessageBox.Show("No API client available for the selected type of item.");
            }
        }

        protected virtual void applyFiltersbutton_Click(object sender, EventArgs e)
        {
            var filters = FilterPanel().GetFilters();

            LoadEntities(filters);
            return;
        }
    }
}
