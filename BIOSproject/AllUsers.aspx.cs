using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIOSproject
{
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllData();
        }

        private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList1();
            if (list.Count <= 0)
            {
                return;
            }
            gvList1.DataSource = list;
            gvList1.DataBind();

            gvList1.UseAccessibleHeader = true;
            gvList1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}