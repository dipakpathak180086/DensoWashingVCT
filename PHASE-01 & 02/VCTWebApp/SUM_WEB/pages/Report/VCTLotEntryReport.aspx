<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTLotEntryReport.aspx.cs" Inherits="VCTWebApp.VCTLotEntryReport" %>

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

        .loader {
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid blue;
            border-bottom: 16px solid blue;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
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
        <h1>Child Part Lot Data Report
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">Child Part Lot Data Report</a></li>
        </ol>
    </section>
    <div class="col-xs-12">
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="DivEntry" runat="server" class="box-header">
                        <span style="color: Red;">* Mandatory Fields</span>

                        <table id="tblentry" runat="server" class="table" style="width: 95%; margin-left: 0%; margin-right: 5%;"
                            cellspacing="6" cellpadding="6">
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
                                        runat="server" ControlToValidate="ddlLine" Display="Dynamic" ErrorMessage="Please Select Line" ForeColor="Red"
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
    <%--<div style="font-weight: bold;">
        :
    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlChildPart" ToolTip="Select Child Part" class="form-control" ValidationGroup="Submit" AutoPostBack="true" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlChildPart_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit" InitialValue="-- Select Model --"
                                        runat="server" ControlToValidate="ddlChildPart" Display="Dynamic" ErrorMessage="Please Select Child" ForeColor="Red"
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
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtFromDate" runat="server" ValidationGroup="Submit" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline"
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
                                        ID="txtToDate" runat="server" ValidationGroup="Submit" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline"
                                        placeholder="Select To Date" class="form-control"></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td style="text-align: right; width: 200px">Enter Lot No <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
    :
</div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox autocomplete="off" ID="txrLotNo" class="form-control" runat="server" ToolTip="Enter Lot No" placeholder="Enter Lot No"
                                        ValidationGroup="Submit" TabIndex="1" MaxLength="2000"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 200px"><span style="color: Red;"></span>
                                </td>
                                <td style="text-align: center; width: 10px">
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">
                                    </div>



                                </td>


                            </tr>

                            <td colspan="6" align="center">

                                <tr>
                                    <td colspan="6" align="center">
                                        <div id="loadingImg" class="loader" runat="server"></div>
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
                                PageSize="10" PagerStyle-CssClass="pgr" DataKeyNames="ModelNo" OnPageIndexChanging="gvVCTDashboard_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Model No" DataField="ModelNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Model Name" DataField="ModelName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Child Part No" DataField="ChildPartNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Child Part Name" DataField="ChildPartName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Lot Number" DataField="LotNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Lot Qty" DataField="LotQty" HeaderStyle-HorizontalAlign="Left"
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
                                    <asp:BoundField HeaderText="TM Name" DataField="TMName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="TL Name" DataField="TLName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vendor Code" DataField="VendorCode" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="FG Serial No" DataField="SerialNo" HeaderStyle-HorizontalAlign="Left"
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
                    <asp:PostBackTrigger ControlID="ddlModel" />
                    <asp:PostBackTrigger ControlID="ddlChildPart" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $('#ContentPlaceHolder1_txtFromDate').datetimepicker({
            format: 'Y-m-d',
            formatTime: 'H:i',
            timepicker: false
            // minDate: 0
        });
        $('#ContentPlaceHolder1_txtToDate').datetimepicker({
            format: 'Y-m-d',
            formatTime: 'H:i',
            timepicker: false
            // minDate: 0
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
    </script>
</asp:Content>
