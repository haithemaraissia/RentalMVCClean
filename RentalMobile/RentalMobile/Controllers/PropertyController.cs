using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Json;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class PropertyController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public PropertyController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }


        public ActionResult Index(int id)
        {

            var unit = _unitOfWork.UnitRepository.FindBy(x => x.UnitId == id).FirstOrDefault() ??
                       _unitOfWork.UnitRepository.FindBy(x => x.UnitId == 1).First();
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

            ViewBag.FaceBook = SocialHelper.FacebookShare(url,primaryimagethumbnail,title,summary);
            ViewBag.Twitter = SocialHelper.TwitterShare(tweet);
            ViewBag.GooglePlusShare = SocialHelper.GooglePlusShare(url);
            ViewBag.LinkedIn = SocialHelper.LinkedInShare(url, title, summary, sitename);
            return View(unit);
        }


        public ActionResult ShareonFacebook()
        {
            Helpers.Facebook.CheckAuthorization();
            return Content("Success", "text/plain");
        }


        public ActionResult JsonFun(int id)
        {
            var data = new List<UnitGalleryJsonData>();
            IQueryable<UnitGallery> unitGallery = _unitOfWork.UnitGalleryRepository.FindBy(x => x.UnitId == id).AsQueryable();
            if (unitGallery.Count() != 0)
            {
                data.AddRange(unitGallery.Select(photo => new UnitGalleryJsonData { href = photo.Path, title = photo.Caption }));
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}
