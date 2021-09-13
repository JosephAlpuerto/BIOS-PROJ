using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIOSproject
{
    public partial class Generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                string totalListNumber = "";

                for (double x = Convert.ToDouble(TextBox1.Text); x <= Convert.ToDouble(TextBox2.Text); x++)
                {
                    totalListNumber += x + "\n";


                }
                TextBox3.Text = totalListNumber;
            }
        }
    }
}