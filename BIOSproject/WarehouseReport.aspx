<%@ Page Title="" Language="C#" MasterPageFile="~/Warehouse.Master" AutoEventWireup="true" CodeBehind="WarehouseReport.aspx.cs" Inherits="BIOSproject.WarehouseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Label ID="LblAlert" runat="server" Text="" ForeColor="Red"></asp:Label>

      <div>
        
        <asp:Label ID="Label1" runat="server" Text="Tracking Series:" CssClass="label"></asp:Label>
        <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click"/>
        <asp:Label ID="Label2" runat="server" Text="From:" CssClass="label"></asp:Label>
        <asp:TextBox ID="TxtFromDate" runat="server" TextMode="Date" CssClass="input1"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="To" CssClass="label" ></asp:Label>
        <asp:TextBox ID="TxtToDate" runat="server" TextMode="Date" CssClass="input1"></asp:TextBox>
        <asp:Button ID="BtnDateDisplay" runat="server" Text="Search By Date"/>

        <asp:GridView runat="server" ID="Gridview1" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField DataTextField="CreatedDate" HeaderText="DateScanned" />
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Start" />
                                         <asp:ButtonField DataTextField="EndingSeries" HeaderText="End" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                         <asp:ButtonField DataTextField="Team" HeaderText="Team" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />

                                    </Columns>
                                </asp:GridView>


    </div>
    
















</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
