using System;

namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface IUserIdentity
    {
        string Login();
        string GetUserName();
        Guid? GetUserGuid();
        int GetTenantId(Guid userId);
        int GetTenantId();
        int GetTenantId(int id);
        int GetAgentId();
        int GetAgentId(int id);
        int GetOwnerId();
        int GetOwnerId(int id);
        int GetSpecialistId();
        int GetSpecialistId(int id);
        int GetProviderId();
        int GetProviderId(int id);
        int GetRoleId(string chosenRole);
        string GetCurrentRole();
        string SetPhotoPathByCurrentRole(out string photoPath);
        string ResolveImageUrl(string relativeUrl);
    }
}