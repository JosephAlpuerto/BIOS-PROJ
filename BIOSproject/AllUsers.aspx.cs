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
    public partial class AllUsers : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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

            ReportUsers.LocalReport.DataSources.Add(new ReportDataSource("DataSetUsers", dt));
            ReportUsers.LocalReport.ReportPath = Server.MapPath("~/Report/ReportUsers.rdlc");
            ReportUsers.LocalReport.EnableHyperlinks = true;
            FillGridView();
            ModalUsers.Show();
        }

        protected void LinkView_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //int IsActive = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ContactViewByIdUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            //sqlData.SelectCommand.Parameters.AddWithValue("@IsActivate", IsActive);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtEmail.Text = dtbl.Rows[0]["Username"].ToString();
            txtFname.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtLname.Text = dtbl.Rows[0]["LastName"].ToString();
            txtMobile.Text = dtbl.Rows[0]["MobileNumber"].ToString();
            string IsActive = dtbl.Rows[0]["IsActive"].ToString();
            btnSave.Text = "Update";
            if(IsActive == "True")
            {
                btnActivate.Visible = false;
                btnDelete.Visible = true;
                FillGridView();
                ModalView.Show();
            }
            else
            {
                btnActivate.Visible = true;
                btnDelete.Visible = false;
                FillGridView();
                ModalView.Show();
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfId.Value = "";
            txtEmail.Text =  txtFname.Text = txtLname.Text = txtMobile.Text = "";
            lblSuccess.Text = lblError.Text = "";
            btnSave.Text = "Save";
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var firstName = txtFname.Text.Trim();
            var lastName = txtLname.Text.Trim();
            var email = txtEmail.Text.Trim();
            var mobile = txtMobile.Text.Trim();

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateOrUpdateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPass.Value == "" ? 0 : Convert.ToChar(hfPass.Value)));
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
          
            string Id = hfId.Value;
            if (email == "")
            {
                lblError.Text = "Please Enter Email!";
            }
            else if (firstName == "")
            {
                lblError.Text = "Please Enter First Name!";
            }
            else if (lastName == "")
            {
                lblError.Text = "Please Enter Last Name!";
            }
            else if (mobile == "")
            {
                lblError.Text = "Please Enter Mobile Number!";
            }
            else if (mobile == "[0-9]{10}")
            {
                lblError.Text = "Please Check Mobile Number!";
            }
            else if (Id == "")
            {
                lblError.Text = "Saved Successfully";
            }
            else
            {
                Clear();
                FillGridView();
                lblSuccess.Text = "Updated Successfully!";
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
               
            }


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
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPass.Value == "" ? 0 : Convert.ToChar(hfPass.Value)));
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text.Trim());
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
        protected void btnActivate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ActivateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", (hfPass.Value == "" ? 0 : Convert.ToChar(hfPass.Value)));
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
            lblSuccess.Text = "Activate Successfully";
        }
        protected void btnCloseView_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalAddUser.Show();
        }
        protected void buttonAddUser1_Click(object sender, EventArgs e)
        {
            var firstName = txtUFirstName1.Text.Trim();
            var lastName = txtULastName1.Text.Trim();
            var email = txtUEmail1.Text.Trim();
            var password = txtUPassword1.Text.Trim();
            var ConPassword = txtUConfirmPassword1.Text.Trim();
            var mobile = txtUNumber1.Text.Trim();

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtUEmail1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtUPassword1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtUFirstName1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtULastName1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtUNumber1.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@RoleType", DropDownList.SelectedItem.Value);
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
            else if (mobile == "")
            {
                lblError1.Text = "Please Enter Mobile Number!";
            }
            else if (mobile == "[0-9]{10}")
            {
                lblError1.Text = "Please Check Mobile Number!";
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
                lblError1.Text = "New User added Successfully!";
                FillGridView();
            }
            else
            {
                lblError1.Text = "Error!";
            }
        }
        private void Clear1()
        {
            hfId1.Value = "";
            txtUEmail1.Text = txtUPassword1.Text = txtUFirstName1.Text = txtULastName1.Text = txtUNumber1.Text = "";
            lblError.Text = "";
        }

        protected void AddUserbtn_Click(object sender, EventArgs e)
        {
            Clear1();
            FillGridView();
            ModalAddUser.Hide();
            
        }

        protected void LinkViewReset_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //string password = Convert.ToString((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewResetUser", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            //sqlData.SelectCommand.Parameters.AddWithValue("@Password", password);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfIdReset.Value = Id.ToString();
            hfPassReset.Value = dtbl.Rows[0]["Password"].ToString();
            txtEmailReset.Text = dtbl.Rows[0]["Username"].ToString();
            FillGridView();
            ModalResetPass.Show();
            
        }

        protected void btnCloseReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);

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
            SqlCommand sqlCmd = new SqlCommand("ResetPasswordUser", sqlCon);
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
                FillGridView();
                lblSuccessReset.Text = "Password Reset Successfully!";
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                
            }

        }

        protected void btnAllActive_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("AllActiveUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvActive.DataSource = dtbl;
            gvActive.DataBind();
            gvActive.FooterRow.TableSection = TableRowSection.TableFooter;
            FillGridView();
            ModalAllActive.Show();
           
        }

        protected void btnCloseAllActive_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalAllActive.Hide();
            
        }

        protected void btnAllDeactive_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("AllDeactiveUsers", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvAllDeactive.DataSource = dtbl;
            gvAllDeactive.DataBind();
            gvAllDeactive.FooterRow.TableSection = TableRowSection.TableFooter;
            FillGridView();
            ModalAllDeactive.Show();
            
        }

        protected void btnCloseAllDeactive_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalAllDeactive.Hide();
            
        }

        protected void btnAllAdmin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("AllAdminAccounts", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvAllAdmin.DataSource = dtbl;
            gvAllAdmin.DataBind();
            gvAllAdmin.FooterRow.TableSection = TableRowSection.TableFooter;
            FillGridView();
            ModalAllAdmin.Show();
           
        }

        protected void btnCloseAllADmin_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalAllAdmin.Hide();
           
        }

        protected void btnAllUser_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("AllUsersAccounts", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvAllUser.DataSource = dtbl;
            gvAllUser.DataBind();
            gvAllUser.FooterRow.TableSection = TableRowSection.TableFooter;
            FillGridView();
            ModalAllUser.Show();
           
        }

        protected void btnCloseAllUser_Click(object sender, EventArgs e)
        {
            FillGridView();
            ModalAllUser.Hide();
           
        }

        protected void AddUserbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        
    }
}