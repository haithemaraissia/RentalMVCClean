<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdTest.aspx.cs" Inherits="RentalMobile.WebForms.Ads.AdTest" %>

<%@ Register TagPrefix="BannerRotator" Namespace="AdControl" Assembly="AdControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
        </table>
    </div>
    </form>
</body>
</html>
