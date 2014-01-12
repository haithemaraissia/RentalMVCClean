using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/3


        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        public ActionResult Index()
        {
            //var unit = db.Units.FirstOrDefault(x => x.UnitId == 26);
            //return View(unit);



            //Spe 8 id:10
            //spe10 id:12

            //


            //All i have from registration is

            //Name
            //EmailAddress

            //Passwod, Role

            var specialist = db.Specialists.FirstOrDefault(x => x.SpecialistId == 10);




            if (specialist != null)
            {
                var smp = new SpecialistMaintenanceProfile()
                    {
                        MaintenanceCompanyLookUp = { Role = 1, UserId = 10 },
                        MaintenanceCompany =
                            {
                                Name = specialist.LastName + "," + specialist.FirstName,
                                EmailAddress = specialist.EmailAddress,
                                GUID = specialist.GUID
                            }
                    };

                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        smp.Save(smp);
                //    }
                //    catch (Exception e)
                //    {

                //        throw new Exception(e.InnerException.Message);
                //    }

                //}
            }






            //testing the creation and the identity for company id
            //When success ; go back to regisrtation and them to
            //Professional
            //Specialist




            //Then do the complete profile for both roles
            //Then create the table for profile completion.


            return View();
        }

    }
}
