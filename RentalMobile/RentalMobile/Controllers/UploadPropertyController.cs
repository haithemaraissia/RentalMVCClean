using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    [Authorize]
    public class UploadPropertyController : Controller
    {

            private readonly RentalContext _db = new RentalContext();
            public string TenantUsername = "TEST1";
            public string TenantPhotoPath = "~/Photo/Tenant/Requests";
            public string RequestID;

            public ActionResult Index()
            {
                RequestID = TempData["Id"].ToString();
                //ViewBag.UserName = TenantUsername;

                ViewBag.UserName = "test";
                ViewBag.Id = TempData["Id"].ToString();
                ViewBag.Type = "Requests";
                TempData["Id"] = RequestID;
                return View();
            }

            [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                SavePictures();
                return RedirectToAction("Index", "MaintenanceOrder");
            }

            public void SavePictures()
            {
                var imageStoragePath = Server.MapPath("~/UploadedImages");
                var photoPath = Server.MapPath(TenantPhotoPath);
                var directory = @"\" + TenantUsername + @"\" + "Requests" + @"\" + TempData["Id"] + @"\";
                var path = imageStoragePath + directory;
                var uploadDirectory = new DirectoryInfo(path);
                var newdirectory = photoPath + directory;
                if (Directory.Exists(path))
                {
                    UploadHelper.CreateDirectoryIfNotExist(newdirectory);
                }
                var files = uploadDirectory.GetFiles();

                foreach (var f in files)
                {
                    var destinationFile = newdirectory + @"\" + f.Name;
                    var virtualdestinationFile = @"~\Photo\Tenant\Requests" + directory + f.Name;
                    if (!System.IO.File.Exists(destinationFile))
                    {
                        System.IO.File.Move(f.FullName, destinationFile);
                        AddPicture(Convert.ToInt32(TempData["Id"]), virtualdestinationFile);
                    }
                    if (System.IO.File.Exists(f.Name))
                        System.IO.File.Delete(f.Name);
                }
                UploadHelper.DeleteDirectoryIfExist(path);
            }

            public void AddPicture(int maintenanceId, string photoPath)
            {
                var maintenancephoto = new MaintenancePhoto {MaintenanceID = maintenanceId, PhotoPath = photoPath};
                if (!ModelState.IsValid) return;
                _db.MaintenancePhotoes.Add(maintenancephoto);
                _db.SaveChanges();
            }





            public ActionResult GetPhoto()
            {

                //RequestID = TempData["Id"].ToString();
                //ViewBag.UserName = TenantUsername;
                //ViewBag.Id = TempData["Id"].ToString();
                //ViewBag.Type = "Requests";
                //TempData["Id"] = RequestID;




                RequestID = "5";
                ViewBag.UserName = "Test";
                ViewBag.Id = "10";
                ViewBag.Type = "Requests";
                TempData["Id"] = "5";
               return PartialView("_Test",_db.UnitGalleries.ToList());

            }
        }
    }
