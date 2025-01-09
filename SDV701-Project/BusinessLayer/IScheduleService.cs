using Models;

namespace BusinessLayer
{
    public interface IScheduleService : IService<ScheduleModel>
    {
        List<ScheduleModel> GetTaskSchedules(int taskID);
    }
}