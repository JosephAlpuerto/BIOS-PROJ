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
    public partial class WebForm2 : System.Web.UI.Page
    {

        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cascadingdropdown();


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
    }
}