using System;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Process.JobOffer
{
    public interface IJobOfferHelper
    {
        void InsertPendingJobOffer(int providerid, Tenant tenant, int propertyid, DateTime startDate, DateTime endDate);
    }
}
