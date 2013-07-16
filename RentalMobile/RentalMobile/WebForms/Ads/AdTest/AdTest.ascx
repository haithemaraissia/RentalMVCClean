<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Register TagPrefix="BannerRotator" Namespace="AdControl" Assembly="AdControl" %>
<script runat="server">

    protected void TopBannerRotatorCreated(object sender, AdCreatedEventArgs e)
    {
        TopBannerRotator.KeywordFilter =  ViewBag.KeywordFilter;
     }
    public string TopBannerKeyword { get; set; }
</script>
FROM USER CONTROL
<table width="90%">
        <tr>
            <td>
                <BannerRotator:BannerRotator ID="TopBannerRotator" DataSourceID="SqlDataSource1"
                    Target="_blank" OnAdCreated="TopBannerRotatorCreated" runat="server" ></BannerRotator:BannerRotator>
                <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:AdDatabaseConnectionString1 %>"
                    SelectCommand="SELECT ID, ImageUrl, Width, Height, NavigateUrl, AlternateText,Keyword, Impressions FROM AdGeneral"
                    runat="server"></asp:SqlDataSource>
            </td>
        </tr>
    </table>