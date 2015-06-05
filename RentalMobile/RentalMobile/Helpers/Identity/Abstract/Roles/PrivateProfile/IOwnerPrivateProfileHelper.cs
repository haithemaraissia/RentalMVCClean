using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile
{
    public interface IOwnerPrivateProfileHelper
    {
        #region OwnerHelper
        string OwnerUsername();
        Owner GetOwner();
        Owner GetPrivateProfileOwnerByOwnerId(int id);
        string OwnerGoogleMap();
        void DeleteOwnerRecords(int ownerId);
        void DeleteOwnerMemebership();
        #endregion

        #region Unit
        dynamic ComposeForwardUnitToFriendEmail(string friendname, string friendemailaddress, string message, int id);
        #endregion

        #region Application
        List<OwnerPendingApplication> GetOwnerPendingApplication();
        void OwnerAcceptApplicationByApplicationId(int pendingApplicationId);
        void OwnerRejectApplicationByApplicationId(int pendingApplicationId);
        List<OwnerAcceptedApplication> GetOwnerAcceptedApplication();
        List<OwnerRejectedApplication> GetOwnerRejectedApplication();
        #endregion

        #region Contract
        List<GeneratedRentalContract> GetOwnerGeneratedRentalContract();
        List<UploadedContract> GetUploadedOwnerRentalContract();
        #endregion

        #region Showing
        IQueryable<OwnerPendingShowingCalendarModelView> GetOwnerPendingShowingCalendar();
        void OwnerDenyShowingRequest(int eventId);
        void OwnerAcceptShowingRequest(int eventId);
        JsonResult GetOwnerCalendar();
        #endregion

        #region TODO
        //TODO

        #region RSS
        FileResult Syndicate(string format);
        #endregion

        //#region Project
        ////Still in Design Phase
        //#endregion

        //#region Picture
        ////TODO TO COMPLETE AND VERIFY: IT DOESN"T FOLLOW THE STANADRDS
        //void SaveUnitPictures(Unit unit);
        //void AddUnitGalleryPictureorDefaultUnitPicture(Unit unit, FileInfo[] files, string newdirectory, string virtualdestinationdirectoryvirtualmapping, string directory);
        //void AddUnitGalleryPicture(Unit unit, int uploaderid, string photoPath, int rank);
        //#endregion

        //#region Contract
        ////Not Used Yet
        //void AddOwnerContractPictures(string key);
        //void AddContractPhotoByOwner(int uploaderid, string photoPath);
        //#endregion

        #endregion
    }
}
