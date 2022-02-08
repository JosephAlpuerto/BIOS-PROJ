using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace BIOSproject.Hub
{
    public partial class WarehouseProcesslist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection coon = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
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
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehouseProcesslist", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist.DataSource = dtbl;
            gvlist.DataBind();
            gvlist.UseAccessibleHeader = true;
            gvlist.HeaderRow.TableSection = TableRowSection.TableHeader;
            //gvlist.FooterRow.TableSection = TableRowSection.TableFooter;

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "WarehousePrint2";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportRequest.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrintRequest2", dt));
            ReportRequest.LocalReport.ReportPath = Server.MapPath("~/Report/ReportRequest2.rdlc");
            ReportRequest.LocalReport.EnableHyperlinks = true;
            FillGridView();
            ModalReport.Show();
        }

        protected void DownloadView_Click(object sender, EventArgs e)
        {
            LinkButton linkdownload = sender as LinkButton;
            GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
            string downloadfile = gvlist.DataKeys[gridrow.RowIndex].Value.ToString();
            Response.ContentType = "Text/txt";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
            Response.TransmitFile(Server.MapPath(downloadfile));
            Response.End();
            //int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlData = new SqlDataAdapter("ViewtoDownload", sqlCon);
            //sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            //DataTable dtbl = new DataTable();
            //sqlData.Fill(dtbl);
            //sqlCon.Close();
            //txtId.Text = Id.ToString();
            //hfTicketNo.Value = dtbl.Rows[0]["TicketNo"].ToString();
            //hfPONumber.Value = dtbl.Rows[0]["PONumber"].ToString();
            //hfStartingSeries.Value = dtbl.Rows[0]["StartingSeries"].ToString();
            //hfEndingSeries.Value = dtbl.Rows[0]["EndingSeries"].ToString();
            //hfSupplier.Value = dtbl.Rows[0]["Supplier"].ToString();
            //hfProduct.Value = dtbl.Rows[0]["ProductQuantity"].ToString();
            //hfQuantity.Value = dtbl.Rows[0]["TotalQuantity"].ToString();
            //hfSchedule.Value = dtbl.Rows[0]["ScheduleDate"].ToString();
            //ModalDownloadView.Show();
            //FillGridView();
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DownloadbySupp", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", txtId.Text);
            sqlCmd.Parameters.AddWithValue("@IfDownload", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            try
            {
                string Id = txtId.Text;
                string TicketNo = hfTicketNo.Value;
                string PONumber = hfPONumber.Value;
                string StartingSeries = hfStartingSeries.Value;
                string EndingSeries = hfEndingSeries.Value;
                string Supplier = hfSupplier.Value;
                string Product = hfProduct.Value;
                string Quantity = hfQuantity.Value;
                string Sched = hfSchedule.Value;
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Length", Id.Length.ToString());
                Response.AddHeader("Content-Length", TicketNo.Length.ToString());
                Response.AddHeader("Content-Length", PONumber.Length.ToString());
                Response.AddHeader("Content-Length", StartingSeries.Length.ToString());
                Response.AddHeader("Content-Length", EndingSeries.Length.ToString());
                Response.AddHeader("Content-Length", Supplier.Length.ToString());
                Response.AddHeader("Content-Length", Product.Length.ToString());
                Response.AddHeader("Content-Length", Quantity.Length.ToString());
                Response.AddHeader("Content-Length", Sched.Length.ToString());
                Response.ContentType = "text/plain";
                Response.AppendHeader("content-disposition", "attachment;filename=\"" + txtId.Text + ".txt\"");
                Response.Write("RequestID: " + Id + " \r \n");
                Response.Write("Ticket Number: " + TicketNo + " \r \n");
                Response.Write("PO Number: " + PONumber + " \r \n");
                Response.Write("Starting Series: " + StartingSeries + " \r \n");
                Response.Write("Ending Series: " + EndingSeries + " \r \n");
                Response.Write("Supplier Name: " + Supplier + " \r \n");
                Response.Write("Product list: \r \n" + Product + " \r \n");
                Response.Write("Total Quantity: " + Quantity + " \r \n");
                Response.Write("Schedule Dated: " + Sched);
                Response.End();
                FillGridView();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex) { }
        }
        private void Clear()
        {
            //hfId.Value = "";
            //hfId1.Value = "";
            //lblSuccess.Text = "";
        }
        protected void btnCloseDownloadView_Click(object sender, EventArgs e)
        {
            ModalDownloadView.Hide();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

    }
}