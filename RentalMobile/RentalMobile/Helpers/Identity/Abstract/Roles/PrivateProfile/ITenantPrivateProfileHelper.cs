using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile
{
    public interface ITenantPrivateProfileHelper
    {
        #region TenantHelper
        Tenant GetTenant();
        string TenantGoogleMap();
        int GetTenantApplicationCount(int tenantId);
        void DeleteTenantRecords(int tenantId);
        void DeleteTenantMemebership();
        Tenant GetPrivateProfileTenantByTenantId(int id);
        MaintenanceOrder GetMaintenanceOrderByMaintenanceIdPlacedByTenant(int id);
        string TenantPrivateProfileUsername();
        #endregion


        List<GeneratedRentalContract> GetTenantContract(int tenantId);
        void AddTenantRequestPictures(string key);
        void AddMaintenancePhoto(int maintenanceId, string photoPath);
    }
}
