using System.Web.Mvc;

namespace RentalMobile.Controllers
{
    public class AdController : Controller
    {
        // Logic.ValidateUserImpression(); 
        // Logic.CurrentLcid = "1";


        // Testing
        // SideJob
        // section 1: ROS
        // Advertiser
        // Section 10: ROS

        public ActionResult MiddleBanner()
        {

            //This is where you logic is for provider,agent....
            MiddleBanner("1", "10");
            ViewBag.MiddleBannerKeywordFilter = "sdsd"; 
            return View();
        }




        private void MiddleBanner(string positionid, string sectionId)
        {
           // string keyword;
            //using (var context = new AdDatabaseModel.AdDatabaseEntities())
            //{
            //    var t = Utility.KeywordFiltering(positionid, sectionId,GetCurrentLCID());
            //    var queryKeywordFilter = (from k in context.AdGenerals
            //                              where k.Keyword == t
            //                              select k).ToList();
            //    keyword = queryKeywordFilter.Count == 0 ? Logic.GetDefaultTopKeyword(sectionId) : Utility.KeywordFiltering(positionid, sectionId, GetCurrentLCID());
            //}
            //TopBannerRotator.KeywordFilter = keyword;


            //ViewBag.TopBannerKeywordFilter = "sdsd";
        }
    }
}
