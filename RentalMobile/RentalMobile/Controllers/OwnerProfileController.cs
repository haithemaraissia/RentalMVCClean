using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class OwnerProfileController : BaseController
    {
        public OwnerProfileController(IGenericUnitofWork uow, IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ActionResult Index(int id)
        {
            var owner = UserHelper.OwnerPublicProfileHelper.GetPublicProfileOwnerByOwnerId(id);
            if (owner == null) return RedirectToAction("Index", "Home");
            ViewBag.OwnerId = owner.OwnerId;
            ViewBag.OwnerGoogleMap = owner.GoogleMap;
            return View(owner);
        }
    }
}
