using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Rental.Documentation.BackUp.Controllers
{
    public class RATestController : Controller
    {
        private RentalContext db = new RentalContext();

        //
        // GET: /RATest/

        public ViewResult Index()
        {
            return View(db.RentalApplications.Where(x => x.TenantId == 5).ToList());
        }

        //
        // GET: /RATest/Details/5

        public ViewResult Details(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RATest/Create

        [HttpPost]
        public ActionResult Create(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                db.RentalApplications.Add(rentalapplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalapplication);
        }

        //
        // GET: /RATest/Edit/5

        public ActionResult Edit(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            return View(rentalapplication);
        }

        //
        // POST: /RATest/Edit/5

        [HttpPost]
        public ActionResult Edit(RentalApplication rentalapplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalapplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalapplication);
        }

        //
        // GET: /RATest/Delete/5

        public ActionResult Delete(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            return View(rentalapplication);
        }

        //
        // POST: /RATest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalApplication rentalapplication = db.RentalApplications.Find(id);
            db.RentalApplications.Remove(rentalapplication);
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