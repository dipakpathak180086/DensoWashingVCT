<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTDashboardBackwardTrace.aspx.cs" Inherits="VCTWebApp.VCTDashboardBackwardTrace" %>

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
        <h1>VCT Backward Traceability Dashboard
        </h1>
        <ol class="breadcrumb">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
                </asp:HyperLink>
            </li>
            <li><a href="#">VCT Backward Traceability Dashboard</a></li>
        </ol>
    </section>
    <div class="col-xs-12">
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="DivEntry" runat="server" class="box-header">
                        <span style="color: Red;">* Mandatory Fields</span>

                        <table id="tblentry" runat="server" class="table" style="width: 95%; margin-left: 0%; margin-right: 5%;"
                            cellspacing="4" cellpadding="4">
                            
                            <tr>
                                <td style="text-align: right; width: 200px">Model <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">


                                    <asp:Label ID="lblModel" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>


                                </td>
                                <td style="text-align: right; width: 200px">Model Name <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                </td>

                                <td style="text-align: left; width: 200px">

                                    <asp:Label ID="lblModelName" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>

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

                                    <asp:Label ID="lblChildPart" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>




                                </td>
                                <td style="text-align: right; width: 200px">Child Part Name <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold;">
                                        :
                                    </div>--%>
                                </td>

                                <td style="text-align: left; width: 200px">

                                    <asp:Label ID="lblChildPartName" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>


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
                                    <asp:Label ID="lblDate" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>

                                </td>
                                <td style="text-align: right; width: 200px">FG Serial No. <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="lblSerial" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>
                                </td>
                            </tr>


                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn-lg" OnClick="BtnBack_Click"
                                        TabIndex="2" />&nbsp;
                                    <asp:HiddenField ID="hidID" runat="server" />
                                    <asp:Button ID="btnExport" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Export" ValidationGroup="Save" OnClick="btnExport_Click" />&nbsp;
                                    
                            
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div id="DivShow" runat="server" visible="false" autopostback="true">

                        <div id="divLotSummary" runat="server" style="overflow: auto; width: 100%;">

                            <asp:GridView ID="dgvDtl" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt">
                                <Columns>
                                    <asp:BoundField HeaderText="Line" DataField="Line" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Line Stopage(In Min)" DataField="Stopage" HeaderStyle-HorizontalAlign="Left"
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
                                    <asp:BoundField HeaderText="Lot" DataField="Lot" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="FG Serial" DataField="Serial" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>


                                </Columns>
                                <%--<FooterStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <PagerStyle CssClass="pgr"></PagerStyle>
                                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                <RowStyle HorizontalAlign="Center" />--%>
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

        }

        function ValidEntry() {



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
