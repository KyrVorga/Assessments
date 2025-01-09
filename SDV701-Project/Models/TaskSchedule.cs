using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskSchedule
    {
        public TaskModel Task { get; set; }
        public IEnumerable<ScheduleModel> Schedules { get; set; }
    }
}
