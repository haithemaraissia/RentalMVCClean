using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Tenant
{ 
    public class TenantShowingController : BaseController
    {
        public TenantShowingController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            return View(UnitofWork.TenantShowingRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var tenantshowing = UnitofWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            return View(tenantshowing);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(TenantShowing tenantshowing)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.TenantShowingRepository.Add(tenantshowing);
                UnitofWork.Save();
                return RedirectToAction("Index");  
            }

            return View(tenantshowing);
        }
        
        public ActionResult Edit(int id)
        {
            var tenantshowing = UnitofWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            return View(tenantshowing);
        }

        [HttpPost]
        public ActionResult Edit(TenantShowing tenantshowing)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.TenantShowingRepository.Edit(tenantshowing);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(tenantshowing);
        }
 
        public ActionResult Delete(int id)
        {
            var tenantshowing = UnitofWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            return View(tenantshowing);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tenantshowing = UnitofWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            UnitofWork.TenantShowingRepository.Delete(tenantshowing);
            UnitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}