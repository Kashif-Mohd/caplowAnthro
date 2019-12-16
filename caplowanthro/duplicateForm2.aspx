<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="duplicateForm2.aspx.cs" Inherits="caplowanthro.duplicateForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 24px;">
            Duplicate Form-2:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">
        <div runat="server" id="div_Main">
            <div style="text-align: center; margin-top: -5px; margin-bottom: 15px">
                <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                    Export Records &nbsp<span class="glyphicon glyphicon-export"></span>
                </button>
            </div>
            <div style="width: 100%; overflow: auto">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unique Mother ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="Linkunique_mother_id" OnClick="Link_unique_mother_id" Text='<%#Eval("unique_id_fup") %>' runat="server" ToolTip="Show Detail"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="total" HeaderText="Total" />
                        <asp:BoundField DataField="pw_name" HeaderText="Woman Name" />
                        <asp:BoundField DataField="pw_husband_name" HeaderText="Husband Name" />
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" Height="35px" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

                <br />

                <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
                </asp:GridView>
            </div>
        </div>




        <div runat="server" id="div_ShowForm" visible="false">

            <div id="divBackButton" runat="server" style="margin-top: 5px; font-size: 18px">
                <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
                    <span class="glyphicon glyphicon-chevron-left"></span>Back
                </button>
            </div>
            <br />


            <div style="width: 100%; overflow: auto">
                <asp:GridView ID="GridView3" runat="server" EmptyDataText="No Record Found." AllowPaging="false" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="true">

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


        </div>
    </div>
</asp:Content>
