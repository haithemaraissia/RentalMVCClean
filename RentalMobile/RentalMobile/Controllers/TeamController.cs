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
    public class TeamController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /Team/

        public ViewResult Index()
        {
            return View(db.MaintenanceTeams.ToList());
        }

        //
        // GET: /Team/Details/5

        public ViewResult Details(int id)
        {
            MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            return View(maintenanceteam);
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Team/Create

        [HttpPost]
        public ActionResult Create(MaintenanceTeam maintenanceteam)
        {
            if (ModelState.IsValid)
            {
                db.MaintenanceTeams.Add(maintenanceteam);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(maintenanceteam);
        }
        
        //
        // GET: /Team/Edit/5
 
        public ActionResult Edit(int id)
        {
            MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            return View(maintenanceteam);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        public ActionResult Edit(MaintenanceTeam maintenanceteam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintenanceteam);
        }

        //
        // GET: /Team/Delete/5
 
        public ActionResult Delete(int id)
        {
            MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            return View(maintenanceteam);
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            db.MaintenanceTeams.Remove(maintenanceteam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }








        //Select which Team based upon available Provider ID
        //Also Will get specialistid as parameter
        public ActionResult SelectTeam(int id)
        {
            //MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            //return View(maintenanceteam);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("SelectTeam")]
        public ActionResult SelectedTeam(int id)
        {
            //MaintenanceTeam maintenanceteam = db.MaintenanceTeams.Find(id);
            //db.MaintenanceTeams.Remove(maintenanceteam);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}