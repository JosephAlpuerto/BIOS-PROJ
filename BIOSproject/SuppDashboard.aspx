<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="SuppDashboard.aspx.cs" Inherits="BIOSproject.SuppDashboard" %>
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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="content">
            <div class="cards">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label1" runat="server" Text="No. of PO" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="LblPO" runat="server" Text="" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label3" runat="server" Text="No of Delivered" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="NoOfdlver" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label5" runat="server" Text="Fulfilment" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label6" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label7" runat="server" Text="Produced" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label8" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label9" runat="server" Text="Availability" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label10" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>

        </div>
   



    
    <div class="whole">
        
    <div class="menuu">
        <div class="menu1">
        <asp:Label ID="Label2" runat="server" Text="Material" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label11" runat="server" Text="PO Qty" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label12" runat="server" Text="Produced" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label13" runat="server" Text="Delivered" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label14" runat="server" Text="On Hand" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label15" runat="server" Text="PO Balance" CssClass="lblTtl" ForeColor="#ffffff"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label16" runat="server" Text="KILOBOX MINI " CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="POQtKBMini" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label18" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBMiniDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label20" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBMINIBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label22" runat="server" Text="KILOBOX SLIM " CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="KBSLIMPO" runat="server" Text="" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label23" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="SlimDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label25" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBSLIMBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label27" runat="server" Text="KILOBOX SMALL" CssClass="lblTtl"> </asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="KBSMALLPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label29" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBSmallDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label31" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBSMALLBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label33" runat="server" Text="KILOBOX MEDIUM " CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="KBMediumPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label35" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBMediumDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label37" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBMEDIUMBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label39" runat="server" Text="KILOBOX LARGE" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="KBLARGEPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label41" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBLargeDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label43" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBLARGEBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label45" runat="server" Text="KILOBOX XL" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="KBXLPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label47" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBXLDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label49" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="KBXLBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label51" runat="server" Text="N-PACK SMALL FOR 2D PRINTER " CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="NPSMALL42DPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label53" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="NPSMALL42DDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label55" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="NPS42DBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label57" runat="server" Text="N-PACK SMALL 4 NON 2D PRNTER " CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="NPSM4NONPO" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label59" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="NPSM4NONDelivered" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label61" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="NPS4NON2DBALANCE" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label63" runat="server" Text="N-PACK LARGE FOR 2D PRINTER" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label64" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label65" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label66" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label67" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label68" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>
    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label69" runat="server" Text="N-PACK LRGE 4 NON 2D PRNTER" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label70" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label71" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label72" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label73" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label74" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label75" runat="server" Text="N-POUCH REGULAR FOR 2D PRINTER" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label76" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label77" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label78" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label79" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label80" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label81" runat="server" Text="N-POUCH XL FOR 2D PRINTER" CssClass="lblTtl"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label82" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label83" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label84" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label85" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label86" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>











</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
