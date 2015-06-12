using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Listing.ProviderProfile
{
    public class ProvidersController : BaseController
    {
        public ProvidersController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.MaintenanceProviderRepository.All.ToList());
        }
    }
}
