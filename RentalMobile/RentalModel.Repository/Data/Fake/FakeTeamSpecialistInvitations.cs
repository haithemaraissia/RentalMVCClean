using System;
using System.Collections.Generic;
using RentalMobile.Model.ModelViews;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeTeamSpecialistInvitations
    { 
       public List<TeamSpecialistInvitation> MyTeamSpecialistInvitations;

       public FakeTeamSpecialistInvitations()
        {
            InitializeTeamSpecialistInvitationList();
        }

       public void InitializeTeamSpecialistInvitationList()
        {
            MyTeamSpecialistInvitations = new List<TeamSpecialistInvitation> {
                FirstTeamSpecialistInvitation(), 
                SecondTeamSpecialistInvitation(),
                ThirdTeamSpecialistInvitation()
            };
        }

       public TeamSpecialistInvitation FirstTeamSpecialistInvitation()
        {

            var firstTeamSpecialistInvitation = new TeamSpecialistInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()
,
                 SpecialistFirstName = null,
                 SpecialistLastName = null,
                 SpecialistAddress = null,
                 SpecialistRegion = null,
                 SpecialistCity = null,
                 SpecialistCountryCode = null,
                 SpecialistDescription = null,
                 SpecialistPhoto = null
         
 };

            return firstTeamSpecialistInvitation;
        }

       public TeamSpecialistInvitation SecondTeamSpecialistInvitation()
        {

            var secondTeamSpecialistInvitation = new TeamSpecialistInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()
,
                 SpecialistFirstName = null,
                 SpecialistLastName = null,
                 SpecialistAddress = null,
                 SpecialistRegion = null,
                 SpecialistCity = null,
                 SpecialistCountryCode = null,
                 SpecialistDescription = null,
                 SpecialistPhoto = null
        
 };

            return secondTeamSpecialistInvitation;
        }

       public TeamSpecialistInvitation ThirdTeamSpecialistInvitation()
        {

            var thirdTeamSpecialistInvitation = new TeamSpecialistInvitation {

                 PendingTeamInvitationID = new Int32()
,
                 TeamId = new Int32()
,
                 TeamName = null,
                 MaintenanceProviderId = new Int32()
,
                 SpecialistID = new Int32()
,
                 SpecialistFirstName = null,
                 SpecialistLastName = null,
                 SpecialistAddress = null,
                 SpecialistRegion = null,
                 SpecialistCity = null,
                 SpecialistCountryCode = null,
                 SpecialistDescription = null,
                 SpecialistPhoto = null
 
 };

            return thirdTeamSpecialistInvitation;
        }

        ~FakeTeamSpecialistInvitations()
        {
            MyTeamSpecialistInvitations = null;
        }
    }
}

    