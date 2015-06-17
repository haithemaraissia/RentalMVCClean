using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.PublicProfile;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Controller.InProgress.Process.Project
{
    [TestClass]
    public class ProjectDetailControllerTest
    {
        public ProjectDetailController Controller;
        public FormCollection Form;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var fakeProjectDetails = new FakeProjectPhotos();
            var projectDetailRepo = new FakeProjectPhotoRepository(fakeProjectDetails.MyProjectPhotos);
            var uow = new UnitofWork { ProjectPhotoRepository = projectDetailRepo };
            Controller = new ProjectDetailController(uow, null);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<ProjectPhoto>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void MakeOffer()
        {
            // Act
            var makeFormCall = Controller.MakeOffer(CreateMakeOfferForm());
            var confirmView = Controller.Confirm();
            // Assert
            var viewResult = confirmView as ViewResult;
            if (viewResult == null) return;

            Assert.AreEqual("1/1/2001", viewResult.ViewBag.StartDate);
            Assert.AreEqual("1/1/2002", viewResult.ViewBag.EndDate);
            Assert.AreEqual("2", viewResult.ViewBag.ProjectId);
        }

        public FormCollection CreateMakeOfferForm()
        {
            Form = new FormCollection
            {
                {"HiddenStartDate", "1/1/2001"},
                {"HiddenEndDate", "1/1/2002"},
                {"HiddenProjectId", "2"}
            };
            return Form;

        }
        [TestCleanup]
        public void CleanUp()
        {
           Controller.Dispose();
            Form = null;
        }
    }
}
       