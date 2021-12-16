using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIOSproject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {






            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PONumber", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            LblPO.Text = numRec.ToString();


            sqlCon.Close();

            Count();

            Hitcheck();
        }

        private void Hitcheck()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Hitcheck", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblHitcheck.Text = numRec.ToString();
            sqlCon.Close();



        }
        private void Count()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(Supplier) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where Supplier = 'Well-Pack Container Corporation';";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            WellNoPO.Text = numRec.ToString();

            sqlCon.Close();



          
        }
    }
}