using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IScheduleRepository
    {
        Schedule Get(int scheduleID);
        List<Schedule> GetAll();
    }
}