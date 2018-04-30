using System;
using System.Data;
using System.Web.UI;
using TropicalServer.DAL;

namespace TropicalServer.UI
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrePopolateWithAllProducts();
        }

        protected void imgBtnCaribbeanLine_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("CARIBBEAN LINE");
        }

        protected void imgBtnCentralAmericanLine_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("CENTRAL AMERICAN");
        }

        protected void imgBtnMexicanLine_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("MEXICAN LINE");
        }
        protected void imgBtnPaisanoLine_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("PAISANO LINE");
        }

        protected void imgBtnDomesticcItems_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("DOMETIC ITEMS");
        }

        protected void imgBtnMeats_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("MEATS");
        }

        protected void imgBtnDeserts_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("DESSERTS");
        }

        protected void imgBtnOthers_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("OTHERS");
        }

        protected void imgBtnDrinkableYogurts_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("DRINKABLE YOGURTS");
        }

        protected void imgBtnArepas_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("AREPAS");
        }

        protected void imgBtnPerPoundItems_Click(object sender, ImageClickEventArgs e)
        {
            BindProductionByCategory("PER POUND ITEMS");
        }
        private void BindProductionByCategory(string category)
        {
            ProductsDAL products = new ProductsDAL();
            DataSet ds = products.GetProductByProductCategory(category);
            gvProductsDisplay.DataSource = ds;
            gvProductsDisplay.DataBind();
        }

        private void PrePopolateWithAllProducts()
        {
            ProductsDAL products = new ProductsDAL();
            DataSet ds = products.GetAllProducts();
            gvProductsDisplay.DataSource = ds;
            gvProductsDisplay.DataBind();
        }
    }
}