using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Menu.Main.Maintain
{
    [TestClass]
    public class MaintainControllerTest
    {
        public MaintainController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var maintainRepo = new FakeMaintenanceProviderRepository();
            var uow = new UnitofWork { MaintenanceProviderRepository = maintainRepo };
            Controller = new MaintainController(uow);
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
       