using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class RentalApplicationController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public RentalApplicationController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }

        public ViewResult Index()
        {
            return View(_unitOfWork.RentalApplicationRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var rentalapplication = _unitOfWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RentalApplicationRepository.Add(rentalapplication);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(rentalapplication);
        }

        public ActionResult Edit(int id)
        {
            var rentalapplication = _unitOfWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        [HttpPost]
        public ActionResult Edit(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RentalApplicationRepository.Edit(rentalapplication);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }

        public ActionResult Delete(int id)
        {
            var rentalapplication = _unitOfWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var rentalapplication = _unitOfWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            _unitOfWork.RentalApplicationRepository.Delete(rentalapplication);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Submit(int id)
        {
            var rentalapplication = _unitOfWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        [HttpPost]
        public ActionResult Submit(RentalApplication rentalapplication)
        {

            //OVER HERE YOU HAVE TO
            //CHECK THAT AN APPLICATION EXIST
            //PROCESS TO AMAZONPAYPAL
            //YOU DON'T NEED MODEL VALIDATION


            //ALOS WHEN SUCCED
            //ADD ROW IN PAYMENT WITH DESCRIPTION OF THIS TRANSACTION

            //ALSO SEND EMAIL TO LISTER
            //SO HE OR SHE DOES BACKGROUND CHECKING AND ACCPET/DENY APPLICATION

            if (ModelState.IsValid)
            {
                _unitOfWork.RentalApplicationRepository.Add(rentalapplication);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }
    }
}