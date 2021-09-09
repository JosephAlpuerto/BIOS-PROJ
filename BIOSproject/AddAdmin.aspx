<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="BIOSproject.AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



        <!--Register form-->

        <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    
                    <div class="col-lg-10">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Create an Admin Account!</h1>
                            </div>

                            <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />

                            <div class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                            
                               <asp:TextBox runat="server" ID="textFirstName" CssClass="form-control form-control-user" placeholder="First Name"/>

                                    </div>
                                    <div class="col-sm-6">

                               <asp:TextBox runat="server" ID="textLastName" CssClass="form-control form-control-user" placeholder="Last Name"/>
                                        
                                    </div>
                                </div>
                                <div class="form-group">

                                    <asp:TextBox runat="server" ID="textEmail" CssClass="form-control form-control-user" placeholder="Email"/>
                                    
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">

                               <asp:TextBox runat="server" ID="textPassword" TextMode="Password" CssClass="form-control form-control-user" placeholder="Password"/>
                                        
                                    </div>
                                    <div class="col-sm-6">

                                <asp:TextBox runat="server" ID="textConfirmPassword" TextMode="Password" CssClass="form-control form-control-user" placeholder="Confrim Password"/>
                                        
                                    </div>
                                </div>

                                <asp:Button Text="Add Account" ID="buttonAddAdmin" CssClass="btn btn-primary btn-user btn-block" runat="server" Onclick="buttonAddAdmin_Click"/>


                                <hr>
                                
                            </div>
                            
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>

  