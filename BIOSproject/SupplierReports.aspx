<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="SupplierReports.aspx.cs" Inherits="BIOSproject.SupplierReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Label runat="server" Text="PO MONITORING REPORT" Font-Size="X-Large"></asp:Label>
    </div>

     <div>
        <asp:Label ID="Label2" runat="server" Text="Per Product:"></asp:Label>
         <asp:TextBox ID="ddlProduct" runat="server" CssClass="input1"></asp:TextBox>  
               <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" 
                   MinimumPrefixLength="1"   
                   CompletionInterval="10" 
                   EnableCaching="false" 
                   CompletionSetCount="1" 
                   TargetControlID="ddlProduct"    
                    ID="AutoCompleteExtender" 
                   runat="server" 
                   FirstRowSelected="false">    
                </asp:AutoCompleteExtender>
        <asp:Label ID="Label3" runat="server" Text="Per PO:"></asp:Label>  
          <asp:TextBox ID="ddlPO" runat="server" CssClass="input1"></asp:TextBox>  
               <asp:AutoCompleteExtender ServiceMethod="GetCompletionList2" 
                   MinimumPrefixLength="1"   
                   CompletionInterval="10" 
                   EnableCaching="false" 
                   CompletionSetCount="1" 
                   TargetControlID="ddlPO"    
                    ID="AutoCompleteExtender2" 
                   runat="server" 
                   FirstRowSelected="false">    
                </asp:AutoCompleteExtender>
        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click"/>
        <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click"/>

        <asp:GridView runat="server" ID="gvlist" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField DataTextField="ProductCode" HeaderText="PRODUCT CODE" />
                                        <asp:ButtonField DataTextField="Material" HeaderText="DESCRIPTION" />
                                        <asp:ButtonField HeaderText="PO NUMBER"/>
                                        <asp:ButtonField DataTextField="POqty" HeaderText="PO QTY" />
                                        <asp:ButtonField DataTextField="POproduced" HeaderText="PRODUCED QTY" />
                                        <asp:ButtonField DataTextField="POissued" HeaderText="ISSUED QTY" />
                                        <asp:ButtonField DataTextField="PObalance" HeaderText="PO BALANCE" />

                                    </Columns>
                                </asp:GridView>

         <asp:GridView runat="server" ID="gvlist2" Visible="false" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField DataTextField="ProductCode" HeaderText="PRODUCT CODE" />
                                        <asp:ButtonField DataTextField="Material" HeaderText="DESCRIPTION" />
                                        <asp:ButtonField DataTextField="POnumber" HeaderText="PO NUMBER"/>
                                        <asp:ButtonField DataTextField="POqty" HeaderText="PO QTY" />
                                        <asp:ButtonField DataTextField="POproduced" HeaderText="PRODUCED QTY" />
                                        <asp:ButtonField DataTextField="POissued" HeaderText="ISSUED QTY" />
                                        <asp:ButtonField DataTextField="PObalance" HeaderText="PO BALANCE" />

                                    </Columns>
                                </asp:GridView>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
