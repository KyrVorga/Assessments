using SharedLibrary;

namespace DataAccessLayer.Models
{
    public partial class Task
    {
        public Task()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string? Measurement { get; set; }
        public DateTime? TaskDate { get; set; }
        public string? Notes { get; set; }
        public int? PetID { get; set; }
        public Pet? Pet { get; set; }
        public virtual ICollection<Schedule>? Schedules { get; set; }

        public MeasurementEnum GetMeasurementType()
        {
            return (MeasurementEnum)Enum.Parse(typeof(MeasurementEnum), Measurement);
        }

        public void SetMeasurementType(MeasurementEnum type)
        {
            Measurement = type.ToString();
        }

        public TaskTypeEnum GetTaskType()
        {
            return (TaskTypeEnum)Enum.Parse(typeof(TaskTypeEnum), Type);
        }

        public void SetTaskType(TaskTypeEnum type)
        {
            Type = type.ToString();
        }
    }
}
