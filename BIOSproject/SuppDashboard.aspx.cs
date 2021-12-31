using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BIOSproject
{
    public partial class SuppDashboard : System.Web.UI.Page
    {

        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            string cmdText = "select count( DISTINCT PONumber) from [LBC.BIOS].[lbcbios].[SSPNewRequest]", con;
            SqlConnection conDatabase = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conDatabase);
            {
                conDatabase.Open();
                int numRec = Convert.ToInt32(cmd.ExecuteScalar());
                LblPO.Text = numRec.ToString();
            }


            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("NoOFDelivered", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NoOfdlver.Text = numRec.ToString();
            }

            KiloboxMini();
            KBSlim();
            KBSmall();
            KBMedium();
            KBLarge();
            KBXL();
            NPSMALL42D();
            NPSMALL4NON();
        }

        private void KiloboxMini()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KNMINIPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                POQtKBMini.Text = numRec.ToString();
            }

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sq = new SqlCommand("KBMiniDelivered", con);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sq.ExecuteScalar().ToString();
                KBMiniDelivered.Text = numRec.ToString();
            }





        }


        private void KBSlim()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KBSLIMPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBSLIMPO.Text = numRec.ToString();
            }


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sq = new SqlCommand("KBSlimDelivered", con);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sq.ExecuteScalar().ToString();
                SlimDelivered.Text = numRec.ToString();
            }
        }

        private void KBSmall()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KBSMALLPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBSMALLPO.Text = numRec.ToString();
            }
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sq = new SqlCommand("KBSmallDelivered", con);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sq.ExecuteScalar().ToString();
                KBSmallDelivered.Text = numRec.ToString();
            }
        }

        private void KBMedium()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KBMEDIUMPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBMediumPO.Text = numRec.ToString();
            }


        }
        private void KBLarge()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KBLARGEPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBLARGEPO.Text = numRec.ToString();
            }
        }

        private void KBXL()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KBXLPOQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBXLPO.Text = numRec.ToString();
            }
        }



        private void NPSMALL42D()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("NPSMALLQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NPSMALL42DPO.Text = numRec.ToString();
            }
        }


        private void NPSMALL4NON()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("NPSMALL4NON2DQTY", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NPSM4NONPO.Text = numRec.ToString();
            }
            //string cmdText = "SELECT COUNT(ProductQuantity) FROM SSPNewRequest where ProductQuantity LIKE '%N-PACK SMALL FOR 2D PRINTER%'", con;
            //SqlConnection conDatabase = new SqlConnection(ConnectionString);
            //SqlCommand cmd = new SqlCommand(cmdText, conDatabase);
            //{
            //    conDatabase.Open();
            //    int numRec = Convert.ToInt32(cmd.ExecuteScalar());
            //    NPSM4NONPO.Text = numRec.ToString();
            //}
        }



















    }
}