using System;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.WIP.Unit
{
    public class UnitController : BaseController
    {
        #region Main

        public UnitController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ActionResult Index()
        {
            return View(UnitofWork.UnitRepository.AllIncluding(x=>x.UnitPricing).ToList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            //TODO Helpers if needed
            //CREATE YOUR OWN SELECTLIST
            // ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Description");
            //var newunit = new UnitModelView();
            // SetCurrencyViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnitModelView u)
        {
            if (!ModelState.IsValid) return View(u);
            //For Now then update it as you go it should reflec the current owner
            u.Unit.OwnerId = 0;

            UserHelper.UnitHelper.CreateNewUnit(u);
            ViewBag.CurrencyCode = UserHelper.UnitHelper.GetUnitCurrencyCode(u);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var unitModel = UserHelper.UnitHelper.GetUnitModelViewByUnitId(id);
            ViewBag.CurrencyCode = UserHelper.UnitHelper.GetUnitCurrencyCode(unitModel);
            TempData["UnitID"] = id;
            return View(unitModel);
        }

        [HttpPost]
        public ActionResult Edit(UnitModelView u)
        {
            if (!ModelState.IsValid) return View(u);
            UserHelper.UnitHelper.EditUnitModel(u);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
        }
       
        #endregion

        #region ImageUpload
        //[Authorize "For ALL the Functions using Unit Upload"]
        
        public ActionResult Partial2(UnitModelView unitModelView)
        {
            var unitUploaderAttributes = UserHelper.UnitHelper.GetUnitUploaderAttributes();
            ViewBag.Id = unitUploaderAttributes.UploaderId;
            ViewBag.UserName = unitUploaderAttributes.UploaderName;
            ViewBag.Type = unitUploaderAttributes.UploadType;
            TempData["UserID"] = unitUploaderAttributes.UploaderId;
            //RequestID = "5";
            //ViewBag.UserName = "Test";
            //ViewBag.Id = "10";
            //ViewBag.Type = "Requests";
            //TempData["Id"] = "5";

            // SaveProfilePhoto(unitModelView.Unit);
            //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
            return PartialView("_Partial2", unitModelView.UnitGallery);
        }

        public ActionResult EditPictures()
        {
            var unitUploaderAttributes = UserHelper.UnitHelper.GetUnitUploaderAttributes();
            ViewBag.Id = unitUploaderAttributes.UploaderId;
            ViewBag.UserName = unitUploaderAttributes.UploaderName;
            ViewBag.Type = unitUploaderAttributes.UploadType;
            var unitGallery = UserHelper.UnitHelper.GetUnitGalleryByUnitId((int)TempData["UserID"]);
            return PartialView("_EditPictures", unitGallery);
        }

        [HttpPost]
        public ActionResult EditPictures(UnitModelView unitModelView)
        {
            UserHelper.UnitHelper.EditPicture(unitModelView.Unit);
            return PartialView("_EditPictures", unitModelView.UnitGallery);
        }

        #endregion

        #region Features

        public ActionResult Preview(int id, bool? shareproperty, bool? requestshowing)
        {
            var unitModel = UserHelper.UnitHelper.GetUnitModelViewByUnitId(id);
            UserHelper.UnitHelper.PreviewUnit(id, shareproperty, unitModel);
            return View(unitModel);
        }

        public ActionResult ForwardtoFriend(string friendname, string friendemailaddress, string message, int id)
        {
            var email = UserHelper.UnitHelper.ComposeForwardToFriendEmail(friendname, friendemailaddress, message, id);
            try
            {
                email.SendAsync();

            }
            catch (Exception)
            {
                Response.Write("Fail");
                throw;
            }
            // return Content(string.Format("<script language='javascript' type='text/javascript'>{0}</script>", JNotifyConfirmation("Sharing Property")));
            return RedirectToAction("Preview", new { id });
        }

        public ActionResult RequestShowing(string yourname, string youremail, string yourtelephone, string datepicker,int id)
        {
            try
            {
                UserHelper.UnitHelper.RequestShowing(yourname, youremail, yourtelephone, datepicker,id);
            }
            catch (Exception)
            {
            return RedirectToAction("Preview", new { id, requestshowing = false });
            }
          return RedirectToAction("Preview", new { id, requestshowing = true });
        }
       
        #endregion
    }
}