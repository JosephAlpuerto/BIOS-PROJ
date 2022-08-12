<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="SSP-DuplicateReport.aspx.cs" Inherits="BIOSproject.SSP_DuplicateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


      <div style="padding-left: 5%; padding-right: 5%;">
        
        <asp:Label ID="Label2" runat="server" Text="From:"></asp:Label>
        <%--<asp:TextBox ID="TxtFromDate" runat="server" TextMode="Date"></asp:TextBox>--%>
          <asp:TextBox ID="TxtFromDate" runat="server" ReadOnly="true" Width="12%"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" Height="2%" ImageUrl="img/icons8-calendar-96.png" onclick="ImageButton1_Click" Width="3%" />
        <asp:Label ID="Label3" runat="server" Text="To"></asp:Label>
        <%--<asp:TextBox ID="TxtToDate" runat="server" TextMode="Date"></asp:TextBox>--%>
          <asp:TextBox ID="TxtToDate" runat="server" ReadOnly="true" Width="12%"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" Height="2%" ImageUrl="img/icons8-calendar-96.png" onclick="ImageButton2_Click" Width="3%" />
        <asp:Button ID="BtnDateDisplay" runat="server" Text="Search By Date" OnClick="BtnDateDisplay_Click"/>

          <div style="margin-left: 10%">
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
              </div>
           <div style="margin-left: 30%">
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Height="180px" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </div>


        <asp:GridView runat="server" ID="Gridview1" CssClass="gridview" width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" EmptyDataText="No Records !">
                                    <Columns>
                                      
                                        <asp:ButtonField DataTextField="CreatedDate" HeaderText="DateScanned" />
                                        <asp:ButtonField DataTextField="StartingSeries" HeaderText="Start" />
                                         <asp:ButtonField DataTextField="EndingSeries" HeaderText="End" />
                                        <asp:ButtonField DataTextField="Area" HeaderText="Area" />
                                         <asp:ButtonField DataTextField="Team" HeaderText="Team" />
                                        <asp:ButtonField DataTextField="Branch" HeaderText="Branch" />

                                    </Columns>
                                </asp:GridView>


    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
