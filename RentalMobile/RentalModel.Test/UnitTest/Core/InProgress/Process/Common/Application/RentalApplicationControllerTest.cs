using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.Process;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Core.InProgress.Process.Common.Application
{
    [TestClass]
    public class RentalApplicationControllerTest
    {
        public RentalApplicationController Controller;
        public FakeRentalApplicationRepository RentalApplicationRepo = new FakeRentalApplicationRepository();

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var uow = new UnitofWork { RentalApplicationRepository = RentalApplicationRepo };
            Controller = new RentalApplicationController(uow);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalApplication>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Create()
        {
            //Act
            var newRentalApplication = new RentalApplication {
                 ApplicationId = 4,
                 FirstName = null,
                 LastName = null,
                 MiddleName = null,
                 DateofBirth = new DateTime(),
                 SocialSecurityNumber = null,
                 DriverLicense = null,
                 Phone = null,
                 CellPhone = null,
                 EmailAddress = null,
                 CoSignerName = null,
                 CoSignerAddress = null,
                 CoSignerCity = null,
                 CoSignerState = null,
                 CoSignerZipcode = null,
                 CoSignerPhone = null,
                 CoSignerRelationShip = null,
                 CoSignerEmailAddress = null,
                 OtherOccupant1Name = null,
                 IsOccupant1Adult = new Boolean(),
                 RelationshipOccupant1ToApplicant = null,
                 OtherOccupant2Name = null,
                 IsOccupant2Adult = new Boolean(),
                 RelationshipOccupant2ToApplicant = null,
                 OtherOccupant3Name = null,
                 IsOccupant3Adult = new Boolean(),
                 RelationshipOccupant3ToApplicant = null,
                 OtherOccupant4Name = null,
                 IsOccupant4Adult = new Boolean(),
                 RelationshipOccupant4ToApplicant = null,
                 EmployerName = null,
                 Income = null,
                 WorkStartDate = new DateTime(),
                 WorkEndDate = new DateTime(),
                 EmployerAddress = null,
                 EmployerCity = null,
                 EmployerState = null,
                 EmployerZipcode = null,
                 EmployerPhone = null,
                 EmployerFax = null,
                 CurrentLandloard = null,
                 CurrentLandLoardPhone = null,
                 CurrentLandLoardFax = null,
                 CurrentAddress = null,
                 CurrentAddressCity = null,
                 CurrentAddressState = null,
                 CurrentAddressZip = null,
                 Rent = null,
                 CurrentRentStartDate = new DateTime(),
                 CurrentRentEndDate = new DateTime(),
                 PreviousLandloard = null,
                 PreviousLandLoardPhone = null,
                 PreviousLandLoardFax = null,
                 PreviousAddress = null,
                 PreviousAddressCity = null,
                 PreviousAddressState = null,
                 PreviousAddressZip = null,
                 PreviousRent = null,
                 PreviousRentStartDate = new DateTime(),
                 PreviousRentEndDate = new DateTime(),
                 EmergencyContactName = null,
                 EmergencyContactRelationShip = null,
                 EmergencyContactPhone = null,
                 EmergencyContactAddress = null,
                 EmergencyContactCity = null,
                 EmergencyContactState = null,
                 EmergencyContactZipCode = null,
                 Pets = new Boolean(),
                 PetsNumber = new Int32(),
                 Pet1Brand = null,
                 Pet1Age = new Int32(),
                 Pet1Weight = null,
                 Pet2Brand = null,
                 Pet2Age = new Int32(),
                 Pet2Weight = null,
                 Vehicle1Make = null,
                 Vehicle1Model = null,
                 Vehicle1Year = new Int32(),
                 Vehicle1Color = null,
                 Vehicle1LicensePlate = null,
                 Vehicle2Make = null,
                 Vehicle2Model = null,
                 Vehicle2Year = new Int32(),
                 Vehicle2Color = null,
                 Vehicle2LicensePlate = null,
                 Vehicle3Make = null,
                 Vehicle3Model = null,
                 Vehicle3Year = new Int32(),
                 Vehicle3Color = null,
                 Vehicle3LicensePlate = null,
                 Vehicle4Make = null,
                 Vehicle4Model = null,
                 Vehicle4Year = new Int32(),
                 Vehicle4Color = null,
                 Vehicle4LicensePlate = null,
                 Bankruptcy = new Boolean(),
                 LeaseDefaulted = new Boolean(),
                 RefusedtoPayRent = new Boolean(),
                 EvictedFromRental = new Boolean(),
                 ConvictedofFelony = new Boolean(),
                 TenantId = new Int32()
    };
            Controller.Create(newRentalApplication);
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalApplication>;
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
            var data = viewResult.ViewData.Model as RentalApplication;
            if (data != null) Assert.AreEqual("Shawnee", data.PreviousAddressCity);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            var rentalApplicationShowing = RentalApplicationRepo.FindBy(x => x.ApplicationId == 2).FirstOrDefault();
            if (rentalApplicationShowing == null) { Assert.AreEqual(true, "rental Application Showing == null"); };
            if (rentalApplicationShowing != null)
            {
                rentalApplicationShowing.CellPhone = "91354578";
                Controller.Edit(rentalApplicationShowing);
            }
            var actual = Controller.Details(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as RentalApplication;
            if (data != null) Assert.AreEqual("91354578", data.CellPhone);
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
            var data = viewResult.ViewData.Model as IList<RentalApplication>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Submit()
        {
            //Act
            var newRentalApplication = new RentalApplication
            {
                ApplicationId = 5,
                FirstName = null,
                LastName = null,
                MiddleName = null,
                DateofBirth = new DateTime(),
                SocialSecurityNumber = null,
                DriverLicense = null,
                Phone = null,
                CellPhone = null,
                EmailAddress = null,
                CoSignerName = null,
                CoSignerAddress = null,
                CoSignerCity = null,
                CoSignerState = null,
                CoSignerZipcode = null,
                CoSignerPhone = null,
                CoSignerRelationShip = null,
                CoSignerEmailAddress = null,
                OtherOccupant1Name = null,
                IsOccupant1Adult = new Boolean(),
                RelationshipOccupant1ToApplicant = null,
                OtherOccupant2Name = null,
                IsOccupant2Adult = new Boolean(),
                RelationshipOccupant2ToApplicant = null,
                OtherOccupant3Name = null,
                IsOccupant3Adult = new Boolean(),
                RelationshipOccupant3ToApplicant = null,
                OtherOccupant4Name = null,
                IsOccupant4Adult = new Boolean(),
                RelationshipOccupant4ToApplicant = null,
                EmployerName = null,
                Income = null,
                WorkStartDate = new DateTime(),
                WorkEndDate = new DateTime(),
                EmployerAddress = null,
                EmployerCity = null,
                EmployerState = null,
                EmployerZipcode = null,
                EmployerPhone = null,
                EmployerFax = null,
                CurrentLandloard = null,
                CurrentLandLoardPhone = null,
                CurrentLandLoardFax = null,
                CurrentAddress = null,
                CurrentAddressCity = null,
                CurrentAddressState = null,
                CurrentAddressZip = null,
                Rent = null,
                CurrentRentStartDate = new DateTime(),
                CurrentRentEndDate = new DateTime(),
                PreviousLandloard = null,
                PreviousLandLoardPhone = null,
                PreviousLandLoardFax = null,
                PreviousAddress = null,
                PreviousAddressCity = null,
                PreviousAddressState = null,
                PreviousAddressZip = null,
                PreviousRent = null,
                PreviousRentStartDate = new DateTime(),
                PreviousRentEndDate = new DateTime(),
                EmergencyContactName = null,
                EmergencyContactRelationShip = null,
                EmergencyContactPhone = null,
                EmergencyContactAddress = null,
                EmergencyContactCity = null,
                EmergencyContactState = null,
                EmergencyContactZipCode = null,
                Pets = true,
                PetsNumber = new Int32(),
                Pet1Brand = null,
                Pet1Age = new Int32(),
                Pet1Weight = null,
                Pet2Brand = null,
                Pet2Age = new Int32(),
                Pet2Weight = null,
                Vehicle1Make = null,
                Vehicle1Model = null,
                Vehicle1Year = new Int32(),
                Vehicle1Color = null,
                Vehicle1LicensePlate = null,
                Vehicle2Make = null,
                Vehicle2Model = null,
                Vehicle2Year = new Int32(),
                Vehicle2Color = null,
                Vehicle2LicensePlate = null,
                Vehicle3Make = null,
                Vehicle3Model = null,
                Vehicle3Year = new Int32(),
                Vehicle3Color = null,
                Vehicle3LicensePlate = null,
                Vehicle4Make = null,
                Vehicle4Model = null,
                Vehicle4Year = new Int32(),
                Vehicle4Color = null,
                Vehicle4LicensePlate = null,
                Bankruptcy = new Boolean(),
                LeaseDefaulted = new Boolean(),
                RefusedtoPayRent = new Boolean(),
                EvictedFromRental = new Boolean(),
                ConvictedofFelony = new Boolean(),
                TenantId = new Int32()
            };
            Controller.Create(newRentalApplication);
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalApplication>;
            if (data != null) Assert.AreEqual(4, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
            RentalApplicationRepo.Dispose();
        }
    }
}
       