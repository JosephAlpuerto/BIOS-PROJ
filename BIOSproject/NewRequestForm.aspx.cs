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
using TextBox = System.Web.UI.WebControls.TextBox;
using System.IO;

namespace BIOSproject
{
    public partial class NewRequestForm : System.Web.UI.Page
    {

        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            //txtRequestNo.ReadOnly = true;
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
            //con.Open();
            //string qry = "select max(ID) from Request";
            //SqlCommand cmd = new SqlCommand(qry, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //int rid = Convert.ToInt32(dr[0]);
            //rid++;
            //txtRequestNo.Text = rid.ToString();
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
                if (Session["Username"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    gvlist.Visible = false;
                                    ReqDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                                    GetRequestNo();
                                    FillGridView();
                                    FillGridView1();
                                    FillGridView2();
                                    GetDBA_Email();
                                    if (ViewState["Records"] == null)
                                    {
                                        ViewState["Records"] = dt;
                                    }
                }
                
            }
        }
        void FillGridView()
        {
            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("Select Products, Quantity from TempRequest", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows == true)
            //    {
            //        GridView.DataSource = dr;
            //        GridView.DataBind();
            //    }
            //}
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from [LBC.BIOS].[lbcbios].[TempRequest]", sqlcon);
                sqlDa.Fill(dtbl);
            }
            GridView.DataSource = dtbl;
            GridView.DataBind();

        }
        void FillGridView1()
        {
            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("Select Products, Quantity from TempRequest", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows == true)
            //    {
            //        GridView.DataSource = dr;
            //        GridView.DataBind();
            //    }
            //}
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, RequestNo, Products, Quantity from [LBC.BIOS].[lbcbios].[TempRequest]", sqlcon);
                sqlDa.Fill(dtbl);
            }
            GridView1.DataSource = dtbl;
            GridView1.DataBind();

        }
        void FillGridView2()
        {
            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("Select Products, Quantity from TempRequest", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows == true)
            //    {
            //        GridView.DataSource = dr;
            //        GridView.DataBind();
            //    }
            //}
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from [LBC.BIOS].[lbcbios].[TempRequest]", sqlcon);
                sqlDa.Fill(dtbl);
            }
            gvlist.DataSource = dtbl;
            gvlist.DataBind();

        }

        public void GetRequestNo()
        {
            string proid;
            //string query = "select ID from Request order by ID Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID from [LBC.BIOS].[lbcbios].[SSPNewRequest] order by ID Desc", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("000001");
            }
            else
            {
                proid = ("000001");
            }
            con.Close();
            txtRequestNo.Text = proid.ToString();
        }
        public void GetDBA_Email()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtEmailDBA.Text == "")
            {
                SqlCommand cmd = new SqlCommand("Select ID, EmailDBA From [LBC.BIOS].[lbcbios].[DBA_Email]", sqlCon);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtEmailDBA.Text = dr.GetValue(1).ToString();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select ID, EmailDBA From [LBC.BIOS].[lbcbios].[DBA_Email]", sqlCon);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtEmailDBA.Text = dr.GetValue(1).ToString();
                }
            }
        }

        public void Clear3()
        {
            TxtQuantity.Text = "";
            lblerror.Text = "";
        }
        void allClear()
        {

            TxtQuantity.Text = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TicketNo.Text != "")
            {
                if (PONumber.Text != "")
                {
                    if (dropSupplier.SelectedItem.Value != "S")
                    {
                        if (DropProduct.SelectedItem.Value != "S")
                        {
                            if (TxtQuantity.Text != "")
                            {
                                if (DDL.Items.FindByText(DropProduct.SelectedItem.Text) == null)
                                {
                                    if (txtTotal.Text == "")
                                    {
                                        txtTotal.Text = TxtQuantity.Text;
                                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand("Insert into [LBC.BIOS].[lbcbios].[TempRequest] values('" + TicketNo.Text + "','" + PONumber.Text + "','" + dropSupplier.SelectedItem.Text + "','" + DropProduct.SelectedItem.Text + "','" + TxtQuantity.Text + "','" + ReqDate.Text + "','" + txtRequestNo.Text + "')", conn);
                                            int insert = cmd.ExecuteNonQuery();
                                            DDL.Items.Add(new ListItem(DropProduct.SelectedItem.Text.ToString(), DropProduct.SelectedItem.Text.ToString()));
                                            DDLQuantity.Items.Add(new ListItem(TxtQuantity.Text, TxtQuantity.Text));
                                            FillGridView();
                                            FillGridView2();


                                        }
                                        allClear();
                                        PONumber.Enabled = false;
                                        dropSupplier.Enabled = false;
                                        lblerrorTicket.Text = "";
                                        lblerror.Text = "";
                                        lblerrorDrop.Text = "";
                                    }
                                    else
                                    {
                                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand("Insert into [LBC.BIOS].[lbcbios].[TempRequest] values('" + TicketNo.Text + "','" + PONumber.Text + "','" + dropSupplier.SelectedItem.Text + "','" + DropProduct.SelectedItem.Text + "','" + TxtQuantity.Text + "','" + ReqDate.Text + "','" + txtRequestNo.Text + "')", conn);
                                            int insert = cmd.ExecuteNonQuery();
                                            DDL.Items.Add(new ListItem(DropProduct.SelectedItem.Text.ToString(), DropProduct.SelectedItem.Text.ToString()));
                                            DDLQuantity.Items.Add(new ListItem(TxtQuantity.Text, TxtQuantity.Text));
                                            if (insert > 0)
                                            {
                                                int num1, num2, num3;
                                                num1 = Convert.ToInt32(txtTotal.Text);
                                                num2 = Convert.ToInt32(TxtQuantity.Text);
                                                num3 = num1 + num2;
                                                txtTotal.Text = num3.ToString();
                                                FillGridView();
                                                FillGridView2();
                                            }
                                            allClear();
                                            lblerrorTicket.Text = "";
                                            lblerror.Text = "";
                                            lblGridview.Text = "";
                                            lblerrorDrop.Text = "";
                                            lblError1.Text = "";
                                        }
                                    }
                                }
                                else
                                {
                                    lblerrorTicket.Text = "";
                                    lblerror.Text = "";
                                    lblerrorDrop.Text = "Product already used!";
                                    lblGridview.Text = "";
                                    lblError1.Text = "";
                                }

                            }
                            else
                            {
                                lblerrorTicket.Text = "";
                                lblError1.Text = "";
                                lblerror.Text = "Please Input Quantity!";
                                lblGridview.Text = "";
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Select Product.','You clicked the button!', 'warning')", true);
                        }
                        
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Select supplier.','You clicked the button!', 'warning')", true);
                    } 
                }
                else
                {
                    lblerrorTicket.Text = "";
                    lblError1.Text = "Please Enter PONumber!";
                    lblGridview.Text = "";
                }
                
            }
            else
            {
                lblerrorTicket.Text = "Please Enter Ticket No.!";
                lblGridview.Text = "";
            }
            
           
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
                //txtAllProductQuantity.Text = list[0].Text;
                ModalReviewView.Show();
                txtDate.Text = ReqDate.Text;
                txtTicketNo.Text = TicketNo.Text;
                txtPONumber.Text = PONumber.Text;
                
                txtRequest.Text = txtRequestNo.Text;
                txtSupplier.Text = dropSupplier.SelectedItem.Text;
                txtEmail.Text = DropFIE.SelectedItem.Text;
                lblerrorTicket.Text = "";
                lblerrorDrop.Text = "";
                txtTotalQuantity.Text = "0";
                for (int i = 0; i < Convert.ToInt32(gvlist.Rows.Count); i++)
                {
                    txtTotalQuantity.Text = Convert.ToString(double.Parse(txtTotalQuantity.Text) + double.Parse(gvlist.Rows[i].Cells[4].Text));
                }
                FillGridView1();
                FillGridView2();
            }

        }
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            FillGridView();
            FillGridView2();
        }
        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView.EditIndex = -1;
            FillGridView();
            FillGridView2();
        }
        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {  
                try
                {
                    using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                    {
                        sqlcon.Open();
                        string Product = (GridView.Rows[e.RowIndex].FindControl("DropProdGV") as DropDownList).Text.Trim();
                        string cnt = "select COUNT(*) from [LBC.BIOS].[lbcbios].[TempRequest] where Products='" + Product + "'";
                        string qry = "UPDATE [LBC.BIOS].[lbcbios].[TempRequest] SET Products=@Products,Quantity=@Quantity WHERE ID=@ID";
                        SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
                        sqlcmd.Parameters.AddWithValue("@Products", (GridView.Rows[e.RowIndex].FindControl("DropProdGV") as DropDownList).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Quantity", (GridView.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));
                        SqlCommand sqlcmda = new SqlCommand(cnt, sqlcon);
                        int count = Convert.ToInt32(sqlcmda.ExecuteScalar());
                        if (count == 1)
                        {
                        sqlcmd.ExecuteNonQuery();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Alert','Selected Product already Used!', 'warning')", true);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('')", true);
                            GridView.EditIndex = -1;
                            FillGridView();
                            FillGridView2();
                        }
                        else
                        {
                            sqlcmd.ExecuteNonQuery();
                            GridView.EditIndex = -1;
                            FillGridView();
                            FillGridView2();

                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE','Selected list Updated!', 'success')", true);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected list Updated!')", true);
                            lblerrorGV.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblGridview.Text = "";
                    lblerrorGV.Text = ex.Message;
                }
            
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                {
                    DataTable dtbl = new DataTable();
                    sqlcon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from [LBC.BIOS].[lbcbios].[TempRequest]", sqlcon);
                    sqlDa.Fill(dtbl);
                    string qry = "DELETE FROM [LBC.BIOS].[lbcbios].[TempRequest] WHERE ID=@ID";
                    SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));
                    GridView.EditIndex = -1;
                    FillGridView();
                    FillGridView2();
                    sqlcmd.ExecuteNonQuery();
                    FillGridView();
                    FillGridView2();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE','Selected list Deleted!', 'success')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected list Deleted!')", true);
                    lblerrorGV.Text = "";

                    //int index = Convert.ToInt32(e.RowIndex);

                    
                    dtbl.Rows[e.RowIndex].Delete();
                    if (txtTotal.Text != "")
                    {
                        ListItem listItem = DDL.Items[Convert.ToInt32(e.RowIndex)];
                        DDL.Items.Remove(listItem);
                        ListItem listItem2 = DDLQuantity.Items[Convert.ToInt32(e.RowIndex)];
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
                    GridView.DataSource = dtbl;
                    GridView.DataBind();
                    lblerror.Text = "";
                    lblerrorDrop.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblGridview.Text = "";
                lblerrorGV.Text = ex.Message;
            }
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





        protected void PONumber_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from [LBC.BIOS].[lbcbios].[SSPNewRequest] where PONumber = '" + PONumber.Text + "' ", con);
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

        

        protected void btnCloseView_Click(object sender, EventArgs e)
        {
            ModalReviewView.Hide();
            FillGridView();
            FillGridView2();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTicketNo.Text != "" && txtPONumber.Text != "")
            {
                try
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            GridView1.RenderControl(hw);
                            StringReader sr = new StringReader(sw.ToString());
                            MailMessage mm = new MailMessage("lbcbios08@gmail.com", txtEmailDBA.Text);
                            mm.Subject = "'FOR TESTING ONLY' Request for Barcode Series" + " Ticket# " + txtTicketNo.Text + " PO# " + txtPONumber.Text;
                            mm.Body = "<h1>Product Details</h1><hr/>" + sw.ToString(); 
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                            NetworkCred.UserName = "lbcbios08@gmail.com";
                            NetworkCred.Password = "pdlgfieeiiqbcsvf";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = 587;
                            smtp.Send(mm);
                        }
                    }
                    //using (StringWriter sw2 = new StringWriter())
                    //{
                    //    using (HtmlTextWriter hw2 = new HtmlTextWriter(sw2))
                    //    {
                    //        GridView1.RenderControl(hw2);
                    //        MailMessage msg = new MailMessage("lbcbios08@gmail.com", txtEmailDBA.Text);
                    //        msg.Subject = "'FOR TESTING ONLY' Request for Barcode Series" + " Ticket# " + txtTicketNo.Text + " PO# " + txtPONumber.Text;
                    //        msg.Body = "<h1>Product Details</h1><hr/>" + sw2.ToString();
                    //        msg.IsBodyHtml = true;

                    //        SmtpClient client = new SmtpClient();
                    //        client.UseDefaultCredentials = false;
                    //        client.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "pdlgfieeiiqbcsvf");
                    //        client.Port = 25; // You can use Port 25 if 587 is blocked (mine is!)
                    //        client.Host = "smtp.office365.com";
                    //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //        client.EnableSsl = true;
                    //        client.Send(msg);
                    //    }
                    //}
                    
                }
                catch (Exception ex)
                {
                    Label7.Text = ex.Message;
                }
                string main = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection Sqlconn = new SqlConnection(main);

                foreach (GridViewRow gr in gvlist.Rows)
                {
                    string sqlquery = "insert into [LBC.BIOS].[lbcbios].[SSPNewRequest] values (@TicketNo,@PONumber,@Supplier,@ProductQuantity,@TotalQuantity,@StartingSeries,@EndingSeries,@CreatedBy,@CreatedDate,@UpdatedBy,@UpdatedDate,@DeletedBy,@DeletedDate,@IsActive,@CancelRequest," +
                        "@IsRejected,@SequenceSeries,@DateRequested,@forHitCheck,@Branch,@Team,@Area,@Hub,@Warehouse,@DestinationTo,@IfDownload,@ScheduledDate,@IfProcess,@WHcheck,@Quantity,@RequestNo,@SupplierName,@link,@ifSend,@ifFinish)";
                    SqlCommand sqlComm = new SqlCommand(sqlquery, Sqlconn);
                    sqlComm.Parameters.AddWithValue("@TicketNo", gr.Cells[0].Text);
                    sqlComm.Parameters.AddWithValue("@PONumber", gr.Cells[1].Text);
                    sqlComm.Parameters.AddWithValue("@Supplier", dropSupplier.SelectedItem.Value);
                    sqlComm.Parameters.AddWithValue("@ProductQuantity", gr.Cells[3].Text);
                    sqlComm.Parameters.AddWithValue("@TotalQuantity", txtTotalQuantity.Text.Trim());
                    sqlComm.Parameters.AddWithValue("@StartingSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@EndingSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                    sqlComm.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss"));
                    sqlComm.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@IsActive", "0");
                    sqlComm.Parameters.AddWithValue("@CancelRequest", "0");
                    sqlComm.Parameters.AddWithValue("@IsRejected", "0");
                    sqlComm.Parameters.AddWithValue("@SequenceSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DateRequested", DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss"));
                    sqlComm.Parameters.AddWithValue("@forHitCheck", "0");
                    sqlComm.Parameters.AddWithValue("@Branch", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@Team", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@Area", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@Hub", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@Warehouse", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DestinationTo", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@IfDownload", "0");
                    sqlComm.Parameters.AddWithValue("@ScheduledDate", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@IfProcess", "0");
                    sqlComm.Parameters.AddWithValue("@WHcheck", "0");
                    sqlComm.Parameters.AddWithValue("@Quantity", gr.Cells[4].Text);
                    sqlComm.Parameters.AddWithValue("@RequestNo", txtRequest.Text.Trim());
                    sqlComm.Parameters.AddWithValue("@SupplierName", dropSupplier.SelectedItem.Text);
                    sqlComm.Parameters.AddWithValue("@link", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@ifSend", "0");
                    sqlComm.Parameters.AddWithValue("@ifFinish", "0");
                    Sqlconn.Open();
                    sqlComm.ExecuteNonQuery();
                    Sqlconn.Close();

                }

                    SqlConnection conn = new SqlConnection(main);
                    string qry = "Delete from [LBC.BIOS].[lbcbios].[TempRequest] where RequestNo = '" + txtRequest.Text + "'";
                    SqlCommand sqlComma = new SqlCommand(qry, conn);
                    conn.Open();
                    sqlComma.ExecuteNonQuery();
                    TicketNo.Text = "";
                    PONumber.Text = "";
                    TxtQuantity.Text = "";
                    txtTotal.Text = "";
                    DDL.Items.Clear();
                    DropFIE.Items.Clear();
                    DDLQuantity.Items.Clear();
                    FillGridView();
                    FillGridView2();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);
                    conn.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);

            }


        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }

        //protected void cascadingdropdown()
        //{
        //    SqlConnection sqlcon = new SqlConnection(ConnectionString);
        //    sqlcon.Open();
        //    SqlCommand sqlcom = new SqlCommand("SELECT * FROM [Reference] where VendorName != 'NULL'", sqlcon);
        //    sqlcom.CommandType = CommandType.Text;
        //    dropSupplier.DataSource = sqlcom.ExecuteReader();
        //    dropSupplier.DataTextField = "VendorName";
        //    dropSupplier.DataValueField = "VendorEmail";
        //    dropSupplier.DataBind();
        //}

        protected void dropSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string EmailID = dropSupplier.SelectedItem.Text;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand comm = new SqlCommand("select VendorEmail from [LBC.BIOS].[lbcbios].[Reference] where VendorName = '" + EmailID +"' ", con);
            comm.CommandType = CommandType.Text;
            DropFIE.DataSource = comm.ExecuteReader();
            DropFIE.DataTextField = "VendorEmail";
            DropFIE.DataValueField = "VendorEmail";
            DropFIE.DataBind();
        }
        
    }
}