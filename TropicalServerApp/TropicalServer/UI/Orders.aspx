<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.Pages.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="~/AppThemes/TropicalStyles/Orders.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CriteriaBar">

            <asp:Label CssClass="label" runat="server" Text="Order Date" ID="lblOrderDate" Width="129px"></asp:Label>
            <asp:DropDownList CssClass="Input" ID="ddlOrderDate" runat="server"></asp:DropDownList>


            <asp:Label CssClass="label" ID="lblCustomerID" runat="server" Text="Customer ID"></asp:Label>
            <asp:TextBox CssClass="Criteria Input" ID="txtBoxCustomerID" runat="server"></asp:TextBox>


            <asp:Label CssClass="label" ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
            <asp:TextBox CssClass="Input" ID="txtBoxUserName" runat="server"></asp:TextBox>


            <asp:Label ID="lblSalesManager" runat="server" Text="Sales Manager"></asp:Label>
            <asp:DropDownList CssClass="Criteria Input" ID="ddlSalesManager" runat="server">

            </asp:DropDownList>
    </div>
    <asp:GridView ID="gvOrders" runat="server" Style="margin-bottom: 0px"></asp:GridView>
</asp:Content>
