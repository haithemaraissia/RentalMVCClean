using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    [Authorize]
    public class TenantRentalApplicationController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public static Guid UserGUID = (Guid) UserHelper.GetUserGUID();
        public int TenantID = (int) UserHelper.GetTenantID(UserGUID);


        // GET: /RATest/

        public ViewResult Index()
        {

            var tenantrentalapplication  = db.RentalApplications.
                Where(t => t.TenantId == TenantID);

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // GET: /RATest/Details/5

        public ViewResult Details()
        {
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                RedirectToActionPermanent("Create");
            }

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // GET: /RATest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RATest/Create

        [HttpPost]
        public ActionResult Create(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                rentalapplication.TenantId = TenantID;
                db.RentalApplications.Add(rentalapplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Edit/5

        public ActionResult Edit()
        {
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                RedirectToActionPermanent("Create");
            }

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // POST: /RATest/Edit/5

        [HttpPost]
        public ActionResult Edit(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalapplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Delete/5

        public ActionResult Delete(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            return View(rentalapplication);
        }

        //
        // POST: /RATest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            db.RentalApplications.Remove(rentalapplication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //
        // GET: /RATest/Edit/5

        public ActionResult Submit()
        {
            var tenantrentalapplication = db.RentalApplications.Where(t => t.TenantId == TenantID);
            if (!tenantrentalapplication.Any())
            {
                RedirectToActionPermanent("Create");
            }

            return View(tenantrentalapplication.FirstOrDefault());
        }

        //
        // POST: /RATest/Edit/5

        [HttpPost]
        public ActionResult Submit(RentalApplication rentalapplication)
        {



            //OVER HERE YOU HAVE TO
            //CHECK THAT AN APPLICATION EXIST
            //PROCESS TO AMAZONPAYPAL
            //YOU DON'T NEED MODEL VALIDATION



            //ALOS WHEN SUCCED
            //ADD ROW IN PAYMENT WITH DESCRIPTION OF THIS TRANSACTION

            //ALSO SEND EMAIL TO LISTER
            //SO HE OR SHE DOES BACKGROUND CHECKING AND ACCPET/DENY APPLICATION


            if (ModelState.IsValid)
            {
                db.Entry(rentalapplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}