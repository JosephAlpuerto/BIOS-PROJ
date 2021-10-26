<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Hub.Master" AutoEventWireup="true" CodeBehind="ProcessList.aspx.cs" Inherits="BIOSproject.Hub.ProcessList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="wrapper">
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                        <asp:Button Text="Print Report" ID="btnDownload" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" Onclick="btnDownload_Click" runat="server"></asp:Button>
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <ajaxtoolkit:modalpopupextender ID="ModalReport" PopupControlID="PanelReport" TargetControlID="gvModal" PopupDragHandleControlID="headerReport"  CancelControlID="btnCloseReport" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelReport"  runat="server">
                        
                            <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div id="headerReport" class="modal-header" >
                                <h5 class="modal-title" id="">Print Report</h5>
                                <button id="btnCloseReport" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                       
                        <rsweb:ReportViewer ID="ReportRequest" runat="server" Width="1200px" Height="400px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
                       </div></div>
                            </asp:Panel>
                       
                            </div>
                        </div>
                     </div>




     <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">DataTables </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="gvlist" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="ID" />
                                         <asp:ButtonField DataTextField="RequestID" HeaderText="Supplier Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PoNO" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                         <asp:ButtonField DataTextField="ScheduleRequest" HeaderText="Scedule Request" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />
                                        <asp:ButtonField DataTextField="Team" HeaderText="Team" />
                                        <asp:ButtonField DataTextField="Product" HeaderText="Product" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Quantity" />
                                        <asp:ButtonField DataTextField="CreatedBy" HeaderText="SupplierName" />
                                        <asp:ButtonField DataTextField="CreatedDate" HeaderText="CreatedDate" />

                                                       <%--<asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="Destination" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnProcess_Click"/>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btn" runat="server" Enabled="false" Text="OnProcess" CssClass="btn" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
          
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
