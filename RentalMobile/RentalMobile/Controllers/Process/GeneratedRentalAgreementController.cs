using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.Process
{
    public class GeneratedRentalAgreementController : BaseController
    {
        public GeneratedRentalAgreementController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ViewResult Index()
        {
            return View(UnitofWork.GeneratedRentalContractRepository.All.ToList());
        }

        public ViewResult Details(int id)
        {
            var generatedrentalcontract = UnitofWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
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
                UnitofWork.GeneratedRentalContractRepository.Add(generatedrentalcontract);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }

            return View(generatedrentalcontract);
        }

        public ActionResult Edit(int id)
        {
            var generatedrentalcontract = UnitofWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            return View(generatedrentalcontract);
        }


        [HttpPost]
        public ActionResult Edit(GeneratedRentalContract generatedrentalcontract)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.GeneratedRentalContractRepository.Edit(generatedrentalcontract);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(generatedrentalcontract);
        }


        public ActionResult Delete(int id)
        {
            var generatedrentalcontract = UnitofWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            return View(generatedrentalcontract);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var generatedrentalcontract = UnitofWork.GeneratedRentalContractRepository.FindBy(x => x.ID == id).FirstOrDefault();
            UnitofWork.GeneratedRentalContractRepository.Delete(generatedrentalcontract);
            UnitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}