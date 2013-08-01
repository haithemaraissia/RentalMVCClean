﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalMobile.ModelViews;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class TestController : Controller
    {
        private DB_33736_rentalEntities db = new DB_33736_rentalEntities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Description");
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(UnitModelView u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Units.Add(u.Unit);
                    db.UnitFeatures.Add(u.UnitFeature);
                   db.UnitCommunityAmenities.Add(u.UnitCommunityAmenity);
                   db.UnitAppliances.Add(u.UnitAppliance);
                   db.UnitInteriorAmenities.Add(u.UnitInteriorAmenity);
                   db.UnitExteriorAmenities.Add(u.UnitExteriorAmenity);
                   db.UnitLuxuryAmenities.Add(u.UnitLuxuryAmenity);
                   db.UnitPricings.Add(u.UnitPricing);




                    //Think if tyou need or not because of the upload control
                    
                    //db.UnitGalleries.Add(u.UnitGallery);




                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(u);
            }


            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Test/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}