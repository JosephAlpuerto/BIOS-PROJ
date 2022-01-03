<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="MyRejectedRequestSupp.aspx.cs" Inherits="BIOSproject.MyRejectedRequestSupp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">My Rejected Request </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="Gridview" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" ShowFooter="True" EmptyDataText="No Records !">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="Supplier Name" />
                                        
                                         <%--<asp:TemplateField>
                                                           <ItemTemplate>

                                                               
                                                               <asp:LinkButton ID="ViewResetAdmin" runat="server" CommandArgument='<%# Eval("Id") %>'>View</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                                       <%--<asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-primary btn-user btn-block"  CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("IsActive").ToString() == "False"%>' OnClick="btnView_Click"/>
                                                                <asp:Button ID="Button1" runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField> --%>      
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
