<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="BIOSproject.Gen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


     <div id="wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <!-- End of Topbar -->
                    <div class="container-fluid">
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Tables</h1>
                        <asp:Button Text="Add Request" ID="btnAddRequest" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnAddRequest_Click" runat="server"></asp:Button>
               </div>
            </div>
       </div>


     <ajaxtoolkit:modalpopupextender ID="ModalRequest" PopupControlID="PanelRequest" TargetControlID="gvModal" runat="server"></ajaxtoolkit:modalpopupextender>
              <asp:Panel ID="PanelRequest" runat="server">
                       
                  <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Add Request!</h1>
                            </div>
                            <div class="form2">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Label Text="" ID="lblSuccess" ForeColor="Green" Font-Bold="true" runat="server" />
                <div class="input_field1">
                    <%--<label>Date Requested</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Date Requested" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtDate" runat="server" CssClass="input1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="input_field1">
                    <%--<label>Area</label>--%>
                    <asp:Label ID="Label3" runat="server" Text="Area" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropArea" runat="server" CssClass="input1">
                       
                    </asp:DropDownList>
                </div>
                <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="Team" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropTeam" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>
               
            <div class="input_field1">
                    <%--<label>Branch</label>--%>
                <asp:Label ID="Label1" runat="server" Text="Branch" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropBranch" runat="server" CssClass="input1">
                    </asp:DropDownList>
                </div>
                                 <div class="input_field1">
                    <%--<label>Team</label>--%>
                    <asp:Label ID="Label7" runat="server" Text="Supplier" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1">
                      
                    </asp:DropDownList>
                </div>

                <div class="input_field1">
                   <%-- <label>Product</label>--%>
                    <asp:Label ID="Label5" runat="server" Text="Product" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                <div class="input_field1">
                    <%--<label>Quantity</label>--%>
                    <asp:Label ID="Label6" runat="server" Text="Quantity" CssClass="label"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="input1"></asp:TextBox>
                </div>
                

                <div class="input_field1">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary btn-user btn-block" OnClick="Button1_Click"/>
      </div>           
 </div>
                                 </ContentTemplate></asp:UpdatePanel>     
                        </div>
                    </div>
                </div>
                 <asp:Button ID="CloseAddRequest" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" runat="server" Text="Close" OnClick="CloseAddRequest_Click"/>
            </div>
        </div>
    </div>

               </asp:Panel>




     <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Request List </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">

                                <asp:HiddenField ID="gvModal" runat="server" />
                                <asp:GridView runat="server" ID="gvListRequest" CssClass="table table-bordered dataTable2" width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:ButtonField DataTextField="Id" HeaderText="Requested ID" />
                                        <asp:ButtonField DataTextField="DateRequested" HeaderText="DateRequested" />
                                         <asp:ButtonField DataTextField="Product" HeaderText="Product" />
                                        <asp:ButtonField DataTextField="Quantity" HeaderText="Quantity" />
                                         <asp:ButtonField DataTextField="StartingSeries" HeaderText="Starting Series" />
                                        <asp:ButtonField DataTextField="EndingSeries" HeaderText="Ending Series" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                        <asp:ButtonField DataTextField="Team" HeaderText="Team" />
                                       
                                       
                                        <asp:ButtonField DataTextField="Done" HeaderText="Requested Status" />
                                        
                                                        <%--<asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkViewReset" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkViewReset_Click">Reset Password</asp:LinkButton>
                                                           </ItemTemplate>
                                                        </asp:TemplateField>
                                        
                                                       <asp:TemplateField>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' Onclick="LinkView_Click">View</asp:LinkButton>
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
