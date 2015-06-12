using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Provider
{

    //THIS IS ONLY FOR TESTING
    //IT SHOULD BE A FUCTION INSIDE PROVIDER CONTROL AREA

    [Authorize(Roles = "Provider")]
    public class AddTeamMemberController : BaseController
    {
        public AddTeamMemberController(IGenericUnitofWork uow, IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ViewResult Index(int specialistId, int maintenanceProviderId)
        {
            var availableSpecialists = UserHelper.ProviderPrivateProfileHelper.GetAllSpecialistsWithoutExistingOrPendingTeamAssociationWithProvider(specialistId, maintenanceProviderId);
            return View(availableSpecialists);
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Model.Models.Specialist specialist, int specialistId, int maintenanceProviderId)
        {
            UserHelper.ProviderPrivateProfileHelper.AddNewPendingSpecialistInvitationToProviderTeam(specialist, specialistId, maintenanceProviderId);
            //var specialistId = Helpers.UserHelper.GetSpecialistID();
            // return specialistId == null ? null : View(db.SpecialistPendingTeamInvitations.Where(x => x.SpecialistID == specialistId).ToList());
            return RedirectToAction("Index");
        }
       
        //Send Email to the Specialist
        //Insert into Specialist Pending Team Invitation
        //Jquery Confirmation

    }
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
