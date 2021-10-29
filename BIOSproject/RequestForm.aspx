<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="RequestForm.aspx.cs" Inherits="BIOSproject.RequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Username] FROM [Users] WHERE RoleType = 'Supplier' and IsActive = '1'"></asp:SqlDataSource>
    
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <script src="js/jquery.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
        <script>
            $(document).ready(function () {
                $("#TicketNo").keypress(function (e) {
                    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                        $("#errmsg").html("Numbers Only").show().fadeOut("slow");
                        return false;
                    }
                });
            });
        </script>
                <style>
                    #errmsg {
                        color: red;
                    }
                </style>

     <script>
         $(document).ready(function () {
             $("#PONo").keypress(function (e) {
                 if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                     $("#errmsg2").html("Numbers Only").show().fadeOut("slow");
                     return false;
                 }
             });
         });
     </script>
                <style>
                    #errmsg2 {
                        color: red;
                    }
                </style>

     <script>
         $(document).ready(function () {
             $("#txtQuantity").keypress(function (e) {
                 if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                     $("#errmsg3").html("Numbers Only").show().fadeOut("slow");
                     return false;
                 }
             });
         });
     </script>
                <style>
                    #errmsg3 {
                        color: red;
                    }
                </style>

    <script>
        $(document).ready(function () {
            $('#txtProduct').bind('keyup blur', function () {
                var node = $(this);
                node.val(node.val().replace(/[^a-z]/g, ''));
            }
            );
        });
    </script>




        <div class="container">
     
            <asp:HiddenField ID="hfId1" runat="server" />
            <asp:Label Text="" ID="lblError1" ForeColor="Red" Font-Bold="true" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="text-center">
                <h1 class="h4 text-gray-900 mb-4">Request Form</h1>
            </div>

            <div class="form2">
                <div class="input_field1">
                    <asp:Label ID="Label7" runat="server"></asp:Label>

                    <asp:Label ID="Label4" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                    <span id="errmsg"></span>
                    <asp:TextBox ID="TicketNo" runat="server" CssClass="input1" AutoPostBack="True" OnTextChanged="TicketNo_TextChanged" AccessKey="9" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label3" runat="server" Text="Requested Date:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" AutoPostBack="True" AccessKey="9" ClientIDMode="Static" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">

                    <asp:Label ID="Label1" runat="server" Text="PO Number" CssClass="label"></asp:Label>
                    <span id="errmsg2"></span>
                    <asp:TextBox ID="PONo" runat="server" CssClass="input1" AutoPostBack="True" OnTextChanged="PONo_TextChanged" AccessKey="8" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="input_field1">

                    <asp:Label ID="Label2" runat="server" Text="Supplier" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="dropSupplier" runat="server" CssClass="input1" DataTextField="Username" DataValueField="Username" DataSourceID="SqlDataSource1">
                    </asp:DropDownList>
                </div>



                <div class="input_field1">
                    <asp:Label ID="Label5" runat="server" Text="Product" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="drpProduct" runat="server" CssClass="input1">
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <span id="errmsg3"></span>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="input1" AccessKey="7" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click"/>
                </div>

  </div>
                            </div>
                   








</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
