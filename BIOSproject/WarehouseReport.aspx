<%@ Page Title="" Language="C#" MasterPageFile="~/Warehouse.Master" AutoEventWireup="true" CodeBehind="WarehouseReport.aspx.cs" Inherits="BIOSproject.WarehouseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">





    <div>
        <asp:TextBox ID="TxtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" />
        <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
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
