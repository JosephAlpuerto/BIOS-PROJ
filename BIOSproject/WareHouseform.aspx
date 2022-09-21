<%@ Page Title="" Language="C#" MasterPageFile="Warehouse.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="WareHouseform.aspx.cs" Inherits="BIOSproject.WareHouseform" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
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
     <style type="text/css">
        .autoCompleteList
		{
			background-color: White !important;
            color: black !important;
			z-index: 12000 !important;
		}
		.autoCompleteListItem
		{
			background-color: White !important;
            color: black !important;
			z-index: 12000 !important;
		}
		.autoCompleteSelectedListItem
		{
			background-color: White !important;
            color: blue !important;
			z-index: 12000 !important;
		}
        .gvTempCss{
            margin-top: 30px !important;
            background-color: #dcdbdb !important;
            color: black !important;
        }
    </style>
>
 
    <div class="big">
        
        <div class="container1">

                            <div class="forms">
                                <asp:HiddenField ID="hfWareEmail" runat="server" />

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
                        <asp:ListItem Value="B">Branch</asp:ListItem>
                        <asp:ListItem Value="H">Hub</asp:ListItem>
                       <%-- <asp:ListItem Value="W">Warehouse</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>

                 <div class="input_field1">
                <asp:Label ID="lblBranch" runat="server" Visible="false" Text="Branch:" CssClass="label"></asp:Label>
               <asp:TextBox ID="DropBranch" Visible="false" AutoPostBack="true" OnTextChanged="DropBranch_TextChanged" runat="server" CssClass="input1" Width="250px"></asp:TextBox>  
               <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" 
                   MinimumPrefixLength="1"   
                   CompletionInterval="10" 
                   EnableCaching="false" 
                   CompletionSetCount="1" 
                   TargetControlID="DropBranch"    
                    ID="AutoCompleteExtender1" 
                   runat="server" 
                   FirstRowSelected="false">    
                </asp:AutoCompleteExtender>
                   <%-- <asp:DropDownList ID="DropBranch" Visible="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropBranch_SelectedIndexChanged" CssClass="input1" Width="250px">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                        </asp:DropDownList>--%>
                </div>

                <div class="input_field1">
                <asp:Label ID="lblTeam" runat="server" Visible="false" Text="Team:" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" Visible="false" runat="server" AutoPostBack="true" CssClass="input1"  Width="261px">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="lblArea" runat="server" Visible="false" Text="Area:" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" Visible="false" runat="server" AutoPostBack="true" CssClass="input1"  Width="265px">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <asp:Label ID="lblHub" runat="server" Visible="false" Text="HUB" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropHub" Visible="False" runat="server" CssClass="input1">
                       <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="input_field1">
                    <asp:Label ID="lblWare" runat="server" Visible="false" Text="WAREHOUSE" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropWare" Visible="False" runat="server" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                                     </ContentTemplate></asp:UpdatePanel> 

                <div class="input_field1">
                    <asp:Label ID="LabelSeries" runat="server" Text="Enter Series:" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtSeries" runat="server" CssClass="input1" AutoPostBack="true"  Width="196px" OnTextChanged="txtSeries_TextChanged" ></asp:TextBox>
                </div>
                <div class="input_field1">
                    <asp:Label ID="Label7" runat="server" Text="StartingSeries:" CssClass="label"></asp:Label>
                    <asp:Label ID="LabelStart" runat="server" CssClass="label" ForeColor="Blue"></asp:Label>
                    <%--<asp:TextBox ID="txtStart" runat="server" CssClass="input1" Visible="false"  Width="196px"></asp:TextBox>--%>
                </div>

                <div class="input_field1">
                    <asp:Label ID="Label8" runat="server" Text="EndingSeries :" CssClass="label"></asp:Label>
                     <asp:Label ID="LabelEnd" runat="server" CssClass="label" ForeColor="Blue"></asp:Label>
                 <%--   <asp:TextBox ID="txtEnd" runat="server" CssClass="input1" Visible="false" Width="200px"></asp:TextBox>--%>
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
                <asp:DropDownList ID="DDLlistseries" Visible="false" runat="server" ></asp:DropDownList>
                <asp:Button ID="btnUpdate" Visible="false" Enabled="false" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnAdd" Enabled="false" runat="server" Text="Add" CssClass="btn" Visible="false" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn" OnClick="btnClear_Click" Width="200px"/>
                </div>
                                </div>
            </div>



         

      <%--   <ajaxtoolkit:modalpopupextender ID="ModalInquiry" PopupControlID="PanelInquiry" TargetControlID="gvModal" CancelControlID="btnClose" runat="server"></ajaxtoolkit:modalpopupextender>
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
                    <asp:TextBox ID="txtTracking" runat="server" CssClass="input1" Width="250px" AutoPostBack="true" OnTextChanged="txtTracking_TextChanged"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn2" OnClick="btnSearch_Click"/>
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





        <ajaxtoolkit:modalpopupextender ID="ModalDetails" PopupControlID="PanelDetails" TargetControlID="gvModal" runat="server" PopupDragHandleControlID="header2"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelDetails" runat="server" TabIndex="1" CssClass="Modal">
          
           <div class="contain"> 
                <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                    <div id="header2" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    </h5>
                        <asp:Button runat="server" ID="btnCloseDetails" Text="x" CssClass="btn" OnClick="btnCloseDetails_Click"/>
                            </div>
              <asp:HiddenField runat="server" ID="hfDesti" />
                <div class="input_field1">
                    <asp:Label ID="LabelID" runat="server" Text="ID:" CssClass="label"></asp:Label>
                    <asp:Label ID="lblID" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label> 
                </div>
                    <div class="input_field1">
                        <asp:Label ID="LabelBr" runat="server" Text="Branch:" CssClass="label"></asp:Label>
                        <asp:Label ID="lblBr" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label>
                    </div>
                    <div class="input_field1">
                        <asp:Label ID="LabelTe" runat="server" Text="Team:" CssClass="label"></asp:Label>
                        <asp:Label ID="lblTe" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label>
                    </div>
                    <div class="input_field1">
                        <asp:Label ID="LabelAr" runat="server" Text="Area:" CssClass="label"></asp:Label>
                        <asp:Label ID="lblAr" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label>
                    </div>
                     <div class="input_field1">
                        <asp:Label ID="LabelWar" runat="server" Text="Warehouse:" CssClass="label"></asp:Label>
                        <asp:Label ID="lblWar" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label>
                    </div>
                    <div class="input_field1">
                        <asp:Label ID="LabelHu" runat="server" Text="Hub:" CssClass="label"></asp:Label>
                        <asp:Label ID="lblHu" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label>
                    </div>

                             </ContentTemplate>
                                     <Triggers>
                            <asp:PostBackTrigger ControlID="btnCloseDetails" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                
            </div>
        </asp:Panel>







        <div class="container">
            <asp:HiddenField ID="gvModal" runat="server"/>
                            <div class="forms">
                                  
                   <div class="input_field1">
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [ItemDescr]+'-'+[ItemMaterialCode2] as Product FROM [Reference] where ItemMaterialCode2 != 'NULL'"></asp:SqlDataSource>
                        <asp:Label ID="Label15" runat="server" Text="Enter Branch-Code:" CssClass="labelSearch"></asp:Label>
                       <asp:TextBox ID="txtSearch" runat="server" CssClass="inputSearch" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:DropDownList ID="DDLcode" Visible="false" runat="server" OnTextChanged="DDLcode_TextChanged" AppendDataBoundItems="True" AutoPostBack="true" CssClass="labelSearch2" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product">
                             <asp:ListItem Selected="True" Value="S" Text="--SELECT--"></asp:ListItem>
                        </asp:DropDownList>

                       
                        <asp:Label ID="lblCode" Visible="false" runat="server" Text="Total Units:"></asp:Label>
                        <asp:Label ID="lblCodeNo" Visible="false" runat="server" Text="" ForeColor="Blue"></asp:Label>
                  </div>

                <div class="input_field1">

                    <asp:Label ID="Label1" runat="server" Text="Date" CssClass="label1"></asp:Label>

                    <asp:TextBox ID="txtDated" runat="server" ReadOnly="true" Width="20%"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="4%" ImageUrl="img/icons8-calendar-96.png" onclick="ImageButton1_Click" Width="5%" />
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Height="180px" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>

                     <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="btn" OnClick="btnDisplay_Click"/>
                    <asp:DropDownList ID="DropPer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropPer_SelectedIndexChanged">
                        <asp:ListItem Value="S">-Select-</asp:ListItem>
                        <asp:ListItem Value="B">Branch</asp:ListItem>
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


               

                              
    <asp:GridView runat="server" RowStyle-Width="100px" ID="Gridview1" CssClass="gridview" width="100%" AllowPaging="true" PagerStyle-HorizontalAlign="Center" PagerStyle-ForeColor="#003366" PageSize="8" PagerSettings-Mode="NextPrevious" PagerStyle-Font-Size="X-Large" OnPageIndexChanging="Gridview1_PageIndexChanging" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
          
                                    <Columns>

                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="StartSeries" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="EndSeries" />

                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Units" />
                                         <asp:TemplateField HeaderText="Destination">
                                            <ItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Eval("Branch") %>'  Width="100%" ForeColor="Black" Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Branch" %>'></asp:TextBox>
                                               <asp:TextBox runat="server" Text='<%# Eval("Hub") %>'  Width="100%" ForeColor="Black"  Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Hub" %>'></asp:TextBox>
                                               <asp:TextBox runat="server" Text='<%# Eval("Warehouse") %>' Width="100%" ForeColor="Black" Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Warehouse" %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField DataTextField="RequestID" HeaderText="CtrlNo" />

                                    </Columns>
                                </asp:GridView>
                                </div>
            </div>--%>

          <div class="container">
            <asp:HiddenField ID="gvModal" runat="server"/>
                 <div class="forms">
                    <div class="input_field1"> 
                          <a style="padding-left: 60%;">
                    <asp:Label ID="Label1" Font-Bold="true" ForeColor="Black" runat="server" Text="DATE:" CssClass="label1"></asp:Label>
                    <asp:Label ID="lblDated" Font-Bold="true" ForeColor="Black" runat="server" CssClass="label1"></asp:Label>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click"/>
                        </a>
                   </div>       
      <asp:GridView runat="server" RowStyle-Width="100px" ID="Gridview1" CssClass="gridview" width="100%" AllowPaging="true" PagerStyle-HorizontalAlign="Center" PagerStyle-ForeColor="#003366" PageSize="8" PagerSettings-Mode="NextPrevious" PagerStyle-Font-Size="X-Large" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                 <Columns>
                                      <asp:TemplateField HeaderText="StartingSeries">
                                            <ItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Eval("StartingSeries") %>' Width="100%" Enabled="false" ForeColor="Black" BorderColor="White"></asp:TextBox>
                                               </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="EndingSeries">
                                            <ItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Eval("EndingSeries") %>' Width="100%" Enabled="false" ForeColor="Black" BorderColor="White"></asp:TextBox>
                                               </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Products">
                                            <ItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Eval("Products") %>' Width="100%" Enabled="false" ForeColor="Black" BorderColor="White"></asp:TextBox>
                                               </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:ButtonField DataTextField="StartingSeries" HeaderText="StartSeries" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="EndSeries" />--%>
                                        <asp:ButtonField DataTextField="TQ" HeaderText="Total Qty" />
                                    </Columns>
                                </asp:GridView>
                                </div>
            </div>




           <ajaxtoolkit:modalpopupextender ID="ModalEdit" PopupControlID="PanelEdit" TargetControlID="gvModal" runat="server" PopupDragHandleControlID="header3"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelEdit" runat="server" TabIndex="1" CssClass="Modal" BackColor="White">
          
           <div class="container2"> 
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <div id="header3" class="modal-header">
                                <h5 class="modal-title" id=""> UPDATE TAGGING
                                    </h5>
                        <asp:Button runat="server" ID="Button1" Text="x" CssClass="btn" OnClick="btnClose_Click"/>
                            </div>
              <asp:HiddenField runat="server" ID="hfIDedit" />
                <div class="input_field1">
                    <asp:Label ID="Label16" runat="server" Text="StartingSeries" CssClass="label"></asp:Label>
                    <asp:Label ID="lblStartSeries" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label> 
                </div>
                <div class="input_field1">
                    <asp:Label ID="Label17" runat="server" Text="EndingSeries" CssClass="label"></asp:Label>
                    <asp:Label ID="lblEndSeries" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label> 
                </div>
               <div class="input_field1">
                    <asp:Label ID="Label19" runat="server" Text="No. of Units:" CssClass="label"></asp:Label>
                    <asp:Label ID="lblQuantity" runat="server" ForeColor="Blue" CssClass="label" ></asp:Label> 
                </div>
                <div class="input_field1">
                    <asp:Label ID="Label18" runat="server" Text="DestinationTo:" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDestiEdit" runat="server" CssClass="input1" AutoPostBack="true" OnSelectedIndexChanged="DropDestiEdit_SelectedIndexChanged">
                         <asp:ListItem Value="S" Selected="True">~Select~</asp:ListItem>
                         <asp:ListItem Value="B">Branch</asp:ListItem>
                         <asp:ListItem Value="H">Hub</asp:ListItem>
                         <%--<asp:ListItem Value="W">Warehouse</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <asp:Label ID="lblBranchEdit" Visible="false" runat="server" Text="Branch:" CssClass="label"></asp:Label>
                  <asp:TextBox ID="DropBranchEdit" Visible="false" AutoPostBack="true" OnTextChanged="DropBranchEdit_TextChanged" runat="server" CssClass="input1" Width="200px"></asp:TextBox>  
                  <asp:AutoCompleteExtender ServiceMethod="GetCompletionList2"
                             CompletionListHighlightedItemCssClass="autoCompleteSelectedListItem"
                             CompletionListItemCssClass="autoCompleteListItem" 
                             CompletionListCssClass="autoCompleteList"
                             MinimumPrefixLength="1"   
                             CompletionInterval="10" 
                             EnableCaching="false" 
                             CompletionSetCount="10"
                             TargetControlID="DropBranchEdit"
                             ID="AutoCompleteExtender2" 
                             runat="server" 
                             FirstRowSelected="false">    
                   </asp:AutoCompleteExtender>
                </div>
               <div class="input_field1">
                    <asp:Label ID="lblTeamEdit" Visible="false" runat="server" Text="Team:" CssClass="label"></asp:Label>
                      <asp:DropDownList ID="DropTeamEdit" Visible="false" runat="server" AutoPostBack="true" CssClass="input1">
                          <asp:ListItem Selected="True" Text=""></asp:ListItem>
                      </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="lblAreaEdit" Visible="false" runat="server" Text="Area:" CssClass="label"></asp:Label>
                       <asp:DropDownList ID="DropAreaEdit" Visible="false" runat="server" AutoPostBack="true" CssClass="input1">
                           <asp:ListItem Selected="True" Text=""></asp:ListItem>
                       </asp:DropDownList>
                </div>

                <div class="input_field1">
                    <asp:Label ID="lblWareEdit" Visible="false" runat="server" Text="Warehouse:" CssClass="label"></asp:Label>
                       <asp:DropDownList ID="DropWareEdit" Visible="false" runat="server" CssClass="input1">
                            <asp:ListItem Selected="True" Text=""></asp:ListItem>
                       </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <asp:Label ID="lblHubEdit" Visible="false" runat="server" Text="Hub:" CssClass="label"></asp:Label>
                        <asp:DropDownList ID="DropHubEdit" Visible="false" runat="server" CssClass="input1">
                             <asp:ListItem Selected="True" Text=""></asp:ListItem>
                       </asp:DropDownList>
                </div>
                <div class="input_field1">
                <asp:Button ID="btnUpdateEdit" Enabled="false" runat="server" Text="Update" OnClick="btnUpdateEdit_Click" CssClass="btn" BackColor="#333333" ForeColor="White"/>
                </div>
                   

                             </ContentTemplate>
                                     <Triggers>
                            <%--<asp:PostBackTrigger ControlID="btnCloseDetails" />--%>
                                    </Triggers>
                                </asp:UpdatePanel> 
                
            </div>
        </asp:Panel>


           <asp:GridView runat="server" CssClass="gvTempCss" HorizontalAlign="Center" OnRowDeleting="gvTemp_RowDeleting" RowStyle-Width="100px" ID="gvTemp" width="100%" DataKeyNames="ID" AutoGenerateColumns="False" ShowFooter="true">
          
                                    <Columns>
                                        <asp:BoundField DataField="StartingSeries" HeaderText="StartingSeries" SortExpression="StartingSeries" />
                                        <asp:BoundField DataField="EndingSeries" HeaderText="EndingSeries" SortExpression="EndingSeries" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                        <asp:BoundField DataField="DestinationTo" HeaderText="DestinationTo" SortExpression="DestinationTo" />
                                        <asp:BoundField DataField="Products" HeaderText="Products" SortExpression="Products" />
                                        <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                                        <asp:BoundField DataField="Team" HeaderText="Team" SortExpression="Team" />
                                        <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                                        <asp:BoundField DataField="Warehouse" HeaderText="Warehouse" SortExpression="Warehouse" />
                                        <asp:BoundField DataField="Hub" HeaderText="Hub" SortExpression="Hub" />
                                      <%--  <asp:BoundField DataField="ScheduleDate" HeaderText="RequestNo" SortExpression="RequestNo"/>--%>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                         
