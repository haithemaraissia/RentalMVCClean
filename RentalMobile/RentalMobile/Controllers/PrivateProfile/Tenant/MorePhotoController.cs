using System.Globalization;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Tenant
{

    [Authorize(Roles = "Tenant")]
    public class MorePhotoController : BaseController
    {
        public MorePhotoController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ActionResult Index(int id)
        {
            if (UserHelper.TenantPrivateProfileHelper.GetMaintenanceOrderByMaintenanceIdPlacedByTenant(id) == null)
            {
                RedirectToAction("Index", "TenantMaintenance");
            }
            UserHelper.TenantPrivateProfileHelper.RequestId = id.ToString(CultureInfo.InvariantCulture);
            ViewBag.UserName = UserHelper.TenantPrivateProfileHelper.TenantPrivateProfileUsername();
            ViewBag.Type = UserHelper.TenantPrivateProfileHelper.RequestType;
            ViewBag.Id = UserHelper.TenantPrivateProfileHelper.RequestId;
            TempData["RequestID"] = UserHelper.TenantPrivateProfileHelper.RequestId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            UserHelper.TenantPrivateProfileHelper.AddTenantRequestPictures("RequestID");
            return RedirectToAction("Index", "TenantMaintenance");
        }
    }
}
