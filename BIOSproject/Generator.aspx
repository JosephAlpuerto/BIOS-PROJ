<%@ Page Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Generate.aspx.cs" Inherits="BIOSproject.Generate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Generator</h1>
                             


                        </div>
                        </div>
        </div>

        

        <div class="wrapper1">
            <div class="title1">
                Encode Series
            </div>

            <div class="form1">
                
                <div class="input_field1">
                    <asp:Label ID="Label1" runat="server" Text="Starting Series" CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="input2"></asp:TextBox>
        </div>
        <div class="input_field1">
            <asp:Label ID="Label2" runat="server" Text="Ending Series" CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="inpu"></asp:TextBox>
        </div>

                <div class="input_field1">
                    <asp:Label ID="Label3" runat="server" Text="Result" CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" CssClass="txtRes" Enabled="false"></asp:TextBox>
        </div>

        <div class="input_field1">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" CssClass="btnGen" />
            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btnSave" />
        </div>
                
         

               
            </div>


          

        </div>



    








</asp:Content>