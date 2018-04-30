<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="TropicalServer.UI.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password"></asp:Label>
    <asp:TextBox ID="txtBoxOldpassword" runat="server" TextMode="Password"></asp:TextBox>
    <br>
    <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
    <asp:TextBox ID="txtBoxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="Button" />
</asp:Content>
