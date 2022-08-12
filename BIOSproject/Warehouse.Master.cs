﻿using System;
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

namespace BIOSproject.Hub
{
    public partial class Warehouse : System.Web.UI.MasterPage
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["Username"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select FirstName From Users Where Username = @Username", sqlCon);
                cmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtUserName.Text = dr.GetString(0).ToString();
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var textEmail = txtEmailId.Text.Trim();
                string cs = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where Username = '" + txtEmailId.Text + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    string email = dr["Username"].ToString();
                    string pw = dr["Password"].ToString();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Username: " + email);
                    sb.AppendLine("Password: " + AllUsers.DecryptData(pw));
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
                else if (textEmail == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Enter Email!!')", true);
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
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}