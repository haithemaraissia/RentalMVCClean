using System.Web.Mvc;

using RentalModel.Repository.CommonPattern;
using RentalModel.Repository.ToDelete.CommonPattern;

namespace RentalMobile.Controllers
{
    public class UnitRepositoryPatternController : Controller
    {

        /// <summary>
        /// Using IRepositry Pattern
        /// </summary>

        public readonly IUnitRepository Unitrepository;

        public UnitRepositoryPatternController() : this(new UnitRepository()) { }

        public UnitRepositoryPatternController(IUnitRepository repository)
        {

            Unitrepository = repository;

        }

        public ActionResult Index()
        {
            return View(Unitrepository.GetUnits());

        }
    }
}
