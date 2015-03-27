using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface ISpecialistHelper
    {
        string GetTeamPrimaryPhoto(int id);
        string GetSpecialistPrimaryPhoto(int id);
        string GetSpecialistName(int id);
        int GetTotalAvailableZoneSpotForProvider(int providerId);
    }
}
