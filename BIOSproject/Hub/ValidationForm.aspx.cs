using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIOSproject.Hub
{
    public partial class ValidationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SSPRequest where PONumber = '" + TxtSearch.Text + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                TextBox1.Text = sdr.GetValue(1).ToString();
                TextBox2.Text = sdr.GetValue(2).ToString();
            }
            else
            {
                MessageBox.Show("No Record Found!");
            }
        }
    }
}