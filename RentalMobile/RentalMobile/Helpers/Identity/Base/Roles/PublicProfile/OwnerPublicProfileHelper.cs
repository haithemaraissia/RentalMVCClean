using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PublicProfile
{
    public class OwnerPublicProfileHelper : BaseController, IOwnerPublicProfileHelper
    {
        public OwnerPublicProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public Owner GetPublicProfileOwnerByOwnerId(int id)
        {
            var ownerId = new UserIdentity(UnitofWork, MembershipService).GetOwnerId();
            return UnitofWork.OwnerRepository.FindBy(x => x.OwnerId ==
                ownerId).FirstOrDefault();
        }

        public string OwnerPublicProfileUsername()
        {
            return new UserIdentity(UnitofWork, MembershipService).GetUserName();
        }
    }
}