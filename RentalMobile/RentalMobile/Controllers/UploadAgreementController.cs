using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class UploadAgreementController : Controller
    {



        //From HERE
        private readonly DB_33736_rentalEntities _db = new DB_33736_rentalEntities();


        public string TenantUsername = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();


        public string TenantPhotoPath = "~/Photo/Tenant/UploadedContract";
        public string OwnertPhotoPath = "~/Photo/Tenant/UploadedContract";


        public string RequestId;

        public ActionResult Index()
        {

            RequestId = TempData["Id"].ToString();
            ViewBag.UserName = TenantUsername;
            ViewBag.Type = "UploadedContract";
            ViewBag.Id = TempData["Id"].ToString();
            TempData["Id"] = RequestId;
            return View();
        }















        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SavePictures();
            return RedirectToAction("Index", "TenantMaintenance");
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
            var maintenancephoto = new MaintenancePhoto { MaintenanceID = maintenanceId, PhotoPath = photoPath };
            if (!ModelState.IsValid) return;
            _db.MaintenancePhotoes.Add(maintenancephoto);
            _db.SaveChanges();
        }

    }
}
