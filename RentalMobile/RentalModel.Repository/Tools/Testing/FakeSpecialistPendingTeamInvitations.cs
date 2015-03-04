using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeSpecialistPendingTeamInvitation
    { 
       public List<SpecialistPendingTeamInvitation> MySpecialistPendingTeamInvitations;

       public FakeSpecialistPendingTeamInvitation()
        {
            InitializeSpecialistPendingTeamInvitationList();
        }

       public void InitializeSpecialistPendingTeamInvitationList()
        {
            MySpecialistPendingTeamInvitations = new List<SpecialistPendingTeamInvitation> {
                FirstSpecialistPendingTeamInvitation(), 
                SecondSpecialistPendingTeamInvitation(),
                ThirdSpecialistPendingTeamInvitation()
            };
        }

       public SpecialistPendingTeamInvitation FirstSpecialistPendingTeamInvitation()
        {

            var firstSpecialistPendingTeamInvitation = new SpecialistPendingTeamInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()

    
 };

            return firstSpecialistPendingTeamInvitation;
        }

       public SpecialistPendingTeamInvitation SecondSpecialistPendingTeamInvitation()
        {

            var secondSpecialistPendingTeamInvitation = new SpecialistPendingTeamInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()

        
 };

            return secondSpecialistPendingTeamInvitation;
        }

       public SpecialistPendingTeamInvitation ThirdSpecialistPendingTeamInvitation()
        {

            var thirdSpecialistPendingTeamInvitation = new SpecialistPendingTeamInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()

 
 };

            return thirdSpecialistPendingTeamInvitation;
        }

        ~FakeSpecialistPendingTeamInvitation()
        {
            MySpecialistPendingTeamInvitations = null;
        }
    }
}


    