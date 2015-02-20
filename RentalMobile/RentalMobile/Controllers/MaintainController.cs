using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    public class MaintainController : Controller
    {
        private readonly RentalContext db = new RentalContext();
        public ActionResult Index()
        {
            return View(db.MaintenanceProviders.ToList());
        }

    }
}
