<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="SourcingReports.aspx.cs" Inherits="BIOSproject.SouringReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="Title">
        <asp:Label runat="server" Text="PO MONITORING REPORT" Font-Size="X-Large"></asp:Label>
    </div>

     <div class="Base">
         <div class="Menu">
        <asp:Label ID="Label1" runat="server" Text="Supplier:"></asp:Label> 
        <asp:TextBox ID="ddlSupplier" runat="server" CssClass="input1"></asp:TextBox>  
               <asp:AutoCompleteExtender ServiceMethod="GetCompletionList1" 
                   MinimumPrefixLength="1"   
                   CompletionInterval="10" 
                   EnableCaching="false" 
                   CompletionSetCount="1" 
                   TargetControlID="ddlSupplier"    
                    ID="AutoCompleteExtender1" 
                   runat="server" 
                   FirstRowSelected="false">    
                </asp:AutoCompleteExtender>
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
        <asp:Button ID="btnSearch" runat="server" CssClass="btnALL" ForeColor="White" BackColor="Gray" Text="SEARCH" OnClick="btnSearch_Click"/>
        <asp:Button ID="btnClear" runat="server" CssClass="btnALL" ForeColor="White" BackColor="Gray" Text="CLEAR" OnClick="btnClear_Click"/>
         </div>
        <asp:GridView runat="server" ID="gvlist" CssClass="gridview" HeaderStyle-CssClass="gvcenter" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="ProductCode" HeaderText="PRODUCT CODE" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="Material" HeaderText="DESCRIPTION" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" HeaderText="PO NUMBER"/>
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POqty" HeaderText="PO QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POproduced" HeaderText="PRODUCED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POissued" HeaderText="ISSUED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="PObalance" HeaderText="PO BALANCE" />

                                    </Columns>
                                </asp:GridView>

         <asp:GridView runat="server" ID="gvlist2" Visible="false" CssClass="gridview" HeaderStyle-CssClass="gvcenter" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="ProductCode" HeaderText="PRODUCT CODE" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="Material" HeaderText="DESCRIPTION" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POnumber" HeaderText="PO NUMBER"/>
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POqty" HeaderText="PO QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POproduced" HeaderText="PRODUCED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POissued" HeaderText="ISSUED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="PObalance" HeaderText="PO BALANCE" />

                                    </Columns>
                                </asp:GridView>

          <asp:GridView runat="server" ID="gvlist3" Visible="false" CssClass="gridview" HeaderStyle-CssClass="gvcenter" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="SuppName" HeaderText="SUPPLIER NAME" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="ProductCode" HeaderText="PRODUCT CODE" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="Material" HeaderText="DESCRIPTION" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POnumber" HeaderText="PO NUMBER"/>
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POqty" HeaderText="PO QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POproduced" HeaderText="PRODUCED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="POissued" HeaderText="ISSUED QTY" />
                                        <asp:ButtonField ItemStyle-HorizontalAlign="Center" DataTextField="PObalance" HeaderText="PO BALANCE" />

                                    </Columns>
                                </asp:GridView>


    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
