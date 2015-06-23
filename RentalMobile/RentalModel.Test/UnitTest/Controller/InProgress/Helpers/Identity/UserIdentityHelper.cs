using System;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.UnitTest.Helpers;
using TestProject.UnitTest.Helpers.Fake;

namespace TestProject.UnitTest.Controller.InProgress.Helpers.Identity
{
    [TestClass]
    public class UserIdentityHelper
    {
        #region Intialization and 2 different style for Mocking

        public AssertHelper Helper = new AssertHelper();
        public UnitofWork Uow;
        [TestInitialize]
        public void Initialize()
        {
            // Arrange

            var maintenanceCompanyLookUpRepo = new FakeMaintenanceCompanyLookUpRepository();
            var maintenanceRepairRepo = new FakeMaintenanceRepairRepository();
            var maintenanceCompanySpecializationRepo = new FakeMaintenanceCompanySpecializationRepository();
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
                MaintenanceRepairRepository = maintenanceRepairRepo,
                MaintenanceCompanySpecializationRepository = maintenanceCompanySpecializationRepo,
                CurrencyRepository = currencyRepo,
                SpecialistProfileCommentRepository = specialistProfileCommentRepo,
                SpecialistWorkRepository = specialistWorkRepo,
                AgentRepository = agentRepo,
                OwnerRepository = ownerRepo,
                SpecialistRepository = specialistRepo,
                TenantRepository = tenantRepo,
                MaintenanceProviderRepository = providerRepo
            };
        }

        [TestMethod]
        public void MembershipServiceMocking()
        {
            //IStaticMembershipService
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            var userGuid = new Guid();
            userMock.Setup(u => u.ProviderUserKey).Returns(userGuid);
            userMock.Setup(u => u.UserName).Returns("jack1");
            membershipMock.Setup(s => s.GetUser(It.IsAny<string>())).Returns(userMock.Object);

            //Identity
            var userIdentity = new UserIdentity(Uow, membershipMock.Object);

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("Robert");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;

            Assert.AreEqual(userIdentity.GetUserName(), "jack1");
            Assert.AreEqual(userIdentity.GetUserGuid(), userGuid);

        }

        [TestMethod]
        public void MembershipProviderFromtheBaseControll()
        {
            var userIdentity = JeffProviderUserIdentityFromMemberShipProvider();
            Assert.AreEqual(userIdentity.GetUserNameFromMembership(), "jeff");
        }

        #endregion

        #region UserIdentity Instance Based on Role

