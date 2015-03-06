using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeAgentAcceptedPostedProjects
    { 
       public List<AgentAcceptedPostedProject> MyAgentAcceptedPostedProjects;

       public FakeAgentAcceptedPostedProjects()
        {
            InitializeAgentAcceptedPostedProjectList();
        }

       public void InitializeAgentAcceptedPostedProjectList()
        {
            MyAgentAcceptedPostedProjects = new List<AgentAcceptedPostedProject> {
                FirstAgentAcceptedPostedProject(), 
                SecondAgentAcceptedPostedProject(),
                ThirdAgentAcceptedPostedProject()
            };
        }

       public AgentAcceptedPostedProject FirstAgentAcceptedPostedProject()
        {

            var firstAgentAcceptedPostedProject = new AgentAcceptedPostedProject {

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

            return firstAgentAcceptedPostedProject;
        }

       public AgentAcceptedPostedProject SecondAgentAcceptedPostedProject()
        {

            var secondAgentAcceptedPostedProject = new AgentAcceptedPostedProject {

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

            return secondAgentAcceptedPostedProject;
        }

       public AgentAcceptedPostedProject ThirdAgentAcceptedPostedProject()
        {

            var thirdAgentAcceptedPostedProject = new AgentAcceptedPostedProject {

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

            return thirdAgentAcceptedPostedProject;
        }

        ~FakeAgentAcceptedPostedProjects()
        {
            MyAgentAcceptedPostedProjects = null;
        }
    }
}


    