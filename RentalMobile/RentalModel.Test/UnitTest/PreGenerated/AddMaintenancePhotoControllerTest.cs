using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller
{
    [TestClass]
    public class AddMaintenancePhotoControllerTest
    {
        //public FakeAddMaintenancePhotoControllers FakeAddMaintenancePhotoControllers;
        //public AddMaintenancePhotoControllerController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            //var fakeAddMaintenancePhotoControllers = new FakeAddMaintenancePhotoControllers();
            //var AddMaintenancePhotoControllerRepo = new FakeAddMaintenancePhotoControllerRepository(fakeAddMaintenancePhotoControllers.MyAddMaintenancePhotoControllers);
            //var uow = new AddMaintenancePhotoControllerofWork { AddMaintenancePhotoControllerRepository = AddMaintenancePhotoControllerRepo };
            //Controller = new AddMaintenancePhotoControllerController(uow);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            //var actual = Controller.Index();

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<AddMaintenancePhotoController>;
            //if (data != null) Assert.AreEqual(3, data.Count);
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
            //var data = viewResult.ViewData.Model as IList<AddMaintenancePhotoController>;
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
            //var data = viewResult.ViewData.Model as AddMaintenancePhotoController;
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
            //var data = viewResult.ViewData.Model as AddMaintenancePhotoController;
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
            //FakeAddMaintenancePhotoControllers = null;
            //Controller.Dispose();
        }
    }
}
       