using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Listing.Specialists
{
    public class SpecialistsController : BaseController
    {
        public SpecialistsController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.SpecialistRepository.All.ToList());
        }
    }
}
