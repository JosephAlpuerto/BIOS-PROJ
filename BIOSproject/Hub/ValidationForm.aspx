<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Hub.Master" AutoEventWireup="true" CodeBehind="ValidationForm.aspx.cs" Inherits="BIOSproject.Hub.ValidationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <div class="container">

        
                    <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Validate Series</h1>
                            </div>
         <asp:Label ID="Label7" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>

                            <div class="form3">
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Enter Tracking" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Enter Tracking" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="Enter Tracking" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                                <div class="input_field1">
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" CssClass="btn btn-primary btn-user btn-block" />
                                    </div>



</div>
        </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
