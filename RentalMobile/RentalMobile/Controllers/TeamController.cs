using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    [Authorize(Roles = "Provider")]
    public class TeamController : Controller
    {
        public DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public string Username = UserHelper.GetUserName();
        public MaintenanceProvider  Provider;


        //Constructir
        public TeamController()
        {
            Provider = db.MaintenanceProviders.Find(UserHelper.GetProviderId());
        }

        //
        // GET: /Team/

        public ViewResult Index()
        {
            var teams =
                db.MaintenanceTeams.Where(x => x.MaintenanceProviderId == Provider.MaintenanceProviderId).ToList();
            return View(teams);
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


        public string ProviderTeamTabUrl()
        {
            var uri = HttpContext.Request.Url;
            if (uri != null)
            {
                return  uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port + "/Provider#team";
            }
            return "~/Provider#team";
        }
        //
        // POST: /Team/Create
        //THis one Should be Done///
        [HttpPost]
        public ActionResult Create(MaintenanceTeam maintenanceteam)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            maintenanceteam.MaintenanceProviderId = Provider.MaintenanceProviderId;
            db.MaintenanceTeams.Add(maintenanceteam);
            db.SaveChanges();
            return Redirect(ProviderTeamTabUrl());
        }
 //THis one Should be Done///



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

                //Save Change for Each Team association Team Name
                var maintenanceTeamAssociation = db.MaintenanceTeamAssociations.
                    Where(x=>x.TeamId == maintenanceteam.TeamId 
                        && x.MaintenanceProviderId == Provider.MaintenanceProviderId).ToList();
               if (maintenanceTeamAssociation.Count > 0)
               {
                   foreach (var mta in maintenanceTeamAssociation)
                   {
                       mta.TeamName = maintenanceteam.TeamName;
                   }
               }
               db.SaveChanges();
                return Redirect(ProviderTeamTabUrl());
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