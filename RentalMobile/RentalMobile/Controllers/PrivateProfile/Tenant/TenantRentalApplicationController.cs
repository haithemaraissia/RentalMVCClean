using System;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Tenant
{
    [Authorize (Roles = "Tenant")]
    public class TenantRentalApplicationController : BaseController
    {
        public TenantRentalApplicationController(IGenericUnitofWork uow, 
            IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var tenantId = UserHelper.GetTenantId();
            var tenantrentalapplication = UnitofWork.RentalApplicationRepository
                .FindBy(x => x.TenantId == tenantId);
            return View(tenantrentalapplication.FirstOrDefault());
        }

        public ViewResult Details()
        {
            var tenantId = UserHelper.GetTenantId();
            var tenantrentalapplication = UnitofWork.RentalApplicationRepository.
                FindBy(x => x.TenantId == tenantId);
            var rentalApplications = tenantrentalapplication.ToList();
            if (rentalApplications.Any() )
            {
                RedirectToActionPermanent("Create");
            }
            return View(rentalApplications.FirstOrDefault());
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
                rentalapplication.TenantId = UserHelper.GetTenantId();
                UnitofWork.RentalApplicationRepository.Add(rentalapplication);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(rentalapplication);
        }

        public ActionResult Edit()
        {
            var tenantId = UserHelper.GetTenantId();
            var tenantrentalapplication =
                UnitofWork.RentalApplicationRepository.
                FindBy(x => x.TenantId == tenantId);
            var rentalApplications = tenantrentalapplication.ToList();
            if (rentalApplications.Any())
            {
                RedirectToActionPermanent("Create");
            }
            return View(rentalApplications.FirstOrDefault());
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
            var rentalapplication =
               UnitofWork.RentalApplicationRepository.FindBy(x => x.ApplicationId == id).FirstOrDefault();
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

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string propertyIdcustom)
        {

            //Property
            var propertyId = (Convert.ToInt32(propertyIdcustom));
            var property = UnitofWork.UnitRepository.FindBy(x => x.UnitId == propertyId).FirstOrDefault();
            if (property == null)
            {
                return RedirectToAction("submit");
            }

            //OVER HERE YOU HAVE TO
            //CHECK THAT AN APPLICATION EXIST
            var tenantId = UserHelper.GetTenantId();
            var tenantrentalapplication = UnitofWork.RentalApplicationRepository.FindBy(x => x.TenantId == tenantId);
            var rentalApplications = tenantrentalapplication.ToList();
            if (rentalApplications.Any())
            {
                return RedirectToAction("Create", "TenantRentalApplication");

            }

            //PROCESS TO AMAZONPAYPAL
            //YOU DON'T NEED MODEL VALIDATION

            //ALSO WHEN SUCCED
            //ADD ROW IN PAYMENT WITH DESCRIPTION OF THIS TRANSACTION

            //ALSO SEND EMAIL TO LISTER
            //SO HE OR SHE DOES BACKGROUND CHECKING AND ACCPET/DENY APPLICATION

            //Insert into Owner/Agent Pending Application when Application payment is complete 
            //var f = db.Units.Where(t=>t.)

            //WHEN AMAZON PAYMENT SUCCEED
                var posterrole = property.PosterRole.Trim();

                switch (posterrole)
                {
                    case "Owner":
                        //Insert into Pending Application
                        if (property.PosterID != null && rentalApplications.Count > 0 && rentalApplications.First() != null)
                            UserHelper.TenantRentalApplicationHelper.InsertOwnerPendingApplication(rentalApplications.First(), (int)property.PosterID);
                        ViewData["confirmationmsg"] = "Your Application had been succesfully submitted to the Owner.";
                        //Confirmation that is has been posted
                        break;

                    case "Agent":
                        //Insert into Pending Application
                        if (property.PosterID != null)
                            UserHelper.TenantRentalApplicationHelper.InsertAgentPendingApplication(rentalApplications.First(), (int)property.PosterID);
                        ViewData["confirmationmsg"] = "Pass";
                        break;
                }
 
            return View();
        }

    }
}