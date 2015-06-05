using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{ 
    public class ProjectController : BaseController
    {

        public ProjectController(IGenericUnitofWork uow)
        {
            UnitofWork = uow;
        }

        public ViewResult Index()
        {
            return View(UnitofWork.ProjectRepository.All.ToList());
        }


        //Only Specialist Make an Offer
        //Make sure to show it when they are log in
        public ViewResult MakeOffer()
        {
            return View();
        }
    }
}