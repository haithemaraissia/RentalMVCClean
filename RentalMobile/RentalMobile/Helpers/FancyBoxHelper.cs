using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalMobile.Model.Models;

namespace RentalMobile.Helpers
{

    public static class FancyBox
    {
        private static RentalContext db = new RentalContext();

        public static string FancyUnit(int id)
        {
            const string fancyBoxScriptBeginning = @" $.fancybox.open([";
            var unitGallery = db.UnitGalleries.Where(x => x.UnitId == id);
            if (unitGallery.Any())
            {
                 var tag = Enumerable.Aggregate(unitGallery, "",
                                           (current, u) => current + ("{href: '" + u.Path + "', title: '" + u.Caption + "'},"));

            tag = tag.Substring(0, tag.Length - 1) + @"], {
				    helpers: {
				        thumbs: {
				            width: 75,
			            height: 50
			        }
		    }
        			});";


            return fancyBoxScriptBeginning + tag;
            }
            return "";
        }

        public static string FancySpecialist(int id)
        {
            const string fancyBoxScriptBeginning = @" $.fancybox.open([";
            var currentspecialist = db.Specialists.FirstOrDefault(x => x.SpecialistId == id);
            if (currentspecialist != null)
            {
            var specialistWorkGallery = db.SpecialistWorks.Where(x => x.SpecialistId == id);
            if (specialistWorkGallery.Any())
            {
                var tag = Enumerable.Aggregate(specialistWorkGallery, "",
                                          (current, u) => current + ("{href: '" + u.PhotoPath + "', title: '" +  currentspecialist.FirstName + " " + currentspecialist.LastName +" work" + "'},"));

                tag = tag.Substring(0, tag.Length - 1) + @"], {
				    helpers: {
				        thumbs: {
				            width: 75,
			            height: 50
			        }
		    }
        			});";


                return fancyBoxScriptBeginning + tag;
            } 
            }
            return "";
        }



        public static string FancyProvider(int id)
        {
            const string fancyBoxScriptBeginning = @" $.fancybox.open([";
            var currentprovider = db.MaintenanceProviders.FirstOrDefault(x => x.MaintenanceProviderId == id);
            if (currentprovider != null)
            {
                var providerWorkGallery = db.ProviderWorks.Where(x => x.ProviderId == id);
                if (providerWorkGallery.Any())
                {
                    var tag = Enumerable.Aggregate(providerWorkGallery, "",
                                              (current, u) => current + ("{href: '" + u.PhotoPath + "', title: '" + currentprovider.FirstName + " " + currentprovider.LastName + " work" + "'},"));

                    tag = tag.Substring(0, tag.Length - 1) + @"], {
				    helpers: {
				        thumbs: {
				            width: 75,
			            height: 50
			        }
		    }
        			});";


                    return fancyBoxScriptBeginning + tag;
                }
            }
            return "";
        }
    }
}
