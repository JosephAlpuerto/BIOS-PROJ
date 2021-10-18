<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BIOSproject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>LBC - Login</title> 
    
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                             
                            <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>

                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                        </div>
                                        <div class="user">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control form-control-user"
                                                    placeholder="Enter Username..."/>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control form-control-user"
                                                    placeholder="Password"/>
                                               
                                            </div>
                                            <asp:HiddenField ID="txtAdmin" runat="server" />
                                                
                                            
                                            <div class="form-group">
                                                 
                                                 <asp:DropDownList Visible="false" ID="DropDownList" runat="server" >
                                                    <asp:ListItem Value="Admin" Selected="True">Admin</asp:ListItem>
                                                    <asp:ListItem Value="User" Selected="True">User</asp:ListItem>
                                                     <asp:ListItem Value="Branch" Selected="True">Branch</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>



                 <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-primary btn-user btn-block" runat="server" Onclick="btnLogin_Click"/>

                                 
                                        </div>
                                        <br />
                   <asp:Label Text="" ID="lblError" ForeColor="Red" Font-Bold="true" runat="server"/>
                                        <br />
                                        <br/>
                                        <div class="text-center">
                                            <a class="small" href="forgot-password.html">Forgot Password?</a>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
 </div>
        </div>

       

        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin-2.min.js"></script>

    </form>
</body>
</html>
