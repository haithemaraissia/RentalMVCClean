using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Tenant
{ 
    [Authorize]
    public class TenantController : BaseController
    {
        #region TenantHelper

        public TenantController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var tenant = UserHelper.TenantPrivateProfileHelper.GetTenant();
            ViewBag.TenantProfile = tenant;
            ViewBag.TenantId = tenant.TenantId;
            ViewBag.TenantGoogleMap = tenant.GoogleMap;
            ViewBag.tenantApplicationCount = UserHelper.TenantPrivateProfileHelper.GetTenantApplicationCount(tenant.TenantId);
            return View(tenant);
        }

        public ActionResult Edit(int id)
        {
            var tenant = UserHelper.TenantPrivateProfileHelper.GetPrivateProfileTenantByTenantId(id);
            return View(tenant);
        }

        [HttpPost]
        public ActionResult Edit(Model.Models.Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.TenantRepository.Edit(tenant);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        public ActionResult ChangeAddress(int id)
        {
            var tenant = UserHelper.TenantPrivateProfileHelper.GetPrivateProfileTenantByTenantId(id);
            return View(tenant);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Model.Models.Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.TenantRepository.Edit(tenant);
                tenant.GoogleMap = UserHelper.TenantPrivateProfileHelper.TenantGoogleMap();
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }
 
        public ActionResult Delete(int id)
        {
            var tenant = UserHelper.TenantPrivateProfileHelper.GetPrivateProfileTenantByTenantId(id);
            return View(tenant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserHelper.TenantPrivateProfileHelper.DeleteTenantRecords(id);
            UserHelper.TenantPrivateProfileHelper.DeleteTenantMemebership();
            return RedirectToAction("Index","Home");
        }

        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload","Account",new {id});
        }

        #region TODO MIGHT BE NEEDED
        //DETAIL OF TENANT FAVORITE
        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var tenantfavorite =  db.TenantFavorites.Where(x => x.TenantId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Tenant tenant = db.TenantFavorites.Where(Tenant == 6 && )
        //    return PartialView("_TenantFavDetail",tenantfavorite);
        //}
#endregion

        #endregion




        public ViewResult GeneratedRentalAgreement()
        {
            var tenant = UserHelper.TenantPrivateProfileHelper.GetTenant();
            if (tenant != null)
            {
                var tenantId = tenant.TenantId;
                if (tenantId != 0)
                {
                      var tenantContracts = UserHelper.TenantPrivateProfileHelper.GetTenantContract(tenantId);
                    return View(tenantContracts);
                }
            }
            return null;
        }
    }
}