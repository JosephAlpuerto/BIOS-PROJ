using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

namespace BIOSproject.Supplier
{
    public partial class SupplierList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection coon = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                string sqlqueryy = "select * from ref_Branches where TeamDescr != '"+null+"'";
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
            }

        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierRequestShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;

        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {

            ModalRequest.Show();
            FillGridView();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           

        }
      
    

        private void Clear()
        {
            hfId.Value = "";
            lblSuccess.Text = "";
        }

        

        

       

        
      

        protected void btnValidateSeries_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalValidateSeries.Show();
        }
        protected void hitCheckCloseSeries_Click(object sender, EventArgs e)
        {
            Clear2();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        private void Clear2()
        {
            TxtSearchSeries.Text = "";
            //TxtStart.Text = TxtEnd.Text = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int start = new int();
            int end = new int();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SearchSeries";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", TxtSearchSeries.Text);
            cmd.Parameters.AddWithValue("@startmin", start);
            cmd.Parameters.AddWithValue("@endmax", end);
            conn.Open();
            SqlCommand sql = new SqlCommand();
            string sqlquery = "select * from SSPRequest where StartingSeries like '%'+@start+'%' or EndingSeries like '%'+@end+'%' ";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@start", TxtSearchSeries.Text);
            sql.Parameters.AddWithValue("@end", TxtSearchSeries.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            sda.Fill(dt);

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This Series is already use!')", true);
                gridview.DataSource = dt;
                gridview.DataBind();
                gridview.UseAccessibleHeader = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
            }

            con.Close();
        }

       

       
    }

    }
