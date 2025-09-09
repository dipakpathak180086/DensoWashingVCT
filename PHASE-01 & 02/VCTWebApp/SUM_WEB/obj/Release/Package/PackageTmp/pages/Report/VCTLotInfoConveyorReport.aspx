<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTLotInfoConveyorReport.aspx.cs" Inherits="VCTWebApp.VCTLotInfoConveyorReport" %>

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

        .icon-cell {
            display: flex;
            justify-content: center;
            align-items: center;
        }

      

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12">
        <div class="messagealert col-md-6" id="alert_container"></div>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Lot Info. Conveyor Report
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">Used Child Part Assy. Report</a></li>
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
                                <td style="text-align: right; width: 200px">Line <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlLine" ToolTip="Select Line" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" ValidationGroup="Submit" runat="server" TabIndex="3">
                                            <asp:ListItem Text="--SELECT--" Value="--Select--"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>


                                </td>
                                <td style="text-align: right; width: 200px">Station <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <%-- <asp:ListBox ID="lstConveyor" class="form-control" runat="server" SelectionMode="Multiple">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                        </asp:ListBox>--%>
                                        <select id="lstConveyor" runat="server" style="width: 100%;" class="form-control" multiple="true">
                                            <option value="01">01</option>
                                            <option value="02">02</option>
                                            <option value="03">03</option>
                                            <option value="04">04</option>
                                            <option value="05">05</option>
                                            <option value="06">06</option>
                                            <option value="07">07</option>
                                        </select>
                                        <%--<span class="glyphicon glyphicon-download form-control-feedback"></span>--%>
                                    </div>


                                </td>

                            </tr>


                            <tr>
                                <td style="text-align: right; width: 200px">From Date <span style="color: Red;">*
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox
                                        ID="txtFromDate"
                                        runat="server"
                                        ValidationGroup="Submit"
                                        TabIndex="6"
                                        class="form-control"
                                        autocomplete="off"
                                        placeholder="Select From Date and Time">
                                    </asp:TextBox>

                                </td>
                                <td style="text-align: right; width: 200px">To Date <span style="color: Red;">*
                                </td>
                                <td style="text-align: center; width: 10px">:
    <%--<div style="font-weight: bold">
        :
    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px;">
                                    <asp:TextBox
                                        ID="txtToDate"
                                        runat="server"
                                        ValidationGroup="Submit"
                                        TabIndex="7"
                                        class="form-control"
                                        autocomplete="off"
                                        placeholder="Select To Date and Time">
                                    </asp:TextBox>

                                </td>
                            </tr>


                            <tr>
                                <td colspan="6" align="center">
                                    <div id="loadingImg" class="loader" runat="server"></div>
                                    <asp:Button ID="btnShow" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Search" OnClientClick="return ValidEntry();" ValidationGroup="Save" OnClick="btnShow_Click" />&nbsp;
                                   
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="ClearFields();" TabIndex="8" ToolTip="Reset/Clear group master fields"
                                Text="Reset" OnClick="btnReset_Click" />&nbsp;
                                    <asp:Button ID="btnExport" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Export" ValidationGroup="Save" OnClick="btnExport_Click" />&nbsp;
                           
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
                                PageSize="10" PagerStyle-CssClass="pgr" DataKeyNames="Line" OnPageIndexChanging="gvVCTDashboard_PageIndexChanging">
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

                                    <asp:BoundField HeaderText="Date" DataField="Date" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Time" DataField="Time" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ModelNo" DataField="ModelNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ModelName" DataField="ModelName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ChildPartNo" DataField="ChildPartNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ChildPartName" DataField="ChildPartName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="LotNo" DataField="LotNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="TrayID" DataField="TrayID" HeaderStyle-HorizontalAlign="Left"
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
                    <asp:PostBackTrigger ControlID="txtFromDate" />
                    <asp:PostBackTrigger ControlID="txtToDate" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        //$(document).ready(function () {
        //    $('#ContentPlaceHolder1_lstConveyor').select2({
        //        placeholder: "Select Station No.", // Placeholder text
        //        allowClear: true // Allow clearing the selection      
        //    });
        //});
        function initSelect2() {
            var ddl = $('#ContentPlaceHolder1_lstConveyor');

            if (ddl.data('select2')) {
                ddl.select2('destroy'); // reset if already initialized
            }

            ddl.select2({
                placeholder: "Select Station No.",
                allowClear: true
            });

            ddl.off('change').on('change', function () {
                __doPostBack('ContentPlaceHolder1$lstConveyor', '');
            });
            $('#ContentPlaceHolder1_txtFromDate').datetimepicker({
                format: 'Y-m-d H:i',
                formatTime: 'H:i',
                timepicker: true,
                step: 30
            });
            $('#ContentPlaceHolder1_txtToDate').datetimepicker({
                format: 'Y-m-d H:i',
                formatTime: 'H:i',
                timepicker: true,
                step: 30
            });
        }

        // Run on first load
        $(document).ready(function () {
            initSelect2();
        });

        // If you use UpdatePanel (partial postback), re-run after async requests
        if (typeof (Sys) !== "undefined") {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                initSelect2();
            });
        }




        function ClearFields() {

        }

        function ValidEntry() {
            var station = document.getElementById('<%= ddlLine.ClientID %>').value;

            var date = document.getElementById('<%= txtFromDate.ClientID %>').value;
            var serial = document.getElementById('<%= txtToDate.ClientID %>').value;


            if (model === "") {
                ShowMessage("Please Select Station.", Warning);
                document.getElementById("<%=ddlLine.ClientID%>").focus();
                return false;
            }

            else if (date === "") {
                ShowMessage("Please Select From date", Warning);
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return false;
            }
            else if (serial === "") {
                ShowMessage("Please Select To date", Warning);
                document.getElementById("<%=txtToDate.ClientID%>").focus();
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
    <script type="text/javascript">
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                initCalendar(); // your datepicker init function
            }
        }

        function initCalendar() {
            $('#ContentPlaceHolder1_txtFromDate').datetimepicker({
                format: 'Y-m-d',
                formatTime: 'H:i',
                timepicker: false,
                step: 30
            });
            $('#ContentPlaceHolder1_txtToDate').datetimepicker({
                format: 'Y-m-d',
                formatTime: 'H:i',
                timepicker: false,
                step: 30
            });
        }

        $(document).ready(function () {
            initCalendar();
        });
    </script>
</asp:Content>
