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
    public partial class AddAdmin : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddAdmin_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();
            var ConPassword = txtConfirmPassword.Text.Trim();
    

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateAdmin", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Username", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password ", txtPassword.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
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
                lblError.Text = "New Admin added Successfully!";

            }
            else
            {
                lblError.Text = "Error!";
            }
        }

        private void Clear()
        {
            hfId.Value = "";
            txtEmail.Text = txtPassword.Text = txtFirstName.Text = txtLastName.Text = "";
            lblError.Text = "";
        }
    }
}