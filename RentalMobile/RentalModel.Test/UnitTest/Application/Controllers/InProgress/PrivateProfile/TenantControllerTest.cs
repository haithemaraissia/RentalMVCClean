using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers.PrivateProfile.Tenant;
using RentalMobile.Controllers.PublicProfile;
using RentalMobile.Helpers.Account;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.UnitTest.Helpers.Fake;
using TestProject.UnitTest.Helpers.Mocks.Email;
using TestProject.UnitTest.Helpers.Util;
using TestProject.UnitTest.Helpers.Util.Expected;

namespace TestProject.UnitTest.Application.Controllers.InProgress.PrivateProfile
{
    [TestClass]
    public class TenantControllerTest
    {

        #region Initialization

        public TenantController Controller;
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
            var fakeMemberShipService = new FakeMemberShipService();
            #endregion

            #region Controller Construction + Mocking Context

            Controller = new TenantController(Uow, fakeMemberShipService, mockHelper.Object);
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
            var tenantUserIdentity = new UserIdentity(Uow, new FakeMemberShipService());
            tenantUserIdentity.MockHttpContext();
            tenantUserIdentity.MockTenantFred();

            var tenantPrivatemockHelper = new Mock<IUserHelper>();
            tenantPrivatemockHelper.Setup(x => x.UserIdentity).Returns(tenantUserIdentity);

            var tenantPrivateProfileHelper = new TenantPrivateProfileHelper(Uow, new FakeMemberShipService(), tenantPrivatemockHelper.Object);
            tenantPrivateProfileHelper.MockHttpContext();
            tenantPrivateProfileHelper.MockTenantFred();
            return tenantPrivateProfileHelper;
        }
        #endregion

        #endregion // Mocking Interface from IUserHelper

        #endregion //Initialization





        [TestMethod]
        public void Index()
        {
            //Act
            var actual = Controller.Index();

            //Assert
            var viewResult = actual;
            if (viewResult == null) return;
            var data = viewResult.Model as Tenant;
            if (data == null) return;
            Assert.AreEqual(0, viewResult.ViewBag.tenantApplicationCount);
        }

        [TestMethod]
        public void Create()
        {
            // Act
            //var newDomain = new Domain { Url = "Test5" };
            //Controller.Create(newDomain);
            //var actual = Controller.Index();

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<TenantController>;
            //if (data != null) Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void Details()
        {
            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as TenantController;
            //if (data != null) Assert.AreEqual("test2", data.Url);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            //var newDomain = new Domain { Id = 2, Url = "new Domain" };
            //Controller.Edit(newDomain);

            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as TenantController;
            //if (data != null) Assert.AreEqual("new Domain", data.Url);
        }

        [TestMethod]
        public void Delete()
        {
            // Act
            //Controller.Delete(1);
            //var actual = Controller.Index();

            // assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<Domain>;
            //if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Controller.Dispose();
        }
    }
}
