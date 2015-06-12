using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.ControllerTester;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.Prototype
{
    [TestClass]
    public class UnitofWorkPatternControllerWithMemory
    {
        public FakeUnits FakeUnits;
        public UnitofWorkPatternController Controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var fakeUnits = new FakeUnits();
            var unitRepo = new FakeUnitRepository(fakeUnits.MyUnits);
            var uow = new UnitofWork { UnitRepository = unitRepo };
             Controller = new UnitofWorkPatternController(uow);
        }

        [TestMethod]
        public void IndexWithMemory()
        {

            // act
            var actual = Controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(2, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            FakeUnits = null;
            Controller = null;
        }
    }
}
