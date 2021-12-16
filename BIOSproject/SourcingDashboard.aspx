<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="SourcingDashboard.aspx.cs" Inherits="BIOSproject.SourcingDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    
        <div class="content">
            <div class="cards">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label1" runat="server" Text="No. of PO" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="LblPO" runat="server" Text="" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label3" runat="server" Text="HitCheck" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="lblHitcheck" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label5" runat="server" Text="On Production" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label6" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label7" runat="server" Text="On Stock" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label8" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label9" runat="server" Text="Completed" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label10" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>

            <%--asdasdasd--%>

            <div class="division">
                <div class="cardss">

                    
             <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label2" runat="server" Text="Supplier:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label4" runat="server" Text="No of PO:" CssClass="label1"></asp:Label>
                        <asp:Label ID="LblPO1" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label13" runat="server" Text="No of Delivered:" CssClass="label1"></asp:Label>
                        <asp:Label ID="lblDelivered" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label15" runat="server" Text="Fulfilment:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label16" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>

                <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label17" runat="server" Text="Produced:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label18" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
                <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label19" runat="server" Text="Availability:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label20" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            </div>





                <%--asdasdasdasdasd--%>
                
                <div class="cardss">

                    
             <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label33" runat="server" Text="Material:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label34" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label35" runat="server" Text="PO Qty:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label36" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label37" runat="server" Text="Delivered:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label39" runat="server" Text="On Hand:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label40" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>

                <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label41" runat="server" Text="PO Balance:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
                <div class="cards1">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label43" runat="server" Text="Availability:" CssClass="label1"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

            </div>
            </div>

                </div>
                


          


<%--             <div class="cards2">
                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label4" runat="server" Text="Material" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label13" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label22" runat="server" Text="PO Qty" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label23" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label24" runat="server" Text="Produced" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label25" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                <div class="card">

                    <div class="box">
                        <asp:Label ID="Label26" runat="server" Text="Delivered" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label27" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>

                 <div class="card">

                    <div class="box">
                        <asp:Label ID="Label28" runat="server" Text="On Hand" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label29" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>
            <div class="card">

                    <div class="box">
                        <asp:Label ID="Label30" runat="server" Text="On Hand" CssClass="label1"></asp:Label>
                    </div>
                    <br />
                    <div class="box1">
                        <asp:Label ID="Label31" runat="server" Text="0" CssClass="label2"></asp:Label>
                    </div>


                </div>



                 </div>--%>

        </div>
   


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
