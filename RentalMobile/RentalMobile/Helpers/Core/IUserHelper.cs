using RentalMobile.Helpers.Identity.Abstract;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile.Associated.Provider;
using RentalMobile.Helpers.Identity.Abstract.Roles.PublicProfile;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile.Associated;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.Process.Application;
using RentalMobile.Helpers.Process.JobOffer;
using RentalMobile.Helpers.Unit;

namespace RentalMobile.Helpers.Core
{
    public interface IUserHelper :

        ISpecialistPrivateProfileHelper, IOwnerPrivateProfileHelper, IAgentPrivateProfileHelper, ITenantPrivateProfileHelper, IProviderPrivateProfileHelper,
        IProviderTeamPrivateProfileHelper,

        ISpecialistPublicProfileHelper, IOwnerPublicProfileHelper, IAgentPublicProfileHelper, ITenantPublicProfileHelper, IProviderPublicProfileHelper,

        IUserIdentity, IPosterHelper, ILocationHelper,

        ITenantRentalApplication, IJobOfferHelper,

        IUnitHelper
    {

        //Private//
        SpecialistPrivateProfileHelper SpecialistPrivateProfileHelper { get; set; }
        OwnerPrivateProfileHelper OwnerPrivateProfileHelper { get; set; }
        AgentPrivateProfileHelper AgentPrivateProfileHelper { get; set; }
        TenantPrivateProfileHelper TenantPrivateProfileHelper { get; set; }
        ProviderPrivateProfileHelper ProviderPrivateProfileHelper { get; set; }
        //Associated
        ProviderTeamPrivateProfileHelper ProviderTeamPrivateProfileHelper { get; set; }

        //Public//
        SpecialistPublicProfileHelper SpecialistPublicProfileHelper { get; set; }
        OwnerPublicProfileHelper OwnerPublicProfileHelper { get; set; }
        AgentPublicProfileHelper AgentPublicProfileHelper { get; set; }
        TenantPublicProfileHelper TenantPublicProfileHelper { get; set; }
        ProviderPublicProfileHelper ProviderPublicProfileHelper { get; set; }

        //Common
        LocationHelper LocationHelper { get; set; }
        PosterHelper PosterHelper { get; set; }
        UserIdentity UserIdentity { get; set; }

        //Process
        TenantRentalApplicationHelper TenantRentalApplicationHelper { get; set; }
        JobOffer JobOffer { get; set; }

        //Unit
        UnitHelper UnitHelper { get; set; }
    }
}