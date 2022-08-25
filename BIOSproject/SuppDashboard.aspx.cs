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
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
            string cmdText = "select count(*) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where Supplier = @Supplier", con;
            SqlConnection conDatabase = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conDatabase);
            cmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conDatabase.Open();
                int numRec = Convert.ToInt32(cmd.ExecuteScalar());
                LblPO.Text = numRec.ToString();
            }


            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[NoOFDelivered]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NoOfdlver.Text = numRec.ToString();
            }
            Availability();
            Produced();
            Fulfilment();

            KiloboxMini();
            KBSlim();
            KBSmall();
            KBMedium();
            KBLarge();
            KBXL();
            NPSMALL42D();
            NPSMALL4NON();
            }

            
        }
        public void Fulfilment()
        {
            hfNoDel.Value = LblPO.Text;
            hfNoPO.Value = NoOfdlver.Text;
            if (hfNoPO.Value != "0" || hfNoDel.Value != "0")
            {
                double PO, DEL, answer;
                double.TryParse(hfNoDel.Value, out PO);
                double.TryParse(hfNoPO.Value, out DEL);

                answer = (DEL / PO) * 100;
                decimal value = Convert.ToDecimal(answer);
                decimal round = Decimal.Round(value);
                if (round >= 101)
                {
                    lblFulfilment.Text = 100 + "%";
                }
                else
                {
                    lblFulfilment.Text = round + "%";
                }
            }
            else
            {
                lblFulfilment.Text = "0";
            }
            
        }
        public void Produced()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("[LBC.BIOS].[lbcbios].[ProducedCount]", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());

            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblProduced.Text = numRec.ToString();
            sqlCon.Close();
        }
        public void Availability()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("[LBC.BIOS].[lbcbios].[AvailabilityCount]", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblAvailability.Text = numRec.ToString();
            sqlCon.Close();
        }
        private void KiloboxMini()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KNMINIPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                POQtKBMini.Text = numRec.ToString();
                conn.Close();
            }

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBMiniDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                KBMiniDelivered.Text = numRec.ToString();
            }

            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX MINI%' and Supplier = '" + Session["Username"].ToString()+"' and DestinationTo IS NULL";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBMINIBALANCE.Text = numRecC.ToString();

            sqlCon.Close();



        }


        private void KBSlim()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KBSLIMPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBSLIMPO.Text = numRec.ToString();
                conn.Close();
            }


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBSlimDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                SlimDelivered.Text = numRec.ToString();
            }

            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX SLIM%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBSLIMBALANCE.Text = numRecC.ToString();

            sqlCon.Close();



        }

        private void KBSmall()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KBSMALLPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBSMALLPO.Text = numRec.ToString();
                conn.Close();
            }


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBSmallDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                KBSmallDelivered.Text = numRec.ToString();
            }


            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX SMALL%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBSMALLBALANCE.Text = numRecC.ToString();

            sqlCon.Close();


        }

        private void KBMedium()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KBMEDIUMPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBMediumPO.Text = numRec.ToString();
            }

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBMediumDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                KBMediumDelivered.Text = numRec.ToString();
            }




            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX MEDIUM%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";
            
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBMEDIUMBALANCE.Text = numRecC.ToString();

            sqlCon.Close();


        }
        private void KBLarge()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KBLARGEPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBLARGEPO.Text = numRec.ToString();
            }

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBLargeDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                KBLargeDelivered.Text = numRec.ToString();
            }


            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX LARGE%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBLARGEBALANCE.Text = numRecC.ToString();

            sqlCon.Close();


        }

        private void KBXL()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[KBXLPOQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                KBXLPO.Text = numRec.ToString();
            }


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[KBXLDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                KBXLDelivered.Text = numRec.ToString();
            }


            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%KILOBOX XL%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";
           
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            KBXLBALANCE.Text = numRecC.ToString();

            sqlCon.Close();


        }



        private void NPSMALL42D()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[NPSMALLQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NPSMALL42DPO.Text = numRec.ToString();
            }


            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[NPS42DLDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                NPSMALL42DDelivered.Text = numRec.ToString();
            }

            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%N-PACK LARGE FOR 2D PRINTER%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";

            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            NPS42DBALANCE.Text = numRecC.ToString();

            sqlCon.Close();


        }


        private void NPSMALL4NON()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("[LBC.BIOS].[lbcbios].[NPSMALL4NON2DQTY]", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            sqlData.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                NPSM4NONPO.Text = numRec.ToString();
            }

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sql = new SqlCommand("[LBC.BIOS].[lbcbios].[NPS4NON2DLDelivered]", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Supplier", Session["Username"].ToString());
            {
                con.Open();
                string numRec = sql.ExecuteScalar().ToString();
                NPSM4NONDelivered.Text = numRec.ToString();
            }

            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(*) FROM [LBC.BIOS].[lbcbios].[FinishedGood] where Product LIKE '%N-PACK SMAL 4 NON 2D PRNTER%' and Supplier = '" + Session["Username"].ToString() + "' and DestinationTo IS NULL";

            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            NPS4NON2DBALANCE.Text = numRecC.ToString();

            sqlCon.Close();
        }



















    }
}