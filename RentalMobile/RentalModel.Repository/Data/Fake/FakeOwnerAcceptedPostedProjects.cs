using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerAcceptedPostedProjects
    { 
       public List<OwnerAcceptedPostedProject> MyOwnerAcceptedPostedProjects;

       public FakeOwnerAcceptedPostedProjects()
        {
            InitializeOwnerAcceptedPostedProjectList();
        }

       public void InitializeOwnerAcceptedPostedProjectList()
        {
            MyOwnerAcceptedPostedProjects = new List<OwnerAcceptedPostedProject> {
                FirstOwnerAcceptedPostedProject(), 
                SecondOwnerAcceptedPostedProject(),
                ThirdOwnerAcceptedPostedProject()
            };
        }

       public OwnerAcceptedPostedProject FirstOwnerAcceptedPostedProject()
        {

            var firstOwnerAcceptedPostedProject = new OwnerAcceptedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 OwnerId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
    
 };

            return firstOwnerAcceptedPostedProject;
        }

       public OwnerAcceptedPostedProject SecondOwnerAcceptedPostedProject()
        {

            var secondOwnerAcceptedPostedProject = new OwnerAcceptedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 OwnerId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
        
 };

            return secondOwnerAcceptedPostedProject;
        }

       public OwnerAcceptedPostedProject ThirdOwnerAcceptedPostedProject()
        {

            var thirdOwnerAcceptedPostedProject = new OwnerAcceptedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 OwnerId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
 
 };

            return thirdOwnerAcceptedPostedProject;
        }

        ~FakeOwnerAcceptedPostedProjects()
        {
            MyOwnerAcceptedPostedProjects = null;
        }
    }
}


    