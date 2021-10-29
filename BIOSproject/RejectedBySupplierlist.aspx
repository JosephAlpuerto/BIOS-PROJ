<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="RejectedBySupplierlist.aspx.cs" Inherits="BIOSproject.RejectedBySupplierlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


     <ajaxtoolkit:modalpopupextender ID="ModalViewReject" PopupControlID="PanelViewReject" TargetControlID="gvModal" CancelControlID="Close"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelViewReject" runat="server">
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
               <asp:HiddenField ID="hfId" runat="server" />   
               <asp:HiddenField ID="hfSupplier" runat="server" />   
               <asp:HiddenField ID="hfSourcing" runat="server" />   
               <asp:HiddenField ID="hfProduct" runat="server" />   
               <asp:HiddenField ID="hfQuantity" runat="server" />    
               <table >
                   
                   <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                   

                   <asp:Label runat="server" ForeColor="Green" Text="Edit the Rejected Request!"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="RequestID:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtRequestID" CssClass="form-control form-control-user col-12" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Ticket No:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtTicketNo" CssClass="form-control form-control-user" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="PO No:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtPONo" CssClass="form-control form-control-user" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Starting Series:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtStart" CssClass="form-control form-control-user" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Ending Series:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtEnd" CssClass="form-control form-control-user" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                  

                  
               </table>
         <asp:Button ID="btnSave" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Update" OnClick="btnSave_Click"   />
         <asp:Button ID="Close" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" />
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
                            <h6 class="m-0 font-weight-bold text-primary">Rejected Request By Supplier </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="Gridview" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="Supplier Name" />
                                        <asp:ButtonField DataTextField="Product" HeaderText="Product" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Quantity" />
                                        
                                                     <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="ViewRejected" runat="server" Text="Edit" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") %>' OnClick="ViewRejected_Click" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                           
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
