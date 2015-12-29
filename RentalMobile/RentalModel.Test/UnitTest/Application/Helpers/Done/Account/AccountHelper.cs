using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Helpers.Account;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.UnitTest.Helpers.Fake;
using TestProject.UnitTest.Helpers.Mocks.Email;
using TestProject.UnitTest.Helpers.Util;
using TestProject.UnitTest.Helpers.Util.Expected;

namespace TestProject.UnitTest.Application.Helpers.Done.Account
{
    [TestClass]
    public class AccountHelperTest
    {

        #region Initialization

        public AccountHelper Controller;
        public AssertHelper Helper = new AssertHelper();
        public UnitofWork Uow;

        #region ExpectedResult Helper
        public Owner ExpectedOwner;
        public Agent ExpectedAgent;
        public Tenant ExpectedTenant;
        public MaintenanceProvider ExpectedProvider;
        public Specialist ExpectedSpecialist;
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            #region AccountHelperTest

            #region Repo
            var maintenanceCompanyLookUpRepo = new FakeMaintenanceCompanyLookUpRepository();
            var maintenanceCompanyRepo = new FakeMaintenanceCompanyRepository();
            var maintenanceCompanySpecializationRepo = new FakeMaintenanceCompanySpecializationRepository();
            var maintenanceCustomServicesRepo = new FakeMaintenanceCustomServiceRepository();
            var maintenanceExteriorRepo = new FakeMaintenanceExteriorRepository();
            var maintenanceInteriorRepo = new FakeMaintenanceInteriorRepository();
            var maintenanceNewConstructionRepo = new FakeMaintenanceNewConstructionRepository();
            var maintenanceRepairRepo = new FakeMaintenanceRepairRepository();
            var maintenanceUtilityRepo = new FakeMaintenanceUtilityRepository();

            var currencyRepo = new FakeCurrencyRepository();
            var specialistProfileCommentRepo = new FakeSpecialistProfileCommentRepository();
            var specialistWorkRepo = new FakeSpecialistWorkRepository();
            var agentRepo = new FakeAgentRepository();
            var ownerRepo = new FakeOwnerRepository();
            var specialistRepo = new FakeSpecialistRepository();
            var tenantRepo = new FakeTenantRepository();
            var providerRepo = new FakeMaintenanceProviderRepository();
            Uow = new UnitofWork
            {
                MaintenanceCompanyLookUpRepository = maintenanceCompanyLookUpRepo,
                MaintenanceCompanyRepository = maintenanceCompanyRepo,
                MaintenanceCompanySpecializationRepository = maintenanceCompanySpecializationRepo,
                MaintenanceCustomServiceRepository = maintenanceCustomServicesRepo,
                MaintenanceExteriorRepository = maintenanceExteriorRepo,
                MaintenanceInteriorRepository = maintenanceInteriorRepo,
                MaintenanceNewConstructionRepository = maintenanceNewConstructionRepo,
                MaintenanceRepairRepository = maintenanceRepairRepo,
                MaintenanceUtilityRepository = maintenanceUtilityRepo,
                CurrencyRepository = currencyRepo,
                SpecialistProfileCommentRepository = specialistProfileCommentRepo,
                SpecialistWorkRepository = specialistWorkRepo,
                AgentRepository = agentRepo,
                OwnerRepository = ownerRepo,
                SpecialistRepository = specialistRepo,
                TenantRepository = tenantRepo,
                MaintenanceProviderRepository = providerRepo
            };
            #endregion

            #region Mocking IUserHelper

            #region  AccountHelper UserHelper
            var mockHelper = new Mock<IUserHelper>();
            mockHelper.
                Setup(x => x.UserIdentity).
                Returns(new UserIdentity(Uow, new FakeMembershipProvider()));
            mockHelper.
                Setup(x => x.AgentPrivateProfileHelper).
                Returns(AgentPrivateProfileHelperMock);
            mockHelper.
              Setup(x => x.OwnerPrivateProfileHelper).
              Returns(OwnerPrivateProfileHelperMock);
            mockHelper.
              Setup(x => x.ProviderPrivateProfileHelper).
              Returns(ProviderPrivateProfileHelperMock);
            mockHelper.
              Setup(x => x.SpecialistPrivateProfileHelper).
              Returns(SpecialistPrivateProfileHelperMock);
            mockHelper.
                Setup(x => x.TenantPrivateProfileHelper).
                Returns(TenantPrivateProfileHelperMock);
            #endregion

