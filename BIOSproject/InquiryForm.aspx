<%@ Page Title="" Language="C#" MasterPageFile="~/Supp.Master" AutoEventWireup="true" CodeBehind="InquiryForm.aspx.cs" Inherits="BIOSproject.InquiryForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="js/SA.js"></script>
   <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
      <div class="big">

     <ajaxtoolkit:modalpopupextender ID="ModalInquiry" PopupControlID="PanelInquiry" TargetControlID="gvModal" CancelControlID="btnCloseInquiry" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelInquiry" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
 
           <div id="Div1" runat="server" style="max-height: 500px; overflow: auto;">
          
           <div class="container2"> 
                <asp:HiddenField ID="hfSuppEmail" runat="server" />
                    <div id="header" class="modal-header">
                                <h5 class="modal-title" id=""> 
                                    Series Inquiry</h5>
                                <button id="btnCloseInquiry" class="close" type="button" data-dismiss="modal" aria-label="Close">
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
          
           <div class="containDL"> 
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
      



        <div class="container" style="width: 1500px;">
            <asp:HiddenField ID="gvModal" runat="server"/>
                 <div class="forms">
                    <div class="input_field1">
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [ItemDescr]+'-'+[ItemMaterialCode2] as Product FROM [LBC.BIOS].[lbcbios].[Reference] where ItemMaterialCode2 != 'NULL'"></asp:SqlDataSource>
                        <asp:Label ID="Label15" runat="server" Text="Enter Branch-Code:" CssClass="labelSearch"></asp:Label>
                       <asp:TextBox ID="txtSearch" runat="server" CssClass="inputSearch" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:DropDownList ID="DDLcode" Visible="false" runat="server" OnTextChanged="DDLcode_TextChanged" AppendDataBoundItems="True" AutoPostBack="true" CssClass="labelSearch2" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product">
                             <asp:ListItem Selected="True" Value="S" Text="--SELECT--"></asp:ListItem>
                        </asp:DropDownList>
                       <%--<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" Visible="false"/>--%>
                       
                        <asp:Label ID="lblCode" Visible="false" runat="server" Text="Total Units:"></asp:Label>
                        <asp:Label ID="lblCodeNo" Visible="false" runat="server" Text="" ForeColor="Blue"></asp:Label>
                   </div>
                     
                  

                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Date" CssClass="label1"></asp:Label>
                    <%--<asp:TextBox ID="txtDate2" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>--%>
                     
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
                                        <%--<asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true"/>
                                                </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" Visible='<%# Eval("forHitCheck").ToString() == "False" &&  Eval("StartingSeries") != DBNull.Value %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="StartSeries" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="EndSeries" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Units" />
                                        <asp:TemplateField HeaderText="Destination">
                                            <ItemTemplate>
                                               <asp:TextBox runat="server" Text='<%# Eval("Branch") %>' Width="100%" ForeColor="Black" Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Branch" %>'></asp:TextBox>
                                               <asp:TextBox runat="server" Text='<%# Eval("Hub") %>' Width="100%" ForeColor="Black" Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Hub" %>'></asp:TextBox>
                                               <asp:TextBox runat="server" Text='<%# Eval("Warehouse") %>' Width="100%" ForeColor="Black" Enabled="false" BorderColor="White" Visible='<%# Eval("DestinationTo").ToString() == "Warehouse" %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:ButtonField DataTextField="RequestID" HeaderText="CtrlNo" />--%>

                                       <%-- <asp:TemplateField>
                                           <ItemTemplate> 
                                               <asp:Button ID="btnDetails" runat="server" CommandArgument='<%# Eval("ID") + "," + Eval("Branch") + "," + Eval("Team")+ "," + Eval("Area")+ "," + Eval("DestinationTo")+ "," + Eval("Hub")+ "," + Eval("Warehouse")%>' Text="View" ForeColor="White" BackColor="Gray" BorderStyle="None" OnClick="btnDetails_Click"/>
                                           </ItemTemplate>
                                        </asp:TemplateField>--%>

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
