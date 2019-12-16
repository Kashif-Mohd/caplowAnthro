<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="chEnroll.aspx.cs" Inherits="caplowanthro.chEnroll" Culture="en-GB" %>

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
            if (document.getElementById("radioChildStatus1").checked == true) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
            }
            else if (document.getElementById("radioChildStatus2").checked == true) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
                document.getElementById("divCh2a").style.display = 'table-row';
                document.getElementById("divCh2b").style.display = 'table-row';
                document.getElementById("divCh2c").style.display = 'table-row';
            }
            else if (document.getElementById("radioChildStatus3").checked == true) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
                document.getElementById("divCh2a").style.display = 'table-row';
                document.getElementById("divCh2b").style.display = 'table-row';
                document.getElementById("divCh2c").style.display = 'table-row';
                document.getElementById("divCh3a").style.display = 'table-row';
                document.getElementById("divCh3b").style.display = 'table-row';
                document.getElementById("divCh3c").style.display = 'table-row';
            }
        }



        function GetRadioValues(chkBoxID) {
            var chkRadio1 = document.getElementById('<%= radioChildStatus1.ClientID %>');
            var chkRadio2 = document.getElementById('<%= radioChildStatus2.ClientID %>');
            var chkRadio3 = document.getElementById('<%= radioChildStatus3.ClientID %>');

            if (chkRadio1.checked) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
                document.getElementById("divCh2a").style.display = 'none';
                document.getElementById("divCh2b").style.display = 'none';
                document.getElementById("divCh2c").style.display = 'none';
                document.getElementById("divCh3a").style.display = 'none';
                document.getElementById("divCh3b").style.display = 'none';
                document.getElementById("divCh3c").style.display = 'none';
            }
            else if (chkRadio2.checked) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
                document.getElementById("divCh2a").style.display = 'table-row';
                document.getElementById("divCh2b").style.display = 'table-row';
                document.getElementById("divCh2c").style.display = 'table-row';
                document.getElementById("divCh3a").style.display = 'none';
                document.getElementById("divCh3b").style.display = 'none';
                document.getElementById("divCh3c").style.display = 'none';
            }
            else if (chkRadio3.checked) {
                document.getElementById("divCh1a").style.display = 'table-row';
                document.getElementById("divCh1b").style.display = 'table-row';
                document.getElementById("divCh1c").style.display = 'table-row';
                document.getElementById("divCh2a").style.display = 'table-row';
                document.getElementById("divCh2b").style.display = 'table-row';
                document.getElementById("divCh2c").style.display = 'table-row';
                document.getElementById("divCh3a").style.display = 'table-row';
                document.getElementById("divCh3b").style.display = 'table-row';
                document.getElementById("divCh3c").style.display = 'table-row';
            }

        }




        function clicknext() {

            if (document.getElementById("ddParaList").value == '0') {
                alert("Select Para!")
                document.getElementById("ddParaList").focus();
                return false;
            }

            else if (document.getElementById("txtBlock").value == '' || document.getElementById("txtBlock").value.length < 2) {
                alert("Enter Block 2 digit long!")
                document.getElementById("txtBlock").focus();
                return false;
            }

            else if (document.getElementById("txtStruct").value == '' || document.getElementById("txtStruct").value.length < 3) {
                alert("Enter Structure!")
                document.getElementById("txtStruct").focus();
                return false;
            }
            else if (document.getElementById("txtHH").value == '') {
                alert("Enter House Hold!")
                document.getElementById("txtHH").focus();
                return false;
            }
            else if (document.getElementById("txtwmNo").value == '' || (document.getElementById("txtwmNo").value < 1 || document.getElementById("txtwmNo").value > 9)) {
                alert("Enter Woman Number between 1 to 9")
                document.getElementById("txtwmNo").focus();
                return false;
            }
            else if (document.getElementById("txtStudyID").value == '' || document.getElementById("txtStudyID").value.length != 5) {
                alert("Enter Study ID 5 digit long!")
                document.getElementById("txtStudyID").focus();
                return false;
            }
            else if (document.getElementById("txtMotherNm").value == '') {
                alert("Enter Mother Name!")
                document.getElementById("txtMotherNm").focus();
                return false;
            }
            else if (document.getElementById("txtFatherNm").value == '') {
                alert("Enter Father Name!")
                document.getElementById("txtFatherNm").focus();
                return false;
            }

            else if (document.getElementById("radioChildStatus1").checked == false && document.getElementById("radioChildStatus2").checked == false && document.getElementById("radioChildStatus3").checked == false) {
                alert("Select Child Status!")
                document.getElementById("radioChildStatus1").focus();
                return false;
            }
            else if (document.getElementById("txtDOB").value == '') {
                alert("Select Date of Birth!")
                document.getElementById("txtDOB").focus();
                return false;
            }


            else if (document.getElementById("txtChildName1").value == '') {
                alert("Enter Child Name!")
                document.getElementById("txtChildName1").focus();
                return false;
            }
            else if (document.getElementById("DropDownListGenderCh1").value == '0') {
                alert("Select Gender!")
                document.getElementById("DropDownListGenderCh1").focus();
                return false;
            }



            else if ((document.getElementById("radioChildStatus2").checked == true || document.getElementById("radioChildStatus3").checked == true) && document.getElementById("txtChildName2").value == '') {
                alert("Enter Second Child Name!")
                document.getElementById("txtChildName2").focus();
                return false;
            }
            else if ((document.getElementById("radioChildStatus2").checked == true || document.getElementById("radioChildStatus3").checked == true) && document.getElementById("DropDownListGenderCh2").value == '0') {
                alert("Select Second Child Gender!")
                document.getElementById("DropDownListGenderCh2").focus();
                return false;
            }


            else if (document.getElementById("radioChildStatus3").checked == true && document.getElementById("txtChildName3").value == '') {
                alert("Enter Third Child Name!")
                document.getElementById("txtChildName3").focus();
                return false;
            }
            else if (document.getElementById("radioChildStatus3").checked == true && document.getElementById("DropDownListGenderCh3").value == '0') {
                alert("Select Third Child Gender!")
                document.getElementById("DropDownListGenderCh3").focus();
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 35px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>CHILD ENROLLMENT!</b></h1>
    </div>

    <br>
    <div style="text-align: center">

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
            <div class="Mobile">
                <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">SITE</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeAssess" runat="server" Text="REHRI GOTH" CssClass="labelCSS" Font-Bold="true"></asp:Label>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Para</td>
                        <td class="Space tdCSS">

                            <asp:DropDownList ID="ddParaList" CssClass="form-control textBoxCSS" data-style="btn-primary" ClientIDMode="Static" runat="server">
                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="AG">AG</asp:ListItem>
                                <asp:ListItem Value="AJ">AJ</asp:ListItem>
                                <asp:ListItem Value="BG">BG</asp:ListItem>
                                <asp:ListItem Value="CG">CG</asp:ListItem>
                                <asp:ListItem Value="DG">DG</asp:ListItem>
                                <asp:ListItem Value="DP">DP</asp:ListItem>
                                <asp:ListItem Value="IA">IA</asp:ListItem>
                                <asp:ListItem Value="KA">KA</asp:ListItem>
                                <asp:ListItem Value="KB ">KB</asp:ListItem>
                                <asp:ListItem Value="KC">KC</asp:ListItem>
                                <asp:ListItem Value="KJ">KJ</asp:ListItem>
                                <asp:ListItem Value="LA">LA</asp:ListItem>
                                <asp:ListItem Value="LB">LB</asp:ListItem>
                                <asp:ListItem Value="MA">MA</asp:ListItem>
                                <asp:ListItem Value="MB">MB</asp:ListItem>
                                <asp:ListItem Value="MP">MP</asp:ListItem>
                                <asp:ListItem Value="PP">PP</asp:ListItem>
                                <asp:ListItem Value="QP">QP</asp:ListItem>
                                <asp:ListItem Value="SH">SH</asp:ListItem>
                                <asp:ListItem Value="SR">SR</asp:ListItem>
                                <asp:ListItem Value="SD">SD</asp:ListItem>
                                <asp:ListItem Value="WP">WP</asp:ListItem>

                                <%-- <asp:ListItem Value="KG">KG</asp:ListItem>--%>
                            </asp:DropDownList>
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Block</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtBlock" type="tel" placeholder="eg. 12" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Structure</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtStruct" type="tel" placeholder="eg. 123" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Family / House Hold</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtHH" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" placeholder="eg. A" Height="2.3em" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Woman Number</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtwmNo" type="tel" placeholder="eg. 1" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>


                    <tr class="trCSS">
                        <td class="TableColumn tdCSS spaceMob">Study ID</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtStudyID" type="tel" placeholder="eg. 12345" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="5" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Mother Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtMotherNm" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="mother name" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Father Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtFatherNm" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" placeholder="father name" Height="2.3em" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Child Status</td>
                        <td class="Space tdCSScenter">

                            <!--Radio group-->
                            <asp:RadioButton ID="radioChildStatus1" CssClass="RadioSpace" onclick="GetRadioValues('radioChildStatus1')" Text="Singleton (1 baby)" ClientIDMode="Static" GroupName="childSta" runat="server" /><br>
                            <asp:RadioButton ID="radioChildStatus2" CssClass="RadioSpace" onclick="GetRadioValues('radioChildStatus2')" Text="Twins (2 babies)" ClientIDMode="Static" GroupName="childSta" runat="server" /><br>
                            <asp:RadioButton ID="radioChildStatus3" CssClass="RadioSpace" onclick="GetRadioValues('radioChildStatus3')" Text="Triplets (3 babies)" ClientIDMode="Static" GroupName="childSta" runat="server" />
                            <!--Radio group-->
                        </td>
                    </tr>


                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Date of Birth</td>
                        <td class="Space tdCSS">
                            <asp:TextBox ID="txtDOB" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx textBoxCSS" placeholder="dd/MM/yyyy" Height="32px" runat="server" Width="9.0em"></asp:TextBox>
                            <asp:ImageButton ID="btnDOB" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB" PopupButtonID="btnDOB" Format="dd/MM/yyyy" />
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






                    <tr id="divCh2a" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS spaceMob" colspan="2">
                            <h3 style="text-align: center; margin-top: 35px; font-size: 20px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #1abc9c; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Second Child</b></h3>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divCh2b" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtChildName2" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="child name" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divCh2c" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Gender</td>
                        <td class="Space tdCSS">
                            <asp:DropDownList ID="DropDownListGenderCh2" CssClass="form-control textBoxCSS" ClientIDMode="Static" data-style="btn-primary" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                                <asp:ListItem Value="9">Don't Know</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>




                    <tr id="divCh3a" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS spaceMob" colspan="2">
                            <h3 style="text-align: center; margin-top: 35px; font-size: 20px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #1abc9c; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Third Child</b></h3>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divCh3b" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtChildName3" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="child name" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="divCh3c" style="display: none" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Gender</td>
                        <td class="Space tdCSS">
                            <asp:DropDownList ID="DropDownListGenderCh3" CssClass="form-control textBoxCSS" ClientIDMode="Static" data-style="btn-primary" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                                <asp:ListItem Value="9">Don't Know</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>


                <br>
                <br>
                <br>
                <br>
                <div class="buttonWeb">

                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block"  OnClick="submit_Click" OnClientClick="return clicknext();" />
                </div>
            </div>
        </asp:Panel>



        <br>
    </div>

</asp:Content>
