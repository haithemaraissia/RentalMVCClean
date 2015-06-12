using System.Globalization;
using System.Linq;
using RentalMobile.Helpers;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile
{
    public class ViewHelper
    {
        private readonly UnitofWork _unitofWork;
        public ViewHelper(IGenericUnitofWork uow)
        {
            _unitofWork = (UnitofWork)uow;
        }
        public ViewHelper()
        {
            _unitofWork = new UnitofWork();
        }

        public bool ProviderHasAnyTeamMember(int maintenanceProviderId)
        {
            var maintenanceTeamAssociation = _unitofWork.MaintenanceTeamAssociationRepository.FindBy(x => x.MaintenanceProviderId == maintenanceProviderId);
            return maintenanceTeamAssociation.Any();
        }

        /// <summary>
        /// InviteTeamMember
        /// </summary>
        /// <returns></returns>

        public string DefaultAvatarPlaceholderImagePath = "../../images/dotimages/avatar-placeholder.png";
        public string DefaultSpecialistName = "Specialist";

        public PosterAttributes DefaultPoster = new PosterAttributes("A Friend", "Friend", "#", "../../images/dotimages/single-property/agent-480x350.png", "none@yahoo.com", "notauthenticated", 0);

        public string GetTeamPrimaryPhoto(int id)
         {
        var maintenanceProvider = _unitofWork.MaintenanceProviderRepository.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (maintenanceProvider == null || maintenanceProvider.Photo == null)
            {
                return DefaultAvatarPlaceholderImagePath;
            }
            return maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture);
         }

        public string GetSpecialistPrimaryPhoto(int id)
        {
        var specialist = _unitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == id);
        if (specialist == null || specialist.Photo == null)
        {
            return DefaultAvatarPlaceholderImagePath;
        }
        return specialist.Photo.ToString(CultureInfo.InvariantCulture);
        }

        public string GetSpecialistName(int id)
        {
            var specialist = _unitofWork.SpecialistRepository.FirstOrDefault(x => x.SpecialistId == id);
            return specialist != null ? specialist.FirstName + " " + specialist.LastName : DefaultSpecialistName;
        }
    }
}