<%@ Page Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="BIOSproject.AllUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bg-white {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div id="wrapper">
        
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                        <asp:Button Text="Add User Account" ID="btnAddUser" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnAddUser_Click" runat="server"></asp:Button>
                        <asp:Button Text="All Active Accounts" ID="btnAllActive" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnAllActive_Click" runat="server"></asp:Button>
                        <asp:Button Text="All Deactive Accounts" ID="btnAllDeactive" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnAllDeactive_Click" runat="server"></asp:Button>
                        <asp:Button Text="Generate Report" ID="btnPrint2" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnPrint2_Click" runat="server"></asp:Button>
                        
                        <ajaxtoolkit:modalpopupextender ID="ModalUsers" PopupControlID="PanelUsers" TargetControlID="gvModal" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelUsers" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportUsers" runat="server" Width="757px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
                       <asp:Button ID="btnClose" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" />
                            </asp:Panel>
                            </div>
                        </div>
                     </div>

     <ajaxtoolkit:modalpopupextender ID="ModalAddUser" PopupControlID="PanelAddUser" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelAddUser" runat="server">
            <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Create an User Account!</h1>
                            </div>
                            <asp:HiddenField ID="hfId1" runat="server" />
                            <asp:Label Text="" ID="lblError1" ForeColor="Red" Font-Bold="true" runat="server" />

                            <div class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                            
                               <asp:TextBox runat="server" ID="txtUFirstName1" CssClass="form-control form-control-user" placeholder="First Name"/>

                                    </div>
                                    <div class="col-sm-6">

                               <asp:TextBox runat="server" ID="txtULastName1" CssClass="form-control form-control-user" placeholder="Last Name"/>
                                        
                                    </div>
                                </div>
                                <div class="form-group">

                                    <asp:TextBox runat="server" ID="txtUEmail1" CssClass="form-control form-control-user" placeholder="Email"/>
                                  
                                </div>

                                <div class="form-group">

                                   <asp:TextBox runat="server" ID="txtUNumber1" CssClass="form-control form-control-user" placeholder="Mobile Number"/>
                                                                         
                                </div>


                               <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">

                               <asp:TextBox runat="server" ID="txtUPassword1" TextMode="Password" CssClass="form-control form-control-user" placeholder="Password"/>
                                        
                                    </div>
                                    <div class="col-sm-6">

                                <asp:TextBox runat="server" ID="txtUConfirmPassword1" TextMode="Password" CssClass="form-control form-control-user" placeholder="Confrim Password"/>
                                        
                                    </div>
                                </div>

                                <asp:Button Text="Add Account" ID="buttonAddUser1" CssClass="btn btn-primary btn-user btn-block" runat="server" Onclick="buttonAddUser1_Click"/>
                                <hr>    
                            </div>
                                 </ContentTemplate></asp:UpdatePanel>     
                        </div>
                    </div>
                </div>
                <asp:Button ID="AddUserbtn" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="AddUserbtn_Click" />
            </div>
        </div>
    </div>
