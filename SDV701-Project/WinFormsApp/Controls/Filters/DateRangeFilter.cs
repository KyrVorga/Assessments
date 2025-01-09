using AdminClient.Controls.Filters;

namespace AdminClient.Controls
{
    /// <summary>
    /// Represents a control that allows users to select a date range as a filter criterion.
    /// </summary>
    public partial class DateRangeFilter : UserControl, IFilterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateRangeFilter"/> class.
        /// </summary>
        /// <param name="DisplayName">The display name of the filter.</param>
        public DateRangeFilter(string DisplayName, string filterName)
        {
            InitializeComponent();

            // Set the label text
            displayLabel.Text = DisplayName;

            FilterName = filterName;

            operand.Items.AddRange(new string[]
            {
                "Within range",
                "Outside range",
                "Before",
                "After",
            });
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the operand ComboBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void operand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var showSecondDate = operand.SelectedItem.ToString() == "Within range" || operand.SelectedItem.ToString() == "Outside range";
            // Show or hide the second DateTimePicker control based on the selected option
            TimeUntil.Visible = showSecondDate;
            joiningLabel.Visible = showSecondDate;
        }

        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        public string FilterValue
        {
            get
            {
                return TimeFrom.Value.ToString("yyyy-MM-dd") + (TimeUntil.Visible ? "_" + TimeUntil.Value.ToString("yyyy-MM-dd") : "").Trim();
            }
        }

        /// <summary>
        /// Gets or sets the name of the filter.
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
