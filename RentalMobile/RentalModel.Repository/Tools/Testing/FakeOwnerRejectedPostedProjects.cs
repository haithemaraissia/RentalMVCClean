using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerRejectedPostedProject
    { 
       public List<OwnerRejectedPostedProject> MyOwnerRejectedPostedProjects;

       public FakeOwnerRejectedPostedProject()
        {
            InitializeOwnerRejectedPostedProjectList();
        }

       public void InitializeOwnerRejectedPostedProjectList()
        {
            MyOwnerRejectedPostedProjects = new List<OwnerRejectedPostedProject> {
                FirstOwnerRejectedPostedProject(), 
                SecondOwnerRejectedPostedProject(),
                ThirdOwnerRejectedPostedProject()
            };
        }

       public OwnerRejectedPostedProject FirstOwnerRejectedPostedProject()
        {

            var firstOwnerRejectedPostedProject = new OwnerRejectedPostedProject {

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

            return firstOwnerRejectedPostedProject;
        }

       public OwnerRejectedPostedProject SecondOwnerRejectedPostedProject()
        {

            var secondOwnerRejectedPostedProject = new OwnerRejectedPostedProject {

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

            return secondOwnerRejectedPostedProject;
        }

       public OwnerRejectedPostedProject ThirdOwnerRejectedPostedProject()
        {

            var thirdOwnerRejectedPostedProject = new OwnerRejectedPostedProject {

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

            return thirdOwnerRejectedPostedProject;
        }

        ~FakeOwnerRejectedPostedProject()
        {
            MyOwnerRejectedPostedProjects = null;
        }
    }
}


    