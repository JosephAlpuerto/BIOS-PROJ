<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AllDeletedAccounts.aspx.cs" Inherits="BIOSproject.AllDeletedAccounts" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <ajaxtoolkit:modalpopupextender ID="ModalActivateAdmin" PopupControlID="PanelActivateAdmin" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelActivateAdmin" runat="server">   
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
               <asp:HiddenField ID="hfId" runat="server" />
               <asp:HiddenField ID="hfPassword" runat="server" />
               <table >
                   
                   <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                   <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

                   <asp:Label runat="server" ForeColor="Red" Text="Are you sure you want to Activate this account?"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="Email:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtEmail" CssClass="form-control form-control-user col-12" placeholder="Email" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="FirstName:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtFname" CssClass="form-control form-control-user" placeholder="FirstName" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="LastName:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtLname" CssClass="form-control form-control-user" placeholder="LastName" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                  
               </table>
         <asp:Button ID="btnActivate" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Activate" Onclick="btnActivate_Click" />
         <asp:Button ID="Close" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseView_Click" />
    </div>
                            </div>
                          </div>
                        </div>
               
                      </div>
                    </div>
                  </div>
</asp:Panel>


     <!-- DataTales Admin Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Deactivate Admin Account's </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                           <asp:Label ID="lblSuccess1" runat="server" Text="" ForeColor="Green"></asp:Label>
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="gvList" CssClass="table table-bordered dataTable1" width="100%" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:ButtonField DataTextField="Id" HeaderText="Admin ID" />
                                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                                        <asp:ButtonField DataTextField="DeletedBy" HeaderText="Deleted By" />
                                                        <asp:ButtonField DataTextField="DeletedDate" HeaderText="Deleted Date" />

                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="Activate" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Activate_Click">Activate</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                       
                                                    </Columns>
                                                </asp:GridView>
                                             </div>
                                        </div>
                                    </div>


    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxtoolkit:modalpopupextender ID="ModalActivateUsers" PopupControlID="PanelActivateUsers" TargetControlID="gvModal1"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelActivateUsers" runat="server">   
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
               <asp:HiddenField ID="hfId1" runat="server" />
               <asp:HiddenField ID="hfPassword1" runat="server" />
               <table >

                   <asp:Label runat="server" ForeColor="Red" Text="Are you sure you want to Activate this account?"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="Email:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtEmail1" CssClass="form-control form-control-user col-12" placeholder="Email" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="FirstName:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtFname1" CssClass="form-control form-control-user" placeholder="FirstName" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="LastName:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtLname1" CssClass="form-control form-control-user" placeholder="LastName" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                    <tr>
                       <td>
                           <asp:Label runat="server" Text="MobileNumber:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtMobile1" CssClass="form-control form-control-user" placeholder="MobileNumber" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                  
               </table>
         <asp:Button ID="btnActivateUsers" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Activate" Onclick="btnActivateUsers_Click" />
         <asp:Button ID="btnCloseViewUsers" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" Onclick="btnCloseViewUsers_Click" />
    </div>
                            </div>
                          </div>
                        </div>
               
                      </div>
                    </div>
                  </div>
</asp:Panel>

    <!-- DataTales Users Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Deactivate User Account's </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                            <asp:Label ID="lblSuccess2" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:HiddenField ID="gvModal1" runat="server" />
                                <asp:GridView runat="server" ID="gvList1" CssClass="table table-bordered dataTable1" width="100%" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:ButtonField DataTextField="Id" HeaderText="Users ID" />
                                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                                        <asp:ButtonField DataTextField="MobileNumber" HeaderText="Mobile Number" />
                                                        <asp:ButtonField DataTextField="DeletedBy" HeaderText="Deleted By" />
                                                        <asp:ButtonField DataTextField="DeletedDate" HeaderText="Deleted Date" />
                                                        
                                                        
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="Activate" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Activate1_Click">Activate</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                       
                                                    </Columns>
                                                </asp:GridView>
                                             </div>
                                        </div>
                                    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
