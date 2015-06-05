using System.IO;
using System.Web.Mvc;
using RentalMobile.Helpers.Photo.Unit;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.Helpers.Unit
{
    public interface IUnitHelper
    {
        #region Main
        void CreateNewUnit(UnitModelView u);
        int GetUnitCurrencyCode(UnitModelView u);
        UnitModelView GetUnitModelViewByUnitId(int id);
        void EditUnitModel(UnitModelView u);
        #endregion

        # region ImageUpload
        string Username();
        UnitGallery GetUnitGalleryByUnitId(int unitId);
        void EditPicture(Model.Models.Unit unit);
        void SavePictures(Model.Models.Unit unit);
        void DefaultPhoto(Model.Models.Unit unit, FileInfo[] files, string newdirectory, string virtualdestinationdirectoryvirtualmapping, string directory);
        void AddPicture(Model.Models.Unit unit, int uploaderid, string photoPath, int rank);
        JavaScriptResult ShareonFacebook();
        UnitUploaderAttributes GetUnitUploaderAttributes();
        #endregion

        #region Features
        //Theorizing
        void ShareProperty(UnitModelView u);
        string GetCurrencyValue(int? currencyId);
        void UnitProperty(int id, string previewPathWithHost, dynamic email, Model.Models.Unit currentunit, string unitPicture);
        void SendRequestToRequester(string requestername, string requesteremailaddress, string datepicker, int id);
        void SendRequestToReceiver(string requestername, string requesteremailaddress, string requestertelephone, string datepicker, int id);
        void InsertPendingShowingRequest(int id);
        string UnitGoogleMap(UnitModelView unitModel);
        void PreviewUnit(int id, bool? shareproperty, UnitModelView unitModel);
        dynamic ComposeForwardToFriendEmail(string friendname, string friendemailaddress, string message, int id);
        void RequestShowing(string yourname, string youremail, string yourtelephone, string datepicker, int id);

        #endregion

        #region Helper
        void SetCurrencyViewBag(int? currencyId = null);
        SelectList GetCurrencySelectList();
        #endregion

        #region ToComplete
        #endregion

    }
}
