using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeAgentRejectedPostedProject
    { 
       public List<AgentRejectedPostedProject> MyAgentRejectedPostedProjects;

       public FakeAgentRejectedPostedProject()
        {
            InitializeAgentRejectedPostedProjectList();
        }

       public void InitializeAgentRejectedPostedProjectList()
        {
            MyAgentRejectedPostedProjects = new List<AgentRejectedPostedProject> {
                FirstAgentRejectedPostedProject(), 
                SecondAgentRejectedPostedProject(),
                ThirdAgentRejectedPostedProject()
            };
        }

       public AgentRejectedPostedProject FirstAgentRejectedPostedProject()
        {

            var firstAgentRejectedPostedProject = new AgentRejectedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 AgentId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
    
 };

            return firstAgentRejectedPostedProject;
        }

       public AgentRejectedPostedProject SecondAgentRejectedPostedProject()
        {

            var secondAgentRejectedPostedProject = new AgentRejectedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 AgentId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
        
 };

            return secondAgentRejectedPostedProject;
        }

       public AgentRejectedPostedProject ThirdAgentRejectedPostedProject()
        {

            var thirdAgentRejectedPostedProject = new AgentRejectedPostedProject {

                 ID = new Int32()
,
                 ProjectID = new Int32()
,
                 AgentId = new Int32(),
                 SpecialistId = new Int32(),
                 ServiceTypeID = new Int32()
,
                 Budget = new Double(),
                 Currency = null,
                 CurrencyCode = new Int32(),
                 Date = new DateTime()
 
 };

            return thirdAgentRejectedPostedProject;
        }

        ~FakeAgentRejectedPostedProject()
        {
            MyAgentRejectedPostedProjects = null;
        }
    }
}


    