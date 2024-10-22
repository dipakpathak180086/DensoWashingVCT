<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTDashboard.aspx.cs" Inherits="VCTWebApp.VCTDashboard" %>

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
          <h1>
            VCT Traceability Dashboard
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">VCT Traceability Dashboard</a></li>
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
                                <td style="text-align: right; width: 200px">Model Name <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:Label ID="lblModelName" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                        </asp:Label>

                                    </div>
                                </td>

                            </tr>
                            <tr>
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
                                <td style="text-align: right; width: 200px">Child Part Name <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">
                                    <div class="form-group has-feedback">

                                        <asp:Label ID="lblChildPartName"  Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                        </asp:Label>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 200px">Select Date <span style="color: Red;">*
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox onkeyup="this.value=this.value.toUpperCase();javascript:RemoveSpecialChar(this);"
                                        ID="txtDate" runat="server" ValidationGroup="Submit" TabIndex="6" MaxLength="50" Style="text-transform: uppercase; display: inline"
                                        placeholder="Select Date" class="form-control"></asp:TextBox>

                                </td>
                                <td style="text-align: right; width: 200px">Part Serial <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox autocomplete="off" ID="txtSerial" onkeypress="return isNumber(event)" class="form-control" runat="server" ToolTip="Enter Serial" placeholder="Enter Serial"
                                        ValidationGroup="Submit" TabIndex="1" MaxLength="6"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>

                                <td style="text-align: right; width: 200px">Rejection <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:TextBox autocomplete="off" ID="txtRejection" onkeypress="return isNumber(event)" class="form-control" runat="server" ToolTip="Enter Rejection" placeholder="Enter Rejection"
                                        ValidationGroup="Submit" TabIndex="1" MaxLength="6"></asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td colspan="6" align="center">
                                    <asp:HiddenField ID="hidID" runat="server" />
                                    <asp:Button ID="btnShow" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Search" OnClientClick="return ValidEntry();" ValidationGroup="Save" OnClick="btnShow_Click" />&nbsp;
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="ClearFields();" TabIndex="8" ToolTip="Reset/Clear group master fields"
                                Text="Reset" OnClick="btnReset_Click" />&nbsp;
                            <asp:Button ID="btnExport" runat="server" TabIndex="10" CssClass="btn-lg"
                                ToolTip="Export user master data into excel file" Text="Export" CausesValidation="false"
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

                                    <asp:BoundField HeaderText="Shift" DataField="Shift" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

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
                                    <asp:BoundField HeaderText="Child Part Number" DataField="ChildPartNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Child PartName" DataField="ChildPartName" HeaderStyle-HorizontalAlign="Left"
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
                                    <asp:BoundField HeaderText="TMName" DataField="TMName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="TLName" DataField="TLName" HeaderStyle-HorizontalAlign="Left"
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
                        <div id="Div1" runat="server" style="overflow: auto; width: 100%;">

                            <asp:GridView ID="dgvDtl" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                                PageSize="10" PagerStyle-CssClass="pgr" OnPageIndexChanging="dgvDtl_PageIndexChanging">
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
                                    <%--<asp:BoundField HeaderText="Range" DataField="Range" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="Part Serial" DataField="Serial" HeaderStyle-HorizontalAlign="Left"
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
                            <asp:Button ID="btnExport2" runat="server" TabIndex="10" CssClass="btn-lg"
                                ToolTip="Export user master data into excel file" Text="Export" CausesValidation="false"
                                OnClick="btnExport2_Click" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExport" />
                    <asp:PostBackTrigger ControlID="btnExport" />
                    <asp:PostBackTrigger ControlID="btnShow" />
                    <asp:PostBackTrigger ControlID="btnReset" />
                    <asp:PostBackTrigger ControlID="ddlModel" />
                    <asp:PostBackTrigger ControlID="ddlChildPart" />
                    <asp:PostBackTrigger ControlID="txtSerial" />
                    <asp:PostBackTrigger ControlID="txtDate" />
                    <asp:PostBackTrigger ControlID="txtRejection" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $('#ContentPlaceHolder1_txtDate').datetimepicker({
            format: 'Y-m-d',


            timepicker: false
        });
        function ClearFields() {

        }

        function ValidEntry() {
            var model = document.getElementById('<%= ddlModel.ClientID %>').value;
            var child = document.getElementById('<%= ddlChildPart.ClientID %>').value;
            var date = document.getElementById('<%= txtDate.ClientID %>').value;
            var serial = document.getElementById('<%= txtSerial.ClientID %>').value;
            var rejection = document.getElementById('<%=txtRejection.ClientID%>').value;


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
                ShowMessage("Please Select date", Warning);
                document.getElementById("<%=txtDate.ClientID%>").focus();
                return false;
            }
            else if (serial === "") {
                ShowMessage("Please Enter Serial", Warning);
                document.getElementById("<%=txtSerial.ClientID%>").focus();
                return false;
            }
            else if (rejection == "") {
                ShowMessage("Please Enter Rejection", Warning);
                document.getElementById("<%=txtRejection.ClientID%>").focus();
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
