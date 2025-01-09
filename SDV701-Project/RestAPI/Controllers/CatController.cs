using BusinessLayer;
using Models;

namespace RestAPI.Controllers
{
    public class CatController : GenericController<ICatService, CatModel>
    {
        public CatController(ICatService catService) : base(catService)
        {
        }
    }
}
