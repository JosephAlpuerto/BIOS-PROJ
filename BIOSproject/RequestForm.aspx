<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="RequestForm.aspx.cs" Inherits="BIOSproject.RequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Username] FROM [Users] WHERE RoleType = 'Supplier'"></asp:SqlDataSource>
     <div class="container">
          <asp:HiddenField ID="hfId1" runat="server" />
                            <asp:Label Text="" ID="lblError1" ForeColor="Red" Font-Bold="true" runat="server" />
         <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Request Form</h1>
                            </div>

                            <div class="form2">

                 <div class="input_field1">
                   
                    <asp:Label ID="Label4" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="TicketNo" runat="server" CssClass="input1" AutoPostBack="True" OnTextChanged="TicketNo_TextChanged"></asp:TextBox>
                </div>

               <div class="input_field1">
                   
                    <asp:Label ID="Label1" runat="server" Text="PO Number" CssClass="label"></asp:Label>
                    <asp:TextBox ID="PONo" runat="server" CssClass="input1" AutoPostBack="True" OnTextChanged="PONo_TextChanged"></asp:TextBox>
                </div>
                               
                <div class="input_field1">
                   
                    <asp:Label ID="Label2" runat="server" Text="Supplier" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="txtSupplier" runat="server" CssClass="input1" DataSourceID="SqlDataSource1" DataTextField="Username" DataValueField="Username">
                      
                    </asp:DropDownList>
                </div>

                

                <div class="input_field1">
                    <asp:Label ID="Label5" runat="server" Text="Product" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="input1"></asp:TextBox>
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
