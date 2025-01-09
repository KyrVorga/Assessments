using Models;
using SharedLibrary;
using System.Data;

namespace AdminClient
{
    /// <summary>
    /// Represents a form for creating or editing a schedule entity.
    /// </summary>
    public partial class ScheduleForm : Form, IEntityForm, ISearchForm
    {
        /// <summary>
        /// Gets or sets the schedule model associated with this form.
        /// </summary>
        public ScheduleModel Schedule { get; set; }

        /// <summary>
        /// Gets or sets the days of the week for the schedule.
        /// </summary>
        public DaysOfWeekEnum? DaysOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the week interval for the schedule.
        /// </summary>
        public int? WeekInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of occurrences after which the schedule ends.
        /// </summary>
        public int? EndAfter { get; set; }

        /// <summary>
        /// Gets or sets the date before which the schedule ends.
        /// </summary>
        public DateTime? EndBefore { get; set; }

        /// <summary>
        /// Gets or sets the days of the month for the schedule.
        /// </summary>
        public string? MonthDays { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleForm"/> class.
        /// </summary>
        public ScheduleForm()
        {
            InitializeComponent();
            PopulateComboBoxes();

            // Set the default values
            frequencyComboBox.SelectedIndex = 0;
            repetitionComboBox.SelectedIndex = 0;

            SetDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleForm"/> class with a specified schedule.
        /// </summary>
        /// <param name="schedule">The schedule to be edited.</param>
        public ScheduleForm(ScheduleModel schedule) : this()
        {

            // Check if the schedule has an ID
            if (schedule.ID != null && schedule.ID > 0)
            {
                frequencyComboBox.Text = schedule.Type;
                repetitionComboBox.Text = schedule.Repetition;
                timePicker.Value = DateTime.Parse(schedule.Time);
                notesTextBox.Text = schedule.Notes;

                if (schedule.Type == "Weekly" || schedule.Type == "CustomWeekly")
                {
                    DaysOfWeek = schedule.DaysOfWeek;

                    var weeklyControl = (CheckedListBox)frequencyPanel.Controls["weeklyCheckedListBox"];
                    SetSelectedDays(weeklyControl, schedule.DaysOfWeek);

                    if (schedule.Type == "CustomWeekly")
                    {
                        WeekInterval = schedule.WeekInterval;
                        var weeklyIntervalControl = (NumericUpDown)frequencyPanel.Controls["weekIntervalNumericUpDown"];
                        weeklyIntervalControl.Value = (decimal)schedule.WeekInterval;
                    }
                }
                else if (schedule.Type == "Monthly")
                {
                    var monthlyControl = (MonthCalendar)frequencyPanel.Controls["monthlyMonthCalendar"];
                    var boldedDates = schedule.MonthDays.Split(',').Select(d => new DateTime(DateTime.Now.Year, DateTime.Now.Month, int.Parse(d))).ToArray();
                    monthlyControl.BoldedDates = boldedDates;
                }

                // Set the repetition controls
                if (schedule.Repetition == "EndAfter")
                {
                    EndAfter = schedule.EndAfter;
                    var endAfterControl = (NumericUpDown)repetitionPanel.Controls["endAfterNumericUpDown"];
                    endAfterControl.Value = (decimal)schedule.EndAfter;
                }
                else if (schedule.Repetition == "EndBefore")
                {
                    EndBefore = schedule.EndBefore;
                    var endBeforeControl = (DateTimePicker)repetitionPanel.Controls["endBeforeDateTimePicker"];
                    endBeforeControl.Value = (DateTime)schedule.EndBefore;
                }
            }
        }

        /// <summary>
        /// Sets the default values for the schedule form fields.
        /// </summary>
        private void SetDefaultValues()
        {
            DaysOfWeek = DaysOfWeekEnum.None;
            WeekInterval = 1;
            EndAfter = 1;
            EndBefore = DateTime.Now;
            MonthDays = "";


        }

        /// <summary>
        /// Populates the combo boxes with available options for frequency and repetition.
        /// </summary>
        private void PopulateComboBoxes()
        {
            frequencyComboBox.Items.AddRange(Enum.GetNames(typeof(FrequencyEnum)));
            repetitionComboBox.Items.AddRange(Enum.GetNames(typeof(RepetitionEnum)));
        }


        /// <summary>
        /// Handles the Save button click event. Validates input and creates or updates the schedule entity.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Create a new schedule model
            var schedule = new ScheduleModel
            {
                Type = frequencyComboBox.Text,
                Repetition = repetitionComboBox.Text,
                Time = timePicker.Value.ToString("HH:mm"),
                Notes = notesTextBox.Text
            };

            // If frequency is daily, weekly or custom weekly,
            // get the respective values from the controls.
            if (frequencyComboBox.Text == "Daily")
            {
                if (repetitionComboBox.Text == "EndAfter")
                {
                    schedule.EndAfter = EndAfter;
                }
                else if (repetitionComboBox.Text == "EndBefore")
                {
                    schedule.EndBefore = EndBefore;
                }
            }
            else if (frequencyComboBox.Text == "CustomWeekly")
            {
                if (repetitionComboBox.Text == "EndAfter")
                {
                    schedule.EndAfter = EndAfter;
                }
                else if (repetitionComboBox.Text == "EndBefore")
                {
                    schedule.EndBefore = EndBefore;
                }
                schedule.DaysOfWeek = DaysOfWeek;

                schedule.WeekInterval = WeekInterval;
            }
            else if (frequencyComboBox.Text == "Weekly")
            {
                if (repetitionComboBox.Text == "EndAfter")
                {
                    schedule.EndAfter = EndAfter;
                }
                else if (repetitionComboBox.Text == "EndBefore")
                {
                    schedule.EndBefore = EndBefore;
                }

                schedule.DaysOfWeek = DaysOfWeek;

            }
            else if (frequencyComboBox.Text == "Monthly")
            {
                if (repetitionComboBox.Text == "EndAfter")
                {
                    schedule.EndAfter = EndAfter;
                }
                else if (repetitionComboBox.Text == "EndBefore")
                {
                    schedule.EndBefore = EndBefore;
                }
                var monthlyControl = (MonthCalendar)frequencyPanel.Controls["monthlyMonthCalendar"];
                schedule.MonthDays = string.Join(",", monthlyControl.BoldedDates.Select(d => d.Day));
            }

            Schedule = schedule;

            SetDefaultValues();
            DialogResult = DialogResult.OK;
            Close();
        }


        /// <summary>
        /// Handles the Cancel button click event. Closes the form without saving.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles changes in the frequency combo box selection. Updates the UI accordingly.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void frequencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            frequencyPanel.Controls.Clear();

            switch (frequencyComboBox.Text)
            {
                case "Daily":
                    AddDailyControls();
                    break;
                case "Weekly":
                    AddWeeklyControls();
                    break;
                case "CustomWeekly":
                    AddCustomWeeklyControls();
                    break;
                case "Monthly":
                    AddMonthlyControls();
                    break;
            }
        }        
        
