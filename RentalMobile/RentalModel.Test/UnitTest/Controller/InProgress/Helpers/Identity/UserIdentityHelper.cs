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
        #region intialization and 2 different style for Mocking

        public AssertHelper Helper = new AssertHelper();
        public UnitofWork Uow;
        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var professionalRepo = new FakeSpecialistRepository();
            var maintenanceCompanyLookUpRepo = new FakeMaintenanceCompanyLookUpRepository();
            var maintenanceRepairRepo = new FakeMaintenanceRepairRepository();
            var maintenanceCompanySpecializationRepo = new FakeMaintenanceCompanySpecializationRepository();
            var currencyRepo = new FakeCurrencyRepository();
            var specialistProfileCommentRepo = new FakeSpecialistProfileCommentRepository();
            var specialistWorkRepo = new FakeSpecialistWorkRepository();

            Uow = new UnitofWork
            {
                SpecialistRepository = professionalRepo,
                MaintenanceCompanyLookUpRepository = maintenanceCompanyLookUpRepo,
                MaintenanceRepairRepository = maintenanceRepairRepo,
                MaintenanceCompanySpecializationRepository = maintenanceCompanySpecializationRepo,
                CurrencyRepository = currencyRepo,
                SpecialistProfileCommentRepository = specialistProfileCommentRepo,
                SpecialistWorkRepository = specialistWorkRepo,
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
            var userIdentity = FredTenantUserIdentity();
            Assert.AreEqual(userIdentity.GetUserNameFromMembership(), "fred");
        }

        #endregion


        #region UserIdentity For eachRole Helper
        public UserIdentity FredTenantUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("fred");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User.IsInRole("Tenant")).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }
       
        public UserIdentity LisaOwnerUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("lisa");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User.IsInRole("Owner")).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }
        
        public UserIdentity MikeAgentUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("mike");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User.IsInRole("Agent")).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity SaraSpecialistUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("sara");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User.IsInRole("Specialist")).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        public UserIdentity JeffProviderUserIdentity()
        {
            //BaseController With Identity
            var userIdentity = new UserIdentity { MembershipProvider = new FakeMembershipProvider() };

            //Context
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("jeff");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User.IsInRole("MaintenanceProvider")).Returns(true);
            userIdentity.ControllerContext = controllerContext.Object;
            return userIdentity;
        }

        #endregion

    }
}
