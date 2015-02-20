﻿using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    public class RentController : Controller
    {
        private readonly RentalContext _db = new RentalContext();

        public ActionResult Index()
        {
            return View(_db.Units.Include("UnitPricing").ToList());
        }


    }
}
