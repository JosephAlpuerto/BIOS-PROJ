﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="AllSupplierRequest.aspx.cs" Inherits="BIOSproject.AllSupplierRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="wrapper">
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                        <asp:Button Text="HitCheck" ID="btnValidate" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnValidate_Click"  runat="server"></asp:Button>
                        
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
                            </div>
                        </div>
                     </div>




     <ajaxtoolkit:modalpopupextender ID="ModalValidate" PopupControlID="PanelValidate" TargetControlID="gvModal"  PopupDragHandleControlID="headerDiv" runat="server"></ajaxtoolkit:modalpopupextender>
        <asp:Panel ID="PanelValidate"  runat="server">
           <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
            <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
            <script src="js/jquery.js"></script>
            <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
                <script>
                    $(document).ready(function () {
                        $("#TxtSearch").keypress(function (e) {
                            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                                $("#errmsg").html("Numbers Only").show().fadeOut("slow");
                                return false;
                            }
                        });
                    });
                </script>
                        <style>
                            #errmsg {
                                color: red;
                            }
                        </style>
           
                <div class="container">
                        <div class="card o-hidden border-0 shadow-lg my-2">
                                <div class="card-body p-0">
                            <div id="headerDiv" class="modal-header" >
                                <h5 class="modal-title" id="">HitCheck</h5>
                                <%--<button id="btnClose" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>--%>
                                <asp:LinkButton ID="hitCheckClose" runat="server" Text="x" OnClick="hitCheckClose_Click"/>

                            </div>

        <div class="row">
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <div class="form3">
               <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label7" runat="server" Text="Enter PO Number" CssClass="label"></asp:Label>
                   <span id="errmsg"></span>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1" AccessKey="1" ClientIDMode="Static"></asp:TextBox>
                </div>
                   
                  <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label8" runat="server" Text="PONumber" CssClass="label"></asp:Label>
                     <asp:TextBox ID="TxtPONo" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>           
                                

                
                

                <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Validate" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click" />
        </div>           
        </div>         
                                     </ContentTemplate></asp:UpdatePanel> 
        </div>
                              </div>
                    </div>
                </div>
                       </div>
                        </div>
                            </div>
                            </asp:Panel>





    <ajaxtoolkit:modalpopupextender ID="ModalRequest" PopupControlID="PanelRequest" TargetControlID="gvModal" CancelControlID="btnClose"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelRequest" runat="server">
          
           <div class="container">

               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_Ref %>" SelectCommand="SELECT [AreaDescr] FROM [Areas]"></asp:SqlDataSource>
                    <div class="modal-header" >
                                <h5 class="modal-title" id="">
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_Ref %>" SelectCommand="SELECT [BranchCode] + ' - ' + [BranchDescr] as BranchCodeDesc FROM [ref_Branches]"></asp:SqlDataSource>
                                    Barcode Issuer</h5>
                                <button id="btnClose" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>

                            <div class="forms">
                                
                                <asp:HiddenField ID="hfId" runat="server" />
                                <asp:Label Text="" ID="lblSuccess" ForeColor="Green" Font-Bold="true" runat="server" />
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtRequestID" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Tracking No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTicket" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                 <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="PO No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtPO" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Schedule Date" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Area</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1" DataSourceID="SqlDataSource1" DataTextField="AreaDescr" DataValueField="AreaDescr">
                       
                    </asp:DropDownList>
                </div>
                <%--<div class="input_field1">
                    
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>--%>

            <div class="input_field1">
                    <%--<label>Branch</label>--%>
                <asp:Label ID="Label1" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1" DataSourceID="SqlDataSource2" DataTextField="BranchCodeDesc" DataValueField="BranchCodeDesc">
                    </asp:DropDownList>
                </div>

                

                <%--<div class="input_field1">
                    
                    <asp:Label ID="Label6" runat="server" Text="Starting Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>

                <%--<div class="input_field1">
                   
                    <asp:Label ID="Label7" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>
               <%-- <div class="input_field1">
                   
                    <asp:Label ID="Label8" runat="server" Text="Particulars" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1"></asp:DropDownList>
                </div>--%>
                

                <div class="input_field1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" />
        </div>  
                                 

        </div>
                                    

        </div>
        </asp:Panel>







    <ajaxtoolkit:modalpopupextender ID="ModalViewReject" PopupControlID="PanelViewReject" TargetControlID="gvModal" CancelControlID="btnClose"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelViewReject" runat="server">
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
               <asp:HiddenField ID="hfId1" runat="server" />   
               <asp:HiddenField ID="hfSupplier1" runat="server" />   
               <asp:HiddenField ID="hfQuantity1" runat="server" />   
               <asp:HiddenField ID="hfStart1" runat="server" />   
               <asp:HiddenField ID="hfEnd1" runat="server" />   
               <table >
                   
                   <asp:Label ID="lblSuccess1" runat="server" Text="" ForeColor="Green"></asp:Label>
                   

                   <asp:Label runat="server" ForeColor="Red" Text="Are you sure you want to Reject this Request!?"></asp:Label>
                   <tr>
                      <td>
                           <asp:Label CssClass="col-10" runat="server" Text="RequestID:"></asp:Label>
                       </td>
                       
                       <td>
                           <asp:TextBox ID="txtRequestID1" CssClass="form-control form-control-user col-12" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Ticket No:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtTicketNo1" CssClass="form-control form-control-user" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="PO No:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtPONo1" CssClass="form-control form-control-user" ReadOnly="true" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                  

                  
               </table>
         <asp:Button ID="btnReject" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm " runat="server" Text="Reject" OnClick="btnReject_Click" />
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
                            <h6 class="m-0 font-weight-bold text-primary">DataTables </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server"/>
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False" DataKeyNames="DownloadFile">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="Supplier" />
                                        <asp:ButtonField DataTextField="Product" HeaderText="Product" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Quantity" />
                                         <asp:ButtonField DataTextField="IsActive" HeaderText="Status" />
                                         <%--<asp:TemplateField>
                                                           <ItemTemplate>

                                                               
                                                               <asp:LinkButton ID="ViewResetAdmin" runat="server" CommandArgument='<%# Eval("Id") %>'>View</asp:LinkButton>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                                       <asp:TemplateField >
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="Destination"  CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("IsActive").ToString() == "False"%>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnRequest_Click"/>
                                                               <asp:Button ID="Button1" runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                        <asp:TemplateField >
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnViewReject" runat="server" Text="Reject" CssClass="btn btn-primary btn-user btn-block"  CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("IsRejected").ToString() == "False"%>' OnClick="btnViewReject_Click"/>
                                                               
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField >
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkButton1" runat="server" Text="Download" Visible='<%# Eval("StartingSeries") != DBNull.Value %>' OnClick="LinkButton1_Click" CssClass="btn btn-primary btn-user btn-block"></asp:LinkButton>
                                                               <asp:Button ID="LinkButton2" runat="server" Text="Download" Enabled="false" Visible='<%# Eval("StartingSeries") == DBNull.Value %>' CssClass="btn btn-primary btn-user btn-block"></asp:Button>
                                                              <%-- <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-primary btn-user btn-block" OnClick="btnDownload_Click" />--%>
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