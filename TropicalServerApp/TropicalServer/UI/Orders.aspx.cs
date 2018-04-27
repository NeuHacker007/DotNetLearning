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
                PopulateSalesMgrTxtBox();
                PopulateOrdersGridView();
            }
        }

        private void PopulateOrdersGridView()
        {
            OrdersDAL orders = new OrdersDAL();
            DataSet ds = orders.GetAllOrders();
            gvOrders.DataSource = ds;
            gvOrders.DataBind();
        }

        private void PopulateSalesMgrTxtBox()
        {
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueSalesMgr();
            ddlSalesManager.DataSource = ds.Tables[0];
            ddlSalesManager.DataTextField = ds.Tables[0].Columns["UserName"].ToString();
            ddlSalesManager.DataValueField = ds.Tables[0].Columns["UserName"].ToString();
            ddlSalesManager.DataBind();
        }
    }
}