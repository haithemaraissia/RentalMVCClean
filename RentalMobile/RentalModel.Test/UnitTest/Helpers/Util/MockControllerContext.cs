using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Moq;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Roles;
using TestProject.UnitTest.Helpers.Fake;

namespace TestProject.UnitTest.Helpers
{
    public static class ControllerContextHelper
    {
        /// <summary>
        /// You can either use mocking of faking
        /// 
        /// Fake live instance of HtpContext
        /// Mock is Mock Instance of HtpContext
        /// 
        /// </summary>

        #region FakingContext

        //Faking Context

        public static void FakeHttpContext(this System.Web.Mvc.Controller controller)
        {
            HttpContext myhttpContext = new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));
            HttpContext.Current = myhttpContext;
        }

        public static void FakeHttpContextWithUserLoginAndLogOff(this System.Web.Mvc.Controller controller)
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
            FakeHttpContext(controller);

            var principal = SpecialistGenericPrincipal();
            Thread.CurrentPrincipal = principal;

            // User is logged in
            HttpContext.Current.User = principal;
        }

        public static void FakeHttpContextWithAuthenticatedUser(this System.Web.Mvc.Controller controller, LookUpRoles.Roles r)
        {
            FakeHttpContext(controller);

            var principal = AuthenticatedRole(r);
            Thread.CurrentPrincipal = principal;

            // User is logged in
            HttpContext.Current.User = principal;
        }


        #region generic Role Credentials
        public static GenericPrincipal TenantGenericPrincipal()
        {
            //TenantId = 5
            var ident = new GenericIdentity("fred");
            var principal = new GenericPrincipal(ident, new[] { LookUpRoles.TenantRole });
            return principal;
        }
        public static GenericPrincipal OwnerGenericPrincipal()
        {
            //OwnerId = 1
            var ident = new GenericIdentity("lisa");
            var principal = new GenericPrincipal(ident, new[] { LookUpRoles.OwnerRole });
            return principal;
        }
        public static GenericPrincipal AgentGenericPrincipal()
        {
            //AgentId = 1,
            var ident = new GenericIdentity("mike");
            var principal = new GenericPrincipal(ident, new[] { LookUpRoles.AgentRole });
            return principal;
        }
        public static GenericPrincipal SpecialistGenericPrincipal()
        {
            //  SpecialistId = 1
            var ident = new GenericIdentity("sara");
            var principal = new GenericPrincipal(ident, new[] { LookUpRoles.SpecialistRole });
            return principal;
        }
        public static GenericPrincipal ProviderGenericPrincipal()
        {
            //  MaintenanceProviderId = 1
            var ident = new GenericIdentity("jeff");
            var principal = new GenericPrincipal(ident, new[] {LookUpRoles.ProviderRole });
            return principal;
        }
        #endregion

        public static GenericPrincipal AuthenticatedRole(LookUpRoles.Roles r)
        {
            switch (r)
            {
                case LookUpRoles.Roles.Tenant:
                    return  TenantGenericPrincipal();
                case LookUpRoles.Roles.Owner:
                    return OwnerGenericPrincipal();
                case LookUpRoles.Roles.Agent:
                    return AgentGenericPrincipal();
                case LookUpRoles.Roles.Specialist:
                    return SpecialistGenericPrincipal();
                case LookUpRoles.Roles.Provider:
                    return ProviderGenericPrincipal();
            }
            return null;
        }

        #endregion

        #region MockingContext
        //Moking Context

        public static void MockHttpContext(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            var myhttpContext =
                new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                    new HttpResponse(null)));
            //controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("sara");
            //controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            //controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Specialist")))).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext).Returns(myhttpContext);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockControllerContextForServerMap(this System.Web.Mvc.Controller controller)
        {

            const string uploadedImagesFodlerPath = @"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalModel.Test\UploadedImages";
            const string photoFolderPath = @"C:\Users\haraissia\Desktop\Latest\RentalMobile\RentalModel.Test\Photo\";

            var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            server.Setup(x => x.MapPath("~/UploadedImages")).Returns(uploadedImagesFodlerPath);
            
            
            const string ownerPhotoPath = "~/Photo/" + LookUpRoles.OwnerRole + "/Profile";
            const string tenantPhotoPath = "~/Photo/" + LookUpRoles.TenantRole + "/Profile";
            const string agentPhotoPath = "~/Photo/" + LookUpRoles.AgentRole + "/Profile";
            const string providerPhotoPath = "~/Photo/" + LookUpRoles.ProviderRole + "/Profile";
            const string specialistPhotoPath = "~/Photo/" + LookUpRoles.SpecialistRole + "/Profile";

            server.Setup(x => x.MapPath(ownerPhotoPath)).Returns(photoFolderPath + LookUpRoles.OwnerRole + @"\Profile");
            server.Setup(x => x.MapPath(tenantPhotoPath)).Returns(photoFolderPath + LookUpRoles.TenantRole + @"\Profile");
            server.Setup(x => x.MapPath(agentPhotoPath)).Returns(photoFolderPath + LookUpRoles.AgentRole + @"\Profile");
            server.Setup(x => x.MapPath(providerPhotoPath)).Returns(photoFolderPath + LookUpRoles.ProviderRole + @"\Profile");
            server.Setup(x => x.MapPath(specialistPhotoPath)).Returns(photoFolderPath + LookUpRoles.SpecialistRole + @"\Profile");

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



        #endregion



        #region MockingUser

        public static void MockTenantFred(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("fred");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Tenant")))).Returns(true);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockLisaOwner(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("lisa");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Owner")))).Returns(true);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockMikeAgent(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("mike");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Agent")))).Returns(true);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockSaraSpecialist(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("sara");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("Specialist")))).Returns(true);
            controller.ControllerContext = controllerContext.Object;
        }

        public static void MockJeffProvider(this System.Web.Mvc.Controller controller)
        {
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("jeff");
            controllerContext.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            controllerContext.Setup(x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("MaintenanceProvider")))).Returns(true);
            controller.ControllerContext = controllerContext.Object;
        }

        #endregion


    }
}
