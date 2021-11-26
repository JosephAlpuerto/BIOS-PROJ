<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="NewRequest.aspx.cs" Inherits="BIOSproject.NewRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
            <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
            <script src="js/jquery.js"></script>
            <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />


    <script>
       $(document).ready(function () {
           $("#TicketNo").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                $("#error").html("Numbers Only").show().fadeOut("slow");
                   return false;
                       }
                     });
                  });
    </script>
    <style>
        #error{
            color: red;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#PONumber").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#errorPO").html("Numbers Only").show().fadeOut("slow");
                    return false;
                }
            });
        });
    </script>
    <style>
        #errorPO{
            color: red;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#TxtQuantity").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#errorQt").html("Numbers Only").show().fadeOut("slow");
                    return false;
                }
            });
        });
    </script>
    <style>
        #errorQt{
            color: red;
        }
    </style>

    <link href="css/NewRequest.css" rel="stylesheet" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Username] FROM [Users] WHERE RoleType = 'Supplier' and IsActive = '1'"></asp:SqlDataSource>

<div class="body">
    <div class="container">
        <formview action="#">
            <div class="form-details">
                <div class="input-box2">
                    <span class="details">Ticket No.:</span><span id="error"></span>
                    <asp:TextBox ID="TicketNo" runat="server" CssClass="input1" AccessKey="1" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="input-box2">
                    <span class="details">PONumber:</span><span id="errorPO"></span>
                    <asp:TextBox ID="PONumber" runat="server" CssClass="input1" AutoPostBack="true" OnTextChanged="PONumber_TextChanged"  AccessKey="2" ClientIDMode="Static"></asp:TextBox><asp:Label ID="lblError1" runat="server" ForeColor="Red"></asp:Label>
                </div>

                <div class="input-box2">
                    <span class="details">Requested Date:</span>
                    <asp:TextBox ID="ReqDate" runat="server" CssClass="input1" TextMode="Date" ReadOnly="True" Enabled="false"></asp:TextBox>
                </div>

                <div class="input-box4">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [VendorEmail], [VendorName] as Vendor FROM [Reference] where VendorName != 'NULL'"></asp:SqlDataSource>
                    <span class="details">Supplier:</span>
                    <asp:DropDownList ID="dropSupplier" runat="server" CssClass="input1" DataSourceID="SqlDataSource2" DataTextField="Vendor" DataValueField="VendorEmail" Width="300px" >
                </asp:DropDownList>
                </div>

                <div class="input-box">
                    <span class="details">Product:</span>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [ItemDescr]+'-'+[ItemMaterialCode2] as Product FROM [Reference] where ItemMaterialCode2 != 'NULL'"></asp:SqlDataSource>
                    <asp:DropDownList ID="DropProduct" runat="server" CssClass="drop1" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product" Width="140px">
                </asp:DropDownList>  
                </div>
                
                <div class="input-box">
                    <span class="details">Quantity:</span>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="drop2" Width="120px" ClientIDMode="Static" AccessKey="3"></asp:TextBox><asp:Label ID="lblerror" runat="server" ForeColor="Red" CssClass="label"></asp:Label><span id="errorQt"></span>
                </div>
                <div class="input-box">
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-primary btn-user btn-block" OnClick="Button2_Click" Width="150px" Height="30px"/>
                </div>

                <div class="input-box7">
                     <span class="details">List of Product's:</span>
                </div>
                <div class="input-box7">
                     <asp:Label ID="Label9" runat="server" Text="Total Quantity" CssClass="label"></asp:Label>
                </div>
                 <div class="input-box6">
                <asp:TextBox ID="TxtAllProduct" runat="server" TextMode="MultiLine" ReadOnly="true" CssClass="input1" value="=Convert.ToString(info[0])" Width="400px" Height="100px"></asp:TextBox>
                </div>
                <div class="input-box6">
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="input1" ReadOnly="True" ></asp:TextBox>
                </div>
                

                 <div class="input-box6">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click" Width="650px"/>
                </div>
               
            </div>
        </formview>
    </div>
    </div>












    <div class="wrapper">

        <div class="forms">



            <asp:Label ID="Label8" runat="server"></asp:Label>
           
            <div class="field1">
                <asp:Label ID="lblTicketNo" runat="server" Visible="false" Text="Ticket No." CssClass="label"></asp:Label>
                
                <asp:Label ID="Label3" runat="server" Visible="false" Text="PO Number" CssClass="label"></asp:Label>
               
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <div class="field2">
                <asp:Label ID="Label2" runat="server" Visible="false" Text="Requested Date" CssClass="label"></asp:Label>
                

                
                <asp:Label ID="Label4" runat="server" Visible="false" Text="Supplier" CssClass="label"></asp:Label>
                
            </div>
           
            <div class="field">
                <asp:Label ID="Label5" runat="server" Visible="false" Text="Product" CssClass="label1"></asp:Label>
                <asp:Label ID="Label6" runat="server" Visible="false" Text="Quantity" CssClass="label2"></asp:Label>
                
                <asp:HiddenField ID="HFValue" runat="server" />
            </div>

           
            <div class="field">
                
                
                <br />
                
                <br />
                <asp:Label ID="Label1" runat="server" Visible="false" Text="List of Product's" CssClass="label"></asp:Label>
                
            </div>
            
            <div class="field">
                <asp:Label ID="Label7" runat="server" Visible="false" Text="Total Quantity" CssClass="label"></asp:Label>
               
            </div>


          

            <br />
           

        </div>

    </div>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
