<%@ Page Language="C#" MasterPageFile="~/BIOS.Master" AutoEventWireup="true" CodeBehind="HitCheck.aspx.cs" Inherits="BIOSproject.HitCheck" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <<div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Request Series</h1>
                             


                        </div>
                        </div>
        </div>

    <div class="wrapp">
            <div class="title1">
                Request
            </div>

            <div class="form1">

                <div class="input_field1">
                    <label>Product</label>

                    <asp:TextBox ID="TextBox2" runat="server" CssClass="input1" ></asp:TextBox>
                </div>
                <div class="input_field1">
                    <label>Quantity</label>

                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1" TextMode="Number"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Button ID="Button2" runat="server" Text="Request" CssClass="btn3" />
                </div>


    </div>
        </div>


</asp:Content>