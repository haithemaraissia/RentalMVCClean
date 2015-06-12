using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.PrivateProfile.Shared;

namespace TestProject.UnitTest.Core.InProgress.Process.Tenant.Maintenance.ManageMaintenance.Prototype
{
    [TestClass]
    public class ChooseProviderControllerTest
    {
        public ChooseProviderController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            //var fakeChooseProviders = new FakeChooseProviders();
            //var chooseProviderRepo = new FakeChooseProviderRepository(fakeChooseProviders.MyChooseProviders);
            //var uow = new UnitofWork { ChooseProviderRepository = chooseProviderRepo };
            //Controller = new ChooseProviderController(uow);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            //var actual = Controller.Index();

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<ChooseProviderController>;
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
            //var data = viewResult.ViewData.Model as IList<ChooseProviderController>;
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
            //var data = viewResult.ViewData.Model as ChooseProviderController;
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
            //var data = viewResult.ViewData.Model as ChooseProviderController;
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
       