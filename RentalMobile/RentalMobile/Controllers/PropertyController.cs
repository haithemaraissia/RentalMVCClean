using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Json;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class PropertyController : BaseController
    {
        public PropertyController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }


        public ActionResult Index(int id)
        {

            var unit = UnitofWork.UnitRepository.FindBy(x => x.UnitId == id).FirstOrDefault() ??
                       UnitofWork.UnitRepository.FindBy(x => x.UnitId == 1).First();
            ViewBag.UnitId = unit.UnitId;
            ViewBag.UnitGoogleMap = unit.GoogleMap;
            ViewBag.Sript = FancyBox.FancyUnit(id);

            //Complete these fields//
            var url = "url";
            var primaryimagethumbnail = "primaryimagethumbnail";
            var title = "title";
            var summary = "summary";

            var tweet = "tweet";
            var sitename = "noDescidedyet";
            //Complete these fields//

            var socialHelper = new SocialHelper();
            ViewBag.FaceBook = socialHelper.FacebookShare(url, primaryimagethumbnail, title, summary);
            ViewBag.Twitter = socialHelper.TwitterShare(tweet);
            ViewBag.GooglePlusShare = socialHelper.GooglePlusShare(url);
            ViewBag.LinkedIn = socialHelper.LinkedInShare(url, title, summary, sitename);
            return View(unit);
        }


        public ActionResult ShareonFacebook()
        {
            var facebookHelper = new Helpers.Facebook();
            facebookHelper.CheckAuthorization();
            return Content("Success", "text/plain");
        }


        public ActionResult JsonFun(int id)
        {
            var data = new List<UnitGalleryJsonData>();
            var unitGallery = UnitofWork.UnitGalleryRepository.FindBy(x => x.UnitId == id).AsQueryable();
            if (unitGallery.Count() != 0)
            {
                data.AddRange(unitGallery.Select(photo => new UnitGalleryJsonData { href = photo.Path, title = photo.Caption }));
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
