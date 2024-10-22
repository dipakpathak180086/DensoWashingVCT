<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="GroupMaster.aspx.cs" Inherits="VCTWebApp.pages.Master.UserManagment.GroupMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 62px;
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
            User Group Master
            <small>Add New User Group</small>
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">User Group Master</a></li>
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
                                <td style="text-align: right; width: 119px" class="auto-style1">Group Name<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center" class="auto-style1">
                                    <div style="font-weight: bold">
                                        :
                                    </div>
                                </td>

                                <td style="text-align: left" class="auto-style1">
                                    <asp:TextBox autocomplete="off" ID="txtGroupName" class="form-control" placeholder="Enter Group Name" Width="500px"
                                        MaxLength="20" ToolTip="Enter Group Name" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hidID" runat="server" />
                                </td>

                            </tr>

                            <tr>
                                <td align="right" class="style2"></td>
                                <td align="left" class="style1"></td>
                                <td align="left">
                                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn-lg" OnClick="BtnBack_Click"
                                        TabIndex="2" />&nbsp;
                            <asp:Button ID="btnsave" runat="server" CssClass="btn-lg" OnClick="btnsave_Click"
                                TabIndex="1" OnClientClick="return ValidEntry();" ToolTip="Save/update group rights" ValidationGroup="Submit" Text="Save" />&nbsp;
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="return ClearFields();" TabIndex="3" ToolTip="Reset/Clear group master fields"
                                Text="Reset" />&nbsp;

                                <asp:Button ID="btnExport" runat="server" CssClass="btn-lg"
                                    TabIndex="4" ToolTip="Export group data into excel file" ValidationGroup="Submit" Text="Export" OnClick="btnExport_Click" />


                                </td>
                            </tr>
                        </table>

                    </div>
                    <div id="DivShow" runat="server">
                        <asp:Label ID="lblRecords" runat="server" Text="No. of Records: "></asp:Label>
                        <div id="DivGrid" runat="server" style="overflow: auto; width: 100%;">
                            <asp:GridView ID="grdDispaly" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" AllowPaging="True" PageSize="5" PagerStyle-CssClass="pgr"
                                OnRowCommand="grdDispaly_RowCommand"
                                OnPageIndexChanging="grdDispaly_PageIndexChanging" DataKeyNames="GroupID" EmptyDataText="<b style='Color:red; text-align:center;'>No Records Founds...</b>">
                                <RowStyle HorizontalAlign="Center"></RowStyle>
                                <Columns>
                                    <asp:BoundField HeaderText="Group ID" DataField="GroupID" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Group Name" DataField="GroupName" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkEdit" Text=" <img src='../../../dist/img/editGrid.png' alt='Edit' />"
                                                runat="server" CausesValidation="False" ToolTip="Edit" CommandName="EditRecords"
                                                CommandArgument='<%#Eval("GroupID")%>' Visible="true">
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Text=" <img src='../../../dist/img/deleteGrid.png' alt='Delete' />"
                                                runat="server" CausesValidation="False" ToolTip="Delete" CommandName="DeleteRecords"
                                                CommandArgument='<%#Eval("GroupID")%>' OnClientClick="return confirm('Are You Sure To Delete This Record?');"
                                                Visible="true">
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle Wrap="False"></FooterStyle>

                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <PagerStyle CssClass="pgr"></PagerStyle>
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                            </asp:GridView>
                        </div>
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

            document.getElementById('<%= txtGroupName.ClientID %>').value = "";

        }

        function ValidEntry() {
            var GrpName = document.getElementById('<%= txtGroupName.ClientID %>').value;


            if (GrpName === "") {
                ShowMessage("Please Enter Group Name.", Warning);
                return false;
            }

        }


    </script>
</asp:Content>
