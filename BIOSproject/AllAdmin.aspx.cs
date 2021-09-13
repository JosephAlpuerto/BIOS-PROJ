using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIOSproject.FolConnectionDB;
using Telerik.Reporting.Processing;

namespace BIOSproject
{
    public partial class AllAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllData();
        }

        [Obsolete]
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            var list = DbAdmin.FetchList2();

            if(list.Count > 0)
            {
                ReportProcessor reportProcessor = new ReportProcessor();
                RenderingResult result = reportProcessor.RenderReport("PDF", new Report.ReportAdmin(list), null);

                Response.Clear();
                Response.ContentType = result.MimeType;
                Response.Cache.SetCacheability(HttpCacheability.Private);
                Response.Expires = -1;
                Response.Buffer = true;
                Response.BinaryWrite(result.DocumentBytes);
                Response.End();
            }
        }


        private void AllData()
        {
            var list = ConnectionDB.AdminDB.FetchList();
            if(list.Count<=0)
            {
                return;
            }
            gvList.DataSource = list;
            gvList.DataBind();

            gvList.UseAccessibleHeader = true;
            gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvList.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}