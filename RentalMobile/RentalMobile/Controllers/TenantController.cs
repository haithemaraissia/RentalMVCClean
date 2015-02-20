﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Controllers
{ 
    [Authorize]
    public class TenantController : Controller
    {

        public RentalContext db = new RentalContext();

        //
        // GET: /Tenant/
        //GET: CurrentTenant

        public ViewResult Index()
        {
            var tenant = db.Tenants.Find(UserHelper.GetTenantId());
            ViewBag.TenantProfile = tenant;
            ViewBag.TenantId = tenant.TenantId;
            ViewBag.TenantGoogleMap = tenant.GoogleMap;
            ViewBag.tenantApplicationCount  =   db.RentalApplications.Where(t => t.TenantId == tenant.TenantId).Count();
            return View(tenant);
        }


        // GET: /Tenant/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            return View(tenant);
        }

        //
        // POST: /Tenant/Edit/5

        [HttpPost]
        public ActionResult Edit(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }


        //
        // GET: /Tenant/Edit/5

        public ActionResult ChangeAddress(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            return View(tenant);
        }

        //
        // POST: /Tenant/Edit/5

        [HttpPost]
        public ActionResult ChangeAddress(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                tenant.GoogleMap = string.IsNullOrEmpty(tenant.Address) ? UserHelper.GetFormattedLocation("", "", "USA") : UserHelper.GetFormattedLocation(tenant.Address, tenant.City, tenant.CountryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        //
        // GET: /Tenant/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            return View(tenant);
        }

        //
        // POST: /Tenant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tenant tenant = db.Tenants.Find(id);
            db.Tenants.Remove(tenant);
            db.SaveChanges();



            // Delete All associated records

            var tenantshowing = db.TenantShowings.Where(x => x.TenantId == id).ToList();
            foreach (var x in tenantshowing)
            {
                db.TenantShowings.Remove(x);
            }
            db.SaveChanges();


        

            //Delete from Membership

            if (Roles.GetRolesForUser(User.Identity.Name).Any())
            {
                Roles.RemoveUserFromRoles(User.Identity.Name, Roles.GetRolesForUser(User.Identity.Name));
            }
            Membership.DeleteUser(User.Identity.Name);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index","Home");
        }


        public ActionResult UpdateProfilePicture(int id)
        {
            return RedirectToAction("Upload","Account",new {id});
        }


        //DETAIL OF TENANT FAVORITE

        //public PartialViewResult FavoriteDetails(int id)
        //{

        //    var tenantfavorite =  db.TenantFavorites.Where(x => x.TenantId == 2 && x.FavoriteId == id).FirstOrDefault();
        //    //Tenant tenant = db.TenantFavorites.Where(Tenant == 6 && )
        //    return PartialView("_TenantFavDetail",tenantfavorite);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }







        public ViewResult GeneratedRentalAgreement()
        {
            if (UserHelper.GetTenantId() != null)
            {
                var id = UserHelper.GetTenantId();
                if (id != null)
                {
                    var tenantId = (int)id;

                    var result = db.GeneratedRentalContracts.Count(x => x.TenantID == tenantId);
                    if (result != 0)
                    {
                        return View(db.GeneratedRentalContracts.Where(x => x.TenantID == UserHelper.GetTenantId()).ToList());
                    }
                }
            }

            return db.GeneratedRentalContracts != null ? View(db.GeneratedRentalContracts.ToList()) : null;
        }
    }
}