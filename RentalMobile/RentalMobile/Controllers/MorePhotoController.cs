using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{

    [Authorize]
    public class MorePhotoController : Controller
    {

        //Variables that should be queried with the request
        private RentalContext db = new RentalContext();

        public string TenantUsername = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();
        public string TenantPhotoPath = @"~/Photo/Tenant/Requests";
        public string RequestID;

        //
        // GET: /Upload/

        public ActionResult Index(int Id)
        {
            if (db.MaintenanceOrders.Find(Id) == null)
            {
                RedirectToAction("Index", "TenantMaintenance");
            }
            RequestID = Id.ToString(CultureInfo.InvariantCulture);
            ViewBag.TenantUserName = TenantUsername;
            ViewBag.RequestID = RequestID;
            TempData["RequestID"] = RequestID;
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
            var directory = @"\" + TenantUsername + @"\" + "Requests" + @"\" + TempData["RequestID"] + @"\";
            var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);
            var newdirectory = photoPath + directory;
            if (Directory.Exists(path))
            {

                CreateDirectoryIfNotExist(newdirectory);
            }

            var files = uploadDirectory.GetFiles();

            foreach (var f in files)
            {

                //This is what you need.
                var destinationFile = newdirectory + @"\" + f.Name;
                var virtualdestinationFile = @"~\Photo\Tenant\Requests" + directory + f.Name;
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(f.FullName, destinationFile);
                    AddPicture(Convert.ToInt32(TempData["RequestID"]), virtualdestinationFile);
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            DeleteDirectoryIfExist(path);
        }

        public void AddPicture(int maintenanceId, string photoPath)
        {
            var maintenancephoto = new MaintenancePhoto { MaintenanceID = maintenanceId, PhotoPath = photoPath };
            if (!ModelState.IsValid) return;
            db.MaintenancePhotoes.Add(maintenancephoto);
            db.SaveChanges();
        }

        /// <summary>
        /// Addition of Helper function to create and/or delete directory
        /// </summary>
        /// <param name="newDirectory"></param>
        private void CreateDirectoryIfNotExist(string newDirectory)
        {
            try
            {
                // Checking the existence of directory
                if (!Directory.Exists(newDirectory))
                {

                    //If No any such directory then creates the new one
                    Directory.CreateDirectory(newDirectory);
                }
            }
            catch (IOException err)
            {
                Response.Write(err.Message);
            }
        }
        private void DeleteDirectoryIfExist(string newDirectory)
        {
            try
            {
                // Checking the existence of directory
                if (Directory.Exists(newDirectory))
                {

                    string[] files = Directory.GetFiles(newDirectory);
                    foreach (string file in files)
                        System.IO.File.Delete(file);

                    Directory.Delete(newDirectory);
                }
            }
            catch (IOException err)
            {
                Response.Write(err.Message);
            }
        }
    }
}
