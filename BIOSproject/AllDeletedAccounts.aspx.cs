using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIOSproject.FolConnectionDB;
using Microsoft.Reporting.WebForms;

namespace BIOSproject
{
    public partial class AllDeletedAccounts : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                FillGridView();
                FillGridView1();
            }
        }
        /*protected void btnPrint_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Admin_SelectAllDeleted";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportAdmin.LocalReport.DataSources.Add(new ReportDataSource("DataSetAdmin", dt));
            ReportAdmin.LocalReport.ReportPath = Server.MapPath("~/Report/ReportAdmin.rdlc");
            ReportAdmin.LocalReport.EnableHyperlinks = true;
            ModalAdmin.Show();
        }*/
        /*protected void btnPrint1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Users_SelectAllDeleted";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportAdmin.LocalReport.DataSources.Add(new ReportDataSource("DataSetAdmin", dt));
            ReportAdmin.LocalReport.ReportPath = Server.MapPath("~/Report/ReportUsers.rdlc");
            ReportAdmin.LocalReport.EnableHyperlinks = true;
            ModalUser.Show();
        }*/
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ContactViewAllDeleted", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvList.DataSource = dtbl;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
            //gvList.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        void FillGridView1()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ContactViewAllUsersDeleted", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvList1.DataSource = dtbl;
            gvList1.DataBind();
            gvList1.UseAccessibleHeader = true;
            gvList1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //gvList1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void Activate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewActivateUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtEmail.Text = dtbl.Rows[0]["Username"].ToString();
            txtFname.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtLname.Text = dtbl.Rows[0]["LastName"].ToString();
            txtMobile.Text = dtbl.Rows[0]["MobileNumber"].ToString();
            ModalActivateAdmin.Show();
        }
        protected void Activate1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewActivateUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId1.Value = Id.ToString();
            txtEmail1.Text = dtbl.Rows[0]["Username"].ToString();
            txtFname1.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtLname1.Text = dtbl.Rows[0]["LastName"].ToString();
            txtMobile1.Text = dtbl.Rows[0]["MobileNumber"].ToString();
            ModalActivateUsers.Show();
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ActivateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPassword.Value == "" ? 0 : Convert.ToChar(hfPassword.Value)));
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            FillGridView1();
            lblSuccess1.Text = "Activate Successfully";
            
           
        }
        public void Clear()
        {
            hfId.Value = "";
            txtEmail.Text =  txtFname.Text = txtLname.Text = "";
            lblSuccess.Text = lblError.Text = "";
        }
        protected void btnCloseView_Click(object sender, EventArgs e)
        {
            Clear();
            Clearlbl();
            ModalActivateAdmin.Hide();
            FillGridView();
            FillGridView1();
        }

        protected void btnActivateUsers_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ActivateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPassword1.Value == "" ? 0 : Convert.ToChar(hfPassword1.Value)));
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            FillGridView1();
            lblSuccess2.Text = "Activate Successfully";
            
            
        }

        protected void btnCloseViewUsers_Click(object sender, EventArgs e)
        {
            Clear();
            Clearlbl();
            ModalActivateUsers.Hide();
            FillGridView1();
            FillGridView();
        }
        public void Clearlbl()
        {
            lblSuccess1.Text = lblSuccess2.Text = "";
        }
    }
}