using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.UnitTest.Helpers
{
    public class TestHelper
    {
        public void AssertThatViewResultIsNull(ActionResult actual)
        {
            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        public void AssertThatViewResultIsNull(ViewResult actual)
        {
            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

        public void AssertThatViewResultIsNull(PartialViewResult actual)
        {
            //Assert
            var viewResult = actual;
            Assert.AreEqual(viewResult, null);
        }

    }
}