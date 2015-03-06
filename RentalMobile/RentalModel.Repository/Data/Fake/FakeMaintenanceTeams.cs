using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceTeams
    { 
       public List<MaintenanceTeam> MyMaintenanceTeams;

       public FakeMaintenanceTeams()
        {
            InitializeMaintenanceTeamList();
        }

       public void InitializeMaintenanceTeamList()
        {
            MyMaintenanceTeams = new List<MaintenanceTeam> {
                FirstMaintenanceTeam(), 
                SecondMaintenanceTeam(),
                ThirdMaintenanceTeam()
            };
        }

       public MaintenanceTeam FirstMaintenanceTeam()
        {

            var firstMaintenanceTeam = new MaintenanceTeam {

                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()

    
 };

            return firstMaintenanceTeam;
        }

       public MaintenanceTeam SecondMaintenanceTeam()
        {

            var secondMaintenanceTeam = new MaintenanceTeam {

                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()

        
 };

            return secondMaintenanceTeam;
        }

       public MaintenanceTeam ThirdMaintenanceTeam()
        {

            var thirdMaintenanceTeam = new MaintenanceTeam {

                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()

 
 };

            return thirdMaintenanceTeam;
        }

        ~FakeMaintenanceTeams()
        {
            MyMaintenanceTeams = null;
        }
    }
}


    