using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Process
{
    public class RentalApplicationController : BaseController
    {

        public RentalApplicationController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ViewResult Index()
        {
            return View(UnitofWork.RentalApplicationRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var rentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
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
                UnitofWork.RentalApplicationRepository.Add(rentalapplication);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
           // var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(rentalapplication);
        }

        public ActionResult Edit(int id)
        {
            var rentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        [HttpPost]
        public ActionResult Edit(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.RentalApplicationRepository.Edit(rentalapplication);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }

        public ActionResult Delete(int id)
        {
            var rentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            return View(rentalapplication);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var rentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
            UnitofWork.RentalApplicationRepository.Delete(rentalapplication);
            UnitofWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Submit(int id)
        {
            var rentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
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
                UnitofWork.RentalApplicationRepository.Add(rentalapplication);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }
    }
}