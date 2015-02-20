using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class NewUnitTestController : Controller
    {
        private RentalContext db = new RentalContext();

        //
        // GET: /NewUnitTest/

        public ViewResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /NewUnitTest/Details/5

        public ViewResult Details(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // GET: /NewUnitTest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NewUnitTest/Create

        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Units.Add(unit);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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

            return View(unit);
        }

        //
        // GET: /NewUnitTest/Edit/5

        public ActionResult Edit(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // POST: /NewUnitTest/Edit/5

        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        //
        // GET: /NewUnitTest/Delete/5

        public ActionResult Delete(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // POST: /NewUnitTest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}