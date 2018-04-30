<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.Pages.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="~/AppThemes/TropicalStyles/Orders.css" type="text/css" />
    <script type="text/javascript" src="~/Javascipts/jquery-ui.min.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CriteriaBar">

        <asp:Label CssClass="label" runat="server" Text="Order Date" ID="lblOrderDate" Width="129px"></asp:Label>
        <asp:DropDownList AutoPostBack="True" CssClass="Input" ID="ddlOrderDate" runat="server" OnSelectedIndexChanged="ddlOrderDate_SelectedIndexChanged"></asp:DropDownList>


        <asp:Label CssClass="label" ID="lblCustomerID" runat="server" Text="Customer ID"></asp:Label>
        <asp:TextBox CssClass="Criteria Input" ID="txtBoxCustomerID" AutoPostBack="True" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regExpCustomerID" runat="server" ErrorMessage="Only Digits Allowed!" ControlToValidate="txtBoxCustomerID" ValidationExpression="/d+"></asp:RegularExpressionValidator>

        <asp:Label CssClass="label" ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
        <asp:TextBox CssClass="Input" ID="txtBoxUserName" AutoPostBack="True" runat="server"></asp:TextBox>


        <asp:Label ID="lblSalesManager" runat="server" Text="Sales Manager"></asp:Label>
        <asp:DropDownList CssClass="Criteria Input" ID="ddlSalesManager" runat="server" OnSelectedIndexChanged="ddlSalesManager_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button CssClass="loginButton" ID="BtnQuery" runat="server" Text="Query" OnClick="BtnQuery_Click" />

        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnRowCancelingEdit="gvOrders_RowCancelingEdit" OnRowUpdating="gvOrders_RowUpdating" OnRowEditing="gvOrders_RowEditing" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged" OnRowDeleting="gvOrders_RowDeleting">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:TemplateField HeaderText="custID" Visible="false">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("custID") %>' ID="lblCustID"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order Date" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("OrderDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer ID" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CustNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Name" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CustOfficeAddress1") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Address_Txt_Box" runat="server" Text='<%#Eval("CustOfficeAddress1") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Route #" Visible="true">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("OrderRouteNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  Visible="False">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblOrderID" Text='<%#Eval("OrderID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Operation" Visible="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="View_Link_Btn" runat="server" Text="View">View</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="Edit_Link_Btn" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("OrderTrackingNumber") %>'>Edit</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="Del_Link_Btn" runat="server" Text="Delete" OnClientClick="confirm('Are you really want to delete')">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="RowEditConfirm_Btn" runat="server" Text="Save" CommandName="Update" />
                        <asp:Button ID="CancelRowEditing_Btn" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
