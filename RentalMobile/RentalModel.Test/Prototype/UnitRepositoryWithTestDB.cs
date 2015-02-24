using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.Prototype
{
    [TestClass]
    public class UnitRepositoryWithTestDb
    {
        public TestDbContext Context;
        public UnitofWorkPatternController Controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            Context = new TestDbContext();
            var uow = new UnitofWork(Context);
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
            Context = null;
            Controller = null;
        }
    }
}
