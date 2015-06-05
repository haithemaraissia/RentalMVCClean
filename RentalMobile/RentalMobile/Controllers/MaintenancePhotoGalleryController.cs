using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers.Base;
using RentalMobile.Helpers.Core;
using RentalMobile.Helpers.Membership;
using RentalMobile.Helpers.Photo.MaintenancePhoto;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace RentalMobile.Controllers
{
    public class MaintenancePhotoGalleryController : BaseController
    {

        public MaintenancePhotoGalleryController(IGenericUnitofWork uow, IMembershipService membershipService, IUserHelper userHelper)
        {
            UnitofWork = uow;
            MembershipService = membershipService;
            UserHelper = userHelper;
        }

        #region ToDO
        //TODO NEED TO COMPLETE AND CLEAN
        public JsonResult GetJsonData()
        {
            //var persons = new List<Person>
            //                  {
            //                      new Person{Id = 1, FirstName = "F1", 
            //                          LastName = "L1", 
            //                          Addresses = new List<Address>
            //                                          {
            //                                              new Address{Line1 = "LaneA"},
            //                                              new Address{Line1 = "LaneB"}
            //                                          }},

            //                      new Person{Id = 2, FirstName = "F2", 
            //                          LastName = "L2", 
            //                          Addresses = new List<Address>
            //                                          {
            //                                              new Address{Line1 = "LaneC"},
            //                                              new Address{Line1 = "LaneD"}
            //                                          }}};

            var persons = UnitofWork.MaintenancePhotoRepository.All;
            var p = persons.Select(d => new Photo {PhotoId = d.PhotoID, PathPath = d.PhotoPath}).ToList();



            foreach (var ph in p)
            {
                ph.PathPath = ph.PathPath.Replace(@"~\Photo", @"../../Photo").Replace(@"\\", "/");
            }
            //foreach (var i in p)
                //{
                //    i.PathPath.Replace(oldValue: @"~\Photo", newValue: @"../../Photo");
                //    i.PathPath.Replace(oldValue: "Photo", newValue: "image");
                //}
            return Json( p, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PopulateDetails(int id)
        {
            var photoes = UnitofWork.MaintenancePhotoRepository.All.ToList();
            return Json(photoes, JsonRequestBehavior.AllowGet);
        }

        public ViewResult Json()
        {
            return View();
        }

        //public JsonResult PopulateDetails(int id)
        //{
        //    //userResultModel.LastName = user.LastName;
        //    //userResultModel.FirstName = user.FirstName;
        //    //userResultModel.Message = String.Empty; //success message is empty in this case

        //    MaintenancePhoto maintenancephoto = db.MaintenancePhotoes.Find(35);
        //   // IQueryable<MaintenancePhoto> maintenancephoto = db.MaintenancePhotoes.Where(o => o.MaintenanceID == 35);
        //    return Json(maintenancephoto, JsonRequestBehavior.AllowGet);
        //}



        //
        // GET: /MaintenancePhotoGallery/

       #endregion


        public ViewResult Index()
        {
            var maintenancephotoes = UnitofWork.MaintenancePhotoRepository.AllIncluding(m => m.MaintenanceOrder);
            return View(maintenancephotoes.ToList());
        }

        public ViewResult Details(int id)
        {
            var maintenancephoto = UnitofWork.MaintenancePhotoRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            return View(maintenancephoto);
        }

        public ActionResult Create()
        {
            ViewBag.MaintenanceID = new SelectList(UnitofWork.MaintenanceOrderRepository.All, "MaintenanceID", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MaintenancePhoto maintenancephoto)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.MaintenancePhotoRepository.Add(maintenancephoto);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.MaintenanceID = new SelectList(UnitofWork.MaintenanceOrderRepository.All, "MaintenanceID", "Description",
                                                   maintenancephoto.MaintenanceID);
            return View(maintenancephoto);
        }

        public ActionResult Edit(int id)
        {
            var maintenancephoto = UnitofWork.MaintenancePhotoRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            if (maintenancephoto == null) return null;
            ViewBag.MaintenanceID = new SelectList(UnitofWork.MaintenanceOrderRepository.All, "MaintenanceID", "Description",
                maintenancephoto.MaintenanceID);
            return View(maintenancephoto);
        }

        [HttpPost]
        public ActionResult Edit(MaintenancePhoto maintenancephoto)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.MaintenancePhotoRepository.Edit(maintenancephoto);
                UnitofWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.MaintenanceID = new SelectList(UnitofWork.MaintenanceOrderRepository.All, "MaintenanceID", "Description",
                                                   maintenancephoto.MaintenanceID);
            return View(maintenancephoto);
        }

        public ActionResult Delete(int id)
        {
            var maintenancephoto = UnitofWork.MaintenancePhotoRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            return View(maintenancephoto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var maintenancephoto = UnitofWork.MaintenancePhotoRepository.FindBy(x => x.MaintenanceID == id).FirstOrDefault();
            UnitofWork.MaintenancePhotoRepository.Delete(maintenancephoto);
            UnitofWork.Save();
            return RedirectToAction("Index", "TenantMaintenance");
        }

    }
}
