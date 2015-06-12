using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PublicProfile
{
    public class TenantProfileController : BaseController
    {
        public TenantProfileController(IGenericUnitofWork uow, IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ActionResult Index(int id)
        {
            var tenant = UserHelper.TenantPublicProfileHelper.GetPublicProfileTenantByTenantId(id);
            if (tenant == null) return RedirectToAction("Index", "Home");
            ViewBag.TenantId = tenant.TenantId;
            ViewBag.TenantGoogleMap = tenant.GoogleMap;
            return View(tenant);
        }
    }
}
