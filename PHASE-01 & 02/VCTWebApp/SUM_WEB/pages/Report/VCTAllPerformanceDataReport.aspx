<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTAllPerformanceDataReport.aspx.cs" Inherits="VCTWebApp.VCTAllPerformanceDataReport" %>

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
    <div id="loadingOverlay" runat="server" class="overlay-loader">
        <div class="loader"></div>
    </div>
    <div class="col-xs-12">
        <div class="messagealert col-md-6" id="alert_container"></div>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Performance Full Report
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">Performance Full Report</a></li>
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

                                        <asp:DropDownList ID="ddlLine" ToolTip="Select Model" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" ValidationGroup="Submit" runat="server" TabIndex="3">
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

                                        <asp:DropDownList ID="ddlStation" ToolTip="Select Station" class="form-control" AutoPostBack="true"  ValidationGroup="Submit" runat="server" TabIndex="4">
                                            <asp:ListItem Text="--SELECT--" Value="--Select--"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>

                                </td>

                            </tr>
                            <tr>

                                <td style="text-align: right; width: 200px">From Date<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtFromDate" runat="server" ValidationGroup="Submit" AutoPostBack="true" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline" autocomplete="off"
                                        placeholder="Select From Date" class="form-control"></asp:TextBox>

                                </td>
                                <td style="text-align: right; width: 200px">To Date<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
    <%--<div style="font-weight: bold;">
        :
    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);" 
                                        ID="txtToDate" runat="server" ValidationGroup="Submit" AutoPostBack="true" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline" autocomplete="off"
                                        placeholder="Select To Date" class="form-control"></asp:TextBox>

                                </td>

                            </tr>






                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button ID="btnShow" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Search" OnClientClick="return ShowLoader();" ValidationGroup="Save" OnClick="btnShow_Click" />&nbsp;
                                  
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="if(ClearFields()){ return return true; } else { return true; }" TabIndex="8" ToolTip="Reset/Clear group master fields"
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

                            <asp:GridView ID="gvUserMaster" runat="server" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt"
                                PagerStyle-CssClass="pgr" DataKeyNames="Model number">
                                <Columns>
                                    <asp:BoundField HeaderText="Model number" DataField="Model number" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Serial number" DataField="Serial number" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Insepction date & time" DataField="Insepction date & time" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="General judgment" DataField="General judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Advance torque" DataField="Advance torque" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Advance instant torque judgment" DataField="Advance instant torque judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Advance instant angle judgment" DataField="Advance instant angle judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Retard torque" DataField="Retard torque" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Retard instant torque judgment" DataField="Retard instant torque judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Retard instant angle judgment" DataField="Retard instant angle judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Maximum conversion angle" DataField="Maximum conversion angle" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Return angle" DataField="Return angle" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="" DataField=" " HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="" DataField=" " HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pin in check torque value" DataField="Pin in check torque value" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pin in check angle value" DataField="Pin in check angle value" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="400 kPa pin out check judgment" DataField="400 kPa pin out check judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="60 kPa pin out check judgment" DataField="60 kPa pin out check judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="400 kPa pressure application confirmation" DataField="400 kPa pressure application confirmation" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="60 kPa pressure application confirmation" DataField="60 kPa pressure application confirmation" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pin out overall judgment" DataField="Pin out overall judgment" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>


                                </Columns>
                                <FooterStyle Wrap="true" />
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
                    <asp:PostBackTrigger ControlID="txtFromDate" />
                    <asp:PostBackTrigger ControlID="txtToDate" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $('#ContentPlaceHolder1_txtFromDate').datetimepicker({
            format: 'Y-m-d',


            timepicker: false
        });
        $('#ContentPlaceHolder1_txtToDate').datetimepicker({
            format: 'Y-m-d',


            timepicker: false
        });

        function ClearFields() {

        }

        function ValidEntry() {
            var line = document.getElementById('<%= ddlLine.ClientID %>').value;
            var fromdate = document.getElementById('<%= txtFromDate.ClientID %>').value;



            <%--if (line === "") {
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
            }--%>



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
