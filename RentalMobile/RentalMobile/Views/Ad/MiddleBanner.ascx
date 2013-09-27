<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Register TagPrefix="BannerRotator" Namespace="AdControl" Assembly="AdControl" %>
<script runat="server">

    protected void MiddleBannerRotatorCreated(object sender, AdCreatedEventArgs e)
    {
        try
        {
            var fullDbPath = Server.MapPath("~/App_Data/GeoLiteCity.dat");
            // Visitor's IP address
            // var visitorIP = Request.ServerVariables["REMOTE_ADDR"];
            var visitorIp = "68.70.88.2";
            //ImpressionUtility.UpdateImpression(e.AdProperties["ID"].ToString(), 0, fullDBPath, visitorIP, Request.Url.ToString());
        }
        catch
        {
            Response.Redirect(Request.Url.ToString());
        }
        e.NavigateUrl = "~/Advertiser/AdHandler.ashx?id=" + e.AdProperties["ID"];
        
        MiddleBannerRotator.KeywordFilter = ViewBag.MiddleBannerKeywordFilter;
    }
    public string MiddleBannerKeyword { get; set; }
</script>



<div>
MiddleBannerKeywordFilter<% Response.Write(ViewBag.MiddleBannerKeywordFilter);%>
<br/>
providerGoogleMap<% Response.Write(ViewBag.providerGoogleMap); %>
</div>


<div>
    
    Logic is as follow:
    
   For each type, there is an adhelper that will determine the keyword with the adHelper.
   Then Send it back to each type on their index() actionResult, 
   Which will be bound at the script of the user Control to the the control.
   
   <p>
       More work need to be done in regard to Ip, Impression, clicks..
   </p>
</div>

<table width="100%">
    <tr>
        <td>
            <BannerRotator:BannerRotator ID="MiddleBannerRotator" DataSourceID="SqlDataSource1"
                Target="_blank" OnAdCreated="MiddleBannerRotatorCreated" runat="server"></BannerRotator:BannerRotator>
            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:AdDatabaseConnectionString1 %>"
                SelectCommand="SELECT ID, ImageUrl, Width, Height, NavigateUrl, AlternateText,Keyword, Impressions FROM AdGeneral"
                runat="server"></asp:SqlDataSource>
        </td>
    </tr>
</table>
