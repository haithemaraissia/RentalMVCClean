using System.Linq;
using System.Web.Mvc;
using PagedList;
using RentalMobile.Helpers;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.JQuery;
using RentalMobile.Helpers.JQuery.JNotify;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Specialist
{
    [Authorize(Roles = "Specialist")]
    public class SpecialistController : BaseController
    {
        #region SpecialistController

        public SpecialistController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetSpecialist();
            ViewBag.SpecialistProfile = specialist;
            ViewBag.SpecialistId = specialist.SpecialistId;
            ViewBag.SpecialistGoogleMap = specialist.GoogleMap;
            return View(specialist);
        }

        public ActionResult Edit(int id)
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(id);
            return View(specialist);
        }

        [HttpPost]
        public ActionResult Edit(Model.Models.Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.SpecialistRepository.Edit(specialist);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        public ActionResult ChangeAddress(int id)
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(id);
            return View(specialist);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Model.Models.Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.SpecialistRepository.Edit(specialist);
                specialist.GoogleMap = UserHelper.SpecialistPrivateProfileHelper.SpecialistGoogleMap();
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        public ActionResult Delete(int id)
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(id);
            return View(specialist);
        }

        #region TODO
        /// TODO ///
        //Not Completed
        ////////////////////////More Work Needed////////////////////////
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(id);
            UnitofWork.SpecialistRepository.Delete(specialist);
            UnitofWork.Save();


            //// Delete All associated records
            //var Specialistshowing = db.SpecialistShowings.Where(x => x.SpecialistId == id).ToList();
            //foreach (var x in Specialistshowing)
            //{
            //    db.SpecialistShowings.Remove(x);
            //}
            //db.SaveChanges();


            UserHelper.SpecialistPrivateProfileHelper.DeleteSpecialistMemebership();
            return RedirectToAction("Index", "Home");
        }


        /// TODO ///
        /// NOT Complete, wrong
        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }
        /// TODO ///
        /// NOT Complete, wrong
        public ActionResult UploadPhoto(UnitModelView unitModelView)
        {
            UserHelper.SpecialistPrivateProfileHelper.UploadPhoto();

            //RequestID = "5";
            //ViewBag.UserName = "Test";
            //ViewBag.Id = "10";
            //ViewBag.Type = "Requests";
            //TempData["Id"] = "5";

            //  SaveProfilePhoto(unitModelView.Unit);
            //ViewBag.Sript = FancyBox.Fancy(unitModelView.Unit.UnitId);
            return PartialView("_UploadPhoto", unitModelView.UnitGallery);
        }

        ////////////////////////More Work Needed///////////////////////
        #endregion

        public ActionResult CompleteProfile()
        {
            var specialistMaintenanceProfile = UserHelper.SpecialistPrivateProfileHelper.GetSpecialistMaitenanceProfile();
            return View(specialistMaintenanceProfile);
        }

        [HttpPost]
        public ActionResult CompleteProfile(SpecialistMaintenanceProfile spf)
        {
                if (ModelState.IsValid)
                {
                    UserHelper.SpecialistPrivateProfileHelper.CompleteSpecialistMaitenanceProfile(spf);
                        return RedirectToAction("Index");
                }
                return View(spf);
        }
        #endregion

        #region Provider Tab
        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************

        public ActionResult ProviderInvitation(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            return specialistId == 0 ? 
                null : 
                View(UnitofWork.SpecialistPendingTeamInvitationRepository.FindBy(x => x.SpecialistID == specialistId).OrderBy(x=>x.SpecialistID).ToPagedList(page, 10 ));
        }

        public ActionResult AcceptInvitation(int id)
        {
            var invitation = UnitofWork.SpecialistPendingTeamInvitationRepository.FirstOrDefault(x=>x.SpecialistID == id);
            return View(invitation);
        }

        [HttpPost]
        public ActionResult AcceptInvitation(SpecialistPendingTeamInvitation sti)
        {
            UserHelper.SpecialistPrivateProfileHelper.AcceptInvitation(sti);
            return RedirectToAction("CurrentProvider");
        }

        public ActionResult DenyInvitation(int id)
        {
            var invitation = UnitofWork.SpecialistPendingTeamInvitationRepository.FirstOrDefault(x => x.PendingTeamInvitationID == id);
            return View(invitation);
        }

        [HttpPost]
        public ActionResult DenyInvitation(SpecialistPendingTeamInvitation sti)
        {
            UserHelper.SpecialistPrivateProfileHelper.DenyInvitation(sti);
            return RedirectToAction("CurrentProvider");
        }

        public ActionResult CurrentProvider(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            var currentProvider = UnitofWork.MaintenanceTeamAssociationRepository.
                FindBy(x => x.SpecialistId == specialistId).OrderBy(x => x.SpecialistId).
                ToPagedList(page, 10);
            return View(currentProvider);
        }

        public ActionResult ManageProvider(int page = 1)
        {
            var specialistId = UserHelper.GetSpecialistId();
            var currentProvider = UnitofWork.MaintenanceTeamAssociationRepository.
                FindBy(x => x.SpecialistId == specialistId).OrderBy(x => x.SpecialistId).
                ToPagedList(page, 10);
            return View(currentProvider);
        }

        public ActionResult RemoveTeamAssociation(int id)
        {
            var maintenanceteamassociation = UnitofWork.MaintenanceTeamAssociationRepository.FirstOrDefault(x => x.TeamAssociationID == id);
            return View(maintenanceteamassociation);
        }

        [HttpPost]
        public ActionResult RemoveTeamAssociation(MaintenanceTeamAssociation mta)
        {
            UserHelper.SpecialistPrivateProfileHelper.RemoveTeamAssociation(mta);
            return RedirectToAction("CurrentProvider");
        }

        //********************************************PROVIDER Tab Function****************************************************
        //*********************************************************************************************************************
        #endregion

        #region Coverage Tab
        //********************************************COVERAGE Tab Function****************************************************
        //*********************************************************************************************************************

        public PartialViewResult  _Coverage()
        {
            return PartialView(UserHelper.SpecialistPrivateProfileHelper.GetSpecialistMaitenanceProfile());
        }


        //********************************************COVERAGE Tab Function****************************************************
        //*********************************************************************************************************************
        #endregion

        #region Common
        public ActionResult Confirmation()
        {
            ViewBag.Confirmation = true;
            ViewBag.ConfirmationSuccess = new JNotfiyScriptQueryHelper().JNotifyConfirmationMessage("Your request has been completed.", "/Specialist/CurrentProvider");
            return View();
        }
        #endregion

        //////////////Maybe Needed for Future Option///////////
        //DETAIL OF Specialist FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var Specialistfavorite =  db.SpecialistFavorites.Where(x => x.SpecialistId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Specialist Specialist = db.SpecialistFavorites.Where(Specialist == 6 && )
        //    return PartialView("_SpecialistFavDetail",Specialistfavorite);
        //}

        //////////////Maybe Needed for Future Option///////////

    }
}
