using AdminClient.Controls.Filters;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control that allows users to select a value from a predefined list as a filter criterion.
    /// </summary>
    public partial class EnumerableFilter : UserControl, IFilterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableFilter"/> class.
        /// </summary>
        /// <param name="DisplayName">The display name of the filter.</param>
        /// <param name="filterName">The internal name of the filter.</param>
        /// <param name="values">The collection of values that the user can select from.</param>
        public EnumerableFilter(string DisplayName, string filterName, IEnumerable<string> values)
        {
            InitializeComponent();

            FilterName = filterName;

            // Set the label text
            filterLabel.Text = DisplayName;

            // Add the comparison operators to the combo box
            operand.Items.AddRange(new string[]
            {
                "Is",
                "Is not"
            });

            // Add the values to the combo box
            filterValueComboBox.Items.AddRange(values.ToArray());

            // Set the default operand
            operand.SelectedIndex = 0;

            // Set the default value
            filterValueComboBox.SelectedIndex = 0;
        }


        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// Gets the value of the filter based on the selected item from the combo box.
        /// </summary>
        public string FilterValue
        {
            get
            {
                return filterValueComboBox.Text;
            }
        }

        /// <summary>
        /// Gets the operand selected by the user, indicating the type of comparison to be made.
        /// </summary>
        public string FilterOperand
        {
            get
            {
                return operand.Text;
            }
        }
    }
}
