using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class SpecialistsController : Controller
    {
        private readonly DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public ActionResult Index()
        {
            return View(db.Specialists.ToList());
        }

    }
}
