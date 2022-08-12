<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="Dashboard.aspx.cs" Inherits="BIOSproject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <style>
        .whole .menuu{
            margin-left: 30px;
        }
       
        .whole .menu1 {
            width: 16%;
            float: left;
            padding: 10px;
            /*border: 1px solid red;*/
            background-color: #d00149;
        }
        .whole .menu2 {
            width: 16%;
            height: 80px;
            padding: 10px;
            float: left;
            border: 1px solid black;
        }
        .whole .menu2 .lblTxt {
        padding: 30px 20px;
        font-size: 25px;
        }
    </style>

     <div class="content">
            <div class="cards">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label79" runat="server" Text="No. of PO" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="LblPO" runat="server" Text="" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label80" runat="server" Text="HitCheck" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblHitcheck" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label81" runat="server" Text="On Production" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblOnProduction" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label83" runat="server" Text="On Stock" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblOnStock" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label85" runat="server" Text="Completed" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblCompleted" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
        </div>






    <div class="whole">
        
    <div class="menuu">
        <div class="menu1">
        <asp:Label ID="Label1" runat="server" Text="Supplier" ForeColor="#ffffff"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label2" runat="server" Text="No of PO" ForeColor="#ffffff"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label3" runat="server" Text="No of Delivered" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label4" runat="server" Text="Fulfilment" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label5" runat="server" Text="Produced" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label6" runat="server" Text="Availability" ForeColor="#ffffff"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label7" runat="server" Text="Forms International Enterprises  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="FIENoOfPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="FIEDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="FIEFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="FIEProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="FIEAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label13" runat="server" Text="Well-Pack Container Corporation"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="WellNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="WellDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="WellFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="WellProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="WellAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label19" runat="server" Text="ADVANCE COMPUTER FORMS, INC.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="ACFNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="ACFDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="ACFFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="ACFProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="ACFAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


    
     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label8" runat="server" Text="DTM Print & Labels Specialist Inc."></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="DTMNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="DTMDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="DTMFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="DTMProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="DTMAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


    
     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label50" runat="server" Text="PRINTSUNLIMITED COMPANY INC."></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="PCINoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="PCIDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="PCIFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="PCIProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="PCIAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label25" runat="server" Text="JRD Manufacturing Corp.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="JRDNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="JRDDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="JRDFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="JRDProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="JRDAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label31" runat="server" Text="TFT Express Printing Co. Inc.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="TFTNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="TFTDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TFTFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TFTProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TFTAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label37" runat="server" Text="KIMWIN CORPORATION  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="kimwinNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="kimwinDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="kimwinFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="kimwinProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="kimwinAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label43" runat="server" Text="United Polyresins Inc.   "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="UPINoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="UPIDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
     <div class="menu2">
        <asp:Label ID="UPIFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="UPIProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="UPIAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label49" runat="server" Text="Holy Family Printing Corporation  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="HFPCNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="HFPCDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="HFPCFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="HFPCProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="HFPCAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label55" runat="server" Text="CHRISMOND PRINTING SERVICES CORP.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="CPSCNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="CPSCDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="CPSCFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="CPSCProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="CPSCAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>
    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label61" runat="server" Text="TWINPACK CONTAINER CORPORATION   "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="TCCNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="TCCDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TCCFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TCCProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="TCCAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label67" runat="server" Text="S.P. Mamplasan Packaging Corp.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="SPMPCNoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="SPMPCDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="SPMPCFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="SPMPCProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="SPMPCAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label73" runat="server" Text="AGP Trading Inc.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="AGPTINoPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="AGPTIDeliver" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="AGPTIFulFilment" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="AGPTIProduced" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="AGPTIAvailability" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
