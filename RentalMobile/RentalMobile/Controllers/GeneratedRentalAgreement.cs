using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    public class GeneratedRentalAgreement : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /GeneratedRentalAgreement/

        public ViewResult Index()
        {
            return View(db.GeneratedRentalContracts.ToList());
        }

        //
        // GET: /GeneratedRentalAgreement/Details/5

        public ViewResult Details(int id)
        {
            GeneratedRentalContract generatedrentalcontract = db.GeneratedRentalContracts.Find(id);
            return View(generatedrentalcontract);
        }

        //
        // GET: /GeneratedRentalAgreement/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /GeneratedRentalAgreement/Create

        [HttpPost]
        public ActionResult Create(GeneratedRentalContract generatedrentalcontract)
        {
            if (ModelState.IsValid)
            {
                db.GeneratedRentalContracts.Add(generatedrentalcontract);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(generatedrentalcontract);
        }
        
        //
        // GET: /GeneratedRentalAgreement/Edit/5
 
        public ActionResult Edit(int id)
        {
            GeneratedRentalContract generatedrentalcontract = db.GeneratedRentalContracts.Find(id);
            return View(generatedrentalcontract);
        }

        //
        // POST: /GeneratedRentalAgreement/Edit/5

        [HttpPost]
        public ActionResult Edit(GeneratedRentalContract generatedrentalcontract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generatedrentalcontract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generatedrentalcontract);
        }

        //
        // GET: /GeneratedRentalAgreement/Delete/5
 
        public ActionResult Delete(int id)
        {
            GeneratedRentalContract generatedrentalcontract = db.GeneratedRentalContracts.Find(id);
            return View(generatedrentalcontract);
        }

        //
        // POST: /GeneratedRentalAgreement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GeneratedRentalContract generatedrentalcontract = db.GeneratedRentalContracts.Find(id);
            db.GeneratedRentalContracts.Remove(generatedrentalcontract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}