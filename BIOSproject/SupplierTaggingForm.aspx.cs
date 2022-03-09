﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;


namespace BIOSproject
{
    public partial class SupplierTaggingForm : System.Web.UI.Page
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
                    adding();
                    product();


                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                    txtDate2.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();

                
            }
            }
          
            protected void product()
            {
                string mainconn = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                string sqlqueryy = "select * from Reference";
                SqlCommand sqlcom = new SqlCommand(sqlqueryy, con);
                con.Open();
                SqlDataAdapter dr = new SqlDataAdapter(sqlcom);
                DataTable td = new DataTable();
                dr.Fill(td);
                DropProduct.DataSource = td;
                DropProduct.DataTextField = "ItemDescr";
                DropProduct.DataValueField = "ItemDescr";
                DropProduct.DataBind();
                DropProduct.Items.Insert(0, new ListItem("-- Select --", "0"));
                con.Close();
            }
        protected void DropDesti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDesti.SelectedValue == "B")
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
            else if (DropDesti.SelectedValue == "H")
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
            else if (DropDesti.SelectedValue == "W")
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
                SqlCommand sqlcmd = new SqlCommand("Select * from [ref_Branches] where BranchID =" + BranchID, sqlcon);
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


            void FillGridView()
            {
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SupplierTagging", sqlCon);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                sqlCon.Close();
                Gridview1.DataSource = dtbl;
                Gridview1.DataBind();
                Gridview1.UseAccessibleHeader = true;
                Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            public void adding()
            {
                lblUnits.Text = "0";
                double start, end, answer;
                double.TryParse(LabelStart.Text, out start);
                double.TryParse(LabelEnd.Text, out end);


                answer = end - start + 1;
                if (answer > 0 && LabelStart.Text != "" && LabelEnd.Text != "")
                    lblUnits.Text = answer.ToString();
            }
        protected void txtSeries_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtSeries.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID, EndingSeries, ProductQuantity,StartingSeries From SSPNewRequest Where StartingSeries = @Series and WHcheck = '0' and Supplier = @Supplier or EndingSeries = @Series and WHcheck = '0' and Supplier = @Supplier", sqlCon);
                cmd.Parameters.AddWithValue("@Series", int.Parse(txtSeries.Text));
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    LabelStart.Text = dr.GetValue(3).ToString();
                    LabelEnd.Text = dr.GetValue(1).ToString();

                    hfId1.Value = dr.GetValue(0).ToString();
                    DropProduct.SelectedItem.Text = dr.GetValue(2).ToString();
                    DropProduct.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                    txtSeries.Text = "";
                    product();
                    DropProduct.Enabled = true;
                    btnUpdate.Enabled = false;
                }
                sqlCon.Close();
            }
            else if (txtSeries.Text == "")
            {
                LabelStart.Text = "";
                LabelEnd.Text = "";

                btnUpdate.Enabled = false;
                product();
                DropProduct.Enabled = true;
            }
            adding();
        }
        //protected void txtStart_TextChanged(object sender, EventArgs e)
        //    {
                
        //    }

            //protected void txtEnd_TextChanged(object sender, EventArgs e)
            //{
            //    adding();
            //}

            protected void btnInquiry_Click(object sender, EventArgs e)
            {
            txtSearch.Text = "";
                ModalInquiry.Show();
            txtTracking.Text = "";
            txtArea.Text = "";
            txtTeam.Text = "";
            txtBranch.Text = "";
            txtDateTracking.Text = "";
            txtStartTracking.Text = "";
            txtEndTracking.Text = "";
            }

        protected void btnClear_Click(object sender, EventArgs e)
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

            txtSeries.Text = "";
            LabelStart.Text = "";
            LabelEnd.Text = "";
            DropDesti.SelectedValue = "S";
            lblUnits.Text = Convert.ToString(0);
            product();
            cascadingdropdown();
            btnUpdate.Enabled = false;
            DropProduct.Enabled = true;
            hfId1.Value = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TaggingbySupp", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Hub", DropHub.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Warehouse", DropWare.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DestinationTo", DropDesti.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@WHcheck", "1");
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            tagging();
            
            string Id = hfId1.Value;

            // validations
            if (Id == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);
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


                txtSeries.Text = "";
                LabelStart.Text = "";
                LabelEnd.Text = "";
                DropDesti.SelectedValue = "S";
                lblUnits.Text = Convert.ToString(0);
                product();
                cascadingdropdown();
                FillGridView();
                btnUpdate.Enabled = false;
                DropProduct.Enabled = true;
                hfId1.Value = "";
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
                //lblSuccess.Text = "Please Cornfirm your Details!";
            }
        }
        public void tagging()
        {
            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand sqlCmd = new SqlCommand("TaggingFinished", sqlCon2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@RequestID", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Hub", DropHub.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@ScheduledDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@DestinationTo", DropDesti.SelectedItem.Text);
            sqlCmd.ExecuteNonQuery();
            sqlCon2.Close();
            Clear();
        }
        private void Clear()
        {
            hfId1.Value = "";
        }
        void FilterRecords()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierDateFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Date", txtDate2.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            FilterRecords();
        }
        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierPerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = false;
            //Gridview1.Columns[4].Visible = true;
        }
        void fill2()
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierPerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = true;
            //Gridview1.Columns[4].Visible = false;
        }
        void fill3()
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierPerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            sqlData.SelectCommand.Parameters.AddWithValue("@Desti", DropPer.SelectedItem.Text);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //Gridview1.Columns[3].Visible = true;
            //Gridview1.Columns[4].Visible = false;
        }

        protected void DropPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropPer.SelectedItem.Value == "B")
            {
                txtSearch.Text = "";
                fill();
            }
            else if (DropPer.SelectedItem.Value == "W") 
            {
                txtSearch.Text = "";
                fill2();
            }
            else if (DropPer.SelectedItem.Value == "S")
            {
                txtSearch.Text = "";
                FillGridView();
            }
            else if (DropPer.SelectedItem.Value == "H")
            {
                txtSearch.Text = "";
                fill3();
            }
        }

        protected void txtTracking_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            if (txtTracking.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select Area, Team, Branch, ScheduleDate, StartingSeries, EndingSeries from SSPNewRequest where StartingSeries <= @search and EndingSeries >= @search and Supplier = @Supplier and forHitCheck = '1' and ifSend = '1'  and WHcheck = '1'", sqlCon);
                cmd.Parameters.AddWithValue("@search", txtTracking.Text);
                cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtArea.Text = dr.GetValue(0).ToString();
                    txtTeam.Text = dr.GetValue(1).ToString();
                    txtBranch.Text = dr.GetValue(2).ToString();
                    txtDateTracking.Text = dr.GetValue(3).ToString();
                    txtStartTracking.Text = dr.GetValue(4).ToString();
                    txtEndTracking.Text = dr.GetValue(5).ToString();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                }
                sqlCon.Close();
            }
            else
            {
                txtArea.Text = "";
                txtTeam.Text = "";
                txtBranch.Text = "";
                txtDateTracking.Text = "";
                txtStartTracking.Text = "";
                txtEndTracking.Text = "";
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SuppPrint";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            RvSuppPrint.LocalReport.DataSources.Add(new ReportDataSource("DataSetSuppPrint", dt));
            RvSuppPrint.LocalReport.ReportPath = Server.MapPath("~/Report/ReportSuppPrint.rdlc");
            RvSuppPrint.LocalReport.EnableHyperlinks = true;
            FillGridView();
            txtSearch.Text = "";
            ModalPrint.Show();
        }

        protected void btnCloseDetails_Click(object sender, EventArgs e)
        {
            ModalDetails.Hide();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Button HitCheck = (sender as Button);
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
            hfDesti.Value = commandArguments[4];
            if (hfDesti.Value == "Branches")
            {
                lblID.Text = commandArguments[0];
                lblBr.Text = commandArguments[1];
                lblTe.Text = commandArguments[2];
                lblAr.Text = commandArguments[3];

                lblHu.Visible = false;
                lblWar.Visible = false;
                LabelHu.Visible = false;
                LabelWar.Visible = false;

                LabelBr.Visible = true;
                LabelTe.Visible = true;
                LabelAr.Visible = true;

                lblBr.Visible = true;
                lblTe.Visible = true;
                lblAr.Visible = true;
                ModalDetails.Show();
            }
            else if(hfDesti.Value == "Hub")
            {
                lblID.Text = commandArguments[0];
                lblHu.Visible = true;
                lblWar.Visible = false;

                LabelHu.Visible = true;
                LabelWar.Visible = false;

                LabelBr.Visible = false;
                LabelTe.Visible = false;
                LabelAr.Visible = false;


                lblBr.Visible = false;
                lblTe.Visible = false;
                lblAr.Visible = false;

                lblHu.Text = commandArguments[5];
                ModalDetails.Show();
            }
            else if (hfDesti.Value == "Warehouse")
            {
                lblID.Text = commandArguments[0];
                LabelBr.Visible = false;
                lblBr.Visible = false;
                LabelTe.Visible = false;
                lblTe.Visible = false;
                LabelAr.Visible = false;
                lblAr.Visible = false;
                LabelHu.Visible = false;
                lblHu.Visible = false;

                LabelWar.Visible = true;
                lblWar.Visible = true;
                lblWar.Text = commandArguments[6];
                ModalDetails.Show();
            }

            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(maincon);
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            string sqlquery = "select * from SSPNewRequest where Branch like '%'+@BranchCode+'%' and Supplier = @Supplier and WHcheck = '1'";
            sqlcmd.CommandText = sqlquery;
            sqlcmd.Connection = sqlcon;
            sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
            sqlcmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            sda.Fill(dt);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

        }
    }
}