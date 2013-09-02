<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendToFriend.aspx.cs" Inherits="RentalMobile.Views.Emails.SendtoFriend.SendToFriend" %>

<html>
    <head>
        <title>Mike Invitation to Property</title>

        <style type="text/css">
        	.Sender
        	{
        		color: #800000;
        	}
        	#PropertyImage
        	{
        		height: 150px;
        		width: 250px;
        	}
        	text {
        		 font-family:Arial, Helvetica, sans-serif;font-size:18px;padding:5px 50px 15px;color:#444444;
        	}
        </style>
    </head>
    <body>
    <form id="form1" runat="server">
<div>
        <div style="text-align: center">
            <span style="text-align: center">Request from </span><span class="Sender">
            <strong>Sami</strong></span><br />
        </div>
        <div>
            <br />
            Hi Mike,<br />
            <br />
            Sami&nbsp; invite you to see&nbsp; this property.<br />
            <br />
             <a href="http://www.yahoo.com">
           <img id="Img1" runat="server" 
                src="http://www.haithem-araissia.com/images/property/home12.jpg" border="0" 
                alt=""></img>
           </a>
            <br />
            <br />
            <a href="http://www.yahoo.com">Check out this property.</a>
            <br />
        </div>
    </div>    </form>
</body>
</html>
