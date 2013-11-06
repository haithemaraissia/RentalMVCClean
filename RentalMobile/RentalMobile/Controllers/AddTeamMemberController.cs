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

    //THIS IS ONLY FOR TESTING
    //IT SHOULD BE A FUCTION INSIDE PROVIDER CONTROL
    public class AddTeamMemberController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();




           //var specialistId = Helpers.UserHelper.GetSpecialistID();
           // return specialistId == null ? null : View(db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());
        //var maintenanceteamassociation = db.MaintenanceTeamAssociations.FirstOrDefault(x => x.TeamAssociationID == mta.TeamAssociationID);


        //For Testing//
        public const int SpecialistId = 3;
        public const int MaintenanceProviderId = 3;

        public ViewResult Index()
        {

            //Get all specialist that don't have pending association or all already associated with the Team

            var existingTeamAssociation = db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == SpecialistId && x.MaintenanceProviderId == MaintenanceProviderId).ToList();
            var existingTeamAssociationLooKup = existingTeamAssociation.ToLookup(x => x.SpecialistId);

            var pendingTeamAssociation = db.MaintenanceTeamAssociations.Where(x => x.SpecialistId == SpecialistId && x.MaintenanceProviderId == 1).ToList();
            var pendingTeamAssociationLooKup = pendingTeamAssociation.ToLookup(x => x.SpecialistId);

            var excludedspecialistLookUp = existingTeamAssociationLooKup.Concat(pendingTeamAssociationLooKup).SelectMany(x => x).ToLookup(x => x.MaintenanceProviderId);

            var availableSpecialist = db.Specialists.Where(x => !excludedspecialistLookUp.Contains(x.SpecialistId));
            return View(availableSpecialist.ToList());
        }


        public ActionResult Submit()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Submit(Specialist specialist)
        {

            //Get the value of the team for the maintenanceprovider
            var Team = 
            if (ModelState.IsValid)
            {

                var npti = new SpecialistPendingTeamInvitation
                    {
                        MaintenanceProviderId = MaintenanceProviderId,
                        PendingTeamInvitationID = 3,
                        SpecialistID = SpecialistId,
                        TeamId = 2,
                        TeamName = "df"


                    };

                //var specialistId = Helpers.UserHelper.GetSpecialistID();
                // return specialistId == null ? null : View(db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());

                db.SpecialistPendingTeamInvitations.Add(npti);
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