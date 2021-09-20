<%@ Page Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="BIOSproject.AllUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                            <asp:Button Text="Generate Report" ID="btnPrint2" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnPrint2_Click" runat="server"></asp:Button>
                        
                        <ajaxtoolkit:modalpopupextender ID="ModalUsers" PopupControlID="PanelUsers" TargetControlID="gvList1" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelUsers" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportUsers" runat="server" Width="750px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
                       <asp:Button ID="btnClose" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" />
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

                                <asp:GridView runat="server" ID="gvList1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Users ID" />
                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                        <asp:ButtonField DataTextField="MobileNumber" HeaderText="Mobile Number" />
                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
                        </div>

</asp:Content>