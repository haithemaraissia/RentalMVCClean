using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class AgentsController : Controller
    {
        private readonly RentalContext db = new RentalContext();
        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }
    }
}
