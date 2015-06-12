using System.Web.Mvc;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;

namespace RentalMobile.ControllerTester
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
