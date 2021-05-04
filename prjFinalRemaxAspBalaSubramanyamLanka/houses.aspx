<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="houses.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.houses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/houses.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <asp:Table CssClass="table table-image" ID="tableHouses" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableCell CssClass="th" runat="server">Image</asp:TableCell>
                        <asp:TableCell runat="server">About</asp:TableCell>
                        <asp:TableCell runat="server">Beds</asp:TableCell>
                        <asp:TableCell runat="server">Baths</asp:TableCell>
                        <asp:TableCell runat="server">Type</asp:TableCell>
                        <asp:TableCell runat="server">City</asp:TableCell>
                        <asp:TableCell runat="server">Price</asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
