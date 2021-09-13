using BIOSproject.FolDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace BIOSproject.Report
{
    /// <summary>
    /// Summary description for ReportAdmin.
    /// </summary>
    public partial class ReportAdmin : Telerik.Reporting.Report
    {
        public ReportAdmin(List<clsAdmin> list)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.objectDataSource1.DataSource = list;
        }
    }
}