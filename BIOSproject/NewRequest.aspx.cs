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
    public partial class NewRequest : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                //string sqlquery = "select * from Reference where VendorName != '"+null+"'";
                //SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
                //con.Open();
                //SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                //DataTable dt = new DataTable();
                //sdr.Fill(dt);
                //dropSupplier.DataSource = dt;
                //dropSupplier.DataTextField = "VendorName";
                //dropSupplier.DataValueField = "VendorName";
                //dropSupplier.DataBind();

                //DropProduct.DataSource = dt;
                //DropProduct.DataTextField = "ItemDescr";
                //DropProduct.DataValueField = "ItemDescr";
                //DropProduct.DataBind();
                //con.Close();

                //string mainconn = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                //string sqlqueryy = "select * from Product";
                //SqlCommand sqlcom = new SqlCommand(sqlqueryy, con);
                //con.Open();
                //SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
                //DataTable td = new DataTable();
                //dr.Fill(td);
                //DropProduct.DataSource = td;
                //DropProduct.DataTextField = "ItemDescr";
                //DropProduct.DataValueField = "ItemDescr";
                //DropProduct.DataBind();
                //con.Close();






                ReqDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(TxtAllProduct.Text == "")
            {
                TxtAllProduct.Text = DropProduct.SelectedItem.Text + "-" + TxtQuantity.Text;
                if (txtTotal.Text == "")
                {
                    txtTotal.Text = TxtQuantity.Text;
                }
                else if (txtTotal.Text != "")
                {
                    int num1, num2, num3;
                    num1 = Convert.ToInt32(txtTotal.Text);
                    num2 = Convert.ToInt32(TxtQuantity.Text);
                    num3 = num1 + num2;
                    txtTotal.Text = num3.ToString();
                }
            }
            else if (TxtAllProduct.Text != "")
            {
                TxtAllProduct.Text = TxtAllProduct.Text + "\n" + DropProduct.SelectedItem.Text + "-" + TxtQuantity.Text;
                if(txtTotal.Text == "")
                {
                    txtTotal.Text = TxtQuantity.Text;
                }
                else if (txtTotal.Text != "")
                {
                    int num1, num2, num3;
                    num1 = Convert.ToInt32(txtTotal.Text);
                    num2 = Convert.ToInt32(TxtQuantity.Text);
                    num3 = num1 + num2;
                    txtTotal.Text = num3.ToString();
                }
            }

        }

        protected void PONumber_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPNewRequest where PONumber = '" + PONumber.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                lblError1.Text = "PO Number Already Exists!!";
                TicketNo.Enabled = false;
                dropSupplier.Enabled = false;
                TxtQuantity.Enabled = false;
                DropProduct.Enabled = false;
                btnAdd.Enabled = false;
                Button1.Enabled = false;
            }
            else
            {
                lblError1.Text = "";
                TicketNo.Enabled = true;
                dropSupplier.Enabled = true;
                TxtQuantity.Enabled = true;
                DropProduct.Enabled = true;
                btnAdd.Enabled = true;
                Button1.Enabled = true;
            }

            con.Close();
        }
        public void Clear()
        {
            TicketNo.Text = PONumber.Text = txtTotal.Text = "";
            HiddenField1.Value = "";
            lblError1.Text = "";
            TxtAllProduct.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TicketNo.Text != "" || PONumber.Text != "" || txtTotal.Text != "")
            {

                try
                {
                    using (MailMessage mail = new MailMessage())
                    {



                        mail.From = new MailAddress("lbcbios08@gmail.com");
                        mail.To.Add(dropSupplier.SelectedValue);
                        mail.Subject = "Request for Barcode Series" + "<br />"+ dropSupplier.Text + " " + PONumber.Text;
                        mail.Body = "Hi Sir/Ma'am,<br/><br/>" + "Please see requested barcode series: <br/><br/>" +
                            "Product & Quantity: " +"<br/>"+ TxtAllProduct.Text + " - " + "<br/><br/>Starting Series - Ending Series<br/><br/>" +
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
                var Ticket = TicketNo.Text.Trim();
                var PO = PONumber.Text.Trim();
                var Product = DropProduct.Text.Trim();
                var Quantity = txtTotal.Text.Trim();


                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("NewRequest", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Id", (HiddenField1.Value == "" ? 0 : Convert.ToInt32(HiddenField1.Value)));
                sqlCmd.Parameters.AddWithValue("@TicketNo", TicketNo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PONumber ", PONumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Supplier", dropSupplier.SelectedItem.Value);
                sqlCmd.Parameters.AddWithValue("@Product", TxtAllProduct.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Quantity", txtTotal.Text.Trim());

                sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
                sqlCmd.Parameters.AddWithValue("@IsActive", "0");
                sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
                sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
                sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
                sqlCmd.Parameters.AddWithValue("@DateRequested", ReqDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@forHitCheck", "0");
                //sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
                //sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
                //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
                string Id = HiddenField1.Value;
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



            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Fill up all forms!')", true);
            //}


        }

            }
        }
    