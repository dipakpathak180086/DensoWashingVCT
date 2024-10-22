<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="_Default" CodeBehind="Default.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        .has-feedback {
   
     left: 0px !important;
     width: 100% !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Content Header (Page header) -->
    <section class="content-header">
       
    </section>

    <div class="col-xs-12">
        <div class="box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
