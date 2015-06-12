using System;
using System.Collections.Generic;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile.Associated.Provider;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile.Associated
{
    public class ProviderTeamPrivateProfileHelper : BaseController, IProviderTeamPrivateProfileHelper
    {
        public ProviderTeamPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public List<MaintenanceTeam> GetAllProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return
              UnitofWork.MaintenanceTeamRepository.FindBy(x => x.MaintenanceProviderId == providerId).ToList();
        }

        public MaintenanceTeam GetProviderPrivateMaintenanceTeamByProviderId(int providerId)
        {
            return
              UnitofWork.MaintenanceTeamRepository.FindBy(
                  x => x.MaintenanceProviderId ==
                      providerId).
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
            var providerId = UserHelper.GetProviderId();
            var maintenanceTeamAssociation = UnitofWork.MaintenanceTeamAssociationRepository.
                FindBy(x => x.TeamId == maintenanceteam.TeamId
                           && x.MaintenanceProviderId == providerId).ToList();
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