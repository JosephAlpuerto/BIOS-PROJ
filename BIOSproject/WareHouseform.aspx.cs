using System;
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
    public partial class WareHouseform : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                FillGridView();
                FillGridView2();
                //cascadingdropdown();
                adding();
                product();


                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                txtDate2.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();

                if (ViewState["Records"] == null)
                {
                    ViewState["Records"] = dt;
                }
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


        //protected void cascadingdropdown()
        //{
        //        SqlConnection sqlcon = new SqlConnection(mainconn);
        //        sqlcon.Open();
        //        SqlCommand sqlcmd = new SqlCommand("SELECT [BranchID],[BranchCode] + ' - ' + [BranchDescr] as BranchCodeDesc FROM [ref_Branches]", sqlcon);
        //        sqlcmd.CommandType = CommandType.Text;
        //        DropBranch.DataSource = sqlcmd.ExecuteReader();
        //        DropBranch.DataTextField = "BranchCodeDesc";
        //        DropBranch.DataValueField = "BranchID";
        //        DropBranch.DataBind();
        //        DropBranch.SelectedItem.Text = Convert.ToString(DBNull.Value);

        //}
        protected void DropBranch_TextChanged(object sender, EventArgs e)
        {
            if (DropBranch.Text != "")
            {
                string CodeDescr = DropBranch.Text;
                SqlConnection sqlcon = new SqlConnection(mainconn);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select * from [ref_Branches] where BranchCode +' - '+ BranchDescr = '" + CodeDescr + "'", sqlcon);
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
            else
            {
                DropTeam.Items.Clear();
                DropArea.Items.Clear();
            }
        }

        //protected void dropdown()
        //{

        //    int BranchID = Convert.ToInt32(DropBranch.SelectedValue);
        //    SqlConnection sqlcon = new SqlConnection(mainconn);
        //    sqlcon.Open();
        //    SqlCommand sqlcmd = new SqlCommand("Select * from [ref_Branches] where BranchID =" + BranchID, sqlcon);
        //    sqlcmd.CommandType = CommandType.Text;
        //    DropTeam.DataSource = sqlcmd.ExecuteReader();
        //    DropTeam.DataTextField = "TeamDescr";
        //    DropTeam.DataValueField = "AreaID";
        //    DropTeam.DataBind();

        //    int TeamID = Convert.ToInt32(DropTeam.SelectedValue);
        //    SqlConnection sqlcon2 = new SqlConnection(mainconn);
        //    sqlcon2.Open();
        //    SqlCommand sqlcmd2 = new SqlCommand("Select * from [Areas] where AreaId =" + TeamID, sqlcon2);
        //    sqlcmd.CommandType = CommandType.Text;
        //    DropArea.DataSource = sqlcmd2.ExecuteReader();
        //    DropArea.DataTextField = "AreaDescr";
        //    DropArea.DataValueField = "AreaID";
        //    DropArea.DataBind();
        //}

        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehouseTagging", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Warehouse", Session["Username"].ToString());
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            Gridview1.DataSource = dtbl;
            Gridview1.DataBind();
            Gridview1.UseAccessibleHeader = true;
            Gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //Gridview1.FooterRow.TableSection = TableRowSection.TableFooter;
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
            if(txtSeries.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select ID, EndingSeries, Product, StartingSeries From FinishedGood Where  StartingSeries = @Series and DestinationTo = 'Warehouse' or  EndingSeries = @Series and DestinationTo = 'Warehouse'", sqlCon);
                cmd.Parameters.AddWithValue("@Series", int.Parse(txtSeries.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    LabelStart.Text = dr.GetValue(3).ToString();
                    LabelEnd.Text = dr.GetValue(1).ToString();

                    hfId1.Value = dr.GetValue(0).ToString();
                    DropProduct.SelectedItem.Text = dr.GetValue(2).ToString();
                    DropProduct.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnAdd.Enabled = true;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('No Record!','You clicked the button!', 'warning')", true);
                    txtSeries.Text = "";
                    product();
                    DropProduct.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnAdd.Enabled = false;
                }
                sqlCon.Close();
            }
            else if (txtSeries.Text == "")
            {
                LabelStart.Text = "";
                LabelEnd.Text = "";

                btnUpdate.Enabled = false;
                btnAdd.Enabled = false;
                product();
                DropProduct.Enabled = true;
            }
            adding();
        }

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
            //cascadingdropdown();
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            DropProduct.Enabled = true;
            hfId1.Value = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("TaggingbyWarehouse", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            //sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            //sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.SelectedItem.Text);
            //sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            //sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@IfProcess", "1");
            //sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();
            //tagging();
            //FillGridView();
            //string Id = hfId1.Value;

            //// validations
            //if (Id == "")
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);

            //    DropArea.Items.Clear();
            //    DropTeam.Items.Clear();

            //    txtStart.Text = "";
            //    txtEnd.Text = "";
            //    lblUnits.Text = Convert.ToString(0);
            //    product();
            //    cascadingdropdown();
            //    btnUpdate.Enabled = false;
            //    DropProduct.Enabled = true;
            //    hfId1.Value = "";
            //}
            //else
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
            //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
            //    //lblSuccess.Text = "Please Cornfirm your Details!";
            //}

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TaggingbySupp", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.Text);
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Hub", DropHub.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse (Alabang)");
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
                //cascadingdropdown();
                FillGridView();
                btnUpdate.Enabled = false;
                btnAdd.Enabled = false;
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
            sqlCmd.Parameters.AddWithValue("@Branch", DropBranch.Text);
            sqlCmd.Parameters.AddWithValue("@Team", DropTeam.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Area", DropArea.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@Hub", DropHub.SelectedItem.Text);
            sqlCmd.Parameters.AddWithValue("@ScheduledDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@DestinationTo", "Branch");
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
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehouseDateFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Desti", Session["Username"].ToString());
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
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehousePerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehousePerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
            SqlDataAdapter sqlData = new SqlDataAdapter("WarehousePerFilter", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
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
                SqlCommand cmd = new SqlCommand("Select Area, Team, Branch, ScheduleDate, StartingSeries, EndingSeries from SSPNewRequest where StartingSeries <= @search and EndingSeries >= @search and Warehouse = 'Blossom Warehouse (Alabang)' and forHitCheck = '1' and ifSend = '1'  and WHcheck = '1'", sqlCon);
                cmd.Parameters.AddWithValue("@search", txtTracking.Text);
                //cmd.Parameters.AddWithValue("@Desti", Session["Username"].ToString());

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
            cmd.CommandText = "WarehousePrint";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Desti", Session["Username"].ToString());
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            RvSuppPrint.LocalReport.DataSources.Add(new ReportDataSource("DataSetWarehousePrint", dt));
            RvSuppPrint.LocalReport.ReportPath = Server.MapPath("~/Report/ReportWarehousePrint.rdlc");
            RvSuppPrint.LocalReport.EnableHyperlinks = true;
            FillGridView();
            txtSearch.Text = "";
            ModalPrint.Show();
        }
        protected void btnCloseDetails_Click(object sender, EventArgs e)
        {
            ModalDetails.Hide();
        }
        //protected void btnDetails_Click(object sender, EventArgs e)
        //{
        //    Button HitCheck = (sender as Button);
        //    string[] commandArguments = HitCheck.CommandArgument.Split(',');

        //    SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
        //    if (sqlCon3.State == ConnectionState.Closed)
        //        sqlCon3.Open();
        //    SqlDataAdapter sqlData3 = new SqlDataAdapter("ViewAllByIdSSPRequest", sqlCon3);
        //    sqlData3.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sqlData3.SelectCommand.Parameters.AddWithValue("@Id", commandArguments[0]);
        //    DataTable dtbl = new DataTable();
        //    sqlData3.Fill(dtbl);
        //    sqlCon3.Close();
        //    hfDesti.Value = commandArguments[4];
        //    if (hfDesti.Value == "Branches")
        //    {
        //        lblID.Text = commandArguments[0];
        //        lblBr.Text = commandArguments[1];
        //        lblTe.Text = commandArguments[2];
        //        lblAr.Text = commandArguments[3];

        //        lblHu.Visible = false;
        //        lblWar.Visible = false;
        //        LabelHu.Visible = false;
        //        LabelWar.Visible = false;

        //        LabelBr.Visible = true;
        //        LabelTe.Visible = true;
        //        LabelAr.Visible = true;

        //        lblBr.Visible = true;
        //        lblTe.Visible = true;
        //        lblAr.Visible = true;
        //        ModalDetails.Show();
        //    }
        //    else if (hfDesti.Value == "Hub")
        //    {
        //        lblID.Text = commandArguments[0];
        //        lblHu.Visible = true;
        //        lblWar.Visible = false;

        //        LabelHu.Visible = true;
        //        LabelWar.Visible = false;

        //        LabelBr.Visible = false;
        //        LabelTe.Visible = false;
        //        LabelAr.Visible = false;


        //        lblBr.Visible = false;
        //        lblTe.Visible = false;
        //        lblAr.Visible = false;

        //        lblHu.Text = commandArguments[5];
        //        ModalDetails.Show();
        //    }
        //    else if (hfDesti.Value == "Warehouse")
        //    {
        //        lblID.Text = commandArguments[0];
        //        LabelBr.Visible = false;
        //        lblBr.Visible = false;
        //        LabelTe.Visible = false;
        //        lblTe.Visible = false;
        //        LabelAr.Visible = false;
        //        lblAr.Visible = false;
        //        LabelHu.Visible = false;
        //        lblHu.Visible = false;

        //        LabelWar.Visible = true;
        //        lblWar.Visible = true;
        //        lblWar.Text = commandArguments[6];
        //        ModalDetails.Show();
        //    }


        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
        //    SqlConnection sqlcon = new SqlConnection(maincon);
        //    sqlcon.Open();
        //    SqlCommand sqlcmd = new SqlCommand();
        //    string sqlquery = "select * from SSPNewRequest where Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse (Alabang)' and WHcheck = '1'";
        //    sqlcmd.CommandText = sqlquery;
        //    sqlcmd.Connection = sqlcon;
        //    sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
        //    sda.Fill(dt);
        //    Gridview1.DataSource = dt;
        //    Gridview1.DataBind();
        //}
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                FillGridView();
            }
            else
            {
                string maincon = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(maincon);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                string sqlquery = "select * from FinishedGood where Branch like '%'+@BranchCode+'%' and Warehouse = 'Blossom Warehouse(Alabang)' and DestinationTo != ''";
                sqlcmd.CommandText = sqlquery;
                sqlcmd.Connection = sqlcon;
                sqlcmd.Parameters.AddWithValue("@BranchCode", txtSearch.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                sda.Fill(dt);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
        }

        protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridview1.PageIndex = e.NewPageIndex;
            this.FillGridView();
        }
        void FillGridView2()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from TempTagging", sqlcon);
                sqlDa.Fill(dtbl);
            }
            gvTemp.DataSource = dtbl;
            gvTemp.DataBind();
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select BranchCode +' - '+ BranchDescr as CodeDescr from ref_Branches where BranchCode like @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["CodeDescr"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (DDLlistseries.Items.FindByText(txtSeries.Text) == null)
            {
                if (DropDesti.SelectedItem.Value != "S")
                {
                    if (DropWare.Text == "" && DropHub.Text == "")
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("Insert into TempTagging values('" + LabelStart.Text + "','" + LabelEnd.Text + "','" + DropDesti.SelectedItem.Text + "','" + DropBranch.Text + "','" + DropTeam.SelectedItem.Text + "','" + DropArea.SelectedItem.Text + "','" + DBNull.Value + "','" + DBNull.Value + "','" + txtDate.Text + "','" + lblUnits.Text + "','" + DropProduct.SelectedItem.Text + "')", conn);
                            int insert = cmd.ExecuteNonQuery();
                            DDLlistseries.Items.Add(new ListItem(LabelStart.Text, LabelStart.Text));
                            DDLlistseries.Items.Add(new ListItem(LabelEnd.Text, LabelEnd.Text));
                            if (insert > 0)
                            {
                                FillGridView();
                                FillGridView2();
                                this.DropDesti.SelectedIndex = 0;

                                lblBranch.Visible = false;
                                DropBranch.Text = "";
                                DropBranch.Visible = false;

                                DropTeam.Visible = false;
                                lblTeam.Visible = false;
                                DropTeam.Items.Clear();
                                DropArea.Visible = false;
                                lblArea.Visible = false;
                                DropArea.Items.Clear();
                                lblHub.Visible = false;
                                DropHub.Visible = false;
                                DropHub.Items.Clear();
                                lblWare.Visible = false;
                                DropWare.Visible = false;
                                DropWare.Items.Clear();
                                LabelStart.Text = "";
                                LabelEnd.Text = "";
                                lblUnits.Text = "0";
                                txtSeries.Text = "";
                                btnAdd.Enabled = true;

                               
                            }
                        }
                    }
                    else if (DropWare.Text == "" && DropBranch.Text == "")
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("Insert into TempTagging values('" + LabelStart.Text + "','" + LabelEnd.Text + "','" + DropDesti.SelectedItem.Text + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DropHub.SelectedItem.Text + "','" + txtDate.Text + "','" + lblUnits.Text + "','" + DropProduct.SelectedItem.Text + "')", conn);
                            int insert = cmd.ExecuteNonQuery();
                            if (insert > 0)
                            {
                                FillGridView();
                                FillGridView2();
                                this.DropDesti.SelectedIndex = 0;

                                lblBranch.Visible = false;
                                DropBranch.Text = "";
                                DropBranch.Visible = false;

                                DropTeam.Visible = false;
                                lblTeam.Visible = false;
                                DropTeam.Items.Clear();
                                DropArea.Visible = false;
                                lblArea.Visible = false;
                                DropArea.Items.Clear();
                                lblHub.Visible = false;
                                DropHub.Visible = false;
                                DropHub.Items.Clear();
                                lblWare.Visible = false;
                                DropWare.Visible = false;
                                DropWare.Items.Clear();
                                LabelStart.Text = "";
                                LabelEnd.Text = "";
                                lblUnits.Text = "0";
                                txtSeries.Text = "";
                                btnAdd.Enabled = true;
                            }
                        }
                    }
                    else if (DropHub.Text == "" && DropBranch.Text == "")
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("Insert into TempTagging values('" + LabelStart.Text + "','" + LabelEnd.Text + "','" + DropDesti.SelectedItem.Text + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DropWare.SelectedItem.Text + "','" + DBNull.Value + "','" + txtDate.Text + "','" + lblUnits.Text + "','" + DropProduct.SelectedItem.Text + "')", conn);
                            int insert = cmd.ExecuteNonQuery();
                            if (insert > 0)
                            {
                                FillGridView();
                                FillGridView2();
                                this.DropDesti.SelectedIndex = 0;

                                lblBranch.Visible = false;
                                DropBranch.Text = "";
                                DropBranch.Visible = false;

                                DropTeam.Visible = false;
                                lblTeam.Visible = false;
                                DropTeam.Items.Clear();
                                DropArea.Visible = false;
                                lblArea.Visible = false;
                                DropArea.Items.Clear();
                                lblHub.Visible = false;
                                DropHub.Visible = false;
                                DropHub.Items.Clear();
                                lblWare.Visible = false;
                                DropWare.Visible = false;
                                DropWare.Items.Clear();
                                LabelStart.Text = "";
                                LabelEnd.Text = "";
                                lblUnits.Text = "0";
                                txtSeries.Text = "";
                                btnAdd.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Select Destination.','You clicked the button!', 'warning')", true);
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('This Series already added in the list.','You clicked the button!', 'warning')", true);
            }

                
        }
        protected void gvTemp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTemp.EditIndex = -1;
            FillGridView2();
        }

        protected void gvTemp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                {
                    DataTable dtbl = new DataTable();
                    sqlcon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select ID, Products, Quantity from TempRequest", sqlcon);
                    sqlDa.Fill(dtbl);
                    string qry = "DELETE FROM TempTagging WHERE ID=@ID";
                    SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(gvTemp.DataKeys[e.RowIndex].Value.ToString()));
                    gvTemp.EditIndex = -1;
                    FillGridView();
                    FillGridView2();
                    sqlcmd.ExecuteNonQuery();
                    FillGridView();
                    FillGridView2();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE','Selected list Deleted!', 'success')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Selected list Deleted!')", true);
                    //lblerrorGV.Text = "";

                    //int index = Convert.ToInt32(e.RowIndex);


                    //dtbl.Rows[e.RowIndex].Delete();
                    //if (txtTotal.Text != "")
                    //{
                    //    ListItem listItem = DDL.Items[Convert.ToInt32(e.RowIndex)];
                    //    DDL.Items.Remove(listItem);
                    //    ListItem listItem2 = DDLQuantity.Items[Convert.ToInt32(e.RowIndex)];
                    //    int num1, num2, num3;
                    //    num1 = Convert.ToInt32(listItem2.Text);
                    //    num2 = Convert.ToInt32(txtTotal.Text);
                    //    num3 = num2 - num1;
                    //    txtTotal.Text = Convert.ToString(num3);
                    //    DDLQuantity.Items.Remove(listItem2);
                    //}
                    //if (Convert.ToInt32(txtTotal.Text) == 0)
                    //{
                    //    PONumber.Enabled = true;
                    //    dropSupplier.Enabled = true;
                    //}
                    ////DDL.Items.Clear();
                    //GridView.DataSource = dtbl;
                    //GridView.DataBind();
                    //lblerror.Text = "";
                    //lblerrorDrop.Text = "";
                }
            }
            catch (Exception ex)
            {
                //lblGridview.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton HitCheck = (sender as ImageButton);
            string[] commandArguments = HitCheck.CommandArgument.Split(',');

            SqlConnection sqlCon3 = new SqlConnection(ConnectionString);
            if (sqlCon3.State == ConnectionState.Closed)
                sqlCon3.Open();
            SqlDataAdapter sqlData3 = new SqlDataAdapter("ViewtempTagging", sqlCon3);
            sqlData3.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData3.SelectCommand.Parameters.AddWithValue("@Id", commandArguments[0]);
            DataTable dtbl = new DataTable();
            sqlData3.Fill(dtbl);
            sqlCon3.Close();
            hfIDedit.Value = commandArguments[0];
            lblStartSeries.Text = commandArguments[1];
            lblEndSeries.Text = commandArguments[2];
            lblQuantity.Text = commandArguments[9];
            ModalEdit.Show();
        }

        protected void DropDestiEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDestiEdit.SelectedValue == "B")
            {
                DropBranchEdit.Visible = true;
                lblBranchEdit.Visible = true;

                DropTeamEdit.Visible = true;
                lblTeamEdit.Visible = true;

                DropAreaEdit.Visible = true;
                lblAreaEdit.Visible = true;

                DropHubEdit.Visible = false;
                lblHubEdit.Visible = false;
                DropHubEdit.Items.Clear();

                DropWareEdit.Visible = false;
                lblWareEdit.Visible = false;
                DropWareEdit.Items.Clear();

                btnUpdateEdit.Enabled = true;

            }
            else if (DropDestiEdit.SelectedValue == "H")
            {
                SqlConnection sqlcon = new SqlConnection(ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT [ID], [Hub] FROM [Reference] WHERE [Hub] != 'NULL'", sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                DropHubEdit.DataSource = sqlcmd.ExecuteReader();
                DropHubEdit.DataTextField = "Hub";
                DropHubEdit.DataValueField = "ID";
                DropHubEdit.DataBind();

                DropHubEdit.Visible = true;
                lblHubEdit.Visible = true;

                DropBranchEdit.Visible = false;
                lblBranchEdit.Visible = false;
                DropBranchEdit.Text = "";
                DropTeamEdit.Visible = false;
                lblTeamEdit.Visible = false;
                DropTeamEdit.Items.Clear();
                DropAreaEdit.Visible = false;
                lblAreaEdit.Visible = false;
                DropAreaEdit.Items.Clear();
                DropWareEdit.Visible = false;
                lblWareEdit.Visible = false;
                DropWareEdit.Items.Clear();

                btnUpdateEdit.Enabled = true;

            }
            else if (DropDestiEdit.SelectedValue == "W")
            {
                SqlConnection sqlcon = new SqlConnection(ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT [ID], [WareHouse] FROM [Reference] WHERE [WareHouse] != 'NULL'", sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                DropWareEdit.DataSource = sqlcmd.ExecuteReader();
                DropWareEdit.DataTextField = "WareHouse";
                DropWareEdit.DataValueField = "ID";
                DropWareEdit.DataBind();

                DropWareEdit.Visible = true;
                lblWareEdit.Visible = true;

                DropBranchEdit.Visible = false;
                lblBranchEdit.Visible = false;
                DropBranchEdit.Text = "";
                DropTeamEdit.Visible = false;
                lblTeamEdit.Visible = false;
                DropTeamEdit.Items.Clear();
                DropAreaEdit.Visible = false;
                lblAreaEdit.Visible = false;
                DropAreaEdit.Items.Clear();
                DropHubEdit.Visible = false;
                lblHubEdit.Visible = false;
                DropHubEdit.Items.Clear();

                btnUpdateEdit.Enabled = true;
            }
            else
            {
                DropBranchEdit.Visible = false;
                lblBranchEdit.Visible = false;
                DropBranchEdit.Text = "";

                DropTeamEdit.Visible = false;
                lblTeamEdit.Visible = false;
                DropTeamEdit.Items.Clear();

                DropAreaEdit.Visible = false;
                lblAreaEdit.Visible = false;
                DropAreaEdit.Items.Clear();

                DropHubEdit.Visible = false;
                lblHubEdit.Visible = false;
                DropHubEdit.Items.Clear();

                DropWareEdit.Visible = false;
                lblWareEdit.Visible = false;
                DropWareEdit.Items.Clear();

                btnUpdateEdit.Enabled = false;
            }
        }

        protected void DropBranchEdit_TextChanged(object sender, EventArgs e)
        {
            if (DropBranchEdit.Text != "")
            {
                string CodeDescr = DropBranchEdit.Text;
                SqlConnection sqlcon = new SqlConnection(mainconn);
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select * from [ref_Branches] where BranchCode +' - '+ BranchDescr = '" + CodeDescr + "'", sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                DropTeamEdit.DataSource = sqlcmd.ExecuteReader();
                DropTeamEdit.DataTextField = "TeamDescr";
                DropTeamEdit.DataValueField = "AreaID";
                DropTeamEdit.DataBind();

                int TeamID = Convert.ToInt32(DropTeamEdit.SelectedValue);
                SqlConnection sqlcon2 = new SqlConnection(mainconn);
                sqlcon2.Open();
                SqlCommand sqlcmd2 = new SqlCommand("Select * from [Areas] where AreaId =" + TeamID, sqlcon2);
                sqlcmd.CommandType = CommandType.Text;
                DropAreaEdit.DataSource = sqlcmd2.ExecuteReader();
                DropAreaEdit.DataTextField = "AreaDescr";
                DropAreaEdit.DataValueField = "AreaID";
                DropAreaEdit.DataBind();
            }
            else
            {
                DropTeamEdit.Items.Clear();
                DropAreaEdit.Items.Clear();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList2(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select BranchCode +' - '+ BranchDescr as CodeDescr from ref_Branches where BranchCode like @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> BranchCode = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            BranchCode.Add(sdr["CodeDescr"].ToString());
                        }
                    }
                    con.Close();
                    return BranchCode;
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnUpdateEdit_Click(object sender, EventArgs e)
        {
            if (DropDestiEdit.SelectedItem.Value == "B")
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UpdateTempTagging", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", hfIDedit.Value);
                cmd.Parameters.AddWithValue("@DestinationTo", DropDestiEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Branch", DropBranchEdit.Text);
                cmd.Parameters.AddWithValue("@Team", DropTeamEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Area", DropAreaEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Warehouse", DBNull.Value);
                cmd.Parameters.AddWithValue("@Hub", DBNull.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                FillGridView2();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else if (DropDestiEdit.SelectedItem.Value == "W")
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UpdateTempTagging", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", hfIDedit.Value);
                cmd.Parameters.AddWithValue("@DestinationTo", DropDestiEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Branch", DBNull.Value);
                cmd.Parameters.AddWithValue("@Team", DBNull.Value);
                cmd.Parameters.AddWithValue("@Area", DBNull.Value);
                cmd.Parameters.AddWithValue("@Warehouse", DropWareEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Hub", DBNull.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                FillGridView2();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else if (DropDestiEdit.SelectedItem.Value == "H")
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UpdateTempTagging", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", hfIDedit.Value);
                cmd.Parameters.AddWithValue("@DestinationTo", DropDestiEdit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Branch", DBNull.Value);
                cmd.Parameters.AddWithValue("@Team", DBNull.Value);
                cmd.Parameters.AddWithValue("@Area", DBNull.Value);
                cmd.Parameters.AddWithValue("@Warehouse", DBNull.Value);
                cmd.Parameters.AddWithValue("@Hub", DropHubEdit.SelectedItem.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                FillGridView2();
                Response.Redirect(Request.Url.AbsoluteUri);
            }

        }

        protected void btnSavedGV_Click(object sender, EventArgs e)
        {

            string main = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;
            SqlConnection Sqlcon = new SqlConnection(main);

            foreach (GridViewRow gr in gvTemp.Rows)
            {
                if (gr.Cells[3].Text == "Branch")
                {
                    string sqlquery = "update FinishedGood set Branch = @Branch, Team = @Team, Area = @Area, Hub = @Hub, Warehouse = @Warehouse, ScheduleDate = @ScheduledDate, DestinationTo = @DestinationTo WHERE StartingSeries = @StartingSeries and EndingSeries = @EndingSeries";
                    SqlCommand sqlCmd = new SqlCommand(sqlquery, Sqlcon);
                    sqlCmd.Parameters.AddWithValue("@StartingSeries", gr.Cells[0].Text);
                    sqlCmd.Parameters.AddWithValue("@EndingSeries", gr.Cells[1].Text);
                    sqlCmd.Parameters.AddWithValue("@Branch", gr.Cells[5].Text);
                    sqlCmd.Parameters.AddWithValue("@Team", gr.Cells[6].Text);
                    sqlCmd.Parameters.AddWithValue("@Area", gr.Cells[7].Text);
                    sqlCmd.Parameters.AddWithValue("@Hub", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse(Alabang)");
                    sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text);
                    sqlCmd.Parameters.AddWithValue("@DestinationTo", gr.Cells[3].Text);
                    Sqlcon.Open();
                    sqlCmd.ExecuteNonQuery();
                    Sqlcon.Close();
                    //tagging();

                    // validations
                    if (gr.Cells[10].Text != "")
                    {
                        SqlConnection conn = new SqlConnection(main);
                        string qry = "Delete from [lbcbios].[TempTagging] where ID = '" + gr.Cells[10].Text + "'";
                        SqlCommand sqlComma = new SqlCommand(qry, conn);
                        conn.Open();
                        sqlComma.ExecuteNonQuery();
                        DDLlistseries.Items.Clear();
                        FillGridView();
                        FillGridView2();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);
                        conn.Close();
                        //Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
                        //lblSuccess.Text = "Please Cornfirm your Details!";
                    }
                }
                else if (gr.Cells[3].Text == "Warehouse")
                {
                    string sqlquery = "update FinishedGood set Branch = @Branch, Team = @Team, Area = @Area, Hub = @Hub, Warehouse = @Warehouse, ScheduleDate = @ScheduledDate, DestinationTo = @DestinationTo WHERE StartingSeries = @StartingSeries and EndingSeries = @EndingSeries";
                    SqlCommand sqlCmd = new SqlCommand(sqlquery, Sqlcon);
                    sqlCmd.Parameters.AddWithValue("@StartingSeries", gr.Cells[0].Text);
                    sqlCmd.Parameters.AddWithValue("@EndingSeries", gr.Cells[1].Text);
                    sqlCmd.Parameters.AddWithValue("@Branch", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Team", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Area", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Hub", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Warehouse", gr.Cells[8].Text);
                    sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text);
                    sqlCmd.Parameters.AddWithValue("@DestinationTo", gr.Cells[3].Text);
                    Sqlcon.Open();
                    sqlCmd.ExecuteNonQuery();
                    Sqlcon.Close();
                    //tagging();

                    // validations
                    if (gr.Cells[10].Text != "")
                    {
                        SqlConnection conn = new SqlConnection(main);
                        string qry = "Delete from [lbcbios].[TempTagging] where ID = '" + gr.Cells[10].Text + "'";
                        SqlCommand sqlComma = new SqlCommand(qry, conn);
                        conn.Open();
                        sqlComma.ExecuteNonQuery();
                        DDLlistseries.Items.Clear();
                        FillGridView();
                        FillGridView2();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);
                        conn.Close();
                        //Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
                        //lblSuccess.Text = "Please Cornfirm your Details!";
                    }
                }
                else if (gr.Cells[3].Text == "Hub")
                {
                    string sqlquery = "update FinishedGood set Branch = @Branch, Team = @Team, Area = @Area, Hub = @Hub, Warehouse = @Warehouse, ScheduleDate = @ScheduledDate, DestinationTo = @DestinationTo WHERE StartingSeries = @StartingSeries and EndingSeries = @EndingSeries";
                    SqlCommand sqlCmd = new SqlCommand(sqlquery, Sqlcon);
                    sqlCmd.Parameters.AddWithValue("@StartingSeries", gr.Cells[0].Text);
                    sqlCmd.Parameters.AddWithValue("@EndingSeries", gr.Cells[1].Text);
                    sqlCmd.Parameters.AddWithValue("@Branch", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Team", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Area", DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@Hub", gr.Cells[9].Text);
                    sqlCmd.Parameters.AddWithValue("@Warehouse", "Blossom Warehouse(Alabang)");
                    sqlCmd.Parameters.AddWithValue("@ScheduledDate", txtDate.Text);
                    sqlCmd.Parameters.AddWithValue("@DestinationTo", gr.Cells[3].Text);
                    Sqlcon.Open();
                    sqlCmd.ExecuteNonQuery();
                    Sqlcon.Close();
                    //tagging();

                    // validations
                    if (gr.Cells[10].Text != "")
                    {
                        SqlConnection conn = new SqlConnection(main);
                        string qry = "Delete from [lbcbios].[TempTagging] where ID = '" + gr.Cells[10].Text + "'";
                        SqlCommand sqlComma = new SqlCommand(qry, conn);
                        conn.Open();
                        sqlComma.ExecuteNonQuery();
                        DDLlistseries.Items.Clear();
                        FillGridView();
                        FillGridView2();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('New Request added Successfully!','You clicked the button!', 'success')", true);
                        conn.Close();
                        //Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Please Cornfirm your Details!','You clicked the button!', 'warning')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Cornfirm your Details!')", true);
                        //lblSuccess.Text = "Please Cornfirm your Details!";
                    }
                }



            }


        }
    }
}