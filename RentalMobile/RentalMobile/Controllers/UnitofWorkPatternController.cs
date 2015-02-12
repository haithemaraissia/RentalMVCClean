using System.Web.Mvc;
using RentalMobile.Models.UnitOfWork;

namespace RentalMobile.Controllers
{
    public class UnitofWorkPatternController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public UnitofWorkPatternController()
            : this(new UnitOfWork())
        {
        }

        public UnitofWorkPatternController(UnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.UnitRepository.GetUnits());

        }
    }
}
