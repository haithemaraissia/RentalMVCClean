using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalMobile.Controllers;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Identity.Base.Roles.PrivateProfile;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Core.InProgress.Profiles
{
    [TestClass]
    public class AgentProfileControllerTest
    {
        public AgentProfileController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var agentRepo = new FakeAgentRepository();
            var uow = new UnitofWork { AgentRepository = agentRepo };

            //MockHelper
            var mockHelper = new Mock<IUserHelper>();
            mockHelper.Setup(x => x.AgentPrivateProfileHelper).Returns(new AgentPrivateProfileHelper(uow, null));
            Controller = new AgentProfileController(uow, mockHelper.Object);

        }

        [TestMethod]
        public void Index()
        {
            // Act
            var actual = Controller.Index(2);

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.Model as Agent;
            if (data == null) return;
            Assert.AreEqual("Sammy Agent", viewResult.ViewBag.FirstName);
            Assert.AreEqual("2", viewResult.ViewBag.agentId);
            Assert.AreEqual("Google Address", viewResult.ViewBag.agentGoogleMap);
        }

        [TestMethod]
        public void Create()
        {
            // Act
            //var newDomain = new Domain { Url = "Test5" };
            //Controller.Create(newDomain);
            //var actual = Controller.Index();

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<AgentProfileController>;
            //if (data != null) Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void Details()
        {
            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as AgentProfileController;
            //if (data != null) Assert.AreEqual("test2", data.Url);
        }

        [TestMethod]
        public void Edit()
        {
            // Act
            //var newDomain = new Domain { Id = 2, Url = "new Domain" };
            //Controller.Edit(newDomain);

            // Act
            //var actual = Controller.Details(2);

            // Assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as AgentProfileController;
            //if (data != null) Assert.AreEqual("new Domain", data.Url);
        }

        [TestMethod]
        public void Delete()
        {
            // Act
            //Controller.Delete(1);
            //var actual = Controller.Index();

            // assert
            //var viewResult = actual as ViewResult;
            //if (viewResult == null) return;
            //var data = viewResult.ViewData.Model as IList<Domain>;
            //if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Controller.Dispose();
        }
    }
}
       