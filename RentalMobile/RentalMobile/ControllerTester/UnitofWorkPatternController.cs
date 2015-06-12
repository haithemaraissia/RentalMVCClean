using System.Web.Mvc;
using RentalModel.Repository.Generic.UnitofWork;

//using RentalModel.Repository.UnitOfWork;

namespace RentalMobile.ControllerTester
{
    public class UnitofWorkPatternController : Controller
    {
        //private readonly UnitOfWork _unitOfWork;

        //public UnitofWorkPatternController()
        //    : this(new UnitOfWork())
        //{
        //}

        //public UnitofWorkPatternController(UnitOfWork uow)
        //{
        //    _unitOfWork = uow;
        //}

        //public ActionResult Index()
        //{
        //    return View(_unitOfWork.UnitRepository.GetUnits());

        //}

        private readonly IGenericUnitofWork _unitofWork;

        public UnitofWorkPatternController() 
        {
            _unitofWork = new UnitofWork();
        }

        public UnitofWorkPatternController(IGenericUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(_unitofWork.UnitRepository.All);

        }

    }
}
