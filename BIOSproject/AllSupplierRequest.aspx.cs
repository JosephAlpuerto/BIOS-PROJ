using System;
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

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalValidate.Show();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + TxtSearch.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                MessageBox.Show("This PO Number is Already Use!");
                TxtPONo.Text = sdr.GetValue(2).ToString();
                Button1.Enabled = false;

            }
            else
            {
                MessageBox.Show("No Record Found");
            }

            con.Close();
        }

        protected void hitCheckClose_Click(object sender, EventArgs e)
        {
            Clear1();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        private void Clear1()
        {
            TxtSearch.Text = TxtPONo.Text = "";
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

