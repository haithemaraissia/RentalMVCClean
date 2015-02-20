using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalMobile.Model.Models;
using RentalMobile.Models;

namespace TestProject.Controller
{
    [TestClass]
    public class ProviderControllerTest
    {
        public RentalContext Db = new RentalContext();

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
            Assert.AreEqual("2", maintenanceteamassocation.Count().ToString(CultureInfo.InvariantCulture));
        }
    }
}
