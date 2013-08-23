using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var unit = db.Units.FirstOrDefault(x => x.UnitId == 26);
            return View(unit);
        }

    }
}
