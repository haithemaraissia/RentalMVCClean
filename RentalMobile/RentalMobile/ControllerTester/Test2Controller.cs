using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalMobile.ControllerTester
{
    public class Test2Controller : Controller
    {
//
        private RentalContext db = new RentalContext();

        //
        // GET: /Unit/

        public ViewResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /Unit/Details/5

        public ViewResult Details(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // GET: /Unit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Unit/Create

        [HttpPost]
        public ActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(test.Unit);
                db.UnitFeatures.Add(test.UnitFeature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        //
        // GET: /Unit/Edit/5

        public ActionResult Edit(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // POST: /Unit/Edit/5

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
        // GET: /Unit/Delete/5

        public ActionResult Delete(int id)
        {
            Unit unit = db.Units.Find(id);
            return View(unit);
        }

        //
        // POST: /Unit/Delete/5

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