<%--                                      <asp:TemplateField HeaderText="StartSeries">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("StartingSeries") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>--%>

                                        <%--<asp:TemplateField HeaderText="EndSeries">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("EndingSeries") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                        <asp:TemplateField HeaderText="No.ofUnits">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Quantity") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>--%>

                                        <%--<asp:TemplateField HeaderText="DestinationTo">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("DestinationTo") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                          
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Branch">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Branch") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>--%>

<%--                                        <asp:TemplateField HeaderText="Team">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Team") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Area">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Area") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Warehouse">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Warehouse") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Hub">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("Hub") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>--%>

                                      <%--  <asp:TemplateField HeaderText="ScheduleDate" Visible="false">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("ScheduleDate") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                          <ItemTemplate>
                                              <asp:Label Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>--%>


                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                 <asp:ImageButton runat="server" ImageUrl="~/img/EditIcon.png" ID="btnEdit" CommandArgument='<%# Eval("ID") + "," + Eval("StartingSeries") + "," + Eval("EndingSeries")+ "," + Eval("DestinationTo")+ "," + Eval("Branch")+ "," + Eval("Team")+ "," + Eval("Area")+ "," + Eval("Warehouse")+ "," + Eval("Hub")+ "," + Eval("Quantity")%>' OnClick="btnEdit_Click" Width="20px" Height="20px" />
                                                 <asp:ImageButton runat="server" ImageUrl="~/img/TrashIcon.png" ID="btnDelete" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                            </ItemTemplate>
                                           <%-- <EditItemTemplate>
                                                <asp:ImageButton runat="server" ImageUrl="~/img/SaveIcon.png" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                                <asp:ImageButton runat="server" ImageUrl="~/img/ExitIcon.png" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                            </EditItemTemplate>--%>
                                        </asp:TemplateField>
                                         <asp:TemplateField>
                                             <HeaderTemplate>
                                                  <asp:Button runat="server" ID="btnSavedGV" Text="Submit" CssClass="btn" ForeColor="White" BackColor="#333333" OnClick="btnSavedGV_Click" />
                                             </HeaderTemplate>
                                              <ItemTemplate>
                                                 <asp:Label runat="server" Text="Ready" ForeColor="DarkRed"></asp:Label>
                                             </ItemTemplate>
                                      </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
              <%--     </div>
            </div>--%>
</div>
        

    




     <div class="loader-wrapper">
        <span class="loader"><span class="loader-inner"></span></span>
            </div>
    
    <script>
        //$(window).on("load", function () {
        //    $(".loader-wrapper").fadeOut("slow");
        //});

        $(window).on('load', () => {
            setTimeout(() => {
               
                $(".loader-wrapper").fadeOut("slow", function () {
                    $(this).remove();
                });
            }, 150);
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
