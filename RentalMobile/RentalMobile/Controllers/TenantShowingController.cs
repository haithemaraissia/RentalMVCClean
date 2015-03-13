using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{ 
    public class TenantShowingController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public TenantShowingController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }

        public ViewResult Index()
        {
            return View(_unitOfWork.TenantShowingRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var tenantshowing = _unitOfWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
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
                _unitOfWork.TenantShowingRepository.Add(tenantshowing);
                _unitOfWork.Save();
                return RedirectToAction("Index");  
            }

            return View(tenantshowing);
        }
        
        public ActionResult Edit(int id)
        {
            var tenantshowing = _unitOfWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            return View(tenantshowing);
        }

        [HttpPost]
        public ActionResult Edit(TenantShowing tenantshowing)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TenantShowingRepository.Edit(tenantshowing);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(tenantshowing);
        }
 
        public ActionResult Delete(int id)
        {
            var tenantshowing = _unitOfWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            return View(tenantshowing);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tenantshowing = _unitOfWork.TenantShowingRepository.FindBy(x => x.ShowingId == id).FirstOrDefault();
            _unitOfWork.TenantShowingRepository.Delete(tenantshowing);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}