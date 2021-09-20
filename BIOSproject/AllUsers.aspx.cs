using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIOSproject.FolConnectionDB;
using Microsoft.Reporting.WebForms;

namespace BIOSproject
{
    public partial class AllUsers : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source=THEOTEDDY07\SQLEXPRESS;Initial Catalog=BIOSproject;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            AllData();
        }

        private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList1();
            if (list.Count <= 0)
            {
                return;
            }
            gvList1.DataSource = list;
            gvList1.DataBind();

            gvList1.UseAccessibleHeader = true;
            gvList1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void btnPrint2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Users_SelectAll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportUsers.LocalReport.DataSources.Add(new ReportDataSource("DataSetUser", dt));
            ReportUsers.LocalReport.ReportPath = Server.MapPath("~/Report/ReportUsers.rdlc");
            ReportUsers.LocalReport.EnableHyperlinks = true;
            ModalUsers.Show();
        }
    }
}