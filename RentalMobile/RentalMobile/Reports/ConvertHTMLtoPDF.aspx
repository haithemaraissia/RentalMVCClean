<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConvertHTMLtoPDF.aspx.cs" Inherits="ConvertHTMLtoPDF" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Convert HTML to PDF</h2>
    <p>
        This demo shows how to use iTextSharp to convert an HTML document (<code>~/HTMLTemplate/Receipt.htm</code>) into a PDF.
        Enter the values for the receipt in the user interface below and then click "Create Receipt." iTextSharp will then create
        a PDF based on the HTML defined in the HTML template file (<code>~/HTMLTemplate/Receipt.htm</code>) using the values you
        entered below. (Of course, in a real-world application the values for the receipt would come from a database...)
    </p>
    <p>
        <b>Order ID:</b>
        <asp:TextBox ID="txtOrderID" runat="server" Columns="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqOrderID" runat="server" 
            ControlToValidate="txtOrderID" ErrorMessage="[Required]" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </p>
    <p>
        <b>Total Price:</b>
        $<asp:TextBox ID="txtTotalPrice" Columns="10" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqTotalPrice" runat="server" 
            ControlToValidate="txtTotalPrice" Display="Dynamic" ErrorMessage="[Required]" 
            SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmpTotalPrice" runat="server" 
            ControlToValidate="txtTotalPrice" Display="Dynamic" ErrorMessage="[Invalid]" 
            Operator="GreaterThan" SetFocusOnError="True" ValueToCompare="0"></asp:CompareValidator>
    </p>
    <p>
        <b>What Items Were Purchased?</b>
        <asp:CheckBoxList ID="cblItemsPurchased" runat="server">
            <asp:ListItem Value="Widget|450FX|4">Four widgets</asp:ListItem>
            <asp:ListItem Value="Thingamajiggs|780JP|3">Three Thingamajiggs</asp:ListItem>
            <asp:ListItem Value="Whatchacallit|89001|1">One Whatchacallit</asp:ListItem>
            <asp:ListItem Value="Thingamabops|A0902X|7">Seven Thingamabops</asp:ListItem>
        </asp:CheckBoxList>
    </p>
    <p>
        <asp:Button ID="btnCreatePDF" runat="server" Text="Create Receipt" 
            onclick="btnCreatePDF_Click" />
    </p>
</asp:Content>

