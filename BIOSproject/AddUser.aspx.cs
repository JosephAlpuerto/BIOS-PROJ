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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            

        protected void buttonAddUser_Click(object sender, EventArgs e)
        {
                var firstName = textUFirstName.Text.Trim();
                var lastName = textULastName.Text.Trim();
                var email = textUEmail.Text.Trim();
                var password = textUPassword.Text.Trim();
                var ConPassword = textUConfirmPassword.Text.Trim();
                var mobile = textUNumber.Text.Trim();




            var user = new Domain.Users
            {
                Username = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                MobileNumber = mobile

                };
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
                    lblError.Text = "Please Enter Mobile Number!";
                }
                else if (password == "")
                {
                    lblError.Text = "Please Enter Password!";
                }
                else if (password != ConPassword)
                {
                    lblError.Text = "Password & Confirm Password should be same!";
                }
                else if (AdminDB.Insert(user))
                {
                    lblError.Text = "New User added Successfully!";

                }
                else
                {
                    lblError.Text = "Error!";
                }
            }
        }
    }
