<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="AllSupplierRequest.aspx.cs" Inherits="BIOSproject.AllSupplierRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="wrapper">
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <%--<h1 class="h3 mb-0 text-gray-800">Requested list</h1>--%>
                        <asp:Button Text="Hitcheck" ID="AllHitcheck" Visible="false" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" OnClick="AllHitcheck_Click"></asp:Button>
                        <%--<asp:Button Text="HitCheck Series" ID="btnValidateSeries" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnValidateSeries_Click" runat="server"></asp:Button>--%>
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            </div>
                        </div>
                     </div>

    <ajaxtoolkit:modalpopupextender ID="ModalValidateSeries" PopupControlID="PanelValidateSeries" TargetControlID="gvModal"  PopupDragHandleControlID="headerDivSeries" runat="server"></ajaxtoolkit:modalpopupextender>
        <asp:Panel ID="PanelValidateSeries" runat="server">
            <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
            <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
            <script src="js/jquery.js"></script>
            <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
                <script>
                    $(document).ready(function () {
                        $("#TxtSearchSeries").keypress(function (e) {
                            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                                $("#errmsgSeries").html("Numbers Only").show().fadeOut("slow");
                                return false;
                            }
                        });
                    });
                </script>
                        <style>
                            #errmsgSeries {
                                color: red;
                            }
                        </style>

             <div class="container">
                        <div class="card o-hidden border-0 shadow-lg my-2">
                                <div class="card-body p-0">
                            <div id="headerDivSeries" class="modal-header" >
                                <h5 class="modal-title" id="">HitCheck Series Number</h5>
                                <%--<button id="btnClose" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>--%>
                                <asp:LinkButton ID="hitCheckCloseSeries" runat="server" Text="x" OnClick="hitCheckCloseSeries_Click"/>

                            </div>

        <div class="row">
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:Label ID="hitcheckerrorSeries" ForeColor="Red" runat="server" Text=""></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                
                                <div class="forms">
               <div class="input_field1">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label9" runat="server" Text="Enter Series Number" CssClass="label"></asp:Label>
                    <span id="errmsgSeries"></span>
                    <asp:TextBox ID="TxtSearchSeries" runat="server" CssClass="input1" AccessKey="2" ClientIDMode="Static"></asp:TextBox>

                   <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered dataTable2"  AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="This Series Sequence is already use!">
                    <Columns>
                       <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                         <asp:TemplateField>
                          <ItemTemplate>
                                <asp:LinkButton runat="server" Text="OnProcess!" ForeColor="Red" Enabled="false" Visible='<%# Eval("IsActive").ToString() == "False"%>' CssClass="btn btn-user btn-block" />
                                <asp:Button runat="server" Text="Done" Enabled="false" Visible='<%# Eval("IsActive").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                          </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                   </asp:GridView>
                </div>

                   
                  <%--<div class="input_field1">
                    <asp:Label ID="Label5" runat="server" Text="StartingSeries" CssClass="label"></asp:Label>
                     <asp:TextBox ID="TxtStart" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>     
                 <div class="input_field1">
                    <asp:Label ID="Label1" runat="server" Text="EndingSeries" CssClass="label"></asp:Label>
                     <asp:TextBox ID="TxtEnd" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>
               <%-- <div class="input_field1">
                    <asp:Label ID="Label6" runat="server" Text="PONumber" CssClass="label"></asp:Label>
                     <asp:TextBox ID="TxtPONoSeries" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>  

                    
                                

                
                

                <div class="input_field1">
                    <asp:Button ID="Button2" runat="server" Text="Validate" CssClass="btn btn-primary btn-user btn-block" OnClick="Button2_Click" />
        </div>           
        </div>         
                                     </ContentTemplate></asp:UpdatePanel> 
        </div>
                              </div>
                    </div>
                </div>
                       </div>
                        </div>
                            

        </asp:Panel>


   <%--  <ajaxtoolkit:modalpopupextender ID="ModalValidate" PopupControlID="PanelValidate" TargetControlID="gvModal"  PopupDragHandleControlID="headerDiv" runat="server"></ajaxtoolkit:modalpopupextender>
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
                               
                                <asp:LinkButton ID="hitCheckClose" runat="server" Text="x" OnClick="hitCheckClose_Click"/>

                            </div>

        <div class="row">
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <div class="form3">
               <div class="input_field1">
                   
                    <asp:Label ID="Label7" runat="server" Text="Enter PO Number" CssClass="label"></asp:Label>
                   <span id="errmsg"></span>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1" AccessKey="1" ClientIDMode="Static"></asp:TextBox>
                </div>
                   
                  <div class="input_field1">
                   
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
                            </asp:Panel>--%>





    <ajaxtoolkit:modalpopupextender ID="ModalRequest" PopupControlID="PanelRequest" TargetControlID="gvModal" CancelControlID="btnClose"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelRequest" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
 
           <div id="Div1" runat="server" style="max-height: 500px; overflow: auto;">
          
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
                                <asp:HiddenField ID="Product" runat="server" />
                                <asp:HiddenField ID="Quantity" runat="server" />

                                <asp:Label Text="" ID="lblSuccess" ForeColor="Green" Font-Bold="true" runat="server" />
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtRequestID" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Tracking No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTicket" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                 <div class="input_field1">
                    <asp:Label ID="Label2" runat="server" Text="PO No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtPO" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label7" runat="server" Text="StartingSeries" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStart" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label8" runat="server" Text="EndingSeries" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEnd" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Schedule Date" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <%--<div class="input_field1">
                    
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>--%>

            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <div id="Destination" class="input_field1">
                <asp:Label ID="Label11" runat="server" Text="Destination To:" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDesti" runat="server" CssClass="input1" AutoPostBack="true"  OnSelectedIndexChanged="DropDesti_SelectedIndexChanged">
                        <asp:ListItem>~Select~</asp:ListItem>
                        <asp:ListItem Value="B">Branches</asp:ListItem>
                        <asp:ListItem Value="H">Hub</asp:ListItem>
                        <asp:ListItem Value="W">Warehouse</asp:ListItem>
                    </asp:DropDownList>
                </div>
               
              <div class="input_field1">
                <asp:Label ID="lblBranch" runat="server" Visible="false" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" Visible="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropBranch_SelectedIndexChanged" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                        </asp:DropDownList>
                </div>

                <div class="input_field1">
                <asp:Label ID="lblTeam" runat="server" Visible="false" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" Visible="false" runat="server" AutoPostBack="true" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="lblArea" runat="server" Visible="false" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" Visible="false" runat="server" AutoPostBack="true" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>

               <%--IF HUB--%>
               <%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Hub] FROM [Reference] where [Hub] != 'NULL'"></asp:SqlDataSource>--%>
                 <div class="input_field1">
                    <asp:Label ID="lblHub" runat="server" Visible="false" Text="HUB" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropHub" Visible="False" runat="server" CssClass="input1">
                       <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <%--IF WAREHOUSE--%>
               <%-- <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [WareHouse] FROM [Reference] WHERE [WareHouse] != 'NULL'"></asp:SqlDataSource>--%>
                 <div class="input_field1">
                    <asp:Label ID="lblWare" runat="server" Visible="false" Text="WAREHOUSE" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropWare" Visible="False" runat="server" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                </ContentTemplate></asp:UpdatePanel> 
                <div class="input_field1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" />
                </div>  
                                 

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
               <asp:HiddenField ID="hfSourcing1" runat="server" />   
               <asp:HiddenField ID="hfProduct1" runat="server" />   
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

                   <tr>
                       <td>
                           <asp:Label runat="server" Text="Reason:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtReason" CssClass="form-control form-control-user" runat="server" Height="70px" Rows="20" TextMode="MultiLine"></asp:TextBox>
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



    <ajaxtoolkit:modalpopupextender ID="ModalDownloadView" PopupControlID="PanelDownloadView" TargetControlID="gvModal"  runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelDownloadView" runat="server">
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-2">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="p-5">
    <div>
                
               <table >
                   
                   <asp:Label ID="Label10" runat="server" Text="" ForeColor="Green"></asp:Label>
                   

                   <asp:Label runat="server" ForeColor="Red" Text="Are you sure you want to Download this Request!?"></asp:Label>
                   
                   <tr>
                       <td>
                           <asp:Label runat="server" Text="ID:"></asp:Label>
                       </td>
                       
                       <td colspan="2">
                           <asp:TextBox ID="txtId" CssClass="form-control form-control-user" Enabled="false" runat="server"></asp:TextBox>
                       </td>
                   </tr>
                   <asp:HiddenField ID="hfTicketNo" runat="server" />   
                   <asp:HiddenField ID="hfPONumber" runat="server" />   
                   <asp:HiddenField ID="hfStartingSeries" runat="server" />   
                   <asp:HiddenField ID="hfEndingSeries" runat="server" />   
                   <asp:HiddenField ID="hfSupplier" runat="server" />  
                   <asp:HiddenField ID="hfProduct" runat="server" />  
                   <asp:HiddenField ID="hfQuantity" runat="server" />  

               </table>
         <asp:LinkButton ID="Download" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Download Now" OnClick="Download_Click1"/>
         <asp:Button ID="btnCloseDownloadView" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="btnCloseDownloadView_Click"/>
    </div>
                            </div>
                          </div>
                        </div>
               
                      </div>
                    </div>
                  </div>
           </asp:Panel>


     <ajaxtoolkit:modalpopupextender ID="ModalScanSupplier" PopupControlID="PanelScanSupplier" TargetControlID="gvModal" PopupDragHandleControlID="header" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelScanSupplier" runat="server" CssClass="Modal" Height="500px">
 
           <div id="Div2" runat="server" style="max-height: 500px; overflow: auto;">
          
           <div class="container2"> 
               <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <div id="header" class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel"></h5>
                        <asp:LinkButton runat="server" id="btnCloseScanSupplier" Text="x" OnClick="btnCloseScanSupplier_Click" class="close" type="button" data-dismiss="modal" aria-label="Close"/>
                        

                    </div>
               <div class="container3">
    
                            <div class="forms">
                                <asp:HiddenField ID="hfStart" runat="server" />
                                <asp:HiddenField ID="hfEnd" runat="server" />
                                <asp:HiddenField ID="hfIdScan" runat="server" />
                                <asp:HiddenField ID="hfIdHIT" runat="server" />
                <div class="input_field1">
                    <asp:Label ID="Label1" runat="server" Text="Request No:" CssClass="label"></asp:Label>
                    <asp:Label ID="lblID" runat="server" CssClass="label" ForeColor="Blue"></asp:Label>
                </div>
                <div class="input_field1">
                    <asp:Label ID="Label17" runat="server" Text="StartingSeries:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStartScan" runat="server" Enabled="false" CssClass="input1" AutoPostBack="true"  Width="315px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="LabelEnd" runat="server" Text="EndingSeries:" CssClass="labelend"></asp:Label>
                    <asp:TextBox ID="txtEndScan" runat="server" CssClass="input1" Enabled="false" AutoPostBack="true" Width="315px"></asp:TextBox>
                </div>
            <div class="input_field1">
                    <asp:Label ID="Label19" runat="server" Text="No. Of Units:" CssClass="label"></asp:Label>
                    <asp:Label ID="lblUnits" runat="server" CssClass="input1" ForeColor="Red"></asp:Label>
                </div>
                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label20" runat="server" Text="Product:" CssClass="label"></asp:Label>
                     <asp:TextBox ID="txtProduct" runat="server"  Enabled="false" CssClass="input1" Width="315px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Button ID="btnCheck" runat="server" Text="CHECK" CssClass="btn btn-primary btn-user btn-block" OnClick="btnCheck_Click"/>
                </div>
                                </div>

               <div class="formsSeries">
                    <%--<div class="input_field1">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Series Quantity:"></asp:Label>
                        <asp:Label ID="lblseries" runat="server" CssClass="label" ForeColor="Red"></asp:Label>
                    </div>--%>
                    <div class="input_field1">
                        <asp:TextBox ID="txtSeries" runat="server" CssClass="input1" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <%--<div class="input_field1">
                        <asp:Button ID="btnScan" Text="SCAN" Visible="false" CssClass="btnScan" runat="server" OnClick="btnScan_Click"/>
                    </div>--%>
                  <%--  <div class="input_field1">
                        <asp:HiddenField runat="server" ID="hfisRejected"/>
                        <asp:Button ID="btnPrint" Text="Print" Visible="false" CssClass="btnScan" runat="server" OnClick="btnPrint_Click"/>
                    </div>--%>
                     <div class="input_field1">
                        <asp:Button ID="btnHitcheck" Text="HitCheck" Visible="false" CssClass="btnScan" runat="server" OnClick="btnHitcheck_Click"/>
                    </div>
                     
              </div>
                    </div>
                    
                   </ContentTemplate>
                   <Triggers>
                            <asp:PostBackTrigger ControlID="btnCheck" />
                            <asp:PostBackTrigger ControlID="btnHitcheck" />
                    </Triggers>
               </asp:UpdatePanel>
               
            </div>
               </div>
        </asp:Panel>

    <ajaxtoolkit:modalpopupextender ID="ModalPrint" PopupControlID="PanelPrint" TargetControlID="gvModal" CancelControlID="btnClosePrint" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelPrint" CssClass="Print"  runat="server">
                        
                            <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div class="modal-header" >
                                <h5 class="modal-title" id="">Print Report</h5>
                                <button id="btnClosePrint" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                       
                       <rsweb:ReportViewer ID="RvSeries" runat="server" BackColor="White" CssClass="bg-white" Height="4.21875in" Width="730px">
                           <LocalReport ReportPath="Report/SeriesReport.rdlc">

                            </LocalReport>
                       </rsweb:ReportViewer>
                       </div></div>
                            </asp:Panel>


       <ajaxtoolkit:modalpopupextender ID="ModalScan" PopupControlID="PanelScan" TargetControlID="gvModal" CancelControlID="btnCloseScan" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelScan" runat="server" TabIndex="1" CssClass="Modal">
 
           <div id="Div3" runat="server" style="max-height: 500px; overflow: auto;">
          
           <div class="contain"> 
                    <div id="header1" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Scanning of Finished Goods</h5>
                                <asp:LinkButton runat="server" id="btnCloseScan" Text="x" OnClick="btnCloseScan_Click"/>
