using AdminClient.Controls;
using AdminClient.Controls.Searches;
using Models;
using RestAPIClient;

namespace AdminClient
{
    /// <summary>
    /// Provides a base form for managing different types of entities such as Cats, Birds, Clients, etc.
    /// </summary>
    public partial class ManageBaseForm : Form
    {
        /// <summary>
        /// Maps entity names to their respective model types.
        /// </summary>
        protected Dictionary<string, Type> _entityTypeMappings = new Dictionary<string, Type>
        {
            { "Cat", typeof(CatModel) },
            { "Bird", typeof(BirdModel) },
            { "Client", typeof(ClientModel) },
            { "Booking", typeof(BookingModel) },
            { "Room", typeof(RoomModel) },
            { "Task", typeof(TaskModel) },
            { "Veterinarian", typeof(VeterinarianModel) },
            { "Pet", typeof(PetModel) }
        };

        /// <summary>
        /// Maps entity names to functions that create search controls for those entities.
        /// </summary>
        protected Dictionary<string, Func<ISearchControl>> _entityTypes = new Dictionary<string, Func<ISearchControl>>
        {
            { "Cat", () => new CatSearchControl() },
            { "Bird", () => new BirdSearchControl() },
            { "Client", () => new ClientSearchControl()},
            { "Booking", () => new BookingSearchControl() },
            { "Room", () => new RoomSearchControl() },
            { "Task", () => new TaskSearchControl() },
            { "Veterinarian", () => new VeterinarianSearchControl() },
            { "Pet", () => new PetSearchControl() }
        };

        /// <summary>
        /// Maps model types to their respective API client types.
        /// </summary>
        protected Dictionary<Type, Type> _apiClientTypeMapping = new Dictionary<Type, Type>
        {
            { typeof(ClientModel), typeof(ClientClient) },
            { typeof(CatModel), typeof(CatClient) },
            { typeof(BirdModel), typeof(BirdClient) },
            { typeof(BookingModel), typeof(BookingClient) },
            { typeof(RoomModel), typeof(RoomClient) },
            { typeof(TaskModel), typeof(TaskClient) },
            { typeof(VeterinarianModel), typeof(VeterinarianClient) },
            { typeof(PetModel), typeof(PetClient) }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageBaseForm"/> class.
        /// </summary>
        public ManageBaseForm()
        {
            InitializeComponent();
            PopulateEntitySelector();
        }

        /// <summary>
        /// Populates the entity selector with available entity types.
        /// </summary>
        private void PopulateEntitySelector()
        {
            entitySelector.Items.AddRange(_entityTypes.Keys.ToArray());
        }
        /// <summary>
        /// Gets the filter panel control.
        /// </summary>
        /// <returns>The filter panel control on the form</returns>
        protected FiltersPanel FilterPanel()
        {
            return filtersPanelControl;
        }

        /// <summary>
        /// Handles the event when the selected entity in the entity selector changes.
        /// Updates the filter controls and search control based on the selected entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void entitySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEntity = entitySelector.SelectedItem.ToString();
            UpdateFilterControls(selectedEntity);
            UpdateSearchControl(selectedEntity);
        }

        /// <summary>
        /// Updates the search control to match the selected entity.
        /// </summary>
        /// <param name="selectedEntity">The entity selected by the user.</param>
        private void UpdateSearchControl(string selectedEntity)
        {
            // Get the selected entity's search control
            var searchControlCreator = _entityTypes[selectedEntity];
            var searchControl = searchControlCreator?.Invoke();

            if (searchControl != null)
            {
                //delete the current search control
                searchPanel.Controls.Clear();
                searchPanel.Controls.Add((UserControl)searchControl);
                searchControl.InitializeAPIClients();
                searchControl.LoadEntities();
            }
        }

        /// <summary>
        /// Updates the filter controls based on the selected entity.
        /// </summary>
        /// <param name="selectedEntity">The entity selected by the user.</param>
        public void UpdateFilterControls(string selectedEntity)
        {
            // Clear existing filter controls
            filtersPanelControl.ClearFilters();
            // Update the filters in the combo box
            filtersPanelControl.ChangeFilters(selectedEntity);
        }

        /// <summary>
        /// Gets the entity currently selected in the search control.
        /// </summary>
        /// <returns>The selected entity.</returns>
        public virtual object GetSelectedEntity()
        {
            var searchControl = (ISearchControl)searchPanel.Controls[0];
            return searchControl.GetSelectedEntity();
        }

        /// <summary>
        /// Sets the entity selector to a specific entity.
        /// </summary>
        /// <param name="entity">The entity to select.</param>
        public virtual void SetEntitySelector(string entity)
        {
            entitySelector.SelectedItem = entity;
        }

        /// <summary>
        /// Disables the entity selector control.
        /// </summary>
        public void DisableEntitySelector()
        {
            entitySelector.Enabled = false;
        }

        /// <summary>
        /// Loads the entities into the search control.
        /// </summary>
        public void LoadEntities(Dictionary<string, List<FilterCriteria>> filters = null)
        {
            var searchControl = (ISearchControl)searchPanel.Controls[0];
            searchControl.LoadEntities(filters);
        }
    }
}
