using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers.PublicProfile
{
    public class AgentProfileController : BaseController
    {
        public AgentProfileController(IGenericUnitofWork uow, IUserHelper userHelper)
        {
            UnitofWork = uow;
            UserHelper = userHelper;
        }

        public ActionResult Index(int id)
        {
            var agent = UserHelper.AgentPublicProfileHelper.GetAgentPublicProfileByAgentId(id);
            if (agent == null) return RedirectToAction("Index", "Home");
            ViewBag.agentId = agent.AgentId;
            ViewBag.agentGoogleMap = agent.GoogleMap;
            return View(agent);
        }
    }
}
