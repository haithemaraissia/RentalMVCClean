using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Process.Application
{
    public interface ITenantRentalApplication
    {
        void InsertOwnerPendingApplication(RentalApplication r, int ownerId);
        void InsertAgentPendingApplication(RentalApplication r, int agentId);
    }
}
