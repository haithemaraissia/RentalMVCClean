using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.WIP
{
    public class MaintenanceOrderController : BaseController
    {
        public MaintenanceOrderController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var maintenanceorders = UnitofWork.MaintenanceOrderRepository.AllIncluding(m => m.ServiceType).Include(m => m.UrgencyType);
            return View(maintenanceorders.ToList());
        }

        public ViewResult Details(int id)
        {
            var maintenanceorder =
                UnitofWork.MaintenanceOrderRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            return View(maintenanceorder);
        }

        public ActionResult Create()
        {
            ViewBag.ServiceTypeID = new SelectList(UnitofWork.ServiceTypeRepository.All, "ServiceTypeID", "ServiceType1");
            ViewBag.UrgencyID = new SelectList(UnitofWork.UrgencyTypeRepository.All, "UrgencyTypeID", "UrgencyType1");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "MaintenanceID")]MaintenanceOrder maintenanceorder)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.MaintenanceOrderRepository.Add(maintenanceorder);
                UnitofWork.Save();
                TempData["UserName"] = MembershipService.GetUser(UserHelper.UserIdentity.GetUserName());
                TempData["Id"] = maintenanceorder.MaintenanceID;
                return RedirectToAction("Index", "Upload");
            }

            ViewBag.ServiceTypeID = new SelectList(UnitofWork.ServiceTypeRepository.All, "ServiceTypeID", "ServiceType1", maintenanceorder.ServiceTypeID);
            ViewBag.UrgencyID = new SelectList(UnitofWork.UrgencyTypeRepository.All, "UrgencyTypeID", "UrgencyType1", maintenanceorder.UrgencyID);
            return View(maintenanceorder);
        }

        public ActionResult Edit(int id)
        {
            var maintenanceorder = 
                UnitofWork.MaintenanceOrderRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            if (maintenanceorder != null)
            {
                ViewBag.ServiceTypeID = new SelectList(UnitofWork.ServiceTypeRepository.All, "ServiceTypeID", "ServiceType1", maintenanceorder.ServiceTypeID);
                ViewBag.UrgencyID = new SelectList(UnitofWork.UrgencyTypeRepository.All, "UrgencyTypeID", "UrgencyType1", maintenanceorder.UrgencyID);
                return View(maintenanceorder);
            }
            return null;
        }

        [HttpPost]
        public ActionResult Edit(MaintenanceOrder maintenanceorder)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.MaintenanceOrderRepository.Edit(maintenanceorder);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceTypeID = new SelectList(UnitofWork.ServiceTypeRepository.All, "ServiceTypeID", "ServiceType1", maintenanceorder.ServiceTypeID);
            ViewBag.UrgencyID = new SelectList(UnitofWork.UrgencyTypeRepository.All, "UrgencyTypeID", "UrgencyType1", maintenanceorder.UrgencyID);
            return View(maintenanceorder);
        }

        public ActionResult Delete(int id)
        {
            var maintenanceorder = UnitofWork.MaintenanceOrderRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            return View(maintenanceorder);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var maintenanceorder = UnitofWork.MaintenanceOrderRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            UnitofWork.MaintenanceOrderRepository.Delete(maintenanceorder);
            UnitofWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult AddMorePhotos([Bind(Exclude = "MaintenanceID")]MaintenanceOrder maintenanceorder)
        {
            TempData["UserName"] = MembershipService.GetUser(UserHelper.UserIdentity.GetUserName());
            TempData["Id"] = maintenanceorder.MaintenanceID;
            TempData["Type"] = "Requests"; 
            return RedirectToAction("Index", "Upload");
        }
    }
}