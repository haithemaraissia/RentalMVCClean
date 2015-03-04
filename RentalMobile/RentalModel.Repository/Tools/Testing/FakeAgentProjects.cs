using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeAgentProject
    { 
       public List<AgentProject> MyAgentProjects;

       public FakeAgentProject()
        {
            InitializeAgentProjectList();
        }

       public void InitializeAgentProjectList()
        {
            MyAgentProjects = new List<AgentProject> {
                FirstAgentProject(), 
                SecondAgentProject(),
                ThirdAgentProject()
            };
        }

       public AgentProject FirstAgentProject()
        {

            var firstAgentProject = new AgentProject {

                 AgentId = new Int32(),
                 ProjectID = new Int32()

    
 };

            return firstAgentProject;
        }

       public AgentProject SecondAgentProject()
        {

            var secondAgentProject = new AgentProject {

                 AgentId = new Int32(),
                 ProjectID = new Int32()

        
 };

            return secondAgentProject;
        }

       public AgentProject ThirdAgentProject()
        {

            var thirdAgentProject = new AgentProject {

                 AgentId = new Int32(),
                 ProjectID = new Int32()

 
 };

            return thirdAgentProject;
        }

        ~FakeAgentProject()
        {
            MyAgentProjects = null;
        }
    }
}


    