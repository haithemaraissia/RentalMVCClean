using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Controllers.Listing.Tenants;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.Menu.Listing
{
    [TestClass]
    public class TenantsControllerTest
    {
        public TenantsController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var tenantRepo = new FakeTenantRepository();
            var uow = new UnitofWork { TenantRepository = tenantRepo };
            Controller = new TenantsController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllTenant()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Tenant>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

      
        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       