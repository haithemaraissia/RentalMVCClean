using System.Linq;
using System.Web.Mvc;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class OwnersController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public OwnersController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.OwnerRepository.All.ToList());
        }
    }
}
