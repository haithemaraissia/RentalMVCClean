using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Helpers.Core;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Profiles
{
    [TestClass]
    public class OwnerProfileControllerTest
    {
        public OwnerProfileController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var ownerProfileRepo = new FakeOwnerRepository();
            var uow = new UnitofWork { OwnerRepository = ownerProfileRepo };
            Controller = new OwnerProfileController(uow,null);
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
            Assert.AreEqual("Bob Owner", viewResult.ViewBag.FirstName);
            Assert.AreEqual("1", viewResult.ViewBag.agentId);
            Assert.AreEqual("Google Map", viewResult.ViewBag.agentGoogleMap);
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
            //var data = viewResult.ViewData.Model as IList<OwnerProfileController>;
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
            //var data = viewResult.ViewData.Model as OwnerProfileController;
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
            //var data = viewResult.ViewData.Model as OwnerProfileController;
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
       