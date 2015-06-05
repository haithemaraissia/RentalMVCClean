using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class RentController : BaseController
    {
        public RentController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }
        public ActionResult Index()
        {
            return View(UnitofWork.UnitRepository.AllIncluding(x => x.UnitPricing).ToList());
        }

    }
}
