using System;
using System.Data;
using System.Web.UI.WebControls;
using TropicalServer.DAL;

namespace TropicalServer.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateOrderDateFilter();
                PopulateSalesMgrFilter();
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
        private void PopulateSalesMgrFilter()
        {
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueSalesMgr();
            ddlSalesManager.DataSource = ds.Tables[0];
            ddlSalesManager.DataTextField = ds.Tables[0].Columns["UserName"].ToString();
            ddlSalesManager.DataValueField = ds.Tables[0].Columns["UserName"].ToString();
            ddlSalesManager.DataBind();
        }
        private void PopulateOrderDateFilter()
        {

            ddlOrderDate.Items.Add(new ListItem("Today"));
            ddlOrderDate.Items.Add(new ListItem("Last 7 Days"));
            ddlOrderDate.Items.Add(new ListItem("Last 1 Month"));
            ddlOrderDate.Items.Add(new ListItem("Last 6 Months"));
        }
        protected void ddlSalesManager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOrderDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrdersDAL orders = new OrdersDAL();

            DataSet ds = orders.GetOrdersByDateType(ddlOrderDate.SelectedValue);
            gvOrders.DataSource = ds;
            gvOrders.DataBind();
        }

        protected void BtnQuery_Click(object sender, EventArgs e)
        {
            string orderDateFilterValue = ddlOrderDate.SelectedValue;
            int custId = Convert.ToInt32(txtBoxCustomerID.Text);
            string custName = txtBoxUserName.Text;
            string salesMgr = ddlSalesManager.SelectedValue;

            //TODO: filter data by dynamic SQL
        }
    }
}