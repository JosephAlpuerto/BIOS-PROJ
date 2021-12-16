<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BIOSproject.WebForm1" %>
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
            border: 1px solid red;
            background-color: darkorange;
        }
        .whole .menu2 {
            width: 16%;
            height: 80px;
            padding: 10px;
            float: left;
            border: 1px solid red;
        }
        .whole .menu2 .lblTxt{
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
                        <asp:Label ID="Label82" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label83" runat="server" Text="On Stock" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label84" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label85" runat="server" Text="Completed" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label86" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
        </div>






    <div class="whole">
        
    <div class="menuu">
        <div class="menu1">
        <asp:Label ID="Label1" runat="server" Text="Supplier"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label2" runat="server" Text="No of PO"></asp:Label>
        </div>
    
    <div class="menu1">
        <asp:Label ID="Label3" runat="server" Text="No of Delivered"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label4" runat="server" Text="Fulfilment"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label5" runat="server" Text="Produced"></asp:Label>
        </div>
    <div class="menu1">
        <asp:Label ID="Label6" runat="server" Text="Availability"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label7" runat="server" Text="Forms International Enterprises  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label8" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label9" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label10" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label11" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label12" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
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
        <asp:Label ID="Label15" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label16" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label17" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label18" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

     <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label19" runat="server" Text="ADVANCE COMPUTER FORMS, INC.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label20" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label21" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label22" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label23" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label24" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>


    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label25" runat="server" Text="JRD Manufacturing Corp.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label26" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label27" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label28" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label29" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label30" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label31" runat="server" Text="TFT Express Printing Co. Inc.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label32" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label33" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label34" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label35" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label36" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label37" runat="server" Text="KIMWIN CORPORATION  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label38" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label39" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label40" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label41" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label42" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label43" runat="server" Text="United Polyresins Inc.   "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label44" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label45" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label46" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label47" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label48" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label49" runat="server" Text="Holy Family Printing Corporation  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label50" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label51" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label52" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label53" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label54" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label55" runat="server" Text="CHRISMOND PRINTING SERVICES CORP.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label56" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label57" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label58" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label59" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    <div class="menu2">
        <asp:Label ID="Label60" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>

    </div>

    </div>
    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label61" runat="server" Text="TWINPACK CONTAINER CORPORATION   "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label62" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label63" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
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

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label67" runat="server" Text="S.P. Mamplasan Packaging Corp.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label68" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label69" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
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

    </div>

    </div>

    <div class="whole">
        
    <div class="menuu">
        <div class="menu2">
        <asp:Label ID="Label73" runat="server" Text="AGP Trading Inc.  "></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label74" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
        </div>
    
    <div class="menu2">
        <asp:Label ID="Label75" runat="server" Text="0" CssClass="lblTxt"></asp:Label>
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

    </div>

    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
