using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RentalMobile.Handler
{
    /// <summary>
    /// Summary description for AdHandler
    /// </summary>
    public class AdHandler : IHttpHandler, IRequiresSessionState
    {
          //var strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"];
        //string conString = strConnString.ConnectionString;


        string conString = ConfigurationManager.ConnectionStrings["AdDatabaseConnectionString1"].ConnectionString;


       // private const string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\AdDatabase.mdf;Integrated Security=True;User Instance=True";

        public void ProcessRequest(HttpContext context)
        {
            int AdId = Int32.Parse(context.Request["Id"]);

            SqlConnection con = new SqlConnection(conString);
            string navigateUrl = string.Empty;
            using (con)
            {
                con.Open();
                UpdateTransferStats(AdId, con);
                navigateUrl = GetNavigateUrl(AdId, con);
            }

            if (!string.IsNullOrEmpty(navigateUrl))
            {
                context.Response.Redirect(navigateUrl);
            }
        }
        public void UpdateTransferStats(int advertisementId, SqlConnection con)
        {
            //string cmdText = "INSERT AdStats (AdId, EntryDate, Type) VALUES " + "(@AdId, GetDate(), 1)";
            //SqlCommand cmd = new SqlCommand(cmdText, con);
            //cmd.Parameters.AddWithValue("@AdId", advertisementId);
            ////cmd.Parameters.AddWithValue("@UserId", 100);
            ////cmd.Parameters.AddWithValue("@UserRole", "PRO");
            //cmd.ExecuteNonQuery();


          //  UpdateImpression(e.AdProperties["Id"].ToString(), 0);
            UpdateClick(advertisementId.ToString(CultureInfo.InvariantCulture), 1);


        }
        public string GetNavigateUrl(int advertisementId, SqlConnection con)
        {
            string cmdText = "SELECT NavigateUrl FROM AdGeneral WHERE Id=@AdId";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.Parameters.AddWithValue("@AdId", advertisementId);
            //cmd.Parameters.AddWithValue("@UserId", 100);
            //cmd.Parameters.AddWithValue("@UserRole", "PRO");
            return cmd.ExecuteScalar().ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void UpdateClick(string adId, int type)
        {
            //    try
            //    {
            //        // Full path to GeoLiteCity.dat file
            //        string fullDBPath = HttpContext.Current.Server.MapPath("~/App_Data/GeoLiteCity.dat");

            //        // Visitor's IP address
            //        string visitorIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            //        // Create objects needed for geo targeting
            //        var ls = new Geotargeting.LookupService(fullDBPath, Geotargeting.LookupService.GEOIP_STANDARD);

            //        //Geotargeting.Location visitorLocation = ls.getLocation(VisitorIP);
            //        //testing
            //        var visitorLocation = ls.getLocation("68.70.88.2");

            //        var myWebVisitor = new WebsiteVisitor(HttpContext.Current);

            //        //YOU Need to account for NULL AND FOR LOWER CASE!!!!!!!!!!!!!!///////////////
            //        //YOU Need to account for NULL AND FOR LOWER CASE!!!!!!!!!!!!!!///////////////

            //        int countryID;
            //        int regionID;
            //        int cityID;
            //        using (var context = new SidejobEntities())
            //        {
            //            try
            //            {
            //                var selectedCountryID =
            //                    from c in context.CountriesUpdates
            //                    where c.ISO2 == visitorLocation.countryCode
            //                    select c.CountryId;

            //                countryID = selectedCountryID.FirstOrDefault();
            //                if (countryID == 0)
            //                {
            //                    //Default: US
            //                    countryID = 254;
            //                }

            //                var selectedRegionID =
            //                    from c in context.regionsUpdates
            //                    where c.Code == visitorLocation.region && c.CountryId == Convert.ToInt32(selectedCountryID)
            //                    select c.RegionId;
            //                regionID = Convert.ToInt32(selectedRegionID);
            //                if (regionID == 0)
            //                {
            //                    //Default: NY
            //                    regionID = 154;
            //                }

            //                var selectedCityID =
            //                    from c in context.CitiesUpdates
            //                    where c.City == visitorLocation.city
            //                    select c.CityId;
            //                cityID = Convert.ToInt32(selectedCityID);
            //                if (cityID == 0)
            //                {
            //                    //Default: NY
            //                    cityID = 10182;
            //                }
            //            }
            //            catch (Exception)
            //            {
            //                //Default: US
            //                countryID = 254;

            //                //Default: NY
            //                regionID = 154;

            //                //Default: NY
            //                cityID = 10182;
            //            }
            //        }

            //        ///////////////
            //        string refURL = "Exception";
            //        ///////////////

            //        ImpressionUtility.UpdateClickTrack(Convert.ToInt32(adId),Convert.ToDateTime(DateTime.Today.ToString(CultureInfo.InvariantCulture)),
            //                                           type, visitorIP, visitorLocation.countryCode,
            //                                           visitorLocation.region,
            //                                           visitorLocation.postalCode,
            //                                           visitorLocation.area_code, visitorLocation.dma_code,
            //                                           visitorLocation.latitude,
            //                                           visitorLocation.longitude,
            //                                           refURL, myWebVisitor.BrowserType,
            //                                           myWebVisitor.BrowserName,
            //                                           myWebVisitor.BrowserPlatform,
            //                                           myWebVisitor.UserHostAddress,
            //                                           myWebVisitor.UserHostName,
            //                                           myWebVisitor.UserLanguages,
            //                                           myWebVisitor.MobileDeviceManufacturer,
            //                                           myWebVisitor.MobileDeviceModel,
            //                                           myWebVisitor.DeviceType,
            //                                           UserImpression.ImpressionUserID,
            //                                           UserImpression.ImpressionUserRole, 
            //                                           UserImpression.ImpressionFirstName,
            //                                           UserImpression.ImpressionLastName, 
            //                                           UserImpression.ImpressionAddress, 
            //                                           countryID,
            //                                           visitorLocation.countryCode,
            //                                           regionID, 
            //                                           visitorLocation.region, 
            //                                           cityID,
            //                                           visitorLocation.city,
            //                                           UserImpression.ImpressionPhone, 
            //                                           UserImpression.ImpressionAge,
            //                                           UserImpression.ImpressionGender, 
            //                                           UserImpression.ImpressionEmailAddress,
            //                                           UserImpression.ImpressionPhotoPath, 
            //                                           UserImpression.ImpressionIndustryID,
            //                                           UserImpression.ImpressionProfession, 
            //                                           UserImpression.ImpressionLCID);


            //        //// UpdateImpression(int adId, DateTime entryData, int type, string iPAddress, string countryCode, string region, string postalcode,
            //        //int areaCode, int metroCode, double latiture, double longitude, string refURL, string browserType, string browserName, string browserPlatform,  string userHostAddress,
            //        //string userHostName,
            //        //string userLanguage,string mobileDeviceManufacturer,
            //        // string mobileDeviceModel, string deviceType,  int userId, string userRole, string firstName,
            //        //string lastName, string address, int countryID, string countryName, int regionID,
            //        //string regionName, int cityID, string cityName, string phone, int age, int gender,
            //        //string emailAddress, string photoPath, int industryID, int professionID, int lcid)
            //    }
            //    catch (Exception)
            //    {
            //    }
            //
        }
    }
    }
