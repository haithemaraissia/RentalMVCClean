using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class OwnersController : Controller
    {
        private readonly RentalContext db = new RentalContext();
        public ActionResult Index()
        {
            return View(db.Owners.ToList());
        }

    }
}
