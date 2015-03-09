using System.Linq;
using System.Web.Mvc;
using RentalModel.Repository.Generic.UnitofWork;


namespace RentalMobile.Controllers
{
    public class SpecialistsController : Controller
    {

        private readonly UnitofWork _unitOfWork;
        public SpecialistsController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.SpecialistRepository.All.ToList());
        }

    }
}
