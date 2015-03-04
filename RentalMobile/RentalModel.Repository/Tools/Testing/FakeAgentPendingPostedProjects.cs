using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeAgentPendingPostedProject
    { 
       public List<AgentPendingPostedProject> MyAgentPendingPostedProjects;

       public FakeAgentPendingPostedProject()
        {
            InitializeAgentPendingPostedProjectList();
        }

       public void InitializeAgentPendingPostedProjectList()
        {
            MyAgentPendingPostedProjects = new List<AgentPendingPostedProject> {
                FirstAgentPendingPostedProject(), 
                SecondAgentPendingPostedProject(),
                ThirdAgentPendingPostedProject()
            };
        }

       public AgentPendingPostedProject FirstAgentPendingPostedProject()
        {

            var firstAgentPendingPostedProject = new AgentPendingPostedProject {

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

            return firstAgentPendingPostedProject;
        }

       public AgentPendingPostedProject SecondAgentPendingPostedProject()
        {

            var secondAgentPendingPostedProject = new AgentPendingPostedProject {

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

            return secondAgentPendingPostedProject;
        }

       public AgentPendingPostedProject ThirdAgentPendingPostedProject()
        {

            var thirdAgentPendingPostedProject = new AgentPendingPostedProject {

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

            return thirdAgentPendingPostedProject;
        }

        ~FakeAgentPendingPostedProject()
        {
            MyAgentPendingPostedProjects = null;
        }
    }
}


    