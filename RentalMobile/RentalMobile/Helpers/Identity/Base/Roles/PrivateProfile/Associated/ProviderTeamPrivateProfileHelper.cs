using System;
using System.Collections.Generic;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile.Associated.Provider;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile.Associated
{
    public class ProviderTeamPrivateProfileHelper : BaseController, IProviderTeamPrivateProfileHelper
    {
        public ProviderTeamPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public List<MaintenanceTeam> GetAllProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return
              UnitofWork.MaintenanceTeamRepository.FindBy(
                  x => x.MaintenanceProviderId == 
                      new UserIdentity(UnitofWork, MembershipService).GetProviderId(providerId)).
                      ToList();
        }

        public MaintenanceTeam GetProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return
              UnitofWork.MaintenanceTeamRepository.FindBy(
                  x => x.MaintenanceProviderId ==
                      new UserIdentity(UnitofWork, MembershipService).GetProviderId(providerId)).
                      FirstOrDefault();
        }

        public string ProviderMaintenanceTeamTabUrl()
        {
            var uri = HttpContext.Request.Url;
            if (uri != null)
            {
                return uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port + "/Provider#team";
            }
            return "~/Provider#team";
        }

        public void UpdateMaintenanceTeamsName(MaintenanceTeam maintenanceteam)
        {
            var maintenanceTeamAssociation = UnitofWork.MaintenanceTeamAssociationRepository.
                FindBy(x => x.TeamId == maintenanceteam.TeamId
                           && x.MaintenanceProviderId == UserHelper.GetProviderId()).ToList();
            if (maintenanceTeamAssociation.Count > 0)
            {
                foreach (var mta in maintenanceTeamAssociation)
                {
                    mta.TeamName = maintenanceteam.TeamName;
                }
            }
            UnitofWork.Save();
        }
    }
}