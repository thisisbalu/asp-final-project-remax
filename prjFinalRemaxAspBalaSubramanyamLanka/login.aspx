<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-signin">
        <img class="mb-4" src="/Images/Website/remax-balloon.png" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
        <label for="inputUsername" class="sr-only">Username</label>
        <asp:TextBox class="form-control" placeholder="Username" ID="inputUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="loginGroup" ID="usernameValidator" runat="server" ControlToValidate="inputUsername" ErrorMessage="Username is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox class="form-control" placeholder="Password" ID="inputPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="loginGroup" ID="passwordValidator" runat="server" ControlToValidate="inputPassword" ErrorMessage="Password is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:Button class="btn btn-lg btn-primary btn-block" validationgroup="loginGroup" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Label ID="lblError"  ForeColor="#FF3300" runat="server"></asp:Label>
        <br />
    </div>
</asp:Content>
