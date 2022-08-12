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
    public partial class SouringReports : System.Web.UI.Page
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
            FillGridView();
            gvlist.Visible = true;
            gvlist2.Visible = false;
            gvlist3.Visible = false;
            }
            
        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist.DataSource = dtbl;
            gvlist.DataBind();
            gvlist.UseAccessibleHeader = true;
            gvlist.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView2()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport2]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist2.DataSource = dtbl;
            gvlist2.DataBind();
            gvlist2.UseAccessibleHeader = true;
            gvlist2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView3()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport3]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist2.DataSource = dtbl;
            gvlist2.DataBind();
            gvlist2.UseAccessibleHeader = true;
            gvlist2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView4()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport4]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchSupp", ddlSupplier.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist3.DataSource = dtbl;
            gvlist3.DataBind();
            gvlist3.UseAccessibleHeader = true;
            gvlist3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView5()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport5]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchSupp", ddlSupplier.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist3.DataSource = dtbl;
            gvlist3.DataBind();
            gvlist3.UseAccessibleHeader = true;
            gvlist3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView6()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport6]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchSupp", ddlSupplier.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist3.DataSource = dtbl;
            gvlist3.DataBind();
            gvlist3.UseAccessibleHeader = true;
            gvlist3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView7()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport7]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchSupp", ddlSupplier.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist3.DataSource = dtbl;
            gvlist3.DataBind();
            gvlist3.UseAccessibleHeader = true;
            gvlist3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView8()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[SourcingReport8]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist2.DataSource = dtbl;
            gvlist2.DataBind();
            gvlist2.UseAccessibleHeader = true;
            gvlist2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select REVERSE(PARSENAME(REPLACE(REVERSE(Product), '-', '.'), 1)) as Material, REVERSE(PARSENAME(REPLACE(REVERSE(Product), '-', '.'), 2)) as ProductCode,COUNT(*) as qty from [LBC.BIOS].[lbcbios].[FinishedGood] where Product like @Search + '%' group by Product";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["Material"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;
                }
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList1(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select SupplierName, COUNT(*) as qty from [LBC.BIOS].[lbcbios].[FinishedGood] where SupplierName like @Search + '%' group by SupplierName";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames1 = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames1.Add(sdr["SupplierName"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames1;
                }
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList2(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select PONumber,COUNT(*) as PO from [LBC.BIOS].[lbcbios].[FinishedGood] where PONumber like @Search + '%' group by PONumber";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames2 = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames2.Add(sdr["PONumber"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames2;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSupplier.Text == "" && ddlProduct.Text == "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "filltextbox()", true);
                gvlist.Visible = true;
            }
            else if (ddlSupplier.Text == "" && ddlProduct.Text == "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView2();
                gvlist.Visible = false;
                gvlist2.Visible = true;
                gvlist3.Visible = false;
            }
            else if (ddlSupplier.Text == "" && ddlProduct.Text != "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView3();
                gvlist.Visible = false;
                gvlist2.Visible = true;
                gvlist3.Visible = false;
            }
            else if (ddlSupplier.Text == "" && ddlProduct.Text != "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView8();
                gvlist.Visible = false;
                gvlist2.Visible = true;
                gvlist3.Visible = false;
            }
            else if (ddlSupplier.Text != "" && ddlProduct.Text == "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView4();
                gvlist.Visible = false;
                gvlist2.Visible = false;
                gvlist3.Visible = true;
            }
            else if (ddlSupplier.Text != "" && ddlProduct.Text != "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView6();
                gvlist.Visible = false;
                gvlist2.Visible = false;
                gvlist3.Visible = true;
            }
            else if (ddlSupplier.Text != "" && ddlProduct.Text == "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView7();
                gvlist.Visible = false;
                gvlist2.Visible = false;
                gvlist3.Visible = true;
            }
            else if (ddlSupplier.Text != "" && ddlProduct.Text != "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView5();
                gvlist.Visible = false;
                gvlist2.Visible = false;
                gvlist3.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlSupplier.Text = "";
            ddlProduct.Text = "";
            ddlPO.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}