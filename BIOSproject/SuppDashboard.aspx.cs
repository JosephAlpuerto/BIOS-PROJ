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
    public partial class SuppDashboard : System.Web.UI.Page
    {

        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            string cmdText = "select count(PONumber) from [LBC.BIOS].[lbcbios].[SSPRequest]", con;
            SqlConnection conDatabase = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conDatabase);
            {
                conDatabase.Open();
                int numRec = Convert.ToInt32(cmd.ExecuteScalar());
                LblPO.Text = numRec.ToString();
            }



        }
    }
}