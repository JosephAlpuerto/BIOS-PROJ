using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BIOSproject
{
    public partial class Generate : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from lbcbios.Area";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);

            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            DropArea.DataSource = dt;
            DropArea.DataTextField = "Area";
            DropArea.DataValueField = "Area";
            DropArea.DataBind();

            DropTeam.DataSource = dt;
            DropTeam.DataTextField = "Team";
            DropTeam.DataValueField = "Team";
            DropTeam.DataBind();

            DropBranch.DataSource = dt;
            DropBranch.DataTextField = "Branch";
            DropBranch.DataValueField = "Branch";
            DropBranch.DataBind();






        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Generate values('" + TxtDate.Text + "','" + DropArea.SelectedValue + "','" + DropBranch.SelectedValue + "','" + DropTeam.SelectedValue + "','" + TxtStart.Text + "','" + TxtEnd.Text + "','" + TxtQuantity.Text + "')", con   );
            cmd.ExecuteNonQuery();
            con.Close();
            TxtDate.Text = "";


        }
    }
}