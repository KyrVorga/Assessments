using AdminClient.Controls.Filters;
using SharedLibrary;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a panel that allows users to dynamically add and configure filters for different entities.
    /// </summary>
    public partial class FiltersPanel : UserControl
    {
        private Dictionary<string, Action> _filterActions;


        /// <summary>
        /// Gets or sets the filter actions available for the current entity.
        /// </summary>
        /// <value>A dictionary where keys are filter names and values are actions to add the filter control.</value>
        public Dictionary<string, Action> FilterActions
        {
            get { return _filterActions; }
            set
            {
                _filterActions = value;
                if (_filterActions != null)
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(_filterActions.Keys.ToArray());
                    comboBox1.SelectedIndex = 0;
                }
            }
        }
        private readonly Dictionary<string, Dictionary<string, Action>> filterActionsByEntity;

        private int filterControlY;
        private readonly int filterControlX;


        /// <summary>
        /// Initializes a new instance of the <see cref="FiltersPanel"/> class.
        /// </summary>
        public FiltersPanel()
        {
            InitializeComponent();

            // Initialize the position of the first filter control
            filterControlY = 10;
            filterControlX = 10;

            // Attach the event handler to the "+" button
            button1.Click += (sender, e) => AddFilter();

            // Get the enumerators from the shared library
            var qualities = Enum.GetNames(typeof(QualityEnum)).ToList();
            var statuses = Enum.GetNames(typeof(StatusEnum)).ToList();
            var sizes = Enum.GetNames(typeof(SizeEnum)).ToList();
            var petSexes = Enum.GetNames(typeof(PetSexEnum)).ToList();

            List<string> bools = new List<string>
            {
                "Yes",
                "No"
            };

            // Define filter actions for each entity type
            filterActionsByEntity = new Dictionary<string, Dictionary<string, Action>>
            {
                ["Client"] = new Dictionary<string, Action>
                {
                    { "Name", () => AddFilterControl(new TextFilter("Name", "Name")) },
                    { "Email", () => AddFilterControl(new TextFilter("Email", "Email")) },
                    { "Phone", () => AddFilterControl(new TextFilter("Phone", "Phone")) },
                },
                ["Booking"] = new Dictionary<string, Action>
                {
                    { "Check In", () => AddFilterControl(new DateRangeFilter("Check In Date", "Check In")) },
                    { "Check Out", () => AddFilterControl(new DateRangeFilter("Check Out Date", "Check Out")) },
                    { "Room", () => AddFilterControl(new NumericFilter("Room Number", "Room")) },
                    { "Pet", () => AddFilterControl(new TextFilter("Pet Name", "Pet")) },
                    { "Client", () => AddFilterControl(new TextFilter("Client Name", "Client")) },
                },
                ["Cat"] = new Dictionary<string, Action>
                {
                    { "Name", () => AddFilterControl(new TextFilter("Name", "Name")) },
                    { "Type", () => AddFilterControl(new TextFilter("Type", "Type")) },
                    { "Breed", () => AddFilterControl(new TextFilter("Breed", "Breed")) },
                    { "Colour", () => AddFilterControl(new TextFilter("Colour", "Colour")) },
                },
                ["Bird"] = new Dictionary<string, Action>
                {
                    { "Name", () => AddFilterControl(new TextFilter("Name", "Name")) },
                    { "Type", () => AddFilterControl(new TextFilter("Type", "Type")) },
                    { "Species", () => AddFilterControl(new TextFilter("Species", "Species")) },
                    { "Colour", () => AddFilterControl(new TextFilter("Colour", "Colour")) },
                },
                ["Room"] = new Dictionary<string, Action>
                {
                    { "Number", () => AddFilterControl(new NumericFilter("Room Number", "Number")) },
                    { "Quality", () => AddFilterControl(new EnumerableFilter("Quality", "Quality", qualities)) },
                    { "Status", () => AddFilterControl(new EnumerableFilter("Status", "Status", statuses)) },
                    { "Size", () => AddFilterControl(new EnumerableFilter("Size", "Size", sizes)) },
                },
                ["Task"] = new Dictionary<string, Action>
                {
                    { "Name", () => AddFilterControl(new TextFilter("Name", "Name")) },
                    { "Type", () => AddFilterControl(new TextFilter("Type", "Type")) },
                    { "Measurement", () => AddFilterControl(new TextFilter("Measurement", "Measurement")) },
                    { "Quantity", () => AddFilterControl(new NumericFilter("Quantity", "Quantity")) }
                },
                ["Veterinarian"] = new Dictionary<string, Action>
                {
                    { "Business", () => AddFilterControl(new TextFilter("Business", "Name")) },
                    { "Email", () => AddFilterControl(new TextFilter("Email", "Email")) },
                    { "Phone", () => AddFilterControl(new TextFilter("Phone", "Phone")) },
                }
            };
        }

        /// <summary>
        /// Retrieves the current set of filters configured by the user.
        /// </summary>
        /// <returns>A dictionary where keys are filter names and values are lists of filter criteria.</returns>
        public Dictionary<string, List<FilterCriteria>> GetFilters()
        {
            var filters = new Dictionary<string, List<FilterCriteria>>();

            var controls = panel1.Controls.OfType<IFilterControl>();

            foreach (var control in controls)
            {
                var filterName = control.FilterName;
                var filterOperand = control.FilterOperand;
                var filterValue = control.FilterValue;

                if (!filters.ContainsKey(filterName))
                {
                    filters[filterName] = new List<FilterCriteria>();
                }

                filters[filterName].Add(new FilterCriteria { FilterName = filterName, Operation = filterOperand, Value = filterValue });
            }
            return filters;
        }

        /// <summary>
        /// Adds a filter control to the panel based on the selected filter type from the dropdown.
        /// </summary>
        private void AddFilter()
        {
            // Get the selected filter type
            string filterType = comboBox1.SelectedItem?.ToString();

            // If a filter type is selected
            if (!string.IsNullOrEmpty(filterType))
            {
                // Find the corresponding action and execute it
                if (FilterActions.TryGetValue(filterType, out Action action))
                {
                    action();
                }
            }
        }

        /// <summary>
        /// Adds a specified filter control to the panel and positions it.
        /// </summary>
        /// <param name="filterControl">The filter control to add to the panel.</param>
        public void AddFilterControl(UserControl filterControl)
        {
            // Add the control to the panel
            panel1.Controls.Add(filterControl);

            // Position the control
            filterControl.Location = new Point(filterControlX, filterControlY);

            // Update the Y position for the next control
            filterControlY += filterControl.Height + 10; // 10 is the margin between controls

            // Bring the control to front
            filterControl.BringToFront();
        }

        /// <summary>
        /// Changes the available filters based on the selected entity.
        /// </summary>
        /// <param name="selectedEntity">The entity for which to display filters.</param>
        public void ChangeFilters(string selectedEntity)
        {
            // Clear existing filter controls
            ClearFilters();

            // Get the filter actions for the selected entity
            if (filterActionsByEntity.TryGetValue(selectedEntity, out var filterActions))
            {
                // Add the filter controls to the ComboBox
                FilterActions = filterActions;
            }
        }

        /// <summary>
        /// Clears all filter controls from the panel.
        /// </summary>
        public void ClearFilters()
        {
            panel1.Controls.Clear();
            filterControlY = 10;
        }
    }
}
