using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class RentController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public RentController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.UnitRepository.AllIncluding(x=>x.UnitPricing).ToList());
        }


    }
}
