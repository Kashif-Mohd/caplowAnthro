<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="followupsSecA.aspx.cs" Inherits="caplowanthro.followupsSecA" Culture="en-GB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        /*change Color of Radio Button*/

        .RomanEnglish {
            color: #BE90D4;
            margin-top: 0.5em;
        }

        /* For Label CSS */
        .labelCSS {
            font-family: Calibri;
            font-size: 1.1em;
            color: #00b894;
            /*#446CB3          #3A539B*/
        }

        /* For Textbox CSS */
        .textBoxCSS {
            font-size: 1em;
            font-family: Calibri;
            Height: 2.4em;
            color: #007d64;
        }


        /* For First Column of Table (Questions)*/
        .TableColumn {
            color: #FF4081;
            font-family: Trebuchet MS;
            font-size: 1.3em;
            height: auto;
        }





        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            .spaceMob {
                padding-top: 70px;
            }



            thead th {
                display: none;
            }

            td[data-th]:before {
                content: attr(data-th);
            }



            /* own design*/
            table {
                border-collapse: collapse;
                width: 100%;
            }

            .trCSS {
                border-bottom: 1px solid #ddd;
            }

            .tdCSS, th {
                margin-top: 1em;
                margin-bottom: 1em;
                display: block;
                font-family: Trebuchet MS;
                text-align: center;
            }

            .tdCSScenter {
                margin-left: 37%;
                margin-top: 1em;
                margin-bottom: 1em;
                display: block;
                font-family: Trebuchet MS;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }

            .ColumTOP {
                padding-top: 2.2em;
            }

            .ColumBOTTOM {
                padding-bottom: 1em;
            }
        }







        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .SpaceLabelCRF {
                padding-left: 48%;
            }

            .SpaceLabelVisit {
                padding-left: 46%;
            }

            .buttonWeb {
                width: 22%;
                margin-left: 38%;
            }

            table {
                border-collapse: collapse;
                width: 100%;
            }

            th, .tdCSS {
                width: 50%;
                padding: 7px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .tdCSScenter {
                width: 50%;
                padding: 7px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .Mobile {
                padding-left: 5%;
                text-align: center;
                width: 95%;
            }

            .trCSS {
                height: 70px;
            }
        }
    </style>


    <script type="text/javascript">
        window.onload = function () {

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 35px; font-size: 28px; word-spacing: 5px; color: white; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Follow-ups Form</b></h1>
    </div>

    <br>
    <div style="text-align: center">

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">

            <div class="Mobile">
                <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">DSSID</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeDSSID" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Study ID</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeStudyID" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS" colspan="2">CRF&nbsp   
                            <asp:Label ID="lbeCRF" runat="server" Text="" CssClass="labelCSS SpaceLabelCRF" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS" colspan="2">Visit ID&nbsp                     
                            <asp:Label ID="lbeVisit" runat="server" Text="" CssClass="labelCSS SpaceLabelVisit" Font-Bold="true"></asp:Label>
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Child Name</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeChNm" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Mother Name</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeMotherNm" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Age (in days)</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeAge" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>

                    <tr class="trCSS">
                        <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Mid Upper Arm Circumference (MUAC) of Child (in cm)
                                <br>
                            <td class="tdCSS">
                                <%--MUAC start--%>
                                <table>
                                    <thead>
                                        <tr class="trCSS">
                                            <th>Reading 1</th>
                                            <th>Reading 2</th>
                                            <th>Difference</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="trCSS" id="divMUAC1">
                                            <td class="tdCSS" data-th="Reading 1">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACaR1" type="tel" placeholder="reading 1"  MaxLength="3" runat="server"></asp:TextBox>
                                              <%--  <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtMUACaR1" Mask="99.9" MaskType="None" />--%>
                                                <cc1:MaskedEditExtender ID="meeRequestByPhone" runat="server" TargetControlID="txtMUACaR1" Mask="99.9" ClearMaskOnLostFocus="false" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="None" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="Left" Filtered="-" ErrorTooltipEnabled="True" />
                                            </td>
                                            <td class="tdCSS" data-th="Reading 2">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACaR2" type="tel" placeholder="reading 2" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtMUACaR2" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />

                                            </td>
                                            <td class="tdCSS" data-th="Difference">
                                                <asp:Label ID="lbeq20a" runat="server" Text="0.5a" CssClass="labelCSS"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr class="trCSS" style="display:none" id="divMUAC2">
                                            <td data-th="Reading 1" class="tdCSS ColumTOP ">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACbR1" type="tel" placeholder="reading 1b" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtMUACbR1" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />
                                            </td>
                                            <td data-th="Reading 2" class="tdCSS">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACbR2" type="tel" placeholder="reading 2b" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtMUACbR2" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />
                                            </td>
                                            <td data-th="Difference" class="tdCSS">
                                                <asp:Label ID="lbeq20b" runat="server" Text="0.5b" CssClass="labelCSS"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr class="trCSS" style="display:none" id="divMUAC3">
                                            <td data-th="Reading 1" class="ColumTOP tdCSS">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACcR1" type="tel" placeholder="reading 1c" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtMUACcR1" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />
                                            </td>
                                            <td data-th="Reading 2" class="tdCSS">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACcR2" type="tel" placeholder="reading 2c" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtMUACcR2" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />
                                            </td>


                                            <td data-th="Difference" class="tdCSS">
                                                <asp:Label ID="lbeq20c" runat="server" Text="0.5c" CssClass="labelCSS"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr class="trCSS" style="display:none" id="divMUAC4">
                                            <td data-th="Reading 1" class="tdCSS ColumTOP ">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACdR1" type="tel" placeholder="reading 1d" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtMUACdR1" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />

                                            </td>
                                            <td data-th="Reading 2" class="tdCSS">
                                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtMUACdR2" type="tel" placeholder="reading 2d" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtMUACdR2" Mask="99.9" MaskType="Number" ClearMaskOnLostFocus="false" InputDirection="LeftToRight" />
                                            </td>
                                            <td data-th="Difference" class="tdCSS">
                                                <asp:Label ID="lbeq20d" runat="server" Text="0.5d" CssClass="labelCSS"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="Tr1">
                                            <td colspan="3" style="text-align:center"  class="tdCSS">
                                                <asp:Button ID="btnCheckMUAC" runat="server" Text="Check" class="btn btn-success btn-lg" OnClientClick="return clicknext();" />

                                            </td>

                                        </tr>
                                    </tbody>
                                </table>
                                <%--MUAC End--%>
                            </td>
                    </tr>








                    <tr id="divCh1a" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS spaceMob" colspan="2">

                            <h3 style="text-align: center; margin-top: 35px; font-size: 20px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #1abc9c; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>First Child</b></h3>
                        </td>
                    </tr>

                    <tr class="trCSS" id="divCh1b" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtChildName1" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="child name" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divCh1c" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Gender</td>
                        <td class="Space tdCSS">
                            <asp:DropDownList ID="DropDownListGenderCh1" CssClass="form-control textBoxCSS" ClientIDMode="Static" data-style="btn-primary" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                                <asp:ListItem Value="9">Don't Know</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>








                </table>


                <br>
                <br>
                <br>
                <br>
                <div class="buttonWeb">

                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClientClick="return clicknext();" />
                </div>
            </div>
        </asp:Panel>



        <br>
    </div>
</asp:Content>
