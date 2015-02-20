using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    public class TenantProfileController : Controller
    {
        private readonly RentalContext _db = new RentalContext();

        public ViewResult Index(int id)
        {
            var tenant = _db.Tenants.Find(UserHelper.GetTenantId(id));
            ViewBag.TenantProfile = tenant;
            ViewBag.TenantId = tenant.TenantId;
            ViewBag.TenantGoogleMap = tenant.GoogleMap;
            return View(tenant);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
