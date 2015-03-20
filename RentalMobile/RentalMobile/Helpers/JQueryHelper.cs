using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalMobile.Helpers
{
    public static class JNotfiyScriptQueryHelper
    {
        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
        /// <summary>
        /// Parameterized JNotify Function
        /// </summary>
        /// <param name="successmessage"></param>
        /// <param name="navigateturlwhencompleted"></param>
        /// <returns></returns>

        public static string JNotifyConfirmationMessage(string successmessage, string navigateturlwhencompleted)
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



        public static string JNotifyConfirmationSharingEmail()
        {

            var jNotifyConfirmationScript = string.Format(@"jSuccess('Your sharing has been sent successfully.")
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

        public static string JNotifyConfirmationSuccessComment()
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
        //***********************************************JQuery HELPER*********************************************************
        //*********************************************************************************************************************
    }
}