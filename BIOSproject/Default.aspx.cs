using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where Username = '" + txtEmailId.Text + "' ",con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows == true)
                {
                    dr.Read();
                    string email = dr["Username"].ToString();
                    string pw = dr["Password"].ToString();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Username:-" + email);
                    sb.AppendLine("Password:-" + pw);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("lbcbios08@gmail.com", "lolipop312");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(txtEmailId.Text);
                    msg.From = new MailAddress("LBC BIOS..<lbcbios08@gmail.com>");
                    msg.Subject = "Your Password";
                    msg.Body = sb.ToString();
                    client.Send(msg);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Your password has been sent to registered Email!!')", true);
                    txtEmailId.Text = "";
                    //MsgError.Text = "Your password has been sent to registered Email!!";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Invalid Email Id')", true);
                    //MsgError.Text = "Invalid Email Id";
                }
            }
            catch (Exception ex)
            {
                MsgError.Text = "ERROR" + ex.Message.ToString();
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