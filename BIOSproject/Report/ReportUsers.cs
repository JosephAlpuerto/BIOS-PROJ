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
    /// Summary description for ReportUsers.
    /// </summary>
    public partial class ReportUsers : Telerik.Reporting.Report
    {
        public ReportUsers(List<clsUsers> list)
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