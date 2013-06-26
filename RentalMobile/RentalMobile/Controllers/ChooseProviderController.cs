using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class ChooseProviderController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();


        public ViewResult Index(int id)
        {
            var provider = db.MaintenanceProviders.Find(UserHelper.GetProviderID(id));
            ViewBag.providerProfile = provider;
            ViewBag.providerId = provider.MaintenanceProviderId;
            ViewBag.providerGoogleMap = provider.GoogleMap;
            


            //If Tenant is log on
            var tenant = db.Tenants.Find(UserHelper.GetTenantID());
            ViewBag.TenantName = tenant.FirstName + " " + tenant.LastName;
            ViewBag.TenantEmail = tenant.EmailAddress;
          

            //Tenant Telephone not required

            return View(provider);
        }


        public ActionResult Hire(int id)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