        /// <summary>
        /// Retrieves the selected days of the week from the weekly control.
        /// </summary>
        /// <param name="weeklyControl">The checked list box containing the days of the week.</param>
        /// <returns>A <see cref="DaysOfWeekEnum"/> value representing the selected days.</returns>
        private DaysOfWeekEnum GetSelectedDays(CheckedListBox weeklyControl)
        {
            // Combine the selected days using bitwise OR
            DaysOfWeekEnum selectedDays = DaysOfWeekEnum.None;
            foreach (var item in weeklyControl.CheckedItems)
            {
                if (Enum.TryParse<DaysOfWeekEnum>(item.ToString(), out var day))
                {
                    selectedDays |= day; // Combine the selected days using bitwise OR
                }
            }
            return selectedDays;
        }

        /// <summary>
        /// Sets the selected days of the week in the weekly control based on the provided <see cref="DaysOfWeekEnum"/>.
        /// </summary>
        /// <param name="weeklyControl">The checked list box to update.</param>
        /// <param name="daysOfWeek">The days of the week to select in the control.</param>
        private void SetSelectedDays(CheckedListBox weeklyControl, DaysOfWeekEnum? daysOfWeek)
        {
            if (daysOfWeek == null)
            {
                return;
            }

            // For each day in the control, set the checked state based on the selected days
            for (int i = 0; i < weeklyControl.Items.Count; i++)
            {
                var dayName = weeklyControl.Items[i].ToString();
                if (Enum.TryParse<DaysOfWeekEnum>(dayName, out var dayEnum))
                {
                    if (daysOfWeek.Value.HasFlag(dayEnum))
                    {
                        weeklyControl.SetItemChecked(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// Adds controls to the frequency panel for daily frequency selection.
        /// </summary>
        private void AddDailyControls()
        {
            frequencyPanel.Controls.Clear();
        }

        /// <summary>
        /// Adds controls to the frequency panel for weekly frequency selection.
        /// </summary>
        private void AddWeeklyControls()
        {
            frequencyPanel.Controls.Clear();

            var weeklyControl = new CheckedListBox();
            weeklyControl.Name = "weeklyCheckedListBox";
            weeklyControl.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            frequencyPanel.Controls.Add(weeklyControl);

            // set the values of the checked items
            SetSelectedDays(weeklyControl, DaysOfWeek);

            // bind the on change event
            weeklyControl.ItemCheck += weeklyControl_ItemCheck;
        }

        /// <summary>
        /// Adds controls to the frequency panel for custom weekly frequency selection, including a numeric up down for week interval.
        /// </summary>
        private void AddCustomWeeklyControls()
        {
            AddWeeklyControls(); // Add the same controls as Weekly

            var intervalControl = new NumericUpDown();
            intervalControl.Name = "weekIntervalNumericUpDown";
            intervalControl.Minimum = 1;
            intervalControl.Maximum = 52;
            frequencyPanel.Controls.Add(intervalControl);

            // Set the values
            intervalControl.Value = (decimal)WeekInterval;

            // bind the on change event
            intervalControl.ValueChanged += weekIntervalNumericUpDown_ValueChanged;
        }

        /// <summary>
        /// Adds controls to the frequency panel for monthly frequency selection.
        /// </summary>
        private void AddMonthlyControls()
        {
            frequencyPanel.Controls.Clear();

            var monthlyControl = new MonthCalendar();
            monthlyControl.Name = "monthlyMonthCalendar";
            monthlyControl.MaxSelectionCount = 31;

            frequencyPanel.Controls.Add(monthlyControl);
        }

        /// <summary>
        /// Handles changes in the repetition combo box selection. Updates the UI accordingly.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public void AddRepetitionControls()
        {
            repetitionPanel.Controls.Clear();

            if (repetitionComboBox.Text == "EndAfter")
            {
                var endAfterControl = new NumericUpDown();
                endAfterControl.Name = "endAfterNumericUpDown";
                endAfterControl.Minimum = 1;
                endAfterControl.Maximum = 1000;

                // Create a label for the numeric up down
                var label = new Label();
                label.Text = "End after how many times?";

                repetitionPanel.Controls.Add(label);
                repetitionPanel.Controls.Add(endAfterControl);

                // set the value
                endAfterControl.Value = (decimal)EndAfter;

                // bind the on change event
                endAfterControl.ValueChanged += endAfterNumericUpDown_ValueChanged;
            }
            else if (repetitionComboBox.Text == "EndBefore")
            {
                var endBeforeControl = new DateTimePicker();
                endBeforeControl.Name = "endBeforeDateTimePicker";
                endBeforeControl.Format = DateTimePickerFormat.Custom;
                endBeforeControl.CustomFormat = "dd/MM/yyyy";

                // Create a label for the date picker
                var label = new Label();
                label.Text = "End before when?";

                repetitionPanel.Controls.Add(label);
                repetitionPanel.Controls.Add(endBeforeControl);

                // set the value
                endBeforeControl.Value = (DateTime)EndBefore;

                // bind the on change event
                endBeforeControl.ValueChanged += endBeforeDateTimePicker_ValueChanged;
            }

        }

        /// <summary>
        /// Handles item check events for the weekly control. Updates the selected days based on user selection.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the index and new check state of the item.</param>
        private void weeklyControl_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var weeklyControl = (CheckedListBox)sender;
            var selectedDays = GetSelectedDays(weeklyControl);

            // Update the selected days
            if (e.NewValue == CheckState.Checked)
            {
                if (Enum.TryParse<DaysOfWeekEnum>(weeklyControl.Items[e.Index].ToString(), out var day))
                {
                    selectedDays |= day;
                }
            }
            else
            {
                if (Enum.TryParse<DaysOfWeekEnum>(weeklyControl.Items[e.Index].ToString(), out var day))
                {
                    selectedDays &= ~day;
                }
            }

            DaysOfWeek = selectedDays;
        }

        /// <summary>
        /// Handles value changed events for the week interval numeric up down control. Updates the week interval based on user input.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void weekIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            WeekInterval = (int)((NumericUpDown)sender).Value;
        }


        /// <summary>
        /// Handles value changed events for the end after numeric up down control. Updates the end after value based on user input.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void endAfterNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EndAfter = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>
        /// Handles value changed events for the end before date time picker control. Updates the end before date based on user selection.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void endBeforeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndBefore = ((DateTimePicker)sender).Value;
        }

        private void repetitionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddRepetitionControls();
        }

        /// <summary>
        /// Returns the API client associated with this form. Not implemented.
        /// </summary>
        /// <returns>The API client.</returns>
        public object GetAPIClient()
        {
            throw new NotImplementedException();
        }
    }
}
