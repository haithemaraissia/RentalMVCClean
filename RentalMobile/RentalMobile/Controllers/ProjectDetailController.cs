using System;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{ 
    public class ProjectDetailController : BaseController
    {

        public ProjectDetailController(IGenericUnitofWork uow,  IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            return View(UnitofWork.ProjectPhotoRepository.All.ToList());
        }

        [HttpPost]
        public ActionResult MakeOffer(FormCollection form)
        {
            TempData["startDate"] = form["HiddenStartDate"];
            TempData["endDate"] = form["HiddenEndDate"];
            TempData["ProjectId"] = form["HiddenProjectId"];
            return RedirectToAction("Confirm");
        }

        public ActionResult Confirm()
        {
            ViewBag.StartDate = TempData["startDate"];
            ViewBag.EndDate = TempData["endDate"];
            ViewBag.ProjectID = TempData["ProjectId"];
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(FormCollection form)
        {

            //SpecialistID
            var specialistId = (Convert.ToInt32( form["HiddenProjectId"]));
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(specialistId);

            if (specialist == null)
            {
                return RedirectToAction("MakeOffer");
            }


            ////<Summary>///
            //TODO The below//
            //Make sure Project is still Open, not closed by Owner, Agent or finished.

            //Offer Data
            //More Work
            //You need to put them in the view so you can grab them

            //It Should be already included
            var startdate = form["StartDate"];
            var enddate = form["EndDate"];
            //It Should be already included

            var amount = form["Amount"];
            var currency = form["Currency"];
            var quicknote = form["Quick Note"];

            //Insert into Owner, Agent Offer
            //Insert into Sepcialist submittted ofer
            //Do the confirmation.


            ////WHEN AMAZON PAYMENT SUCCEED
            //if (property != null)
            //{
            //    var posterrole = property.PosterRole.Trim();

            //    switch (posterrole)
            //    {

            //        case "Owner":
            //            //Insert into Pending Application
            //            if (property.PosterID != null)
            //                InsertOwnerPendingApplication(tenantrentalapplication.First(), (int)property.PosterID);
            //            ViewData["confirmationmsg"] = "Your Application had been succesfully submitted to the Owner.";

            //            //Confirmation that is has been posted
            //            break;

            //        case "Agent":
            //            //Insert into Pending Application
            //            if (property.PosterID != null)
            //                InsertAgentPendingApplication(tenantrentalapplication.First(), (int)property.PosterID);
            //            ViewData["confirmationmsg"] = "Pass";
            //            break;

            //    }
            //}
            return View();
        }

    }
}