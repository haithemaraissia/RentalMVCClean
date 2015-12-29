using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.Listing.Owners;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Application.Controllers.Done.Listing
{
    [TestClass]
    public class OwnersControllerTest
    {
       public OwnersController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var ownerRepo = new FakeOwnerRepository();
            var uow = new UnitofWork { OwnerRepository = ownerRepo };
            Controller = new OwnersController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllOwners()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Owner>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       