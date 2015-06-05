using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PublicProfile
{
    public class TenantPublicProfileHelper : BaseController ,ITenantPublicProfileHelper
    {
        public string TenantPhotoPath = @"~/Photo/Tenant/Requests";
        public string RequestId;
        public string RequestType = "Request";

        public TenantPublicProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public Tenant GetPublicProfileTenantByTenantId(int id)
        {
            var tenantId = new UserIdentity(UnitofWork, MembershipService).GetTenantId();
            return UnitofWork.TenantRepository.FindBy(x => x.TenantId == tenantId).FirstOrDefault();
        }

        public string TenantPublicProfileUsername()
        {
            return new UserIdentity(UnitofWork, MembershipService).GetUserName();
        }

    }
}