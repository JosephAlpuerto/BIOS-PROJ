<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="NewRequestForm.aspx.cs" Inherits="BIOSproject.NewRequestForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
            <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
            <script src="js/jquery.js"></script>
            <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="js/SA.js"></script>

   <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
       $(document).ready(function () {
           $("#TicketNo").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                $("#error").html("Numbers Only").show().fadeOut("slow");
                   return false;
                       }
                     });
                  });
    </script>
    <style>
        #error{
            color: red;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#PONumber").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#errorPO").html("Numbers Only").show().fadeOut("slow");
                    return false;
                }
            });
        });
    </script>
    <style>
        #errorPO{
            color: red;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#TxtQuantity").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#errorQt").html("Numbers Only").show().fadeOut("slow");
                    return false;
                }
            });
        });
    </script>
    <style>
        #errorQt{
            color: red;
        }
    </style>

    <%--<script>
        $(document).ready(function () {
            $('#btnAdd').click(function () {
                $('#DropProduct option:selected').remove();
            });
        });
    </script>--%>


      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#btnDelete").bind("click", function () {
            $("#DDL option:selected").remove();
        });
    });
</script>



    <link href="css/NewRequest.css" rel="stylesheet" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [Username] FROM [Users] WHERE RoleType = 'Supplier' and IsActive = '1'"></asp:SqlDataSource>

