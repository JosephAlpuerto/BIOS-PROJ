using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using ConnectionDB;
using System.Data.SqlClient;
using System.Data;

namespace BIOSproject
{
    public partial class AddUser : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            

        protected void buttonAddUser_Click(object sender, EventArgs e)
        {
                var firstName = txtUFirstName.Text.Trim();
                var lastName = txtULastName.Text.Trim();
                var email = txtUEmail.Text.Trim();
                var password = txtUPassword.Text.Trim();
                var ConPassword = txtUConfirmPassword.Text.Trim();
                var mobile = txtUNumber.Text.Trim();

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateUsers", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtUEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtUPassword.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtUFirstName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtULastName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MobileNumber", txtUNumber.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            //sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            string Id = hfId.Value;
            // validations

            if (firstName == "")
                {
                    lblError.Text = "Please Enter First Name!";
                }
                else if (lastName == "")
                {
                    lblError.Text = "Please Enter Last Name!";
                }
                else if (email == "")
                {
                    lblError.Text = "Please Enter Email!";
                }
                else if (mobile == "")
                {
                    lblError.Text = "Please Enter Mobile Number!";
                }
                else if (mobile == "[0-9]{10}")
                {
                    lblError.Text = "Please Check Mobile Number!";
                }
                else if (password == "")
                {
                    lblError.Text = "Please Enter Password!";
                }
                else if (password != ConPassword)
                {
                    lblError.Text = "Password & Confirm Password should be same!";
                }
                else if (Id == "")
                {
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    sqlCon.Close();
                    lblError.Text = "New User added Successfully!";

                }
                else
                {
                    lblError.Text = "Error!";
                }
            }
        private void Clear()
        {
            hfId.Value = "";
            txtUEmail.Text = txtUPassword.Text = txtUFirstName.Text = txtULastName.Text = txtUNumber.Text = "";
            lblError.Text = "";
        }
    }
    }
