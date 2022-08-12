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
using Microsoft.Reporting.WebForms;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;

namespace BIOSproject
{
    public partial class Warehouse_InquiryForm : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        String ConnectionString2 = @"Data Source = 172.19.2.140; Initial Catalog = LBC_Tracer; Persist Security Info=True;User ID = nds_user;Password=nds_user";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;

        DataTable dt = new DataTable();
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
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select Username From Users Where Username = @Username", sqlCon);
                    cmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hfWareEmail.Value = dr.GetString(0).ToString();
                    }
                    sqlCon.Close();
                    FillGridView();
                    txtDated.Text = DateTime.Now.ToString("yyyy-dd-MM").ToString();

                    if (ViewState["Records"] == null)
                    {
                        ViewState["Records"] = dt;
                    }
                    Calendar1.Visible = false;
                }

            }
        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[WarehouseTagging]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Warehouse", hfWareEmail.Value);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        protected void btnInquiry_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ModalInquiry.Show();
            txtTracking.Text = "";
            txtArea.Text = "";
            txtTeam.Text = "";
            txtBranch.Text = "";
            txtDateTracking.Text = "";
            txtStartTracking.Text = "";
            txtEndTracking.Text = "";
            DDLcode.Visible = false;
            lblCodeNo.Visible = false;
            lblCode.Visible = false;
        }
        void FilterRecords()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[WarehouseDateFilter]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Date", txtDated.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            DDLcode.Visible = false;
            txtSearch.Text = "";
            FilterRecords();
            lblCodeNo.Visible = false;
            lblCode.Visible = false;
        }

        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[WarehousePerFilter]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = false;
            //Gridview1.Columns[4].Visible = true;
        }
        void fill2()
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[WarehousePerFilter]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = true;
            //Gridview1.Columns[4].Visible = false;
        }
        void fill3()
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[LBC.BIOS].[lbcbios].[WarehousePerFilter]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = true;
            //Gridview1.Columns[4].Visible = false;
        }

        protected void DropPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropPer.SelectedItem.Value == "B")
            {
                txtSearch.Text = "";
                DDLcode.Visible = false;
                lblCodeNo.Visible = false;
                lblCode.Visible = false;
                fill();
            }
            else if (DropPer.SelectedItem.Value == "W")
            {
                txtSearch.Text = "";
                DDLcode.Visible = false;
                lblCodeNo.Visible = false;
                lblCode.Visible = false;
                fill2();
            }
            else if (DropPer.SelectedItem.Value == "S")
            {
                txtSearch.Text = "";
                DDLcode.Visible = false;
                lblCodeNo.Visible = false;
                lblCode.Visible = false;
                FillGridView();
            }
            else if (DropPer.SelectedItem.Value == "H")
            {
                txtSearch.Text = "";
                DDLcode.Visible = false;
                lblCodeNo.Visible = false;
                lblCode.Visible = false;
                fill3();
            }
        }
        protected void txtTracking_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtTracking.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select Area, Team, Branch, ScheduleDate, StartingSeries, EndingSeries from [LBC.BIOS].[lbcbios].[FinishedGood] where StartingSeries <= @search and EndingSeries >= @search", sqlCon);
                cmd.Parameters.AddWithValue("@search", txtTracking.Text);
                cmd.Parameters.AddWithValue("@Supplier", hfWareEmail.Value);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtArea.Text = dr.GetValue(0).ToString();
                    txtTeam.Text = dr.GetValue(1).ToString();
                    txtBranch.Text = dr.GetValue(2).ToString();
                    txtDateTracking.Text = dr.GetValue(3).ToString();
                    txtStartTracking.Text = dr.GetValue(4).ToString();
                    txtEndTracking.Text = dr.GetValue(5).ToString();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else
            {
                txtArea.Text = "";
                txtTeam.Text = "";
                txtBranch.Text = "";
                txtDateTracking.Text = "";
                txtStartTracking.Text = "";
                txtEndTracking.Text = "";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtTracking.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select Area, Team, Branch, ScheduleDate, StartingSeries, EndingSeries from [LBC.BIOS].[lbcbios].[FinishedGood] where StartingSeries <= @search and EndingSeries >= @search", sqlCon);
                cmd.Parameters.AddWithValue("@search", txtTracking.Text);
                cmd.Parameters.AddWithValue("@Supplier", hfWareEmail.Value);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtArea.Text = dr.GetValue(0).ToString();
                    txtTeam.Text = dr.GetValue(1).ToString();
                    txtBranch.Text = dr.GetValue(2).ToString();
                    txtDateTracking.Text = dr.GetValue(3).ToString();
                    txtStartTracking.Text = dr.GetValue(4).ToString();
                    txtEndTracking.Text = dr.GetValue(5).ToString();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else
            {
                txtArea.Text = "";
                txtTeam.Text = "";
                txtBranch.Text = "";
                txtDateTracking.Text = "";
                txtStartTracking.Text = "";
                txtEndTracking.Text = "";
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "[LBC.BIOS].[lbcbios].[WarehousePrint]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Desti", Session["Username"].ToString());
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            RvSuppPrint.LocalReport.DataSources.Add(new ReportDataSource("DataSetWarehousePrint", dt));
            RvSuppPrint.LocalReport.ReportPath = Server.MapPath("~/Report/ReportWarehousePrint.rdlc");
            RvSuppPrint.LocalReport.EnableHyperlinks = true;
            FillGridView();
            txtSearch.Text = "";
            ModalPrint.Show();
        }
        protected void btnCloseDetails_Click(object sender, EventArgs e)
        {
            ModalDetails.Hide();
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                FillGridView();
                DDLcode.Visible = false;
                lblCode.Visible = false;
                lblCodeNo.Visible = false;
                DDLcode.SelectedValue = "S";
            }
            else
            {
                string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(maincon);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                string sqlquery = "select * from [LBC.BIOS].[lbcbios].[FinishedGood] where Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse(Alabang)' and DestinationTo != ''";
                sqlcmd.CommandText = sqlquery;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                sda.Fill(dt);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                DDLcode.Visible = true;
            }
        }

        protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridview1.PageIndex = e.NewPageIndex;
            this.FillGridView();
        }
        protected void DDLcode_TextChanged(object sender, EventArgs e)
        {
            if (DDLcode.SelectedValue != "S")
            {
                string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(maincon);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                string sqlquery = "select * from [LBC.BIOS].[lbcbios].[FinishedGood] where Product like '%'+@Product+'%' and Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse(Alabang)' and DestinationTo != ''";
                sqlcmd.CommandText = sqlquery;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@Product", DDLcode.Text);
                sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
                SqlDataReader dr = sqlcmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.Read())
                {
                    sqlcon.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                    sda.Fill(dt);
                    Gridview1.DataSource = dt;
                    Gridview1.DataBind();
                    DDLcode.Visible = true;


                    SqlConnection sqlCon2 = new SqlConnection(maincon);
                    sqlCon2.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Sum(isnull(cast(Quantity as float),0)) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product like '%'+@Product+'%' and Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse(Alabang)' and DestinationTo != ''", sqlCon2);
                    cmd.Parameters.AddWithValue("@Product", DDLcode.Text);
                    cmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    if (dr2.Read())
                    {
                        lblCodeNo.Text = dr2.GetValue(0).ToString();
                    }
                    else
                    {
                        lblCodeNo.Text = "0";
                    }
                    sqlCon2.Close();

                    lblCode.Visible = true;
                    lblCodeNo.Visible = true;
                }
                else
                {
                    DataTable dt3 = new DataTable();
                    Gridview1.DataSource = dt3;
                    Gridview1.DataBind();
                    lblCode.Visible = false;
                    lblCodeNo.Visible = false;
                }

            }
            else if (DDLcode.SelectedValue == "S")
            {
                string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(maincon);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                string sqlquery = "select * from [LBC.BIOS].[lbcbios].[FinishedGood] where Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse(Alabang)' and DestinationTo != '' ";
                sqlcmd.CommandText = sqlquery;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                sda.Fill(dt);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                DDLcode.Visible = true;
                lblCode.Visible = false;
                lblCodeNo.Visible = false;
            }
            else
            {
                lblCode.Visible = false;
                lblCodeNo.Visible = false;
                if (txtSearch.Text == "")
                {
                    FillGridView();
                    DDLcode.Visible = false;
                    lblCode.Visible = false;
                    lblCodeNo.Visible = false;
                }
                else
                {
                    DataTable dt3 = new DataTable();
                    Gridview1.DataSource = dt3;
                    Gridview1.DataBind();
                }
            }
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
            }
            Calendar1.Attributes.Add("style", "position:absolute");
            DDLcode.Visible = false;
            lblCodeNo.Visible = false;
            lblCode.Visible = false;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDated.Text = Calendar1.SelectedDate.ToString("yyyy-dd-MM");
            Calendar1.Visible = false;
            txtSearch.Text = "";
            FilterRecords();
            DDLcode.Visible = false;
        }

    }
}