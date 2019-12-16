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


            <div style="padding-left: 2%; margin-top: 15px;">

                <div style="color: #009432; font-size: 22px; width: 100%">
                    Search Child to Open (Form-2):
                </div>
                <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


                <div class="RadioSpaceWeb">
                    <asp:RadioButton ID="radioChildStatus1" Checked="true" CssClass="RadioSpace" Text="Study ID" ClientIDMode="Static" GroupName="searchBy" runat="server" />
                    <asp:RadioButton ID="radioChildStatus2"  CssClass="RadioSpace" Text="DSSID" ClientIDMode="Static" GroupName="searchBy" runat="server" /><br>
                </div>

                <%--Search Button--%>
                <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">

                    <div id="imaginary_container" style="margin-top: 10px">
                        <div class="input-group stylish-input-group">

                            <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" Font-Size="1.3em" placeholder="Study ID / DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>

                </div>




                <div style="width: 100%; height: 490px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">

                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkStudyID" OnClick="Link_Studyid" Text='OPEN' CommandArgument='<%#Eval("status")+","+ Eval("pw_id")+","+ Eval("child_id")+","+ Eval("age")+","+ Eval("start_date")+","+ Eval("end_date")+","+ Eval("mother_id")+","+ Eval("followup_no")%>' runat="server" ToolTip="Open Followups"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="mother_id" HeaderText="Mother ID" />
                            <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="followup_no" HeaderText="Followups No." />
                            <asp:BoundField DataField="pw_name" HeaderText="Woman Name" />
                            <asp:BoundField DataField="husband_name" HeaderText="Husband Name" />
                            <asp:BoundField DataField="age" HeaderText="Age" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="start_date" HeaderText="Start Date" />
                            <asp:BoundField DataField="end_date" HeaderText="End Date" />
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
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
