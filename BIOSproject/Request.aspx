<%@ Page Title="" Language="C#" MasterPageFile="~/BIOS.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="BIOSproject.Gen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">





    <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Request</h1>
                             


                        </div>
                        </div>
        </div>

    
          <div class="wrapper1">
            <div class="title1">
                Request
            </div>

            <div class="form1">
                <div class="input_field1">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <label>Date Requested</label>
                    <asp:TextBox ID="TxtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <label>Area</label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1">
                       
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <label>Team</label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>
            <div class="input_field1">
                    <label>Branch</label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1">
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <label>Product</label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <label>Quantity</label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                

                <div class="inputfield1">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" OnClick="Button1_Click"/>
      </div>


               
            </div>


          

        </div>
        

























</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
