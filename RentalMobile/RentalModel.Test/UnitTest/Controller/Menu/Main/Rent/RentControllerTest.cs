using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Menu.Main.Rent
{
    [TestClass]
    public class RentControllerTest
    {
        public RentController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var unitRepo = new FakeUnitRepository();
            var uow = new UnitofWork { UnitRepository = unitRepo };
            Controller = new RentController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllUnitWithTheirPrices()
        {
            //Act
            var actual = Controller.Index();

             //Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       