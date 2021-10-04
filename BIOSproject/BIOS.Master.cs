using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIOSproject
{
    public partial class BIOS : System.Web.UI.MasterPage
    {
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
    }
}