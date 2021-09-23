﻿using System;
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
    public partial class AllUsers : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                FillGridView();
            }
        }

        /*private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList1();
            if (list.Count <= 0)
            {
                return;
            }
            gvList1.DataSource = list;
            gvList1.DataBind();

            gvList1.UseAccessibleHeader = true;
            gvList1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList1.FooterRow.TableSection = TableRowSection.TableFooter;
        }*/

        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ContactViewAllUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvList1.DataSource = dtbl;
            gvList1.DataBind();
            gvList1.UseAccessibleHeader = true;
            gvList1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void btnPrint2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Users_SelectAll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportUsers.LocalReport.DataSources.Add(new ReportDataSource("DataSetUser", dt));
            ReportUsers.LocalReport.ReportPath = Server.MapPath("~/Report/ReportUsers.rdlc");
            ReportUsers.LocalReport.EnableHyperlinks = true;
            ModalUsers.Show();
        }

        protected void LinkView_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ContactViewByIdUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtEmail.Text = dtbl.Rows[0]["Username"].ToString();
            txtPass.Text = dtbl.Rows[0]["Password"].ToString();
            txtFname.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtLname.Text = dtbl.Rows[0]["LastName"].ToString();
            txtMobile.Text = dtbl.Rows[0]["MobileNumber"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
            ModalView.Show();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfId.Value = "";
            txtEmail.Text = txtPass.Text = txtFname.Text = txtLname.Text = txtMobile.Text = "";
            lblSuccess.Text = lblError.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateOrUpdateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtPass.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", "Admin");
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string Id = hfId.Value;
            Clear();
            if (Id == "")
                lblSuccess.Text = "Saved Successfully";
            else
                lblSuccess.Text = "Updated Successfully";
            FillGridView();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ContactDeleteByIdUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtPass.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "0");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", "Admin");
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", "Admin");
            sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccess.Text = "Deleted Successfully";
        }
        protected void btnCloseView_Click(object sender, EventArgs e)
        {
            Clear();
            ModalView.Hide();
        }
    }
}