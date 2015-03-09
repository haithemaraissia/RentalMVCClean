using System.Linq;
using System.Web.Mvc;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class TenantsController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public TenantsController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.TenantRepository.All.ToList());
        }
    }
}
