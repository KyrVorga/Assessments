using Models;

namespace AdminClient.Controls.Collections
{
    public partial class ScheduleCollectionControl : EntityCollectionControl<ScheduleModel, ScheduleForm, ScheduleForm>
    {

        public ScheduleCollectionControl() : base()
        {
            InitializeComponent();
            UpdateDisplayText("Entities");

            _entityForm = new ScheduleForm();
            _entityEditForm = new ScheduleForm();
            Entities = new List<ScheduleModel>();
        }

        protected override void AddEntity()
        {
            // Open the new Schedule form
            var result = OpenEntityForm();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Get the selected entity from the search form
            var selectedEntity = _entityForm.Schedule;

            // Check if the selected entity is already in the list
            if (selectedEntity != null && Entities.Any(e => e.ID == selectedEntity.ID))
            {
                MessageBox.Show("Schedule already exists in the list.");
                return;
            }
            // Add the item to the list
            Entities.Add(selectedEntity);
        }

        protected override void UpdateEntity(ScheduleModel selectedEntity)
        {
            // Open the entity form
            DialogResult result = OpenEntityForm(selectedEntity);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Set the ID of the new Schedule to the ID of the old Schedule
            _entityForm.Schedule.ID = selectedEntity.ID;

            // Maintain the same OwnerID
            _entityForm.Schedule.OwnerID = selectedEntity.OwnerID;

            // Update the item in the list
            Entities.Remove(selectedEntity);
            Entities.Add(_entityForm.Schedule);
        }
        protected DialogResult OpenEntityForm(ScheduleModel selectedEntity)
        {
            // Open the edit Schedule form
            _entityEditForm = new ScheduleForm(selectedEntity);
            return _entityEditForm.ShowDialog();
        }

        protected DialogResult OpenEntityForm()
        {
            _entityForm = new ScheduleForm();
            return _entityForm.ShowDialog();
        }
    }
}
