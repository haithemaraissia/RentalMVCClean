using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;
using TestProject.Before.Fake;
using Assert = NUnit.Framework.Assert;

namespace TestProject.Before.UnitOfWork
{
    [TestClass]
    public class UnitofWorkPatternTest
    { 
        public DummyRentalRepositoryTest UnitRepo;
        public RentalModel.Repository.Generic.UnitofWork.UnitofWork Uow;
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
            // Lets create our dummy repository
            UnitRepo = new DummyRentalRepositoryTest(_fakeUnits.MyUnits);

            // Let us now create the Unit of work with our dummy repository
            Uow = new RentalModel.Repository.Generic.UnitofWork.UnitofWork(UnitRepo);

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
            var repoMock = new Mock<IUnitRepository>();
            repoMock.Setup(x => x.GetUnits()).Returns(_fakeUnits.MyUnits);

            var uowMock = new Mock<RentalModel.Repository.Generic.UnitofWork.UnitofWork>(repoMock.Object);
            Controller = new UnitofWorkPatternController(uowMock.Object);

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


        ///TODO 
        /// With Only Mocking of IRepository
        /// 
        /// 
        /// 
        /// FakeDBContext with IDataSet
        /// Unit test for Control ; Simplistic for View returned by a Controller
        /// Effort for Entity 6
        /// TODO
    }
}
