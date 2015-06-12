using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Listing.Owners
{
    public class OwnersController : BaseController
    {
        public OwnersController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.OwnerRepository.All.ToList());
        }
    }
}
