using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    [Authorize(Roles = "Provider")]
    public class TeamController : BaseController
    {
        public TeamController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            return View(
                UserHelper.
                GetAllProviderPrivateMaintenanceTeamByProviderId
                (UserHelper.GetProviderId()));
        }

        public ViewResult Details(int id)
        {
            var maintenanceteam = UserHelper.GetProviderPrivateMaintenanceTeamByProviderId(id);
            return View(maintenanceteam);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(MaintenanceTeam maintenanceteam)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            maintenanceteam.MaintenanceProviderId = UserHelper.GetProviderId();
            UnitofWork.MaintenanceTeamRepository.Add(maintenanceteam);
            UnitofWork.Save();
            return Redirect(UserHelper.ProviderMaintenanceTeamTabUrl());
        }

        public ActionResult Edit(int id)
        {
            var maintenanceteam = UserHelper.GetProviderPrivateMaintenanceTeamByProviderId(id);
            return View(maintenanceteam);
        }

        [HttpPost]
        public ActionResult Edit(MaintenanceTeam maintenanceteam)
        {
            if (ModelState.IsValid)
            {
                UserHelper.UpdateMaintenanceTeamsName(maintenanceteam);
                return Redirect(UserHelper.ProviderMaintenanceTeamTabUrl());
            }
            return View(maintenanceteam);
        }

        public ActionResult Delete(int id)
        {
            var maintenanceteam = UserHelper.GetProviderPrivateMaintenanceTeamByProviderId(id);
            return View(maintenanceteam);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var maintenanceteam = UserHelper.GetProviderPrivateMaintenanceTeamByProviderId(id);
            UnitofWork.MaintenanceTeamRepository.Delete(maintenanceteam);
            UnitofWork.Save();
            return RedirectToAction("Index");
        }

        #region TODO 
        //Still On Design

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

        #endregion
    }
}