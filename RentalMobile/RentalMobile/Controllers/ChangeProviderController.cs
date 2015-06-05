using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class ChangeProviderController : BaseController
    {
        public ChangeProviderController(IGenericUnitofWork uow, IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ViewResult Index(int id)
        {
            var provider = UserHelper.ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(id);
            ViewBag.providerProfile = provider;
            ViewBag.providerId = provider.MaintenanceProviderId;
            ViewBag.providerGoogleMap = provider.GoogleMap;
            return View(provider);
        }
    }
}
