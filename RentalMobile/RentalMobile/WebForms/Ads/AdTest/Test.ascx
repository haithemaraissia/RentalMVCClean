<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Register TagPrefix="BannerRotator" Namespace="AdControl" Assembly="AdControl" %>
<script runat="server">

    protected void TopBannerRotatorCreated(object sender, AdCreatedEventArgs e)
    {

    }

    protected void RightBannerRotatorCreated(object sender, AdCreatedEventArgs e)
    {

    }
</script>
FROM USER CONTROL
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
                Right KeywordFilter <%= (string)ViewBag.KeywordFilter%>
            </td>
            <td>
                <BannerRotator:BannerRotator ID="RightBannerRotator" DataSourceID="SqlDataSource1"
                    Target="_blank" OnAdCreated="RightBannerRotatorCreated" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>