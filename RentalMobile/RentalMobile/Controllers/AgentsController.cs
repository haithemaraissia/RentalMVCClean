using System.Linq;
using System.Web.Mvc;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class AgentsController : Controller
    {
        private readonly DB_33736_rentalEntities db = new DB_33736_rentalEntities();
        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }
    }
}
