using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PrivateProfile.Agent
{
    [Authorize]
    public class AgentController : BaseController
    {
        public AgentController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        public ViewResult Index()
        {
            var agent = UserHelper.AgentPrivateProfileHelper.GetAgent();
            ViewBag.AgentProfile = agent;
            ViewBag.AgentId = agent.AgentId;
            ViewBag.AgentGoogleMap = agent.GoogleMap;
            return View(agent);
        }

        public ActionResult Edit(int id)
        {
            var agent = UserHelper.AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(id);
            return View(agent);
        }

        [HttpPost]
        public ActionResult Edit(Model.Models.Agent agent)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.AgentRepository.Edit(agent);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        public ActionResult ChangeAddress(int id)
        {
            var agent = UserHelper.AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(id);
            return View(agent);
        }

        [HttpPost]
        public ActionResult ChangeAddress(Model.Models.Agent agent)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.AgentRepository.Edit(agent);
                agent.GoogleMap = UserHelper.AgentPrivateProfileHelper.AgentGoogleMap();
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        public ActionResult Delete(int id)
        {
            var agent = UserHelper.AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(id);
            return View(agent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var agent = UserHelper.AgentPrivateProfileHelper.GetAgentPrivateProfileByAgentId(id);
            UnitofWork.AgentRepository.Delete(agent);
            UnitofWork.Save();

            // Delete All associated records

            //var Agentshowing = db.AgentShowings.Where(x => x.AgentId == id).ToList();
            //foreach (var x in Agentshowing)
            //{
            //    db.AgentShowings.Remove(x);
            //}
            //db.SaveChanges();

            UserHelper.AgentPrivateProfileHelper.DeleteAgentMemebership();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload", "Account", new { id });
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