using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerPendingPostedProjects
    { 
       public List<OwnerPendingPostedProject> MyOwnerPendingPostedProjects;

       public FakeOwnerPendingPostedProjects()
        {
            InitializeOwnerPendingPostedProjectList();
        }

       public void InitializeOwnerPendingPostedProjectList()
        {
            MyOwnerPendingPostedProjects = new List<OwnerPendingPostedProject> {
                FirstOwnerPendingPostedProject(), 
                SecondOwnerPendingPostedProject(),
                ThirdOwnerPendingPostedProject()
            };
        }

       public OwnerPendingPostedProject FirstOwnerPendingPostedProject()
        {

            var firstOwnerPendingPostedProject = new OwnerPendingPostedProject {

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

            return firstOwnerPendingPostedProject;
        }

       public OwnerPendingPostedProject SecondOwnerPendingPostedProject()
        {

            var secondOwnerPendingPostedProject = new OwnerPendingPostedProject {

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

            return secondOwnerPendingPostedProject;
        }

       public OwnerPendingPostedProject ThirdOwnerPendingPostedProject()
        {

            var thirdOwnerPendingPostedProject = new OwnerPendingPostedProject {

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

            return thirdOwnerPendingPostedProject;
        }

        ~FakeOwnerPendingPostedProjects()
        {
            MyOwnerPendingPostedProjects = null;
        }
    }
}


    