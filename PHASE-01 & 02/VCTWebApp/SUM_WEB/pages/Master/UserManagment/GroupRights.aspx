<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="GroupRights.aspx.cs" Inherits="VCTWebApp.pages.Master.UserManagment.GroupRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="col-xs-12">
    <div class="messagealert col-md-6" id="alert_container"></div>
        </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Group Rights
            <small>Assign Group Rights</small>
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">Group Rights</a></li>
          </ol>
        </section>
    <div class="col-xs-12">
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <table id="Table1" runat="server" cellspacing="10" style="width: 100%" align="center">
                        <tr>
                            <td colspan="4">
                                <div id="DivEntry" runat="server" class="box-header">
                                    <span style="color: Red;">* Mandatory Fields</span>

                                    <table id="tblentry" runat="server" class="table" style="width: 95%; margin-left: 0%; margin-right: 5%;"
                                        cellspacing="3" cellpadding="3">
                                        <tr>
                                            <td style="text-align: right; width: 119px">Select Group <span style="color: Red;">*</span>
                                            </td>
                                            <td style="text-align: center">
                                                <div style="font-weight: bold;">
                                                    :
                                                </div>
                                            </td>
                                            <td style="text-align: left">
                                                <div class="form-group has-feedback">
                                                <asp:DropDownList ID="ddlGroup" ToolTip="Select Group Name" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"
                                                    AutoPostBack="true" class="form-control" runat="server" ValidationGroup="Submit">
                                                </asp:DropDownList>
                                                <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                                    </div>
                                                <asp:RequiredFieldValidator ID="RFV_GrpCode" ValidationGroup="Submit" InitialValue="-- Select Group --"
                                                    runat="server" ControlToValidate="ddlGroup" Display="Dynamic" ErrorMessage="Please Select Group" ForeColor="Red"
                                                    CssClass="validation"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn-lg" OnClick="BtnBack_Click"
                                                    TabIndex="2" />&nbsp;
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn-lg" OnClick="btnSubmit_Click"
                                                    TabIndex="1" ToolTip="Save/update group rights" ValidationGroup="Submit" Text="Update" />&nbsp;
                                                <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="btn-lg"
                                                    OnClientClick="ClearFields();" TabIndex="3" ToolTip="Reset/Clear group rights"
                                                    Text="Reset" OnClick="btnClear_Click" />&nbsp;
                                                <asp:Button ID="btnExport" runat="server" TabIndex="13" CssClass="btn-lg" Enabled="false" 
                                                    ToolTip="Export group rights data into excel file" Text="Download" CausesValidation="false"
                                                    Visible="false" OnClick="btnExport_Click" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <div id="DivGrid" runat="server">

                                    <asp:GridView ID="gvGroupRights" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                        OnRowCreated="gvGroupRights_RowCreated" ShowFooter="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvGroupRights_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Module ID" Visible="false"
                                                HeaderStyle-Width="120px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPageCode" runat="server" Text='<%#Eval("MODULE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Module Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPageName" runat="server" Text='<%#Eval("MODULE_DESC") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHView" runat="server" onclick="javascript:HeaderViewClick(this);"
                                                        Text=" Form Access" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkView" runat="server" Checked='<%#Eval("VIEW_RIGHTS") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerStyle CssClass="pgr"></PagerStyle>
                                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                    </asp:GridView>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="right"></td>
                        </tr>
                    </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function ClearFields() {
            document.getElementById('<%= ddlGroup.ClientID %>').selectedIndex = 0;
        }
        var TotalChkBx;
        var TotalChkBxSave;
        var TotalChkBxEdit;
        var TotalChkBxDelete;
        var TotalChkBxExport;
        var Counter;
        function GetRowsCount() {
            TotalChkBx = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            TotalChkBxSave = document.getElementById('<%= this.gvGroupRights.ClientID %>').rows.length;
            TotalChkBxEdit = document.getElementById('<%= this.gvGroupRights.ClientID %>').rows.length;
            TotalChkBxDelete = document.getElementById('<%= this.gvGroupRights.ClientID %>').rows.length;
            TotalChkBxExport = document.getElementById('<%= this.gvGroupRights.ClientID %>').rows.length;
            Counter = 0;
        }
        function HeaderViewClick(CheckBox) {
            var TargetBaseControl = document.getElementById('<%= this.gvGroupRights.ClientID %>');
            var TargetChildControl = "chkView";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                    Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        function HeaderNewClick(CheckBox) {
            var TargetBaseControl = document.getElementById('<%= this.gvGroupRights.ClientID %>');
            var TargetChildControl = "chkSave";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                    Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBxSave : 0;
        }
        function HeaderEditClick(CheckBox) {
            var TargetBaseControl = document.getElementById('<%= this.gvGroupRights.ClientID %>');
            var TargetChildControl = "chkEdit";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                    Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBxEdit : 0;
        }
        function HeaderDeleteClick(CheckBox) {
            var TargetBaseControl = document.getElementById('<%= this.gvGroupRights.ClientID %>');
            var TargetChildControl = "chkDelete";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                    Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBxDelete : 0;
        }
        function HeaderExportClick(CheckBox) {
            var TargetBaseControl = document.getElementById('<%= this.gvGroupRights.ClientID %>');
            var TargetChildControl = "chkExport";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                    Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBxExport : 0;
        }
        function ChildViewClick(CheckBox, HCheckBox) {
            TotalChkBx = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            var HeaderCheckBox = document.getElementById(HCheckBox);
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
        function ChildSaveClick(CheckBox, HCheckBox) {
            TotalChkBxSave = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            var HeaderCheckBox = document.getElementById(HCheckBox);
            if (CheckBox.checked && Counter < TotalChkBxSave)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBxSave)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBxSave)
                HeaderCheckBox.checked = true;
        }
        function ChildEditClick(CheckBox, HCheckBox) {
            TotalChkBxEdit = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            var HeaderCheckBox = document.getElementById(HCheckBox);
            if (CheckBox.checked && Counter < TotalChkBxEdit)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBxEdit)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBxEdit)
                HeaderCheckBox.checked = true;
        }
        function ChildDeleteClick(CheckBox, HCheckBox) {
            TotalChkBxDelete = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            var HeaderCheckBox = document.getElementById(HCheckBox);
            if (CheckBox.checked && Counter < TotalChkBxDelete)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBxDelete)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBxDelete)
                HeaderCheckBox.checked = true;
        }
        function ChildExportClick(CheckBox, HCheckBox) {
            TotalChkBxExport = document.getElementById('<%= gvGroupRights.ClientID %>').rows.length;
            var HeaderCheckBox = document.getElementById(HCheckBox);
            if (CheckBox.checked && Counter < TotalChkBxExport)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBxExport)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBxExport)
                HeaderCheckBox.checked = true;
        }
        function noBack() {
            window.history.forward(1);
        }
    </script>
</asp:Content>
