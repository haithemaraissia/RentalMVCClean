using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity.Abstract.Roles.PrivateProfile;
using RentalMobile.Helpers.IO;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile
{
    public class TenantPrivateProfileHelper : BaseController ,ITenantPrivateProfileHelper
    {
        public string TenantPhotoPath = @"~/Photo/Tenant/Requests";
        public string RequestId;
        public string RequestType = "Request";

        public TenantPrivateProfileHelper(IGenericUnitofWork uow, IMembershipService membershipService)
        {
            MembershipService = membershipService;
            UnitofWork = uow;
        }

        public Tenant GetTenant()
        {
            var tenantId = new UserIdentity(UnitofWork, MembershipService).GetTenantId();
            return UnitofWork.TenantRepository.FindBy(x => x.TenantId == tenantId).FirstOrDefault();
        }

        public string TenantGoogleMap()
        {
            return string.IsNullOrEmpty(GetTenant().Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(GetTenant().Address, GetTenant().City, GetTenant().CountryCode);
        }

        public int GetTenantApplicationCount(int tenantId)
        {
            return UnitofWork.TenantRepository.Count(x => x.TenantId == tenantId);
        }

        public void DeleteTenantRecords(int tenantId)
        {
            //Tenant
            UnitofWork.TenantRepository.Delete(GetPrivateProfileTenantByTenantId(tenantId));

            //TenantShowing
            var tenantShowings = UnitofWork.TenantShowingRepository.FindBy(x => x.TenantId == tenantId);
            if (tenantShowings == null) return;
            foreach (var tenantShowing in tenantShowings)
            {
                UnitofWork.TenantShowingRepository.Delete(tenantShowing);
            }
            UnitofWork.Save();
        }

        public void DeleteTenantMemebership()
        {
            var username = UserHelper.GetUserName();
            if (MembershipService.GetRolesForUser(username).Any())
            {
                MembershipService.RemoveUserFromRoles(username,
                    MembershipService.GetRolesForUser(username));
            }
            MembershipService.DeleteUser(username);
            MembershipService.SignOut();
        }


        public Tenant GetPrivateProfileTenantByTenantId(int id)
        {
            return UnitofWork.TenantRepository.FindBy(x => x.TenantId == new UserIdentity(UnitofWork, MembershipService).GetTenantId(id)).FirstOrDefault();
        }

        public MaintenanceOrder GetMaintenanceOrderByMaintenanceIdPlacedByTenant(int id)
        {
            return UnitofWork.MaintenanceOrderRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
        }

        public string TenantPrivateProfileUsername()
        {
            return new UserIdentity(UnitofWork, MembershipService).GetUserName();
        }

        public List<GeneratedRentalContract> GetTenantContract(int tenantId)
        {
            return (List<GeneratedRentalContract>) UnitofWork.GeneratedRentalContractRepository.FindBy(x => x.TenantID == tenantId);
        }

        public void AddTenantRequestPictures(string key)
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            var photoPath = HttpContext.Server.MapPath(TenantPhotoPath);
            var directory = @"\" + TenantPrivateProfileUsername() + @"\" + "Requests" + @"\" + TempData[key] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = photoPath + directory;
            if (Directory.Exists(path))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            var files = uploadDirectory.GetFiles();
            foreach (var f in files)
            {
                var destinationFile = newdirectory + @"\" + f.Name;
                var virtualdestinationFile = TenantPhotoPath + directory + f.Name;
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(f.FullName, destinationFile);
                    AddMaintenancePhoto(Convert.ToInt32(TempData[key]), virtualdestinationFile);
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            new DirectoryHelper().DeleteDirectoryIfExist(path);
        }


        public void AddMaintenancePhoto(int maintenanceId, string photoPath)
        {
            var maintenancephoto = new MaintenancePhoto { MaintenanceID = maintenanceId, PhotoPath = photoPath };
            if (!ModelState.IsValid) return;
            UnitofWork.MaintenancePhotoRepository.Add(maintenancephoto);
            UnitofWork.Save();
        }
    }
}