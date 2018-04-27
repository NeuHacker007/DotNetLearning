<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfoBoxControl1.ascx.cs" Inherits="TropicalServer.UserControls.UserInfoBoxControl" %>

<b>Information about <%=this.UserName %></b>
<br /><br />
<%= this.UserName %> is <%= this.UserAge %> years old and lives in <%= this.UserCountry %>