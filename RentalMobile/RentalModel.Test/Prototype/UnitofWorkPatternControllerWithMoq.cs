using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.Prototype
{
    [TestClass]
    public class UnitofWorkPatternControllerWithMoq
    {
        public Mock<IGenericRepository<Unit>> MockRepository;
        public Mock<IGenericUnitofWork> MockUnitofWork;
        public FakeUnits FakeUnits;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            FakeUnits = new FakeUnits();

            //MockRepository
            MockRepository = new Mock<IGenericRepository<Unit>>();
            MockRepository.Setup(x => x.All).Returns(FakeUnits.MyUnits.AsQueryable());
            MockRepository.Setup(m => m.Find(It.IsAny<Unit>())).Returns((int d) =>
                FakeUnits.MyUnits.Find(x => x.UnitId == d));
            MockRepository.Setup(m => m.Insert(It.IsAny<Unit>())).Callback((Unit unit) =>
            {
                FakeUnits.MyUnits.Add(unit);
            });
            MockRepository.Setup(m => m.Update(It.IsAny<Unit>())).Callback((Unit unit) =>
            {
                FakeUnits.MyUnits.Remove(FakeUnits.MyUnits.Find(x => x.UnitId == unit.UnitId));
                FakeUnits.MyUnits.Add(unit);
            });
            MockRepository.Setup(m => m.Delete(It.IsAny<Unit>())).Callback((Unit unit) =>
            {
                FakeUnits.MyUnits.Remove(FakeUnits.MyUnits.Find(x => x.UnitId == unit.UnitId));
            });
            //MockIUnitofWork
            MockUnitofWork = new Mock<IGenericUnitofWork>();
            MockUnitofWork.SetupGet(x => x.UnitRepository).Returns(MockRepository.Object);
        }

        [TestMethod]
        public void IndexWithMocking()
        {
            //arrange
            var controller = new RentalMobile.Controllers.UnitofWorkPatternController(MockUnitofWork.Object);

            // act
            var actual = controller.Index();

            // assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Unit>;
            if (data != null) Assert.AreEqual(2, data.Count);
        }


        [TestCleanup]
        public void CleanUp()
        {
            MockRepository = null;
            MockUnitofWork = null;
            FakeUnits = null;
        }
    }
}
