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
using System.IO;

namespace BIOSproject
{
    public partial class Supp : System.Web.UI.MasterPage
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = Session["Username"].ToString();
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

        protected void txtStartingScan_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
            sqlCon3.Open();
            if (txtStartingScan.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID,TicketNo,PONumber,Supplier,ProductQuantity,TotalQuantity,Quantity,StartingSeries,EndingSeries,RequestNo,SupplierName From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and ifFinish = '0'", sqlCon3);
                cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartingScan.Text));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ID.Value = dr.GetValue(0).ToString();
                    TicketNo.Value = dr.GetValue(1).ToString();
                    PONumber.Value = dr.GetValue(2).ToString();
                    Supplier.Value = dr.GetValue(3).ToString();
                    ProductQuantity.Value = dr.GetValue(4).ToString();
                    TotalQuantity.Value = dr.GetValue(5).ToString();
                    Quantity.Value = dr.GetValue(6).ToString();
                    StartingSeries.Value = dr.GetValue(7).ToString();
                    EndingSeries.Value = dr.GetValue(8).ToString();
                    RequestNo.Value = dr.GetValue(9).ToString();
                    SupplierName.Value = dr.GetValue(10).ToString();

                    hfEndingSeries2.Value = dr.GetValue(8).ToString();
                    addingScan();

                    lblTotal.Text = dr.GetValue(6).ToString();
                    btnOkay.Visible = true;

                    if (lblScanUnits.Text == lblTotal.Text)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Scan()", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                }
                sqlCon3.Close();
            }
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            txtStartingScan.Text = "";
            lblTotal.Text = "";
            btnOkay.Visible = false;
        }
        public void addingScan()
        {
            //lblUnits.Text = "0";
            double start, end, answer;
            double.TryParse(txtStartingScan.Text, out start);
            double.TryParse(hfEndingSeries2.Value, out end);


            answer = end - start + 1;
            if (answer > 0 && txtStartingScan.Text != "" && hfEndingSeries2.Value != "")
                lblScanUnits.Text = answer.ToString();        
        }
        public void InsertDB()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("InsertFinishGood", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNo", TicketNo.Value);
            cmd.Parameters.AddWithValue("@PONumber", PONumber.Value);
            cmd.Parameters.AddWithValue("@Supplier", Supplier.Value);
            cmd.Parameters.AddWithValue("@Product", ProductQuantity.Value);
            cmd.Parameters.AddWithValue("@TotalQuantity", TotalQuantity.Value);
            cmd.Parameters.AddWithValue("@Quantity", Quantity.Value);
            cmd.Parameters.AddWithValue("@StartingSeries", StartingSeries.Value);
            cmd.Parameters.AddWithValue("@EndingSeries", EndingSeries.Value);
            cmd.Parameters.AddWithValue("@RequestNo", RequestNo.Value);
            cmd.Parameters.AddWithValue("@SupplierName", SupplierName.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@RequestID", ID.Value);
            cmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse(Alabang)");
            cmd.ExecuteNonQuery();
            con.Close();
            finish();
            clearScan();

        }
        public void Scan()
        {
            if (lblScanUnits.Text == lblTotal.Text)
            {
                txtStartingScan.Text = "";
                lblTotal.Text = "";
                if (txtStartingScan.Text == "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Saved()", true);
                }
            }
        }
        public void finish()
        {
            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand sqlCmd = new SqlCommand("ScanFinish", sqlCon2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", ID.Value);
            sqlCmd.Parameters.AddWithValue("@ifFinish", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon2.Close();
        }
        public void clearScan()
        {
            ID.Value = "";
            TicketNo.Value = "";
            PONumber.Value = "";
            Supplier.Value = "";
            ProductQuantity.Value = "";
            TotalQuantity.Value = "";
            Quantity.Value = "";
            StartingSeries.Value = "";
            EndingSeries.Value = "";
            RequestNo.Value = "";
            SupplierName.Value = "";
        }
        protected void btnOkay_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtStartingScan.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID, EndingSeries From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and forHitCheck = '1' and ifSend = '1'  and WHcheck = '0'", sqlCon);
                cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartingScan.Text));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    hfIDScan2.Value = dr.GetValue(0).ToString();
                    hfEndingSeries2.Value = dr.GetValue(1).ToString();
                    //addingScan();
                    InsertDB();
                    Scan();


                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else if (txtStartingScan.Text == "")
            {
                txtStartingScan.Text = "";
            }
        }
    }
}