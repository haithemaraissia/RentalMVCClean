using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Listing.Agents
{
    public class AgentsController : BaseController
    {
        public AgentsController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.AgentRepository.All.ToList());
        }
    }
}
