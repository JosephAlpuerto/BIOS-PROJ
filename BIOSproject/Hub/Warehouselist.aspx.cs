using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace BIOSproject.Hub
{
    public partial class Warehouselist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection coon = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillGridView();
                string maincon = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                string sqlquery = "select * from ref_Branches where TeamDescr != '" + null + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, conn);
                conn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                DropTeam.DataSource = dt;
                DropTeam.DataTextField = "TeamDescr";
                DropTeam.DataValueField = "TeamDescr";
                DropTeam.DataBind();
                conn.Close();



                //string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                //string sqlqueryy = "select * from ref_Branches where TeamDescr != '"+null+"'";
                //SqlCommand sqlcom = new SqlCommand(sqlqueryy, conn);
                //con.Open();
                //SqlDataAdapter sd = new SqlDataAdapter(sqlcom);
                //DataSet ds = new DataSet();
                //sd.Fill(ds);
                //DropTeam.DataSource = ds;
                //DropTeam.DataTextField = "TeamDescr";
                //DropTeam.DataValueField = "TeamDescr";
                //DropTeam.DataBind();
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{

                //    DropBranch.Items.Add(ds.Tables[0].Rows[i][1] + "--" + ds.Tables[0].Rows[i][2]);
                //}
            }

        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SuppRequestShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32((sender as System.Web.UI.WebControls.Button).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewAllSuppRequest", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtRequestID.Text = dtbl.Rows[0]["RequestID"].ToString();
            txtTicket.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPO.Text = dtbl.Rows[0]["PoNO"].ToString();
            txtBranch.Text = dtbl.Rows[0]["Branch"].ToString();
            txtArea.Text = dtbl.Rows[0]["Area"].ToString();
            txtStart.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEnd.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            txtProduct.Text = dtbl.Rows[0]["Product"].ToString();
            txtQuantity.Text = dtbl.Rows[0]["Quantity"].ToString();
            txtSuppName.Text = dtbl.Rows[0]["CreatedBy"].ToString();
            double start, end, answer;
            double.TryParse(txtStart.Text, out start);
            double.TryParse(txtEnd.Text, out end);
            answer = end - start + 2;
            if (answer > 0)
                txtUnit.Text = answer.ToString();



            ModalProcess.Show();
            FillGridView();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("HubProcess", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@NoOfUnit", txtUnit.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IfProcess", "1");
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            string Id = hfId.Value;

            // validations
            if (Id == "")
            {
                using (MailMessage mail = new MailMessage())
                {



                    mail.From = new MailAddress("lbcbios08@gmail.com");
                    mail.To.Add(txtSuppName.Text);
                    mail.Subject = "Request for Process" + txtSuppName.Text + " " + txtPO.Text;
                    mail.Body = "This Item Proceed to the Delivery with Ticket#: " + txtTicket.Text + "<hr>PONumber:</hr>"
                        + txtPO.Text + "<hr> Branch: </hr>" + txtBranch.Text + "<hr> Area: </hr>" + txtArea.Text + "<hr> Team: </hr>" + DropTeam.SelectedItem.Text +
                        "<hr> Product: </hr>" + txtProduct.Text + "<hr>Quantity:</hr>" + txtQuantity.Text + "<hr>StartingSeries:</hr>" + txtStart.Text + "<hr>EndingSeries:</hr>" + txtEnd.Text +
                        "<hr>No. of Units:</hr>" + txtUnit.Text + "<hr> Supplier: </hr>" + txtSuppName.Text + "<br/><br/>Thanks,";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "lolipop312");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }


                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('New Process added and Email send Successfully!')", true);
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
        private void Clear2()
        {
            TxtSearchSeries.Text = "";
            //TxtStart.Text = TxtEnd.Text = "";
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
            //sql.Parameters.AddWithValue("@end", Convert.ToInt64(TxtSearchSeries.Text));
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "WarehousePrint";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            ReportRequest.LocalReport.DataSources.Add(new ReportDataSource("DataSetReportRequest", dt));
            ReportRequest.LocalReport.ReportPath = Server.MapPath("~/Report/ReportRequest.rdlc");
            ReportRequest.LocalReport.EnableHyperlinks = true;
            FillGridView();
            ModalReport.Show();
        }


    }

}
