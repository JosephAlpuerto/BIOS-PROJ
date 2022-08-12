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
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

                if (!IsPostBack)
                {
                    if (Session["Username"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                    FillGridView();
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
                    DropTeam.DataSource = ds;
                    DropTeam.DataTextField = "TeamDescr";
                    DropTeam.DataValueField = "TeamDescr";
                    DropTeam.DataBind();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

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
            }
        private void Clear()
        {
            HiddenField1.Value = "";
            txtProduct.Text = "";
            TxtQuantity.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
            {

            //    con.Open();
            //    SqlCommand sqlcmd = new SqlCommand("Requests", con);
            //    sqlcmd.CommandType = CommandType.StoredProcedure;
            //    sqlcmd.Parameters.AddWithValue("@ID", HiddenField1.Value == "" ? 0 : Convert.ToInt32(HiddenField1.Value));
            //    sqlcmd.Parameters.AddWithValue("@DateRequested", TxtDate.Text.Trim());
            //    sqlcmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Value);
            //    sqlcmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Value);
            //    sqlcmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Value);
            //    sqlcmd.Parameters.AddWithValue("@Product", txtProduct.Text.Trim());
            //    sqlcmd.Parameters.AddWithValue("@Quantity", TxtQuantity.Text.Trim());
            //    sqlcmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
            //    sqlcmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
            //    sqlcmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
            //    sqlcmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
            //    sqlcmd.Parameters.AddWithValue("@Done", "0");
            //    sqlcmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            //    sqlcmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            //    sqlcmd.ExecuteNonQuery();
            //    FillGridView();
            //    if (HiddenField1.Value == "")
            //    {
            //    Clear();
            //        lblSuccess.Text = "New Request added Successfully!";
            //    FillGridView();
            //}
            //    con.Close();
            }

        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("AllRequestedforUser", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvListRequest.DataSource = dtbl;
            gvListRequest.DataBind();
            gvListRequest.UseAccessibleHeader = true;
            gvListRequest.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvListRequest.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void btnAddRequest_Click(object sender, EventArgs e)
        {
            ModalRequest.Show();
        }

        protected void CloseAddRequest_Click(object sender, EventArgs e)
        {
            ModalRequest.Hide();
            Clear();
        }
    }
    }