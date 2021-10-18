<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Validate.aspx.cs" Inherits="BIOSproject.Generate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    
     <div class="container">

        
                    <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Validate Series</h1>
                            </div>

                            <div class="form3">
               <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Starting" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                   
                             
                                

                <div class="input_field1">

                    <asp:Label ID="Label3" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtTicket" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="PONumber" CssClass="label"></asp:Label>
                     <asp:TextBox ID="TxtPONo" runat="server" CssClass="input1"></asp:TextBox>
                </div>

            <div class="input_field1">
                <asp:Label ID="Label1" runat="server" Text="Supplier" CssClass="label"></asp:Label>
                <asp:TextBox ID="TxtSupplier" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Product" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1" Enabled="false"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1" Enabled="false"></asp:TextBox>
                </div>
                

                <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Validate" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click" />
        </div>           
        </div>
                                 

        </div>








</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
