using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class Fakeaspnet_WebEvent_Eventss
    { 
       public List<aspnet_WebEvent_Events> Myaspnet_WebEvent_Eventss;

       public Fakeaspnet_WebEvent_Eventss()
        {
            Initializeaspnet_WebEvent_EventsList();
        }

       public void Initializeaspnet_WebEvent_EventsList()
        {
            Myaspnet_WebEvent_Eventss = new List<aspnet_WebEvent_Events> {
                Firstaspnet_WebEvent_Events(), 
                Secondaspnet_WebEvent_Events(),
                Thirdaspnet_WebEvent_Events()
            };
        }

       public aspnet_WebEvent_Events Firstaspnet_WebEvent_Events()
        {

            var firstaspnet_WebEvent_Events = new aspnet_WebEvent_Events {

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

            return firstaspnet_WebEvent_Events;
        }

       public aspnet_WebEvent_Events Secondaspnet_WebEvent_Events()
        {

            var secondaspnet_WebEvent_Events = new aspnet_WebEvent_Events {

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

            return secondaspnet_WebEvent_Events;
        }

       public aspnet_WebEvent_Events Thirdaspnet_WebEvent_Events()
        {

            var thirdaspnet_WebEvent_Events = new aspnet_WebEvent_Events {

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

            return thirdaspnet_WebEvent_Events;
        }

        ~Fakeaspnet_WebEvent_Eventss()
        {
            Myaspnet_WebEvent_Eventss = null;
        }
    }
}


    