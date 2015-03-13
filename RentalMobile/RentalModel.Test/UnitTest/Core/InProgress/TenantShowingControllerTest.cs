using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Core.InProgress
{
    [TestClass]
    public class TenantShowingControllerTest
    {
       public TenantShowingController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var tenantShowingRepo = new FakeTenantShowingRepository();
            var uow = new UnitofWork { TenantShowingRepository = tenantShowingRepo };
            Controller = new TenantShowingController(uow);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<TenantShowing>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Create()
        {
             //Act
            var newTenantShowing = new TenantShowing {
                 ShowingId = 4,
                 Date = new DateTime(),
                 UnitId = new Int32(),
                 TenantId = new Int32(),
                 Tenant = new Tenant()  
            };
            Controller.Create(newTenantShowing);
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<TenantShowing>;
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
            var data = viewResult.ViewData.Model as TenantShowing;
            if (data != null) Assert.AreEqual("4", data.TenantId);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            var newDomain = new TenantShowing
            {
                ShowingId = 2,
                Date = new DateTime(),
                UnitId = new Int32(),
                TenantId = 8,
                Tenant = new Tenant()
            };
            Controller.Edit(newDomain);

            // Act
            var actual = Controller.Details(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as TenantShowing;
            if (data != null) Assert.AreEqual("8", data.TenantId);
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
            var data = viewResult.ViewData.Model as IList<TenantShowing>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       