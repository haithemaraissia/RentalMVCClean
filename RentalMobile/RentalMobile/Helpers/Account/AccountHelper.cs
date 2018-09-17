using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Email;
using RentalMobile.Helpers.IO;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Account
{
    public class AccountHelper : BaseController
    {

        #region AccountHelper Constructor
        /// AccountHelper

        public AccountHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper, IEmailService emailService)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
            EmailService = emailService;
        }

        #endregion

        #region ChangeEmail
        /// ChangeEmail
        /// 
        public void ChangeTenantEmail(ChangeEmail model)
        {
            //Tenant
            var tenantId = UserHelper.UserIdentity.GetTenantId();
            if (tenantId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var tenant = UserHelper.TenantPrivateProfileHelper.GetPrivateProfileTenantByTenantId(tenantId);
                {
                    if (tenant != null) tenant.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeOwnerEmail(ChangeEmail model)
        {
            //Owner
            var ownerId = UserHelper.UserIdentity.GetOwnerId();
            if (ownerId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var owner = UserHelper.OwnerPrivateProfileHelper.GetPrivateProfileOwnerByOwnerId(ownerId);
                {
                    if (owner != null) owner.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeAgentmail(ChangeEmail model)
        {
            //Agent
            var agentId = UserHelper.UserIdentity.GetAgentId();
            if (agentId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var agent = UserHelper.AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(agentId);
                {
                    if (agent != null) agent.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeSpecialistEmail(ChangeEmail model)
        {
            //Specialist
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            if (specialistId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var specialist = UserHelper.SpecialistPrivateProfileHelper.GetPrivateProfileSpecialistBySpecialistId(specialistId);
                {
                    if (specialist != null) specialist.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeProviderEmail(ChangeEmail model)
        {
            //MaintenanceProvider
            var providerId = UserHelper.UserIdentity.GetProviderId();
            if (providerId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var provider = UserHelper.ProviderPrivateProfileHelper.GetPrivateProfileProviderByProviderId(providerId);
                {
                    if (provider != null) provider.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeEmailByType(ChangeEmail model)
        {
            if (HttpContext.User.IsInRole(LookUpRoles.TenantRole))
            {
                ChangeTenantEmail(model);
            }

            if (HttpContext.User.IsInRole(LookUpRoles.OwnerRole))
            {
                ChangeOwnerEmail(model);
            }

            if (HttpContext.User.IsInRole(LookUpRoles.AgentRole))
            {
                ChangeAgentmail(model);
            }

            if (HttpContext.User.IsInRole(LookUpRoles.SpecialistRole))
            {
                ChangeSpecialistEmail(model);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.ProviderRole))
            {
                ChangeProviderEmail(model);
            }
        }
        #endregion

        #region RegisterAccount
        /// RegisterAccount

        public void RegisterAccountByType(RegisterModel model)
        {
            if (model.Role == LookUpRoles.TenantRole)
            {
                RegisterTenant(model);
            }

            if (model.Role == LookUpRoles.OwnerRole)
            {
                RegisterOwner(model);
            }

            if (model.Role == LookUpRoles.AgentRole)
            {
                RegisterAgent(model);
            }

            if (model.Role == LookUpRoles.SpecialistRole)
            {
                RegisterSpecialist(model);
            }

            if (model.Role == LookUpRoles.ProviderRole)
            {
                RegisterProvider(model);
            }
        }

        public void RegisterTenant(RegisterModel model)
        {
            var nexttenantId =
                UnitofWork.TenantRepository.All.OrderByDescending(x => x.TenantId)
                .First()
                .TenantId + 1;
            var newtenant = new Tenant { EmailAddress = model.Email, TenantId = nexttenantId };
            var user = MembershipService.GetUser(model.UserName, true);
            if (user != null)
            {
                if (user.ProviderUserKey != null) newtenant.GUID = new Guid(user.ProviderUserKey.ToString());
                newtenant.FirstName = model.UserName;
                newtenant.Photo = "./../images/dotimages/avatar-placeholder.png";
                newtenant.GoogleMap = "USA";
                UnitofWork.TenantRepository.Add(newtenant);
                UnitofWork.Save();
            }
        }

        public void RegisterOwner(RegisterModel model)
        {
            var nextownerId =
                UnitofWork.OwnerRepository.All.OrderByDescending(x => x.OwnerId)
                .First()
                .OwnerId + 1;
            var newowner = new Owner { EmailAddress = model.Email , OwnerId = nextownerId};
            var user = MembershipService.GetUser(model.UserName, true);
            if (user != null)
            {
                if (user.ProviderUserKey != null) newowner.GUID = new Guid(user.ProviderUserKey.ToString());
                newowner.FirstName = model.UserName;
                newowner.Photo = "./../images/dotimages/avatar-placeholder.png";
                newowner.GoogleMap = "USA";
                UnitofWork.OwnerRepository.Add(newowner);
                UnitofWork.Save(); 
            }
        }

        public void RegisterAgent(RegisterModel model)
        {
            var nextagentId =
                UnitofWork.AgentRepository.All.OrderByDescending(x => x.AgentId)
                .First()
                .AgentId + 1; 
            var newagent = new Agent { EmailAddress = model.Email , AgentId = nextagentId};
            var user = MembershipService.GetUser(model.UserName, true);
            if (user != null)
            {
                if (user.ProviderUserKey != null) newagent.GUID = new Guid(user.ProviderUserKey.ToString());
                newagent.FirstName = model.UserName;
                newagent.Photo = "./../images/dotimages/avatar-placeholder.png";
                newagent.GoogleMap = "USA";
                UnitofWork.AgentRepository.Add(newagent);
                UnitofWork.Save();
            }
        }

        public void RegisterSpecialist(RegisterModel model)
        {
            var nextspecialistId =
                    UnitofWork.SpecialistRepository.All.OrderByDescending(x => x.SpecialistId)
                        .First()
                        .SpecialistId + 1;
            var newspecialist = new Specialist { EmailAddress = model.Email, SpecialistId = nextspecialistId };
            var user = MembershipService.GetUser(model.UserName, true);
            if (user != null)
            {
                if (user.ProviderUserKey != null) newspecialist.GUID = new Guid(user.ProviderUserKey.ToString());
                newspecialist.FirstName = model.UserName;
                newspecialist.Photo = "./../images/dotimages/avatar-placeholder.png";
                newspecialist.GoogleMap = "USA";
                newspecialist.PercentageofCompletion = 50;
                UnitofWork.SpecialistRepository.Add(newspecialist);
                UnitofWork.Save();
                SpecialistInitialProfileValues(model, newspecialist.SpecialistId);
            }
        }

        public void RegisterProvider(RegisterModel model)
        {
            var nextproviderId = UnitofWork.MaintenanceProviderRepository.All.
                OrderByDescending(x => x.MaintenanceProviderId).
                First().MaintenanceProviderId + 1;
            var newprovider = new MaintenanceProvider { EmailAddress = model.Email, MaintenanceProviderId = nextproviderId };
            var user = MembershipService.GetUser(model.UserName, true);
            if (user != null)
            {
                if (user.ProviderUserKey != null) newprovider.GUID = new Guid(user.ProviderUserKey.ToString());
                newprovider.FirstName = model.UserName;
                newprovider.Photo = "./../images/dotimages/avatar-placeholder.png";
                newprovider.GoogleMap = "USA";
                UnitofWork.MaintenanceProviderRepository.Add(newprovider);
                UnitofWork.Save();
                ProviderInitialProfileValues(model, newprovider.MaintenanceProviderId);
            }
        }

        #region InitializeProfileByType
        /// Initialize ProfileByType

        public void SpecialistInitialProfileValues(RegisterModel model, int specialistId)
        {

            if (specialistId != 0)
            {  
                var nextCompanyId =
                    UnitofWork.MaintenanceCompanyLookUpRepository.All.OrderByDescending(x => x.CompanyId)
                        .First()
                        .CompanyId + 1;      
                var newMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp
                {
                    CompanyId = nextCompanyId,
                    UserId = specialistId,
                    Role = (int) LookUpRoles.Roles.Specialist
                };
                var newMaintenanceCompany = new MaintenanceCompany
                {
                    CompanyId = nextCompanyId,
                    Name = model.UserName,
                    EmailAddress = model.Email,
                    GoogleMap = "USA",
                    Country = "US",
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                    //   CountryCode = "US"
                };
                var newMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization
                {
                    CompanyId = nextCompanyId,
                    NumberofEmployee = 1,
                    NumberofCertifitedEmplyee = 1,
                    IsInsured = true,
                    Rate = 50,
                    CurrencyID = 1,
                    Currency = "USD",
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceCustomService = new MaintenanceCustomService
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceExterior = new MaintenanceExterior
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceInterior = new MaintenanceInterior
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceNewConstruction = new MaintenanceNewConstruction
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceRepair = new MaintenanceRepair
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceUtility = new MaintenanceUtility
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var specialistwork = new SpecialistWork
                {
                    PhotoPath = "./../images/dotimages/home-handyman-projects.jpg",
                    SpecialistId = specialistId
                };

                UnitofWork.MaintenanceCompanyLookUpRepository.Add(newMaintenanceCompanyLookUp);
                UnitofWork.MaintenanceCompanyRepository.Add(newMaintenanceCompany);
                UnitofWork.MaintenanceCompanySpecializationRepository.Add(newMaintenanceCompanySpecialization);
                UnitofWork.MaintenanceCustomServiceRepository.Add(newMaintenanceCustomService);
                UnitofWork.MaintenanceExteriorRepository.Add(newMaintenanceExterior);
                UnitofWork.MaintenanceInteriorRepository.Add(newMaintenanceInterior);
                UnitofWork.MaintenanceNewConstructionRepository.Add(newMaintenanceNewConstruction);
                UnitofWork.MaintenanceRepairRepository.Add(newMaintenanceRepair);
                UnitofWork.MaintenanceUtilityRepository.Add(newMaintenanceUtility);
                UnitofWork.SpecialistWorkRepository.Add(specialistwork);
                UnitofWork.Save();

            }
        }

        public void ProviderInitialProfileValues(RegisterModel model, int providerId)
        {

            if (providerId != 0)
            {
                var nextCompanyId =
                    UnitofWork.MaintenanceCompanyLookUpRepository.All.OrderByDescending(x => x.CompanyId)
                        .First()
                        .CompanyId + 1;      

                var newMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp
                {
                    CompanyId = nextCompanyId,
                    UserId = providerId,
                    Role = (int)LookUpRoles.Roles.Provider
                };
                var newMaintenanceCompany = new MaintenanceCompany
                {
                    CompanyId = nextCompanyId,
                    Name = model.UserName,
                    EmailAddress = model.Email,
                    GoogleMap = "USA",
                    Country = "US",
                    //   CountryCode = "US"
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization
                {
                    CompanyId = nextCompanyId,
                    NumberofEmployee = 1,
                    NumberofCertifitedEmplyee = 1,
                    IsInsured = true,
                    Rate = 50,
                    CurrencyID = 1,
                    Currency = "USD",
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceCustomService = new MaintenanceCustomService
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };

                var newMaintenanceExterior = new MaintenanceExterior
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceInterior = new MaintenanceInterior
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceNewConstruction = new MaintenanceNewConstruction
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceRepair = new MaintenanceRepair
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var newMaintenanceUtility = new MaintenanceUtility
                {
                    CompanyId = nextCompanyId,
                    MaintenanceCompanyLookUp = newMaintenanceCompanyLookUp
                };
                var providerwork = new ProviderWork
                {
                    PhotoPath = "./../images/dotimages/home-handyman-projects.jpg",
                    ProviderId = providerId
                };
                UnitofWork.MaintenanceCompanyLookUpRepository.Add(newMaintenanceCompanyLookUp);
                UnitofWork.MaintenanceCompanyRepository.Add(newMaintenanceCompany);
                UnitofWork.MaintenanceCompanySpecializationRepository.Add(newMaintenanceCompanySpecialization);
                UnitofWork.MaintenanceCustomServiceRepository.Add(newMaintenanceCustomService);
                UnitofWork.MaintenanceExteriorRepository.Add(newMaintenanceExterior);
                UnitofWork.MaintenanceInteriorRepository.Add(newMaintenanceInterior);
                UnitofWork.MaintenanceNewConstructionRepository.Add(newMaintenanceNewConstruction);
                UnitofWork.MaintenanceRepairRepository.Add(newMaintenanceRepair);
                UnitofWork.MaintenanceUtilityRepository.Add(newMaintenanceUtility);
                UnitofWork.ProviderWorkRepository.Add(providerwork);
                UnitofWork.Save();

            }
        }

        #endregion

        #endregion
 
        #region Add Picture
        // Add Picture

        public void AddPictureToProfile(string photoPath)
        {
            var role = UserHelper.UserIdentity.GetCurrentRole();
            if (role == LookUpRoles.TenantRole)
            {
                AddTenantPicture(photoPath);
            }
            if (role == LookUpRoles.OwnerRole)
            {
                AddOwnerPicture(photoPath);
            }
            if (role == LookUpRoles.AgentRole)
            {
                AddAgentPicture(photoPath);
            }
            if (role == LookUpRoles.SpecialistRole)
            {
                AddSpecialistPicture(photoPath);
            }
            if (role == LookUpRoles.ProviderRole)
            {
                AddProviderPicture(photoPath);
            }
        }

        public void AddTenantPicture(string photoPath)
        {
            var tenantId = UserHelper.UserIdentity.GetTenantId();
            var tenant = UnitofWork.TenantRepository.FindBy
                (x => x.TenantId == tenantId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (tenant != null) tenant.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddOwnerPicture(string photoPath)
        {
            var ownerId = UserHelper.UserIdentity.GetOwnerId();
            var owner = UnitofWork.OwnerRepository.FindBy
                (x => x.OwnerId == ownerId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (owner != null) owner.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }   
      
        public void AddAgentPicture(string photoPath)
        {
            var agentId = UserHelper.UserIdentity.GetAgentId();
            var agent = UnitofWork.AgentRepository.FindBy
                (x => x.AgentId == agentId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (agent != null) agent.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddSpecialistPicture(string photoPath)
        {
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            var specialist = UnitofWork.SpecialistRepository.FindBy
                (x => x.SpecialistId == specialistId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (specialist != null) specialist.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddProviderPicture(string photoPath)
        {
            var providerId = UserHelper.UserIdentity.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.
                FindBy(x => x.MaintenanceProviderId ==
                            providerId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (provider != null) provider.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public string CleanUpPhotoPath(string photoPath)
        {
            return photoPath.Replace(@"~\Photo", @"../../Photo").Replace(@"\", "/");
        }
        #endregion

        #region Saving Picture
        //Saving Picture

        public void SaveProfilePhoto(int uploaderId)
        {
            var userName = UserHelper.UserIdentity.GetUserName();
            var imageStoragePath = UploadPath();
            var photoPath = PhotoPath();
            var directory = @"\" + userName + @"\" + "Profile" + @"\" + uploaderId + @"\";
            var desinationdirectory = @"\" + userName + @"\" + uploaderId + @"\";
            var path = imageStoragePath + directory;
            CreateDirectoryIfItDoesNotExist(path);
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = photoPath + desinationdirectory;
            var newDirectoryPath = new DirectoryInfo(newdirectory);
            CreateDirectoryIfItDoesNotExist(newdirectory);

            var filesInDirectoryCount = (from f in uploadDirectory.GetFiles() orderby f.LastWriteTime descending select f).Count();
            if (filesInDirectoryCount <= 0) return;
            var latestUploadedFile = (from f in uploadDirectory.GetFiles() orderby f.LastWriteTime descending select f).First();

            if (latestUploadedFile != null)
                try
                {                       
                    var destinationFile = newdirectory + @"\" + latestUploadedFile.Name;
                    var virtualdestinationFile = GetVirtualUserPhotoPath() + @"\" + "Profile" + @"\" + userName + @"\" + uploaderId + @"\" + latestUploadedFile.Name;
                    DeleteDestinationDirectoryFiles(newDirectoryPath);
                    CopyUploadedFileToDestinationFolder(latestUploadedFile, destinationFile);
                    AddPictureToProfile(virtualdestinationFile);
                    DeleteUploadDirectoryFiles(uploadDirectory);
                }
                catch (Exception e)
                {

                    Response.Write(string.Format("Error occurs in uploading profile picture! {0}", e.Message));
                }
        }

        public void CopyUploadedFileToDestinationFolder(FileInfo latestUploadedFile, string destinationFile)
        {
                System.IO.File.Delete(destinationFile);
                System.IO.File.Copy(latestUploadedFile.FullName, destinationFile);
        }

        public void DeleteDestinationDirectoryFiles(DirectoryInfo  newdirectory )
        {
            var uploadfiles = newdirectory.GetFiles();
            foreach (var f in uploadfiles)
            {
                System.IO.File.Delete(f.FullName);
            }

        }

        public void DeleteUploadDirectoryFiles(DirectoryInfo uploadDirectory)
        {
            var uploadfiles = uploadDirectory.GetFiles();
            foreach (var f in uploadfiles)
            {
                System.IO.File.Delete(f.FullName);
            }
        }

        public void CreateDirectoryIfItDoesNotExist(string newdirectory)
        {
            if (Directory.Exists(newdirectory) == false)
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
        }

        public string PhotoPath()
        {
            var photoPath = HttpContext.Server.MapPath(GetUserPhotoPath());
            return photoPath;
        }

        public string UploadPath()
        {
            var imageStoragePath = HttpContext.Server.MapPath("~/UploadedImages");
            return imageStoragePath;
        }

        public string GetUserPhotoPath()
        {
            var role = UserHelper.UserIdentity.GetCurrentRole();
            if (role != null)
            {
                return "~/Photo/" + role + "/Profile";
            }
            return null;
        }

        public string GetVirtualUserPhotoPath()
        {
            var role = UserHelper.UserIdentity.GetCurrentRole();
            if (role != null)
            {
                return @"~\Photo\" + role;
            }
            return null;
        }

        #endregion

        #region Update and Load Video
        /// <summary>
        /// Update Video
        /// </summary>
        /// <param name="primaryVideo"></param>

        public void UpdateVideoByAccountType(PrimaryVideo primaryVideo)
        {
            if (HttpContext.User.IsInRole(LookUpRoles.TenantRole))
            {
                UpdateTenantVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.OwnerRole))
            {
                UpdateOwnerVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.AgentRole))
            {
                UpdateAgentVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.SpecialistRole))
            {
                UpdateSpecialistVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.ProviderRole))
            {
                UpdateProviderVideo(primaryVideo);
            }
        }

        public void UpdateProviderVideo(PrimaryVideo primaryVideo)
        {
            var providerId = UserHelper.UserIdentity.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.FindBy
               (x => x.MaintenanceProviderId == providerId).FirstOrDefault();
            if (provider != null)
            {
                provider.VimeoVideo = primaryVideo.VimeoVideo;
                provider.VimeoVideoURL = primaryVideo.VimeoVideoUrl;
                provider.YouTubeVideo = primaryVideo.YouTubeVideo;
                provider.YouTubeVideoURL = primaryVideo.YouTubeVideoUrl;
            }

            UnitofWork.Save();
        }

        public void UpdateSpecialistVideo(PrimaryVideo primaryVideo)
        {
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            var specialist = UnitofWork.SpecialistRepository.FindBy
          (x => x.SpecialistId == specialistId).FirstOrDefault();

            if (specialist != null)
            {
                specialist.VimeoVideo = primaryVideo.VimeoVideo;
                specialist.VimeoVideoURL = primaryVideo.VimeoVideoUrl;
                specialist.YouTubeVideo = primaryVideo.YouTubeVideo;
                specialist.YouTubeVideoURL = primaryVideo.YouTubeVideoUrl;
            }

            UnitofWork.Save();
        }

        public void UpdateAgentVideo(PrimaryVideo primaryVideo)
        {
            var agentId = UserHelper.UserIdentity.GetAgentId();
            var agent = UnitofWork.AgentRepository.FindBy
          (x => x.AgentId == agentId).FirstOrDefault();

            if (agent != null)
            {
                agent.VimeoVideo = primaryVideo.VimeoVideo;
                agent.VimeoVideoURL = primaryVideo.VimeoVideoUrl;
                agent.YouTubeVideo = primaryVideo.YouTubeVideo;
                agent.YouTubeVideoURL = primaryVideo.YouTubeVideoUrl;
            }

            UnitofWork.Save();
        }

        public void UpdateOwnerVideo(PrimaryVideo primaryVideo)
        {
            var ownerId = UserHelper.UserIdentity.GetOwnerId();
            var owner = UnitofWork.OwnerRepository.FindBy
          (x => x.OwnerId == ownerId).FirstOrDefault();

            if (owner != null)
            {
                owner.VimeoVideo = primaryVideo.VimeoVideo;
                owner.VimeoVideoURL = primaryVideo.VimeoVideoUrl;
                owner.YouTubeVideo = primaryVideo.YouTubeVideo;
                owner.YouTubeVideoURL = primaryVideo.YouTubeVideoUrl;
            }

            UnitofWork.Save();
        }

        public void UpdateTenantVideo(PrimaryVideo primaryVideo)
        {
            var tenantId = UserHelper.UserIdentity.GetTenantId();
            var tenant = UnitofWork.TenantRepository.FindBy
          (x => x.TenantId == tenantId).FirstOrDefault();

            if (tenant != null)
            {
                tenant.VimeoVideo = primaryVideo.VimeoVideo;
                tenant.VimeoVideoURL = primaryVideo.VimeoVideoUrl;
                tenant.YouTubeVideo = primaryVideo.YouTubeVideo;
                tenant.YouTubeVideoURL = primaryVideo.YouTubeVideoUrl;
            }

            UnitofWork.Save();
        }

        /// <summary>
        /// Load Video
        /// </summary>
        /// <param name="primaryVideo"></param>
        public PrimaryVideo LoadVideoByAccountType(PrimaryVideo primaryVideo)
        {
            if (HttpContext.User.IsInRole(LookUpRoles.TenantRole))
            {
                LoadTenantVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.OwnerRole))
            {
                LoadOwnerVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.AgentRole))
            {
                LoadAgentVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.SpecialistRole))
            {
                LoadSpecialistVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole(LookUpRoles.ProviderRole))
            {
                LoadProviderVideo(primaryVideo);
            }
            return null;
        }

        public PrimaryVideo LoadProviderVideo(PrimaryVideo primaryVideo)
        {
            var providerId = UserHelper.UserIdentity.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.FindBy
            (x => x.MaintenanceProviderId == providerId).FirstOrDefault();

            if (provider != null)
            {
                primaryVideo.VimeoVideo = provider.VimeoVideo;
                primaryVideo.VimeoVideoUrl = provider.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = provider.YouTubeVideo;
                primaryVideo.YouTubeVideoUrl = provider.YouTubeVideoURL ?? "";
            }
            return primaryVideo;
        }

        public PrimaryVideo LoadSpecialistVideo(PrimaryVideo primaryVideo)
        {
            var specialistId = UserHelper.UserIdentity.GetSpecialistId();
            var specialist = UnitofWork.SpecialistRepository.FindBy
            (x => x.SpecialistId == specialistId).FirstOrDefault();

            if (specialist != null)
            {
                primaryVideo.VimeoVideo = specialist.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = specialist.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = specialist.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = specialist.YouTubeVideoURL ?? "";
            }
            return primaryVideo;
        }

        public PrimaryVideo LoadAgentVideo(PrimaryVideo primaryVideo)
        {
            var agentId = UserHelper.UserIdentity.GetAgentId();
            var agent = UnitofWork.AgentRepository.FindBy
            (x => x.AgentId == agentId).FirstOrDefault();

            if (agent != null)
            {
                primaryVideo.VimeoVideo = agent.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = agent.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = agent.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = agent.YouTubeVideoURL ?? "";
            }
            return primaryVideo;
        }

        public PrimaryVideo LoadOwnerVideo(PrimaryVideo primaryVideo)
        {
            var ownerId = UserHelper.UserIdentity.GetOwnerId();
            var owner = UnitofWork.OwnerRepository.FindBy
            (x => x.OwnerId == ownerId).FirstOrDefault();

            if (owner != null)
            {
                primaryVideo.VimeoVideo = owner.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = owner.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = owner.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = owner.YouTubeVideoURL ?? "";
            }
            return primaryVideo;
        }

        public PrimaryVideo LoadTenantVideo( PrimaryVideo primaryVideo)
        {
            var tenantId = UserHelper.UserIdentity.GetTenantId();
            var tenant = UnitofWork.TenantRepository.FindBy
            (x => x.TenantId == tenantId).FirstOrDefault();

            if (tenant != null)
            {
                primaryVideo.VimeoVideo = tenant.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = tenant.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = tenant.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = tenant.YouTubeVideoURL ?? "";
            }
            return primaryVideo;
        }

        #endregion

        #region SendResetEmail
        /// SendResetEmail

        public void SendResetEmail(MembershipUser user)
        {
            var messagebody = ComposeEmailMessage(user);
            var plainView = AlternateView.CreateAlternateViewFromString(Regex.Replace(messagebody, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString(messagebody, null, "text/html");
            var message = new MailMessage("haithem-araissia.com", user.Email)
            {
                Subject = "Password Reset",
                BodyEncoding = Encoding.GetEncoding("utf-8"),
                IsBodyHtml = true,
                Priority = MailPriority.High
            }; 
            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);
            SendEmailMessage(message);
        }

        public string ComposeEmailMessage(MembershipUser user)
        {
            var domainLink = GetDomainLink();
            var body = "<p> Dear " + user.UserName + ",</p>";
            body += "<p> Your password has been reset. Click " + domainLink + " to login with details below</p>";
            body += "<p> UserName: " + user.UserName + "</p>";
            body += "<p> Password: " + MembershipService.ResetPassword() + "</p>";
            body += "<p> It is recommended that you change it after logging in.</p>";
            body += "<p> If you did not request a password reset, you do not need to take any action.</p>";
            return body;
        }

        public string GetDomainLink()
        {
            //The URL to login
            if (HttpContext.Request.Url == null) return "";
            var domain = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath;

            //link to send
            return domain + "/Account/Logon";
        }

        public void SendEmailMessage(MailMessage message)
        {
            try
            {
                EmailService.SendEmail(message);
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        #endregion
    }
}