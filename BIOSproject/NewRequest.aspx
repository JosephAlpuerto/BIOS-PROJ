<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="NewRequest.aspx.cs" Inherits="BIOSproject.NewRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <link href="css/NewRequest.css" rel="stylesheet" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Username] FROM [Users] WHERE RoleType = 'Supplier' and IsActive = '1'"></asp:SqlDataSource>
    
    <div class="wrapper">

        <div class="forms">



            <asp:Label ID="Label8" runat="server"></asp:Label>



            <asp:Label ID="lblError1" runat="server" ForeColor="Red"></asp:Label>
            <div class="field">
                <asp:Label ID="lblTicketNo" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                <asp:TextBox ID="TicketNo" runat="server" CssClass="input1"></asp:TextBox>
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <div class="field">
                <asp:Label ID="Label2" runat="server" Text="Requested Date" CssClass="label"></asp:Label>
                <asp:TextBox ID="ReqDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
            </div>
            

            <div class="field">
                <asp:Label ID="Label3" runat="server" Text="PO Number" CssClass="label"></asp:Label>
                <asp:TextBox ID="PONumber" runat="server" CssClass="input1" AutoPostBack="true" OnTextChanged="PONumber_TextChanged"  AccessKey="8" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="field">
                <asp:Label ID="Label4" runat="server" Text="Supplier" CssClass="label"></asp:Label>
                <asp:DropDownList ID="dropSupplier" runat="server" CssClass="input1" >
                </asp:DropDownList>
            </div>

            <div class="field">
                <asp:Label ID="Label5" runat="server" Text="Product" CssClass="label1"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="label2"></asp:Label>
                
                <asp:HiddenField ID="HFValue" runat="server" />
            </div>

            <div class="field">
                <asp:DropDownList ID="DropProduct" runat="server" CssClass="drop1">
                    <asp:ListItem>KILO BOX</asp:ListItem>
                    <asp:ListItem>KB MINI</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TxtQuantity" runat="server" CssClass="drop2"></asp:TextBox>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-primary btn-user btn-block" OnClick="Button2_Click"/>
                <br />
                <asp:TextBox ID="TxtAllProduct" runat="server" TextMode="MultiLine" CssClass="input1" value="=Convert.ToString(info[0])" ></asp:TextBox>
            </div>
            
            <div class="field">
                <asp:Label ID="Label7" runat="server" Text="Total Quantity" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server" CssClass="input1" ></asp:TextBox>
            </div>


          

            <br />
            <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click"/>
                </div>

        </div>

    </div>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
