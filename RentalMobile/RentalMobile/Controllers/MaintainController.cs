using System.Linq;
using System.Web.Mvc;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class MaintainController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public MaintainController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.MaintenanceProviderRepository.All.ToList());
        }
    }
}