            #endregion

            #region Mocking MemberShipService
            //MembershipService Optional 
            var membershipMock = new Mock<IMembershipService>();
            //var userMock = new Mock<MembershipUser>();
            //var secondSpecialist = professionalRepo.MyList[1];
            //userMock.Setup(u => u.ProviderUserKey).Returns(secondSpecialist.GUID);
            //userMock.Setup(u => u.UserName).Returns(secondSpecialist.FirstName);
            //membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);
            #endregion

            #region Controller Construction + Mocking Context

            Controller = new AccountHelper(Uow, membershipMock.Object, mockHelper.Object, new MockEmailService());
            Controller.MockHttpContext();

            #endregion

            #region ExpectedResult Helper
            ExpectedOwner = new ExpectedHelper(Uow).GetExpectedOwner();
            ExpectedAgent = new ExpectedHelper(Uow).GetExpectedAgent();
            ExpectedTenant = new ExpectedHelper(Uow).GetExpectedTenant();
            ExpectedProvider = new ExpectedHelper(Uow).GetExpectedProvider();
            ExpectedSpecialist = new ExpectedHelper(Uow).GetExpectedSpecialist();
            #endregion

            #endregion //AccountHelperTest

        }

        #region Mocking Interface from IUserHelper

        #region AgentPrivateProfileHelperMock
        public AgentPrivateProfileHelper AgentPrivateProfileHelperMock()
        {
            var agentUserIdentity = new UserIdentity(Uow, new FakeMembershipProvider());
            agentUserIdentity.MockHttpContext();
            agentUserIdentity.MockMikeAgent();

            var agentPrivatemockHelper = new Mock<IUserHelper>();
            agentPrivatemockHelper.Setup(x => x.UserIdentity).Returns(agentUserIdentity);

            var agentPrivateProfileHelper = new AgentPrivateProfileHelper(Uow, new FakeMembershipProvider(), agentPrivatemockHelper.Object);
            agentPrivateProfileHelper.MockHttpContext();
            agentPrivateProfileHelper.MockMikeAgent();
            return agentPrivateProfileHelper;
        }
        #endregion

        #region OwnerPrivateProfileHelperMock
        public OwnerPrivateProfileHelper OwnerPrivateProfileHelperMock()
        {
            var ownerUserIdentity = new UserIdentity(Uow, new FakeMembershipProvider());
            ownerUserIdentity.MockHttpContext();
            ownerUserIdentity.MockLisaOwner();

            var ownerPrivatemockHelper = new Mock<IUserHelper>();
            ownerPrivatemockHelper.Setup(x => x.UserIdentity).Returns(ownerUserIdentity);

            var ownerPrivateProfileHelper = new OwnerPrivateProfileHelper(Uow, new FakeMembershipProvider(), ownerPrivatemockHelper.Object);
            ownerPrivateProfileHelper.MockHttpContext();
            ownerPrivateProfileHelper.MockMikeAgent();
            return ownerPrivateProfileHelper;
        }
        #endregion

        #region ProviderPrivateProfileHelperMock
        public ProviderPrivateProfileHelper ProviderPrivateProfileHelperMock()
        {
            var providerUserIdentity = new UserIdentity(Uow, new FakeMembershipProvider());
            providerUserIdentity.MockHttpContext();
            providerUserIdentity.MockJeffProvider();

            var providerPrivatemockHelper = new Mock<IUserHelper>();
            providerPrivatemockHelper.Setup(x => x.UserIdentity).Returns(providerUserIdentity);

            var providerPrivateProfileHelper = new ProviderPrivateProfileHelper(Uow, new FakeMembershipProvider(), providerPrivatemockHelper.Object);
            providerPrivateProfileHelper.MockHttpContext();
            providerPrivateProfileHelper.MockJeffProvider();
            return providerPrivateProfileHelper;
        }
        #endregion

