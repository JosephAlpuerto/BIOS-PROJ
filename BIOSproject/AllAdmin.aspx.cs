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

    public partial class AllAdmin : System.Web.UI.Page
    {
        //String ConnectionString = @"Data Source=172.25.8.134;Initial Catalog=LBC.BIOS;User ID=lbcbios;Password=lbcbios; Security=True;";
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
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
                    btnDelete.Enabled = false;
                    FillGridView();
                }
               
            }
        }

       
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "[dbo].[Admin_SelectAll]";
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
        }


        /*private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList();
            if(list.Count<=0)
            {
                return;
            }
            gvList.DataSource = list;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList.FooterRow.TableSection = TableRowSection.TableFooter;

        }*/
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[dbo].[ContactViewAll]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvList.DataSource = dtbl;
            gvList.DataBind();
            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfId.Value = "";
            txtEmail.Text = txtPass.Text = txtFname.Text = txtLname.Text = "";
            lblSuccess.Text = lblError.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var firstName = txtFname.Text.Trim();
            var lastName = txtLname.Text.Trim();
            var email = txtEmail.Text.Trim();
            //var password = txtPass.Text.Trim();
            //var ConPassword = txtConfirm.Text.Trim();


            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("[dbo].[IdCreateOrUpdate]", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPass.Value == "" ? 0 : Convert.ToChar(hfPass.Value)));
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            string Id = hfId.Value;

            // validations

            if (firstName == "")
            { lblError.Text = "Please Enter First Name!"; }
            else if (lastName == "")
            { lblError.Text = "Please Enter Last Name!"; }
            else if (email == "")
            { lblError.Text = "Please Enter Email!"; }   
            
            else if (Id == "")
            { lblSuccess.Text = "Saved Successfully!"; }
            else
            {
                Clear();
                lblSuccess.Text = "Updated Successfully!";
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            FillGridView();
            }

        }

                protected void LinkView_OnClick(object sender, EventArgs e)
                {
                    int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("[dbo].[ContactViewById]", sqlCon);
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
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    ModalView.Show();
                }

                protected void btnDelete_Click(object sender, EventArgs e)
                {
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("[dbo].[ContactDeleteById]", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
                    sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password ", txtPass.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@IsActive", "0");
                    sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                    sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
                    sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
                    sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
                    sqlCmd.Parameters.AddWithValue("@DeletedBy", Session["Username"].ToString());
                    sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Clear();
                    FillGridView();
                    lblSuccess.Text = "Deactivate Successfully";
                }

                protected void btnCloseView_Click(object sender, EventArgs e)
                {
                    Clear();
                    ModalView.Hide();
                }

        public void Clear1()
        {
            hfId1.Value = "";
            txtEmail1.Text = txtPassword1.Text = txtFirstName1.Text = txtLastName1.Text = "";
            lblSuccess.Text = lblError1.Text = "";
        }
        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            ModalAddAdmin.Show();
        }

        protected void btnAddAdminClose_Click(object sender, EventArgs e)
        {
            Clear1();
            ModalAddAdmin.Hide();
        }

        protected void AddAdminbtn_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName1.Text.Trim();
            var lastName = txtLastName1.Text.Trim();
            var email = txtEmail1.Text.Trim();
            var password = txtPassword1.Text.Trim();
            var ConPassword = txtConfirmPassword1.Text.Trim();


            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("[lbcbios].[IdCreateAdmin]", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtPassword1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            //sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            string Id = hfId1.Value;

            // validations

            if (firstName == "")
            {
                lblError1.Text = "Please Enter First Name!";
            }
            else if (lastName == "")
            {
                lblError1.Text = "Please Enter Last Name!";
            }
            else if (email == "")
            {
                lblError1.Text = "Please Enter Email!";
            }
            else if (password == "")
            {
                lblError1.Text = "Please Enter Password!";
            }
            else if (password != ConPassword)
            {
                lblError1.Text = "Password & Confirm Password should be same!";
            }
            else if (Id == "")
            {
                sqlCmd.ExecuteNonQuery();
                Clear1();
                sqlCon.Close();
                lblError1.Text = "New Admin added Successfully!";
                FillGridView();
            }
            else
            {
                lblError1.Text = "Error!";
            }
        }

        protected void ViewResetAdmin_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //string password = Convert.ToString((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("[lbcbios].[ViewResetAdmin]", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            //sqlData.SelectCommand.Parameters.AddWithValue("@Password", password);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfIdReset.Value = Id.ToString();
            hfPassReset.Value = dtbl.Rows[0]["Password"].ToString();
            txtEmailReset.Text = dtbl.Rows[0]["Username"].ToString();
            ModalResetPass.Show();
        }
        protected void btnCloseReset_Click(object sender, EventArgs e)
        {
            Clear2();
            ModalResetPass.Hide();
        }
        protected void Clear2()
        {
            hfIdReset.Value = "";
            txtPassReset.Text = txtNewPassReset.Text = txtConfirmReset.Text = "";
            lblErrorReset.Text = lblSuccessReset.Text = "";
        }
        protected void btnSaveReset_Click(object sender, EventArgs e)
        {
            //var firstName = hfFname.Text.Trim();
            //var lastName = txtLname.Text.Trim();
            //var email = txtEmail.Text.Trim();
            var password = txtPassReset.Text.Trim();
            var ConPassword = txtConfirmReset.Text.Trim();
            var NewPass = txtNewPassReset.Text.Trim();
            //var mobile = txtMobile.Text.Trim();

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("[lbcbios].[ResetPasswordAdmin]", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfIdReset.Value == "" ? 0 : Convert.ToInt32(hfIdReset.Value)));
            //sqlCmd.Parameters.AddWithValue("@Username", (hfEmailReset.Value == "" ? 0 : Convert.ToChar(hfEmailReset.Value)));
            sqlCmd.Parameters.AddWithValue("@Password ", txtNewPassReset.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@FirstName", (hfFnameReset.Value == "" ? 0 : Convert.ToChar(hfFnameReset.Value)));
            //sqlCmd.Parameters.AddWithValue("@LastName", (hfLnameReset.Value == "" ? 0 : Convert.ToChar(hfLnameReset.Value)));
            //sqlCmd.Parameters.AddWithValue("@MobileNumber", (hfMobileReset.Value == "" ? 0 : Convert.ToInt64(hfMobileReset.Value)));
            //sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            //sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            //sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);

            string Id = hfIdReset.Value;
            string CurrentPass = hfPassReset.Value;
            if (password == "")
            {
                lblErrorReset.Text = "Please Enter Current Password!";
            }
            else if (password != CurrentPass)
            {
                lblErrorReset.Text = "Please Enter Correct Password!";
            }
            else if (NewPass == "")
            {
                lblErrorReset.Text = "Please Enter New Password!";
            }
            else if (ConPassword == "")
            {
                lblErrorReset.Text = "Please Enter Confirm Password!";
            }
            else if (NewPass != ConPassword)
            {
                lblErrorReset.Text = "Please Check Your New Password!";
            }
            else if (Id == "")
            {
                lblSuccessReset.Text = "Saved Successfully!";
            }
            else
            {
                Clear2();
                lblSuccessReset.Text = "Password Reset Successfully!";
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                btnSaveReset.Enabled = false;
                FillGridView();
            }

        }
    }
}