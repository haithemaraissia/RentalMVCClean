using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class SpecialistsController : Controller
    {
        private readonly RentalContext _db = new RentalContext();
        public ActionResult Index()
        {
            return View(_db.Specialists.ToList());
        }

    }
}