        #region SpecialistPrivateProfileHelperMock
        public SpecialistPrivateProfileHelper SpecialistPrivateProfileHelperMock()
        {
            var specialistUserIdentity = new UserIdentity(Uow, new FakeMembershipProvider());
            specialistUserIdentity.MockHttpContext();
            specialistUserIdentity.MockSaraSpecialist();

            var specialistPrivatemockHelper = new Mock<IUserHelper>();
            specialistPrivatemockHelper.Setup(x => x.UserIdentity).Returns(specialistUserIdentity);

            var specialistPrivateProfileHelper = new SpecialistPrivateProfileHelper(Uow, new FakeMembershipProvider(), specialistPrivatemockHelper.Object);
            specialistPrivateProfileHelper.MockHttpContext();
            specialistPrivateProfileHelper.MockSaraSpecialist();
            return specialistPrivateProfileHelper;
        }
        #endregion

        #region TenantPrivateProfileHelperMock
        public TenantPrivateProfileHelper TenantPrivateProfileHelperMock()
        {
            var tenantUserIdentity = new UserIdentity(Uow, new FakeMembershipProvider());
            tenantUserIdentity.MockHttpContext();
            tenantUserIdentity.MockTenantFred();

            var tenantPrivatemockHelper = new Mock<IUserHelper>();
            tenantPrivatemockHelper.Setup(x => x.UserIdentity).Returns(tenantUserIdentity);

            var tenantPrivateProfileHelper = new TenantPrivateProfileHelper(Uow, new FakeMembershipProvider(), tenantPrivatemockHelper.Object);
            tenantPrivateProfileHelper.MockHttpContext();
            tenantPrivateProfileHelper.MockTenantFred();
            return tenantPrivateProfileHelper;
        }
        #endregion

        #endregion // Mocking Interface from IUserHelper

        #endregion //Initialization

        #region ChangeEmail

        [TestMethod]
        public void ChangeSpecialistEmail()
        {
            var newEmail = new ChangeEmail
            {
                Email = "new Specialist Email.com"
            };
            Controller.UserHelper.UserIdentity.MockSaraSpecialist();
            Controller.ChangeSpecialistEmail(newEmail);
            var email = Uow.SpecialistRepository.FindBy(x => x.SpecialistId == 1).FirstOrDefault();
            Debug.Assert(email != null, "email != null");
            Assert.AreEqual(email.EmailAddress, "new Specialist Email.com");
        }

        [TestMethod]
        public void ChangeTenantEmail()
        {
            var newEmail = new ChangeEmail
            {
                Email = "new Tenant Email.com"
            };
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.ChangeTenantEmail(newEmail);
            var email = Uow.TenantRepository.FindBy(x => x.TenantId == 5).FirstOrDefault();
            Debug.Assert(email != null, "email != null");
            Assert.AreEqual(email.EmailAddress, "new Tenant Email.com");
        }

