<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTLotInfoChildReport.aspx.cs" Inherits="VCTWebApp.VCTLotInfoChildReport" %>

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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loadingOverlay" runat="server" class="overlay-loader">
        <div class="loader"></div>
    </div>
    <div class="col-xs-12">
        <div class="messagealert col-md-6" id="alert_container"></div>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Lot Info. Model Child Part Report
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">Lot Info. Model Child Part Report</a></li>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Submit" InitialValue="-- Select Line --"
                                        runat="server" ControlToValidate="ddlModel" Display="Dynamic" ErrorMessage="Please Select Line" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>
                                <td style="text-align: right; width: 200px"><span style="color: Red;"></span>
                                </td>
                                <td style="text-align: center; width: 10px"></td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">
                                    </div>
                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: right; width: 200px">Model <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlModel" ToolTip="Select Model" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" ValidationGroup="Submit" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RFV_GrpCode" ValidationGroup="Submit" InitialValue="-- Select Model --"
                                        runat="server" ControlToValidate="ddlModel" Display="Dynamic" ErrorMessage="Please Select Model" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>

                                <td style="text-align: right; width: 200px">Child Part Number <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlChildPart" ToolTip="Select Child Part" class="form-control" AutoPostBack="true" ValidationGroup="Submit" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit" InitialValue="-- Select Model --"
                                        runat="server" ControlToValidate="ddlModel" Display="Dynamic" ErrorMessage="Please Select Model" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

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
                                <td style="text-align: left; width: 200px">
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
                                        TabIndex="8" Text="Search" OnClientClick="return ShowLoader();" ValidationGroup="Save" OnClick="btnShow_Click" />&nbsp;
                                   
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="if(ClearFields()){ return return true; } else { return true; }" TabIndex="8" ToolTip="Reset/Clear group master fields"
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
                                PageSize="10" PagerStyle-CssClass="pgr" DataKeyNames="ModelNo" OnPageIndexChanging="gvVCTDashboard_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Model Name" DataField="ModelName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>


                                    <asp:BoundField HeaderText="Model No" DataField="ModelNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Child Part No." DataField="ChildPartNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Child Part Name" DataField="ChildPartName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Lot No." DataField="LotNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Conveyor No" DataField="ConveyorNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Shift" DataField="Shift" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Production Date" DataField="ProductionDate" HeaderStyle-HorizontalAlign="Left"
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
                                    <asp:BoundField HeaderText="Tray Barcode" DataField="TrayBarcode" HeaderStyle-HorizontalAlign="Left"
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
                    <asp:PostBackTrigger ControlID="ddlModel" />
                    <asp:PostBackTrigger ControlID="ddlChildPart" />
                    <asp:PostBackTrigger ControlID="txtFromDate" />
                    <asp:PostBackTrigger ControlID="txtToDate" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
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
        function ClearFields() {

        }

        function ValidEntry() {
            var model = document.getElementById('<%= ddlModel.ClientID %>').value;
            var child = document.getElementById('<%= ddlChildPart.ClientID %>').value;
            var date = document.getElementById('<%= txtFromDate.ClientID %>').value;
            var serial = document.getElementById('<%= txtToDate.ClientID %>').value;


            if (model === "") {
                ShowMessage("Please Select Model.", Warning);
                document.getElementById("<%=ddlModel.ClientID%>").focus();
                return false;
            }
            else if (child === "") {
                ShowMessage("Please Select Child", Warning);
                document.getElementById("<%=ddlChildPart.ClientID%>").focus();
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
        function ShowLoader() {

            document.getElementById("<%=loadingOverlay.ClientID%>").style.display = "flex";
            return true;
        }
        // 🔹 Hide loader when UpdatePanel completes
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            document.getElementById("<%=loadingOverlay.ClientID%>").style.display = "none";
        });
        window.onload = function () {
            document.getElementById("<%=loadingOverlay.ClientID%>").style.display = "none";
        };
        function ValidateAndShowLoader() {
            ShowLoader();        // always show
            return ValidEntry(); // only allow postback if valid
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

        $(document).ready(function () {
            initCalendar();
        });
    </script>
</asp:Content>
