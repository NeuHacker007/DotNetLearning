<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TropicalServer.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tropical Mobile Order Tracking Login</title>
    <link rel="stylesheet" href="~/AppThemes/TropicalStyles/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="page">
            <div class="header">
                <div class="imageDisplay">
                    <asp:Image ID="Image" runat="server"
                        CssClass="imageHeader" ImageUrl="~/Images/HeaderTropicalServer.png" />
                </div>
            </div>
            <div id="container">
                <div id="BodyDetail">
                    <asp:Label ID="lblBodayDetail" runat="server" Text="Mobile Customer Order Tracking" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
                    <div id="loginBox">

                        <asp:Label ID="lblUserName" runat="server" CssClass="useridlbl" Text="Login ID:" Font-Bold="True" Font-Names="Calibri" Font-Size="25px"></asp:Label>


                        <asp:TextBox ID="txtBoxUsername" CssClass="useridtxtBox" runat="server"></asp:TextBox>

                        <br />
                        <asp:Label ID="lblPassword" CssClass="userPasswdlbl" runat="server" Text="Password:" Font-Bold="True"></asp:Label>


                        <asp:TextBox ID="txtBoxPassword" CssClass="userPasswdTxtBox" runat="server" TextMode="Password" Width="237px"></asp:TextBox>
                        <br />
                        <div class="remeberMe">
                            <asp:Label ID="lblRemeberMe" runat="server" Text="Remeber My ID" Font-Names="Calibri" Font-Size="Small" ForeColor="White"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:CheckBox ID="chkRemeberMe" runat="server" />
                            &nbsp;&nbsp;
                            <asp:Button CssClass="btn-Login" ID="btnLogin" runat="server" Text="Log-in" Font-Bold="True" Font-Names="Calibri" ForeColor="White" Width="82px" OnClick="btnLogin_Click" />


                    </div>

                <div id="forgotPassword">
                        <asp:LinkButton ID="lbtnForgetUserName" runat="server" Font-Size="Small" ForeColor="White" Font-Names="Calibri" OnClick="lbtnForgetUserName_Click" >Forget User Name</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;
                        <asp:LinkButton ID="lbtnForgetPassword" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="White" OnClick="lbtnForgetPassword_Click">Forget Password</asp:LinkButton>
                    </div>
                </div>

            </div>

        </div>
</div>
    </form>
</body>
</html>
