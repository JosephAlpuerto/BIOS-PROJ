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

           
        ////protected void txtStartingScan_TextChanged(object sender, EventArgs e)
        ////{
        ////    SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
        ////    sqlCon3.Open();
        ////    if (txtStartingScan.Text != "")
        ////    {
        ////        SqlCommand cmd = new SqlCommand("Select ID,TicketNo,PONumber,Supplier,ProductQuantity,TotalQuantity,Quantity,StartingSeries,EndingSeries,RequestNo,SupplierName From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and ifFinish = '0'", sqlCon3);
        ////        cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartingScan.Text));
        ////        cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

        ////        SqlDataReader dr = cmd.ExecuteReader();
        ////        if (dr.Read())
        ////        {
        ////            ID.Value = dr.GetValue(0).ToString();
        ////            TicketNo.Value = dr.GetValue(1).ToString();
        ////            PONumber.Value = dr.GetValue(2).ToString();
        ////            Supplier.Value = dr.GetValue(3).ToString();
        ////            ProductQuantity.Value = dr.GetValue(4).ToString();
        ////            TotalQuantity.Value = dr.GetValue(5).ToString();
        ////            Quantity.Value = dr.GetValue(6).ToString();
        ////            StartingSeries.Value = dr.GetValue(7).ToString();
        ////            EndingSeries.Value = dr.GetValue(8).ToString();
        ////            RequestNo.Value = dr.GetValue(9).ToString();
        ////            SupplierName.Value = dr.GetValue(10).ToString();

        ////            hfEndingSeries2.Value = dr.GetValue(8).ToString();
        ////            txtEndingScan.Text = dr.GetValue(8).ToString();
        ////            addingScan();

        ////            lblTotal.Text = dr.GetValue(6).ToString();
        ////            btnOkay.Visible = true;

        ////            txtProduct.Text = dr.GetValue(4).ToString();
        ////            txtProduct.Visible = true;
        ////            lblProduct.Visible = true;
        ////            //lblBundle.Visible = true;
        ////            //lblBundleNo.Visible = true;


        ////            if (lblScanUnits.Text == lblTotal.Text)
        ////            {
        ////                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Scan()", true);
        ////            }
        ////            else {
        ////                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('This series are not equal quantities.','You clicked the button!', 'warning')", true);
        ////            }
        ////        }
        ////        else
        ////        {
        ////            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
        ////        }
        ////        sqlCon3.Close();
        ////    }
        ////    else
        ////    {
        ////        ID.Value = "";
        ////        TicketNo.Value = "";
        ////        PONumber.Value = "";
        ////        Supplier.Value = "";
        ////        ProductQuantity.Value = "";
        ////        TotalQuantity.Value = "";
        ////        Quantity.Value = "";
        ////        StartingSeries.Value = "";
        ////        EndingSeries.Value = "";
        ////        RequestNo.Value = "";
        ////        SupplierName.Value = "";

        ////        hfEndingSeries2.Value = "";
        ////        txtStartingScan.Text = "";
        ////        txtEndingScan.Text = "";
        ////        lblScanUnits.Text = "0";

        ////        lblTotal.Text = "0";
        ////        btnOkay.Visible = false;

        ////        txtProduct.Text = "";
        ////        txtProduct.Visible = false;
        ////        lblProduct.Visible = false;
        ////        //lblBundle.Visible = false;
        ////        //lblBundleNo.Visible = false;
        ////    }
        //}
        //protected void txtEndingScan_TextChanged(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon4 = new SqlConnection(ConnectionString);
        //    sqlCon4.Open();
        //    if (txtEndingScan.Text != "")
        //    {
        //        SqlCommand cmd = new SqlCommand("Select ID,TicketNo,PONumber,Supplier,ProductQuantity,TotalQuantity,Quantity,StartingSeries,EndingSeries,RequestNo,SupplierName From SSPNewRequest Where  EndingSeries = @EndingSeries and Supplier = @Supplier and ifFinish = '0'", sqlCon4);
        //        cmd.Parameters.AddWithValue("@EndingSeries", int.Parse(txtEndingScan.Text));
        //        cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            ID.Value = dr.GetValue(0).ToString();
        //            TicketNo.Value = dr.GetValue(1).ToString();
        //            PONumber.Value = dr.GetValue(2).ToString();
        //            Supplier.Value = dr.GetValue(3).ToString();
        //            ProductQuantity.Value = dr.GetValue(4).ToString();
        //            TotalQuantity.Value = dr.GetValue(5).ToString();
        //            Quantity.Value = dr.GetValue(6).ToString();
        //            StartingSeries.Value = dr.GetValue(7).ToString();
        //            EndingSeries.Value = dr.GetValue(8).ToString();
        //            RequestNo.Value = dr.GetValue(9).ToString();
        //            SupplierName.Value = dr.GetValue(10).ToString();

        //            hfEndingSeries2.Value = dr.GetValue(8).ToString();
        //            txtStartingScan.Text = dr.GetValue(7).ToString();
        //            addingScan();

        //            lblTotal.Text = dr.GetValue(6).ToString();
        //            btnOkay.Visible = true;

        //            txtProduct.Text = dr.GetValue(4).ToString();
        //            txtProduct.Visible = true;
        //            lblProduct.Visible = true;
        //            //lblBundle.Visible = true;
        //            //lblBundleNo.Visible = true;

        //            if (lblScanUnits.Text == lblTotal.Text)
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Scan2()", true);
        //            }
        //            else
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('This series are not equal quantities.','You clicked the button!', 'warning')", true);
        //            }
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
        //        }
        //        sqlCon4.Close();
        //    }
        //    else
        //    {
        //        ID.Value = "";
        //        TicketNo.Value = "";
        //        PONumber.Value = "";
        //        Supplier.Value = "";
        //        ProductQuantity.Value = "";
        //        TotalQuantity.Value = "";
        //        Quantity.Value = "";
        //        StartingSeries.Value = "";
        //        EndingSeries.Value = "";
        //        RequestNo.Value = "";
        //        SupplierName.Value = "";

        //        hfEndingSeries2.Value = "";
        //        txtStartingScan.Text = "";
        //        txtEndingScan.Text = "";
        //        lblScanUnits.Text = "0";

        //        lblTotal.Text = "0";
        //        btnOkay.Visible = false;

        //        txtProduct.Text = "";
        //        txtProduct.Visible = false;
        //        lblProduct.Visible = false;
        //        //lblBundle.Visible = false;
        //        //lblBundleNo.Visible = false;
        //    }
        //}

        protected void btnclose_Click(object sender, EventArgs e)
        {
            txtStartSeries.Text = "";
            //txtEndingScan.Text = "";
            lblTotal.Text = "0";
            lblScanUnits.Text = "0";
            btnOkay.Visible = false;
        }
        
        public void InsertDB()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("InsertFinishGood", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketNo", TicketNo.Value);
            cmd.Parameters.AddWithValue("@Supplier", Supplier.Value);
            cmd.Parameters.AddWithValue("@PONumber", PONumber.Value);
            cmd.Parameters.AddWithValue("@Product", ProductQuantity.Value);
            cmd.Parameters.AddWithValue("@TotalQuantity", lblTotal.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtUnits.Text);
            cmd.Parameters.AddWithValue("@StartingSeries", hfstart.Value);
            cmd.Parameters.AddWithValue("@EndingSeries", hfend.Value);
            cmd.Parameters.AddWithValue("@RequestNo", RequestNo.Value);
            cmd.Parameters.AddWithValue("@SupplierName", SupplierName.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@RequestID", ID.Value);
            cmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse(Alabang)");
            cmd.ExecuteNonQuery();
            con.Close();
            finish();
        }
        public void Scan()
        {
            addingScan();
            if (lblScanUnits.Text != lblTotal.Text)
            {
                StartSeries.Visible = false;
                txtStart.Visible = false;
                txtStart.Text = "";

                Units.Visible = true;
                txtUnits.Visible = true;
                txtUnits.Enabled = true;
                txtUnits.Text = "";

                LabelSeries.Visible = false;
                lblSeries.Visible = false;
                txtSeries.Visible = false;
                txtSeries.Text = "";

                hfend.Value = "";
                hfstart.Value = "";

                if (txtStart.Text == "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Saved()", true);
                }
            }
            else
            {
                txtSeries.Text = "";
                hfend.Value = "";
                hfstart.Value = "";

                txtStartSeries.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "AllSaved()", true);
                clearScan();
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
            if (txtStartSeries.Text != "" && txtUnits.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID, EndingSeries From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and forHitCheck = '1' and ifSend = '1'  and WHcheck = '0'", sqlCon);
                cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartSeries.Text));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    hfIDScan2.Value = dr.GetValue(0).ToString();
                    hfEndingSeries2.Value = dr.GetValue(1).ToString();
                    //addingScan();
                    InsertDB();
                    Scan();
                    lblSeries2.Visible = false;
                    txtStart.Enabled = true;
                    
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Unit()", true);
            }
        }
        
        protected void txtStartSeries_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
            sqlCon3.Open();
            if (txtStartSeries.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID,TicketNo,PONumber,Supplier,ProductQuantity,TotalQuantity,Quantity,StartingSeries,EndingSeries,RequestNo,SupplierName From SSPNewRequest Where  StartingSeries = @StartingSeries and Supplier = @Supplier and ifFinish = '0'", sqlCon3);
                cmd.Parameters.AddWithValue("@StartingSeries", int.Parse(txtStartSeries.Text));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblStart.Text = dr.GetValue(7).ToString();
                    lblEnd.Text = dr.GetValue(8).ToString();
                    
                    Units.Visible = true;
                    txtUnits.Visible = true;
                    

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
                    //txtEndingScan.Text = dr.GetValue(8).ToString();
                    

                    lblTotal.Text = dr.GetValue(6).ToString();
                    

                    txtProduct.Text = dr.GetValue(4).ToString().Trim();
                    txtProduct.Visible = true;
                    lblProduct.Visible = true;
                    //lblBundle.Visible = true;
                    //lblBundleNo.Visible = true;


                    if (Quantity.Value == lblTotal.Text)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Scan()", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('This series are not equal quantities.','You clicked the button!', 'warning')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                }
                sqlCon3.Close();
            }
            else
            {
                lblStart.Text = "";
                lblEnd.Text = "";
                
                Units.Visible = false;
                txtUnits.Visible = false;

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

                hfEndingSeries2.Value = "";
                txtStartSeries.Text = "";
                //txtEndingScan.Text = "";
                lblScanUnits.Text = "0";

                lblTotal.Text = "0";
                btnOkay.Visible = false;

                txtProduct.Text = "";
                txtProduct.Visible = false;
                lblProduct.Visible = false;
                //lblBundle.Visible = false;
                //lblBundleNo.Visible = false;
            }
        }
        public void addingScan()
        {
            //lblUnits.Text = "0";
            double txUnit, lbUnit, answer;
            double.TryParse(txtUnits.Text, out txUnit);
            double.TryParse(lblScanUnits.Text, out lbUnit);

            answer = txUnit + lbUnit;
            if (answer > 0)
                lblScanUnits.Text = answer.ToString();
        }
        protected void txtUnits_TextChanged(object sender, EventArgs e)
        {
            string Product = txtProduct.Text.Replace("\r", "").Replace("\n", "");
            if (Product == Convert.ToString("KILOBOX MINI W/1 BARCODE /10-101603") || Product == Convert.ToString("KILOBOX SLIM W/1 BARCODE /10-101641") || Product == Convert.ToString("KILOBOX SMALL W/1 BARCODE /10-101712") || Product == Convert.ToString("KILOBOX MEDIUM W/1 BARCODE /10-101713") || Product == Convert.ToString("KILOBOX LARGE W/1 BARCODE /10-101714") || Product == Convert.ToString("KILOBOX XL W/1 BARCODE /10-101715") || Product == Convert.ToString("V-POUCH /10-101711"))
            {
                if (txtUnits.Text != "")
                {
                    if (Convert.ToInt32(txtUnits.Text) < 10)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "CheckUnit()", true);
                        StartSeries.Visible = false;
                        txtStart.Visible = false;
                        txtStart.Text = "";
                    }
                    else if (Convert.ToInt32(txtUnits.Text) > Convert.ToInt32(lblTotal.Text))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "CheckUnit()", true);
                        StartSeries.Visible = false;
                        txtStart.Visible = false;
                        txtStart.Text = "";
                    }
                    else if (Convert.ToInt32(txtUnits.Text) == 10 || Convert.ToInt32(txtUnits.Text) == Convert.ToInt32(lblTotal.Text))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "CheckUnitSuccess()", true);
                        StartSeries.Visible = true;
                        txtStart.Visible = true;
                        txtSeries.Text = "";
                        lblSeries.Text = "";
                    }
                    else if (Convert.ToInt32(txtUnits.Text) != Convert.ToInt32(lblTotal.Text) || Convert.ToInt32(txtUnits.Text) != 10 || Convert.ToInt32(txtUnits.Text) == Convert.ToInt32(lblTotal.Text))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "CheckUnit()", true);
                        StartSeries.Visible = false;
                        txtStart.Visible = false;
                        txtStart.Text = "";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "CheckUnit()", true);
                    StartSeries.Visible = false;
                    txtStart.Visible = false;
                    txtStart.Text = "";
                }
                
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
            }
        }
        public void Hitcheck()
        {
            int start = new int();
            int end = new int();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SeriesFinished";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", txtStart.Text);
            cmd.Parameters.AddWithValue("@startmin", start);
            cmd.Parameters.AddWithValue("@endmax", end);
            conn.Open();
            SqlCommand sql = new SqlCommand();
            string sqlquery = "select * from FinishedGood where StartingSeries <= @search and EndingSeries >= @search";
            sql.CommandText = sqlquery;
            sql.Connection = conn;
            sql.Parameters.AddWithValue("@search", Convert.ToInt64(txtStart.Text));
            //sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            //DataTable dt = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(sql);
            //sda.Fill(dt);

            SqlDataReader sdr = sql.ExecuteReader();
            if (sdr.Read())
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "HitcheckError()", true);
                txtStart.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "HitcheckSuccess()", true);
            }

            con.Close();
            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlData = new SqlDataAdapter("CheckDuplicateFinishGood", sqlCon);
            //sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Id", ID.Value);
            //sqlData.SelectCommand.Parameters.AddWithValue("@StartingSeries", txtStart.Text);
            //sqlData.SelectCommand.Parameters.AddWithValue("@EndingSeries", EndingSeries.Value);

            //SqlDataReader sdr = sqlData.SelectCommand.ExecuteReader();
            //if (sdr.Read())
            //{
            //}
            //else
            //{  
            //}
            //sqlCon.Close();
        }
        public void UnitAddStart()
        {
            if(hfend.Value == "" && hfstart.Value == "")
            {
                hfstart.Value = txtStart.Text;
                hfend.Value = txtStart.Text;
            }
            else
            {
                if (Convert.ToInt64(hfstart.Value) > Convert.ToInt64(txtStart.Text))
                {
                    hfstart.Value = txtStart.Text;
                }
                else if (Convert.ToInt64(hfend.Value) < Convert.ToInt64(txtStart.Text))
                {
                    hfend.Value = txtStart.Text;
                }
            }
            
        }
        protected void txtStart_TextChanged(object sender, EventArgs e)
        {
            if (txtStart.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "Series()", true);
                if (txtSeries.Text == "")
                {
                    txtUnits.Enabled = true;
                    txtSeries.Text = "";
                    txtSeries.Visible = false;
                    LabelSeries.Visible = false;
                    lblSeries.Visible = false;
                }
                else
                {
                    txtUnits.Enabled = false;
                    txtSeries.Visible = true;
                    LabelSeries.Visible = true;
                    lblSeries.Visible = true;
                }
            }
            else
            {
                Hitcheck();
                CountSeries();
            }
            
        }
        public void equals()
        {
            if (lblSeries.Text == txtUnits.Text)
            {
                txtStart.Text = "";
                txtStart.Enabled = false;
                lblSeries2.Visible = true;
                lblSeries2.Text = "Ready to save!";
                btnOkay.Visible = true;
            }
            else
            {
                btnOkay.Visible = false;
                txtStart.Enabled = true;
            }
        }
        public void CountSeries()
        {
           
            if (txtStart.Text != "" && txtUnits.Text != "")
            {
                if (Convert.ToInt64(lblStart.Text) <= Convert.ToInt64(txtStart.Text) && Convert.ToInt64(lblEnd.Text) >= Convert.ToInt64(txtStart.Text))
                {
                    if (txtSeries.Text.Contains(txtStart.Text.Trim()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "HitcheckDuplicate()", true);
                    }
                    else
                    {
                        UnitAddStart();
                        if (txtSeries.Text == "")
                        {
                            txtUnits.Enabled = false;
                            string start = txtStart.Text;
                            string series = "";
                            series += start + System.Environment.NewLine;
                            string text = Convert.ToString(series);
                            txtSeries.Text = text;
                            txtSeries.Visible = true;
                            LabelSeries.Visible = true;

                            int no = 1;
                            int count = 0;
                            int anss;
                            anss = no + count;
                            lblSeries.Text = Convert.ToString(anss);
                            lblSeries.Visible = true;
                        }
                        else
                        {
                            txtUnits.Enabled = false;
                            string start = txtStart.Text;
                            string series = txtSeries.Text;
                            series += start + System.Environment.NewLine;
                            string text = Convert.ToString(series);
                            txtSeries.Text = text;

                            int no = 1;
                            int count = Convert.ToInt32(lblSeries.Text);
                            int anss;
                            anss = no + count;
                            lblSeries.Text = Convert.ToString(anss);
                            lblSeries.Visible = true;
                            equals();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "randomtext", "HitcheckSame()", true);
                }
                
                //txtUnits.Enabled = false;
                //int start = int.Parse(txtStart.Text);
                //int unit = int.Parse(txtUnits.Text);
                //int end = start + unit - 1;
                //string series = "";
                //for (int i = start; i <= end; i++)
                //{
                //    series += i.ToString() + System.Environment.NewLine;
                //}
                //string text = Convert.ToString(series);
                //txtSeries.Text = text;
                //txtSeries.Visible = true;
                //LabelSeries.Visible = true;
            }
            else
            {
                if (txtSeries.Text == "")
                {
                    txtSeries.Visible = false;
                    LabelSeries.Visible = false;
                    lblSeries.Visible = false;
                    txtUnits.Enabled = true;
                }
                else
                {
                    txtSeries.Visible = true;
                    LabelSeries.Visible = true;
                    lblSeries.Visible = true;
                    txtUnits.Enabled = false;
                }
                
            }
        }
    }
}