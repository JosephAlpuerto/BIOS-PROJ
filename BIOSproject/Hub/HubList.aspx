﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Hub.Master" AutoEventWireup="true" CodeBehind="HubList.aspx.cs" Inherits="BIOSproject.Supplier.SupplierList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
     <ajaxtoolkit:modalpopupextender ID="ModalRequest" PopupControlID="PanelRequest" TargetControlID="gvModal" CancelControlID="btnClose"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelRequest" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <div class="container">

               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_Ref %>" SelectCommand="SELECT [AreaDescr] FROM [Areas]"></asp:SqlDataSource>
                    <div class="modal-header" >
                                <h5 class="modal-title" id="">
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_Ref %>" SelectCommand="SELECT [BranchCode] + ' - ' + [BranchDescr] as BranchCodeDesc FROM [ref_Branches]"></asp:SqlDataSource>
                                    Barcode Issuer</h5>
                                <button id="btnClose" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>

                            <div class="forms">
                                
                                <asp:HiddenField ID="hfId" runat="server" />
                                <asp:Label Text="" ID="lblSuccess" ForeColor="Green" Font-Bold="true" runat="server" />
                 <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label7" runat="server" Text="Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtRequestID" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Supplier Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtSuppRequestID" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Tracking No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTicket" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                 <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="PO No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtPO" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Supplier Schedule Request" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" ></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtArea" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <%--<div class="input_field1">
                    
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>--%>

            <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtBranch" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                

                <%--<div class="input_field1">
                    
                    <asp:Label ID="Label6" runat="server" Text="Starting Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>

                <%--<div class="input_field1">
                   
                    <asp:Label ID="Label7" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>
               <%-- <div class="input_field1">
                   
                    <asp:Label ID="Label8" runat="server" Text="Particulars" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1"></asp:DropDownList>
                </div>--%>
                

                <div class="input_field1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click"/>
        </div>  
                                 

        </div>
                                    

        </div>
        </asp:Panel>
    
    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">DataTables </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                         <asp:ButtonField DataTextField="RequestID" HeaderText="Supplier Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PoNO" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="ScheduleRequest" HeaderText="Scedule Request" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />
                                        <asp:ButtonField DataTextField="CreatedBy" HeaderText="CreatedBy" />
                                        <asp:ButtonField DataTextField="CreatedDate" HeaderText="CreatedDate" />

                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="Destination" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnRequest_Click"/>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <%-- <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-primary btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                       

                                                       
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
