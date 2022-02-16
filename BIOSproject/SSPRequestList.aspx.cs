using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;

namespace BIOSproject
{
    public partial class SSPRequestList : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
            FillGridView2();
        }


        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SSPNewRequestShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        void FillGridView2()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SSPNewRequestShow2", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview2.DataSource = dtbl;
            Gridview2.DataBind();
            Gridview2.UseAccessibleHeader = true;
            Gridview2.HeaderRow.TableSection = TableRowSection.TableHeader;
           
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnValidate_Click(object sender, EventArgs e)
        //{
        //    FillGridView();
        //    ModalValidate.Show();
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + TxtSearch.Text + "' ", con);
        //    SqlDataReader sdr = comm.ExecuteReader();
        //    if (sdr.Read())
        //    {

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This PO Number is already use!')", true);
        //        TxtPONo.Text = sdr.GetValue(2).ToString();
        //        Button1.Enabled = false;
               
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
        //    }
            
        //    con.Close();
        //}
        //private void Clear1()
        //{
        //    TxtSearch.Text = TxtPONo.Text = "";
        //}
        private void Clear2()
        {
            TxtSearchSeries.Text =  "";
            //TxtStart.Text = TxtEnd.Text = "";
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewAllByIdSSPRequest", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);

            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtRequestIDView.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicketNoView.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPONumberView.Text = dtbl.Rows[0]["PONumber"].ToString();
            txtStartingSeriesView.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEndingSeriesView.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            txtSupplierView.Text = dtbl.Rows[0]["Supplier"].ToString();
            txtProductView.Text = dtbl.Rows[0]["ProductQuantity"].ToString();
            txtQuantityView.Text = dtbl.Rows[0]["TotalQuantity"].ToString();
            txtForHitCheck.Text = dtbl.Rows[0]["forHitCheck"].ToString();
            txtifSend.Text = dtbl.Rows[0]["ifSend"].ToString();

            btnSend.Enabled = false;
            btnSend.Text = "SEND";
            if (txtForHitCheck.Text.Trim().ToLower() == "true" )
            {
                btnSend.Enabled = true;
                if (txtifSend.Text.Trim().ToLower() == "true")
                {
                    btnCancelRequest.Enabled = false;
                    btnSend.Enabled = false;
                    btnSend.Text = "DONE";
                }
            }

            ModalView.Show();
            FillGridView();
        }

        protected void btnUpdateView_Click(object sender, EventArgs e)
        {
            var txtProduct = txtProductView.Text.Trim();
            var txtQuantity = txtQuantityView.Text.Trim();
            

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateSSPRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@Product", txtProductView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQuantityView.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);

            string Id = hfId.Value;
            if (txtProduct == "")
            {
                lblError.Text = "Please Enter Product!";
            }
            else if (txtQuantity == "")
            {
                lblError.Text = "Please Enter Quantity!";
            }
            else if (Id == "")
            {
                lblSuccess.Text = "Saved Successfully";
            }
            else
            {
                Clear();
                FillGridView();
                FillGridView2();
                lblSuccess.Text = "Updated Successfully!";
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                
            }
        }
        private void Clear()
        {
            hfId.Value = "";
            lblError.Text = "";
            lblSuccess.Text = "";
        }

        

        protected void btnCloseView_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnCancelRequest_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(),"randomtext", "submitForm()", true);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CancelRequestSSP", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "1");

            Clear();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE','you have successfully rejected the request!', 'success')", true);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ModalView.Hide();
            FillGridView();
            FillGridView2();
            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        //protected void hitCheckClose_Click(object sender, EventArgs e)
        //{
        //    Clear1();
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}

        protected void btnValidateSeries_Click(object sender, EventArgs e)
        {
            
            FillGridView();
            ModalValidateSeries.Show();
        }

        protected void hitCheckCloseSeries_Click(object sender, EventArgs e)
        {
            Clear2();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int start = new int();
            int end = new int();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SearchSeries";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", TxtSearchSeries.Text);
            cmd.Parameters.AddWithValue("@startmin", start);
            cmd.Parameters.AddWithValue("@endmax", end);
            conn.Open();
            SqlCommand sql = new SqlCommand();
            string sqlquery = "select * from SSPRequest where StartingSeries <= @search and EndingSeries >= @search ";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@search", Convert.ToInt64(TxtSearchSeries.Text));
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            sda.Fill(dt);

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This Series is already use!')", true);
                    gridview.DataSource = dt;
                    gridview.DataBind();
                    gridview.UseAccessibleHeader = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('No Record Found')", true);
            }
            con.Close();
        }

        protected void HitCheck_Click(object sender, EventArgs e)
        {
            LinkButton HitCheck = (sender as LinkButton);
            string[] commandArguments = HitCheck.CommandArgument.Split(',');

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("CheckDuplicate", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", commandArguments[0]);
            sqlData.SelectCommand.Parameters.AddWithValue("@StartingSeries", commandArguments[1]);
            sqlData.SelectCommand.Parameters.AddWithValue("@EndingSeries", commandArguments[2]);
            FillGridView();
            FillGridView2();

            SqlDataReader sdr = sqlData.SelectCommand.ExecuteReader();
            if (sdr.Read())
            {
                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                if (sqlCon2.State == ConnectionState.Closed)
                    sqlCon2.Open();
                SqlCommand sqlCmd = new SqlCommand("CheckDuplicate2", sqlCon2);
                sqlCmd.CommandType = CommandType.StoredProcedure;   
                sqlCmd.Parameters.AddWithValue("@Id", commandArguments[0]);
                sqlCmd.Parameters.AddWithValue("@forHitCheck", "1");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('There are no duplicates in this series.','You clicked the button!', 'success')", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This series has not been used.')", true);
                sqlCmd.ExecuteNonQuery();
                sqlCon2.Close();
                FillGridView();
                FillGridView2();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Duplicate Record','You clicked the button!', 'warning')", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('')", true);
            }

            sqlCon.Close();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("SendRequestSSP", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@ifSend", "1");

            Clear();
            
            string Id = hfId.Value;
            if (Id == "")
            {
                using (MailMessage mail = new MailMessage())
                {



                    mail.From = new MailAddress("lbcbios08@gmail.com");
                    mail.To.Add(txtSupplierView.Text);
                    mail.Subject = "Sent of Request By: " + Session["Username"].ToString() + " PO# " + txtPONumberView.Text + " " + txtRequestIDView.Text;
                    mail.Body = "BARCODE SERIES REQUEST. <hr>BIOS TICKET NO:</hr> " + txtTicketNoView.Text + "<hr>PONumber:</hr>"
                        + txtPONumberView.Text + "<hr> Request NO.: </hr>" + txtRequestIDView.Text + "<hr> Product: </hr>" + txtProductView.Text + "<hr>Quantity:</hr>" + txtQuantityView.Text +
                        "<hr>Starting Series:</hr>" + txtStartingSeriesView.Text + "<hr>Ending Series:</hr>" + txtEndingSeriesView.Text +
                         "<hr> Supplier: </hr>" + txtSupplierView.Text +  "<br/><br/>Thanks,";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "pdlgfieeiiqbcsvf");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }


                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE','you have successfully sent request to supplier!', 'success')", true);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                ModalView.Hide();
                FillGridView();
                FillGridView2();
            }
            else
            {
                lblSuccess.Text = "Please Cornfirm your Details!";
            }
        }
    }
}