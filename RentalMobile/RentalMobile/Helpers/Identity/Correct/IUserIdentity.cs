using System;

namespace RentalMobile.Helpers.Identity.Correct
{
    public interface IUserIdentity
    {
        string GetUserName();
        Guid? GetUserGuid();
        int? GetTenantId(Guid userId);
        int? GetTenantId();
        int? GetTenantId(int id);
        int GetAgentId();
        int GetAgentId(int id);
        int GetOwnerId();
        int GetOwnerId(int id);
        int GetSpecialistId();
        int GetSpecialistId(int id);
        int GetProviderId();
        int GetProviderId(int id);
        string GetCurrentRole(out string photoPath);
    }
}