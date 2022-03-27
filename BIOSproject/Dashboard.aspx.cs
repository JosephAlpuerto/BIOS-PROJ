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

            Completed();
            OnStock();
            OnProduction();
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
            DTM();
            PCI();
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
        public void OnProduction()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("OnProductionCount", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblOnProduction.Text = numRec.ToString();
            sqlCon.Close();
        }
        public void OnStock()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("OnStockCount", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblOnStock.Text = numRec.ToString();
            sqlCon.Close();
        }
        public void Completed()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("OnCompletedCount", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;


            int numRec = Convert.ToInt32(sqlCmd.ExecuteScalar());
            lblCompleted.Text = numRec.ToString();
            sqlCon.Close();
        }

        private void Count()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'Well-Pack Container Corporation';";
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

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'Forms International Enterprises' and DestinationTo = 'Branches' or SupplierName = 'Forms International Enterprises' and DestinationTo = 'Hub'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            FIEDelivered.Text = numRecC.ToString();
            FIEProduced.Text = numRecC.ToString();
            sqlCon.Close();

            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'Forms International Enterprises' and DestinationTo = 'Warehouse' or SupplierName = 'Forms International Enterprises' and DestinationTo = NULL";
            SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
            sqlCon2.Open();
            int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
            FIEAvailability.Text = numRecC2.ToString();
            sqlCon2.Close();

            if (FIENoOfPO.Text != "0" || FIEDelivered.Text != "0")
            {
                double PO, DEL, answer;
                double.TryParse(FIENoOfPO.Text, out PO);
                double.TryParse(FIEDelivered.Text, out DEL);
                answer = (DEL / PO) * 100;
                decimal value = Convert.ToDecimal(answer);
                decimal round = Decimal.Round(value);
                FIEFulFilment.Text = round + "%";
            }
            else
            {
                FIEFulFilment.Text = "0";
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
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'Well-Pack Container Corporation' and DestinationTo = 'Branches' or SupplierName = 'Well-Pack Container Corporation' and DestinationTo = 'Hub'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            WellDelivered.Text = numRecC.ToString();
            WellProduced.Text = numRecC.ToString();
            sqlCon.Close();

            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'Well-Pack Container Corporation' and DestinationTo = 'Warehouse' or SupplierName = 'Well-Pack Container Corporation' and DestinationTo = NULL";
            SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
            sqlCon2.Open();
            int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
            WellAvailability.Text = numRecC2.ToString();
            sqlCon2.Close();

            if (WellNoPO.Text != "0" || WellDelivered.Text != "0")
            {
                double PO, DEL, answer;
                double.TryParse(WellNoPO.Text, out PO);
                double.TryParse(WellDelivered.Text, out DEL);
                answer = (DEL / PO) * 100;
                decimal value = Convert.ToDecimal(answer);
                decimal round = Decimal.Round(value);
                WellFulFilment.Text = round + "%";
            }
            else
            {
                WellFulFilment.Text = "0";
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
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'ADVANCE COMPUTER FORMS, INC.' and DestinationTo = 'Branches' or SupplierName = 'ADVANCE COMPUTER FORMS, INC.' and DestinationTo = 'Hub'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRecC = Convert.ToInt32(sqlcom.ExecuteScalar());
            ACFDeliver.Text = numRecC.ToString();
            ACFProduced.Text = numRecC.ToString();
            sqlCon.Close();

            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'ADVANCE COMPUTER FORMS, INC.' and DestinationTo = 'Warehouse' or SupplierName = 'ADVANCE COMPUTER FORMS, INC.' and DestinationTo = NULL";
            SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
            sqlCon2.Open();
            int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
            ACFAvailability.Text = numRecC2.ToString();
            sqlCon2.Close();

            if (ACFNoPO.Text != "0" || ACFDeliver.Text != "0")
            {
                double PO, DEL, answer;
                double.TryParse(ACFNoPO.Text, out PO);
                double.TryParse(ACFDeliver.Text, out DEL);
                answer = (DEL / PO) * 100;
                decimal value = Convert.ToDecimal(answer);
                decimal round = Decimal.Round(value);
                ACFFulFilment.Text = round + "%";
            }
            else
            {
                ACFFulFilment.Text = "0";
            }
        }
        

        private void DTM()

        {
            {
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                string sqlquery = "SELECT COUNT(SupplierName) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'DTM Print &amp; Labels Specialist Inc.'";
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
                sqlCon.Open();
                int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
                DTMNoPO.Text = numRec.ToString();
                sqlCon.Close();
            }
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'DTM Print &amp; Labels Specialist Inc.' and DestinationTo = 'Branches' or SupplierName = 'DTM Print &amp; Labels Specialist Inc.' and DestinationTo = 'Hub'";
            SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
            sqlConn.Open();
            int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
            DTMDeliver.Text = numRecC.ToString();
            DTMProduced.Text = numRecC.ToString();
            sqlConn.Close();

            SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
            string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'DTM Print &amp; Labels Specialist Inc.' and DestinationTo = 'Warehouse' or SupplierName = 'DTM Print &amp; Labels Specialist Inc.' and DestinationTo = NULL";
            SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
            sqlCon2.Open();
            int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
            DTMAvailability.Text = numRecC2.ToString();
            sqlCon2.Close();

            if (DTMNoPO.Text != "0" || DTMDeliver.Text != "0")
            {
                double PO, DEL, answer;
                double.TryParse(DTMNoPO.Text, out PO);
                double.TryParse(DTMDeliver.Text, out DEL);
                answer = (DEL / PO) * 100;
                decimal value = Convert.ToDecimal(answer);
                decimal round = Decimal.Round(value);
                DTMFulFilment.Text = round + "%";
            }
            else
            {
                DTMFulFilment.Text = "0";
            }
        }

        private void PCI()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'PRINTSUNLIMITED COMPANY INC.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            PCINoPO.Text = numRec.ToString();
            sqlCon.Close();
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'PRINTSUNLIMITED COMPANY INC.' and DestinationTo = 'Branches' or SupplierName = 'PRINTSUNLIMITED COMPANY INC.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                PCIDeliver.Text = numRecC.ToString();
                PCIProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'PRINTSUNLIMITED COMPANY INC.' and DestinationTo = 'Warehouse' or SupplierName = 'PRINTSUNLIMITED COMPANY INC.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                PCIAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (PCINoPO.Text != "0" || PCIDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(PCINoPO.Text, out PO);
                    double.TryParse(PCIDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    PCIFulFilment.Text = round + "%";
                }
                else
                {
                    PCIFulFilment.Text = "0";
                }
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
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'JRD Manufacturing Corp.' and DestinationTo = 'Branches' or SupplierName = 'JRD Manufacturing Corp.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                JRDDeliver.Text = numRecC.ToString();
                JRDProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'JRD Manufacturing Corp.' and DestinationTo = 'Warehouse' or SupplierName = 'JRD Manufacturing Corp.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                JRDAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (JRDNoPO.Text != "0" || JRDDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(JRDNoPO.Text, out PO);
                    double.TryParse(JRDDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    JRDFulFilment.Text = round + "%";
                }
                else
                {
                    JRDFulFilment.Text = "0";
                }
            }
        }

            private void TFT()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'TFT Express Printing Co. Inc.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            TFTNoPO.Text = numRec.ToString();
            sqlCon.Close();
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'TFT Express Printing Co. Inc.' and DestinationTo = 'Branches' or SupplierName = 'TFT Express Printing Co. Inc.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                TFTDeliver.Text = numRecC.ToString();
                TFTProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'TFT Express Printing Co. Inc.' and DestinationTo = 'Warehouse' or SupplierName = 'TFT Express Printing Co. Inc.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                TFTAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (TFTNoPO.Text != "0" || TFTDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(TFTNoPO.Text, out PO);
                    double.TryParse(TFTDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    TFTFulFilment.Text = round + "%";
                }
                else
                {
                    TFTFulFilment.Text = "0";
                }
            }
        }

        private void Kimwin()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'KIMWIN CORPORATION'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            kimwinNoPO.Text = numRec.ToString();
            sqlCon.Close();
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'KIMWIN CORPORATION' and DestinationTo = 'Branches' or SupplierName = 'KIMWIN CORPORATION' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                kimwinDeliver.Text = numRecC.ToString();
                kimwinProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'KIMWIN CORPORATION' and DestinationTo = 'Warehouse' or SupplierName = 'KIMWIN CORPORATION' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                kimwinAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (kimwinNoPO.Text != "0" || kimwinDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(kimwinNoPO.Text, out PO);
                    double.TryParse(kimwinDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    kimwinFulFilment.Text = round + "%";
                }
                else
                {
                    kimwinFulFilment.Text = "0";
                }
            }
        }

        private void UnitedPI()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'United Polyresins Inc.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            UPINoPO.Text = numRec.ToString();
            sqlCon.Close();
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'United Polyresins Inc.' and DestinationTo = 'Branches' or SupplierName = 'United Polyresins Inc.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                UPIDeliver.Text = numRecC.ToString();
                UPIProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'United Polyresins Inc.' and DestinationTo = 'Warehouse' or SupplierName = 'United Polyresins Inc.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                UPIAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (UPINoPO.Text != "0" || UPIDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(UPINoPO.Text, out PO);
                    double.TryParse(UPIDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    UPIFulFilment.Text = round + "%";
                }
                else
                {
                    UPIFulFilment.Text = "0";
                }
            }
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
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'Holy Family Printing Corporation' and DestinationTo = 'Branches' or SupplierName = 'Holy Family Printing Corporation' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                HFPCDeliver.Text = numRecC.ToString();
                HFPCProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'Holy Family Printing Corporation' and DestinationTo = 'Warehouse' or SupplierName = 'Holy Family Printing Corporation' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                HFPCAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (HFPCNoPO.Text != "0" || HFPCDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(HFPCNoPO.Text, out PO);
                    double.TryParse(HFPCDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    HFPCFulFilment.Text = round + "%";
                }
                else
                {
                    HFPCFulFilment.Text = "0";
                }
            }

        }

        private void CPSP()
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);

            string sqlquery = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'CHRISMOND PRINTING SERVICES CORP.'";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlCon);
            sqlCon.Open();
            int numRec = Convert.ToInt32(sqlcom.ExecuteScalar());
            CPSCNoPO.Text = numRec.ToString();
            sqlCon.Close();
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'CHRISMOND PRINTING SERVICES CORP.' and DestinationTo = 'Branches' or SupplierName = 'CHRISMOND PRINTING SERVICES CORP.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                CPSCDeliver.Text = numRecC.ToString();
                CPSCProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'CHRISMOND PRINTING SERVICES CORP.' and DestinationTo = 'Warehouse' or SupplierName = 'CHRISMOND PRINTING SERVICES CORP.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                CPSCAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (CPSCNoPO.Text != "0" || CPSCDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(CPSCNoPO.Text, out PO);
                    double.TryParse(CPSCDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    CPSCFulFilment.Text = round + "%";
                }
                else
                {
                    CPSCFulFilment.Text = "0";
                }
            }
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
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'TWINPACK CONTAINER CORPORATION' and DestinationTo = 'Branches' or SupplierName = 'TWINPACK CONTAINER CORPORATION' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                TCCDeliver.Text = numRecC.ToString();
                TCCProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'TWINPACK CONTAINER CORPORATION' and DestinationTo = 'Warehouse' or SupplierName = 'TWINPACK CONTAINER CORPORATION' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                TCCAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (TCCNoPO.Text != "0" || TCCDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(TCCNoPO.Text, out PO);
                    double.TryParse(TCCDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    TCCFulFilment.Text = round + "%";
                }
                else
                {
                    TCCFulFilment.Text = "0";
                }
            }

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
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'S.P. Mamplasan Packaging Corp.' and DestinationTo = 'Branches' or SupplierName = 'S.P. Mamplasan Packaging Corp.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                SPMPCDeliver.Text = numRecC.ToString();
                SPMPCProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'S.P. Mamplasan Packaging Corp.' and DestinationTo = 'Warehouse' or SupplierName = 'S.P. Mamplasan Packaging Corp.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                SPMPCAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (SPMPCNoPO.Text != "0" || SPMPCDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(SPMPCNoPO.Text, out PO);
                    double.TryParse(SPMPCDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    SPMPCFulFilment.Text = round + "%";
                }
                else
                {
                    SPMPCFulFilment.Text = "0";
                }
            }
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
            {
                SqlConnection sqlConn = new SqlConnection(ConnectionString);
                string sqlqueryy = "SELECT COUNT(SupplierName) FROM SSPNewRequest where SupplierName = 'AGP Trading Inc.' and DestinationTo = 'Branches' or SupplierName = 'AGP Trading Inc.' and DestinationTo = 'Hub'";
                SqlCommand sqlcomm = new SqlCommand(sqlqueryy, sqlConn);
                sqlConn.Open();
                int numRecC = Convert.ToInt32(sqlcomm.ExecuteScalar());
                AGPTIDeliver.Text = numRecC.ToString();
                AGPTIProduced.Text = numRecC.ToString();
                sqlConn.Close();

                SqlConnection sqlCon2 = new SqlConnection(ConnectionString);
                string sqlquery2 = "SELECT COUNT(DestinationTo) from [LBC.BIOS].[lbcbios].[SSPNewRequest] where SupplierName = 'AGP Trading Inc.' and DestinationTo = 'Warehouse' or SupplierName = 'AGP Trading Inc.' and DestinationTo = NULL";
                SqlCommand sqlcom2 = new SqlCommand(sqlquery2, sqlCon2);
                sqlCon2.Open();
                int numRecC2 = Convert.ToInt32(sqlcom2.ExecuteScalar());
                AGPTIAvailability.Text = numRecC2.ToString();
                sqlCon2.Close();

                if (AGPTINoPO.Text != "0" || AGPTIDeliver.Text != "0")
                {
                    double PO, DEL, answer;
                    double.TryParse(AGPTINoPO.Text, out PO);
                    double.TryParse(AGPTIDeliver.Text, out DEL);
                    answer = (DEL / PO) * 100;
                    decimal value = Convert.ToDecimal(answer);
                    decimal round = Decimal.Round(value);
                    AGPTIFulFilment.Text = round + "%";
                }
                else
                {
                    AGPTIFulFilment.Text = "0";
                }
            }
        }




    }
}