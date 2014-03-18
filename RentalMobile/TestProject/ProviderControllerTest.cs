using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Models;

namespace TestProject
{
    [TestClass]
    public class ProviderControllerTest
    {
        public DB_33736_rentalEntities Db = new DB_33736_rentalEntities();

        [TestMethod]
        public void TestMethod1()
        {
            //You get the TeamName and TeamID if you want
            var maintenanceteamassocation = Db.MaintenanceTeamAssociations.
                           Where(x => x.MaintenanceProviderId == 2);



           //You get all specialist where TeamID = whatever and MaintenanceProvider is whateverif you want
            var maintenanceteams = Db.MaintenanceTeams.
                           Where(x => x.MaintenanceProviderId == 2);


            //for testing skill, try to test the group by caluse in linq

            var test2 = maintenanceteamassocation.ToList();
            Assert.AreEqual("5", maintenanceteamassocation.Count().ToString(CultureInfo.InvariantCulture));
        }
    }
}
