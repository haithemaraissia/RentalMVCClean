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
                 AgentId = 1,
                 FirstName = null,
                 LastName = null,
                 Address = null,
                 EmailAddress = null,
                 Description = null,
                 GUID = new Guid("dddddddd-dddd-dddd-1234-dddddddddddd"),
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

                 AgentId = 2
,
                 FirstName = "Sammy Agent",
                 LastName = "Douglas",
                 Address = "11125 NorthEast Boulevard, California 552441",
                 EmailAddress = "mikedouglas@yhaoo.com",
                 Description = "Mike Description",
                 GUID = new Guid()
,
                 VCard = null,
                 Skype = null,
                 Twitter = null,
                 LinkedIn = null,
                 GooglePlus = null,
                 Photo = null,
                 GoogleMap = "Google Address",
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


    