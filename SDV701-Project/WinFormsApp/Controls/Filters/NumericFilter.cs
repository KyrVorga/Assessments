using AdminClient.Controls.Filters;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control that allows users to select a numeric value as a filter criterion.
    /// </summary>
    public partial class NumericFilter : UserControl, IFilterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFilter"/> class.
        /// </summary>
        /// <param name="DisplayName">The display name of the filter.</param>
        /// <param name="filterName">The internal name of the filter.</param>
        public NumericFilter(string DisplayName, string filterName)
        {
            InitializeComponent();

            FilterName = filterName;

            // Set the label text
            filterLabel.Text = DisplayName;

            // Add the comparison operators to the combo box
            operand.Items.AddRange(new string[] {
                "Less than or equal",
                "Not equal",
                "Less than",
                "Greater than",
                "Greater than or equal",
                "Equal"
            });
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
        /// Gets the operand selected by the user, indicating the type of numeric comparison to be made.
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
