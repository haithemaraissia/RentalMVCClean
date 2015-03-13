using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class AgentProfileController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public AgentProfileController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index(int id)
        {
            var agent = _unitOfWork.AgentRepository.FindBy(x => x.AgentId == UserHelper.GetAgentId(id)).FirstOrDefault();
            if (agent == null) return RedirectToAction("Index", "Home");
            ViewBag.agentId = agent.AgentId;
            ViewBag.agentGoogleMap = agent.GoogleMap;
            return View(agent);
        }
    }
}
