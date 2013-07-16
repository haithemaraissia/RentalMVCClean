<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register TagPrefix="BannerRotator" Namespace="AdControl" Assembly="AdControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void TopBannerRotatorCreated(object sender, AdCreatedEventArgs e)
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
    }

    protected void RightBannerRotatorCreated(object sender, AdCreatedEventArgs e)
    {
        try
        {
            var fullDbPath = Server.MapPath("~/App_Data/GeoLiteCity.dat");
            // Visitor's IP address
            // var visitorIP = Request.ServerVariables["REMOTE_ADDR"];
            var test = Request.ServerVariables["REMOTE_ADDR"];
            var visitorIp = "68.70.88.2";
            //   ImpressionUtility.UpdateImpression(e.AdProperties["ID"].ToString(), 0, fullDBPath, visitorIP, Request.Url.ToString());
        }
        catch
        {
            Response.Redirect(Request.Url.ToString());
        }
        e.NavigateUrl = "~/Advertiser/AdHandler.ashx?id=" + e.AdProperties["ID"];
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>This is a test for the ad</title>
</head>
<body>
    <table width="90%">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Top
            </td>
            <td>
                <BannerRotator:BannerRotator ID="TopBannerRotator" DataSourceID="SqlDataSource1"
                    Target="_blank" OnAdCreated="TopBannerRotatorCreated" runat="server" />
                <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:AdDatabaseConnectionString1 %>"
                    SelectCommand="SELECT ID, ImageUrl, Width, Height, NavigateUrl, AlternateText,Keyword, Impressions FROM AdGeneral"
                    runat="server"></asp:SqlDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Right
            </td>
            <td>
                <BannerRotator:BannerRotator ID="RightBannerRotator" DataSourceID="SqlDataSource1"
                    Target="_blank" OnAdCreated="RightBannerRotatorCreated" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Data passed from viewbag is:
            </td>
            <td>
                <%= ViewBag.SomeValue %>
            </td>
        </tr>
    </table>
       <small style="color: green">
        <%= ViewBag.SomeValue%></small>
        
    <br/><br/>
        Form the UserControl:
          <%=Html.Partial("Test")%>
</body>
</html>
