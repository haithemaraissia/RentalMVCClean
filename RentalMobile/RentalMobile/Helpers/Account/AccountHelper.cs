using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.IO;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Helpers.Account
{
    public class AccountHelper : BaseController
    {

        #region AccountHelper Constructor
        /// AccountHelper

        public AccountHelper(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        #endregion

        #region ChangeEmail
        /// ChangeEmail

        public void ChangeSpecialistEmail(ChangeEmail model)
        {
            //Specialist
            var specialistId = UserHelper.GetSpecialistId();
            if (specialistId == 0)
            {
                UserHelper.Login();
            }
            else
            {
                var specialist = UserHelper.GetPrivateProfileSpecialistBySpecialistId(specialistId);
                {
                    if (specialist != null) specialist.EmailAddress = model.Email;
                }
                UnitofWork.Save();
            }
        }

        public void ChangeTenantEmail(ChangeEmail model)
        {
            //Tenant
            var tenantId = UserHelper.GetTenantId();
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

        public void ChangeProviderEmail(ChangeEmail model)
        {
            //MaintenanceProvider
            var providerId = UserHelper.GetProviderId();
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

        public void ChangeOwnerEmail(ChangeEmail model)
        {
            //Owner
            var ownerId = UserHelper.GetOwnerId();
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
            var agentId = UserHelper.GetAgentId();
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

        public void ChangeEmailByType(ChangeEmail model)
        {
            if (HttpContext.User.IsInRole("Tenant"))
            {
                ChangeTenantEmail(model);
            }

            if (HttpContext.User.IsInRole("Owner"))
            {
                ChangeOwnerEmail(model);
            }

            if (HttpContext.User.IsInRole("Agent"))
            {
                ChangeAgentmail(model);
            }

            if (HttpContext.User.IsInRole("Specialist"))
            {
                ChangeSpecialistEmail(model);
            }
            if (HttpContext.User.IsInRole("Provider"))
            {
                ChangeProviderEmail(model);
            }
        }

        #endregion

        #region RegisterAccount
        /// RegisterAccount

        public void RegisterAccountByType(RegisterModel model)
        {
            if (model.Role == "Tenant")
            {
                RegisterTenant(model);
            }

            if (model.Role == "Owner")
            {
                RegisterOwner(model);
            }

            if (model.Role == "Agent")
            {
                RegisterAgent(model);
            }

            if (model.Role == "Specialist")
            {
                RegisterSpecialist(model);
            }

            if (model.Role == "Provider")
            {
                RegisterProvider(model);
            }
        }

        public void RegisterTenant(RegisterModel model)
        {
            var newtenant = new Tenant { EmailAddress = model.Email };
            var user = MembershipService.GetUser(model.UserName);
            if (user != null)
            {
                var providerUserKey = user.ProviderUserKey;
                if (providerUserKey != null)
                    newtenant.GUID = (Guid)providerUserKey;
                newtenant.FirstName = model.UserName;
                newtenant.Photo = "./../images/dotimages/avatar-placeholder.png";
                newtenant.GoogleMap = "USA";
            }

            UnitofWork.TenantRepository.Add(newtenant);
            UnitofWork.Save();
        }

        public void RegisterOwner(RegisterModel model)
        {
            var newowner = new Owner { EmailAddress = model.Email };
            var user = MembershipService.GetUser(model.UserName);
            if (user != null)
            {
                var providerUserKey = user.ProviderUserKey;
                if (providerUserKey != null)
                    newowner.GUID = (Guid)providerUserKey;
                newowner.FirstName = model.UserName;
                newowner.Photo = "./../images/dotimages/avatar-placeholder.png";
                newowner.GoogleMap = "USA";
            }

            UnitofWork.OwnerRepository.Add(newowner);
            UnitofWork.Save();
        }

        public void RegisterAgent(RegisterModel model)
        {
            var newagent = new Agent { EmailAddress = model.Email };
            var user = MembershipService.GetUser(model.UserName);
            if (user != null)
            {
                var providerUserKey = user.ProviderUserKey;
                if (providerUserKey != null)
                    newagent.GUID = (Guid)providerUserKey;
                newagent.FirstName = model.UserName;
                newagent.Photo = "./../images/dotimages/avatar-placeholder.png";
                newagent.GoogleMap = "USA";
            }

            UnitofWork.AgentRepository.Add(newagent);
            UnitofWork.Save();

        }

        public void RegisterSpecialist(RegisterModel model)
        {
            var newspecialist = new Specialist { EmailAddress = model.Email };
            var user = MembershipService.GetUser(model.UserName);
            if (user != null)
            {
                var providerUserKey = user.ProviderUserKey;
                if (providerUserKey != null)
                    newspecialist.GUID = (Guid)providerUserKey;
                newspecialist.FirstName = model.UserName;
                newspecialist.Photo = "./../images/dotimages/avatar-placeholder.png";
                newspecialist.GoogleMap = "USA";
                newspecialist.PercentageofCompletion = 50;

            }
            UnitofWork.SpecialistRepository.Add(newspecialist);
            UnitofWork.Save();

            SpecialistInitialProfileValues(model, newspecialist.SpecialistId);
        }

        public void RegisterProvider(RegisterModel model)
        {
            var newprovider = new MaintenanceProvider { EmailAddress = model.Email };
            var user = MembershipService.GetUser(model.UserName);
            if (user != null)
            {
                var providerUserKey = user.ProviderUserKey;
                if (providerUserKey != null)
                    newprovider.GUID = (Guid)providerUserKey;
                newprovider.FirstName = model.UserName;
                newprovider.Photo = "./../images/dotimages/avatar-placeholder.png";
                newprovider.GoogleMap = "USA";
            }

            UnitofWork.MaintenanceProviderRepository.Add(newprovider);
            UnitofWork.Save();

            ProviderInitialProfileValues(model, newprovider.MaintenanceProviderId);
        }

        #endregion

        #region InitializeProfileByType
        /// Initialize ProfileByType

        public void SpecialistInitialProfileValues(RegisterModel model, int specialistId)
        {

            if (specialistId != 0)
            {
                var newMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp
                {
                    UserId = specialistId,
                    Role = 1
                };
                UnitofWork.MaintenanceCompanyLookUpRepository.Add(newMaintenanceCompanyLookUp);
                UnitofWork.Save();

                var specialistCompanyId = newMaintenanceCompanyLookUp.CompanyId;
                var newMaintenanceCompany = new MaintenanceCompany
                {
                    CompanyId = specialistCompanyId,
                    Name = model.UserName,
                    EmailAddress = model.Email,
                    GoogleMap = "USA",
                    Country = "US"
                    //   CountryCode = "US"
                };
                var newMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization
                {
                    CompanyId = specialistCompanyId,
                    NumberofEmployee = 1,
                    NumberofCertifitedEmplyee = 1,
                    IsInsured = true,
                    Rate = 50,
                    CurrencyID = 1,
                    Currency = "USD"
                };
                var newMaintenanceCustomService = new MaintenanceCustomService
                {
                    CompanyId = specialistCompanyId
                };

                var newMaintenanceExterior = new MaintenanceExterior
                {
                    CompanyId = specialistCompanyId
                };
                var newMaintenanceInterior = new MaintenanceInterior
                {
                    CompanyId = specialistCompanyId
                };
                var newMaintenanceNewConstruction = new MaintenanceNewConstruction
                {
                    CompanyId = specialistCompanyId
                };
                var newMaintenanceRepair = new MaintenanceRepair
                {
                    CompanyId = specialistCompanyId
                };
                var newMaintenanceUtility = new MaintenanceUtility
                {
                    CompanyId = specialistCompanyId
                };
                var specialistwork = new SpecialistWork
                {
                    PhotoPath = "./../images/dotimages/home-handyman-projects.jpg",
                    SpecialistId = specialistCompanyId
                };

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
                var newMaintenanceCompanyLookUp = new MaintenanceCompanyLookUp
                {
                    UserId = providerId,
                    Role = 2
                };
                UnitofWork.MaintenanceCompanyLookUpRepository.Add(newMaintenanceCompanyLookUp);
                UnitofWork.Save();

                var providerCompanyId = newMaintenanceCompanyLookUp.CompanyId;
                var newMaintenanceCompany = new MaintenanceCompany
                {
                    CompanyId = providerCompanyId,
                    Name = model.UserName,
                    EmailAddress = model.Email,
                    GoogleMap = "USA",
                    Country = "US"
                    //   CountryCode = "US"
                };
                var newMaintenanceCompanySpecialization = new MaintenanceCompanySpecialization
                {
                    CompanyId = providerCompanyId,
                    NumberofEmployee = 1,
                    NumberofCertifitedEmplyee = 1,
                    IsInsured = true,
                    Rate = 50,
                    CurrencyID = 1,
                    Currency = "USD"
                };
                var newMaintenanceCustomService = new MaintenanceCustomService
                {
                    CompanyId = providerCompanyId
                };

                var newMaintenanceExterior = new MaintenanceExterior
                {
                    CompanyId = providerCompanyId
                };
                var newMaintenanceInterior = new MaintenanceInterior
                {
                    CompanyId = providerCompanyId
                };
                var newMaintenanceNewConstruction = new MaintenanceNewConstruction
                {
                    CompanyId = providerCompanyId
                };
                var newMaintenanceRepair = new MaintenanceRepair
                {
                    CompanyId = providerCompanyId
                };
                var newMaintenanceUtility = new MaintenanceUtility
                {
                    CompanyId = providerCompanyId
                };
                var providerwork = new ProviderWork
                {
                    PhotoPath = "./../images/dotimages/home-handyman-projects.jpg",
                    ProviderId = providerCompanyId
                };

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

        #region Add Picture
        // Add Picture

        public void AddPicture(string photoPath)
        {
            var role = UserHelper.GetCurrentRole();
            if (role == "Agent")
            {
                AddAgentPicture(photoPath);
            }
            if (role == "Owner")
            {
                AddOwnerPicture(photoPath);
            }
            if (role == "Agent")
            {
                AddAgentPicture(photoPath);
            }
            if (role == "Specialist")
            {
                AddSpecialistPicture(photoPath);
            }
            if (role == "Provider")
            {
                AddProviderPicture(photoPath);
            }
        }

        public void AddAgentPicture(string photoPath)
        {
            var agentId = UserHelper.GetAgentId();
            var agent = UnitofWork.AgentRepository.FindBy
                (x => x.AgentId == agentId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (agent != null) agent.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddOwnerPicture(string photoPath)
        {
            var ownerId = UserHelper.GetOwnerId();
            var owner = UnitofWork.OwnerRepository.FindBy
                (x => x.OwnerId == ownerId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (owner != null) owner.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddSpecialistPicture(string photoPath)
        {
            var specialistId = UserHelper.GetSpecialistId();
            var specialist = UnitofWork.SpecialistRepository.FindBy
                (x => x.SpecialistId == specialistId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (specialist != null) specialist.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public void AddProviderPicture(string photoPath)
        {

            var providerId = UserHelper.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.
                FindBy(x => x.MaintenanceProviderId ==
                            providerId).FirstOrDefault();
            if (!ModelState.IsValid) return;
            if (provider != null) provider.Photo = CleanUpPhotoPath(photoPath);
            UnitofWork.Save();
        }

        public string CleanUpPhotoPath(string photoPath)
        {
            return photoPath.Replace(@"~\Photo", @"../../Photo").Replace("\\", "/");
        }
        #endregion

        #region Saving Picture
        //Saving Picture

        public void SavePictures(int id)
        {
            var userName = new UserIdentity(UnitofWork, MembershipService).GetUserName();
            var imageStoragePath = ImageStoragePath();
            var photoPath = PhotoPath();
            var directory = @"\" + userName + @"\" + "Profile" + @"\" + id + @"\";
            var desinationdirectory = @"\" + userName + @"\" + id + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = photoPath + desinationdirectory;
            if (Directory.Exists(newdirectory))
            {
                new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);
            }
            var latestFile = (from f in uploadDirectory.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First();
            if (latestFile != null)
                try
                {
                    var destinationFile = newdirectory + @"\" + latestFile.Name;
                    var virtualdestinationFile = GetVirtualUserPhotoPath() + @"\" + "Profile" + @"\" +
                                                 userName + @"\" + id + @"\" +
                                                 latestFile.Name;
                    if (!System.IO.File.Exists(destinationFile))
                    {
                        var desintationDirectoryFolder = new DirectoryInfo(newdirectory);
                        if (desintationDirectoryFolder.Exists)
                        {
                            var files = desintationDirectoryFolder.GetFiles();
                            foreach (var f in files)
                            {
                                System.IO.File.Delete(f.Name);
                            }
                        }
                        else
                        {
                            new DirectoryHelper().CreateDirectoryIfNotExist(newdirectory);

                        }
                        System.IO.File.Move(latestFile.FullName, destinationFile);
                        AddPicture(virtualdestinationFile);
                    }
                    var uploadfiles = uploadDirectory.GetFiles();
                    foreach (var f in uploadfiles)
                    {
                        System.IO.File.Delete(f.Name);
                    }
                }
                catch (Exception e)
                {

                    Response.Write(string.Format("Error occurs in uploading profile picture! {0}", e.Message));
                }

            new DirectoryHelper().DeleteDirectoryIfExist(path);
        }

        public string PhotoPath()
        {
            var photoPath = HttpContext.Server.MapPath(GetUserPhotoPath());
            return photoPath;
        }

        public string ImageStoragePath()
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
            var role = UserHelper.GetCurrentRole();
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

            if (HttpContext.User.IsInRole("Tenant"))
            {
                UpdateTenantVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Owner"))
            {
                UpdateOwnerVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Agent"))
            {
                UpdateAgentVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Specialist"))
            {
                UpdateSpecialistVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole("Provider"))
            {
                UpdateProviderVideo(primaryVideo);
            }
        }

        public void UpdateProviderVideo(PrimaryVideo primaryVideo)
        {
            var providerId = UserHelper.GetProviderId();
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
            var specialistId = UserHelper.GetSpecialistId();
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
            var agentId = UserHelper.GetAgentId();
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
            var ownerId = UserHelper.GetOwnerId();
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
            var tenantId = UserHelper.GetTenantId();
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
        public void LoadVideoByAccountType(PrimaryVideo primaryVideo)
        {
            if (HttpContext.User.IsInRole("Tenant"))
            {
                LoadTenantVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Owner"))
            {
                LoadOwnerVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Agent"))
            {
                LoadAgentVideo(primaryVideo);
            }

            if (HttpContext.User.IsInRole("Specialist"))
            {
                LoadSpecialistVideo(primaryVideo);
            }
            if (HttpContext.User.IsInRole("Provider"))
            {
                LoadProviderVideo(primaryVideo);
            }
        }

        private void LoadProviderVideo(PrimaryVideo primaryVideo)
        {
            var providerId = UserHelper.GetProviderId();
            var provider = UnitofWork.MaintenanceProviderRepository.FindBy
            (x => x.MaintenanceProviderId == providerId).FirstOrDefault();

            if (provider != null)
            {
                primaryVideo.VimeoVideo = provider.VimeoVideo;
                primaryVideo.VimeoVideoUrl = provider.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = provider.YouTubeVideo;
                primaryVideo.YouTubeVideoUrl = provider.YouTubeVideoURL ?? "";
            }
        }

        private void LoadSpecialistVideo(PrimaryVideo primaryVideo)
        {
            var specialistId = UserHelper.GetSpecialistId();
            var specialist = UnitofWork.SpecialistRepository.FindBy
            (x => x.SpecialistId == specialistId).FirstOrDefault();

            if (specialist != null)
            {
                primaryVideo.VimeoVideo = specialist.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = specialist.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = specialist.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = specialist.YouTubeVideoURL ?? "";
            }
        }

        private void LoadAgentVideo(PrimaryVideo primaryVideo)
        {
            var agentId = UserHelper.GetAgentId();
            var agent = UnitofWork.AgentRepository.FindBy
            (x => x.AgentId == agentId).FirstOrDefault();

            if (agent != null)
            {
                primaryVideo.VimeoVideo = agent.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = agent.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = agent.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = agent.YouTubeVideoURL ?? "";
            }
        }

        private void LoadOwnerVideo(PrimaryVideo primaryVideo)
        {
            var ownerId = UserHelper.GetOwnerId();
            var owner = UnitofWork.OwnerRepository.FindBy
            (x => x.OwnerId == ownerId).FirstOrDefault();

            if (owner != null)
            {
                primaryVideo.VimeoVideo = owner.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = owner.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = owner.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = owner.YouTubeVideoURL ?? "";
            }
        }

        private void LoadTenantVideo(PrimaryVideo primaryVideo)
        {
            var tenantId = UserHelper.GetTenantId();
            var tenant = UnitofWork.TenantRepository.FindBy
            (x => x.TenantId == tenantId).FirstOrDefault();

            if (tenant != null)
            {
                primaryVideo.VimeoVideo = tenant.VimeoVideo ?? false;
                primaryVideo.VimeoVideoUrl = tenant.VimeoVideoURL ?? "";
                primaryVideo.YouTubeVideo = tenant.YouTubeVideo ?? false;
                primaryVideo.YouTubeVideoUrl = tenant.YouTubeVideoURL ?? "";
            }
        }

        #endregion

        #region SendResetEmail
        /// SendResetEmail

        public void SendResetEmail(MembershipUser user)
        {
            //The URL to login
            if (HttpContext.Request.Url == null) return;
            var domain = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath;

            //link to send
            var link = domain + "/Account/Logon";

            var body = "<p> Dear " + user.UserName + ",</p>";
            body += "<p> Your Orion password has been reset, Click " + link + " to login with details below</p>";
            body += "<p> UserName: " + user.UserName + "</p>";
            body += "<p> Password: " + user.ResetPassword() + "</p>";
            body += "<p>It is recomended that you change it after logon.</p>";
            body += "<p>If you did not request a password reset you do not need to take any action.</p>";

            var plainView = AlternateView.CreateAlternateViewFromString
                (Regex.Replace(body, @"<(.|\n)*?>", string.Empty), null, "text/plain");

            var htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

            var message = new MailMessage("haithem-araissia.com", user.Email)
            {
                Subject = "Password Reset",
                BodyEncoding = System.Text.Encoding.GetEncoding("utf-8"),
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);

            var smtpMail = new SmtpClient();
            var basicAuthenticationInfo = new NetworkCredential("postmaster@haithem-araissia.com",
                                                                           "haithem759163");
            smtpMail.Host = "mail.haithem-araissia.com";
            smtpMail.UseDefaultCredentials = false;
            smtpMail.Credentials = basicAuthenticationInfo;
            try
            {
                smtpMail.Send(message);
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