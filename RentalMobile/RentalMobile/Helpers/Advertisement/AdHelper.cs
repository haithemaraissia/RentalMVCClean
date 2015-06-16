

namespace RentalMobile.Helpers
{
    public static class Advertisement
    {


        public static string MiddleBanner(string positionid, string sectionId)
        {
            string keyword;
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
            keyword = "test";
            return keyword;
        }

    }
}