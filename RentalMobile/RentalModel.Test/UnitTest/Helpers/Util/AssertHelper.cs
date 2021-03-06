using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTest.Helpers.Util
{
    public class AssertHelper
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