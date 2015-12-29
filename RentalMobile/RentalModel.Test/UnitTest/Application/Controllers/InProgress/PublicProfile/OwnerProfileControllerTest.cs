using System.Web.Mvc;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers.PublicProfile;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base.Roles.PublicProfile;
using RentalMobile.Helpers.Membership;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Application.Controllers.InProgress.PublicProfile
{
    [TestClass]
    public class OwnerProfileControllerTest
    {
        public OwnerProfileController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            //UOW
            var ownerProfileRepo = new FakeOwnerRepository();
            var uow = new UnitofWork { OwnerRepository = ownerProfileRepo };

            //MEMBERSHIP
            var membershipMock = new Mock<IMembershipService>();
            var userMock = new Mock<MembershipUser>();
            //OR // var userIdentity = new UserIdentity(Uow, new FakeMembershipProvider());

            //HELPER 
            var mockHelper = new Mock<IUserHelper>();
            mockHelper.Setup(x => x.OwnerPublicProfileHelper).Returns(new OwnerPublicProfileHelper(uow, membershipMock.Object));
            
            //Init
            Controller = new OwnerProfileController(uow, mockHelper.Object);
        }

        [TestMethod]
        public void Index()
        {

            // Act
            var actual = Controller.Index(1);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.Model as Owner;
            if (data == null) return;
            Assert.AreEqual(1, viewResult.ViewBag.OwnerId);
            Assert.AreEqual("Google Map", viewResult.ViewBag.OwnerGoogleMap);
        }

        [TestMethod]
        public void Create()
        {
            Assert.Inconclusive("Not Implemented Yet");
            // Act
            //var newDomain = new Domain { Url = "Test5" };
            //Controller.Create(newDomain);
            //var actual = Controller.Index();

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<OwnerProfileController>;
            //if (data != null) Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void Details()
        {
            Assert.Inconclusive("Not Implemented Yet");
            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as OwnerProfileController;
            //if (data != null) Assert.AreEqual("test2", data.Url);
        }

        [TestMethod]
        public void Edit()
        {
            Assert.Inconclusive("Not Implemented Yet");
            // Act
            //var newDomain = new Domain { Id = 2, Url = "new Domain" };
            //Controller.Edit(newDomain);

            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as OwnerProfileController;
            //if (data != null) Assert.AreEqual("new Domain", data.Url);
        }

        [TestMethod]
        public void Delete()
        {
            Assert.Inconclusive("Not Implemented Yet");
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
       