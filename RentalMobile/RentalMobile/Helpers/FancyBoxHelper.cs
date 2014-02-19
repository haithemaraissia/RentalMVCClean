using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalMobile.Models;

namespace RentalMobile.Helpers
{

    public static class FancyBox
    {
        private static DB_33736_rentalEntities db = new DB_33736_rentalEntities();

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
    }
}
