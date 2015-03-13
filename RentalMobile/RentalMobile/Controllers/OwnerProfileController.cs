using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class OwnerProfileController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public OwnerProfileController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }

        public ActionResult Index(int id)
        {
            var owner = _unitOfWork.OwnerRepository.FindBy(x => x.OwnerId == UserHelper.GetOwnerId(id)).FirstOrDefault();
            if (owner == null) return RedirectToAction("Index", "Home");
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }
    }
}
