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

    public partial class AllAdmin : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source=THEOTEDDY07\SQLEXPRESS;Initial Catalog=BIOSproject;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            AllData();
        }

       
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Admin_SelectAll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportAdmin.LocalReport.DataSources.Add(new ReportDataSource("DataSetAdmin", dt));
            ReportAdmin.LocalReport.ReportPath = Server.MapPath("~/Report/ReportAdmin.rdlc");
            ReportAdmin.LocalReport.EnableHyperlinks = true;
            ModalAdmin.Show();
        }


        private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList();
            if(list.Count<=0)
            {
                return;
            }
            gvList.DataSource = list;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList.FooterRow.TableSection = TableRowSection.TableFooter;

        }

        
    }
}