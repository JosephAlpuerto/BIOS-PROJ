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
    public partial class SourcingDashboard : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("PONumber", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;


                int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
                LblPO.Text = numRec.ToString();

                sqlCon.Close();
                //string cmdText = "select count(PONumber) from [LBC.BIOS].[lbcbios].[SSPNewRequest]", con;
                //SqlConnection conDatabase = new SqlConnection(ConnectionString);
                //SqlCommand cmd = new SqlCommand(cmdText, conDatabase);
                //{
                //    conDatabase.Open();
                //    int numRec = Convert.ToInt32(cmd.ExecuteScalar());
                //    LblPO.Text = numRec.ToString();
                //    LblPO1.Text = numRec.ToString();

                //}

                Hitcheck();
                FillGridview();
            }
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
        private void FillGridview()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("GridShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
        }


    }
}