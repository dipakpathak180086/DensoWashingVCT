<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="VCTWebApp.pages.Master.UserManagment.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../JSFiles/jquery.min.js" type="text/javascript"></script>
    <script src="../../JSFiles/bootstrap-select.min.js" type="text/javascript"></script>
    <link href="../../JSFiles/bootstrap-select.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="col-xs-12">
    <div class="messagealert col-md-6" id="alert_container" style="width:800px"></div>
        </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
         Change Password
            <small>Change Password</small>
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">Change Password</a></li>
          </ol>
        </section>
    <div class="col-xs-12">
        <div class="box">
             <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
            <div id="DivEntry" runat="server" class="box-header">
                <span style="color: Red;">* Mandatory Fields</span>
                <table id="tblentry" runat="server" class="table" style="width: 80%; margin-left: 10%; margin-right: 10%;">
                    <tr>
                        <td align="right">User ID<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">Current    Password <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"
                                TabIndex="6" MaxLength="50" Width="400px" 
                                 class="form-control" placeholder="Enter Your Current Password"></asp:TextBox>--%>

                             <asp:TextBox autocomplete="off" ID="txtCurrentPassword" class="form-control" runat="server" placeholder="Enter Your Current Password"
                                        ToolTip="Enter Password" TabIndex="2" ValidationGroup="submit"
                                        TextMode="Password" MaxLength="12" oncopy="return false;" onpaste="return false;"
                                        oncut="return false;" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">New Password<span style="color: Red;">*</span>
                        </td>
                        <td>
                           <%-- <asp:TextBox onkeyup="this.value=this.value.toUpperCase();" ID="txtPassword" runat="server" TextMode="Password"
                                TabIndex="6" MaxLength="50"  placeholder="Enter Your New Password" Width="400px"
                                class="form-control"></asp:TextBox>--%>
                            
                             <asp:TextBox autocomplete="off" ID="txtPassword" class="form-control" runat="server" placeholder="Enter Your New Password"
                                        ToolTip="Enter Password" TabIndex="2" ValidationGroup="submit"
                                        TextMode="Password" MaxLength="12" oncopy="return false;" onpaste="return false;"
                                        oncut="return false;" Width="400px"></asp:TextBox>

                            <asp:HiddenField ID="hidID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Confirm Password<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <%--<asp:TextBox onkeyup="this.value=this.value.toUpperCase();" ID="txtConfirmPassword" runat="server" TextMode="Password"
                                TabIndex="6" MaxLength="50" placeholder="Enter Your Confirm Password" Width="400px"
                                class="form-control"></asp:TextBox>--%>
                             <asp:TextBox autocomplete="off" ID="txtConfirmPassword" class="form-control" runat="server" placeholder="Enter Your Confirm Password"
                                        ToolTip="Enter Password" TabIndex="2" ValidationGroup="submit"
                                        TextMode="Password" MaxLength="12" oncopy="return false;" onpaste="return false;"
                                        oncut="return false;" Width="400px"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <br />
                            <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn-lg" OnClick="BtnBack_Click"
                                TabIndex="10" />
                            &nbsp;
                                    <asp:Button ID="BtnSave" CssClass="btn-lg" runat="server" Text="Save" OnClick="BtnSave_Click"
                                        OnClientClick="return ValidEntry()" TabIndex="17"></asp:Button>
                            &nbsp;
                                    <asp:Button ID="BtnReset" CssClass="btn-lg" runat="server" Text="Reset" OnClientClick="return Reset();"
                                        OnClick="BtnReset_Click" TabIndex="18"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
                    </ContentTemplate>
                

            </asp:UpdatePanel>
</asp:Content>
