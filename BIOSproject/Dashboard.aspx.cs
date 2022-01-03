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
    public partial class WebForm1 : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source = 172.25.8.134; Initial Catalog = LBC.BIOS; Persist Security Info=True;User ID = lbcbios;Password=lbcbios";
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString);
        string mainconn = ConfigurationManager.ConnectionStrings["LBC_Ref"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {






            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PONumber", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            LblPO.Text = numRec.ToString();


            sqlCon.Close();

            Count();

            Hitcheck();
            FIE();
            WPCC();
            ACF();
            JRD();
            TFT();
            Kimwin();
            UnitedPI();
            HFPC();
            CPSP();
            TCC();
            SPMPC();
            AGPTI();
        }

        private void Hitcheck()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Hitcheck", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblHitcheck.Text = numRec.ToString();
            sqlCon.Close();



        }
        private void Count()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(Supplier) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where Supplier = 'Well-Pack Container Corporation';";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            WellNoPO.Text = numRec.ToString();

            sqlCon.Close();



          
        }

        private void FIE()
        {



            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("FIENoOfPO", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                FIENoOfPO.Text = numRec.ToString();
            }
        }

        private void WPCC()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("WellPackNoOfPO", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                WellNoPO.Text = numRec.ToString();
            }

        }

        private void ACF()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("AdvanceCFNoOfPO", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                ACFNoPO.Text = numRec.ToString();
            }
        }
        
        private void JRD()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'JRD Manufacturing Corp.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            JRDNoPO.Text = numRec.ToString();

            sqlCon.Close();
        }
        

        private void TFT()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("TFTNoOfPO", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                TFTNoPO.Text = numRec.ToString();
            }
        }

        private void Kimwin()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlData = new SqlCommand("KimwinNoOfPO", conn);
            sqlData.CommandType = CommandType.StoredProcedure;
            {
                conn.Open();
                string numRec = sqlData.ExecuteScalar().ToString();
                kimwinNoPO.Text = numRec.ToString();
            }


        }

        private void UnitedPI()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'United Polyresins Inc.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            WellNoPO.Text = numRec.ToString();

            sqlCon.Close();
        }

        private void HFPC()
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'Holy Family Printing Corporation'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            HFPCNoPO.Text = numRec.ToString();

            sqlCon.Close();

        }

        private void CPSP()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'CHRISMOND PRINTING SERVICES CORP.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            HFPCNoPO.Text = numRec.ToString();

            sqlCon.Close();
        }

        private void TCC()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'TWINPACK CONTAINER CORPORATION'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            TCCNoPO.Text = numRec.ToString();

            sqlCon.Close();

        }

        private void SPMPC()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'S.P. Mamplasan Packaging Corp.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            SPMPCNoPO.Text = numRec.ToString();

            sqlCon.Close();
        }
        private void AGPTI()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'AGP Trading Inc.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            AGPTINoPO.Text = numRec.ToString();

            sqlCon.Close();
        }




    }
}