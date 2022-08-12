<%@ Page Title="" Language="C#" MasterPageFile="~/Warehouse.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="Branch.aspx.cs" Inherits="BIOSproject.Branch" %>
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
                    <asp:Label ID="Label4" runat="server" Text="Enter Tracking" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Area</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1" Enabled="false">
                       
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1" Enabled="false">
                      
                    </asp:DropDownList>
                </div>

            <div class="input_field1">
                    <%--<label>Branch</label>--%>
                <asp:Label ID="Label1" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1" Enabled="false">
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Date" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1" Enabled="false"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Starting Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1" Enabled="false"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label7" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1" Enabled="false"></asp:TextBox>
                </div>
                

                <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Validate" CssClass="btn btn-primary btn-user btn-block" />
        </div>           
        </div>
                                 

        </div>






































</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
