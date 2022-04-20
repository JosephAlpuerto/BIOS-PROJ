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
    public partial class SupplierReports : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
            gvlist.Visible = true;
            gvlist2.Visible = false;
        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierReport", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierReport2", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierReport3", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvlist2.DataSource = dtbl;
            gvlist2.DataBind();
            gvlist2.UseAccessibleHeader = true;
            gvlist2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView8()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierReport8", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPro", ddlProduct.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@SearchPO", ddlPO.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
                    com.CommandText = "select REVERSE(PARSENAME(REPLACE(REVERSE(Product), '-', '.'), 1)) as Material, REVERSE(PARSENAME(REPLACE(REVERSE(Product), '-', '.'), 2)) as ProductCode,COUNT(*) as qty from FinishedGood where Product like @Search + '%' and Supplier = @Supplier group by Product";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Parameters.AddWithValue("@Supplier", HttpContext.Current.Session["Username"].ToString());
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
                    com.CommandText = "select SupplierName, COUNT(*) as qty from FinishedGood where SupplierName like @Search + '%' and Supplier = @Supplier group by Supplier";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Parameters.AddWithValue("@Supplier", HttpContext.Current.Session["Username"].ToString());
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames1 = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames1.Add(sdr["Supplier"].ToString());
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
                    com.CommandText = "select PONumber,COUNT(*) as PO from FinishedGood where PONumber like @Search + '%' and Supplier = @Supplier group by PONumber";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Parameters.AddWithValue("@Supplier", HttpContext.Current.Session["Username"].ToString());
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
            if (ddlProduct.Text == "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "filltextbox()", true);
                gvlist.Visible = true;
            }
            else if (ddlProduct.Text == "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView2();
                gvlist.Visible = false;
                gvlist2.Visible = true;
            }
            else if (ddlProduct.Text != "" && ddlPO.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView3();
                gvlist.Visible = false;
                gvlist2.Visible = true;
            }
            else if (ddlProduct.Text != "" && ddlPO.Text != "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Goodd()", true);
                FillGridView8();
                gvlist.Visible = false;
                gvlist2.Visible = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlProduct.Text = "";
            ddlPO.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}