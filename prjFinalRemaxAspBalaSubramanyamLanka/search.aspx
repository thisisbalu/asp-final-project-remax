<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/search.css" rel="stylesheet" />
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
            <div class="col-12">
                <ul class="nav nav-tabs nav-fill" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#duck" role="tab" aria-controls="duck" aria-selected="true">Search Houses</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#chicken" role="tab" aria-controls="chicken" aria-selected="false">Search Agents</a>
                    </li>
                </ul>

                <div class="tab-content mt-3">
                    <div class="tab-pane active" id="duck" role="tabpanel" aria-labelledby="duck-tab">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkBeds" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblBeds" runat="server" Text="Number of Beds: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtBeds" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="errBeds" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkBaths" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblBaths" runat="server" Text="Number of Baths: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtBaths" runat="server" CssClass="mt-2"  TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="errBaths" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkPrice" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lclPrice" runat="server" Text="Price from: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtFrom" runat="server" CssClass="mt-2"  TextMode="Number"></asp:TextBox>
                                    &nbsp;to&nbsp;<asp:TextBox ID="txtTo" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="errPrice" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkCity" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
                                    &nbsp;<asp:DropDownList ID="dlCity" runat="server" CssClass="mt-2"  TextMode="Number"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkProperty" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Property Type: "></asp:Label>
                                    &nbsp;<asp:DropDownList ID="dlProperty" runat="server" CssClass="mt-2"  TextMode="Number"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" CssClass="mt-2 float-right" ID="btnSearchHouses" Text="Search Houses" OnClick="btnSearchHouses_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tab-pane" id="chicken" role="tabpanel" aria-labelledby="chicken-tab">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkFirstName" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    <asp:Label ID="errFirstName" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkLastName" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Last Name: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtLastName" runat="server" CssClass="mt-2"></asp:TextBox>
                                    <asp:Label ID="errLastName" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkEmail" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Email ID: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtEmail" runat="server" CssClass="mt-2"></asp:TextBox>
                                    <asp:Label ID="errEmail" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkUsername" />
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Username: "></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtUsername" runat="server" CssClass="mt-2"></asp:TextBox>
                                    <asp:Label ID="errUsername" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" CssClass="mt-2 float-right" ID="Button1" Text="Search Agents" OnClick="btnSearchAgents_Click" />
                                </td>
                            </tr>
                        </table>   
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="container">
        <div class="row">
            <div class="col-12">
                <asp:Table CssClass="table table-image mt-5" ID="tableHouses" Visible="false" runat="server">
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
    <div class="container">
        <div class="row">
            <div class="col-12">
                <asp:Table CssClass="table table-image mt-5" ID="tableAgents" Visible="false" runat="server">
                    <asp:TableHeaderRow runat="server">
                        <asp:TableCell CssClass="th" runat="server">Image</asp:TableCell>
                        <asp:TableCell runat="server">Firstname</asp:TableCell>
                        <asp:TableCell runat="server">Lastname</asp:TableCell>
                        <asp:TableCell runat="server">Email</asp:TableCell>
                        <asp:TableCell runat="server">Username</asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="auto-style1">
                <asp:Label ID="lblSearchText" CssClass="mt-5" runat="server" Text="No Search Results" />
            </div>
        </div>
    </div>
    <script src="Lib/jquery/jquery.min.js"></script>
    <script src="Lib/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
