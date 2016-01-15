using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");




            //Professional/{Id} 
            routes.MapRoute(
                "ProfessionalView",
                "SpecialistProfile/{id}",
                new { controller = "SpecialistProfile", action = "Index",  id = UrlParameter.Optional }
            );

            //ProviderProfile/{Id} 
            routes.MapRoute(
                "ProviderProfileView",
                "ProviderProfile/{id}",
                new { controller = "ProviderProfile", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );



            //Area




            
            //Need to add new route for property/id
            //routes.MapRoute("Property", "Property/{id}",
            //             new { controller = "Property", action = "Index" });



            //OwnerProject
           // routes.MapRoute(
           //  "Owner",
           //  "ArchivedProject/View",
           //  new { Controller = "Owner", action = "ViewArchivedProject" });

           // routes.MapRoute(
           //"Owner",
           //"ArchivedProject/Delete",
           //new { Controller = "Owner", action = "ViewArchivedProject" });
        }

        protected void Application_Start()
        {

            ViewEngines.Engines.Add(new MobileViewEngine());
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependencyResolver();
        }
        private void RegisterDependencyResolver()
        {
            var kernel = new Bootstrapper().Kernel;
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

    }
}