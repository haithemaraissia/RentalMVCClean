using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeMaintenanceTeamAssociations
    { 
       public List<MaintenanceTeamAssociation> MyMaintenanceTeamAssociations;

       public FakeMaintenanceTeamAssociations()
        {
            InitializeMaintenanceTeamAssociationList();
        }

       public void InitializeMaintenanceTeamAssociationList()
        {
            MyMaintenanceTeamAssociations = new List<MaintenanceTeamAssociation> {
                FirstMaintenanceTeamAssociation(), 
                SecondMaintenanceTeamAssociation(),
                ThirdMaintenanceTeamAssociation()
            };
        }

       public MaintenanceTeamAssociation FirstMaintenanceTeamAssociation()
        {

            var firstMaintenanceTeamAssociation = new MaintenanceTeamAssociation {

                 TeamAssociationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistId = new Int32()

    
 };

            return firstMaintenanceTeamAssociation;
        }

       public MaintenanceTeamAssociation SecondMaintenanceTeamAssociation()
        {

            var secondMaintenanceTeamAssociation = new MaintenanceTeamAssociation {

                 TeamAssociationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistId = new Int32()

        
 };

            return secondMaintenanceTeamAssociation;
        }

       public MaintenanceTeamAssociation ThirdMaintenanceTeamAssociation()
        {

            var thirdMaintenanceTeamAssociation = new MaintenanceTeamAssociation {

                 TeamAssociationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistId = new Int32()

 
 };

            return thirdMaintenanceTeamAssociation;
        }

        ~FakeMaintenanceTeamAssociations()
        {
            MyMaintenanceTeamAssociations = null;
        }
    }
}


    