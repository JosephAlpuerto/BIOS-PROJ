<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="AllRequest.aspx.cs" Inherits="BIOSproject.Request1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     
    <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                          
                        <ajaxtoolkit:modalpopupextender ID="ModalUsers" PopupControlID="PanelUsers" TargetControlID="gvModal" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelUsers" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                       <asp:Button ID="btnClose" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" />
                            </asp:Panel>
                            </div>
                        </div>
        </div>
    <!-- DataView Example -->
     <ajaxtoolkit:modalpopupextender ID="ModalView" PopupControlID="PanelView" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelView" runat="server">
           
           
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-2">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                            
         
    <div>
               <asp:HiddenField ID="HiddenField1" runat="server" />
               <table >
                   
                   <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                   <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="Date:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ReadOnly="true" ID="TxtDate" CssClass="form-control form-control-user col-12" placeholder="Date" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" CssClass="col-10" Text="Area:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ReadOnly="true" ID="TxtArea" CssClass="form-control form-control-user col-12" placeholder="Area" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Team:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ReadOnly="true" ID="TxtTeam" CssClass="form-control form-control-user" placeholder="Team" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Branch:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ReadOnly="true" ID="TxtBranch" CssClass="form-control form-control-user" placeholder="Branch" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                    <tr>
                       <td>
                           <asp:Label runat="server" Text="Product:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ReadOnly="true" ID="TxtProduct" CssClass="form-control form-control-user" placeholder="Product" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Quantity:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ReadOnly="true" ID="TxtQuantity" CssClass="form-control form-control-user" placeholder="Quantity" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Status:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ReadOnly="true" ID="TxtStatus" CssClass="form-control form-control-user" placeholder="Status" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                  
               </table>
         <asp:Button ID="btnSave" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Check Series"  />
         
         
    </div>
                
                   
                         </div>
                    </div>
                </div>
         <asp:Button ID="Close" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" />
            </div>
       </div> 
  </div>
               
</asp:Panel>

        
    <br />
    <br />
     <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">DataTables </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="HfID" runat="server" />
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Requested ID" />
                                        <asp:ButtonField DataTextField="DateRequested" HeaderText="DateRequested" />
                                         <asp:ButtonField DataTextField="Product" HeaderText="Product" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Quantity" />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                        <asp:ButtonField DataTextField="Team" HeaderText="Team" />
                                       

                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnk_OnClick">View</asp:LinkButton>
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
