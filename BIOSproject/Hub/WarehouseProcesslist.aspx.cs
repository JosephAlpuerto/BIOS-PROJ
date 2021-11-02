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
            gvlist.FooterRow.TableSection = TableRowSection.TableFooter;

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
    }
}