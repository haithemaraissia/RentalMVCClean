using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class GeneratedRentalAgreementController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public GeneratedRentalAgreementController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }

        public ViewResult Index()
        {
            return View(_unitOfWork.GeneratedRentalContractRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var generatedrentalcontract = _unitOfWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            return View(generatedrentalcontract);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneratedRentalContract generatedrentalcontract)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GeneratedRentalContractRepository.Add(generatedrentalcontract);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(generatedrentalcontract);
        }

        public ActionResult Edit(int id)
        {
            var generatedrentalcontract = _unitOfWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            return View(generatedrentalcontract);
        }


        [HttpPost]
        public ActionResult Edit(GeneratedRentalContract generatedrentalcontract)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GeneratedRentalContractRepository.Edit(generatedrentalcontract);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(generatedrentalcontract);
        }


        public ActionResult Delete(int id)
        {
            var generatedrentalcontract = _unitOfWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            return View(generatedrentalcontract);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var generatedrentalcontract = _unitOfWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            _unitOfWork.GeneratedRentalContractRepository.Delete(generatedrentalcontract);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}