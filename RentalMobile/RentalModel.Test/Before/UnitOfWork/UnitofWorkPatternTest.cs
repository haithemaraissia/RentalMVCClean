using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers;
using RentalMobile.ControllerTester;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.Repositories.Base;
using RentalModel.Repository.Generic.UnitofWork;
using TestProject.Before.Fake;
using Assert = NUnit.Framework.Assert;

namespace TestProject.Before.UnitOfWork
{
    [TestClass]
    public class UnitofWorkPatternTest
    { 
        public DummyRentalRepositoryTest UnitRepo;
        public UnitofWork Uow;
        public UnitofWorkPatternController Controller;
        private readonly FakeUnits _fakeUnits = new FakeUnits();

        [TestInitialize]
        public void SetUp()
        {
            _fakeUnits.InitializeUnitList();
        }

        [TestMethod]
        public void Index()
        {
            //Arrange//
            UnitRepo = new DummyRentalRepositoryTest(_fakeUnits.MyUnits);

            // Let us now create the Unit of work with our dummy repository
            Uow = new UnitofWork {UnitRepository = UnitRepo};

            // Now lets create the unitsController object to test and pass our unit of work
            Controller = new UnitofWorkPatternController(Uow);

            // act
            var actual = Controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(1, data.Count);
        }

        [TestMethod]
        public void IndexWithMocking()
        {
            // Arrange
            //Creating a mock Object
            //Pass the mock to the SUT
            var repoMock = new Mock<IGenericRepository<Unit>>();    
            repoMock.Setup(x => x.All).Returns(_fakeUnits.MyUnits.AsQueryable());


            var unitofWork = new UnitofWork{ UnitRepository = repoMock.Object};

          //  var uowMock = new Mock<UnitofWork>(repoMock.Object);
            Controller = new UnitofWorkPatternController(unitofWork);

            //ACT
                //Execute the SUT
            var actual = Controller.Index();

            //Assert
                //Verify SUT's interaction with the mock object
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(1, data.Count );
        }
    }
}
