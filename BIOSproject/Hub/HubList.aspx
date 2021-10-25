<%@ Page Title="" Language="C#" MasterPageFile="~/Hub/Hub.Master" AutoEventWireup="true" CodeBehind="HubList.aspx.cs" Inherits="BIOSproject.Supplier.SupplierList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
    
    <div id="wrapper">
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                        <%--<asp:Button Text="HitCheck" ID="btnValidate" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnValidate_Click"  runat="server"></asp:Button>--%>
                        <asp:Button Text="HitCheck Series" ID="btnValidateSeries" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnValidateSeries_Click" runat="server"></asp:Button>
                        <asp:Button Text="Print Report" ID="btnDownload" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnDownload_Click" runat="server"></asp:Button>
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
                        <ajaxtoolkit:modalpopupextender ID="ModalReport" PopupControlID="PanelReport" TargetControlID="gvModal" PopupDragHandleControlID="headerReport"  CancelControlID="btnCloseReport" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelReport"  runat="server">
                        
                            <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div id="headerReport" class="modal-header" >
                                <h5 class="modal-title" id="">Print Report</h5>
                                <button id="btnCloseReport" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                       
                        <rsweb:ReportViewer ID="ReportRequest" runat="server" Width="1150px" Height="500px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
                       </div></div>
                            </asp:Panel>
                            </div>
                        </div>
                     </div>

      <ajaxtoolkit:modalpopupextender ID="ModalValidateSeries" PopupControlID="PanelValidateSeries" TargetControlID="gvModal"  PopupDragHandleControlID="headerDivSeries" runat="server"></ajaxtoolkit:modalpopupextender>
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
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label13" runat="server" Text="Enter Series Number" CssClass="label"></asp:Label>
                    <span id="errmsgSeries"></span>
                    <asp:TextBox ID="TxtSearchSeries" runat="server" CssClass="input1" AccessKey="2" ClientIDMode="Static"></asp:TextBox>

                   <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered dataTable2"  AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="This is a Sequence on Series!">
                    <Columns>
                       <asp:ButtonField DataTextField="PONumber" HeaderText="PO No." />
                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
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



 





    
     <ajaxtoolkit:modalpopupextender ID="ModalDestination" PopupControlID="PanelRequest" TargetControlID="gvModal" CancelControlID="btnClose"  runat="server"></ajaxtoolkit:modalpopupextender>
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
                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                <asp:HiddenField ID="hfId" runat="server" />
                                <asp:Label Text="" ID="lblSuccess" ForeColor="Green" Font-Bold="true" runat="server" />
                                <%--<div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <%--<asp:Label ID="Label7" runat="server" Text="Request ID" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtRequestID" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>
                                            
                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label12" runat="server" Text="Ticket No." CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTicket" runat="server" CssClass="input1" TextMode="Number"></asp:TextBox>
                </div>  
                 
               
                 
                                
                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Date" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>
                                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1"></asp:DropDownList>
                   <%-- <asp:TextBox ID="DropBranch" ReadOnly="true" runat="server" CssClass="input1"></asp:TextBox>--%>
                </div>

                 <div class="input_field1">
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1"></asp:DropDownList>
                    
                </div>
            <div class="input_field1">
                    
                    <asp:Label ID="Label4" runat="server" Text="Starting Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStart" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                

                <div class="input_field1">
                    
                    <asp:Label ID="Label6" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                                <div class="input_field1">
                    
                    <asp:Label ID="Label10" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                                <div class="input_field1">
                    
                    <asp:Label ID="Label11" runat="server" Text="Product" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <%--<div class="input_field1">
                   
                    <asp:Label ID="Label7" runat="server" Text="Ending Series" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input1"></asp:TextBox>
                </div>--%>
               <%-- <div class="input_field1">
                   
                    <asp:Label ID="Label8" runat="server" Text="Particulars" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1"></asp:DropDownList>
                </div>--%>
                

                <div class="input_field1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click"/>
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
                                <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Request ID" />
                                         <asp:ButtonField DataTextField="RequestID" HeaderText="Supplier Request ID" />
                                        <asp:ButtonField DataTextField="TicketNo" HeaderText="Ticket No." />
                                         <asp:ButtonField DataTextField="PoNO" HeaderText="PO No." />
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                         <asp:ButtonField DataTextField="ScheduleRequest" HeaderText="Scedule Request" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />
                                        <asp:ButtonField DataTextField="CreatedBy" HeaderText="SupplierName" />
                                        <asp:ButtonField DataTextField="CreatedDate" HeaderText="CreatedDate" />

                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnRequest" runat="server" Text="Destination" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-user btn-block" OnClick="btnRequest_Click"/>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <%-- <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-primary btn-user btn-block" />
                                                           </ItemTemplate>
                                                       </asp:TemplateField>--%>
          
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
