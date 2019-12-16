<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="searchChild.aspx.cs" Inherits="caplowanthro.searchChild" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        //function clicknext() {
        //    if (document.getElementById("txtdssid").value == '' || document.getElementById("txtdssid").value.length < 3) {
        //        alert("Enter minimum 3 digit value!")
        //        document.getElementById("txtdssid").focus();
        //        return false;
        //    }
         //}


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



    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Search Child
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


        <div class="RadioSpaceWeb">
            <asp:RadioButton ID="radioChildStatus1" Checked="true" CssClass="RadioSpace" Text="Study ID" ClientIDMode="Static" GroupName="searchBy" runat="server" />
            <asp:RadioButton ID="radioChildStatus2" CssClass="RadioSpace" Text="DSSID" ClientIDMode="Static" GroupName="searchBy" runat="server" /><br>
        </div>

        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">

            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">

                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" type="tel" placeholder="Study ID / DSSID" onkeypress="return isNumberKey(event)" MaxLength="5" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; height: 490px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">

                <Columns>

                    <asp:TemplateField HeaderText="Study ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudyID" OnClick="Link_Studyid" Text='<%#Eval("Study_ID") %>' CommandArgument='<%#Eval("aid")%>'  runat="server" ToolTip="Open Followups"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DSSID" HeaderText="DSSID" />
                    <asp:BoundField DataField="child_nm" HeaderText="Child Name" />
                    <asp:BoundField DataField="mother_nm" HeaderText="Mother Name" />
                    <asp:BoundField DataField="father_nm" HeaderText="Father Name" />
                    <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                </Columns>

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
