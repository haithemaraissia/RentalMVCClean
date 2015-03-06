using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeAgents
    { 
       public List<Agent> MyAgents;

       public FakeAgents()
        {
            InitializeAgentList();
        }

       public void InitializeAgentList()
        {
            MyAgents = new List<Agent> {
                FirstAgent(), 
                SecondAgent(),
                ThirdAgent()
            };
        }

       public Agent FirstAgent()
        {

            var firstAgent = new Agent {

                 AgentId = new Int32()
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 Video = null,
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
    
 };

            return firstAgent;
        }

       public Agent SecondAgent()
        {

            var secondAgent = new Agent {

                 AgentId = new Int32()
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 Video = null,
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
        
 };

            return secondAgent;
        }

       public Agent ThirdAgent()
        {

            var thirdAgent = new Agent {

                 AgentId = new Int32()
,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = null,
                 Country = null,
                 Region = null,
                 City = null,
                 Zip = null,
                 CountryCode = null,
                 Video = null,
                 YouTubeVideo = new Boolean(),
                 YouTubeVideoURL = null,
                 VimeoVideo = new Boolean(),
                 VimeoVideoURL = null
 
 };

            return thirdAgent;
        }

        ~FakeAgents()
        {
            MyAgents = null;
        }
    }
}


    