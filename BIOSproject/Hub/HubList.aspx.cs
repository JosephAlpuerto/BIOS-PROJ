using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIOSproject.Supplier
{
    public partial class SupplierList : System.Web.UI.Page
    {

        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillGridView();
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
            //    }
            }

        }
        void FillGridView()
        {
           
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SupplierRequestShow", sqlCon);
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

        protected void btnRequest_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32((sender as Button).CommandArgument);
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
            txtRequestID.Text = dtbl.Rows[0]["Id"].ToString();
            txtSuppRequestID.Text = dtbl.Rows[0]["RequestId"].ToString();
            txtTicket.Text = dtbl.Rows[0]["TicketNo"].ToString();
            txtPO.Text = dtbl.Rows[0]["PoNO"].ToString();
            txtDate.Text = dtbl.Rows[0]["ScheduleRequest"].ToString();
            txtArea.Text = dtbl.Rows[0]["Area"].ToString();
            txtBranch.Text = dtbl.Rows[0]["Branch"].ToString();
            ModalRequest.Show();
            FillGridView();
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //var ResquestID = txtSuppRequestID.Text.Trim();
            //var Ticket = txtTicket.Text.Trim();
            //var PO = txtPO.Text.Trim();


            //SqlConnection sqlCon = new SqlConnection(ConnectionString);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("IdCreateSuppRequest", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            //sqlCmd.Parameters.AddWithValue("@RequestID", txtSuppRequestID.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@TicketNO ", txtTicket.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@PoNO", txtPO.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@ScheduleRequest", txtDate.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@Area", txtArea.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@Branch", txtBranch.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@CreatedBy", Session["Username"].ToString());
            //sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTimeOffset.UtcNow);
            //sqlCmd.Parameters.AddWithValue("@UpdatedBy", Convert.DBNull);
            //sqlCmd.Parameters.AddWithValue("@UpdatedDate", Convert.DBNull);
            //sqlCmd.Parameters.AddWithValue("@DeletedBy", Convert.DBNull);
            //sqlCmd.Parameters.AddWithValue("@DeletedDate", Convert.DBNull);
            //sqlCmd.Parameters.AddWithValue("@IsActive", "1");
            //sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();
            //Clear();
            //FillGridView();
            //string Id = hfId.Value;

            //// validations
            //if (Id == "")
            //{
            //    lblSuccess.Text = "New Request added Successfully!";
            //}
            //else
            //{
            //    lblSuccess.Text = "Please Cornfirm your Details!";
            //}
        }
        private void Clear()
        {
            hfId.Value = "";
            lblSuccess.Text = "";
        }
    }

    }
