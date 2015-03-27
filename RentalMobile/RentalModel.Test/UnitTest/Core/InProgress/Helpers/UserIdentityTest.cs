using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Identity;
using RentalMobile.Helpers.Identity.Correct;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.Fake;
using TestProject.UnitTest.Helpers;

namespace TestProject.UnitTest.Core.InProgress.Helpers
{
   [TestClass]
    public class UserIdentityTest
    {
       
        public TestHelper Helper = new TestHelper();
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
           //BaseController With Identity
           var userIdentity = new UserIdentity {MembershipProvider = new FakeMembershipProvider()};


           //Context
           var controllerContext = new Mock<ControllerContext>();
           controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("fred");
           controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
           userIdentity.ControllerContext = controllerContext.Object;


           Assert.AreEqual(userIdentity.GetUserName2(), "fred");

       }
    }
}
