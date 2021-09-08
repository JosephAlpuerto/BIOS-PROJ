<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AllAdmin.aspx.cs" Inherits="BIOSproject.AllAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
                <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                            <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                                class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
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