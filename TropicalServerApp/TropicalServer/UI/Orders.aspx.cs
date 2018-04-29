using System;
using System.Data;
using TropicalServer.DAL;

namespace TropicalServer.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateOrdersGridView();
            }
        }
        private void PopulateOrdersGridView()
        {
            BindData();
        }
        private void BindData()
        {
            OrdersDAL orders = new OrdersDAL();
            DataSet ds = orders.GetAllOrders();
            gvOrders.DataSource = ds;
            gvOrders.DataBind();
        }
        protected void ddlSalesManager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOrderDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}