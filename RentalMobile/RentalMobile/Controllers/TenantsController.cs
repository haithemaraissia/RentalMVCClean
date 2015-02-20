using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    public class TenantsController : Controller
    {
        private readonly RentalContext _db = new RentalContext();
        public ActionResult Index()
        {
            return View(_db.Tenants.ToList());
        }
    }
}
