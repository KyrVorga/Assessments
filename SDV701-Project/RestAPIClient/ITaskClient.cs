using Models;
using SharedLibrary;

namespace RestAPIClient
{
    public interface ITaskClient : IAPIClient<TaskModel>
    {
        Task<IList<TimelineEvent>> GetTimelineEventsAsync(List<int> taskIds = null);
    }
}