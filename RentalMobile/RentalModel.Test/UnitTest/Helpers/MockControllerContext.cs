using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Moq;

namespace TestProject.UnitTest.Helpers
{
    public static class ControllerContextHelper
    {
        public static void FakeHttpContext(this System.Web.Mvc.Controller controller)
        {
            HttpContext myhttpContext = new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));
            HttpContext.Current = myhttpContext;

            String[] rolesArray = { "Agent" };

            // User is logged in
            HttpContext.Current.User = new GenericPrincipal(
                new GenericIdentity("Sam"),
                rolesArray
                );

            // User is logged out
            HttpContext.Current.User = new GenericPrincipal(
                new GenericIdentity(String.Empty),
                rolesArray
                );
        }

        public static void FakeHttpContextWithAuthenticatedSpecialist(this System.Web.Mvc.Controller controller)
        {
            HttpContext myhttpContext = new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));
            HttpContext.Current = myhttpContext;

            GenericIdentity ident = new GenericIdentity("sami5");

            GenericPrincipal principal = new GenericPrincipal(ident, new string[] { "Specialist" });

            System.Threading.Thread.CurrentPrincipal = principal;

            String[] rolesArray = { "Specialist" };

            // User is logged in
            HttpContext.Current.User = principal;

            MockControllerContext(controller);
        }

        public static void MockControllerContext(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            var myhttpContext =
                new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                    new HttpResponse(null)));
            controllerContext.SetupGet(x => x.HttpContext)
                .Returns(myhttpContext);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockControllerContextForServerMap(this System.Web.Mvc.Controller controller)
        {

            var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            server.Setup(x => x.MapPath(It.IsAny<string>())).Returns("test");

            var response = new Mock<HttpResponseBase>(MockBehavior.Loose);

            var request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            request.Setup(r => r.UserHostAddress).Returns("http://tempuri.org");

            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());

            var context = new Mock<HttpContextBase>();
            context.SetupGet(c => c.Request).Returns(request.Object);
            context.SetupGet(c => c.Response).Returns(response.Object);
            context.SetupGet(c => c.Server).Returns(server.Object);
            context.SetupGet(c => c.Session).Returns(session.Object);

            controller.ControllerContext = new ControllerContext(context.Object,
                                              new RouteData(), controller);

        }

    }
}
