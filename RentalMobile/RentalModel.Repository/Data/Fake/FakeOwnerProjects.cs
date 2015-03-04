using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeOwnerProject
    { 
       public List<OwnerProject> MyOwnerProjects;

       public FakeOwnerProject()
        {
            InitializeOwnerProjectList();
        }

       public void InitializeOwnerProjectList()
        {
            MyOwnerProjects = new List<OwnerProject> {
                FirstOwnerProject(), 
                SecondOwnerProject(),
                ThirdOwnerProject()
            };
        }

       public OwnerProject FirstOwnerProject()
        {

            var firstOwnerProject = new OwnerProject {

                 OwnerId = new Int32(),
                 ProjectID = new Int32()

    
 };

            return firstOwnerProject;
        }

       public OwnerProject SecondOwnerProject()
        {

            var secondOwnerProject = new OwnerProject {

                 OwnerId = new Int32(),
                 ProjectID = new Int32()

        
 };

            return secondOwnerProject;
        }

       public OwnerProject ThirdOwnerProject()
        {

            var thirdOwnerProject = new OwnerProject {

                 OwnerId = new Int32(),
                 ProjectID = new Int32()

 
 };

            return thirdOwnerProject;
        }

        ~FakeOwnerProject()
        {
            MyOwnerProjects = null;
        }
    }
}


    