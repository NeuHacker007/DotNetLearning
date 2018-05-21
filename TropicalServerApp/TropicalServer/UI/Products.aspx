<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.UI.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/AppThemes/TropicalStyles/Products.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="productCategories" style="display: inline-block">
        <div style="display: inline-block;">
            <asp:Label ID="lblProductionCategories" CssClass="productCategoriesLabel" runat="server" Text="PRODUCTION CATEGORIES" Font-Bold="True"></asp:Label>
            <br />
            <asp:ImageButton CssClass="imageStyle" ID="imgBtnCaribbeanLine" runat="server" ImageUrl="~/Images/productCaribbeanLine.png" OnClick="imgBtnCaribbeanLine_Click" />
            <br>
            <asp:ImageButton ID="imgBtnCentralAmericanLine" runat="server" CssClass="imageStyle" ImageUrl="~/Images/productCentralAmericanLine.png" OnClick="imgBtnCentralAmericanLine_Click" />
            <br>
            <asp:ImageButton ID="imgBtnMexicanLine" runat="server" ImageUrl="~/Images/productMexicanLine.png" CssClass="imageStyle" OnClick="imgBtnMexicanLine_Click" />
            <br />
            <asp:ImageButton ID="imgBtnPaisanoLine" runat="server" ImageUrl="~/Images/productPaisanoLine.png" CssClass="imageStyle" OnClick="imgBtnPaisanoLine_Click" />
            <br />
            <asp:ImageButton ID="imgBtnDomesticcItems" runat="server" ImageUrl="~/Images/productDomesticItems.png" CssClass="imageStyle" OnClick="imgBtnDomesticcItems_Click" />
            <br />
            <asp:ImageButton ID="imgBtnMeats" runat="server" CssClass="imageStyle" ImageUrl="~/Images/productMeats.png" OnClick="imgBtnMeats_Click" />
            <br />
            <asp:ImageButton ID="imgBtnDeserts" runat="server" CssClass="imageStyle" ImageUrl="~/Images/productDesserts.png" OnClick="imgBtnDeserts_Click" />
            <br>
            <asp:ImageButton ID="imgBtnOthers" runat="server" ImageUrl="~/Images/productOthers.png" CssClass="imageStyle" OnClick="imgBtnOthers_Click" />
            <br />
            <asp:ImageButton ID="imgBtnDrinkableYogurts" runat="server" ImageUrl="~/Images/productDrinkableYogurts.png" CssClass="imageStyle" OnClick="imgBtnDrinkableYogurts_Click" />
            <br />
            <asp:ImageButton ID="imgBtnArepas" runat="server" ImageUrl="~/Images/productArepas.png" CssClass="imageStyle" OnClick="imgBtnArepas_Click" />
            <br>
            <asp:ImageButton ID="imgBtnPerPoundItems" runat="server" ImageUrl="~/Images/productPerPoundItems.png" CssClass="imageStyle" OnClick="imgBtnPerPoundItems_Click" />
        </div>
        <div style="float: right; display: inline-block;">
            <asp:GridView ID="gvProductsDisplay" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="670px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
