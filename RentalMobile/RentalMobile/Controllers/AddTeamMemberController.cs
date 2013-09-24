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
    public class AddTeamMemberController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();



        public ViewResult Index()
        {
            return View(db.Specialists.ToList());
        }


        public ActionResult Submit()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Submit(Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                db.Specialists.Add(specialist);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }



            //Send Email to the Specialist
            //Insert into Specialist Pending Team Invitation
            //Jquery Confirmation



            return View(specialist);
        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}