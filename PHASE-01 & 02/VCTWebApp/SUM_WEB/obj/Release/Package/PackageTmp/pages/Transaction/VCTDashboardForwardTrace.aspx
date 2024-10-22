<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VCTDashboardForwardTrace.aspx.cs" Inherits="VCTWebApp.VCTDashboardForwardTrace" %>

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
            VCT Forward Traceability Dashboard
          </h1>
          <ol class="breadcrumb">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> <i class="fa fa-dashboard"></i> Home
            </asp:HyperLink>
            </li>
            <li><a href="#">VCT Forward Traceability Dashboard</a></li>
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
                                <td style="text-align: right; width: 200px">Suspected Lot <span style="color: Red;">*</span>
                                </td>
                                <td style="text-align: center; width: 10px">:
                                    <%--<div style="font-weight: bold">
                                        :
                                    </div>--%>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="lblSuspectedLot" Text="XXXXXXXXXXXX" runat="server" TabIndex="3">
                                    </asp:Label>
                                </td>
                            </tr>

                            <tr>


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
                                    <asp:HiddenField ID="hidID" runat="server" />
                                    <asp:Button ID="btnShowBackTrace" runat="server" CssClass="btn-lg"
                                        TabIndex="8" Text="Search Backward Trace Data" OnClientClick="return ValidEntry();" ValidationGroup="Save" OnClick="btnShowBackTrace_Click" />&nbsp;
                                    
                            <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="btn-lg"
                                OnClientClick="ClearFields();" TabIndex="8" ToolTip="Reset/Clear group master fields"
                                Text="Reset" OnClick="btnReset_Click" />&nbsp;
                           
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div id="DivShow" runat="server" visible="false" autopostback="true">
                      
                        <div id="divLotSummary" runat="server" style="overflow: auto; width: 100%;">

                            <asp:GridView ID="dgvDtl" runat="server" FooterStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                                PageSize="10" PagerStyle-CssClass="pgr" DataKeyNames="Date"  OnPageIndexChanging="dgvDtl_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Lot Number" DataField="LotNo" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Date" DataField="Date" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Total Qty" DataField="Qty" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">

                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Rejection Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRejection" onkeypress="return isNumber(event)" runat="server" TextMode="Number" MaxLength="6"  Rows="2"
                                                Text='<%# Eval("RejectionQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                    </asp:TemplateField>

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

                    <asp:PostBackTrigger ControlID="btnReset" />
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
