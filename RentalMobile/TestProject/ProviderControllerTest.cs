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

            var teams = Db.MaintenanceTeamAssociations.
                           Where(x => x.MaintenanceProviderId == 2);


            var test2 = teams.ToList();
            Assert.AreEqual("5",teams.Count().ToString(CultureInfo.InvariantCulture));
        }
    }
}
