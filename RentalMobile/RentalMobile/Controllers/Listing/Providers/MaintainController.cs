using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Listing.Providers
{
    public class MaintainController : BaseController
    {
        public MaintainController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.MaintenanceProviderRepository.All.ToList());
        }
    }
}
