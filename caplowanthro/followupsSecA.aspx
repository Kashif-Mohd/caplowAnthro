<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="followupsSecA.aspx.cs" Inherits="caplowanthro.followupsSecA" Culture="ar-DZ" %>

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
            if (document.getElementById("txtq17").value == '2') {
                document.getElementById("divQ18").style.display = 'table-row';
                document.getElementById("divQ19").style.display = 'table-row';
            }
        }







        // Followups Status 

        function skipQ16(id) {
            var val = document.getElementById(id).value;
            if (val != 1 && val != '' && val != '2') {
                document.getElementById("txtq16Reason").value = '';
                document.getElementById("txtq17").value = '';
                document.getElementById("txtq18").value = '';
                document.getElementById("txtq19").value = '';
                document.getElementById("txtBabyWeight1").value = '';
                document.getElementById("txtBabyWeight2").value = '';
                document.getElementById("txtBabyLength1").value = '';
                document.getElementById("txtBabyLength2").value = '';
                document.getElementById("txtBabyMUAC1").value = '';
                document.getElementById("txtBabyMUAC2").value = '';
                document.getElementById("txtBabyHeadCircum1").value = '';
                document.getElementById("txtBabyHeadCircum2").value = '';
                document.getElementById("txtq28").value = '';
                document.getElementById("txtq29").value = '';
                document.getElementById("txtq30").value = '';
                document.getElementById("txtq35").value = '';
                document.getElementById("txtq36").value = '';
                document.getElementById("txtq37").value = '';
                document.getElementById("txtq38").value = '';
                document.getElementById("txtq39").value = '';
                document.getElementById("txtq40").value = '';
                document.getElementById("txtq41").value = '';
                document.getElementById("txtq42").value = '';
                document.getElementById("txtq43").value = '';
                document.getElementById("txtq44").value = '';
                document.getElementById("divQ16Reason").style.display = "none";
                document.getElementById("divQ17").style.display = "none";
                document.getElementById("divQ18").style.display = "none";
                document.getElementById("divQ19").style.display = "none";
                document.getElementById("divQ28").style.display = "none";
                document.getElementById("divQ29").style.display = "none";
                document.getElementById("divQ30").style.display = "none";
                document.getElementById("divQ35").style.display = "none";
                document.getElementById("divQ36").style.display = "none";
                document.getElementById("divQ37").style.display = "none";
                document.getElementById("divQ38").style.display = "none";
                document.getElementById("divQ39").style.display = "none";
                document.getElementById("divQ40").style.display = "none";
                document.getElementById("divQ41").style.display = "none";
                document.getElementById("divQ42").style.display = "none";
                document.getElementById("divQ43").style.display = "none";
                document.getElementById("divQ44").style.display = "none";
                document.getElementById("divBabyWeight").style.display = "none";

                document.getElementById("divBabyLength").style.display = "none";
                document.getElementById("divBabyMUAC").style.display = "none";
                document.getElementById("divBabyHeadCircum").style.display = "none";
            }
                //For Refused Reason Field 
            else if (val == '2') {
                document.getElementById("txtq17").value = '';
                document.getElementById("txtq18").value = '';
                document.getElementById("txtq19").value = '';
                document.getElementById("txtBabyWeight1").value = '';
                document.getElementById("txtBabyWeight2").value = '';
                document.getElementById("txtBabyLength1").value = '';
                document.getElementById("txtBabyLength2").value = '';
                document.getElementById("txtBabyMUAC1").value = '';
                document.getElementById("txtBabyMUAC2").value = '';
                document.getElementById("txtBabyHeadCircum1").value = '';
                document.getElementById("txtBabyHeadCircum2").value = '';
                document.getElementById("txtq28").value = '';
                document.getElementById("txtq29").value = '';
                document.getElementById("txtq30").value = '';
                document.getElementById("txtq35").value = '';
                document.getElementById("txtq36").value = '';
                document.getElementById("txtq37").value = '';
                document.getElementById("txtq38").value = '';
                document.getElementById("txtq39").value = '';
                document.getElementById("txtq40").value = '';
                document.getElementById("txtq41").value = '';
                document.getElementById("txtq42").value = '';
                document.getElementById("txtq43").value = '';
                document.getElementById("txtq44").value = '';
                document.getElementById("divQ16Reason").style.display = "table-row";
                document.getElementById("divQ17").style.display = "none";
                document.getElementById("divQ18").style.display = "none";
                document.getElementById("divQ19").style.display = "none";
                document.getElementById("divQ28").style.display = "none";
                document.getElementById("divQ29").style.display = "none";
                document.getElementById("divQ30").style.display = "none";
                document.getElementById("divQ35").style.display = "none";
                document.getElementById("divQ36").style.display = "none";
                document.getElementById("divQ37").style.display = "none";
                document.getElementById("divQ38").style.display = "none";
                document.getElementById("divQ39").style.display = "none";
                document.getElementById("divQ40").style.display = "none";
                document.getElementById("divQ41").style.display = "none";
                document.getElementById("divQ42").style.display = "none";
                document.getElementById("divQ43").style.display = "none";
                document.getElementById("divQ44").style.display = "none";
                document.getElementById("divBabyWeight").style.display = "none";
                document.getElementById("divBabyLength").style.display = "none";
                document.getElementById("divBabyMUAC").style.display = "none";
                document.getElementById("divBabyHeadCircum").style.display = "none";

            }
            else {
                document.getElementById("divQ16Reason").style.display = "none";
                document.getElementById("txtq16Reason").value = '';
                document.getElementById("divQ17").style.display = "table-row";
                document.getElementById("divQ18").style.display = "table-row";
                document.getElementById("divQ19").style.display = "table-row";
                document.getElementById("divQ28").style.display = "table-row";
                document.getElementById("divQ29").style.display = "table-row";
                document.getElementById("divQ30").style.display = "table-row";
                document.getElementById("divQ35").style.display = "table-row";
                document.getElementById("divQ36").style.display = "table-row";
                document.getElementById("divQ37").style.display = "table-row";
                document.getElementById("divQ38").style.display = "table-row";
                document.getElementById("divQ39").style.display = "table-row";
                document.getElementById("divQ40").style.display = "table-row";
                document.getElementById("divQ41").style.display = "table-row";
                document.getElementById("divQ42").style.display = "table-row";
                document.getElementById("divQ43").style.display = "table-row";
                document.getElementById("divQ44").style.display = "table-row";
                document.getElementById("divBabyWeight").style.display = "table-row";

                if (document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') {
                    document.getElementById("divBabyLength").style.display = "table-row";
                    document.getElementById("divBabyMUAC").style.display = "table-row";
                    document.getElementById("divBabyHeadCircum").style.display = "table-row";
                }
            }
        }


        // Child Alive or Not
        function skipQ17(id) {
            var val = document.getElementById(id).value;
            if (val == 1 || val == '') {
                //Date and Time of Death
                document.getElementById("divQ18").style.display = "none";
                document.getElementById("divQ19").style.display = "none";
                document.getElementById("txtq18").value = '';
                document.getElementById("txtq19").value = '';
                document.getElementById("divBabyWeight").style.display = "table-row";

                if (document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') {
                    document.getElementById("divBabyLength").style.display = "table-row";
                    document.getElementById("divBabyMUAC").style.display = "table-row";
                    document.getElementById("divBabyHeadCircum").style.display = "table-row";
                }
                document.getElementById("divQ28").style.display = "table-row";
                document.getElementById("divQ29").style.display = "table-row";
                document.getElementById("divQ30").style.display = "table-row";
                document.getElementById("divQ35").style.display = "table-row";
                document.getElementById("divQ36").style.display = "table-row";
                document.getElementById("divQ37").style.display = "table-row";
                document.getElementById("divQ38").style.display = "table-row";
                document.getElementById("divQ39").style.display = "table-row";
                document.getElementById("divQ40").style.display = "table-row";
                document.getElementById("divQ41").style.display = "table-row";
                document.getElementById("divQ42").style.display = "table-row";
                document.getElementById("divQ43").style.display = "table-row";
                document.getElementById("divQ44").style.display = "table-row";
            }
            else {
                //Date and Time of Death
                document.getElementById("txtBabyWeight1").value = '';
                document.getElementById("txtBabyWeight2").value = '';
                document.getElementById("txtBabyLength1").value = '';
                document.getElementById("txtBabyLength2").value = '';
                document.getElementById("txtBabyMUAC1").value = '';
                document.getElementById("txtBabyMUAC2").value = '';
                document.getElementById("txtBabyHeadCircum1").value = '';
                document.getElementById("txtBabyHeadCircum2").value = '';
                document.getElementById("txtq28").value = '';
                document.getElementById("txtq29").value = '';
                document.getElementById("txtq30").value = '';
                document.getElementById("txtq35").value = '';
                document.getElementById("txtq36").value = '';
                document.getElementById("txtq37").value = '';
                document.getElementById("txtq38").value = '';
                document.getElementById("txtq39").value = '';
                document.getElementById("txtq40").value = '';
                document.getElementById("txtq41").value = '';
                document.getElementById("txtq42").value = '';
                document.getElementById("txtq43").value = '';
                document.getElementById("txtq44").value = '';
                document.getElementById("divQ18").style.display = "table-row";
                document.getElementById("divQ19").style.display = "table-row";
                document.getElementById("divQ28").style.display = "none";
                document.getElementById("divQ29").style.display = "none";
                document.getElementById("divQ30").style.display = "none";
                document.getElementById("divQ35").style.display = "none";
                document.getElementById("divQ36").style.display = "none";
                document.getElementById("divQ37").style.display = "none";
                document.getElementById("divQ38").style.display = "none";
                document.getElementById("divQ39").style.display = "none";
                document.getElementById("divQ40").style.display = "none";
                document.getElementById("divQ41").style.display = "none";
                document.getElementById("divQ42").style.display = "none";
                document.getElementById("divQ43").style.display = "none";
                document.getElementById("divQ44").style.display = "none";
                document.getElementById("divBabyWeight").style.display = "none";
                document.getElementById("divBabyLength").style.display = "none";
                document.getElementById("divBabyMUAC").style.display = "none";
                document.getElementById("divBabyHeadCircum").style.display = "none";
            }
        }




        function skipQ28(id) {
            var val = document.getElementById(id).value;
            if (val == 2) {
                document.getElementById("divQ29").style.display = "none";
                document.getElementById("txtq29").value = '';
            }
            else {
                document.getElementById("divQ29").style.display = "table-row";
            }
        }








        function clicknext() {

            if (document.getElementById("txtChildName").value == '') {
                alert("Enter Child Name!")
                document.getElementById("txtChildName").focus();
                return false;
            }
            else if (document.getElementById("txtDOV").value == '__-__-____' || document.getElementById("txtDOV").value == '') {
                alert("Enter Date of Visit")
                document.getElementById("txtDOV").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '' || (document.getElementById("txtq16").value < 1 || document.getElementById("txtq16").value > 5)) {
                alert("Enter Value between 1 to 5 only")
                document.getElementById("txtq16").value = '';
                document.getElementById("txtq16").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '2' && document.getElementById("txtq16Reason").value == '') {
                alert("Enter Reason for Refusal")
                document.getElementById("txtq16Reason").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '' && (document.getElementById("txtq17").value < 1 || document.getElementById("txtq17").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq17").value = '';
                document.getElementById("txtq17").focus();
                return false;
            }

                // Child Death Question
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '2' && (document.getElementById("txtq18").value == '__-__-____' || document.getElementById("txtq18").value == '')) {
                alert("Enter Date of Death")
                document.getElementById("txtq18").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '2' && (document.getElementById("txtq19").value == '' || document.getElementById("txtq19").value == '__:__')) {
                alert("Enter Time of Death")
                document.getElementById("txtq19").focus();
                return false;
            }


                // Anthro Question:

                // Weight
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyWeight1").value != '00000' && ((document.getElementById("txtBabyWeight1").value == '' || (document.getElementById("txtBabyWeight1").value < 800 || document.getElementById("txtBabyWeight1").value > 11000)))) {
                alert("Enter Weight, 5 digit long between 800 to 11000")
                document.getElementById("txtBabyWeight1").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyWeight2").value != '00000' && ((document.getElementById("txtBabyWeight2").value == '' || (document.getElementById("txtBabyWeight2").value < 800 || document.getElementById("txtBabyWeight2").value > 11000)))) {
                alert("Enter Weight, 5 digit long between 800 to 11000")
                document.getElementById("txtBabyWeight2").focus();
                return false;
            }

                //Length
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '519' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyLength1").value != '00.0' && ((document.getElementById("txtBabyLength1").value == '' || document.getElementById("txtBabyLength1").value == '__._') || (document.getElementById("txtBabyLength1").value < 36.0 || document.getElementById("txtBabyLength1").value > 71.0))) {
                alert("Enter Length between 36.0 to 71.0")
                document.getElementById("txtBabyLength1").focus();
                return false;
            }
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyLength2").value != '00.0' && ((document.getElementById("txtBabyLength2").value == '' || document.getElementById("txtBabyLength2").value == '__._') || (document.getElementById("txtBabyLength2").value < 36.0 || document.getElementById("txtBabyLength2").value > 71.0))) {
                alert("Enter Length between 36.0 to 71.0")
                document.getElementById("txtBabyLength2").focus();
                return false;
            }

                //MUAC
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyMUAC1").value != '00.0' && document.getElementById("txtBabyMUAC1").value != '00.0' && ((document.getElementById("txtBabyMUAC1").value == '' || document.getElementById("txtBabyMUAC1").value == '__._') || (document.getElementById("txtBabyMUAC1").value < 5.0 || document.getElementById("txtBabyMUAC1").value > 18.0))) {
                alert("Enter MUAC between 05.0 to 18.0")
                document.getElementById("txtBabyMUAC1").focus();
                return false;
            }
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyMUAC2").value != '00.0' && document.getElementById("txtBabyMUAC2").value != '00.0' && ((document.getElementById("txtBabyMUAC2").value == '' || document.getElementById("txtBabyMUAC2").value == '__._') || (document.getElementById("txtBabyMUAC2").value < 5.0 || document.getElementById("txtBabyMUAC2").value > 18.0))) {
                alert("Enter MUAC between 05.0 to 18.0")
                document.getElementById("txtBabyMUAC2").focus();
                return false;
            }
                //Head Circum
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyHeadCircum1").value != '00.0' && ((document.getElementById("txtBabyHeadCircum1").value == '' || document.getElementById("txtBabyHeadCircum1").value == '__._') || (document.getElementById("txtBabyHeadCircum1").value < 28.0 || document.getElementById("txtBabyHeadCircum1").value > 47.0))) {
                alert("Enter Head Circum between 28.0 to 47.0")
                document.getElementById("txtBabyHeadCircum1").focus();
                return false;
            }
            else if ((document.getElementById("lbeAge").innerText == '27' || document.getElementById("lbeAge").innerText == '59' || document.getElementById("lbeAge").innerText == '89' || document.getElementById("lbeAge").innerText == '179') && document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtBabyHeadCircum2").value != '00.0' && ((document.getElementById("txtBabyHeadCircum2").value == '' || document.getElementById("txtBabyHeadCircum2").value == '__._') || (document.getElementById("txtBabyHeadCircum2").value < 28.0 || document.getElementById("txtBabyHeadCircum2").value > 47.0))) {
                alert("Enter Head Circum between 28.0 to 47.0")
                document.getElementById("txtBabyHeadCircum2").focus();
                return false;
            }

                // Q28:
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq28").value == '' && (document.getElementById("txtq28").value < 1 || document.getElementById("txtq28").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq28").value = '';
                document.getElementById("txtq28").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq28").value == '1' && (document.getElementById("txtq29").value == '' || document.getElementById("txtq29").value.length != 2)) {
                alert("Enter Time per day!")
                document.getElementById("txtq29").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq30").value == '') {
                alert("Write Q30")
                document.getElementById("txtq30").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && (document.getElementById("txtq35").value == '' || document.getElementById("txtq35").value.length != 3)) {
                alert("Enter Breathing Rates, 3 digit long!")
                document.getElementById("txtq35").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && ((document.getElementById("txtq36").value == '' || document.getElementById("txtq36").value == '__._'))) {
                alert("Enter Temperature")
                document.getElementById("txtq36").focus();
                return false;
            }



            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq37").value == '' && (document.getElementById("txtq37").value < 1 || document.getElementById("txtq37").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq37").value = '';
                document.getElementById("txtq37").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq38").value == '' && (document.getElementById("txtq38").value < 1 || document.getElementById("txtq38").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq38").value = '';
                document.getElementById("txtq38").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq39").value == '' && (document.getElementById("txtq39").value < 1 || document.getElementById("txtq39").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq39").value = '';
                document.getElementById("txtq39").focus();
                return false;
            } else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq40").value == '' && (document.getElementById("txtq40").value < 1 || document.getElementById("txtq40").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq40").value = '';
                document.getElementById("txtq40").focus();
                return false;
            } else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq41").value == '' && (document.getElementById("txtq41").value < 1 || document.getElementById("txtq41").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq41").value = '';
                document.getElementById("txtq41").focus();
                return false;
            } else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq42").value == '' && (document.getElementById("txtq42").value < 1 || document.getElementById("txtq42").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq42").value = '';
                document.getElementById("txtq42").focus();
                return false;
                }
            //else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq43").value == '' && (document.getElementById("txtq43").value < 1 || document.getElementById("txtq43").value > 2)) {
            //    alert("Enter Value 1 or 2")
            //    document.getElementById("txtq43").value = '';
            //    document.getElementById("txtq43").focus();
            //    return false;
            //}
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq44").value == '') {
                alert("Enter Danger Sign")
                document.getElementById("txtq44").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '1' && document.getElementById("txtq17").value == '1' && document.getElementById("txtq45").value == '' && (document.getElementById("txtq45").value < 1 || document.getElementById("txtq45").value > 2)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq45").value = '';
                document.getElementById("txtq45").focus();
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
        <h1 style="text-align: center; margin-top: 35px; font-size: 28px; word-spacing: 5px; color: white; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Follow-ups Form</b></h1>
    </div>

    <br>
    <div style="text-align: center">

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">

            <div class="Mobile">
                <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Mother ID</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeMotherID" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Child ID</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeChildID" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">DSSID</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeDSSID" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Followup Number</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeFollowupNum" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Age of Followup</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeAge" runat="server" Text="" ClientIDMode="Static" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Mother Name</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeMotherNm" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Father Name</td>
                        <td class="Space tdCSS">
                            <asp:Label ID="lbeFatherNm" runat="server" Text="" CssClass="labelCSS" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Child Name</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtChildName" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="child name" MaxLength="25" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Date of Visit</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtDOV" placeholder="Date" ClientIDMode="Static" Format="dd-mm-yyyy" runat="server"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtDOV" Mask="99/99/9999" MaskType="Date" />
                        </td>
                    </tr>



                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">Q16. Outcome of the visit?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq16" onkeypress="return OnlyNumeric(event)" onkeyup="skipQ16('txtq16')" Font-Size="Medium" Height="2.3em" placeholder="1 to 5" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ16Reason" runat="server" clientidmode="Static" style="display: none">
                        <td class="TableColumn tdCSS"></td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq16Reason" type="text" Font-Size="Medium" Height="2.3em" placeholder="Reason for refusal" runat="server"></asp:TextBox></td>
                    </tr>




                    <tr class="trCSS" id="divQ17" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q17. Is child currently alive?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq17" onkeypress="return OnlyNumeric(event)" onkeyup="skipQ17('txtq17')" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr class="trCSS" id="divQ18" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q18. Date of death</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtq18" placeholder="Date" ClientIDMode="Static" Format="dd-mm-yyyy" runat="server"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtq18" Mask="99/99/9999" MaskType="Date" />
                        </td>
                    </tr>

                    <tr class="trCSS" id="divQ19" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q19. Time of death</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtq19" placeholder="Time" ClientIDMode="Static" runat="server"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtq19" Mask="99:99" MaskType="Time" />
                        </td>
                    </tr>





                    <tr id="divBabyWeight" runat="server" clientidmode="Static">
                        <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Q20. Current Weight of the baby grams</td>
                        <td class="tdCSS">
                            <%--Weight Baby  start--%>
                            <table>
                                <thead>
                                    <tr class="trCSS">
                                        <th>Reading 1</th>
                                        <th>Reading 2</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="trCSS">
                                        <td class="tdCSS" data-th="Reading 1">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyWeight1" MaxLength="5" onkeypress="return OnlyNumeric(event)" placeholder="reading 1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="tdCSS" data-th="Reading 2">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyWeight2" MaxLength="5" onkeypress="return OnlyNumeric(event)" placeholder="reading 2" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--Weight Baby End--%>
                        </td>
                    </tr>

                    <tr id="divBabyLength" runat="server" clientidmode="Static">
                        <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Q22. Current Length of the baby in cm</td>
                        <td class="tdCSS">
                            <%--Length Baby start--%>
                            <table>
                                <thead>
                                    <tr class="trCSS">
                                        <th>Reading 1</th>
                                        <th>Reading 2</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="trCSS">
                                        <td class="tdCSS" data-th="Reading 1">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyLength1" placeholder="reading 1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtBabyLength1" Mask="99.9" MaskType="Number" />
                                        </td>
                                        <td class="tdCSS" data-th="Reading 2">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyLength2" placeholder="reading 2" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtBabyLength2" Mask="99.9" MaskType="Number" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--Length Baby End--%>
                        </td>
                    </tr>
                    <tr id="divBabyMUAC" runat="server" clientidmode="Static">
                        <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Q24. Mid Upper Arm Circumference (MUAC) of Child in cm </td>
                        <td class="tdCSS">
                            <%--MUAC start--%>
                            <table>
                                <thead>
                                    <tr class="trCSS">
                                        <th>Reading 1</th>
                                        <th>Reading 2</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr class="trCSS">
                                        <td class="tdCSS" data-th="Reading 1">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyMUAC1" placeholder="reading 1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBabyMUAC1" Mask="99.9" MaskType="Number" />
                                        </td>
                                        <td class="tdCSS" data-th="Reading 2">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyMUAC2" placeholder="reading 2" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtBabyMUAC2" Mask="99.9" MaskType="Number" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--MUAC End--%>
                        </td>
                    </tr>
                    <tr id="divBabyHeadCircum" runat="server" clientidmode="Static">
                        <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Q26. Current head circumference of the baby in cm</td>
                        <td class="tdCSS">
                            <%--MUAC start--%>
                            <table>
                                <thead>
                                    <tr class="trCSS">
                                        <th>Reading 1</th>
                                        <th>Reading 2</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr class="trCSS">
                                        <td class="tdCSS" data-th="Reading 1">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyHeadCircum1" placeholder="reading 1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtBabyHeadCircum1" Mask="99.9" MaskType="Number" />
                                        </td>
                                        <td class="tdCSS" data-th="Reading 2">
                                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtBabyHeadCircum2" placeholder="reading 2" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtBabyHeadCircum2" Mask="99.9" MaskType="Number" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--MUAC End--%>
                        </td>
                    </tr>


                    <tr class="trCSS" id="divQ28" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q28. Has child been on breastfeeding since last visit.</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq28" onkeypress="return OnlyNumeric(event)" onkeyup="skipQ28('txtq28')" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ29" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q29. How many times breast feeding is given each day.</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq29" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="Time per day" MaxLength="2" runat="server"></asp:TextBox>
                        </td>
                    </tr>




                    <tr class="trCSS" id="divQ30" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q30. Has child given anything to drink apart from breast milk</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq30" type="text" Font-Size="Medium" Height="2.3em" placeholder="write..." runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divQ35" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q35. Respiratory rate</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq35" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="999" MaxLength="3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ36" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q36. Temperature</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtq36" placeholder="99.9" ClientIDMode="Static" runat="server"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtq36" Mask="99.9" MaskType="Number" />
                        </td>
                    </tr>








                    <tr class="trCSS" id="divQ37" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q37. Severe chest indrawing</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq37" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ38" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q38. Poor feeding</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq38" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ39" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q39. Lethargy</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq39" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ40" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q40. Observed convulsion or history of convulsions</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq40" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ41" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q41. Skin pustule</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq41" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ42" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q42. Three or more loose or watery stools per day</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq42" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ43" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q43. Any other danger sign</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq43" type="text" Font-Size="Medium" Height="2.3em" placeholder="Mention here" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divQ44" runat="server" clientidmode="Static">
                        <td class="TableColumn tdCSS">Q44. Referral to center required?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static" ID="txtq44" onkeypress="return OnlyNumeric(event)" Font-Size="Medium" Height="2.3em" placeholder="1 or 2" MaxLength="1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>


                <br>
                <br>
                <div class="buttonWeb">

                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
                </div>
            </div>
        </asp:Panel>



        <br>
    </div>
</asp:Content>
