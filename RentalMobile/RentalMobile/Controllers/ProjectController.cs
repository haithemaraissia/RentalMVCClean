using System.Linq;
using System.Web.Mvc;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{ 
    public class ProjectController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public ProjectController(UnitofWork uow)
        {
            _unitOfWork = uow;
        }
        public ViewResult Index()
        {
            return View(_unitOfWork.ProjectRepository.All.ToList());
        }


        //Only Specialist Make an Offer
        //Make sure to show it when they are log in
        public ViewResult MakeOffer()
        {
            return View();
        }
    }
}