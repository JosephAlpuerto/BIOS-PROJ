<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="SSPRequestList.aspx.cs" Inherits="BIOSproject.SSPRequestList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="js/SA.js"></script>

   <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
   <script>
       function submitForm() {
           swal({
               title: "Are you sure?",
               text: "you want to reject this request!",
               icon: "success",
           })
               .then(function (isOkay) {
                   if (isOkay) {
                       form.submit();
                   }
               });
           return false;
       }
   </script>


     <div id="wrapper">
                    <div class="container-fluid">
                   <%-- <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>   
                        <asp:Button Text="HitCheck Series" ID="btnValidateSeries" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnValidateSeries_Click" runat="server"></asp:Button>--%>
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
                            <%--</div>--%>
                        </div>
                     </div>


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
                                $("#errmsg1").html("Numbers Only").show().fadeOut("slow");
                                return false;
                            }
                        });
                    });
                </script>
                        <style>
                            #errmsg1 {
                                color: red;
                            }
                        </style>
            

                <div class="container">
                        <div class="card o-hidden border-0 shadow-lg my-2">
                                <div class="card-body p-0">
                            <div id="headerDiv" class="modal-header" >
                                <h5 class="modal-title" id="">HitCheck PO Number</h5>
                                <asp:LinkButton ID="hitCheckClose" runat="server" Text="x" OnClick="hitCheckClose_Click"/>

                            </div>

        <div class="row">
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:Label ID="hitcheckerror" ForeColor="Red" runat="server" Text=""></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                
                                <div class="form3">
               <div class="input_field1">

                    <asp:Label ID="Label4" runat="server" Text="Enter PO Number" CssClass="label"></asp:Label>
                    <span id="errmsg1"></span>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="input1" AccessKey="1" ClientIDMode="Static"></asp:TextBox>
                </div>
                   
                  <div class="input_field1">
          
                    <asp:Label ID="Label2" runat="server" Text="PONumber" CssClass="label"></asp:Label>
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
                            </asp:Panel>--%>




     <ajaxtoolkit:modalpopupextender ID="ModalValidateSeries" PopupControlID="PanelValidateSeries" TargetControlID="gvModal" PopupDragHandleControlID="headerDivSeries" runat="server"></ajaxtoolkit:modalpopupextender>
        <asp:Panel ID="PanelValidateSeries"  runat="server">
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
                                
                                <div class="form3">
               <div class="input_field1">
                    <asp:HiddenField ID="hfId1" runat="server" />
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Enter Series Number" CssClass="label"></asp:Label>
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




      <ajaxtoolkit:modalpopupextender ID="ModalView" PopupControlID="PanelView" TargetControlID="gvModal" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelView" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
          
            

                       
                             
        <div class="card o-hidden border-0 shadow-lg my-2">
            <div class="card-body p-0">
               
                

                 <div class="container4">

                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>--%>
                             <div class="form3">
                            
                  

                
                
                  

                                    
        </div>

                           <%--</ContentTemplate></asp:UpdatePanel>--%> 
        </div>
   </div>