<div class="body">
    <div class="container">
        <formview action="#">
            <div class="form-details">
                <div class="input-box2">
                    <span class="details">Ticket No.:</span><span id="error"></span>
                    <asp:TextBox ID="TicketNo" runat="server" CssClass="input1" AccessKey="1" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox><asp:Label ID="lblerrorTicket" runat="server" ForeColor="Red" CssClass="label"></asp:Label>
                </div>

                <div class="input-box2">
                    <span class="details">PONumber:</span><span id="errorPO"></span>
                    <asp:TextBox ID="PONumber" runat="server" CssClass="input1" AutoPostBack="true" OnTextChanged="PONumber_TextChanged"  AccessKey="2" ClientIDMode="Static"></asp:TextBox><asp:Label ID="lblError1" runat="server" ForeColor="Red"></asp:Label>
                </div>

                <div class="input-box2">
                    <span class="details">Requested Date:</span>
                    <asp:TextBox ID="ReqDate" runat="server" CssClass="input1" TextMode="Date" ReadOnly="True" Enabled="false"></asp:TextBox>
                </div>

                  
                <div class="input-box4">
                   <span class="details">Supplier:</span>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [VendorEmail], [VendorName] as Vendor FROM [Reference] where VendorName != 'NULL'"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [VendorName], [VendorEmail] FROM [Reference] where VendorName != 'NULL'"></asp:SqlDataSource>
             
                    <asp:DropDownList ID="dropSupplier" runat="server" AppendDataBoundItems="True" AutoPostBack="true" CssClass="drop1" OnSelectedIndexChanged="dropSupplier_SelectedIndexChanged" DataSourceID="SqlDataSource5" DataTextField="VendorName" DataValueField="VendorName" Width="300px" >
                        <asp:ListItem Selected="True" Value="S" Text="--SELECT--"></asp:ListItem>
                </asp:DropDownList>
                  <%--  <asp:DropDownList ID="dropSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropSupplier_SelectedIndexChanged" CssClass="drop1" Width="300px" >
                </asp:DropDownList>--%>

                    <asp:HiddenField ID="gvModal" runat="server" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="details">Request NO.:</span>
                     <asp:TextBox ID="txtRequestNo" CssClass="input1" runat="server" Width="134px" ReadOnly="True" Enabled="false"></asp:TextBox>
                    
                   <asp:DropDownList ID="DropFIE" Visible="false" runat="server" AutoPostBack="true" CssClass="input1">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                        </asp:DropDownList>
                </div>
                        

                <div class="input-box">
                    <span class="details">Product:</span>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [ItemDescr]+'-'+[ItemMaterialCode2] as Product FROM [Reference] where ItemMaterialCode2 != 'NULL'"></asp:SqlDataSource>
                    <asp:DropDownList ID="DropProduct" AppendDataBoundItems="True" runat="server" AutoPostBack="true" CssClass="drop1" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product" Width="140px"> 
                        <asp:ListItem Selected="True" Value="S" Text="--SELECT--"></asp:ListItem>
                    </asp:DropDownList><asp:Label ID="lblerrorDrop" runat="server" ForeColor="Red" CssClass="label"></asp:Label> 

                  
                </div>

                <div class="input-box">
                    <span class="details">Quantity:</span>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="drop2" Width="120px" ClientIDMode="Static" AccessKey="3"></asp:TextBox><asp:Label ID="lblerror" runat="server" ForeColor="Red" CssClass="label"></asp:Label><span id="errorQt"></span>
                </div>
                <div class="input-box">
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-primary btn-user btn-block" OnClick="Button2_Click" Width="150px" Height="30px"/>
                </div>

                <div class="input-box7">
                     <span class="details" ></span>
                </div>
                <div class="input-box7">
                     <asp:Label ID="Label9" runat="server" Visible="false" Text="Total Quantity" CssClass="label"></asp:Label>
                </div>
                 <div class="input-box6">
                <asp:TextBox ID="TxtAllProduct" runat="server" Visible="false" TextMode="MultiLine" ReadOnly="true" CssClass="input1" value="=Convert.ToString(info[0])" Width="400px" Height="100px"></asp:TextBox> 
                </div>
                <div class="input-box6">
                    <asp:TextBox ID="txtTotal" Visible="false" runat="server" CssClass="input1" ReadOnly="True" ></asp:TextBox>
                </div>
                    
                <asp:DropDownList ID="DDL" runat="server" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="DDLQuantity" runat="server" Visible="false"></asp:DropDownList>
                <asp:TextBox ID="txtSupp" Visible="false" runat="server"></asp:TextBox>
            </div>
        </formview>


         <asp:GridView ID="GridView" runat="server" HorizontalAlign="Center" OnRowEditing="GridView_RowEditing" DataKeyNames="ID" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" OnRowDeleting="GridView_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#d00149" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />

                    <Columns>

                        <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Products") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                               <%-- <asp:TextBox runat="server" ID="txtProduct" Text='<%#Eval("Products") %>'></asp:TextBox>--%>
                              <asp:DropDownList ID="DropProdGV" runat="server" CssClass="drop1" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product" AppendDataBoundItems="True">
                                  <asp:ListItem Selected="True" Value="0" Text="~~Select~~"></asp:ListItem>
                              </asp:DropDownList>
                            </EditItemTemplate>
                            <%--<FooterTemplate>
                                <asp:TextBox runat="server" ID="txtProductFooter"></asp:TextBox>
                            </FooterTemplate>--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtQuantity" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <%--<FooterTemplate>
                                <asp:TextBox runat="server" ID="txtQuantityFooter"></asp:TextBox>
                            </FooterTemplate>--%>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/img/EditIcon.png" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                <asp:ImageButton runat="server" ImageUrl="~/img/TrashIcon.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/img/SaveIcon.png" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                <asp:ImageButton runat="server" ImageUrl="~/img/ExitIcon.png" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                            </EditItemTemplate>
                           <%-- <FooterTemplate>

                            </FooterTemplate>--%>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView><asp:Label ID="lblGridview" runat="server" ForeColor="Green" CssClass="label"></asp:Label><asp:Label ID="lblerrorGV" runat="server" ForeColor="Red" CssClass="label"></asp:Label>

        <div>
            <asp:Button ID="Button1" runat="server" style="margin-top:30px" Text="Check" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click" Width="650px"/>
       
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:LBC_BIOS %>" SelectCommand="SELECT [TicketNo], [PONumber], [Supplier], [Products], [Quantity], [DateRequested], [RequestNo] FROM [TempRequest]"></asp:SqlDataSource>
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TicketNo" HeaderText="TicketNo" SortExpression="TicketNo" />
                        <asp:BoundField DataField="PONumber" HeaderText="PONumber" SortExpression="PONumber" />
                        <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
                        <asp:BoundField DataField="Products" HeaderText="Products" SortExpression="Products" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="DateRequested" HeaderText="DateRequested" SortExpression="DateRequested" />
                        <asp:BoundField DataField="RequestNo" HeaderText="RequestNo" SortExpression="RequestNo" />
                    </Columns>
               </asp:GridView>
            </div>
    </div>
    </div>


     <ajaxtoolkit:modalpopupextender ID="ModalReviewView" PopupControlID="PanelView" TargetControlID="gvModal" runat="server"></ajaxtoolkit:modalpopupextender>
       <asp:Panel ID="PanelView" runat="server" TabIndex="1" CssClass="Modal" Height="500px">
           <div id="Div1" runat="server" style="max-height: 500px; overflow: auto;">
                          
        <div class="card o-hidden border-0 shadow-lg my-2">
            <div class="card-body p-0">
                <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel"></h5>
                                
                                    <asp:LinkButton ID="btnCloseView" runat="server" Text="x" OnClick="btnCloseView_Click"/>
                               
                            </div>
                

                 <div class="container">

                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                             <div class="form3">

                <div  class="input_field1">
                    <span class="details">Requested Date:</span>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input1" ReadOnly="True" Enabled="false"></asp:TextBox>
                </div>
                <div  class="input_field1">
                    <span class="details">Requested No.:</span>
                    <asp:TextBox ID="txtRequest" runat="server" CssClass="input1" ReadOnly="True" Enabled="false"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <span class="details">Ticket Number</span>
                    <asp:TextBox ID="txtTicketNo" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                     <span class="details">PO Number</span>
                     <asp:TextBox ID="txtPONumber" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                     <span class="details">Supplier</span>
                    <asp:TextBox ID="txtSupplier" Enabled="false" runat="server" CssClass="input1"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" runat="server" Visible="false"></asp:TextBox>
                </div>

                 <%--<div class="input_field1">
                      <span class="details">List of Product's</span>
                    <asp:TextBox ID="txtAllProductQuantity" runat="server" Enabled="false" CssClass="input1" TextMode="MultiLine" ></asp:TextBox>
                </div>--%>

             <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#d00149" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />

                    <Columns>

                        <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Products") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                               <%-- <asp:TextBox runat="server" ID="txtProduct" Text='<%#Eval("Products") %>'></asp:TextBox>--%>
                              <asp:DropDownList ID="DropProdGV" runat="server" CssClass="drop1" DataSourceID="SqlDataSource3" DataTextField="Product" DataValueField="Product"></asp:DropDownList>
                            </EditItemTemplate>
                            <%--<FooterTemplate>
                                <asp:TextBox runat="server" ID="txtProductFooter"></asp:TextBox>
                            </FooterTemplate>--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtQuantity" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <%--<FooterTemplate>
                                <asp:TextBox runat="server" ID="txtQuantityFooter"></asp:TextBox>
                            </FooterTemplate>--%>
                        </asp:TemplateField>

                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/img/EditIcon.png" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                <asp:ImageButton runat="server" ImageUrl="~/img/TrashIcon.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/img/SaveIcon.png" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                <asp:ImageButton runat="server" ImageUrl="~/img/ExitIcon.png" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                            </EditItemTemplate>
                            <FooterTemplate>

                            </FooterTemplate>
                        </asp:TemplateField>--%>
                    </Columns>

                </asp:GridView>

            

                                

                <div class="input_field1">
                     <span class="details">Total Quantity</span>
                    <asp:TextBox ID="txtTotalQuantity" runat="server" Enabled="false" CssClass="input1"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" />
                </div>
                          
        </div>        
        </div>
   </div>
