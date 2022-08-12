using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace BIOSproject
{
    public partial class WarehouseReport : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
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
        //FillGridView();
                    FilterRecords();
                    //Search();
                    if (!IsPostBack)
                    {
                        TxtFromDate.Text = DateTime.Now.ToString("yyyy-dd-MM").ToString();
                        TxtToDate.Text = DateTime.Now.ToString("yyyy-dd-MM").ToString();

                        Calendar1.Visible = false;
                        Calendar2.Visible = false;
                    }
            }

            
        }




        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[ReportSearch]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@search", TxtSearch.Text);
            //sqlData.SelectCommand.Parameters.AddWithValue("@search1", TxtSearch.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        void Search()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[ReportSearch]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@search", TxtSearch.Text);
            //sqlData.SelectCommand.Parameters.AddWithValue("@search1", TxtSearch.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;


        }


        void FilterRecords()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[DateFilter1]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Date", TxtFromDate.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Date2", TxtToDate.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void BtnDateDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[DateFilter1]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Date", TxtFromDate.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Date2", TxtToDate.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            TxtSearch.Text = "";
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text == "")
            {
                LblAlert.Text = "Please input Tracking Series";
            }


            string series = TxtSearch.Text;
            string[] num = series.Split(',').Select(n => string.Format("'{0}'", n.Trim())).ToArray();
            string sql = string.Format("SELECT * FROM [LBC.BIOS].[lbcbios].[FinishedGood] WHERE StartingSeries in ({0}) or EndingSeries in ({0})", string.Join(",", num));
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, sqlCon);
            //sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@search1", TxtSearch.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            TxtSearch.Text += ", ";
            TxtSearch.Focus();

            var position = TxtSearch.Text.IndexOf(TxtSearch.Text) + TxtSearch.Text.Length + 1;
            var script = String.Format("setCursorPosition('{0}',{1});", TxtSearch.ClientID, position);
            ClientScript.RegisterStartupScript(GetType(), "CursorScript", script, true);


        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = "";
            Response.Redirect("WarehouseReport.aspx");
        }

        protected void BtnDateDisplay_Click1(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[DateFilter1]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Date", TxtFromDate.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Date2", TxtToDate.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            TxtSearch.Text = "";
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
                Calendar2.Visible = false;
            }
            Calendar1.Attributes.Add("style", "position:absolute");
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
                Calendar1.Visible = false;
            }
            Calendar2.Attributes.Add("style", "position:absolute");
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TxtFromDate.Text = Calendar1.SelectedDate.ToString("yyyy-dd-MM");
            Calendar1.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TxtToDate.Text = Calendar2.SelectedDate.ToString("yyyy-dd-MM");
            Calendar2.Visible = false;
        }
    }
}