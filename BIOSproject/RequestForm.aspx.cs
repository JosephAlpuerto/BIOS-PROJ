using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Windows.Forms;

namespace BIOSproject
{
    public partial class RequestForm : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            //string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
            //string sqlquery = "select * from Supplier";
            //SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
            //conn.Open();
            //SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            //DataTable dt = new DataTable();
            //sdr.Fill(dt);
            //dropSupplier.DataSource = dt;
            //dropSupplier.DataTextField = "SupplierName";
            //dropSupplier.DataValueField = "SupplierName";
            //dropSupplier.DataBind();
            //conn.Close();

                string mainconn = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                string sqlqueryy = "select * from Product where ProductName != '"+null+"'";
                SqlCommand sqlcom = new SqlCommand(sqlqueryy, con);
                conn.Open();
                SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
                DataTable td = new DataTable();
                dr.Fill(td);
                drpProduct.DataSource = td;
                drpProduct.DataTextField = "ProductName";
                drpProduct.DataValueField = "ProductName";
                drpProduct.DataBind();
                conn.Close();



                //if(TicketNo.Text != "" || PONo.Text != "" || txtQuantity.Text !="")
                //{
                //    Button1.Enabled = true;
                //}
                //    string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                //    string sqlqueryy = "select * from ref_Branches";
                //    SqlCommand sqlcom = new SqlCommand(sqlqueryy, conn);
                //    con.Open();
                //    SqlDataAdapter sd = new SqlDataAdapter(sqlcom);
                //    DataSet ds = new DataSet();
                //    sd.Fill(ds);
                //    DropTeam.DataSource = ds;
                //    DropTeam.DataTextField = "TeamDescr";
                //    DropTeam.DataValueField = "TeamDescr";
                //    DropTeam.DataBind();
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {

                //        DropBranch.Items.Add(ds.Tables[0].Rows[i][1] + "--" + ds.Tables[0].Rows[i][2]);
                ////    }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TicketNo.Text != "" || PONo.Text != "" || txtQuantity.Text != "")
            {

                try
                {
                    using (MailMessage mail = new MailMessage())
                    {



                        mail.From = new MailAddress("lbcbios08@gmail.com");
                        mail.To.Add("castillojhondavid6@gmail.com , jmalpuerto@lbcexpress.com");
                        mail.Subject = "Request for Barcode Series" + dropSupplier.Text + " " + PONo.Text;
                        mail.Body = "Hi Sir/Ma'am,<br/><br/>" + "Please see requested barcode series: <br/><br/>" + 
                            "Product & Quantity: "+ drpProduct.Text + " - " + txtQuantity.Text + "<br/><br/>Starting Series - Ending Series<br/><br/>" +
                            "Thanks,";
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "lolipop312");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }


                    }
                }
                catch (Exception ex)
                {
                    Label7.Text = ex.Message;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Fill up all forms!')", true);
            }
            var Ticket = TicketNo.Text.Trim();
            var PO = PONo.Text.Trim();
            var Product = drpProduct.Text.Trim();
            var Quantity = txtQuantity.Text.Trim();
           

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("SSPCreateRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@TicketNo", TicketNo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PONumber ", PONo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", dropSupplier.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@Product", drpProduct.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
           
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@IsActive","0");
            sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
            sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
            sqlCmd.Parameters.AddWithValue("@DateRequested", txtDate.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            //sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            string Id = hfId1.Value;
            // validations

            if (Ticket == "")
            {
                lblError1.Text = "Please Enter Ticket No.!";
            }
            else if (PO == "")
            {
                lblError1.Text = "Please Enter PO No.!";
            }
            else if (Product == "")
            {
                lblError1.Text = "Please Enter Product Name!";
            }
            else if (Quantity == "")
            {
                lblError1.Text = "Please Enter Quantity!";
            }
           
            else if (Id == "")
            {
                sqlCmd.ExecuteNonQuery();
                Clear();
                sqlCon.Close();
                lblError1.Text = "New Request added Successfully!";
                //FillGridView();
            }
            else
            {
                lblError1.Text = "Error!";
            }
           
        }

        public void Clear()
        {
            TicketNo.Text = PONo.Text = txtQuantity.Text = "";
            hfId1.Value = "";
            lblError1.Text = "";
        }

        protected void TicketNo_TextChanged(object sender, EventArgs e)
        {
            

            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where TicketNo = '" + TicketNo.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                lblError1.Text = "Ticket Number Already Exists!!";
                PONo.Enabled = false;
                dropSupplier.Enabled = false;
                txtQuantity.Enabled = false;
                drpProduct.Enabled = false;

            }
            else
            {
                lblError1.Text = "";
                PONo.Enabled = true;
                dropSupplier.Enabled = true;
                txtQuantity.Enabled = true;
                drpProduct.Enabled = true;
            }

            con.Close();
        }

        protected void PONo_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + PONo.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                lblError1.Text = "PO Number Already Exists!!";
                TicketNo.Enabled = false;
                dropSupplier.Enabled = false;
                txtQuantity.Enabled = false;
                drpProduct.Enabled = false;
            }
            else
            {
                lblError1.Text = "";
                TicketNo.Enabled = true;
                dropSupplier.Enabled = true;
                txtQuantity.Enabled = true;
                drpProduct.Enabled = true;
            }

            con.Close();
        }
    }
}