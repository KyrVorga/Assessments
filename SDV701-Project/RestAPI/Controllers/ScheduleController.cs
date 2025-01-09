using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : GenericController<IScheduleService, ScheduleModel>
    {
        public ScheduleController(IScheduleService scheduleService) : base(scheduleService) { }

        // GET api/schedule/task/5
        [HttpGet("task/{taskID}")]
        public virtual IList<ScheduleModel> GetTaskSchedules(int taskID)
        {
            return Service.GetTaskSchedules(taskID);
        }
    }
}
