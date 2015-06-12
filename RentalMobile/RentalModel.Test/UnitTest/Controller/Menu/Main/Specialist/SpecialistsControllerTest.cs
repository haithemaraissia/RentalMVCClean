using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Controllers.Listing.Specialists;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Menu.Main.Specialist
{
    [TestClass]
    public class SpecialistsControllerTest
    {
       public SpecialistsController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var specialitRepo = new FakeSpecialistRepository();
            var uow = new UnitofWork { SpecialistRepository = specialitRepo };
            Controller = new SpecialistsController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllSpecialists()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Agent>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       