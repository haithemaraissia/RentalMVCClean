using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class OwnerProfileController : Controller
    {
        private RentalContext db = new RentalContext();


        public ViewResult Index(int id)
        {
            var Owner = db.Owners.Find(UserHelper.GetOwnerId(id));
            ViewBag.OwnerProfile = Owner;
            ViewBag.OwnerId = Owner.OwnerId;
            ViewBag.OwnerGoogleMap = Owner.GoogleMap;
            return View(Owner);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
