using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIOSproject
{
    public partial class ValidateSSP : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + TxtSearch.Text + "'", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {
                TxtTicket.Text = sdr.GetValue(1).ToString();
                TxtPONo.Text = sdr.GetValue(2).ToString();
                TxtSupplier.Text = sdr.GetValue(3).ToString();
                txtProduct.Text = sdr.GetValue(4).ToString();
                TxtQuantity.Text = sdr.GetValue(5).ToString();
            }
            else
            {
                MessageBox.Show("No Record Found");
            }
            con.Close();
        }
    }
}