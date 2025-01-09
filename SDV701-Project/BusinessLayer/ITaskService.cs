using Models;
using SharedLibrary;

namespace BusinessLayer
{
    public interface ITaskService : IService<TaskModel>
    {
        int Add(TaskModel taskModel, IEnumerable<ScheduleModel> schedulesModels);
        IList<TimelineEvent> GetTimelineEvents(List<int> taskIds = null);
        int Update(TaskModel taskModel, IEnumerable<ScheduleModel> schedulesModels);
    }
}