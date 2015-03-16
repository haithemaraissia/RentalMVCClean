using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.CRUD
{
    [TestClass]
    public class GeneratedRentalAgreementControllerTest
    {
        public GeneratedRentalAgreementController Controller;
        public FakeGeneratedRentalContractRepository GeneratedRentalContractsRepo = new FakeGeneratedRentalContractRepository();

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var uow = new UnitofWork { GeneratedRentalContractRepository = GeneratedRentalContractsRepo };
            Controller = new GeneratedRentalAgreementController(uow);
        }


        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<GeneratedRentalContract>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Create()
        {
            //Act
            var newGeneratedContract = new GeneratedRentalContract
            {

                ID = 4,
                LandLoardName = null,
                LandLoardRole = null,
                LandLoradID = new Int32(),
                LandLoardAddress = null,
                TenantName = null,
                TenantID = new Int32(),
                PropertyID = new Int32(),
                PropertyAddress = null,
                PropertyCity = null,
                MonthlyRent = new Double(),
                BeginingDate = new Int32(),
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                FirstMonthRent = new Double(),
                SecurityDeposit = new Double(),
                TotalPayment = new Double(),
                TenantRefundedNumberofDays = new Int32(),
                NoticeofMoveoutNumberofDays = new Int32(),
                LateFeeCharge = new Double(),
                PercentageofLateFeeCharge = new Int32(),
                LateFeeStartingDay = new Int32(),
                ExceptedUtilites = null,
                PetDeposit = new Double(),
                PetMonthly = new Double(),
                ParkingSpaceNumber = null,
                ParkingFee = new Double()

            };
            Controller.Create(newGeneratedContract);
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
            var data = viewResult.ViewData.Model as GeneratedRentalContract;
            if (data != null) Assert.AreEqual(5, data.PropertyID);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            var generatedrentalcontract = GeneratedRentalContractsRepo.FindBy(x => x.ID == 2).FirstOrDefault();
            if (generatedrentalcontract == null) { Assert.AreEqual(true, "generated rental contract == null"); };
            if (generatedrentalcontract != null)
            {
                generatedrentalcontract.PropertyID = 8;
                Controller.Edit(generatedrentalcontract);
            }

            // Act
            var actual = Controller.Details(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as GeneratedRentalContract;
            if (data != null) Assert.AreEqual(8, data.PropertyID);
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
            var data = viewResult.ViewData.Model as IList<GeneratedRentalContract>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
            GeneratedRentalContractsRepo.Dispose();
        }
    }
}
       