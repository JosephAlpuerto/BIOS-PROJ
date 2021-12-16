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
    public partial class SourcDashboard : System.Web.UI.Page
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

            Hitcheck();
            FillGridView();

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

        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT VendorName FROM [lbcbios].[Reference] where VendorName != 'NULL'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
            sqlCon.Close();

            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = sqlcom;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                Gridview1.DataSource = objDs.Tables[0];
              
            }



        }
       

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Gridview1_Load(object sender, EventArgs e)
        {
            
        }
        private void NoPO()
        {
            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("Count", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;


            //int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            //Label lblNoPO = numRec.ToString();
        }
    }
}