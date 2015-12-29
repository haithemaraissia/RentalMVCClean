using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Controllers.Listing.Agents;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Repositories;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Application.Controllers.Done.Listing
{
    [TestClass ]
    public class AgentsControllerTest
    {
        public AgentsController Controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var agentRepo = new FakeAgentRepository();
            var uow = new UnitofWork { AgentRepository = agentRepo };
            Controller = new AgentsController(uow);
        }

        [TestMethod]
        public void IndexShouldListAllAgents()
        {
            // Act
            var actual = Controller.Index();

            // Assert
            var viewResult = actual as ViewResult;
            if (viewResult == null) return;
            var data = viewResult.ViewData.Model as IList<Agent>;
            if (data != null) Assert.AreEqual(3, data.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Controller.Dispose();
        }
    }
}
       