using System;
using System.Collections.Generic;
using System.Globalization;
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


        public string OwnerUsername = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();


        public string TenantPhotoPath = "~/Photo/Tenant/UploadedContract";
        public string OwnertPhotoPath = "~/Photo/Owner/UploadedContract";


        public string RequestId;

        public ActionResult Index()
        {
            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetTenantID();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetOwnerID();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetAgentID();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetSpecialistID();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderID();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetProviderID();
            }

            return View();
        }


        public string GetCurrentRole()
        {
            var user = System.Web.HttpContext.Current.User;
            if (user.IsInRole("Tenant"))
            {
                return "Tenant";
            }
            if (user.IsInRole("Owner"))
            {
                return "Owner";
            }
            if (user.IsInRole("Agent"))
            {
                return "Agent";
            }
            if (user.IsInRole("Provider"))
            {
                return "Provider";
            }
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }

















        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SavePictures();
            return RedirectToAction("UploadedAgreement", "Owner");
        }

        public void SavePictures()
        {
            var imageStoragePath = Server.MapPath("~/UploadedImages");
            var photoPath = Server.MapPath(OwnertPhotoPath);
            var directory = @"\" + OwnerUsername + @"\" + "UploadedContract" + @"\" + TempData["UserID"] + @"\";
             var path = imageStoragePath + directory;
            var uploadDirectory = new DirectoryInfo(path);

            var files = uploadDirectory.GetFiles();
            
            directory = @"\" + OwnerUsername + @"\" + TempData["UserID"] + @"\";
            var newdirectory = photoPath + directory;
            if (Directory.Exists(path))
            {
                UploadHelper.CreateDirectoryIfNotExist(newdirectory);
            }
            foreach (var f in files)
            {
                var destinationFile = newdirectory + @"\" + f.Name;
                var virtualdestinationFile = @"~\Photo\Owner\UploadedContract" + directory + f.Name;
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(f.FullName, destinationFile);
                    AddPicture(Convert.ToInt32(TempData["UserID"]), virtualdestinationFile);
                }
                if (System.IO.File.Exists(f.Name))
                    System.IO.File.Delete(f.Name);
            }
            UploadHelper.DeleteDirectoryIfExist(path);
        }

        public void AddPicture(int uploaderid, string photoPath)
        {

                var uploadedcontractphoto = new UploadedContract
                                                {
                                                    UploadedImagePath = photoPath,
                                                    UploaderId = uploaderid,
                                                    UploaderRole = "Owner"
                                                };
           
            if (!ModelState.IsValid) return;
            _db.UploadedContracts.Add(uploadedcontractphoto);
            _db.SaveChanges();
            
        }

    }
}
