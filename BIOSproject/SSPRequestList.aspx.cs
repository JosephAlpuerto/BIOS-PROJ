using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace BIOSproject
{
    public partial class SSPRequestList : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
            
        }


        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SSPNewRequestShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnValidate_Click(object sender, EventArgs e)
        //{
        //    FillGridView();
        //    ModalValidate.Show();
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + TxtSearch.Text + "' ", con);
        //    SqlDataReader sdr = comm.ExecuteReader();
        //    if (sdr.Read())
        //    {

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This PO Number is already use!')", true);
        //        TxtPONo.Text = sdr.GetValue(2).ToString();
        //        Button1.Enabled = false;
               
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
        //    }
            
        //    con.Close();
        //}
        //private void Clear1()
        //{
        //    TxtSearch.Text = TxtPONo.Text = "";
        //}
        private void Clear2()
        {
            TxtSearchSeries.Text =  "";
            //TxtStart.Text = TxtEnd.Text = "";
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewAllByIdSSPRequest", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);

            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtRequestIDView.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicketNoView.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPONumberView.Text = dtbl.Rows[0]["PONumber"].ToString();
            txtStartingSeriesView.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEndingSeriesView.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            txtSupplierView.Text = dtbl.Rows[0]["Supplier"].ToString();
            txtProductView.Text = dtbl.Rows[0]["Product"].ToString();
            txtQuantityView.Text = dtbl.Rows[0]["Quantity"].ToString();
            ModalView.Show();

            FillGridView();
        }

        protected void btnUpdateView_Click(object sender, EventArgs e)
        {
            var txtProduct = txtProductView.Text.Trim();
            var txtQuantity = txtQuantityView.Text.Trim();
            

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateSSPRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Product", txtProductView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQuantityView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);

            string Id = hfId.Value;
            if (txtProduct == "")
            {
                lblError.Text = "Please Enter Product!";
            }
            else if (txtQuantity == "")
            {
                lblError.Text = "Please Enter Quantity!";
            }
            else if (Id == "")
            {
                lblSuccess.Text = "Saved Successfully";
            }
            else
            {
                Clear();
                FillGridView();
                lblSuccess.Text = "Updated Successfully!";
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                
            }
        }
        private void Clear()
        {
            hfId.Value = "";
            lblError.Text = "";
            lblSuccess.Text = "";
        }

        

        protected void btnCloseView_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnCancelRequest_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CancelRequestSSP", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@TicketNo", txtTicketNoView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PONumber", txtPONumberView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", txtSupplierView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQuantityView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@StartingSeries", txtStartingSeriesView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EndingSeries", txtEndingSeriesView.Text.Trim());  
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@IsActive", "0");
            sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "1");
            sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccess.Text = "Cancel Request Successfully!";
        }

        //protected void hitCheckClose_Click(object sender, EventArgs e)
        //{
        //    Clear1();
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}

        protected void btnValidateSeries_Click(object sender, EventArgs e)
        {
            
            FillGridView();
            ModalValidateSeries.Show();
        }

        protected void hitCheckCloseSeries_Click(object sender, EventArgs e)
        {
            Clear2();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int start = new int();
            int end = new int();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SearchSeries";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", TxtSearchSeries.Text);
            cmd.Parameters.AddWithValue("@startmin", start);
            cmd.Parameters.AddWithValue("@endmax", end);
            conn.Open();
            SqlCommand sql = new SqlCommand();
            string sqlquery = "select * from SSPRequest where StartingSeries <= @search and EndingSeries >= @search ";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@search", Convert.ToInt64(TxtSearchSeries.Text));
            //sql.Parameters.AddWithValue("@end", Convert.ToInt64(TxtSearchSeries.Text));
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            sda.Fill(dt);

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This Series is already use!')", true);
                    gridview.DataSource = dt;
                    gridview.DataBind();
                    gridview.UseAccessibleHeader = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
            }
            con.Close();
        }

       
    }
}