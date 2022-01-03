<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Warehouse.Master" AutoEventWireup="true" CodeBehind="WarehouseProcesslist.aspx.cs" Inherits="BIOSproject.Hub.WarehouseProcesslist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="wrapper">
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800"></h1>
                        <%--<asp:Button Text="Print Report" ID="btnDownload" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" Onclick="btnDownload_Click" runat="server"></asp:Button>--%>
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



     <ajaxtoolkit:modalpopupextender ID="ModalDownloadView" PopupControlID="PanelDownloadView" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelDownloadView" runat="server">
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
                
               <table >
                   
                   <asp:Label ID="Label10" runat="server" Text="" ForeColor="Green"></asp:Label>
                   

                   <asp:Label runat="server" ForeColor="Red" Text="Are you sure you want to Download this Request!?"></asp:Label>
                   
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="ID:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtId" CssClass="form-control form-control-user" Enabled="false" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <asp:HiddenField ID="hfTicketNo" runat="server" />   
                   <asp:HiddenField ID="hfPONumber" runat="server" />   
                   <asp:HiddenField ID="hfStartingSeries" runat="server" />   
                   <asp:HiddenField ID="hfEndingSeries" runat="server" />   
                   <asp:HiddenField ID="hfSupplier" runat="server" />  
                   <asp:HiddenField ID="hfProduct" runat="server" />  
                   <asp:HiddenField ID="hfQuantity" runat="server" /> 
                   <asp:HiddenField ID="hfSchedule" runat="server" /> 

               </table>
         <asp:Button ID="Download" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Download Now" OnClick="Download_Click" />
         <asp:Button ID="btnCloseDownloadView" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseDownloadView_Click"/>
    </div>
                            </div>
                          </div>
                        </div>
               
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
                                <asp:GridView runat="server" ID="gvlist" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" ShowFooter="True" EmptyDataText="No Records !">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request No." />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PoNumber" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                         <asp:ButtonField DataTextField="ScheduleDate" HeaderText="Scedule Date" />
                                       <%-- <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product list" />
                                        <asp:ButtonField DataTextField="TotalQuantity" HeaderText="Total Quantity" />--%>
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="SupplierName" />
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

                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="DownloadView" runat="server" Text="Download" CommandArgument='<%# Eval("Id") %>' OnClick="DownloadView_Click" CssClass="btn btn-primary btn-user btn-block"></asp:LinkButton>
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
