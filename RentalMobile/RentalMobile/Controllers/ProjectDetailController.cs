
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    public class ProjectDetailController : Controller
    {
        private RentalContext db = new RentalContext();

        //
        // GET: /ProjectDetail/

        public ViewResult Index()
        {
            return View(db.ProjectPhotoes.ToList());
        }




        [HttpPost]
        public ActionResult MakeOffer(FormCollection form)
        {
            TempData["startDate"] = form["HiddenStartDate"];
            TempData["endDate"] = form["HiddenEndDate"];
            TempData["ProjectId"] = form["HiddenProjectId"];
            return RedirectToAction("Confirm");
        }



        //
        // GET: /RATest/Edit/5

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
            var specialistID = (Convert.ToInt32( form["HiddenProjectId"]));
            var specialist = db.Specialists.FirstOrDefault(t => t.SpecialistId == specialistID);
            if (specialist == null)
            {
                return RedirectToAction("MakeOffer");
            }



//Make sure Project is still Open, not closed by Owner, Agent or finished.


            //Offer Data
            //More Work
            //You need to put them in the view so you can grab them
            var startdate = form["StartDate"];
            var enddate = form["StartDate"];
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}