<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="SourcingDashboard.aspx.cs" Inherits="BIOSproject.SourcingDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    
        <div class="content">
            <div class="cards">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label1" runat="server" Text="No. of PO" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="LblPO" runat="server" Text="" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label3" runat="server" Text="HitCheck" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblHitcheck" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label5" runat="server" Text="On Production" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label6" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label7" runat="server" Text="On Stock" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label8" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label9" runat="server" Text="Completed" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label10" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>

          
        </div>
   

    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">DataTables </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server"/>
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:ButtonField DataTextField="VendorName" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="Number" HeaderText="Ticket No." />
                                         <asp:ButtonField HeaderText="PO No." />
                                         <asp:ButtonField HeaderText="Starting Series" />
                                        <asp:ButtonField HeaderText="Ending Series" />

                                                       

                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
                     </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
