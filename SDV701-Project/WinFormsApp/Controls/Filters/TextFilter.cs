using AdminClient.Controls.Filters;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control that allows users to select a text-based value as a filter criterion.
    /// </summary>
    public partial class TextFilter : UserControl, IFilterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFilter"/> class.
        /// </summary>
        /// <param name="displayName">The display name of the filter.</param>
        /// <param name="filterName">The internal name of the filter.</param>

        public TextFilter(string displayName, string filterName)
        {
            InitializeComponent();

            // Set the label text
            filterLabel.Text = displayName;
            FilterName = filterName;

            // Add the comparison operators to the combo box
            operand.Items.AddRange(new string[]
            {
                "Starts with",
                "Ends with",
                "Contains",
                "Does not contain",
                "Equal"
            });
            // Set the default value
            operand.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// Gets the value of the filter based on the user input.
        /// </summary>
        public string FilterValue
        {
            get
            {
                return filterValue.Text;
            }
        }

        /// <summary>
        /// Gets the operand selected by the user, indicating the type of text comparison to be made.
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
