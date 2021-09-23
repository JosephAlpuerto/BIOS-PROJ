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
                        
                        <ajaxtoolkit:modalpopupextender ID="ModalUsers" PopupControlID="PanelUsers" TargetControlID="gvModal" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelUsers" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportUsers" runat="server" Width="750px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
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
                            
             <asp:UpdatePanel ID="Panel1" runat="server"><ContentTemplate>
    <div>
               <asp:HiddenField ID="hfId" runat="server" />
               <table >
                   
                   <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                   <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                           <asp:Label runat="server" CssClass="col-10" Text="Password:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtPass" CssClass="form-control form-control-user col-12" placeholder="Password" runat="server"></asp:TextBox>
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
         <asp:Button ID="btnDelete" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Delete" OnClick="btnDelete_Click" />
         <asp:Button ID="btnClear" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Clear" OnClick="btnClear_Click" />
         
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