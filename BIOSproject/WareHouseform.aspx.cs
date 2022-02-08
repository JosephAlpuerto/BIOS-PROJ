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

namespace BIOSproject
{
    public partial class WareHouseform : System.Web.UI.Page
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
                dropdown();



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
                con.Close();
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

        protected void dropdown()
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
    }
}