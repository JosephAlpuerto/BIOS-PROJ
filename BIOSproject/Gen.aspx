<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Gen.aspx.cs" Inherits="BIOSproject.Gen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <label>Area</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1">
                        <asp:ListItem>EMM - EAST METRO MANILA</asp:ListItem>
                        <asp:ListItem>EAST METRO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <label>Team</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="input1">
                        <asp:ListItem>ANTIPOLO</asp:ListItem>
                        <asp:ListItem>1075 - ANTIPOLO TEAM</asp:ListItem>
                    </asp:DropDownList>
                </div>
            <div class="input_field1">
                    <label>Branch</label>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="input1">
                        <asp:ListItem>EMM - EAST METRO MANILA</asp:ListItem>
                        <asp:ListItem>1319 - ANTIPOLO CIRCUMFERENTIAL</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <label>Start Series</label>
                    <input type="text" class="input1" />
                </div>

                <div class="input_field1">
                    <label>End Series</label>
                    <input type="text" class="input1" />
                </div>
                <div class="input_field1">
                    <label>Upload File</label>
                   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input1" />
                </div>

                <div class="inputfield1">
        <input type="submit" value="Done" class="btn"/>
      </div>


               
            </div>


          

        </div>
        

























</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
