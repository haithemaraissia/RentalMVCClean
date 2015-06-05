using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalMobile.Helpers.Identity.Base;

namespace RentalMobile.Helpers
{
    public  class JNotfiyScriptQueryHelper
    {
        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
        /// <summary>
        /// Parameterized JNotify Function
        /// </summary>
        /// <param name="successmessage"></param>
        /// <param name="navigateturlwhencompleted"></param>
        /// <returns></returns>

        
        public  string JNotifyConfirmationMessage(string successmessage, string navigateturlwhencompleted)
        {

            var jNotifyConfirmationScript = @"jSuccess('" + successmessage
                                            +
                                            @"',{
	                            autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                    ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
                                window.location.href = '" + navigateturlwhencompleted + @"' }});";
            return jNotifyConfirmationScript;
        }


        public  string JNotifyConfirmationSharingEmail()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your email has been sent successfully.")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
	  	                        
	  	                          window.location.href = location.href.replace('?sharespecialist=True','#send-to-friend'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }

        public  string JNotifyConfirmationSuccessComment()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your comment have been successfully inserted.")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
	  	                        
	  	                          window.location.href = location.href.replace('?insertingnewcomment=True','#comments'); 
	   
	  	                }
		             });

";
            return jNotifyConfirmationScript;
        }

        public string JNotifyConfirmationUpdatingVideo()
        {
            var jNotifyConfirmationScript =
                                string.Format(@"jSuccess('Your video has been sent successfully updated.")
                                 +
                                @"',{
	                            autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	  	                        },
	  	                        onCompleted : function(){ // added in v2.0
	  	                        window.location.href = "
                               + string.Format(@"'../{0}'", new UserIdentity().GetCurrentRole()) + @"; }});";
            return jNotifyConfirmationScript;
        }


        public string JNotifyShowingAppointmentConfirmation()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your appointement confirmation was successful.")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                         onCompleted : function(){ // added in v2.0
	  	                        

	   
	  	                }
		             });

                    ";
            return jNotifyConfirmationScript;
        
        }


        public string JNotifySocialConfirmation(string socialnetwork)
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your post to {0} has been succesfully.",
                                                          "socialnetwork")
                                            +
                                            @"',{
	                        autoHide : true, // added in v2.0
	  	                        clickOverlay : false, // added in v2.0
	  	                        MinWidth : 300,
	  	                        TimeShown : 3000,
	  	                        ShowTimeEffect : 200,
	  	                        HideTimeEffect : 200,
	  	                        LongTrip :10,
	  	                        HorizontalPosition : 'center',
	  	                        VerticalPosition : 'center',
	  	                        ShowOverlay : true,
  		  	                        ColorOverlay : '#000',
	  	                        OpacityOverlay : 0.3,
	  	                        onClosed : function(){ // added in v2.0
	   
	  	                        },
	  	                        onCompleted : function(){ // added in v2.0
	   
	  	                }
		             });";
            return jNotifyConfirmationScript;
        }

        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
    }
}