<%@ Page Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Generate.aspx.cs" Inherits="BIOSproject.Generate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Generate Series</h1>
                             


                        </div>
                        </div>
        </div>

    
          <div class="wrapper1">
            <div class="title1">
                Encode Series
            </div>

            <div class="form1">
                <div class="input_field1">
                    <label>Date</label>
                    <asp:TextBox ID="TxtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <label>Area</label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1">
                        <asp:ListItem>EMM - EAST METRO MANILA</asp:ListItem>
                        <asp:ListItem>EAST METRO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <label>Team</label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                        <asp:ListItem>ANTIPOLO</asp:ListItem>
                        <asp:ListItem>1075 - ANTIPOLO TEAM</asp:ListItem>
                    </asp:DropDownList>
                </div>
            <div class="input_field1">
                    <label>Branch</label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1">
                        <asp:ListItem>EMM - EAST METRO MANILA</asp:ListItem>
                        <asp:ListItem>1319 - ANTIPOLO CIRCUMFERENTIAL</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <label>Start Series</label>
                    <asp:TextBox ID="TxtStart" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <label>End Series</label>
                    <asp:TextBox ID="TxtEnd" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <label>Quantity</label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>                

                
                <div class="inputfield1">
                    <asp:Button ID="Button1" runat="server" Text="Done" CssClass="btn" OnClick="Button1_Click" />
      </div>



               
            </div>


          

        </div>
        





</asp:Content>