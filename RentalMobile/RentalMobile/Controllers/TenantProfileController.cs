using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class TenantProfileController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public TenantProfileController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index(int id)
        {
            var tenant = _unitOfWork.TenantRepository.FindBy(x => x.TenantId == UserHelper.GetTenantId(id)).FirstOrDefault();
            if (tenant == null) return RedirectToAction("Index", "Home");
            ViewBag.TenantId = tenant.TenantId;
            ViewBag.TenantGoogleMap = tenant.GoogleMap;
            return View(tenant);
        }
    }
}
