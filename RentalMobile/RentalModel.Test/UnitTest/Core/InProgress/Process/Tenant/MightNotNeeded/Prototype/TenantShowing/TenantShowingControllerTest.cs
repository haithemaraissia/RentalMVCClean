using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.PrivateProfile.Tenant;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Core.InProgress.Process.Tenant.MightNotNeeded.Prototype.TenantShowing
{
    [TestClass]
    public class TenantShowingControllerTest
    {
        public TenantShowingController Controller;
        public FakeTenantShowingRepository TenantShowingRepo = new FakeTenantShowingRepository();
        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var uow = new UnitofWork { TenantShowingRepository = TenantShowingRepo };
            Controller = new TenantShowingController(uow, null,null);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalMobile.Model.Models.TenantShowing>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Create()
        {
            //Act
            var newTenantShowing = new RentalMobile.Model.Models.TenantShowing
            {
                ShowingId = 4,
                Date = new DateTime(),
                UnitId = new Int32(),
                TenantId = new Int32(),
                Tenant = new RentalMobile.Model.Models.Tenant()
            };
            Controller.Create(newTenantShowing);
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalMobile.Model.Models.TenantShowing>;
            if (data != null) Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void Details()
        {
            // Act
            var actual = Controller.Details(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as RentalMobile.Model.Models.TenantShowing;
            if (data != null) Assert.AreEqual(4, data.TenantId);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            var tenantShowing = TenantShowingRepo.FindBy(x => x.ShowingId == 2).FirstOrDefault();
            if (tenantShowing == null) { Assert.AreEqual(true, "tenantShowing == null"); };
            if (tenantShowing != null)
            {
                tenantShowing.TenantId = 8;
                Controller.Edit(tenantShowing);
            }

            // Act
            var actual = Controller.Details(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as RentalMobile.Model.Models.TenantShowing;
            if (data != null) Assert.AreEqual(8, data.TenantId);
        }

        [TestMethod]
        public void Delete()
        {
            // Act
            Controller.Delete(1);
            var actual = Controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalMobile.Model.Models.TenantShowing>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
            TenantShowingRepo.Dispose();
        }
    }
}
