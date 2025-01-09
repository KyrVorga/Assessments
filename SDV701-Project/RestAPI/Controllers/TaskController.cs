using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using SharedLibrary;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : GenericController<ITaskService, TaskModel>
    {
        public TaskController(ITaskService taskService) : base(taskService) { }

        // POST api/task/schedules
        [HttpPost("schedules")]
        public int Add([FromBody] TaskSchedule taskSchedule)
        {
            return Service.Add(taskSchedule.Task, taskSchedule.Schedules);
        }

        // PUT api/task/schedules
        [HttpPut("schedules")]
        public virtual int Put([FromBody] TaskSchedule taskSchedule)
        {
            return Service.Update(taskSchedule.Task, taskSchedule.Schedules);
        }

        // GET api/task/timeline
        [HttpGet("timeline")]
        public virtual IList<TimelineEvent> GetTimelineEvents([FromQuery] List<int> taskIds = null)
        {

            return Service.GetTimelineEvents(taskIds);
        }
    }
}
