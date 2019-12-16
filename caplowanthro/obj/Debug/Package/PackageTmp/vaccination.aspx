<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="vaccination.aspx.cs" Inherits="caplowanthro.vaccination" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }


        .btnChng {
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            .btnChng:active {
                position: relative;
                top: 1px;
            }




        .StylePager {
            border-radius: 5px;
            text-align: left;
        }

            .StylePager a:hover {
                background-color: #33d9b2;
                margin-right: 3px;
                padding: 3px;
                border-radius: 3px;
            }

            .StylePager a {
                padding: 3px;
                margin-right: 3px;
            }

            .StylePager span {
                background: #aec62c;
                padding: 4px;
                border-radius: 3px;
                margin-right: 3px;
            }

        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            tddd, thhh {
                margin-top: 0.8em;
                display: block;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>

    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #009432; font-size: 22px; width: 100%">
            Vaccination:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">



        <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
            <tr>
                <td>
                    <asp:Button ID="btnGraph" OnClick="btnGraph_Click" CssClass="btnChng" runat="server" Text="Graph " Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnVaccination" OnClick="btnVaccination_Click" CssClass="btnChng" runat="server" Text="Vaccination" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
            </tr>
        </table>




        <%--Graph Button--%>
        <div style="padding-left: 2%; margin-top: 15px;" id="divGraph" runat="server">

            <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

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
                        <asp:Title Name="Top" Text="Vaccination (Eligible and Done)" Font="Arial Rounded MT Bold, 18pt, ">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </div>





           <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: 0px">




            <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">

                <asp:Chart ID="Chart1" runat="server" Width="1000" Height="400px">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Interval="1" TextOrientation="Rotated90">
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Name="Top" Text="Child Death" Font="Arial Rounded MT Bold, 18pt, ">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </div>


        </div>














        <%--Vaccination Button--%>


        <div style="padding-left: 2%; margin-top: 15px;" id="divVaccination" runat="server">
            <div id="divExportButton" runat="server" style="text-align: right; margin-top: -10px">
                <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                    Export &nbsp<span class="glyphicon glyphicon-export"></span>
                </button>
            </div>

            <%--Search Button--%>
            <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">


                <div id="imaginary_container" style="margin-top: 10px">
                    <div class="input-group stylish-input-group">
                        <asp:TextBox ID="txtdssidVacciantion" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                        <span class="input-group-addon">
                            <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </span>
                    </div>
                </div>

            </div>

            <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="vaccination_id" HeaderText="vaccination_id" />
                        <asp:BoundField DataField="mother_id" HeaderText="Mother ID" />
                        <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                        <asp:BoundField DataField="child_name" HeaderText="Child Name" />
                        <asp:BoundField DataField="pw_name" HeaderText="Mother Name" />
                        <asp:BoundField DataField="pw_husband_name" HeaderText="Father Name" />
                        <asp:BoundField DataField="dob" HeaderText="DOB" />
                        <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                        <asp:BoundField DataField="dod" HeaderText="DOD" />
                        <asp:BoundField DataField="" HeaderText="DOD_age" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="bcg0_card_history" HeaderText="bcg0 card / history" />
                        <asp:BoundField DataField="bcg0_date" HeaderText="BCG0_date" />
                        <asp:BoundField DataField="bcg0_aku_vpt" HeaderText="bcg0 aku/vpt" />
                        <asp:BoundField DataField="opv0_card_history" HeaderText="opv0 card / history" />
                        <asp:BoundField DataField="opv0_date" HeaderText="OPV0_date" />
                        <asp:BoundField DataField="opv0_aku_vpt" HeaderText="opv0 aku/vpt" />
                        <asp:BoundField DataField="opv1_card_history" HeaderText="opv1 card / history" />
                        <asp:BoundField DataField="opv1_date" HeaderText="OPV1_date" />
                        <asp:BoundField DataField="opv1_aku_vpt" HeaderText="opv1 aku/vpt" />
                        <asp:BoundField DataField="penta1_card_history" HeaderText="penta1 card / history" />
                        <asp:BoundField DataField="penta1_date" HeaderText="Penta1_date" />
                        <asp:BoundField DataField="penta1_aku_vpt" HeaderText="penta1 aku/vpt" />
                        <asp:BoundField DataField="pcv1_card_history" HeaderText="pcv1 card / history" />
                        <asp:BoundField DataField="pcv1_date" HeaderText="PCV1_date" />
                        <asp:BoundField DataField="pcv1_aku_vpt" HeaderText="pcv1 aku/vpt" />
                        <asp:BoundField DataField="rota1_card_history" HeaderText="rota1 card / history" />
                        <asp:BoundField DataField="rota1_date" HeaderText="Rota1_date" />
                        <asp:BoundField DataField="rota1_aku_vpt" HeaderText="rota1 aku/vpt" />
                        <asp:BoundField DataField="opv2_card_history" HeaderText="opv2 card / history" />
                        <asp:BoundField DataField="opv2_date" HeaderText="OPV2_date" />
                        <asp:BoundField DataField="opv2_aku_vpt" HeaderText="opv2 aku/vpt" />
                        <asp:BoundField DataField="penta2_card_history" HeaderText="penta2 card / history" />
                        <asp:BoundField DataField="penta2_date" HeaderText="Penta2_date" />
                        <asp:BoundField DataField="penta2_aku_vpt" HeaderText="penta2 aku/vpt" />
                        <asp:BoundField DataField="pcv2_card_history" HeaderText="pcv2 card / history" />
                        <asp:BoundField DataField="pcv2_date" HeaderText="PCV2_date" />
                        <asp:BoundField DataField="pcv2_aku_vpt" HeaderText="pcv2 aku/vpt" />
                        <asp:BoundField DataField="rota2_card_history" HeaderText="rota2 card / history" />
                        <asp:BoundField DataField="rota2_date" HeaderText="Rota2_date" />
                        <asp:BoundField DataField="rota2_aku_vpt" HeaderText="rota2 aku/vpt" />
                        <asp:BoundField DataField="opv3_card_history" HeaderText="opv3 card / history" />
                        <asp:BoundField DataField="opv3_date" HeaderText="OPV3_date" />
                        <asp:BoundField DataField="opv3_aku_vpt" HeaderText="opv3 aku/vpt" />
                        <asp:BoundField DataField="penta3_card_history" HeaderText="penta3 card / history" />
                        <asp:BoundField DataField="penta3_date" HeaderText="Penta3_date" />
                        <asp:BoundField DataField="penta3_aku_vpt" HeaderText="penta3 aku/vpt" />
                        <asp:BoundField DataField="pcv3_card_history" HeaderText="pcv3 card / history" />
                        <asp:BoundField DataField="pcv3_date" HeaderText="PCV3_date" />
                        <asp:BoundField DataField="pcv3_aku_vpt" HeaderText="pcv3 aku/vpt" />
                        <asp:BoundField DataField="ipv_card_history" HeaderText="ipv card / history" />
                        <asp:BoundField DataField="ipv_date" HeaderText="IPV_date" />
                        <asp:BoundField DataField="ipv_aku_vpt" HeaderText="ipv aku/vpt" />
                        <asp:BoundField DataField="measles1" HeaderText="Measles 1" />
                        <asp:BoundField DataField="measles2" HeaderText="Measles 2" />

                        <asp:BoundField DataField="" HeaderText="Pending_After_Birth" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_6_Weeks" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_10_Weeks" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_14_Weeks" />

                    </Columns>

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>




                <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="vaccination_id" HeaderText="vaccination_id" />
                        <asp:BoundField DataField="mother_id" HeaderText="Mother ID" />
                        <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                        <asp:BoundField DataField="child_name" HeaderText="Child Name" />
                        <asp:BoundField DataField="pw_name" HeaderText="Mother Name" />
                        <asp:BoundField DataField="pw_husband_name" HeaderText="Father Name" />
                        <asp:BoundField DataField="dob" HeaderText="DOB" />
                        <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                        <asp:BoundField DataField="dod" HeaderText="DOD" />
                        <asp:BoundField DataField="" HeaderText="DOD_age" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="bcg0_card_history" HeaderText="bcg0 card / history" />
                        <asp:BoundField DataField="bcg0_date" HeaderText="BCG0_date" />
                        <asp:BoundField DataField="bcg0_aku_vpt" HeaderText="bcg0 aku/vpt" />
                        <asp:BoundField DataField="opv0_card_history" HeaderText="opv0 card / history" />
                        <asp:BoundField DataField="opv0_date" HeaderText="OPV0_date" />
                        <asp:BoundField DataField="opv0_aku_vpt" HeaderText="opv0 aku/vpt" />
                        <asp:BoundField DataField="opv1_card_history" HeaderText="opv1 card / history" />
                        <asp:BoundField DataField="opv1_date" HeaderText="OPV1_date" />
                        <asp:BoundField DataField="opv1_aku_vpt" HeaderText="opv1 aku/vpt" />
                        <asp:BoundField DataField="penta1_card_history" HeaderText="penta1 card / history" />
                        <asp:BoundField DataField="penta1_date" HeaderText="Penta1_date" />
                        <asp:BoundField DataField="penta1_aku_vpt" HeaderText="penta1 aku/vpt" />
                        <asp:BoundField DataField="pcv1_card_history" HeaderText="pcv1 card / history" />
                        <asp:BoundField DataField="pcv1_date" HeaderText="PCV1_date" />
                        <asp:BoundField DataField="pcv1_aku_vpt" HeaderText="pcv1 aku/vpt" />
                        <asp:BoundField DataField="rota1_card_history" HeaderText="rota1 card / history" />
                        <asp:BoundField DataField="rota1_date" HeaderText="Rota1_date" />
                        <asp:BoundField DataField="rota1_aku_vpt" HeaderText="rota1 aku/vpt" />
                        <asp:BoundField DataField="opv2_card_history" HeaderText="opv2 card / history" />
                        <asp:BoundField DataField="opv2_date" HeaderText="OPV2_date" />
                        <asp:BoundField DataField="opv2_aku_vpt" HeaderText="opv2 aku/vpt" />
                        <asp:BoundField DataField="penta2_card_history" HeaderText="penta2 card / history" />
                        <asp:BoundField DataField="penta2_date" HeaderText="Penta2_date" />
                        <asp:BoundField DataField="penta2_aku_vpt" HeaderText="penta2 aku/vpt" />
                        <asp:BoundField DataField="pcv2_card_history" HeaderText="pcv2 card / history" />
                        <asp:BoundField DataField="pcv2_date" HeaderText="PCV2_date" />
                        <asp:BoundField DataField="pcv2_aku_vpt" HeaderText="pcv2 aku/vpt" />
                        <asp:BoundField DataField="rota2_card_history" HeaderText="rota2 card / history" />
                        <asp:BoundField DataField="rota2_date" HeaderText="Rota2_date" />
                        <asp:BoundField DataField="rota2_aku_vpt" HeaderText="rota2 aku/vpt" />
                        <asp:BoundField DataField="opv3_card_history" HeaderText="opv3 card / history" />
                        <asp:BoundField DataField="opv3_date" HeaderText="OPV3_date" />
                        <asp:BoundField DataField="opv3_aku_vpt" HeaderText="opv3 aku/vpt" />
                        <asp:BoundField DataField="penta3_card_history" HeaderText="penta3 card / history" />
                        <asp:BoundField DataField="penta3_date" HeaderText="Penta3_date" />
                        <asp:BoundField DataField="penta3_aku_vpt" HeaderText="penta3 aku/vpt" />
                        <asp:BoundField DataField="pcv3_card_history" HeaderText="pcv3 card / history" />
                        <asp:BoundField DataField="pcv3_date" HeaderText="PCV3_date" />
                        <asp:BoundField DataField="pcv3_aku_vpt" HeaderText="pcv3 aku/vpt" />
                        <asp:BoundField DataField="ipv_card_history" HeaderText="ipv card / history" />
                        <asp:BoundField DataField="ipv_date" HeaderText="IPV_date" />
                        <asp:BoundField DataField="ipv_aku_vpt" HeaderText="ipv aku/vpt" />
                        <asp:BoundField DataField="measles1" HeaderText="Measles 1" />
                        <asp:BoundField DataField="measles2" HeaderText="Measles 2" />

                        <asp:BoundField DataField="" HeaderText="Pending_After_Birth" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_6_Weeks" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_10_Weeks" />
                        <asp:BoundField DataField="" HeaderText="Pending_Greater_14_Weeks" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
