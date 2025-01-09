using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraitController : GenericController<ITraitService, TraitModel>
    {
        public TraitController(ITraitService traitService) : base(traitService) { }
    }
}
