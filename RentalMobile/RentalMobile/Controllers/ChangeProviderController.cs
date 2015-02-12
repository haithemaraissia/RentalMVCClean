using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class ChangeProviderController : Controller
    {
        private readonly RentalContext db = new RentalContext();


        public ViewResult Index(int id)
        {
            var provider = db.MaintenanceProviders.Find(UserHelper.GetProviderId(id));
            ViewBag.providerProfile = provider;
            ViewBag.providerId = provider.MaintenanceProviderId;
            ViewBag.providerGoogleMap = provider.GoogleMap;
            return View(provider);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
