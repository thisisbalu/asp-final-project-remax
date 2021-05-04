<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            text-align: center;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="auto-style1">
                <asp:Label runat="server" ID="lblTitle" Font-Bold="False" Font-Size="Large"></asp:Label>
                <br /><br />
                <div class="text-left">
                <asp:Table CssClass="table table-image" ID="tableUser" runat="server" Font-Size="Small">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableCell runat="server">Sent On</asp:TableCell>
                        <asp:TableCell runat="server">Sent to</asp:TableCell>
                        <asp:TableCell runat="server">Email</asp:TableCell>
                        <asp:TableCell runat="server">Subject</asp:TableCell>
                        <asp:TableCell runat="server">Message</asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:Table CssClass="table table-image" ID="tableAgent" runat="server" Font-Size="Small">
                    <asp:TableHeaderRow runat="server" Font-Bold="true">
                        <asp:TableCell runat="server">Received On</asp:TableCell>
                        <asp:TableCell runat="server">Received From</asp:TableCell>
                        <asp:TableCell runat="server">Email</asp:TableCell>
                        <asp:TableCell runat="server">Subject</asp:TableCell>
                        <asp:TableCell runat="server">Message</asp:TableCell>
                        <asp:TableCell runat="server">Is New</asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