</asp:Panel>


    <!--All Active-->
    <ajaxtoolkit:modalpopupextender ID="ModalAllActive" PopupControlID="PanelAllActive" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelAllActive" runat="server">
                     
                    <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="gvActive" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Users ID" />
                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                        <asp:ButtonField DataTextField="MobileNumber" HeaderText="Mobile Number" />

                                        <asp:ButtonField DataTextField="IsActive" HeaderText="Active" />
                                        
                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkViewReset" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkViewReset_Click">Reset Password</asp:LinkButton>
                                                           </ItemTemplate>
                                                        </asp:TemplateField>
                                        
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkView_Click">View</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <asp:Button ID="btnCloseAllActive" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseAllActive_Click" />
                            </div>
                        </div>
        </asp:Panel>

     <!--All Deactive-->
    <ajaxtoolkit:modalpopupextender ID="ModalAllDeactive" PopupControlID="PanelAllDeactive" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelAllDeactive" runat="server">
                    <div class="card shadow mb-4">
                            <div class="card-body p-0">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="gvAllDeactive" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Users ID" />
                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                        <asp:ButtonField DataTextField="MobileNumber" HeaderText="Mobile Number" />

                                        <asp:ButtonField DataTextField="IsActive" HeaderText="Active" />
                                        
                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkViewReset" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkViewReset_Click">Reset Password</asp:LinkButton>
                                                           </ItemTemplate>
                                                        </asp:TemplateField>
                                        
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkView_Click">View</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <asp:Button ID="btnCloseAllDeactive" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseAllDeactive_Click" />
                            </div>
                        </div>
           </asp:Panel>


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
                            
             <asp:UpdatePanel ID="Panel1" runat="server"><ContentTemplate>
    <div>
               <asp:HiddenField ID="hfId" runat="server" />
                <asp:HiddenField ID="hfPass" runat="server" />
               <table >
                   
                   <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                   <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="Email:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtEmail" ReadOnly="true" CssClass="form-control form-control-user col-12" placeholder="Email" runat="server"></asp:TextBox>
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
                    <tr>
                       <td>
                           <asp:Label runat="server" Text="MobileNumber:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtMobile" CssClass="form-control form-control-user" placeholder="MobileNumber" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                  
               </table>
         <asp:Button ID="btnSave" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Save" OnClick="btnSave_Click" />
         <asp:Button ID="btnDelete" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Deactivate" OnClick="btnDelete_Click" />
        <asp:Button ID="btnActivate" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Activate" Onclick="btnActivate_Click" />
         <!--<asp:Button ID="btnClear" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Clear" OnClick="btnClear_Click" />-->
         
    </div>
                 </ContentTemplate></asp:UpdatePanel>     
                   
                         </div>
                    </div>
                </div>
         <asp:Button ID="Close" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseView_Click" />
            </div>
       </div> 
  </div>
               
</asp:Panel>


    <!-- Reset Password -->
    <ajaxtoolkit:modalpopupextender ID="ModalResetPass" PopupControlID="PanelResetPass" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelResetPass" runat="server">
           <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                        <div class="row">
                    
                            <div class="col-lg-10">
                                 <div class="p-5">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                         <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Reset Password Account!</h1>
                                        </div>
                                     <div>
                                          <asp:HiddenField ID="hfIdReset" runat="server" />
                                         <asp:HiddenField ID="hfEmailReset" runat="server" />
                                         <asp:HiddenField ID="hfPassReset" runat="server" />
                                         <asp:HiddenField ID="hfFnameReset" runat="server" />
                                         <asp:HiddenField ID="hfLnameReset" runat="server" />
                                         <asp:HiddenField ID="hfMobileReset" runat="server" />

                <table>
                     <asp:Label ID="lblErrorReset" runat="server" Text="" ForeColor="Red"></asp:Label>
                   <asp:Label ID="lblSuccessReset" runat="server" Text="" ForeColor="Green"></asp:Label>
                    <tr>
                       
                       <td>
                           <asp:Label runat="server" Text="Email:"></asp:Label>&nbsp &nbsp
                           <asp:TextBox ID="txtEmailReset" ReadOnly="true" CssClass="form-control form-control-user col-12" placeholder="Email" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtPassReset" TextMode="Password" CssClass="form-control form-control-user col-12" placeholder="Current Password" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtNewPassReset" TextMode="Password" CssClass="form-control form-control-user col-12" placeholder="New Password" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                    <tr>
                       <td>
                           <asp:TextBox ID="txtConfirmReset" TextMode="Password" CssClass="form-control form-control-user col-12" placeholder="Confirm Password" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                  </table>
                        <asp:Button ID="btnSaveReset" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Save" OnClick="btnSaveReset_Click" />
                        </div>
                            </ContentTemplate></asp:UpdatePanel> 
                      </div>
                     </div>
                    </div>
                        <asp:Button ID="btnCloseReset" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseReset_Click" />
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
                                <asp:GridView runat="server" ID="gvList1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Users ID" />
                                        <asp:ButtonField DataTextField="Username" HeaderText="Username" />
                                        <asp:ButtonField DataTextField="FirstName" HeaderText="First Name" />
                                        <asp:ButtonField DataTextField="LastName" HeaderText="Last Name" />
                                        <asp:ButtonField DataTextField="MobileNumber" HeaderText="Mobile Number" />

                                        <asp:ButtonField DataTextField="IsActive" HeaderText="Active" />
                                        
                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkViewReset" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkViewReset_Click">Reset Password</asp:LinkButton>
                                                           </ItemTemplate>
                                                        </asp:TemplateField>
                                        
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkView_Click">View</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
                        </div>

   
</asp:Content>