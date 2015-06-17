using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.Listing.ProviderProfile;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Done.Listing
{
    [TestClass]
    public class ProvidersControllerTest
    {
        public ProvidersController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var ProvidersRepo = new FakeMaintenanceProviderRepository();
            var uow = new UnitofWork { MaintenanceProviderRepository = ProvidersRepo };
            Controller = new ProvidersController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllMaintenanceProvider()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<MaintenanceProvider>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }


        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       