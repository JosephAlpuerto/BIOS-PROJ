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
                gvlist.Visible = false;
                ReqDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                GetRequestNo();
                FillGridView();
                FillGridView1();
                FillGridView2();
                if (ViewState["Records"] == null)
                {
                    ViewState["Records"] = dt;
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from TempRequest", sqlcon);
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from TempRequest", sqlcon);
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from TempRequest", sqlcon);
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
            SqlCommand cmd = new SqlCommand("select ID from SSPNewRequest order by ID Desc", con);
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
                                    SqlCommand cmd = new SqlCommand("Insert into TempRequest values('" + TicketNo.Text + "','" + PONumber.Text + "','" + dropSupplier.SelectedItem.Text + "','" + DropProduct.SelectedItem.Text + "','" + TxtQuantity.Text + "','" + ReqDate.Text + "','" + txtRequestNo.Text + "')", conn);
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
                                    SqlCommand cmd = new SqlCommand("Insert into TempRequest values('" + TicketNo.Text + "','" + PONumber.Text + "','" + dropSupplier.SelectedItem.Text + "','" + DropProduct.SelectedItem.Text + "','" + TxtQuantity.Text + "','" + ReqDate.Text + "','" + txtRequestNo.Text + "')", conn);
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
                txtTotalQuantity.Text = txtTotal.Text;
                txtRequest.Text = txtRequestNo.Text;
                txtSupplier.Text = dropSupplier.SelectedItem.Text;
                txtEmail.Text = DropFIE.SelectedItem.Text;
                lblerrorTicket.Text = "";
                lblerrorDrop.Text = "";
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
                    string cnt = @"(select count(*) from TempRequest where Products='"+ (GridView.Rows[e.RowIndex].FindControl("DropProdGV") as DropDownList).Text.Trim() +"')";
                    string qry = "UPDATE TempRequest SET Products=@Products,Quantity=@Quantity WHERE ID=@ID";
                    SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@Products", (GridView.Rows[e.RowIndex].FindControl("DropProdGV") as DropDownList).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Quantity",(GridView.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));
                    SqlCommand sqlcmda = new SqlCommand(cnt, sqlcon);
                    int count = (int)sqlcmda.ExecuteScalar();
                    if (count > 0)
                    { 
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected Product already Used!')", true);
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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected list Updated!')", true);
                        lblerrorGV.Text = "";
                    }
                }
            }
            catch(Exception ex)
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from TempRequest", sqlcon);
                    sqlDa.Fill(dtbl);
                    string qry = "DELETE FROM TempRequest WHERE ID=@ID";
                    SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));
                    GridView.EditIndex = -1;
                    FillGridView();
                    FillGridView2();
                    sqlcmd.ExecuteNonQuery();
                    FillGridView();
                    FillGridView2();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected list Deleted!')", true);
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
                    using (MailMessage mail = new MailMessage())
                    {

                        mail.From = new MailAddress("lbcbios08@gmail.com");
                        mail.To.Add(txtEmail.Text);
                        mail.Subject = "Request for Barcode Series" + "<br />" + txtEmail.Text + " " + txtPONumber.Text;
                        mail.Body = "Hi Sir/Ma'am,<br/><br/>" + "Please see requested barcode series: <br/>" +
                             "<br/><br/>Starting Series - Ending Series<br/><br/>" +
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
                string main = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection Sqlconn = new SqlConnection(main);

                foreach (GridViewRow gr in gvlist.Rows)
                {
                    string sqlquery = "insert into SSPNewRequest values (@TicketNo,@PONumber,@Supplier,@ProductQuantity,@TotalQuantity,@StartingSeries,@EndingSeries,@CreatedBy,@CreatedDate,@UpdatedBy,@UpdatedDate,@DeletedBy,@DeletedDate,@IsActive,@CancelRequest," +
                        "@IsRejected,@SequenceSeries,@DateRequested,@forHitCheck,@Branch,@Team,@Area,@Hub,@Warehouse,@DestinationTo,@IfDownload,@ScheduledDate,@IfProcess,@WHcheck,@Quantity,@RequestNo,@SupplierName)";
                    SqlCommand sqlComm = new SqlCommand(sqlquery, Sqlconn);
                    sqlComm.Parameters.AddWithValue("@TicketNo", gr.Cells[0].Text);
                    sqlComm.Parameters.AddWithValue("@PONumber", gr.Cells[1].Text);
                    sqlComm.Parameters.AddWithValue("@Supplier", DropFIE.SelectedItem.Text);
                    sqlComm.Parameters.AddWithValue("@ProductQuantity", gr.Cells[3].Text);
                    sqlComm.Parameters.AddWithValue("@TotalQuantity", txtTotalQuantity.Text.Trim());
                    sqlComm.Parameters.AddWithValue("@StartingSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@EndingSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
                    sqlComm.Parameters.AddWithValue("@CreatedDate", txtDate.Text.Trim());
                    sqlComm.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@IsActive", "0");
                    sqlComm.Parameters.AddWithValue("@CancelRequest", "0");
                    sqlComm.Parameters.AddWithValue("@IsRejected", "0");
                    sqlComm.Parameters.AddWithValue("@SequenceSeries", Convert.DBNull);
                    sqlComm.Parameters.AddWithValue("@DateRequested", txtDate.Text.Trim());
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
                    sqlComm.Parameters.AddWithValue("@SupplierName", gr.Cells[2].Text);
                    Sqlconn.Open();
                    sqlComm.ExecuteNonQuery();
                    Sqlconn.Close();

                }

                    SqlConnection conn = new SqlConnection(main);
                    string qry = "Delete from [lbcbios].[TempRequest] where RequestNo = '" + txtRequest.Text + "'";
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                    "alert('Add Request Successfully! ')", true);
                    conn.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);

            }


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
            SqlCommand comm = new SqlCommand("select [VendorEmail] from Reference where VendorName = '"+ EmailID +"' ", con);
            comm.CommandType = CommandType.Text;
            DropFIE.DataSource = comm.ExecuteReader();
            DropFIE.DataTextField = "VendorEmail";
            DropFIE.DataValueField = "VendorEmail";
            DropFIE.DataBind();
        }
    }
}