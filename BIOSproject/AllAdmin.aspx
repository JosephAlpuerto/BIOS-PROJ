<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AllAdmin.aspx.cs" Inherits="BIOSproject.AllAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

   
                <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                            
                        <asp:Button Text="Generate Report" ID="btnPrint" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" Onclick="btnPrint_Click" runat="server"></asp:Button>

       <ajaxtoolkit:modalpopupextender ID="ModalAdmin" PopupControlID="PanelAdmin" TargetControlID="gvList" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelAdmin" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportAdmin" runat="server" Width="750px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
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

                                <asp:GridView runat="server" ID="gvList" CssClass="table table-bordered dataTable1" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Admin ID" />
                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                    </Columns>
                                </asp:GridView>
                               

                                </div>
                            </div>
                        </div>

   
    
   
        
</asp:Content>

    



