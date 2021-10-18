using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIOSproject
{
    public partial class Default : System.Web.UI.Page
    {
        static String connectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'",con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count != 0)
                {
                   
                    string roleType;
                    roleType = dt.Rows[0][13].ToString().Trim();
                    if (roleType == "Sourcing")
                    {
                        Session["Username"] = txtUsername.Text.ToString();
                        Response.Redirect("~/AllUsers.aspx");
                    }
                    if (roleType == "Supplier")
                    {
                        Session["Username"] = txtUsername.Text.ToString();
                        Response.Redirect("~/AllSupplierRequest.aspx");
                    }
                    if (roleType == "Hub")
                    {
                        Session["Username"] = txtUsername.Text.ToString();
                        Response.Redirect("~/Hub/HubList.aspx");
                    }
                }
          
                else
                {
                    lblError.Text = "Invalid Username or Password ";
                }
            }

        }


        /* protected void btnLogin_Click(object sender, EventArgs e)
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
         }*/

        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(connectionString);
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "loginUser";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
        //        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
        //        cmd.Parameters.AddWithValue("@RoleType", DropDownList.Text.ToString());

        //        con.Open();

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            Session["Username"] = txtUsername.Text.ToString();
        //            lblError.Text = "Login Successful! ";

        //            reader.Close();
        //            if (DropDownList.SelectedValue == "Admin")
        //            {
        //                Response.Redirect("AllUsers.aspx");
        //            }
        //            else if(DropDownList.SelectedValue == "User")
        //            {
        //                Response.Redirect("RequestForm.aspx");
        //            }
        //            else if (DropDownList.SelectedValue == "Branch")
        //            {
        //                Response.Redirect("Supplier/ValidateSupplier.aspx");
        //            }
        //            con.Close();

        //        }
        //        else
        //        {
        //            lblError.Text = "Invalid Username, Password or Role! "; 
        //        }

        //        reader.Close();
        //        con.Close();
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
    }
}