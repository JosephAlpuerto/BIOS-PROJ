using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using ConnectionDB;

namespace BIOSproject
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddAdmin_Click(object sender, EventArgs e)
        {
            var firstName = textFirstName.Text.Trim();
            var lastName = textLastName.Text.Trim();
            var email = textEmail.Text.Trim();
            var password = textPassword.Text.Trim();
            var ConPassword = textConfirmPassword.Text.Trim();

            var admin = new Domain.Admin
            {
                Username = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                CreatedBy ="Admin",
                CreatedDate= DateTime.Now.ToString(),
                UpdatedBy ="Admin",
                UpdatedDate = DateTime.Now.ToString(),
                DeletedDate = null,

            };
            // validations

            if (firstName=="")
            {
                lblError.Text = "Please Enter First Name!";
            }
            else if(lastName=="")
            {
                lblError.Text = "Please Enter Last Name!";
            }
            else if(email=="")
            {
                lblError.Text = "Please Enter Email!";
            }
            else if (password == "")
            {
                lblError.Text = "Please Enter Password!";
            }
            else if(password!=ConPassword)
            {
                lblError.Text = "Password & Confirm Password should be same!";
            }
            else if (AdminDB.Insert(admin))
            {
                lblError.Text = "New Admin added Successfully!";             
               
            }
            else 
            {
                lblError.Text = "Error!";
            }
        }
    }
}