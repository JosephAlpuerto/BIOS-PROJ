using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace BIOSproject
{
    public partial class Gen : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

                if (!IsPostBack)
                {

                    string maincon = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                    string sqlquery = "select * from Areas";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, conn);
                    conn.Open();
                    SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    DropArea.DataSource = dt;
                    DropArea.DataTextField = "AreaDescr";
                    DropArea.DataValueField = "AreaDescr";
                    DropArea.DataBind();
                    conn.Close();


                string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                string sqlqueryy = "select * from ref_Branches";
                SqlCommand sqlcom = new SqlCommand(sqlqueryy, conn);
                con.Open();
                SqlDataAdapter sd = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropTeam.Items.Add(ds.Tables[0].Rows[i][5] + "--" + ds.Tables[0].Rows[i][4]);
                    DropBranch.Items.Add(ds.Tables[0].Rows[i][1] + "--" + ds.Tables[0].Rows[i][2]);
                }





                //string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                //string sqlqueryy = "select * from ref_Branches";
                //SqlCommand sqlcom = new SqlCommand(sqlqueryy, conn);
                //conn.Open();
                //SqlDataAdapter sd = new SqlDataAdapter(sqlcom);
                //DataTable dtt = new DataTable();
                //DataSet ds = new DataSet();
                //sd.Fill(dtt);
                //string Team1 = "TeamDescr".ToString();
                //string Team2 = "TeamCode".ToString();
                //DropTeam.DataSource = dtt;
                //DropTeam.DataValueField = "TeamDescr";
                //DropTeam.DataTextField = "TeamDescr" + "TeamCode";
                //DropTeam.DataBind();
                //conn.Close();

                //sd.Fill(ds);
                //DropBranch.DataSource = ds;
                //DropBranch.DataValueField = "BranchDescr";
                //DropBranch.DataTextField = "BranchDescr";
                //DropBranch.DataBind();


            }
            }
            protected void Button1_Click(object sender, EventArgs e)
            {

                con.Open();
                SqlCommand sqlcmd = new SqlCommand("Requests", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ID", HiddenField1.Value == "" ? 0 : Convert.ToInt32(HiddenField1.Value));
                sqlcmd.Parameters.AddWithValue("@DateRequested", TxtDate.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Value);
                sqlcmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Value);
                sqlcmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Value);
                sqlcmd.Parameters.AddWithValue("@Product", txtProduct.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Quantity", TxtQuantity.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
                sqlcmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
                sqlcmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
                sqlcmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
                sqlcmd.Parameters.AddWithValue("@Done", "0");
                sqlcmd.ExecuteNonQuery();
                if (HiddenField1.Value == "")
                {
                    Response.Write("<script>alert('Request Sent');</script>");
                    txtProduct.Text = "";
                    TxtQuantity.Text = "";
                }
                con.Close();
            }
        }
    }