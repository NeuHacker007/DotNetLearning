using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using TropicalServer.DAL;

namespace TropicalServer.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
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

            string custId = txtBoxCustomerID.Text;
            string custName = txtBoxUserName.Text;
            string salesMgr = ddlSalesManager.SelectedValue;
            if (string.Equals(orderDateFilterValue, ""))
            {
                orderDateFilterValue = null;
            }
            else if (string.Equals(custId, ""))
            {
                custId = null;
            }
            else if (string.Equals(custName, ""))
            {
                custName = null;
            }
            else if (string.Equals(salesMgr, ""))
            {
                salesMgr = null;
            }

            OrdersDAL orders = new OrdersDAL();
            DataSet ds = orders.GetOrdersWithFilterOptions(orderDateFilterValue, custId, custName, salesMgr);
            gvOrders.DataSource = ds;
            gvOrders.DataBind();

        }

        protected void gvOrders_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvOrders.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(((Label)row.FindControl("lblCustID")).Text);
            string address = ((TextBox)row.FindControl("Address_Txt_Box")).Text;
            OrdersDAL orders = new OrdersDAL();
            orders.UpdateCustomerAddress(address, customerId);
            gvOrders.EditIndex = -1;
            BindData();
        }

        protected void gvOrders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrders.EditIndex = -1;
            BindData();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCustomerId(string pre)
        {

            List<string> ids = new List<string>();
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueCustomerID();
            ids = ds.Tables[0].AsEnumerable()
                .Where(datarow => datarow["CustNumber"].ToString().StartsWith(pre))
                .Select(a => a.Field<string>("CustNumber")).ToList();
            return ids;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCustomerNames(string pre)
        {
            List<string> names = new List<string>();
            UserOperationDALcs userOperation = new UserOperationDALcs();
            DataSet ds = userOperation.GetUniqueCustomerID();
            names = ds.Tables[0].AsEnumerable()
                .Where(datarow => datarow["CustName"].ToString().StartsWith(pre))
                .Select(a => a.Field<string>("CustName")).ToList();
            return names;
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvOrders_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrders.EditIndex = e.NewEditIndex;

        }

        protected void gvOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvOrders.Rows[e.RowIndex];
            int orderId = Convert.ToInt32(((Label)row.FindControl("OrderID")).Text);


        }
    }
}