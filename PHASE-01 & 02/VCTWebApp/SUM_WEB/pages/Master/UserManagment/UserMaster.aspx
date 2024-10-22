<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="UserMaster.aspx.cs" Inherits="VCTWebApp.pages.Master.UserManagment.UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .has-feedback {
   
     left: 0px !important;
     width: 100% !important;
}
        .auto-style2 {
            width: 200px;
            height: 68px;
        }
        .auto-style3 {
            width: 10px;
            height: 68px;
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
            User Master
            <small>Add New User</small>
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">User Master</a></li>
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
                                <td style="text-align: right;width:200px">User Name<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center ;width:10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left ;width:200px">
                                    <asp:TextBox autocomplete="off" ID="txtUserName" class="form-control" ToolTip="Enter User Name" placeholder="Enter User Name"
                                        ValidationGroup="Submit" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                                <td style="text-align: right ;width:200px">User ID<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center ;width:10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left ;width:200px">
                                    <asp:TextBox autocomplete="off" ID="txtUserID" class="form-control" runat="server" ToolTip="Enter User ID" placeholder="Enter User ID"
                                        ValidationGroup="Submit" TabIndex="1" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;" class="auto-style2">Password<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center;" class="auto-style3">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left;" class="auto-style2">
                                    <asp:TextBox autocomplete="off" ID="txtPassword" class="form-control" runat="server" placeholder="Enter Password"
                                        ToolTip="Enter Password" TabIndex="2" ValidationGroup="submit"
                                        TextMode="Password" MaxLength="12" oncopy="return false;" onpaste="return false;"
                                        oncut="return false;"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style2">User Group<span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center;" class="auto-style3">
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left;" class="auto-style2">
                                    <div class="form-group has-feedback">

                                        <asp:DropDownList ID="ddlUserType" ToolTip="Select User Type" class="form-control" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                        <span class="glyphicon glyphicon-download form-control-feedback"></span>
                                    </div>
                                </td>
                            </tr>

                            

                            <tr>
                                <td style="text-align: right ;width:200px">Enter Email<span style="color: Red;">*</span>
                                </td>
                                  <td style="text-align: center ;width:10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left ;width:200px">
                              <asp:TextBox autocomplete="off" ID="txtEmailID" class="form-control" runat="server" ToolTip="Enter Email ID" placeholder="Enter Email ID"
                                        ValidationGroup="Submit" TabIndex="6" MaxLength="100"></asp:TextBox>
                                </td>
                                <td style="text-align: right ;width:200px">Pin No.
                                </td>
                                 <td style="text-align: center ;width:10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left ;width:200px">
                              <asp:TextBox autocomplete="off" ID="txtPinNo" class="form-control" runat="server" ToolTip="Login Pin" placeholder="Enter Login Pin"
                                        ValidationGroup="Submit" TextMode="Password" TabIndex="6" MaxLength="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <asp:HiddenField ID="hidID" runat="server" />
                                    <%--<asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn-lg" OnClick="BtnBack_Click"
                                        TabIndex="9" />&nbsp;--%>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="Save" ToolTip="Save user master details"
                                TabIndex="7" OnClientClick="return ValidEntry();" Text="Save" CssClass="btn-lg"
                                OnClick="btnSave_Click" />&nbsp;
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
                    <div id="DivShow" runat="server">
                        <asp:Label ID="lblRecords" runat="server" Text="No. of Records: "></asp:Label>
                        <div id="DivGrid" runat="server" style="overflow: auto; width: 100%;">

                            <asp:GridView ID="gvUserMaster" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                OnRowCommand="gvUserMaster_RowCommand" AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                                PageSize="50" PagerStyle-CssClass="pgr" DataKeyNames="UserCode" OnPageIndexChanging="gvUserMaster_PageIndexChanging">
                                <Columns>

                                    <asp:BoundField HeaderText="Active" DataField="Active" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" Visible="false" >

                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="User ID" DataField="UserCode" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >

                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="User Name" DataField="USERNAME" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmailId" HeaderText="Email" />
                                    <asp:BoundField HeaderText="User Group" DataField="GROUPNAME" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                  
                                    
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkEdit" Text=" <img src='../../../dist/img/editGrid.png' alt='Edit' />"
                                                runat="server" CausesValidation="False" ToolTip="Edit" CommandName="EditRecords"
                                                CommandArgument='<%#Eval("UserCode")%>' Visible="true">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Text=" <img src='../../../dist/img/deleteGrid.png' alt='Delete' />"
                                                runat="server" CausesValidation="False" ToolTip="Delete" CommandName="DeleteRecords"
                                                CommandArgument='<%#Eval("UserCode")%>' OnClientClick="return confirm('Are You Sure To Delete This Record?');"
                                                Visible="true">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Password" DataFormatString="Password" HeaderText="Password" Visible="False" />
                                    <asp:BoundField DataField="PinNo" DataFormatString="PinNo" HeaderText="PinNo" Visible="False" />
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
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function ClearFields() {
            document.getElementById('<%= txtUserName.ClientID %>').value = "";
            document.getElementById('<%= txtUserID.ClientID %>').value = "";
            document.getElementById('<%= txtPassword.ClientID %>').value = "";
            document.getElementById('<%= ddlUserType.ClientID %>').selectedIndex = 0;
        }

        function ValidEntry() {
            var UserName = document.getElementById('<%= txtUserName.ClientID %>').value;
            var UserId = document.getElementById('<%= txtUserID.ClientID %>').value;
            var Pswd = document.getElementById('<%= txtPassword.ClientID %>').value;
            var usertype = document.getElementById('<%= ddlUserType.ClientID %>').value;


            if (UserName === "") {
                ShowMessage("Please Enter User Name.", Warning);
                document.getElementById("<%=txtUserName.ClientID%>").focus();
                return false;
            }
            else if (UserId === "") {
                ShowMessage("Please Enter User Id.", Warning);
                document.getElementById("<%=txtUserID.ClientID%>").focus();
                return false;
            }
            else if (Pswd === "") {
                ShowMessage("Please Enter Password.", Warning);
                document.getElementById("<%=txtPassword.ClientID%>").focus();
                return false;
            }
            else if (usertype === "--SELECT--") {
                ShowMessage("Please Select User Type.", Warning);
                document.getElementById("<%=ddlUserType.ClientID%>").focus();
                return false;
            }

          
        }
        function ValidateRegForm() {
            var email = document.getElementById("<%=txtEmailID.ClientID%>");
            var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
            if (!filter.test(email.value)) {
                alert('Please provide a valid email address');
                email.focus;
                return false;
            }
            return true;
        }
    </script>
</asp:Content>