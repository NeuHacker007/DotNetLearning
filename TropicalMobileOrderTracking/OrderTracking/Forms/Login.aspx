<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/OrderTraking.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrderTracking.Forms.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <form id="form1" runat="server" style="height: 310px; width: 1418px;">

        <div class=" LoginFormContainer">
            <div id="">
                <asp:Label ID="lblBodayDetail" runat="server" Text="Mobile Customer Order Tracking" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            </div>

            <div class="LoginFormContent">
                <asp:Label ID="lblLoginID" runat="server" Text="Login ID:" Font-Bold="True" Font-Names="Calibri" Font-Size="Small" ForeColor="White"></asp:Label>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:TextBox ID="txtBoxLoginID" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="9pt" Width="200px"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="lblPasswd" runat="server" Text="Password:" Font-Bold="True" Font-Names="Calibri" Font-Size="Small" ForeColor="White"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtBoxPasswd" runat="server" Font-Names="Calibri" Font-Size="9pt" TextMode="Password" Width="200px"></asp:TextBox><br />
                <br/>
                <br/>
                <asp:Label ID="lblRemeberMe" runat="server" Text="Remeber My ID" Font-Names="Calibri" Font-Size="Small" ForeColor="White"></asp:Label>
                &nbsp;&nbsp;
                <asp:CheckBox ID="chkRemeberMe" runat="server" />
                &nbsp;&nbsp;
                <asp:Button CssClass="btn-Login" ID="btnLogin" runat="server" Text="Log-in" Font-Bold="True" Font-Names="Calibri" ForeColor="White" Width="82px" OnClick="btnLogin_Click" />
                </div>
            <br>
            <div class="link_Btn">
                <asp:LinkButton ID="lbtnForgetUserName" runat="server" Font-Size="Small" ForeColor="White" Font-Names="Calibri">Forget User Name</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnForgetPassword" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="White">Forget Password</asp:LinkButton>
            </div>
        </div>


    </form>


</asp:Content>


