





using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface ITaskRepository
    {
        Models.Task Get(int taskID);
        List<Models.Task> GetAll();
        void Add(Models.Task task, IEnumerable<Schedule> schedules);
    }
}