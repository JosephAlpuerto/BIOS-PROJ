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
using Button = System.Web.UI.WebControls.Button;

namespace BIOSproject
{
    public partial class NewRequest : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                if (Session["Username"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ReqDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                    if (ViewState["Records"] == null)
                    {
                        dt.Columns.Add("List of Products");
                        ViewState["Records"] = dt;
                    }
                }
                

            }
        }
        public void Clear3()
        {
            TxtQuantity.Text = "";
            lblerror.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["Records"];

            if (TxtQuantity.Text == "" && PONumber.Text == "")
            {
                lblerror.Text = "Please Input Quantity!";
                lblError1.Text = "Please Input PO Number!";
            }
            else
            {
                if (TxtAllProduct.Text == "" && PONumber.Text != "" && TxtQuantity.Text != "")
                {
                    
                    if (txtTotal.Text == "")
                    {
                        dt.Rows.Add(DropProduct.SelectedItem.Text + " : " + TxtQuantity.Text + "pcs");
                        TxtAllProduct.Text = DropProduct.SelectedItem.Text + " : " + TxtQuantity.Text + "pcs";
                        DDL.Items.Add(new ListItem(DropProduct.SelectedItem.Text.ToString(), DropProduct.SelectedItem.Text.ToString()));
                        DDLQuantity.Items.Add(new ListItem(TxtQuantity.Text, TxtQuantity.Text));

                        txtTotal.Text = TxtQuantity.Text;
                        PONumber.Enabled = false;
                        dropSupplier.Enabled = false;
                        Clear3();
                    }
                    else if (txtTotal.Text != "")
                    {
                        int num1, num2, num3;
                        num1 = Convert.ToInt32(txtTotal.Text);
                        num2 = Convert.ToInt32(TxtQuantity.Text);
                        num3 = num1 + num2;
                        txtTotal.Text = num3.ToString();
                        lblerrorTicket.Text = "";
                    }
                    else
                    {
                        lblerror.Text = "Please Input Quantity!";
                    }
                }

                else if (TxtAllProduct.Text != "" && TxtQuantity.Text != "")
                {

                    if (DDL.Items.FindByText(DropProduct.SelectedItem.Text) == null)
                        {
                            dt.Rows.Add(DropProduct.SelectedItem.Text + " : " + TxtQuantity.Text + "pcs");
                            TxtAllProduct.Text = TxtAllProduct.Text + "\n" + DropProduct.SelectedItem.Text + " : " + TxtQuantity.Text + "pcs";
                            DDL.Items.Add(new ListItem(DropProduct.SelectedItem.Value.ToString(), DropProduct.SelectedItem.Value.ToString()));
                            DDLQuantity.Items.Add(new ListItem(TxtQuantity.Text, TxtQuantity.Text));

                            int num1, num2, num3;
                            num1 = Convert.ToInt32(txtTotal.Text);
                            num2 = Convert.ToInt32(TxtQuantity.Text);
                            num3 = num1 + num2;
                            txtTotal.Text = Convert.ToString(num3);
                            PONumber.Enabled = false;
                            dropSupplier.Enabled = false;
                            lblerrorDrop.Text = "";
                            lblerrorTicket.Text = "";
                            Clear3();

                        }
                        else
                        {
                            lblerrorDrop.Text = "Product already used!";
                            lblerror.Text = "";
                        }
                    
                }
                else
                {
                    if(PONumber.Text == "")
                    {
                        lblError1.Text = "Please Input PO Number!";
                        lblerror.Text = "";
                    }
                    else if(TxtQuantity.Text == "")
                    {
                        lblerror.Text = "Please Input Quantity!";
                    }
                    
                }

            }

            GridView.DataSource = dt;
            GridView.DataBind();
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = ViewState["Records"] as DataTable;
        //    ListItemCollection liCol = DDL.Items;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ListItem li = liCol[i];
        //        if (li.Selected)
        //        {
        //            dt.Rows[i].Delete();
        //        }
        //    }
        //    ViewState["Records"] = dt;
        //    DDL.DataSource = dt;
        //    DDL.DataTextField = "Text";
        //    DDL.DataValueField = "Value";
        //    DDL.DataBind();
        //}

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";

                    }
                }
            }
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);

            DataTable dt = ViewState["Records"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["Records"] = dt;

            if (txtTotal.Text != "")
            {
                ListItem listItem = DDL.Items[Convert.ToInt32(index)];
                DDL.Items.Remove(listItem);

                ListItem listItem2 = DDLQuantity.Items[Convert.ToInt32(index)];
                int num1, num2, num3;
                num1 = Convert.ToInt32(listItem2.Text);
                num2 = Convert.ToInt32(txtTotal.Text);
                num3 = num2 - num1;
                txtTotal.Text = Convert.ToString(num3);

                DDLQuantity.Items.Remove(listItem2);
            }
            if (Convert.ToInt32(txtTotal.Text) == 0)
            {
                PONumber.Enabled = true;
                dropSupplier.Enabled = true;
            }
            
            //DDL.Items.Clear();
            GridView.DataSource = dt;
            GridView.DataBind();
            lblerror.Text = "";
            lblerrorDrop.Text = "";

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
            TxtQuantity.Text = "";
            TxtAllProduct.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TicketNo.Text == "")
            {
                lblerrorTicket.Text = "Please Enter Ticket No.!";
            }
            else if (DDL.Text == "")
            {
                lblerrorDrop.Text = "Please Select Product!";
            }
            else if (txtTotal.Text == "")
            {
                lblerrorDrop.Text = "Please Select Product!";
            }
            else if (TicketNo.Text != "" && DDL.Text != "")
            {
                ListItemCollection list = DDL.Items;
                txtAllProductQuantity.Text = list[0].Text;
                ModalReviewView.Show();
                txtDate.Text = ReqDate.Text;
                txtTicketNo.Text = TicketNo.Text;
                txtPONumber.Text = PONumber.Text;
                txtSupplier.Text = dropSupplier.SelectedItem.Text;
                txtTotalQuantity.Text = txtTotal.Text;
                lblerrorTicket.Text = "";
                lblerrorDrop.Text = "";
            }



            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Fill up all forms!')", true);
            //}


        }

        protected void btnCloseView_Click(object sender, EventArgs e)
        {
            ModalReviewView.Hide();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TicketNo.Text != "" && txtTotal.Text != "")
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {

                        mail.From = new MailAddress("lbcbios08@gmail.com");
                        mail.To.Add(dropSupplier.SelectedValue);
                        mail.Subject = "Request for Barcode Series" + "<br />" + dropSupplier.Text + " " + PONumber.Text;
                        mail.Body = "Hi Sir/Ma'am,<br/><br/>" + "Please see requested barcode series: <br/><br/>" +
                            "Product & Quantity: " + "<br/>" + txtAllProductQuantity.Text + " - " + txtTotalQuantity.Text + " pcs " + "<br/><br/>Starting Series - Ending Series<br/><br/>" +
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
                sqlCmd.Parameters.AddWithValue("@TicketNo", txtTicketNo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Product", txtAllProductQuantity.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Quantity", txtTotalQuantity.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
                sqlCmd.Parameters.AddWithValue("@IsActive", "0");
                sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
                sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
                sqlCmd.Parameters.AddWithValue("@DateRequested", txtDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@forHitCheck", "0");
                sqlCmd.Parameters.AddWithValue("@IfDownload", "0");
                sqlCmd.Parameters.AddWithValue("@IfProcess", "0");
                sqlCmd.Parameters.AddWithValue("@WHcheck", "0");
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
                    DataTable dt = ViewState["Records"] as DataTable;
                    
                    Clear();
                    sqlCon.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('New Request added Successfully!')", true);
                    dt.Rows.Clear();
                    PONumber.Enabled = true;
                    dropSupplier.Enabled = true;
                    GridView.DataSource = dt;
                    GridView.DataBind();
                    //lblError1.Text = "New Request added Successfully!";
                    //FillGridView();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Error!')", true);
                    //lblError1.Text = "Error!";
                }
            }

        }





        // The id parameter name should match the DataKeyNames value set on the control
    }
}
    