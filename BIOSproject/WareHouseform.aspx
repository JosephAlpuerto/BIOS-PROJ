<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Warehouse.Master" AutoEventWireup="true" CodeBehind="WareHouseform.aspx.cs" Inherits="BIOSproject.WareHouseform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="big">
        
        <div class="container1">

               

                            <div class="forms">

<div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Date" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" Enabled="false" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>


                <div class="input_field1">
                    <asp:Label ID="lblArea" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" runat="server" AutoPostBack="true" CssClass="input1">
                    </asp:DropDownList>
                </div>


            <div class="input_field1">
                <asp:Label ID="lblTeam" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" AutoPostBack="true" CssClass="input1">
                    </asp:DropDownList>
                </div>

                 <div class="input_field1">
                <asp:Label ID="lblBranch" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" runat="server" AutoPostBack="true" CssClass="input1">
                        </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label7" runat="server" Text="StartingSeries" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStart" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label8" runat="server" Text="EndingSeries" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEnd" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            <div class="input_field1">
                    <asp:Label ID="Label3" runat="server" Text="No. Of Units" CssClass="label"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Text="0" CssClass="input1"></asp:Label>
                </div>
                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Particulars" CssClass="label"></asp:Label>
                     <asp:DropDownList ID="DropProduct" runat="server" CssClass="input1"></asp:DropDownList>
                </div>
            <div class="input_field1">
                <asp:Button ID="Button1" runat="server" Text="Update" CssClass="btn"/>
                <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn"/>
                </div>



                                </div>
            </div>

        <div class="container">

               

                            <div class="forms">

                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Date" CssClass="label1"></asp:Label>
                    <asp:TextBox ID="TextBox1" Enabled="false" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>

                     <asp:Button ID="Button3" runat="server" Text="Display" CssClass="btn"/>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Sample</asp:ListItem>
                    </asp:DropDownList>
                     <asp:Button ID="Button4" runat="server" Text="Inquiry" CssClass="btn"/>
                     <asp:Button ID="Button5" runat="server" Text="Print" CssClass="btn"/>

                </div>


               


    <asp:GridView runat="server" RowStyle-Width="100px" ID="Gridview1" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" ShowFooter="True" EmptyDataText="No Records !">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true"/>
                                                </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField DataTextField="RequestNo" HeaderText="Request No." />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product/Quantity" />


                                    </Columns>
                                </asp:GridView>



                                </div>
            </div>
        
</div>
        

    






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
