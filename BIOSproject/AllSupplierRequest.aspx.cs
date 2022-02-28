using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Reporting.WebForms;

namespace BIOSproject
{
    public partial class AllSupplierRequest : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                cascadingdropdown();
            }

        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SSPRequestSupplierShow", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        //void FillGridView2()
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConnectionString);
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlData = new SqlDataAdapter("SSPRequestSupplierShow2", sqlCon);
        //    sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
        //    DataTable dtbl = new DataTable();
        //    sqlData.Fill(dtbl);
        //    sqlCon.Close();
        //    Gridview2.DataSource = dtbl;
        //    Gridview2.DataBind();
        //    Gridview2.UseAccessibleHeader = true;
        //    Gridview2.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as System.Web.UI.WebControls.Button).CommandArgument);
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("ViewAllSSPRequest", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtRequestID.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicket.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPO.Text = dtbl.Rows[0]["PONumber"].ToString();
            txtStart.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            txtEnd.Text = dtbl.Rows[0]["EndingSeries"].ToString();
            Product.Value = dtbl.Rows[0]["ProductQuantity"].ToString();
            Quantity.Value = dtbl.Rows[0]["TotalQuantity"].ToString();
            ModalRequest.Show();
            FillGridView();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var ResquestID = txtRequestID.Text.Trim();
            var Ticket = txtTicket.Text.Trim();
            var PO = txtPO.Text.Trim();

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IdCreateSuppRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Hub", DropHub.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Warehouse", DropWare.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DestinationTo", DropDesti.SelectedItem.Text);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            string Id = hfId.Value;

            // validations
            if (Id == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('New Request added Successfully!')", true);
                //lblSuccess.Text = "New Request added Successfully!";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
                //lblSuccess.Text = "Please Cornfirm your Details!";
            }
        }
        private void Clear()
        {
            hfId.Value = "";
            hfId1.Value = "";
            //lblSuccess.Text = "";
        }



      

        protected void btnViewReject_Click(object sender, EventArgs e)
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
            hfId1.Value = Id.ToString();
            hfSupplier1.Value = dtbl.Rows[0]["Supplier"].ToString();
            hfSourcing1.Value = dtbl.Rows[0]["CreatedBy"].ToString();
            hfProduct1.Value = dtbl.Rows[0]["ProductQuantity"].ToString();
            hfQuantity1.Value = dtbl.Rows[0]["TotalQuantity"].ToString();
            hfStart1.Value = dtbl.Rows[0]["StartingSeries"].ToString();
            hfEnd1.Value = dtbl.Rows[0]["EndingSeries"].ToString();
            txtRequestID1.Text = dtbl.Rows[0]["Id"].ToString();
            txtTicketNo1.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPONo1.Text = dtbl.Rows[0]["PONumber"].ToString();
            ModalViewReject.Show();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("RejectedBySupplier", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@IsRejected", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            string Id = hfId1.Value;

            if (Id == "")
            {
                using (MailMessage mail = new MailMessage())
                {



                    mail.From = new MailAddress("lbcbios08@gmail.com");
                    mail.To.Add(hfSourcing1.Value);
                    mail.Subject = "'FOR TESTING' Rejected of Request By: " + hfSupplier1.Value + " PO# " + txtPONo1.Text + " " + txtRequestID1.Text;
                    mail.Body = "This PONumber have duplicate series of barcodes <hr>Ticket#:</hr> " + txtTicketNo1.Text + "<hr>PONumber:</hr>"
                        + txtPONo1.Text + "<hr> Request NO.: </hr>" + txtRequestID1.Text + "<hr> Product: </hr>" + hfProduct1.Value + "<hr>Quantity:</hr>" + hfQuantity1.Value +
                        "<hr>Starting Series:</hr>" + hfStart1.Value + "<hr>Ending Series:</hr>" + hfEnd1.Value +
                         "<hr> Supplier: </hr>" + hfSupplier1.Value + "<hr> Reason: </hr>" + txtReason.Text + "<br/><br/>Thanks,";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("lbcbios08@gmail.com", "pdlgfieeiiqbcsvf");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }


                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Request Rejected and Email send Successfully!')", true);
            }
            else
            {
                lblSuccess.Text = "Please Cornfirm your Details!";
            }
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

        //protected void hitCheckClose_Click(object sender, EventArgs e)
        //{
        //    Clear1();
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}
        //private void Clear1()
        //{
        //    TxtSearch.Text = TxtPONo.Text = "";
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
            string sqlquery = "select * from SSPRequest where StartingSeries <= @search and EndingSeries >= @search and Supplier = @Supplier";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@search", Convert.ToInt64(TxtSearchSeries.Text));
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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

        public IEnumerable<int> Generate(int start, int end)
        {
            int begin = start;
            while (begin <= end)
            {
                yield return begin;
                begin++;
            }
        }
        protected void DownloadView_Click(object sender, EventArgs e)
        {
            LinkButton HitCheck = (sender as LinkButton);
            string[] commandArguments = HitCheck.CommandArgument.Split(',');
            try
            {
                int start = int.Parse(commandArguments[1]);
                int end = int.Parse(commandArguments[2]);

                string series = "";
                for (int i = start; i <= end; i++)
                {
                    series += i.ToString() + System.Environment.NewLine;
                }


                string text = Convert.ToString(series);
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Length", text.Length.ToString());
                Response.ContentType = "text/plain";
                Response.AppendHeader("content-disposition", "attachment;filename=\"" + commandArguments[0] + ".txt\"");
                Response.Write(text);
                Response.End();
                FillGridView();
            }
            catch (Exception ex) { }

           

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

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This series has not been used.')", true);
                sqlCmd.ExecuteNonQuery();
                sqlCon2.Close();
                FillGridView();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('This series is used by another PONumber!!')", true);
            }

            sqlCon.Close();

        }

        protected void DropDesti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDesti.SelectedValue == "B")
            {
                DropBranch.Visible = true;
                lblBranch.Visible = true;

                DropTeam.Visible = true;
                lblTeam.Visible = true;

                DropArea.Visible = true;
                lblArea.Visible = true;

                DropHub.Visible = false;
                lblHub.Visible = false;
                DropWare.Visible = false;
                lblWare.Visible = false;
            }
            else if(DropDesti.SelectedValue == "H")
            {
                SqlConnection sqlcon = new SqlConnection(ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT [ID], [Hub] FROM [Reference] WHERE [Hub] != 'NULL'", sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                DropHub.DataSource = sqlcmd.ExecuteReader();
                DropHub.DataTextField = "Hub";
                DropHub.DataValueField = "ID";
                DropHub.DataBind();

                DropHub.Visible = true;
                lblHub.Visible = true;

                DropBranch.Visible = false;
                lblBranch.Visible = false;
                DropTeam.Visible = false;
                lblTeam.Visible = false;
                DropArea.Visible = false;
                lblArea.Visible = false;
                DropWare.Visible = false;
                lblWare.Visible = false;
            }
            else if(DropDesti.SelectedValue == "W")
            {
                SqlConnection sqlcon = new SqlConnection(ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT [ID], [WareHouse] FROM [Reference] WHERE [WareHouse] != 'NULL'", sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                DropWare.DataSource = sqlcmd.ExecuteReader();
                DropWare.DataTextField = "WareHouse";
                DropWare.DataValueField = "ID";
                DropWare.DataBind();

                DropWare.Visible = true;
                lblWare.Visible = true;

                DropBranch.Visible = false;
                lblBranch.Visible = false;
                DropTeam.Visible = false;
                lblTeam.Visible = false;
                DropArea.Visible = false;
                lblArea.Visible = false;
                DropHub.Visible = false;
                lblHub.Visible = false;
            }
            else
            {
                DropBranch.Visible = false;
                lblBranch.Visible = false;

                DropTeam.Visible = false;
                lblTeam.Visible = false;

                DropArea.Visible = false;
                lblArea.Visible = false;

                DropHub.Visible = false;
                lblHub.Visible = false;

                DropWare.Visible = false;
                lblWare.Visible = false;
            }
        }

        protected void cascadingdropdown()
        {
            SqlConnection sqlcon = new SqlConnection(mainconn);
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT [BranchID],[BranchCode] + ' - ' + [BranchDescr] as BranchCodeDesc FROM [ref_Branches]", sqlcon);
            sqlcmd.CommandType = CommandType.Text;
            DropBranch.DataSource = sqlcmd.ExecuteReader();
            DropBranch.DataTextField = "BranchCodeDesc";
            DropBranch.DataValueField = "BranchID";
            DropBranch.DataBind();
            DropBranch.SelectedItem.Text = Convert.ToString(DBNull.Value);
        }

        protected void DropBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BranchID = Convert.ToInt32(DropBranch.SelectedValue);
            SqlConnection sqlcon = new SqlConnection(mainconn);
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select * from [ref_Branches] where BranchID =" +BranchID, sqlcon);
            sqlcmd.CommandType = CommandType.Text;
            DropTeam.DataSource = sqlcmd.ExecuteReader();
            DropTeam.DataTextField = "TeamDescr";
            DropTeam.DataValueField = "AreaID";
            DropTeam.DataBind(); 

            int TeamID = Convert.ToInt32(DropTeam.SelectedValue);
            SqlConnection sqlcon2 = new SqlConnection(mainconn);
            sqlcon2.Open();
            SqlCommand sqlcmd2 = new SqlCommand("Select * from [Areas] where AreaId =" + TeamID, sqlcon2);
            sqlcmd.CommandType = CommandType.Text;
            DropArea.DataSource = sqlcmd2.ExecuteReader();
            DropArea.DataTextField = "AreaDescr";
            DropArea.DataValueField = "AreaID";
            DropArea.DataBind();
        }

        protected void btnCloseDownloadView_Click(object sender, EventArgs e)
        {
            ModalDownloadView.Hide();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkstatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkstatus.NamingContainer;
            if (checkstatus.Checked == true)
            {
                AllHitcheck.Visible = true;
            }
            else
            {
                AllHitcheck.Visible = false;
            }
        }

        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkheader = (CheckBox)Gridview1.HeaderRow.FindControl("CheckAll");
            foreach (GridViewRow row in Gridview1.Rows)
            {
                CheckBox checkrow = (CheckBox)row.FindControl("Check");
                if(checkheader.Checked == true)
                {
                    checkrow.Checked = true;
                    AllHitcheck.Visible = true;
                }
                else
                {
                    checkrow.Checked = false;
                    AllHitcheck.Visible = false;
                }
            }
        }

        protected void HitCheck_Click1(object sender, EventArgs e)
        {
                for (int i = 0; i < Gridview1.Rows.Count; i++)
                {
                    CheckBox HitCheck = (CheckBox)Gridview1.Rows[i].Cells[0].FindControl("Check");
                    if (HitCheck.Checked)
                    {
                        int Requestid = Convert.ToInt32(Gridview1.Rows[i].Cells[1].Text);
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("Delete SSPNewRequest where ID ='" + Requestid + "'", con);
                            cmd.ExecuteNonQuery();
                            Gridview1.EditIndex = -1;
                            con.Close();
                        }
                    }
                }
                FillGridView();
        }

        protected void AllHitcheck_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < Gridview1.Rows.Count; i++)
            //{
            //    CheckBox HitCheck = (CheckBox)Gridview1.Rows[i].Cells[0].FindControl("Check");
            //    if (HitCheck.Checked == true)
            //    {
            //        int Requestid = Convert.ToInt32(Gridview1.Rows[i].Cells[1].Text);
            //        con.Open();
            //            SqlCommand cmd = new SqlCommand("DELETE FROM SSPNewRequest WHERE ID ='" + Requestid + "'", con);
            //            cmd.ExecuteNonQuery();
            //            Gridview1.EditIndex = -1;
            //            con.Close();
            //            FillGridView();
            //    }
            //}

            if (Gridview1.Rows.Count > 0)
            {
                for (int i = 0; i < Gridview1.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)Gridview1.Rows[i].Cells[0].FindControl("Check");
                    if (cbx != null)
                    {
                        if (cbx.Checked)
                        {
                            int ColumnValue;
                            string str = Gridview1.Rows[i].Cells[5].Text;
                            int.TryParse(str, out ColumnValue);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('"+ ColumnValue + "')", true);
                        }
                    }
                }
            }

        }

        protected void Download_Click1(object sender, EventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("DownloadbySupp", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@ID", txtId.Text);
            //sqlCmd.Parameters.AddWithValue("@IfDownload", "1");
            //sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();
            //Clear();
            //FillGridView();
            //try
            //{
                LinkButton linkdownload = sender as LinkButton;
                GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
                string downloadfile = Gridview1.DataKeys[gridrow.RowIndex].Value.ToString();
                Response.ContentType = "Text/txt";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
                Response.TransmitFile(Server.MapPath(downloadfile));
                Response.End();




                //string Id = txtId.Text;
                //string TicketNo = hfTicketNo.Value;
                //string PONumber = hfPONumber.Value;
                //string StartingSeries = hfStartingSeries.Value;
                //string EndingSeries = hfEndingSeries.Value;
                //string Supplier = hfSupplier.Value;
                //string Product = hfProduct.Value;
                //string Quantity = hfQuantity.Value;
                //Response.Clear();
                //Response.ClearHeaders();
                //Response.AddHeader("Content-Length", Id.Length.ToString());
                //Response.AddHeader("Content-Length", TicketNo.Length.ToString());
                //Response.AddHeader("Content-Length", PONumber.Length.ToString());
                //Response.AddHeader("Content-Length", StartingSeries.Length.ToString());
                //Response.AddHeader("Content-Length", EndingSeries.Length.ToString());
                //Response.AddHeader("Content-Length", Supplier.Length.ToString());
                //Response.AddHeader("Content-Length", Product.Length.ToString());
                //Response.AddHeader("Content-Length", Quantity.Length.ToString());
                //Response.ContentType = "text/plain";
                //Response.AppendHeader("content-disposition", "attachment;filename=\""+txtId.Text+".txt\"");
                //Response.Write("RequestID: "+ Id +" \r \n");
                //Response.Write("Ticket Number: " + TicketNo + " \r \n");
                //Response.Write("PO Number: " + PONumber + " \r \n");
                //Response.Write("Starting Series: " + StartingSeries + " \r \n");
                //Response.Write("Ending Series: " + EndingSeries + " \r \n");
                //Response.Write("Supplier Name: " + Supplier + " \r \n");
                //Response.Write("Product Name: " + Product + " \r \n");
                //Response.Write("Quantity: " + Quantity);
                //Response.End();
                //FillGridView();
                //Response.Redirect(Request.Url.AbsoluteUri);
            //}
            //catch (Exception ex) { }
        }

        protected void ScanSupplier_Click(object sender, EventArgs e)
        {
            LinkButton HitCheck = (sender as LinkButton);
            string[] commandArguments = HitCheck.CommandArgument.Split(',');

            SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
            if (sqlCon3.State == ConnectionState.Closed)
                sqlCon3.Open();
            SqlDataAdapter sqlData3 = new SqlDataAdapter("ViewAllByIdSSPRequest", sqlCon3);
            sqlData3.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData3.SelectCommand.Parameters.AddWithValue("@Id", commandArguments[0]);

            DataTable dtbl = new DataTable();
            sqlData3.Fill(dtbl);
            sqlCon3.Close();
            hfIdScan.Value = commandArguments[0];
            lblID.Text = commandArguments[0];
            hfIdHIT.Value = commandArguments[0];
            txtStartScan.Text = dtbl.Rows[0]["StartingSeries"].ToString();
            hfEnd.Value = dtbl.Rows[0]["EndingSeries"].ToString();

            lblUnits.Text = "0";
            //lblseries.Text = "0";
            txtSeries.Text = "";
            btnPrint.Visible = false;
            txtEndScan.Text = "";
            txtProduct.Text = "";
            ModalScanSupplier.Show();
            //if (hfIdHIT.Value == "")
            //{
            //    
            //}


        }
        public void adding()
        {
            lblUnits.Text = "0";
            //lblseries.Text = "0";
            double start, end, answer;
            double.TryParse(txtStartScan.Text, out start);
            double.TryParse(txtEndScan.Text, out end);


            answer = end - start + 1;
            if (answer > 0 && txtStartScan.Text != "" && txtEndScan.Text != "")
                lblUnits.Text = answer.ToString();
                //lblseries.Text = answer.ToString();
        }
        public void Hitcheck()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("CheckDuplicate", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", hfIdScan.Value);
            sqlData.SelectCommand.Parameters.AddWithValue("@StartingSeries", txtStartScan.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@EndingSeries", hfEnd.Value);

            SqlDataReader sdr = sqlData.SelectCommand.ExecuteReader();
            if (sdr.Read())
            {
                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                if (sqlCon2.State == ConnectionState.Closed)
                    sqlCon2.Open();
                SqlCommand sqlCmd = new SqlCommand("CheckDuplicate2", sqlCon2);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Id", hfIdScan.Value);
                sqlCmd.Parameters.AddWithValue("@forHitCheck", "1");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Hitcheck()", true);
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('There are no duplicates in this series.','You clicked the button!', 'success')", true);
                hfIdHIT.Value = "";
                btnPrint.Visible = true;
                sqlCmd.ExecuteNonQuery();
                sqlCon2.Close();

            }

            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Duplicate Record','You clicked the button!', 'warning')", true);
            }

            sqlCon.Close();

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            Hitcheck();
            if (hfIdHIT.Value == "")
            {
                ModalScanSupplier.Show();
                SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
                sqlCon3.Open();
                if (txtStartScan.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("Select EndingSeries, ProductQuantity From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and ID = @ID", sqlCon3);
                    cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartScan.Text));
                    cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
                    cmd.Parameters.AddWithValue("@ID", hfIdScan.Value);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtEndScan.Text = dr.GetValue(0).ToString();
                        txtProduct.Text = dr.GetValue(1).ToString();
                        lblUnits.ForeColor = System.Drawing.Color.Blue;
                        //lblseries.ForeColor = System.Drawing.Color.Blue;

                        if (txtStartScan.Text != "" && txtEndScan.Text != "")
                        {
                            int start = int.Parse(txtStartScan.Text);
                            int end = int.Parse(txtEndScan.Text);

                            string series = "";
                            for (int i = start; i <= end; i++)
                            {
                                series += i.ToString() + System.Environment.NewLine;

                            }
                            string text = Convert.ToString(series);
                            txtSeries.Text = text;
                            btnPrint.Visible = true;

                        }
                        else
                        {
                            txtSeries.Text = "No Record!";
                        }
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                        txtEndScan.Text = "";
                        txtProduct.Text = "";
                        lblUnits.ForeColor = System.Drawing.Color.Red;
                        btnPrint.Visible = false;
                    }
                    sqlCon3.Close();
                }
                adding();
            }

           
            
        }

        protected void btnCloseScanSupplier_Click(object sender, EventArgs e)
        {
            txtEndScan.Text = "";
            txtProduct.Text = "";
            lblUnits.ForeColor = System.Drawing.Color.Red;
            btnPrint.Visible = false;
            ModalScanSupplier.Hide();

        }
        protected void btnScan_Click(object sender, EventArgs e)
        {
            txtStartingScan.Text = txtStartScan.Text;
            hfIDScan2.Value = hfIdScan.Value;
            txtEndScan.Text = "";
            txtProduct.Text = "";
            lblUnits.ForeColor = System.Drawing.Color.Red;
            btnPrint.Visible = false;
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select ID,TicketNo,PONumber,Supplier,ProductQuantity,TotalQuantity,Quantity,StartingSeries,EndingSeries,RequestNo,SupplierName From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and forHitCheck = '1' and ifSend = '1'  and WHcheck = '0'", sqlCon);
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
                Quantity2.Value = dr.GetValue(6).ToString();
                StartingSeries.Value = dr.GetValue(7).ToString();
                EndingSeries.Value = dr.GetValue(8).ToString();
                RequestNo.Value = dr.GetValue(9).ToString();
                SupplierName.Value = dr.GetValue(10).ToString();

                lblTotal.Text = dr.GetValue(5).ToString();
                lblScanUnits.Text = "0"; 

                btnOkay.Text = "SCAN";
                btnOkay.Enabled = true;

                ModalScan.Show();
                }
                sqlCon.Close();

            
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
                    txtStart.Enabled = true;
                    addingScan();
                    InsertDB();
                    FillGridView();
                    Scan();
                }

                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else if (txtStart.Text == "")
            {
                txtEnd.Text = "";
            }
            
        }
        public void Scan()
        {
        if (lblScanUnits.Text == lblTotal.Text)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Scan()", true);
                btnOkay.Text = "DONE";
                btnOkay.Enabled = false;
                ModalScan.Show();
            }
        }
        public void clearScan()
        {
            ID.Value = "";
            TicketNo.Value = "";
            PONumber.Value = "";
            Supplier.Value = "";
            ProductQuantity.Value = "";
            TotalQuantity.Value = "";
            Quantity2.Value = "";
            StartingSeries.Value = "";
            EndingSeries.Value = "";
            RequestNo.Value = "";
            SupplierName.Value = "";
        }
        public void InsertDB()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("InsertFinishGood", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNo",TicketNo.Value);
            cmd.Parameters.AddWithValue("@PONumber",PONumber.Value);
            cmd.Parameters.AddWithValue("@Supplier",Supplier.Value);
            cmd.Parameters.AddWithValue("@Product",ProductQuantity.Value);
            cmd.Parameters.AddWithValue("@TotalQuantity",TotalQuantity.Value);
            cmd.Parameters.AddWithValue("@Quantity",Quantity2.Value);
            cmd.Parameters.AddWithValue("@StartingSeries",StartingSeries.Value);
            cmd.Parameters.AddWithValue("@EndingSeries",EndingSeries.Value);
            cmd.Parameters.AddWithValue("@RequestNo",RequestNo.Value);
            cmd.Parameters.AddWithValue("@SupplierName",SupplierName.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            cmd.Parameters.AddWithValue("@CreatedDate",DateTime.Now);
            cmd.Parameters.AddWithValue("@RequestID",ID.Value);
            cmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse(Alabang)");
            cmd.ExecuteNonQuery();
            con.Close();
            finish();
            clearScan();

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

        protected void btnCloseScan_Click(object sender, EventArgs e)
        {
            txtStartingScan.Text = "";
            hfEndingSeries.Value = "";
            lblScanUnits.Text = "";

            Response.Redirect(Request.Url.AbsoluteUri);
            ModalScan.Hide();
        }

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ifFinish = ((System.Web.UI.WebControls.Label)e.Row.FindControl("ifFinish")).Text;
                string ff = Convert.ToString(ifFinish);
                if (ff.Trim().ToLower() == "true")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
           
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (hfIdScan.Value != "")
            {
                SqlCommand cmd = new SqlCommand("Select IsRejected From SSPNewRequest Where  ID = @ID and Supplier = @Supplier", sqlCon);
                cmd.Parameters.AddWithValue("@ID", int.Parse(hfIdScan.Value));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    hfisRejected.Value = dr.GetValue(0).ToString();
                    if (hfisRejected.Value == "False")
                    {
                        ReportParameter series = new ReportParameter("SeriesReport", txtSeries.Text, true);
                        this.RvSeries.LocalReport.SetParameters(new ReportParameter[] { series });
                        Print();
                        ModalPrint.Show();
                    }
                    else
                    {
                        ModalPass.Show();
                        
                    }
                }
                sqlCon.Close();
            }
        }
        public void Print()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("IfPrint", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfIdScan.Value == "" ? 0 : Convert.ToInt32(hfIdScan.Value)));
            sqlCmd.Parameters.AddWithValue("@IsRejected", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            FillGridView();

        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlCommand cmd2 = new SqlCommand("Users_Verify", con))
            {
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@UserName", Session["Username"].ToString());
                cmd2.Parameters.AddWithValue("@Password", AllUsers.EncryptData(txtPass.Text));
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlDataReader sdr = cmd2.ExecuteReader();
                if (sdr.Read())
                {
                    ReportParameter series = new ReportParameter("SeriesReport", txtSeries.Text, true);
                    this.RvSeries.LocalReport.SetParameters(new ReportParameter[] { series });
                    ModalPass.Hide();
                    ModalPrint.Show();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Invalid Password!','You clicked the button!', 'warning')", true);
                }
            }
        }

















        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConnectionString);
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlCommand sqlCmd = new SqlCommand("RejectedBySupp", sqlCon);
        //    sqlCmd.CommandType = CommandType.StoredProcedure;
        //    sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
        //    sqlCmd.Parameters.AddWithValue("@RequestID", txtRequestID.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@TicketNO ", txtTicket.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@PoNO", txtPO.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@ScheduleRequest", txtDate.Text.Trim());
        //    sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Value);
        //    sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Value);
        //    sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
        //    sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
        //    sqlCmd.Parameters.AddWithValue("@UpdatedBy", Session["Username"].ToString());
        //    sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
        //    sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
        //    sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
        //    sqlCmd.Parameters.AddWithValue("@IsActive", "1");
        //    sqlCmd.Parameters.AddWithValue("@IsRejected", "1");
        //    sqlCmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //    Clear();
        //    FillGridView();
        //    lblSuccess.Text = "Rejected Request Successfully!";
        //}

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{

        //    LinkButton linkdownload = sender as LinkButton;
        //    GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
        //    string downloadfile = Gridview1.DataKeys[gridrow.RowIndex].Value.ToString();
        //    Response.ContentType = "Text/txt";
        //    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
        //    Response.TransmitFile(Server.MapPath(downloadfile));
        //    Response.End();

        //}

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{

        //}
    }
}

