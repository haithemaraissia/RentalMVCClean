using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{

    //THIS IS ONLY FOR TESTING
    //IT SHOULD BE A FUCTION INSIDE PROVIDER CONTROL
    public class AddTeamMemberController : Controller
    {
        private RentalContext db = new RentalContext();

        public ViewResult Index(int specialistId, int maintenanceProviderId)
        {

            //Get all specialist that don't have pending association or all already associated with the Team

            var existingTeamAssociation = db.MaintenanceTeamAssociations.Where(
                x => x.SpecialistId == specialistId && x.MaintenanceProviderId == maintenanceProviderId)
                                            .Select(x => x.SpecialistId).ToList();

            var pendingTeamAssociation = db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId && x.MaintenanceProviderId == maintenanceProviderId).Select(x => x.SpecialistID).ToList();
            var mergedExistingandPendingTeamAssociation = new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));
            var excludedSpecialistList = db.Specialists.Where(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
            var filterSpecialistList = db.Specialists.Where(x => x.SpecialistId == specialistId).Except(excludedSpecialistList).ToList();

            return View(filterSpecialistList);
        }




        //public ViewResult Index(int SpecialistId, int MaintenanceProviderId)
        //{

        //    //Get all specialist that don't have pending association or all already associated with the Team

        //    var existingTeamAssociation = db.MaintenanceTeamAssociations.Where(
        //        x => x.SpecialistId == SpecialistId && x.MaintenanceProviderId == MaintenanceProviderId)
        //                                    .Select(x => x.SpecialistId).ToList();

        //    var test1 = existingTeamAssociation.Count();
        //    //should be 2

        //    var pendingTeamAssociation = db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == SpecialistId && x.MaintenanceProviderId == MaintenanceProviderId).Select(x => x.SpecialistID).ToList();
        //    var test2 = pendingTeamAssociation.Count();
        //    //should be 3

        //    var mergedExistingandPendingTeamAssociation = new List<int>(existingTeamAssociation.Union(pendingTeamAssociation));

        //    var test3 = mergedExistingandPendingTeamAssociation.Count();
        //    //should be 5

        //    var excludedSpecialistList = db.Specialists.Where(x => mergedExistingandPendingTeamAssociation.Contains(x.SpecialistId));
        //    var test4 = excludedSpecialistList.Count();
        //    //should be 6


        //    var filterSpecialistList = db.Specialists.Where(x => x.SpecialistId == SpecialistId).Except(excludedSpecialistList).ToList();
        //    var test7 = filterSpecialistList.Count();
        //    //should be 7

        //    return View(filterSpecialistList);
        //}


        public ActionResult Submit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Submit(Specialist specialist, int specialistId, int maintenanceProviderId)
        {
            var teamlist = db.MaintenanceTeams.Where(x => x.MaintenanceProviderId == maintenanceProviderId).ToList();
            var teamcount = db.MaintenanceTeams.Count(x => x.MaintenanceProviderId == maintenanceProviderId);
            switch (teamcount)
            {
                //if Provider has no team
                case 0:
                    //UI for Creating Team and renaming and deleting Team
                    //Redirect to create team

                    RedirectToAction("Create", "Team");
                    break;



                //If Provider has only 1 team then proceed
                case 1:
                    if (ModelState.IsValid)
                    {
                        var currentteam = teamlist.First();
                        var npti = new SpecialistPendingTeamInvitation
                            {
                                MaintenanceProviderId = maintenanceProviderId,
                                SpecialistID = specialistId,
                                TeamId = currentteam.TeamId,
                                TeamName = currentteam.TeamName
                            };
                        db.SpecialistPendingTeamInvitations.Add(npti);
                        db.SaveChanges();
                    }
                    break;


                // Else if Provider has more than 1
                default:
                    if (teamcount > 1)
                    {
                        RedirectToAction("SelectTeam", "Team");
                        RedirectToAction("SelectTeam", "Team", new { id = specialistId });
                    }
                    break;
            }








            //var specialistId = Helpers.UserHelper.GetSpecialistID();
            // return specialistId == null ? null : View(db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());


            return RedirectToAction("Index");
        }
        //Send Email to the Specialist
        //Insert into Specialist Pending Team Invitation
        //Jquery Confirmation




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}