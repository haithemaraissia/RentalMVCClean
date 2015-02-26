using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers;
using RentalMobile.Model.Models;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;
using TestProject.Before.Fake;
using TestProject.Before.UnitOfWork;
using Assert = NUnit.Framework.Assert;

namespace TestProject.Before.Repository
{
    [TestClass]
    public class UnitRepositoryPatternTest
    {

        public DummyRentalRepositoryTest UnitRepo;
        public UnitRepositoryPatternController Controller;

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

            // Now lets create the unitsController object to test and pass our unit of work
            Controller = new UnitRepositoryPatternController(UnitRepo);

            // act
            var actual = Controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(1, data.Count);
        }

        [TestMethod]
        public void IndexViewData()
        {
            //Arrange//
            // Lets create our dummy repository
            UnitRepo = new DummyRentalRepositoryTest(_fakeUnits.MyUnits);

            // Now lets create the unitsController object to test and pass our unit of work
            Controller = new UnitRepositoryPatternController(UnitRepo);

            // act
            var actual = Controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null)
            {
                Assert.AreEqual(1, data.Count);
            }

            ///------View Name-------///
            // var result = controller.Details(2) as ViewResult;
            //Assert.AreEqual("Details", result.ViewName);
            ///------View Name-------///


            ///------Redirect to Action result-------///
            //if (Id < 1)
            //return RedirectToAction("Index");
            // var result = (RedirectToRouteResult) controller.Details(-1);
            // Assert.AreEqual("Index", result.Values["action"]);
            ///------Redirect to ActioN result-------///
        }


        [TestMethod]
        public void IndexWithMocking()
        {
            // Arrange
            //Creating a mock Object
            //Pass the mock to the SUT
            var repoMock = new Mock<IUnitRepository>();
            repoMock.Setup(x => x.GetUnits()).Returns(_fakeUnits.MyUnits);


            Controller = new UnitRepositoryPatternController(repoMock.Object);

            //ACT
            //Execute the SUT
            var actual = Controller.Index();

            //Assert
            //Verify SUT's interaction with the mock object
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(1, data.Count);
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
