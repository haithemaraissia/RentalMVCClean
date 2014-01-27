using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Models;
namespace RentalMobile.Controllers
{
    public class ProvidersController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();


        public ViewResult Index(int id)
        {
            var provider = db.MaintenanceProviders.Find(UserHelper.GetProviderID(id));
            ViewBag.providerProfile = provider;
            ViewBag.providerId = provider.MaintenanceProviderId;
            ViewBag.providerGoogleMap = provider.GoogleMap;

            //For Advertismement
            ViewBag.MiddleBannerKeywordFilter = Advertisement.MiddleBanner("11", "2");
           // For Advertismement

            return View(provider);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