        public UserIdentity FredTenantUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("fred");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Tenant")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity LisaOwnerUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("lisa");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Owner")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity MikeAgentUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("mike");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Agent")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity SaraSpecialistUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("sara");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Specialist")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity JeffProviderUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("jeff");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("MaintenanceProvider")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity JeffProviderUserIdentityFromMemberShipProvider()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("jeff");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("MaintenanceProvider")))).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        #endregion

        #region UserIdentity Class

        [TestMethod]
        public void GetUserNameFromMembershipProvider()
        {
            var userIdentity = JeffProviderUserIdentityFromMemberShipProvider();
            Assert.AreEqual(userIdentity.GetUserNameFromMembership(), "jeff");
        }

        [TestMethod]
        public void LoginShouldRedirectToSignInPage()
        {
            var userIdentity = JeffProviderUserIdentity();
            userIdentity.MockHttpContext();
            Assert.AreEqual(userIdentity.Login(), "~/NotAuthenticated/SignIn.aspx?ReturnUrl=http://tempuri.org/");
        }


        #region GetUserName
        [TestMethod]
        public void GetAgentUserName()
        {
            var userIdentity = MikeAgentUserIdentity();
            Assert.AreEqual(userIdentity.GetUserName(), "mike");
        }

        [TestMethod]
        public void GetOwnerUserName()
        {
            var userIdentity = LisaOwnerUserIdentity();
            Assert.AreEqual(userIdentity.GetUserName(), "lisa");
        }

        [TestMethod]
        public void GetSpecialistUserName()
        {
            var userIdentity = SaraSpecialistUserIdentity();
            Assert.AreEqual(userIdentity.GetUserName(), "sara");
        }

        [TestMethod]
        public void GetTenantUserName()
        {
            var userIdentity = FredTenantUserIdentity();
            Assert.AreEqual(userIdentity.GetUserName(), "fred");
        }

        [TestMethod]
        public void GetProviderUserName()
        {
            var userIdentity = JeffProviderUserIdentity();
            Assert.AreEqual(userIdentity.GetUserName(), "jeff");
        }

        #endregion

        #region UserGuid
        [TestMethod]
        public void GetTenantUserGuid()
        {
            var userIdentity = FredTenantUserIdentity();
            var fredUserKey = new Guid("ffffffff-dddd-dddd-dddd-dddddddddddd");
            Assert.AreEqual(userIdentity.GetUserGuid(), fredUserKey);
        }

        [TestMethod]
        public void GetOwnerUserGuid()
        {
            var userIdentity = LisaOwnerUserIdentity();
            var lisaUserKey = new Guid("dddddddd-dddd-dddd-4567-dddddddddddd");
            Assert.AreEqual(userIdentity.GetUserGuid(), lisaUserKey);
        }

        [TestMethod]
        public void GetAgentUserGuid()
        {
            var userIdentity = MikeAgentUserIdentity();
            var mikeUserKey = new Guid("dddddddd-dddd-dddd-1234-dddddddddddd");
            Assert.AreEqual(userIdentity.GetUserGuid(), mikeUserKey);
        }

        [TestMethod]
        public void GetSpecialistUserGuid()
        {
            var userIdentity = SaraSpecialistUserIdentity();
            var saraUserKey = new Guid("dddddddd-dddd-dddd-1111-dddddddddddd");
            Assert.AreEqual(userIdentity.GetUserGuid(), saraUserKey);
        }

        [TestMethod]
        public void GetProviderUserGuid()
        {
            var userIdentity = JeffProviderUserIdentity();
            var jeffUserKey = new Guid("dddddddd-dddd-dddd-1122-dddddddddddd");
            Assert.AreEqual(userIdentity.GetUserGuid(), jeffUserKey);
        }

        #endregion

        #region Tenant

        [TestMethod]
        public void GetTenantByUserGuidId()
        {
            var userIdentity = FredTenantUserIdentity();
            var fredUserKey = new Guid("ffffffff-dddd-dddd-dddd-dddddddddddd");
            Assert.AreEqual(userIdentity.GetTenantId(fredUserKey), 5);
        }

        [TestMethod]
        public void GetTenantId()
        {
            var userIdentity = FredTenantUserIdentity();
            Assert.AreEqual(userIdentity.GetTenantId(), 5);
        }

        [TestMethod]
        public void GetTenantIdById()
        {
            var userIdentity = FredTenantUserIdentity();
            Assert.AreEqual(userIdentity.GetTenantId(5), 5);
        }

        #endregion

        #region Agent

        [TestMethod]
        public void GetAgentId()
        {
            var userIdentity = MikeAgentUserIdentity();
            Assert.AreEqual(userIdentity.GetAgentId(), 1);
        }

        [TestMethod]
        public void GetAgentIdById()
        {
            var userIdentity = MikeAgentUserIdentity();
            Assert.AreEqual(userIdentity.GetAgentId(1), 1);
        }

        #endregion

        #region Owner
        [TestMethod]
        public void GetOwnerId()
        {
            var userIdentity = LisaOwnerUserIdentity();
            Assert.AreEqual(userIdentity.GetOwnerId(), 1);
        }
        [TestMethod]
        public void GetOwnerIdById()
        {
            var userIdentity = LisaOwnerUserIdentity();
            Assert.AreEqual(userIdentity.GetOwnerId(), 1);
        }


        #endregion

        #region Specialist

        [TestMethod]
        public void GetSpecialistId()
        {
            var userIdentity = SaraSpecialistUserIdentity();
            Assert.AreEqual(userIdentity.GetSpecialistId(), 1);
        }

        [TestMethod]
        public void GetSpecialistIdById()
        {
            var userIdentity = SaraSpecialistUserIdentity();
            Assert.AreEqual(userIdentity.GetSpecialistId(1), 1);
        }
        #endregion

        #region Provider

        [TestMethod]
        public void GetProviderId()
        {
            var userIdentity = JeffProviderUserIdentity();
            Assert.AreEqual(userIdentity.GetProviderId(), 1);
        }

        [TestMethod]
        public void GetProviderIdById()
        {
            var userIdentity = JeffProviderUserIdentity();
            Assert.AreEqual(userIdentity.GetProviderId(1), 1);
        }

        #endregion

        #region GetRoleId
        
        [TestMethod]
        public void GetTenantRoleId()
        {
            var userIdentity = FredTenantUserIdentity();
            Assert.AreEqual(userIdentity.GetRoleId("tenant"), 1);
        }
        
        [TestMethod]
        public void GetOwnerRoleId()
        {
            var userIdentity = LisaOwnerUserIdentity();
            Assert.AreEqual(userIdentity.GetRoleId("owner"), 2);
        }

        [TestMethod]
        public void GetAgentRoleId()
        {
            var userIdentity = MikeAgentUserIdentity();
            Assert.AreEqual(userIdentity.GetRoleId("agent"), 3);
        }

        [TestMethod]
        public void GetSpecialistRoleId()
        {
            var userIdentity = SaraSpecialistUserIdentity();
            Assert.AreEqual(userIdentity.GetRoleId("specialist"), 4);
        }

        [TestMethod]
        public void GetProviderRoleId()
        {
            var userIdentity = JeffProviderUserIdentity();
            Assert.AreEqual(userIdentity.GetRoleId("provider"), 5);
        }

        #endregion
      

        #endregion


        //TODO
        #region TODO

        //Still to Test these 

        //int GetRoleId(string chosenRole);
        //string GetCurrentRole();
        //string SetPhotoPathByCurrentRole(out string photoPath);
        //string ResolveImageUrl(string relativeUrl);

        #endregion

    }
}
