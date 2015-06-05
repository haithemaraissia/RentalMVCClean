using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Process.JobOffer
{
    public class JobOffer : BaseController, IJobOfferHelper
    {

        public JobOffer(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }


        public void InsertPendingJobOffer(int providerid, Tenant tenant, int propertyid, DateTime startDate, DateTime endDate)
        {
            var provider = UnitofWork.MaintenanceProviderRepository.FindBy(x=>x.MaintenanceProviderId == providerid).FirstOrDefault();
            if (provider == null) return;
            //var opa = new OwnerPendingApplication
            var mpj = new MaintenanceProviderNewJobOffer
            {
                TenantId = tenant.TenantId,
                TenantName = tenant.FirstName + " " + tenant.LastName,
                TenantEmailAddress = tenant.EmailAddress,
                PropertyId = propertyid,
                StartDate = startDate,
                EndDate = endDate
            };

            try
            {
                UnitofWork.MaintenanceProviderNewJobOfferRepository.Add(mpj);
                UnitofWork.Save();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(@"Entity of type ""{0}"" in state ""{1}"" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(@"- Property: ""{0}"", Error: ""{1}""",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            ViewData["confirmationmsg"] = "Your Application had been succesfully submitted to the Owner.";
            ViewData["confirmationmsg"] = "Your Application had been succesfully submitted to the Provider.";
        }

    }
}