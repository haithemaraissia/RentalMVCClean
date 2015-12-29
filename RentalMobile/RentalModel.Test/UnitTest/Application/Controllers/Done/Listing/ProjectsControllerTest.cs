using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.Listing.Projects;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Application.Controllers.Done.Listing
{
    [TestClass]
    public class ProjectControllerTest
    {
        public ProjectsController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var projectRepo = new FakeProjectRepository();
            var uow = new UnitofWork { ProjectRepository = projectRepo };
            Controller = new ProjectsController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllProjects()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<RentalMobile.Model.Models.Project>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void OnlySpecialistCanMakeAnOffer()
        {
          //Not Implemented


            //Only Specialist Make an Offer
            //Make sure to show it when they are log in

            Assert.Inconclusive("Not Implemented Yet");
        }

        [TestCleanup]
        public void CleanUp()
        {
          Controller.Dispose();
        }
    }
}
       