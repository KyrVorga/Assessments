using BusinessLayer;
using Models;

namespace RestAPI.Controllers
{
    public class RoomController : GenericController<IRoomService, RoomModel>
    {
        public RoomController(IRoomService roomService) : base(roomService)
        {
        }
    }
}