</div>
            </div>
       </div> 
  </div>
              
           </asp:Panel>


     <ajaxtoolkit:modalpopupextender ID="ModalViewSeries" PopupControlID="PanelViewSeries" TargetControlID="gvModal" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelViewSeries" runat="server" TabIndex="1" CssClass="Modal" Height="100%">
            <div id="Div1" runat="server" style="max-height: 500px; overflow: auto;">
 <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
            <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
            <script src="js/jquery.js"></script>
            <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
                
            <script>
                $(document).ready(function () {
                    $("#txtQuantityView").keypress(function (e) {
                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            $("#errmsg5").html("Numbers Only").show().fadeOut("slow");
                            return false;
                        }
                    });
                });
            </script>
                        <style>
                            #errmsg5 {
                                color: red;
                            }
                        </style>

           <script>
               $(document).ready(function () {
                   $('#txtProductView').bind('keyup blur', function () {
                       var node = $(this);
                       node.val(node.val().replace(/[^a-z]/g, ''));
                   }
                   );
               });
           </script>

               <script type="text/javascript">
                   function changeState() {
                       var val = document.getElementById('txtForHitCheck').value;
                       if (val.text == 'True') {
                           document.getElementById('btnSend').disabled = '';
                       }
                       else {
                           document.getElementById('btnSend').disabled = 'disabled';
                       }
                   }
               </script>

           
               <div class="container2">
           
                    <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel"></h5>
                                
                                    <asp:LinkButton ID="btnCloseViewSeries" runat="server" Text="x" OnClick="btnCloseView_Click1"/>
                               
                            </div>
                    <%--<div id="header1" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Scanning of Finished Goods</h5>
                                
                            </div>--%>
                              <asp:HiddenField ID="hfId" runat="server" />
                             <asp:TextBox ID="txtForHitCheck" runat="server" Visible="false"></asp:TextBox>
                             <asp:TextBox ID="txtifSend" runat="server" Visible="false"></asp:TextBox>
                             <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                             <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>

                   <div class="container3"> 
                            <div class="forms1">
                                
                                <div class="input_field1">

                    <asp:Label ID="Label8" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTicketNoView" Enabled="false" runat="server" CssClass="input1" Width="220px"></asp:TextBox>
                </div>
                                 <div class="input_field1"> 

                    <asp:Label ID="Label2" runat="server" Text="Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtRequestIDView" Enabled="false" runat="server" CssClass="input1" Width="212px"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label9" runat="server" Text="PONumber" CssClass="label"></asp:Label>
                     <asp:TextBox ID="txtPONumberView" Enabled="false" runat="server" CssClass="input1" Width="210px"></asp:TextBox>
                </div>

            <div class="input_field1">
                <asp:Label ID="Label10" runat="server" Text="Starting Series" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtStartingSeriesView" Enabled="false" runat="server" CssClass="input1"  Width="185px"></asp:TextBox>
                </div>

                <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label11" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEndingSeriesView" Enabled="false" runat="server" CssClass="input1" Width="193px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label12" runat="server" Text="Supplier Name" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtSupplierView" Enabled="false" runat="server" CssClass="input1" Width="183px"></asp:TextBox>
                </div>

                 <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label13" runat="server" Text="Product Name" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProductView" runat="server" Enabled="false" CssClass="input1" TextMode="MultiLine" AccessKey="4" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label14" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <span id="errmsg5"></span>
                    <asp:TextBox ID="txtQuantityView" runat="server" Enabled="false" CssClass="input1" AccessKey="5" ClientIDMode="Static"></asp:TextBox>
                </div>
                 <div class="input_field1">
                    <%--<asp:Button ID="btnUpdateView" runat="server" Text="Update" CssClass="btn btn-primary btn-user btn-block" OnClick="btnUpdateView_Click" />--%>
                <asp:Button ID="btnCancelRequest" runat="server" Text="REJECT REQUEST" CssClass="btn btn-primary btn-user btn-block" OnClick="btnCancelRequest_Click" />
                    <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSend_Click"/>
                 </div> 
             </div>

                <div class="forms">
                    <div class="input_field1">
                        <asp:Label ID="Label1" runat="server" CssClass="label" Text="Series Quantity:"></asp:Label>
                        <asp:Label ID="lblseries" runat="server" CssClass="label" ForeColor="Blue"></asp:Label>
                    </div>
                    <div class="input_field1">
                        <asp:TextBox ID="txtSeries" runat="server" CssClass="input1" Enabled="false" TextMode="MultiLine"></asp:TextBox>

                    </div>
                    <div class="input_field1">
                        <asp:Button ID="DownloadSeries" runat="server" Enabled="false" Text="Download" OnClick="DownloadView_Click" CssClass="btn btn-primary btn-user btn-block"/>
                    </div>
              </div>
</div>
            
                   </div>
               </div>
        </asp:Panel>











    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">New Request</h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered" width="100%" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" EmptyDataText="No Records !" OnSelectedIndexChanged="Gridview1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="Supplier Name" />
                                       <%-- <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product & Quantity" />
                                        <asp:ButtonField DataTextField="TotalQuantity" HeaderText="Total Quantity" />--%>
                                                    

                                                        <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:LinkButton ID="HitCheck" runat="server" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries")%>' Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>' OnClick="HitCheck_Click">HitCheck</asp:LinkButton>
                                                               <asp:Button runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button runat="server" Text="HitCheck" Enabled="false"  Visible='<%# Eval("StartingSeries") == DBNull.Value %>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField>
                                                           <ItemTemplate>

                                                               <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("ifSend").ToString() == "False"%>' OnClick="btnView_Click"/>
                                                                <asp:Button ID="Button1" runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("ifSend").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>       
                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
                     </div>




    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">OnProcess</h6>
                            <asp:Image runat="server" ImageUrl="~/img/greenBox.png" Width="15px" Height="15px"/>
                            <asp:Label runat="server" Text="DONE 'Request Sent'"></asp:Label>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:GridView runat="server" ID="Gridview2" CssClass="table table-bordered" ShowHeaderWhenEmpty="true" width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="Gridview1_SelectedIndexChanged" OnRowDataBound="Gridview2_RowDataBound1">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Supplier" HeaderText="Supplier Name" />
                                       <%-- <asp:ButtonField DataTextField="ProductQuantity" HeaderText="Product & Quantity" />
                                        <asp:ButtonField DataTextField="TotalQuantity" HeaderText="Total Quantity" />--%>
                                                        <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:Label ID="WHcheck" runat="server" Text='<%# Eval("WHcheck") %>' Visible="false"></asp:Label>
                                                               <asp:Label ID="ifSend" runat="server" Text='<%# Eval("ifSend") %>' Visible="false"></asp:Label>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                        <asp:TemplateField>
                                                           <ItemTemplate> 
                                                               <asp:Button runat="server" Text="DONE" Enabled="false"  Visible='<%# Eval("forHitCheck").ToString() == "True"%>' CssClass="btn btn-user btn-block" />
                                                               <asp:Button runat="server" Text="HitCheck" Enabled="false"  Visible='<%# Eval("StartingSeries") == DBNull.Value %>' CssClass="btn btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField>
                                                           <ItemTemplate>

                                                               <asp:LinkButton ID="btnView" runat="server" Text="View" CssClass="btn btn-primary btn-user btn-block" CommandArgument='<%# Eval("Id") %>'  OnClick="btnView_Click"/>
                                                               <%-- <asp:Button ID="Button1" runat="server" Text=" " Enabled="false"  Visible='<%# Eval("ifSend").ToString() == "True"%>' CssClass="btn btn-user btn-block" />--%>
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
