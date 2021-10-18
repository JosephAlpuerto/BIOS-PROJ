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

namespace BIOSproject
{
    public partial class RequestForm : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    string maincon = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
            //    string sqlquery = "select * from Areas";
            //    SqlCommand sqlcomm = new SqlCommand(sqlquery, conn);
            //    conn.Open();
            //    SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            //    DataTable dt = new DataTable();
            //    sdr.Fill(dt);
            //    DropArea.DataSource = dt;
            //    DropArea.DataTextField = "AreaDescr";
            //    DropArea.DataValueField = "AreaDescr";
            //    DropArea.DataBind();
            //    conn.Close();



            //    string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
            //    string sqlqueryy = "select * from ref_Branches";
            //    SqlCommand sqlcom = new SqlCommand(sqlqueryy, conn);
            //    con.Open();
            //    SqlDataAdapter sd = new SqlDataAdapter(sqlcom);
            //    DataSet ds = new DataSet();
            //    sd.Fill(ds);
            //    DropTeam.DataSource = ds;
            //    DropTeam.DataTextField = "TeamDescr";
            //    DropTeam.DataValueField = "TeamDescr";
            //    DropTeam.DataBind();
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {

            //        DropBranch.Items.Add(ds.Tables[0].Rows[i][1] + "--" + ds.Tables[0].Rows[i][2]);
            ////    }
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var Ticket = TicketNo.Text.Trim();
            var PO = PONo.Text.Trim();
            var Product = txtProduct.Text.Trim();
            var Quantity = txtQuantity.Text.Trim();
           

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("SSPCreateRequest", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId1.Value == "" ? 0 : Convert.ToInt32(hfId1.Value)));
            sqlCmd.Parameters.AddWithValue("@TicketNo", TicketNo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PONumber ", PONo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", txtSupplier.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@Product", txtProduct.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
           
            sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            sqlCmd.Parameters.AddWithValue("@IsActive","0");
            sqlCmd.Parameters.AddWithValue("@DownloadFile", Convert.DBNull);
            sqlCmd.Parameters.AddWithValue("@CancelRequest", "0");
            sqlCmd.Parameters.AddWithValue("@IsRejected", "0");
            //sqlCmd.Parameters.AddWithValue("@UpdatedBy", "Admin");
            //sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", DateTimeOffset.UtcNow);
            string Id = hfId1.Value;
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
                Clear();
                sqlCon.Close();
                lblError1.Text = "New Request added Successfully!";
                //FillGridView();
            }
            else
            {
                lblError1.Text = "Error!";
            }
        }

        public void Clear()
        {
            TicketNo.Text = PONo.Text = txtProduct.Text = txtQuantity.Text = "";
            hfId1.Value = "";
            lblError1.Text = "";
        }

        protected void TicketNo_TextChanged(object sender, EventArgs e)
        {
            

            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where TicketNo = '" + TicketNo.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                lblError1.Text = "Ticket Number Already Exists!!";
                PONo.Enabled = false;
                txtSupplier.Enabled = false;
                txtQuantity.Enabled = false;
                txtProduct.Enabled = false;

            }
            else
            {
                lblError1.Text = "";
                PONo.Enabled = true;
                txtSupplier.Enabled = true;
                txtQuantity.Enabled = true;
                txtProduct.Enabled = true;
            }

            con.Close();
        }

        protected void PONo_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from SSPRequest where PONumber = '" + PONo.Text + "' ", con);
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {

                lblError1.Text = "PO Number Already Exists!!";
                TicketNo.Enabled = false;
                txtSupplier.Enabled = false;
                txtQuantity.Enabled = false;
                txtProduct.Enabled = false;
            }
            else
            {
                lblError1.Text = "";
                TicketNo.Enabled = true;
                txtSupplier.Enabled = true;
                txtQuantity.Enabled = true;
                txtProduct.Enabled = true;
            }

            con.Close();
        }
    }
}