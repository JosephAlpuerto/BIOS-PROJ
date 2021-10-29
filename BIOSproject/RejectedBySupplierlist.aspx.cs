using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIOSproject
{
    public partial class RejectedBySupplierlist : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }
        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("RejectedListBySupplier", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview.DataSource = dtbl;
            Gridview.DataBind();
            Gridview.UseAccessibleHeader = true;
            Gridview.HeaderRow.TableSection = TableRowSection.TableHeader;
            Gridview.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void ViewRejected_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewtoReject", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            hfSupplier.Value = dtbl.Rows[0]["Supplier"].ToString();
            hfSourcing.Value = dtbl.Rows[0]["CreatedBy"].ToString();
            hfProduct.Value = dtbl.Rows[0]["Product"].ToString();
            hfQuantity.Value = dtbl.Rows[0]["Quantity"].ToString();
            txtStart.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEnd.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            txtRequestID.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicketNo.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPONo.Text = dtbl.Rows[0]["PONumber"].ToString();
            ModalViewReject.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("RejectedUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@TicketNo", txtTicketNo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PONumber", txtPONo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", hfSupplier.Value.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", hfQuantity.Value.Trim());
            sqlCmd.Parameters.AddWithValue("@StartingSeries", txtStart.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EndingSeries", txtEnd.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@DeletedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@IsActive", "0");
            sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
            sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            string Id = hfId.Value;

            if (Id == "")
            {
                using (MailMessage mail = new MailMessage())
                {



                    mail.From = new MailAddress("lbcbios08@gmail.com");
                    mail.To.Add(hfSupplier.Value);
                    mail.Subject = "Request Edited By: " + hfSourcing.Value + " " + txtPONo.Text;
                    mail.Body = "Updated Request item <hr>Ticket#:</hr> " + txtTicketNo.Text + "<hr>PONumber:</hr>"
                        + txtPONo.Text + "<hr> Product: </hr>" + hfProduct.Value + "<hr>Quantity:</hr>" + hfQuantity.Value +
                        "<hr>Starting Series:</hr>" + txtStart.Text + "<hr>Ending Series:</hr>" + txtEnd.Text +
                         "<hr> Supplier: </hr>" + hfSupplier.Value + "<br/><br/>Thanks,";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "lolipop312");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }


                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Request Edited and Email send Successfully!')", true);
            }
            else
            {
                lblSuccess.Text = "Please Cornfirm your Details!";
            }
           
        }
        private void Clear()
        {
            hfId.Value = "";
            lblSuccess.Text = "";
        }
    }
}