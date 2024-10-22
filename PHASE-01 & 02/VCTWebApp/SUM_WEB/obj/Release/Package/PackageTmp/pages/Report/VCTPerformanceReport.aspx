<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTPerformanceReport.aspx.cs" Inherits="VCTWebApp.VCTPerformanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .has-feedback {
            left: 0px !important;
            width: 100% !important;
        }

        .auto-style4 {
            width: 200px;
            height: 60px;
        }

        .auto-style5 {
            width: 10px;
            height: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12">
        <div class="messagealert col-md-6" id="alert_container"></div>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Performance OK FG Report
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">Performance OK FG Report</a></li>
        </ol>
    </section>
    <div class="col-xs-12">
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="DivEntry" runat="server" class="box-header">
                        <span style="color: Red;">* Mandatory Fields</span>

                        <table id="tblentry" runat="server" class="table" style="width: 95%; margin-left: 0%; margin-right: 5%;"
                            cellspacing="3" cellpadding="3">
                            <tr>
                                <td style="text-align: right; width: 200px">File Date<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtFileDate" runat="server" ValidationGroup="Submit" AutoPostBack="true" TabIndex="6" OnTextChanged="txtFileDate_TextChanged" MaxLength="50" Style="text-transform: uppercase; display: inline"
                                        placeholder="Select From Date" class="form-control"></asp:TextBox>

                                </td>
                                <td style="text-align: right; width: 200px">Line <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlLine" ToolTip="Select Line" class="form-control" AutoPostBack="true" ValidationGroup="Submit" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged">
                                            <asp:ListItem Text="--SELECT--" Value="--Select--"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RFV_GrpCode" ValidationGroup="Submit" InitialValue="-- Select Line --"
                                        runat="server" ControlToValidate="ddlLine" Display="Dynamic" ErrorMessage="Please Select Line" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>

                            </tr>

                            <tr>

                                <td style="text-align: right; width: 200px">Station <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlStation" ToolTip="Select Station" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStation_SelectedIndexChanged" ValidationGroup="Submit" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Submit" InitialValue="-- Select Station --"
                                        runat="server" ControlToValidate="ddlStation" Display="Dynamic" ErrorMessage="Please Select Station" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>
                                <td style="text-align: right; width: 200px">Part
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlPart" ToolTip="Select Part" class="form-control" ValidationGroup="Submit" AutoPostBack="true" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlChildPart_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit" InitialValue="-- Select Part --"
                                        runat="server" ControlToValidate="ddlPart" Display="Dynamic" ErrorMessage="Please Select Part" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>


                                </td>
                            </tr>




                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button ID="btnShow" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Search" OnClientClick="return ValidEntry();" ValidationGroup="Save" OnClick="btnShow_Click" />&nbsp;
                                  
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="ClearFields();" TabIndex="8" ToolTip="Reset/Clear group master fields"
                                Text="Reset" OnClick="btnReset_Click" />&nbsp;
                                        <asp:Button ID="btnExport" runat="server" TabIndex="10" CssClass="btn-lg"
                                            ToolTip="Export data into excel file" Text="Export" CausesValidation="false"
                                            OnClick="btnExport_Click" />

                                </td>
                            </tr>
                        </table>

                    </div>
                    <div id="DivShow" runat="server" visible="false" autopostback="true">
                        <asp:Label ID="lblRecords" runat="server" Text="No. of Records: "></asp:Label>
                        <div id="DivGrid" runat="server" style="overflow: auto; width: 100%;">

                            <asp:GridView ID="gvUserMaster" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                                PageSize="10" PagerStyle-CssClass="pgr" DataKeyNames="Station" OnPageIndexChanging="gvVCTDashboard_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Line" DataField="Line" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Station" DataField="Station" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Part" DataField="Model" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Data Count" DataField="Serial" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>


                                </Columns>
                                <FooterStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <PagerStyle CssClass="pgr"></PagerStyle>
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>

                        </div>

                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnShow" />
                    <asp:PostBackTrigger ControlID="btnReset" />
                    <asp:PostBackTrigger ControlID="ddlLine" />
                    <asp:PostBackTrigger ControlID="ddlStation" />
                    <asp:PostBackTrigger ControlID="ddlPart" />
                    <asp:PostBackTrigger ControlID="txtFileDate" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $('#ContentPlaceHolder1_txtFileDate').datetimepicker({
            format: 'Y-m-d',


            timepicker: false
        });

        function ClearFields() {

        }

        function ValidEntry() {
            var line = document.getElementById('<%= ddlLine.ClientID %>').value;
            var ddlprocess = document.getElementById('<%= ddlPart.ClientID %>').value;
            var ddlstation = document.getElementById('<%= ddlStation.ClientID %>').value;
            var fromdate = document.getElementById('<%= txtFileDate.ClientID %>').value;



            if (line === "") {
                ShowMessage("Please Select Line.", Warning);
                document.getElementById("<%=ddlLine.ClientID%>").focus();
                return false;
            }
            else if (ddlprocess === "") {
                ShowMessage("Please Select Part", Warning);
                document.getElementById("<%=ddlStation.ClientID%>").focus();
                return false;
            }
            else if (ddlstation === "") {
                ShowMessage("Please Select Station", Warning);
                document.getElementById("<%=ddlStation.ClientID%>").focus();
                return false;
            }
            else if (fromdate === "") {
                ShowMessage("Please Select file date", Warning);
                document.getElementById("<%=txtFileDate.ClientID%>").focus();
                return false;
            }



        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
