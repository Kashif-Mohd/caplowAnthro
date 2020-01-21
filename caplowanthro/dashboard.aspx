<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="caplowanthro.dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .shakeee {
            animation: shake 0.5s;
            animation-iteration-count: infinite;
            -moz-animation: shake 1s linear;
            -webkit-animation: shake 1.2s linear;
        }

        @keyframes shake {
            0% {
                transform: translate(1px, 1px) rotate(0deg);
            }

            10% {
                transform: translate(-1px, -2px) rotate(-1deg);
            }

            20% {
                transform: translate(-3px, 0px) rotate(1deg);
            }

            30% {
                transform: translate(3px, 2px) rotate(0deg);
            }

            40% {
                transform: translate(1px, -1px) rotate(1deg);
            }

            50% {
                transform: translate(-1px, 2px) rotate(-1deg);
            }

            60% {
                transform: translate(-3px, 1px) rotate(0deg);
            }

            70% {
                transform: translate(3px, 1px) rotate(-1deg);
            }

            80% {
                transform: translate(-1px, -1px) rotate(1deg);
            }

            90% {
                transform: translate(1px, 2px) rotate(0deg);
            }

            100% {
                transform: translate(1px, -2px) rotate(-1deg);
            }
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #A3CB38; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="shakeee">
                <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
                    <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>
                        <asp:Label ID="lbeUname" runat="server" ForeColor="white" Text=""></asp:Label>, Welcome to Dashboard!</b></h1>
                </div>



                <div style="text-align: center; margin-top: 30px;">

                    <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                    <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                    &nbsp To &nbsp
                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                    <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                    <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
                </div>



                <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

                    <asp:Chart ID="Chart1" runat="server" Width="1100" Height="400px" BorderSkin-BorderColor="Black" Palette="SeaGreen">
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Title="Tab User" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Name="Bottom Title" Text="Forms" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Name="Top" Text="User Performance" Font="Arial Rounded MT Bold, 18pt, ">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>

                    <hr style="border-top: 1px solid #ccc; background: transparent;">

                    <asp:Chart ID="Chart2" runat="server" Width="1000" Height="400px">
                        <Series>
                            <asp:Series Name="Series2">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea2">
                                <AxisX Interval="1" TextOrientation="Rotated90">
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Name="Bottom Title" Text="Year" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Name="Top" Text="Birth Capturing" Font="Arial Rounded MT Bold, 18pt, ">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>



                    <hr style="border-top: 1px solid #ccc; background: transparent;">

                    <asp:Chart ID="Chart3" runat="server" Width="1000" Height="400px">
                        <Series>
                            <asp:Series Name="Series3">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea3">
                                <AxisX Interval="1" TextOrientation="Rotated90">
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Name="Bottom Title" Text="Year" Font="Arial Rounded MT Bold, 12pt, ">
                            </asp:Title>
                            <asp:Title Name="Top" Text="Live Birth" Font="Arial Rounded MT Bold, 18pt, ">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>

                </div>

            </div>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <div style="padding-left: 2%; margin-top: 0px;">
                <div style="color: #009432; font-size: 20px; font-family: Arial"><b><u>Mortality</u>:</b></div>
                <br>
                <asp:GridView ID="GridView3" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="field" HeaderText="" />
                        <asp:BoundField DataField="cluster_type" HeaderText="Cluster Type" />
                        <asp:BoundField DataField="year_2012" HeaderText="2012" />
                        <asp:BoundField DataField="year_2013" HeaderText="2013" />
                        <asp:BoundField DataField="year_2014" HeaderText="2014" />
                        <asp:BoundField DataField="year_2015" HeaderText="2015" />
                        <asp:BoundField DataField="year_2016" HeaderText="2016" />
                        <asp:BoundField DataField="year_2017" HeaderText="2017" />
                        <asp:BoundField DataField="year_2018" HeaderText="2018" />
                        <asp:BoundField DataField="year_2019" HeaderText="2019" />
                        <asp:BoundField DataField="year_2020" HeaderText="2020" />
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#284775" />
                    <HeaderStyle BackColor="#A3CB38" ForeColor="white" Font-Bold="True" Height="40px" />
                </asp:GridView>
            </div>


            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <div style="padding-left: 2%; margin-top: 0px;">
                <div style="color: #009432; font-size: 20px; font-family: Arial"><b><u>Enrollments</u>:</b></div>
                <br>
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A3CB38" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>


            <hr style="border-top: 1px solid #ccc; background: transparent;">


            <div style="padding-left: 2%; margin-top: 0px;">
                <div style="color: #009432; font-size: 20px; font-family: Arial"><b><u>Followups</u>:</b></div>
                <br>
                <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A3CB38" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
            <br>
        </ContentTemplate>
    </asp:UpdatePanel>


    <br>
    <br>
</asp:Content>
