using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{
    public class UploadAgreementController : Controller
    {
        //From HERE
        private readonly RentalContext _db = new RentalContext();


        public string OwnerUsername = Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name).ToString();


        public string TenantPhotoPath = "~/Photo/Tenant/UploadedContract";
        public string OwnertPhotoPath = "~/Photo/Owner/UploadedContract";


        public string RequestId;

        public ActionResult Index()
        {
            var role = GetCurrentRole();
            if (role == "Tenant")
            {
                ViewBag.Id = UserHelper.GetTenantId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetTenantId();
            }

            if (role == "Owner")
            {
                ViewBag.Id = UserHelper.GetOwnerId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetOwnerId();
            }

            if (role == "Agent")
            {
                ViewBag.Id = UserHelper.GetAgentId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetAgentId();
            }

            if (role == "Specialist")
            {
                ViewBag.Id = UserHelper.GetSpecialistId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetSpecialistId();
            }
            if (role == "Provider")
            {
                ViewBag.Id = UserHelper.GetProviderId();
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.Type = "UploadedContract";
                TempData["UserID"] = UserHelper.GetProviderId();
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