        [TestMethod]
        public void ChangeProviderEmail()
        {
            var newEmail = new ChangeEmail
            {
                Email = "new Provider Email.com"
            };
            Controller.UserHelper.UserIdentity.MockJeffProvider();
            Controller.ChangeProviderEmail(newEmail);
            var email = Uow.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == 1).FirstOrDefault();
            Debug.Assert(email != null, "email != null");
            Assert.AreEqual(email.EmailAddress, "new Provider Email.com");
        }

        [TestMethod]
        public void ChangeOwnerEmail()
        {
            var newEmail = new ChangeEmail
            {
                Email = "new Owner Email.com"
            };
            Controller.UserHelper.UserIdentity.MockLisaOwner();
            Controller.ChangeOwnerEmail(newEmail);
            var email = Uow.OwnerRepository.FindBy(x => x.OwnerId == 1).FirstOrDefault();
            Debug.Assert(email != null, "email != null");
            Assert.AreEqual(email.EmailAddress, "new Owner Email.com");
        }

        [TestMethod]
        public void ChangeAgentmail()
        {
            var newEmail = new ChangeEmail
            {
                Email = "new Agent Email.com"
            };
            Controller.UserHelper.UserIdentity.MockMikeAgent();
            Controller.ChangeAgentmail(newEmail);
            var email = Uow.AgentRepository.FindBy(x => x.AgentId == 1).FirstOrDefault();
            Debug.Assert(email != null, "email != null");
            Assert.AreEqual(email.EmailAddress, "new Agent Email.com");
        }


        #endregion

        #region RegisterAccount

        [TestMethod]
        public void RegisterTenant()
        {
            var newTenant = new RegisterModel
            {
                UserName = "newTenant",
                Email = "New Jeff Email Address",
                Password = "123456",
                ConfirmPassword = "123456",
                Role = "Tenant"
            };
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.MembershipService = new MockMemberShipService().MockFredTenantMembership();
            Controller.RegisterTenant(newTenant);
            var newtenantCount = Uow.TenantRepository.Count(x => x.GUID.ToString() ==
                new FakeMembershipProvider().FakeUserJeff.ProviderUserKey.ToString() &&
                x.EmailAddress == "New Jeff Email Address");
            Assert.AreEqual(newtenantCount, 1);
        }

        [TestMethod]
        public void RegisterOwner()
        {
            var newOwner = new RegisterModel
            {
                UserName = "lisa",
                Email = "New lisa Email Address",
                Password = "123456",
                ConfirmPassword = "123456",
                Role = "Owner"
            };
            Controller.UserHelper.UserIdentity.MockLisaOwner();
            Controller.MembershipService = new MockMemberShipService().MockLisaOwnerMembership();
            Controller.RegisterOwner(newOwner);
            var newOwnerCount = Uow.OwnerRepository.Count(x => x.GUID.ToString() ==
                new FakeMembershipProvider().FakeUserLisa.ProviderUserKey.ToString() &&
                x.EmailAddress == "New lisa Email Address");
            Assert.AreEqual(newOwnerCount, 1);
        }

        [TestMethod]
        public void RegisterAgent()
        {
            var newAgent = new RegisterModel
            {
                UserName = "mike",
                Email = "New mike Email Address",
                Password = "123456",
                ConfirmPassword = "123456",
                Role = "Agent"
            };
            Controller.UserHelper.UserIdentity.MockMikeAgent();
            Controller.MembershipService = new MockMemberShipService().MockMikeAgentMembership();
            Controller.RegisterAgent(newAgent);
            var newAgentCount =
                Uow.AgentRepository.Count(x => x.GUID.ToString() ==
                new FakeMembershipProvider().FakeUserMike.ProviderUserKey.ToString() &&
                x.EmailAddress == "New mike Email Address");
            Assert.AreEqual(newAgentCount, 1);
        }

        [TestMethod]
        public void RegisterSpecialist()
        {
            var newSpecialist = new RegisterModel
            {
                UserName = "sara",
                Email = "New Sara Email Address",
                Password = "123456",
                ConfirmPassword = "123456",
                Role = LookUpRoles.SpecialistRole
            };
            Controller.UserHelper.UserIdentity.MockSaraSpecialist();
            Controller.MembershipService = new MockMemberShipService().MockSaraSpecialistMembership();
            Controller.RegisterSpecialist(newSpecialist);
            var newAddedSpecialist = Uow.SpecialistRepository.FindBy(x => x.GUID.ToString() == new FakeMembershipProvider().FakeUserSara.ProviderUserKey.ToString() && x.EmailAddress == "New Sara Email Address").FirstOrDefault();
            var newAddedSpecialistCompanyLookUp =
                Uow.MaintenanceCompanyLookUpRepository.FindBy(
                    x => x.UserId == newAddedSpecialist.SpecialistId && x.Role == (int)LookUpRoles.Roles.Specialist)
                    .FirstOrDefault();
            var newAddedSpecialistCompanySpecialization = Uow.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == newAddedSpecialistCompanyLookUp.CompanyId);
            Assert.AreEqual(newAddedSpecialistCompanySpecialization.Rate, 50);
        }

        [TestMethod]
        public void RegisterProvider()
        {
            var newProvider = new RegisterModel
            {
                UserName = "jeff",
                Email = "New Jeff Email Address",
                Password = "123456",
                ConfirmPassword = "123456",
                Role = LookUpRoles.ProviderRole
            };
            Controller.UserHelper.UserIdentity.MockJeffProvider();
            Controller.MembershipService = new MockMemberShipService().MockJeffProviderMembership();
            Controller.RegisterProvider(newProvider);
            var newAddedProvider = Uow.MaintenanceProviderRepository.FindBy(x => x.GUID.ToString() == new FakeMembershipProvider().FakeUserJeff.ProviderUserKey.ToString() && x.EmailAddress == "New Jeff Email Address").FirstOrDefault();
            var newAddedProviderCompanyLookUp =
                Uow.MaintenanceCompanyLookUpRepository.FindBy(
                    x => x.UserId == newAddedProvider.MaintenanceProviderId && x.Role == (int)LookUpRoles.Roles.Provider)
                    .FirstOrDefault();
            var newAddedProviderCompanySpecialization = Uow.MaintenanceCompanySpecializationRepository.FirstOrDefault(x => x.CompanyId == newAddedProviderCompanyLookUp.CompanyId);
            Assert.AreEqual(newAddedProviderCompanySpecialization.NumberofEmployee, 1);

        }
        #endregion

        #region Add Picture

        [TestMethod]
        public void AddTenantPicture()
        {
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.AddTenantPicture(@"~\Photo\FredPhoto");
            var tenant = Uow.TenantRepository.FindBy(x => x.TenantId == 5).FirstOrDefault();
            if (tenant != null) Assert.AreEqual(tenant.Photo, @"../../Photo/FredPhoto");
        }

        [TestMethod]
        public void AddOwnerPicture()
        {
            Controller.UserHelper.UserIdentity.MockLisaOwner();
            Controller.AddOwnerPicture(@"~\Photo\LisaPhoto");
            var owner = Uow.OwnerRepository.FindBy(x => x.OwnerId == 1).FirstOrDefault();
            if (owner != null) Assert.AreEqual(owner.Photo, @"../../Photo/LisaPhoto");
        }

        [TestMethod]
        public void AddAgentPicture()
        {
            Controller.UserHelper.UserIdentity.MockMikeAgent();
            Controller.AddAgentPicture(@"~\Photo\MikePhoto");
            var agent = Uow.AgentRepository.FindBy(x => x.AgentId == 1).FirstOrDefault();
            if (agent != null) Assert.AreEqual(agent.Photo, @"../../Photo/MikePhoto");
        }

        [TestMethod]
        public void AddSpecialistPicture()
        {
            Controller.UserHelper.UserIdentity.MockSaraSpecialist();
            Controller.AddSpecialistPicture(@"~\Photo\SaraPhoto");
            var specialist = Uow.SpecialistRepository.FindBy(x => x.SpecialistId == 1).FirstOrDefault();
            if (specialist != null) Assert.AreEqual(specialist.Photo, @"../../Photo/SaraPhoto");
        }

        [TestMethod]
        public void AddProviderPicture()
        {
            Controller.UserHelper.UserIdentity.MockJeffProvider();
            Controller.AddProviderPicture(@"~\Photo\JeffPhoto");
            var provider = Uow.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == 1).FirstOrDefault();
            if (provider != null) Assert.AreEqual(provider.Photo, @"../../Photo/JeffPhoto");
        }

        #endregion

        #region Saving Picture

        [TestMethod]
        public void SavePictures()
        {
            Controller.FakeHttpContextWithAuthenticatedUser(LookUpRoles.Roles.Tenant);
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.MockControllerContextForServerMap();

            const string photoFromPicturesFolder = @"C:\Users\Public\Pictures\Sample Pictures\Tulips.jpg";
            const string photoDirectory = @"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalModel.Test\Photo\Tenant\Profile\fred\2";
            File.Copy(photoFromPicturesFolder, photoDirectory + @"\Tulips.jpg", true);
            var uploadDirectory = new DirectoryInfo(photoDirectory);

            Controller.SaveProfilePhoto(2);

            var uploadedFilesCount = uploadDirectory.GetFiles().Count();
            Assert.AreEqual(uploadedFilesCount, 1);
            Assert.AreEqual(uploadDirectory.GetFiles().First().Name, "Tulips.jpg");
        }
        #endregion

        #region Update and Load Video

        #region UpdateVideo

        [TestMethod]
        public void UpdateAgentVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube.com"
            };
            Controller.UserHelper.UserIdentity.MockMikeAgent();
            Controller.UpdateAgentVideo(primaryVideo);
            Assert.AreEqual(ExpectedAgent.YouTubeVideoURL, @"http://www.youtube.com");
        }

        [TestMethod]
        public void UpdateOwnerVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube1.com"
            };
            Controller.UserHelper.UserIdentity.MockLisaOwner();
            Controller.UpdateOwnerVideo(primaryVideo);
            Assert.AreEqual(ExpectedOwner.YouTubeVideoURL, @"http://www.youtube1.com");
        }

        [TestMethod]
        public void UpdateTenantVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube2.com"
            };
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.UpdateTenantVideo(primaryVideo);
            Assert.AreEqual(ExpectedTenant.YouTubeVideoURL, @"http://www.youtube2.com");
        }

        [TestMethod]
        public void UpdateProviderVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube3.com"
            };
            Controller.UserHelper.UserIdentity.MockJeffProvider();
            Controller.UpdateProviderVideo(primaryVideo);
            Assert.AreEqual(ExpectedProvider.YouTubeVideoURL, @"http://www.youtube3.com");
        }

        [TestMethod]
        public void UpdateSpecialistVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube4.com"
            };
            Controller.UserHelper.UserIdentity.MockSaraSpecialist();
            Controller.UpdateSpecialistVideo(primaryVideo);
            Assert.AreEqual(ExpectedSpecialist.YouTubeVideoURL, @"http://www.youtube4.com");
        }

        #endregion

        #region LoadVideo

        #region Helper

        public PrimaryVideo DefaultPrimaryVideo()
        {
            var primaryVideo = new PrimaryVideo
            {
                VimeoVideo = false,
                VimeoVideoUrl = "",
                YouTubeVideo = true,
                YouTubeVideoUrl = "http://www.youtube.com"
            };
            return primaryVideo;
        }
        #endregion

        [TestMethod]
        public void LoadAgentVideo()
        {
            var primaryVideo = DefaultPrimaryVideo();
            Controller.UserHelper.UserIdentity.MockMikeAgent();
            Controller.LoadAgentVideo(primaryVideo);
            Assert.AreEqual(primaryVideo.YouTubeVideoUrl, @"http://www.agenttube.com");
        }

        [TestMethod]
        public void LoadOwnerVideo()
        {
            var primaryVideo = DefaultPrimaryVideo();
            Controller.UserHelper.UserIdentity.MockLisaOwner();
            Controller.LoadOwnerVideo(primaryVideo);
            Assert.AreEqual(primaryVideo.VimeoVideoUrl, @"http://www.OwnerVimeo.com");
        }

        [TestMethod]
        public void LoadTenantVideo()
        {
            var primaryVideo = DefaultPrimaryVideo();
            Controller.UserHelper.UserIdentity.MockTenantFred();
            Controller.LoadTenantVideo(primaryVideo);
            Assert.AreEqual(primaryVideo.YouTubeVideoUrl, @"http://www.agenttenant.com");
        }

        [TestMethod]
        public void LoadProviderVideo()
        {
            var primaryVideo = DefaultPrimaryVideo();
            Controller.UserHelper.UserIdentity.MockJeffProvider();
            Controller.LoadProviderVideo(primaryVideo);
            Assert.AreEqual(ExpectedProvider.YouTubeVideoURL, @"http://www.providerTube.com");
        }

        [TestMethod]
        public void LoadSpecialistVideo()
        {
            var primaryVideo = DefaultPrimaryVideo();
            Controller.UserHelper.UserIdentity.MockSaraSpecialist();
            Controller.LoadSpecialistVideo(primaryVideo);
            Assert.AreEqual(primaryVideo.VimeoVideoUrl, @"http://www.specialistVimeo.com");
        }
        #endregion
        #endregion

        #region SendResetEmail

        [TestMethod]
        public void SendResetEmail()
        {
            Controller.FakeHttpContextWithAuthenticatedUser(LookUpRoles.Roles.Tenant);
            Controller.MembershipService = new FakeMemberShipService();

            //Only Test the content of the Message 
            var actualEmailMessage = Controller.ComposeEmailMessage(new FakeMembershipProvider().FakeUserFred);
           
            //Mail Repository Debug in web Confing in C:\temp
            // Use substitutions between debug and release
            const string expectedEmailMessage =
                @"<p> Dear fred,</p><p> Your password has been reset. Click http://tempuri.org/Account/Logon to login with details below</p><p> UserName: fred</p><p> Password: 123!</p><p> It is recommended that you change it after logging in.</p><p> If you did not request a password reset, you do not need to take any action.</p>";
            Assert.AreEqual(expectedEmailMessage, actualEmailMessage);
        }
        #endregion
    }
}