<%--                                    <span aria-hidden="true">×</span>
                                </asp:Button>--%>
                            </div>

                                
                                <asp:HiddenField ID="hfIDScan2" runat="server" />
                                <asp:HiddenField ID="ID" runat="server" />
                                <asp:HiddenField ID="TicketNo" runat="server" />
                                <asp:HiddenField ID="PONumber" runat="server" />
                                <asp:HiddenField ID="Supplier" runat="server" />
                                <asp:HiddenField ID="ProductQuantity" runat="server" />
                                <asp:HiddenField ID="TotalQuantity" runat="server" />
                                <asp:HiddenField ID="Quantity2" runat="server" />
                                <asp:HiddenField ID="StartingSeries" runat="server" />
                                <asp:HiddenField ID="EndingSeries" runat="server" />
                                <asp:HiddenField ID="RequestNo" runat="server" />
                                <asp:HiddenField ID="SupplierName" runat="server" />

                                <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                <div class="input_field1">
                    <asp:Label ID="Label15" runat="server" Text="Enter Starting Series:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStartingScan" runat="server" CssClass="input1" Width="200px" AutoPostBack="true"></asp:TextBox>
                    <asp:HiddenField ID="hfEndingSeries2" runat="server" />
                </div>
                                

            <div class="contain1">
              <div class="forms">
                  <div class="input_field1">
                       <asp:Label ID="lblUnitsScan" runat="server" Text="No. of Units:" CssClass="label" ></asp:Label> 
                       
                   </div>
                  <div class="input_field2">
                      <asp:Label ID="lblScanUnits" runat="server" Text="0" ForeColor="Red" CssClass="label"></asp:Label>
                   </div>
              </div>

              <div class="forms">
                  <div class="input_field1">
                       <asp:Label ID="Label16" runat="server" Text="Total Quantity" CssClass="label" ></asp:Label> 
                       
                   </div>
                  <div class="input_field2">
                      <asp:Label ID="lblTotal" runat="server" Text="0" ForeColor="Green" CssClass="label"></asp:Label>
                   </div>
                  
              </div>
               
            </div>
                  <div class="input_field1">
                     <asp:Button ID="btnOkay" runat="server" Text="SCAN" CssClass="btn" OnClick="btnOkay_Click"/>     
                   </div>
                 
                         </ContentTemplate>
                                     <Triggers>
                            <asp:PostBackTrigger ControlID="btnOkay" />
                                    </Triggers>
                                </asp:UpdatePanel> 
            </div>
               </div>
        </asp:Panel>



       <ajaxtoolkit:modalpopupextender ID="ModalPass" PopupControlID="PanelPass" TargetControlID="gvModal" CancelControlID="btnClosePass" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelPass" runat="server" TabIndex="1" CssClass="ModalPass">
            <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div class="modal-header" >
                                <h5 class="modal-title" id=""></h5>
                                <button id="btnClosePass" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
               <div class="input_field1">
                    <asp:Label ID="Label3" runat="server" Text="Enter Password:" CssClass="label"></asp:Label> 
                    <asp:TextBox ID="txtPass" runat="server" CssClass="input1" Width="200px" AutoPostBack="true" TextMode="Password"></asp:TextBox>
                </div> 
