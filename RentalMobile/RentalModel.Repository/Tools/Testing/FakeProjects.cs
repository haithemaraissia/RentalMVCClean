using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProject
    { 
       public List<Project> MyProjects;

       public FakeProject()
        {
            InitializeProjectList();
        }

       public void InitializeProjectList()
        {
            MyProjects = new List<Project> {
                FirstProject(), 
                SecondProject(),
                ThirdProject()
            };
        }

       public Project FirstProject()
        {

            var firstProject = new Project {

                 ProjectID = new Int32()
,
                 ServiceTypeID = new Int32()
,
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 DaysOnSite = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32()
    
 };

            return firstProject;
        }

       public Project SecondProject()
        {

            var secondProject = new Project {

                 ProjectID = new Int32()
,
                 ServiceTypeID = new Int32()
,
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 DaysOnSite = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32()
        
 };

            return secondProject;
        }

       public Project ThirdProject()
        {

            var thirdProject = new Project {

                 ProjectID = new Int32()
,
                 ServiceTypeID = new Int32()
,
                 Description = null,
                 PrimaryPhoto = null,
                 Address = null,
                 GoogleMap = null,
                 Country = null,
                 State = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 NumberofPhoto = new Int32(),
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 DaysOnSite = new Int32(),
                 AvailableDate = new DateTime(),
                 PosterRole = null,
                 PosterID = new Int32()
 
 };

            return thirdProject;
        }

        ~FakeProject()
        {
            MyProjects = null;
        }
    }
}


    