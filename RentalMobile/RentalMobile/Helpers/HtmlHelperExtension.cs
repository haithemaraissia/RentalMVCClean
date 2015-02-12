using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace RentalMobile.Helpers
{

    public static class HtmlHelperExtensions
    {

        public static RentalContext db = new RentalContext();

        public static string DefaultAvatarPlaceholderImagePath =
            "../../images/dotimages/avatar-placeholder.png";

        //       public static string RelativePath(this HtmlHelper helper, string photopath)
        //       {
        //return server.Content(item.PhotoPath)
        //       }

        public static IEnumerable<SelectListItem> GetRoles(this HtmlHelper helper)
        {
            return new[] {
                new SelectListItem { Text="Tenant" , Value="Tenant"},
                 new SelectListItem { Text="Owner" , Value="Owner"},
                  new SelectListItem { Text="Agent" , Value="Agent"},
                   new SelectListItem { Text="Maintenance Provider", Value="Provider" },
                   new SelectListItem { Text="Specialist" , Value="Specialist"},
            };
        }

        public static IEnumerable<SelectListItem> Currency(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Currencies.Select(c => new { c.CurrencyID, c.CurrencyValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "CurrencyID", "CurrencyValue", 0) : new SelectList(query.AsEnumerable(), "CurrencyID", "CurrencyValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Cooling(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Coolings.Select(c => new { c.CoolingID, c.CoolingValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "CoolingID", "CoolingValue", 0) : new SelectList(query.AsEnumerable(), "CoolingID", "CoolingValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Basement(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Basements.Select(c => new { c.BasementID, c.BasementValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "BasementID", "BasementValue", 0) : new SelectList(query.AsEnumerable(), "BasementID", "BasementValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Garage(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Garages.Select(c => new { c.GarageID, c.GarageValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "GarageID", "GarageValue", 0) : new SelectList(query.AsEnumerable(), "GarageID", "GarageValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Heating(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Heatings.Select(c => new { c.HeatingID, c.HeatingValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "HeatingID", "HeatingValue", 0) : new SelectList(query.AsEnumerable(), "HeatingID", "HeatingValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> UnitType(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.UnitTypes.Select(c => new { c.TypeID, c.TypeValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "TypeID", "TypeValue", 0) : new SelectList(query.AsEnumerable(), "TypeID", "TypeValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> ParkingSpace(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.ParkingSpaces.Select(c => new { c.ParkingID, c.ParkingValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "ParkingID", "ParkingValue", 0) : new SelectList(query.AsEnumerable(), "ParkingID", "ParkingValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Floor(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Floors.Select(c => new { c.FloorID, c.FloorValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "FloorID", "FloorValue", 0) : new SelectList(query.AsEnumerable(), "FloorID", "FloorValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> FloorCovering(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.FloorCoverings.Select(c => new { c.FloorID, c.FloorValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "FloorID", "FloorValue", 0) : new SelectList(query.AsEnumerable(), "FloorID", "FloorValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Foundation(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Foundations.Select(c => new { c.FoundationID, c.FoundationValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "FoundationID", "FoundationValue", 0) : new SelectList(query.AsEnumerable(), "FoundationID", "FoundationValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Bed(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Beds.Select(c => new { c.BedID, c.BedValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "BedID", "BedValue", 0) : new SelectList(query.AsEnumerable(), "BedID", "BedValue", selectedvalue);
        }

        public static IEnumerable<SelectListItem> Bathroom(this HtmlHelper helper, int? selectedvalue)
        {
            var query = db.Bathrooms.Select(c => new { c.BathroomID, c.BathroomValue });
            return selectedvalue == null ? new SelectList(query.AsEnumerable(), "BathroomID", "BathroomValue", 0) : new SelectList(query.AsEnumerable(), "BathroomID", "BathroomValue", selectedvalue);
        }

        public static string GetBooleanValue(this bool? b, string ifTrue, string ifFalse, string ifNull)
        {
            if (!b.HasValue) return ifNull;
            return b.Value ? ifTrue : ifFalse;
        }

        public static string GetCurrencyValue(this HtmlHelper helper, int? currencyID)
        {
            var currency = db.Currencies.FirstOrDefault(x => x.CurrencyID == currencyID);
            if (currency != null)
                return currency.CurrencyValue;
            return db.Currencies.First().CurrencyValue;
        }

        public static string GetBedValue(this HtmlHelper helper, int? selectedvalue)
        {
            if (selectedvalue == null) return "1";
            var bed = db.Beds.FirstOrDefault(x => x.BedID == selectedvalue);
            return bed != null ? bed.BedValue : "1";
        }

        public static string GetBathroomValue(this HtmlHelper helper, int? selectedvalue)
        {
            if (selectedvalue == null) return "1";
            var bathroom = db.Bathrooms.FirstOrDefault(x => x.BathroomID == selectedvalue);
            return bathroom != null ? bathroom.BathroomValue : "1";
        }

        public static string CountPhoto(this HtmlHelper helper, int? unitid)
        {
            return unitid == null ? "1" : db.UnitGalleries.Count(x => x.UnitId == unitid).ToString(CultureInfo.InvariantCulture);
        }

        public static string GetMaintenanceProviderPrimaryPhoto(this HtmlHelper helper, int? id)
        {
            var maintenanceProvider = db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (maintenanceProvider != null)
                return id == null ? " " : maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture);
            return "";
        }

        public static string GetUnitType(this HtmlHelper helper, int? selectedvalue)
        {
            if (selectedvalue == null) return "house";
            var Unit = db.UnitTypes.FirstOrDefault(x => x.TypeID == selectedvalue);
            return Unit != null ? Unit.TypeValue : "house";
        }

        /// <summary>
        /// Custom Label for the purpose of :
        /// new { @class= "SmallInput" })
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }
        
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
        
        public static HtmlString Label(this HtmlHelper helper, string target = "", string text = "", string id = "")
        {
            return new HtmlString(string.Format("<label id='{0}' for='{1}'>{2}</label>", id, target, text));
        }
        
        public static MvcHtmlString CustomHyperlink(this HtmlHelper helper, string linkText)
        {
            return MvcHtmlString.Create(String.Format("<a href='/{0}'>{1}</a>", GetCurrentRole(), linkText));
        }
        
        public static string GetCurrentRole()
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
            return user.IsInRole("Specialist") ? "Specialist" : null;
        }

        public static string GeVimeoVideoEmbeddedUrl(string vimeoVideoUrl)
        {
            return vimeoVideoUrl.ToLower().Replace("vimeo.com", "player.vimeo.com/video");
        }

        public static string GetYouTubeVideoEmbeddedUrl(string youTubeVideoUrl)
        {
            var youTubeUri = new Uri(youTubeVideoUrl);
            var query = HttpUtility.ParseQueryString(youTubeUri.Query);
            var youTubeQueryValue = query.Get("v");
            return "http://www.youtube.com/embed/" + youTubeQueryValue;
        }

        //public static string GetVideoEmbeddedUrl(this HtmlHelper helper, int? unitid)
        //{
        //    var uri = HttpContext.Current.Request.Url;
        //    var defaulturlreturn = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port + "/Html/NoVideo.htm";

        //    if (unitid == null) return defaulturlreturn;
        //    var unit = db.Units.FirstOrDefault(x => x.UnitId == unitid);
        //    if (unit == null) return defaulturlreturn;
        //    if (unit.YouTubeVideo != null && unit.YouTubeVideo.Value == true)
        //    {
        //        var youTubeUri = new Uri(unit.YouTubeVideoURL);
        //        var query = HttpUtility.ParseQueryString(youTubeUri.Query);
        //        var youTubeQueryValue = query.Get("v");
        //        return "http://www.youtube.com/embed/" + youTubeQueryValue;
        //    }
        //    if (unit.VimeoVideo != null && unit.VimeoVideo.Value == true)
        //    {

        //        return unit.VimeoVideoURL.ToLower().Replace("vimeo.com", "player.vimeo.com/video");
        //    }
        //    return defaulturlreturn;
        //}

        public static string TruncateLongString(this HtmlHelper helper, string str, int maxLength)
        {
            if (String.IsNullOrEmpty(str)) return "";
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string GetTeamPrimaryPhoto(this HtmlHelper helper, int? id)
        {
            var maintenanceProvider = db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (maintenanceProvider != null)
                return id == null ? DefaultAvatarPlaceholderImagePath : maintenanceProvider.Photo.ToString(CultureInfo.InvariantCulture);
            return DefaultAvatarPlaceholderImagePath;
        }

        public static MvcHtmlString GetSpecialistZone(this HtmlHelper html, int? specialistId)
        {
            var renderedResult = @"<ul class='arrow'>";
            if (specialistId != null)
            {
                var specialist = db.Specialists.FirstOrDefault(x => x.SpecialistId == specialistId);
                if (specialist != null)
                {
                    if (specialist.City != null)
                    {
                        renderedResult += "<li>";
                        renderedResult += specialist.City;
                        renderedResult += "</li>";
                    }
                }
                var companyLookUp =
                    db.MaintenanceCompanyLookUps.FirstOrDefault(x => x.UserId == specialistId && x.Role == 1);
                if (companyLookUp != null)
                {
                    var specialistcompany = db.MaintenanceCompanies.FirstOrDefault(x => x.CompanyId == companyLookUp.CompanyId);
                    if (specialistcompany != null)
                    {
                        if (specialist != null && (specialistcompany.City != null && specialist.City != specialistcompany.City))
                        {
                            renderedResult += "<li>";
                            renderedResult += specialistcompany.City;
                            renderedResult += "</li>";
                        }
                    }
                    renderedResult += "<li>";
                    if (specialistcompany != null && (specialist != null && (specialist.City == null && specialistcompany.City == null)))
                    {
                        renderedResult += "No Zone Available";
                    }
                    else
                    {
                        if (specialistcompany != null) renderedResult += specialistcompany.City;
                    }
                    renderedResult += "</li>";
                }

            }
            var resultString = new MvcHtmlString(renderedResult);
            return resultString;
        }










        public static MvcHtmlString GetMaintenanceProviderZone(this HtmlHelper html, int? maintenanceProviderId)
        {
            var renderedResult = @"<ul class='arrow'>";
            var providerZones = db.MaintenanceProviderZones.Where(x => x.MaintenanceProviderId == maintenanceProviderId).ToList();
            foreach (var maintenanceProviderZone in providerZones)
            {
                renderedResult += "<li>";
                renderedResult += maintenanceProviderZone.CityName;
                renderedResult += "</li>";
            }

            if (providerZones.Count == 0)
            {
                renderedResult += "<li>";
                renderedResult += "No Zone Available";
                renderedResult += "</li>";
            }
            renderedResult += "</ul>";
            var resultString = new MvcHtmlString(renderedResult);
            return resultString;
        }


   



        /// <summary>
        /// Used to return any html for Razor View
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>

        public static MvcHtmlString ReturnHtmlRaw(this HtmlHelper html)
        {
            var renderedResult = @"<html> Whatver </html>";
            renderedResult += "<Anything/>";
            return new MvcHtmlString(renderedResult);
        }
    }
}

