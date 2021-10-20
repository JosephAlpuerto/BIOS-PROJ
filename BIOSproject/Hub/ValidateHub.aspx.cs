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
    public partial class ValidateSupplier : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
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
                Label7.Visible = false;
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
                //MessageBox.Show("No Record Found!!");
                Label7.Visible = true;
                Label7.Text = " No Record Found!";
                con.Close();
            }
            //SqlConnection conn = new SqlConnection(ConnectionString);
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = "Searching";
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Search", TxtSearch.Text);
            //cmd.Parameters.AddWithValue("@PONumber", TxtPONo.Text);
            //conn.Open();

            //SqlDataReader sdr = cmd.ExecuteReader();
            //if (sdr.Read())
            //{
            //    MessageBox.Show("Record Found");
            //}
            //else
            //{
            //    MessageBox.Show("No Record Found");
            //}
        }
    }
}