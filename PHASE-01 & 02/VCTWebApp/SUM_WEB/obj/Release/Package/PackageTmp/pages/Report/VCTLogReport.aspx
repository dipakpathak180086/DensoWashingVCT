<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTLogReport.aspx.cs" Inherits="VCTWebApp.VCTLogReport" %>

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
          <h1>
            Data Error Log Report
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i>Home </asp:HyperLink>
            </li>
            <li><a href="#"> Data Error Log Report</a></li>
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
                                 <td style="text-align: right; width: 200px">From Date<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                 <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtFromDate" runat="server" ValidationGroup="Submit" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline" autocomplete="off"
                                        placeholder="Select From Date" class="form-control"></asp:TextBox>

                                </td>
                                <td style="text-align: right; width: 200px">To Date <span style="color: Red;">*
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtToDate" runat="server" ValidationGroup="Submit" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline" autocomplete="off"
                                        placeholder="Select To Date" class="form-control"></asp:TextBox>

                                </td>
                               
                            </tr>

                            <tr>
                                <td style="text-align: right; width: 200px">Line <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlLine" ToolTip="Select Model" class="form-control" AutoPostBack="true"  ValidationGroup="Submit" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RFV_GrpCode" ValidationGroup="Submit" InitialValue="-- Select Line --"
                                        runat="server" ControlToValidate="ddlLine" Display="Dynamic" ErrorMessage="Please Select Line" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>
                                <td style="text-align: right; width: 200px">Station <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                               <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlStation" ToolTip="Select Model" class="form-control" AutoPostBack="true"  ValidationGroup="Submit" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Submit" InitialValue="-- Select Station --"
                                        runat="server" ControlToValidate="ddlStation" Display="Dynamic" ErrorMessage="Please Select Station" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: right; width: 200px">Process <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlPorcess" ToolTip="Select Child Part" class="form-control" ValidationGroup="Submit" AutoPostBack="true" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlChildPart_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit" InitialValue="-- Select Process --"
                                        runat="server" ControlToValidate="ddlPorcess" Display="Dynamic" ErrorMessage="Please Select Process" ForeColor="Red"
                                        CssClass="validation"></asp:RequiredFieldValidator>


                                </td>
                                 <td style="text-align: right; width: 200px">
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                   
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

                                    <asp:BoundField HeaderText="Process" DataField="Process" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="File Name" DataField="FileName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Message" DataField="Message" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Created By" DataField="CreatedBy" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Created On" DataField="CreatedOn" HeaderStyle-HorizontalAlign="Left"
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
                     <asp:PostBackTrigger ControlID="ddlPorcess" />
                    <asp:PostBackTrigger ControlID="txtFromDate" />
                     <asp:PostBackTrigger ControlID="txtToDate" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
         $('#ContentPlaceHolder1_txtToDate').datetimepicker({
                    format: 'Y-m-d',


                    timepicker: false
                });
        $('#ContentPlaceHolder1_txtFromDate').datetimepicker({
                    format: 'Y-m-d',


                    timepicker: false
                });
        function ClearFields() {

        }

        function ValidEntry() {
            var line = document.getElementById('<%= ddlLine.ClientID %>').value;
            var ddlprocess = document.getElementById('<%= ddlPorcess.ClientID %>').value;
            var ddlstation = document.getElementById('<%= ddlStation.ClientID %>').value;
            var fromdate = document.getElementById('<%= txtFromDate.ClientID %>').value;
              var todate = document.getElementById('<%= txtToDate.ClientID %>').value;
           


            if (line === "") {
                ShowMessage("Please Select Line.", Warning);
                document.getElementById("<%=ddlLine.ClientID%>").focus();
                return false;
            }
            else if (ddlprocess === "") {
                ShowMessage("Please Select Station", Warning);
                document.getElementById("<%=ddlStation.ClientID%>").focus();
                return false;
            }
         else if (ddlstation === "") {
                ShowMessage("Please Select Station", Warning);
                document.getElementById("<%=ddlStation.ClientID%>").focus();
                return false;
            }
            else if (fromdate === "") {
                ShowMessage("Please Select from date", Warning);
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return false;
            }
             else if (todate === "") {
                ShowMessage("Please Select to date", Warning);
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