</div>

            </div>
       </div> 
  </div>
               </div>

           </asp:Panel>









    <div class="wrapper">

        <div class="forms">



            <asp:Label ID="Label8" runat="server"></asp:Label>
           
            <div class="field1">
                <asp:Label ID="lblTicketNo" runat="server" Visible="false" Text="Ticket No." CssClass="label"></asp:Label>
                
                <asp:Label ID="Label3" runat="server" Visible="false" Text="PO Number" CssClass="label"></asp:Label>
               
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <div class="field2">
                <asp:Label ID="Label2" runat="server" Visible="false" Text="Requested Date" CssClass="label"></asp:Label>
                

                
                <asp:Label ID="Label4" runat="server" Visible="false" Text="Supplier" CssClass="label"></asp:Label>
                
            </div>
           
            <div class="field">
                <asp:Label ID="Label5" runat="server" Visible="false" Text="Product" CssClass="label1"></asp:Label>
                <asp:Label ID="Label6" runat="server" Visible="false" Text="Quantity" CssClass="label2"></asp:Label>
                
                <asp:HiddenField ID="HFValue" runat="server" />
            </div>

           
            <div class="field">
                
                
                <br />
                
                <br />
                <asp:Label ID="Label1" runat="server" Visible="false" Text="List of Product's" CssClass="label"></asp:Label>
                
            </div>
            
            <div class="field">
                <asp:Label ID="Label7" runat="server" Visible="false" Text="Total Quantity" CssClass="label"></asp:Label>
               
            </div>


          

            <br />
           

        </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