<%--                <div class="input_field1">
                    <asp:Label ID="lblwrong" runat="server" ForeColor="Red" Visible="false" CssClass="label"></asp:Label> 
                </div>--%>
                   <div class="input_field2">
                     <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn" OnClick="btnConfirm_Click"/>     
                   </div>
                                  </ContentTemplate>
                                     <Triggers>
                            <asp:PostBackTrigger ControlID="btnConfirm" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                       </div>             
            </div>
          
        </asp:Panel>
    <ajaxtoolkit:modalpopupextender ID="ModalDL" PopupControlID="PanelDL" TargetControlID="gvModal" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelDL" runat="server" TabIndex="1" CssClass="Modal">
          
           <div class="containDL"> 
                <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                    <div id="header2" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Download</h5>
                        <asp:Button runat="server" ID="btnCloseDL" Text="x" CssClass="btn" OnClick="btnCloseDL_Click"/>
                            </div>
              
                <div class="input_field1">
                    <asp:Label ID="Label12" runat="server" Text="Request Number:" CssClass="label"></asp:Label>
                     <asp:Label ID="lblNumber" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label> 
                </div>
                <div class="input_field1">
                     <asp:Button ID="btnDL" runat="server" Text="Download" CssClass="btn" OnClick="btnDL_Click"/>
                     

                </div>

                             </ContentTemplate>
                                     <Triggers>
                            <asp:PostBackTrigger ControlID="btnDL" />
                            <asp:PostBackTrigger ControlID="btnCloseDL" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                
            </div>
        </asp:Panel>


    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Pending list</h6>
                            <asp:Image runat="server" ImageUrl="~/img/greenBox.png" Width="15px" Height="15px"/>
                            <asp:Label runat="server" Text="DONE 'Already Saved'"></asp:Label>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                
                                <asp:HiddenField ID="hfIDdl" runat="server"/>
                                <asp:HiddenField ID="hfStartdl" runat="server"/>
                                <asp:HiddenField ID="hfEnddl" runat="server"/>

                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !" DataKeyNames="link" OnRowDataBound="Gridview1_RowDataBound">
                                    <Columns>
                                        <%--<asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll_CheckedChanged"/> 
                                                <asp:LinkButton ID="HitCheck2" Visible="false" runat="server" CssClass="btn btn-primary btn-user btn-block" OnClick="HitCheck_Click1">HitCheck</asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>' OnCheckedChanged="Check_CheckedChanged"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:ButtonField DataTextField="ID" HeaderText="Request No." />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product/Quantity" />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />

                                                   <%--    <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:LinkButton ID="HitCheck" runat="server" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries")%>' Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>' OnClick="HitCheck_Click">HitCheck</asp:LinkButton>
                                                               <asp:Button runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button runat="server" Text="HitCheck" Enabled="false"  Visible='<%# Eval("StartingSeries") == DBNull.Value %>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="DownloadView" runat="server" Text="Download" CommandArgument='<%# Eval("Id") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries") + "," + Eval("IsRejected")%>' Visible='<%# Eval("IsRejected").ToString() == "False" %>' OnClick="DownloadView_Click" CssClass="btn btn-primary btn-user btn-block"></asp:Button>
                                                               <asp:Button ID="LinkButton2" runat="server" Text="Download" Enabled="false" Visible='<%# Eval("IsRejected").ToString() == "True" %>' CssClass="btn btn-primary btn-user btn-block"></asp:Button>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:Label ID="ifFinish" runat="server" Text='<%# Eval("ifFinish") %>' Visible="false"></asp:Label>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="ScanSupplier" runat="server" Text="HitCheck" CommandArgument='<%# Eval("Id") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries")%>' Visible='<%# Eval("StartingSeries") != DBNull.Value && Eval("forHitCheck").ToString() == "True" %>' OnClick="ScanSupplier_Click" CssClass="btn btn-primary btn-user btn-block"></asp:LinkButton>
                                                              
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <%--<asp:TemplateField >
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="SEND" Enabled='<%# Eval("StartingSeries") != DBNull.Value %>' Visible='<%# Eval("forHitCheck").ToString() == "True" && Eval("IsActive").ToString() == "False" %>' CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnRequest_Click"/>
                                                               <asp:Button ID="Button1" runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button ID="Button3" runat="server" Text="Destination" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "False"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                                      <%--  <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnViewReject" runat="server" Text="Reject" CssClass="btn btn-primary btn-user btn-block"  CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("IsRejected").ToString() == "False" && Eval("IsActive").ToString() == "False" && Eval("IfDownload").ToString() == "False"%>' OnClick="btnViewReject_Click"/>
                                                               <asp:Button runat="server" Text="Disabled" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True" || Eval("IfDownload").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>

                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="gvModal" runat="server"/>
                                </div>
                            </div>
                     </div>






     <!-- DataTales Example -->
                   <%-- <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary"></h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="HiddenField2" runat="server"/>
                                <asp:GridView runat="server" ID="Gridview2" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !" DataKeyNames="link">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll_CheckedChanged"/>
                                                <asp:LinkButton ID="HitCheck2" Visible="false" runat="server" CssClass="btn btn-primary btn-user btn-block" OnClick="HitCheck_Click1">HitCheck</asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>' OnCheckedChanged="Check_CheckedChanged"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField DataTextField="ID" HeaderText="Request No." />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product/Quantity" />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />

                                                       <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:LinkButton ID="HitCheck" runat="server" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries")%>' Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>' OnClick="HitCheck_Click">HitCheck</asp:LinkButton>
                                                               <asp:Button runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button runat="server" Text="HitCheck" Enabled="false"  Visible='<%# Eval("StartingSeries") == DBNull.Value %>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField >
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="Destination" Enabled='<%# Eval("StartingSeries") != DBNull.Value %>' Visible='<%# Eval("forHitCheck").ToString() == "True" && Eval("IsActive").ToString() == "False" %>' CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnRequest_Click"/>
                                                               <asp:Button ID="Button1" runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button ID="Button3" runat="server" Text="Destination" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "False"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                        <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="btnViewReject" runat="server" Text="Reject" CssClass="btn btn-primary btn-user btn-block"  CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("IsRejected").ToString() == "False" && Eval("IsActive").ToString() == "False" && Eval("IfDownload").ToString() == "False"%>' OnClick="btnViewReject_Click"/>
                                                               <asp:Button runat="server" Text="Disabled" Enabled="false"  Visible='<%# Eval("IsActive").ToString() == "True" || Eval("IfDownload").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField>
                                                           <ItemTemplate>

                                                               <asp:LinkButton ID="DownloadView" runat="server" Text="Download" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("StartingSeries") != DBNull.Value && Eval("forHitCheck").ToString() == "True" %>' OnClick="DownloadView_Click" CssClass="btn btn-primary btn-user btn-block"></asp:LinkButton>
                                                               <asp:Button ID="LinkButton2" runat="server" Text="Download" Enabled="false" Visible='<%# Eval("forHitCheck").ToString() == "False"%>' CssClass="btn btn-primary btn-user btn-block"></asp:Button>
                                                             
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
                     </div>--%>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
