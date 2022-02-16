<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="SupplierTaggingForm.aspx.cs" Inherits="BIOSproject.SupplierTaggingForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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


    <asp:Button ID="btnScan" Text="SCAN" CssClass="btnScan" runat="server" OnClick="btnScan_Click"/>
    <div class="big">
        
        

        <div class="container1">

                            <div class="forms">
                                <asp:HiddenField ID="hfStart" runat="server" />
                                <asp:HiddenField ID="hfEnd" runat="server" />
                                <asp:HiddenField ID="hfId1" runat="server" />
            <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Date:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDate" Enabled="false" runat="server" CssClass="input1" TextMode="Date" ReadOnly="True"  Width="265px"></asp:TextBox>
                </div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <div id="Destination" class="input_field1">
                <asp:Label ID="Label14" runat="server" Text="Destination To:" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDesti" runat="server" CssClass="input1" AutoPostBack="true"  OnSelectedIndexChanged="DropDesti_SelectedIndexChanged">
                        <asp:ListItem Value="S">~Select~</asp:ListItem>
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
                    <asp:Label ID="Label7" runat="server" Text="StartingSeries:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStart" runat="server" CssClass="input1" OnTextChanged="txtStart_TextChanged" AutoPostBack="true"  Width="315px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label8" runat="server" Text="EndingSeries:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="input1" OnTextChanged="txtEnd_TextChanged" AutoPostBack="true" Width="315px"></asp:TextBox>
                </div>
            <div class="input_field1">
                    <asp:Label ID="Label3" runat="server" Text="No. Of Units:" CssClass="label"></asp:Label>
                    <asp:Label ID="lblUnits" runat="server" CssClass="input1" ForeColor="Red"></asp:Label>
                </div>
                 <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Particulars:" CssClass="label"></asp:Label>
                     <asp:DropDownList ID="DropProduct" runat="server" CssClass="input1" Enabled="true" Width="315px">
                     </asp:DropDownList>
                </div>
            <div class="input_field1">
                <asp:Button ID="btnUpdate" Enabled="false" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn" OnClick="btnClear_Click"/>
                </div>
                                </div>
            </div>



         

         <ajaxtoolkit:modalpopupextender ID="ModalInquiry" PopupControlID="PanelInquiry" TargetControlID="gvModal" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelInquiry" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
 
           <div id="Div1" runat="server" style="max-height: 500px; overflow: auto;">
          
           <div class="container2"> 
                    <div id="header" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Series Inquiry</h5>
                                <button id="btnClose" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>

                            <div class="forms">
                                
                                <asp:HiddenField ID="hfId" runat="server" />
                                <asp:HiddenField ID="Product" runat="server" />
                                <asp:HiddenField ID="Quantity" runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                <div class="input_field1">
                    <asp:Label ID="Label2" runat="server" Text="Enter Tracking:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTracking" runat="server" CssClass="input1" Width="330px" AutoPostBack="true" OnTextChanged="txtTracking_TextChanged"></asp:TextBox>
                </div>
                                
                <div class="input_field1">
                    <asp:Label ID="Label4" runat="server" Text="Area:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtArea" Enabled="false" runat="server" CssClass="input1" Width="400px" ></asp:TextBox>
                </div>
                 <div class="input_field1">
                    <asp:Label ID="Label9" runat="server" Text="Team:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTeam" Enabled="false" runat="server" CssClass="input1" Width="395px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label10" runat="server" Text="Branch:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtBranch" Enabled="false" runat="server" CssClass="input1" Width="385px"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label11" runat="server" Text="Date:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtDateTracking" Enabled="false" runat="server" Width="400px" CssClass="input1"></asp:TextBox>
                </div>
               
                <div class="input_field1">
                    <asp:Label ID="Label12" runat="server" Text="Start Series:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStartTracking" Enabled="false" runat="server" Width="350px" CssClass="input1"></asp:TextBox>
                </div>
                                
                <div class="input_field1">
                    <asp:Label ID="Label13" runat="server" Text="End Series:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtEndTracking" Enabled="false" runat="server" Width="360px" CssClass="input1"></asp:TextBox>
                </div>
 </ContentTemplate></asp:UpdatePanel> 
              
                                 

        </div>
            </div>
               </div>
        </asp:Panel>







        <ajaxtoolkit:modalpopupextender ID="ModalScan" PopupControlID="PanelScan" TargetControlID="gvModal" CancelControlID="btnCloseScan" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelScan" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
 
           <div id="Div2" runat="server" style="max-height: 500px; overflow: auto;">
          
           <div class="container2"> 
                    <div id="header1" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Scanning of Finished Goods</h5>
                                <button id="btnCloseScan" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>

                            <div class="forms">
                                
                                <asp:HiddenField ID="hfIdScan" runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                <div class="input_field1">
                    <asp:Label ID="Label15" runat="server" Text="Enter Starting Series:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtStartingScan" runat="server" CssClass="input1" Width="300px" AutoPostBack="true" OnTextChanged="txtStartingScan_TextChanged"></asp:TextBox>
                    <asp:HiddenField ID="hfEndingSeries" runat="server" />
                </div>
                                

            <div class="container3">
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
                 <asp:Button ID="btnOkay" runat="server" Text="Okay" Visible="false" CssClass="btn" OnClick="btnOkay_Click"/>     
 </ContentTemplate></asp:UpdatePanel> 
              
                          
            
        </div>
            </div>
               </div>
        </asp:Panel>









        <div class="container">
            <asp:HiddenField ID="gvModal" runat="server"/>
                            <div class="forms">
                                  
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Date" CssClass="label1"></asp:Label>
                    <asp:TextBox ID="txtDate2" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>

                     <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="btn" OnClick="btnDisplay_Click"/>
                    <asp:DropDownList ID="DropPer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropPer_SelectedIndexChanged">
                        <asp:ListItem Value="B">Branches</asp:ListItem>
                        <asp:ListItem Value="W">Warehouse</asp:ListItem>
                        <asp:ListItem Value="H">Hub</asp:ListItem>
                    </asp:DropDownList>
                     <asp:Button ID="btnInquiry" runat="server" Text="Inquiry" CssClass="btn" OnClick="btnInquiry_Click"/>
                     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn" Width="60px" OnClick="btnPrint_Click"/>

                   <ajaxtoolkit:modalpopupextender ID="ModalPrint" PopupControlID="PanelPrint" TargetControlID="gvModal" CancelControlID="btnClosePrint" runat="server"></ajaxtoolkit:modalpopupextender>
                        <asp:Panel ID="PanelPrint"  runat="server">
                        
                            <div class="card shadow mb-4">

                            <div class="card-body p-0">
                            <div class="modal-header" >
                                <h5 class="modal-title" id="">Print Report</h5>
                                <button id="btnClosePrint" class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                       
                        <rsweb:ReportViewer ID="RvSuppPrint" runat="server" Width="757px" BackColor="White" CssClass="bg-white"></rsweb:ReportViewer>
                       </div></div>
                            </asp:Panel>

                </div>


               

                              
      <asp:GridView runat="server" RowStyle-Width="100px" ID="Gridview1" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" ShowFooter="True" EmptyDataText="No Records !">
          
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true"/>
                                                </HeaderTemplate>
                                           <%-- <ItemTemplate>
                                                 <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>'/>
                                            </ItemTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Start Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                         <asp:ButtonField DataTextField="ScheduleDate" HeaderText="Date" />
                                        <asp:ButtonField DataTextField="DestinationTo" HeaderText="DestinationTo" />
                                        <asp:ButtonField DataTextField="ID" HeaderText="CtrlNo" />


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
