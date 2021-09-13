<%@ Page Language="C#" MasterPageFile="~/BIOS.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="BIOSproject.Supplier" %>
         
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Validate Series</h1>
                            
                        </div>
                        </div>
        </div>


    <div class="wrapper">
            <div class="title">
                Validate Series
            </div>

            <div class="form">
                <div class="input_field">
                    <label>Enter Tracking</label>
                    <input type="text" class="input" />

                </div>



                <div class="input_field">
                    <label>Area</label>
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="input" Enabled="false"></asp:DropDownList>
                </div>

                <div class="input_field">
                    <label>Teams</label>
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="input" Enabled="false"></asp:DropDownList>
                </div>

                <div class="input_field">
                    <label>Branch</label>
                    <asp:DropDownList ID="DropDownList6" runat="server" CssClass="input" Enabled="false"></asp:DropDownList>
                </div>

                <div class="input_field">
                    <label>Date</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input" TextMode="Date" ReadOnly="true"></asp:TextBox>
                    
                </div>
                <div class="input_field">
                    <label>Start Series</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="input" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="input_field">
                    <label>End Series</label>
                    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                </div>

                
            </div>
        </div>




    </asp:Content>