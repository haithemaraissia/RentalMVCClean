using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.PrivateProfile.Tenant;

namespace TestProject.UnitTest.Application.Controllers.InProgress.Process.Tenant.Maintenance.Prototype
{
    [TestClass]
    public class AddMaintenancePhotoControllerTest
    {
       public AddMaintenancePhotoController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            //var fakeAddMaintenancePhotos = new FakeAddMaintenancePhotos();
            //var addMaintenancePhotoRepo = new FakeAddMaintenancePhotoRepository(fakeAddMaintenancePhotos.MyAddMaintenancePhotos);
            //var uow = new UnitofWork { AddMaintenancePhotoRepository = addMaintenancePhotoRepo };
            //Controller = new AddMaintenancePhotoController(uow);
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
            //Not Implemented
            Assert.Inconclusive("Not Implemented Yet");
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
            //Controller.Dispose();
        }
    }
}
       