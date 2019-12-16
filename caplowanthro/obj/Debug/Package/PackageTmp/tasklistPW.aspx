<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="tasklistPW.aspx.cs" Inherits="caplowanthro.tasklistPW" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">


         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
    </script>






    <style type="text/css">
        /* Radio Button Space */
        .RadioSpace label {
            font-family: Calibri;
            margin-left: 8px;
            color: #00b894;
        }

        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .RadioSpaceWeb {
                padding-left: 40%;
            }

            .RadioSpace {
                padding-left: 25px;
                font-size: 1.4em;
            }
        }

        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            .RadioSpace {
                display: block;
                font-size: 1.2em;
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
            Capturing List (Pending): 
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

          <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">

            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">

                    <asp:TextBox ID="txtDSSID" CssClass="form-control txtboxx" ClientIDMode="Static" Font-Size="1.3em" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>
        </div>


        <%--Start    Date checks--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="updateProgress" runat="server">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #A3CB38; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <div class="Mobile">
                    <table style="width: 100%; text-align: center; margin-left: 1%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">
                                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtCalndrDate" popupbuttonid="btnCalndrDate" format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtCalndrDate1" popupbuttonid="btnCalndrDate1" format="dd-MM-yyyy" />
                                &nbsp &nbsp 
                          <asp:CheckBox ID="CheckBox1" runat="server" Text="Disable" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--End   Date checks--%>




        <div style="width: 100%; overflow: scroll; margin-top: 15px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found."  CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="mother_id" HeaderText="Mother ID" />
                    <asp:BoundField DataField="pw_block" HeaderText="Block" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="pw_name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="pw_husband_name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="edd_based_on" HeaderText="Based On" />
                    <asp:BoundField DataField="pw_unique_code" HeaderText="PW Assistment ID" />
                    <asp:BoundField DataField="edd" HeaderText="EDD" />
                </Columns>


                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#A3CB38" ForeColor="white" Font-Bold="True" Height="40px" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>



             <asp:GridView ID="GridView2" runat="server" CssClass="footable"  ForeColor="#333333" AutoGenerateColumns="false" >     
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="mother_id" HeaderText="Mother ID" />
                    <asp:BoundField DataField="pw_block" HeaderText="Block" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="pw_name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="pw_husband_name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="edd_based_on" HeaderText="Based On" />
                    <asp:BoundField DataField="pw_unique_code" HeaderText="PW Assistment ID" />
                    <asp:BoundField DataField="edd" HeaderText="EDD" />
                </Columns>        
            </asp:GridView>

        </div>
    </div>
</asp:Content>
