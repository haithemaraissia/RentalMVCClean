using System.Linq;
using System.Web.Mvc;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class SpecialistsController : Controller
    {
        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();
        public ActionResult Index()
        {
            return View(_db.Specialists.ToList());
        }

    }
}
