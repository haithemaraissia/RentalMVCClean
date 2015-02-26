using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        public RentalContext db = new RentalContext();

        public ViewResult Index()
        {
            var Agent = db.Agents.Find(UserHelper.GetAgentId());
            ViewBag.AgentProfile = Agent;
            ViewBag.AgentId = Agent.AgentId;
            ViewBag.AgentGoogleMap = Agent.GoogleMap;
            return View(Agent);
        }

        public ActionResult Edit(int id)
        {
            Agent Agent = db.Agents.Find(id);
            return View(Agent);
        }

        [HttpPost]
        public ActionResult Edit(Agent Agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Agent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Agent);
        }

        public ActionResult ChangeAddress(int id)
        {
            Agent Agent = db.Agents.Find(id);
            return View(Agent);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Agent Agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Agent).State = EntityState.Modified;
                Agent.GoogleMap = string.IsNullOrEmpty(Agent.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(Agent.Address, Agent.City, Agent.CountryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Agent);
        }

        public ActionResult Delete(int id)
        {
            Agent Agent = db.Agents.Find(id);
            return View(Agent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent Agent = db.Agents.Find(id);
            db.Agents.Remove(Agent);
            db.SaveChanges();
            // Delete All associated records

            //var Agentshowing = db.AgentShowings.Where(x => x.AgentId == id).ToList();
            //foreach (var x in Agentshowing)
            //{
            //    db.AgentShowings.Remove(x);
            //}
            //db.SaveChanges();
            if (Roles.GetRolesForUser(User.Identity.Name).Any())
            {
                Roles.RemoveUserFromRoles(User.Identity.Name, Roles.GetRolesForUser(User.Identity.Name));
            }
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




        //////////////Maybe Needed for Future Option///////////        
        //DETAIL OF Agent FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var Agentfavorite =  db.AgentFavorites.Where(x => x.AgentId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Agent Agent = db.AgentFavorites.Where(Agent == 6 && )
        //    return PartialView("_AgentFavDetail",Agentfavorite);
        //}

    }
}