﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

namespace BIOSproject
{
    public partial class AllSupplierRequest : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }

        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SSPRequestSupplierShow", sqlCon);
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
        protected void btnRequest_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32((sender as System.Web.UI.WebControls.Button).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewAllSSPRequest", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtRequestID.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicket.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPO.Text = dtbl.Rows[0]["PONumber"].ToString();
            txtStart.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEnd.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            Product.Value = dtbl.Rows[0]["Product"].ToString();
            Quantity.Value = dtbl.Rows[0]["Quantity"].ToString();
            ModalRequest.Show();
            FillGridView();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var ResquestID = txtRequestID.Text.Trim();
            var Ticket = txtTicket.Text.Trim();
            var PO = txtPO.Text.Trim();


            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateSuppRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@RequestID", txtRequestID.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@TicketNO ", txtTicket.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PoNO", txtPO.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@ScheduleRequest", txtDate.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@StartingSeries", txtStart.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EndingSeries", txtEnd.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Product", Product.Value.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", Quantity.Value.Trim());
            sqlCmd.Parameters.AddWithValue("@NoOfUnit", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@IfProcess", "0");
            sqlCmd.Parameters.AddWithValue("@Team", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            string Id = hfId.Value;

            // validations
            if (Id == "")
            {
                lblSuccess.Text = "New Request added Successfully!";
            }
            else
            {
                lblSuccess.Text = "Please Cornfirm your Details!";
            }
        }
        private void Clear()
        {
            hfId.Value = "";
            lblSuccess.Text = "";
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton linkdownload = sender as LinkButton;
            GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
            string downloadfile = Gridview1.DataKeys[gridrow.RowIndex].Value.ToString();
            Response.ContentType = "Text/txt";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
            Response.TransmitFile(Server.MapPath(downloadfile));
            Response.End();
        }

        protected void btnViewReject_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewtoReject", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId1.Value = Id.ToString();
            txtRequestID1.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicketNo1.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPONo1.Text = dtbl.Rows[0]["PONumber"].ToString();
            ModalViewReject.Show();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("RejectedBySupplier", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@TicketNo", txtTicketNo1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PONumber", txtPONo1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", (hfSupplier1.Value == "" ? 0 : Convert.ToChar(hfSupplier1.Value)));
            sqlCmd.Parameters.AddWithValue("@Quantity", (hfQuantity1.Value == "" ? 0 : Convert.ToInt32(hfQuantity1.Value)));
            sqlCmd.Parameters.AddWithValue("@StartingSeries", (hfStart1.Value == "" ? 0 : Convert.ToInt64(hfStart1.Value)));
            sqlCmd.Parameters.AddWithValue("@EndingSeries", (hfEnd1.Value == "" ? 0 : Convert.ToInt64(hfEnd1.Value)));
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@IsActive", "0");
            sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
            sqlCmd.Parameters.AddWithValue("@IsRejected", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccess1.Text = "Request Rejected!";
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

        //protected void hitCheckClose_Click(object sender, EventArgs e)
        //{
        //    Clear1();
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}
        //private void Clear1()
        //{
        //    TxtSearch.Text = TxtPONo.Text = "";
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
        private void Clear2()
        {
            TxtSearchSeries.Text = "";
            //TxtStart.Text = TxtEnd.Text = "";
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
            string sqlquery = "select * from SSPRequest where StartingSeries like '%'+@start+'%' or EndingSeries like '%'+@end+'%' ";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@start", TxtSearchSeries.Text);
            sql.Parameters.AddWithValue("@end", TxtSearchSeries.Text);
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
        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConnectionString);
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlCommand sqlCmd = new SqlCommand("RejectedBySupp", sqlCon);
        //    sqlCmd.CommandType = CommandType.StoredProcedure;
        //    sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
        //    sqlCmd.Parameters.AddWithValue("@RequestID", txtRequestID.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@TicketNO ", txtTicket.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@PoNO", txtPO.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@ScheduleRequest", txtDate.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Value);
        //    sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Value);
        //    sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
        //    sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
        //    sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
        //    sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
        //    sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
        //    sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
        //    sqlCmd.Parameters.AddWithValue("@IsActive", "1");
        //    sqlCmd.Parameters.AddWithValue("@IsRejected", "1");
        //    sqlCmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //    Clear();
        //    FillGridView();
        //    lblSuccess.Text = "Rejected Request Successfully!";
        //}

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{

        //    LinkButton linkdownload = sender as LinkButton;
        //    GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
        //    string downloadfile = Gridview1.DataKeys[gridrow.RowIndex].Value.ToString();
        //    Response.ContentType = "Text/txt";
        //    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
        //    Response.TransmitFile(Server.MapPath(downloadfile));
        //    Response.End();

        //}

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{

        //}
    }
}

