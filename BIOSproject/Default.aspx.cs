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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim()=="" || txtPassword.Text.Trim()=="")
            {
                this.lblError.Text = "Please Enter Username and Password!";
            }
            else
            {
                this.lblError.Text = "";

                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();

                var obj = new Admin
                {
                    Username = username,
                    Password = password
                };

                var admin = AdminDB.CheckLogin(obj);

                if(admin!=null)
                {
                    Response.Redirect("SB-admin.aspx");
                }
                else
                {
                    lblError.Text = "Invalid Username or Password!";
                }
            }
        }
    }
}