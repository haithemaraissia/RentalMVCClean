using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeaspnetWebEventEventss
    { 
       public List<aspnet_WebEvent_Events> MyaspnetWebEventEventss;

       public FakeaspnetWebEventEventss()
        {
            Initializeaspnet_WebEvent_EventsList();
        }

       public void Initializeaspnet_WebEvent_EventsList()
        {
            MyaspnetWebEventEventss = new List<aspnet_WebEvent_Events> {
                Firstaspnet_WebEvent_Events(), 
                Secondaspnet_WebEvent_Events(),
                Thirdaspnet_WebEvent_Events()
            };
        }

       public aspnet_WebEvent_Events Firstaspnet_WebEvent_Events()
        {

            var firstaspnetWebEventEvents = new aspnet_WebEvent_Events {

                 EventId = null,
                 EventTimeUtc = new DateTime()
,
                 EventTime = new DateTime()
,
                 EventType = null,
                 EventSequence = new Decimal()
,
                 EventOccurrence = new Decimal()
,
                 EventCode = new Int32()
,
                 EventDetailCode = new Int32()
,
                 Message = null,
                 ApplicationPath = null,
                 ApplicationVirtualPath = null,
                 MachineName = null,
                 RequestUrl = null,
                 ExceptionType = null,
                 Details = null
    
 };

            return firstaspnetWebEventEvents;
        }

       public aspnet_WebEvent_Events Secondaspnet_WebEvent_Events()
        {

            var secondaspnetWebEventEvents = new aspnet_WebEvent_Events {

                 EventId = null,
                 EventTimeUtc = new DateTime()
,
                 EventTime = new DateTime()
,
                 EventType = null,
                 EventSequence = new Decimal()
,
                 EventOccurrence = new Decimal()
,
                 EventCode = new Int32()
,
                 EventDetailCode = new Int32()
,
                 Message = null,
                 ApplicationPath = null,
                 ApplicationVirtualPath = null,
                 MachineName = null,
                 RequestUrl = null,
                 ExceptionType = null,
                 Details = null
        
 };

            return secondaspnetWebEventEvents;
        }

       public aspnet_WebEvent_Events Thirdaspnet_WebEvent_Events()
        {

            var thirdaspnetWebEventEvents = new aspnet_WebEvent_Events {

                 EventId = null,
                 EventTimeUtc = new DateTime()
,
                 EventTime = new DateTime()
,
                 EventType = null,
                 EventSequence = new Decimal()
,
                 EventOccurrence = new Decimal()
,
                 EventCode = new Int32()
,
                 EventDetailCode = new Int32()
,
                 Message = null,
                 ApplicationPath = null,
                 ApplicationVirtualPath = null,
                 MachineName = null,
                 RequestUrl = null,
                 ExceptionType = null,
                 Details = null
 
 };

            return thirdaspnetWebEventEvents;
        }

        ~FakeaspnetWebEventEventss()
        {
            MyaspnetWebEventEventss = null;
        }
    }
}


    