using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalMobile.WebForms.Ads
{
    public partial class AdTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //ADD THEM BACK ONCE YOU UNDERSTAND WHAT IS IT
           // Logic.ValidateUserImpression(); 
         ///   Logic.CurrentLcid = "1";


            //Testing
            //SideJob
                //section 1: ROS

            //Advertiser
                // Section 10: ROS
            TopBanner("1", "10");
            RightBanner("2", "10");
           

        }






        //After or Before testing, you need to make them global

        //protected void ValidateUserImpression()
        //{
        //    var user = Membership.GetUser();
        //    if (user == null)
        //    {
        //        UserImpression.NonAuthenticatedUserImpression();
        //    }
        //    else
        //    {
        //        if (HttpContext.Current.User.IsInRole("CUS"))
        //        {
        //            CustomerUserImpression();
        //        }
        //        else if (HttpContext.Current.User.IsInRole("PRO"))
        //        {
        //            ProfessionalUserImpression();
        //        }
        //        else if (HttpContext.Current.User.IsInRole("Advertiser"))
        //        {
        //            AdvertiserUserImpression();
        //        }
        //        else
        //        {
        //            UserImpression.NonAuthenticatedUserImpression();
        //        }
        //    }
        //}

        //protected void CustomerUserImpression()
        //{
        //    using (var context = new SidejobEntities())
        //    {
        //        var customer = (from c in context.CustomerGenerals
        //                        join cus in context.Customers
        //                            on c.CustomerID equals cus.CustomerID
        //                        where cus.UserID == Utility.GetUserID()
        //                        select c).FirstOrDefault();
        //        if (customer != null)
        //        {
        //            string city = customer.CityID != null
        //                              ? customer.CityID.Value.ToString(CultureInfo.InvariantCulture)
        //                              : "128";

        //            UserImpression.AuthenticatedUserImpression(customer.CustomerID, "CUS", customer.FirstName,
        //                                                       customer.LastName, customer.Address,
        //                                                       customer.HomePhoneNumber,
        //                                                       customer.Age.ToString(
        //                                                           CultureInfo.InvariantCulture),
        //                                                       customer.Gender, customer.EmailAddress,
        //                                                       customer.PhotoPath,
        //                                                       customer.CountryID.ToString(
        //                                                           CultureInfo.InvariantCulture),
        //                                                       customer.RegionID.ToString(
        //                                                           CultureInfo.InvariantCulture),
        //                                                       city, customer.Zipcode, 0, 0,
        //                                                       Convert.ToInt32(
        //                                                           GetCurrentLCID().ToString(
        //                                                               CultureInfo.InvariantCulture)));
        //        }
        //        else
        //        {
        //            UserImpression.NonAuthenticatedUserImpression();
        //        }
        //    }
        //}

        //protected void ProfessionalUserImpression()
        //{
        //    using (var context = new SidejobEntities())
        //    {
        //        var professional = (from p in context.ProfessionalGenerals
        //                            join pr in context.Professionals
        //                                on p.ProID equals pr.ProID
        //                            where pr.UserID == Utility.GetUserID()
        //                            select p).FirstOrDefault();
        //        if (professional != null)
        //        {
        //            string city = professional.CityID != null
        //                              ? professional.CityID.Value.ToString(CultureInfo.InvariantCulture)
        //                              : "128";

        //            UserImpression.AuthenticatedUserImpression(professional.ProID, "PRO", professional.FirstName,
        //                                                       professional.LastName, professional.Address,
        //                                                       professional.HomePhoneNumber,
        //                                                       professional.Age.ToString(CultureInfo.InvariantCulture),
        //                                                       professional.Gender, professional.EmailAddress,
        //                                                       professional.PhotoPath,
        //                                                       professional.CountryID.ToString(CultureInfo.InvariantCulture),
        //                                                       professional.RegionID.ToString(CultureInfo.InvariantCulture),
        //                                                       city, professional.Zipcode, 0, 0,
        //                                                       Convert.ToInt32(GetCurrentLCID().ToString(CultureInfo.InvariantCulture)));
        //        }
        //        else
        //        {
        //            UserImpression.NonAuthenticatedUserImpression();
        //        }
        //    }
        //}

        //protected void AdvertiserUserImpression()
        //{
        //    using (new SidejobEntities())
        //    {
        //        try
        //        {
        //            UserImpression.ImpressionUserID = Convert.ToInt32(GetNumericGuid());
        //            UserImpression.ImpressionUserRole = "Advertiser";
        //            UserImpression.ImpressionFirstName = Profile.FirstName == "null" ? Resources.Resource.Unkown : Profile.FirstName;
        //            UserImpression.ImpressionLastName = Profile.LastName == "null" ? Resources.Resource.Unkown : Profile.LastName;
        //            UserImpression.ImpressionAddress = Utility.GetAdvertiserLocation(Profile.City, Profile.Region, Profile.Country);
        //            UserImpression.ImpressionPhone = Profile.Cellphone == "null" ? Resources.Resource.Unkown : Profile.Cellphone;
        //            UserImpression.ImpressionAge = Profile.Age == null ? 25 : Convert.ToInt32(Profile.Age.ToString(CultureInfo.InvariantCulture));
        //            UserImpression.ImpressionGender = Profile.Gender == null ? 1 : Convert.ToInt32(Profile.Gender);
        //            UserImpression.ImpressionPhotoPath = Profile.Picture1 == "null" ? "http://www.haithem-araissia.com/WIP2/RightCleanSideJOB2008FromInetpub/CleanSIDEJOB2008/Images/Profile/unknowuser.png" : Profile.Picture1;
        //            UserImpression.ImpressionCountry = Profile.CountryID.ToString(CultureInfo.InvariantCulture);
        //            UserImpression.ImpressionRegion = Profile.RegionID.ToString(CultureInfo.InvariantCulture);
        //            UserImpression.ImpressionCity = Profile.CityID.ToString(CultureInfo.InvariantCulture);
        //            UserImpression.ImpressionZipcode = Profile.Zipcode == "null" ? "66203" : Profile.Zipcode;
        //            UserImpression.ImpressionIndustryID = Profile.Industry == null ? 1 : Convert.ToInt32(Profile.Industry);
        //            UserImpression.ImpressionProfession = Convert.ToInt32(Utility.CleanUpProfessionId(Profile.ProfessionID));
        //            UserImpression.ImpressionLCID = Convert.ToInt32(GetCurrentLCID().ToString(CultureInfo.InvariantCulture));
        //        }
        //        catch (Exception)
        //        {

        //            UserImpression.NonAuthenticatedUserImpression();
        //        }

        //    }
        //}

        //public static BigInteger GetNumericGuid()
        //{
        //    Guid? userID = Utility.GetUserID();
        //    if (userID != null) return new BigInteger(userID.Value.ToByteArray());
        //    var n = new BigInteger("0");
        //    return n;
        //}

        //After or Before testing, you need to make them global







        //Top Banner
        protected void TopBannerRotatorCreated(object sender, AdCreatedEventArgs e)
        {
            try
            {
                var fullDBPath = Server.MapPath("~/App_Data/GeoLiteCity.dat");
                // Visitor's IP address
                // var visitorIP = Request.ServerVariables["REMOTE_ADDR"];
                var visitorIP = "68.70.88.2";
                //ImpressionUtility.UpdateImpression(e.AdProperties["ID"].ToString(), 0, fullDBPath, visitorIP, Request.Url.ToString());
            }
            catch
            {
                Response.Redirect(Request.Url.ToString());
            }
            e.NavigateUrl = "~/Advertiser/AdHandler.ashx?id=" + e.AdProperties["ID"];
        }

        private void TopBanner(string positionid, string sectionId)
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
        }




        //Right Banner
        protected void RightBannerRotatorCreated(object sender, AdCreatedEventArgs e)
        {
            try
            {
                var fullDBPath = Server.MapPath("~/App_Data/GeoLiteCity.dat");
                // Visitor's IP address
                // var visitorIP = Request.ServerVariables["REMOTE_ADDR"];
                var visitorIP = "68.70.88.2";
             //   ImpressionUtility.UpdateImpression(e.AdProperties["ID"].ToString(), 0, fullDBPath, visitorIP, Request.Url.ToString());
            }
            catch
            {
                Response.Redirect(Request.Url.ToString());
            }
            e.NavigateUrl = "~/Advertiser/AdHandler.ashx?id=" + e.AdProperties["ID"];
        }

        private void RightBanner(string positionid, string sectionId)
        {
            string keyword;
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

    }
}