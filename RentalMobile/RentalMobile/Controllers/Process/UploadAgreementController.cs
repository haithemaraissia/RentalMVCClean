using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Process
{
    [Authorize(Roles = "Owner")]
    //It has to be for all the roles
    public class UploadAgreementController : BaseController
    {
        public UploadAgreementController(IGenericUnitofWork uow,  IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ActionResult Index()
        {
            ViewBag.Id = UserHelper.GetOwnerId();
            ViewBag.UserName = UserHelper.OwnerPrivateProfileHelper.OwnerUsername();
            ViewBag.Type = UserHelper.OwnerPrivateProfileHelper.RequestType;
            TempData["UserID"] = UserHelper.GetOwnerId();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            UserHelper.OwnerPrivateProfileHelper.AddOwnerContractPictures("UserID");
            return RedirectToAction("UploadedAgreement", "Owner");
        }
    }
}
