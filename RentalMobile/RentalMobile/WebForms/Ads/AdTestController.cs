using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalMobile.Controllers
{
    public class AdTestController : Controller
    {
        //
        // GET: /AdTest/

        public ActionResult Index()
        {
            ViewBag.KeywordFilter = "sdsd";
            TopBanner("1", "10");
            RightBanner("2", "10");
            ViewBag.SomeValue = "1";
            return View();
        }









        //This how it should be 
                    //ADD THEM BACK ONCE YOU UNDERSTAND WHAT IS IT
           // Logic.ValidateUserImpression(); 
         ///   Logic.CurrentLcid = "1";


            //Testing
            //SideJob
                //section 1: ROS

            //Advertiser
                // Section 10: ROS


        public ActionResult Test()
        {
            ViewBag.KeywordFilter = "sdsd";
            TopBanner("1", "10");
            RightBanner("2", "10");
            return View();
        }



        private void TopBanner(string positionid, string sectionId)
        {
            //string keyword;
            //using (var context = new AdDatabaseModel.AdDatabaseEntities())
            //{
            //    var t = Utility.KeywordFiltering(positionid, sectionId, GetCurrentLCID());
            //    var queryKeywordFilter = (from k in context.AdGenerals
            //                              where k.Keyword == t
            //                              select k).ToList();
            //    keyword = queryKeywordFilter.Count == 0 ? Logic.GetDefaultTopKeyword(sectionId) : Utility.KeywordFiltering(positionid, sectionId, GetCurrentLCID());
            //}
            //TopBannerRotator.KeywordFilter = keyword;

            ViewBag.KeywordFilter = "sdsd";
        }



        private void RightBanner(string positionid, string sectionId)
        {
           // string keyword;
            //using (var context = new AdDatabaseModel.AdDatabaseEntities())
            //{
            //    var t = Utility.KeywordFiltering(positionid, sectionId, GetCurrentLCID());
            //    var queryKeywordFilter = (from k in context.AdGenerals
            //                              where k.Keyword == t
            //                              select k).ToList();
            //    keyword = queryKeywordFilter.Count == 0 ? Logic.GetDefaultRightKeyword(sectionId): Utility.KeywordFiltering(positionid, sectionId, GetCurrentLCID());
            //}
            //RightBannerRotator.KeywordFilter = keyword;
        }





























        public ActionResult AdTest()
        {
            ViewBag.KeywordFilter = "sdsd";
            TopBanner("1", "10");
            RightBanner("2", "10");
            ViewBag.SomeValue = "1";
            return View();
        }


    }
}
