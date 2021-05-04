<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-signin">
        <img class="mb-4" src="/Images/Website/remax-balloon.png" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Register</h1>
        
        <label for="inputFirstName" class="sr-only">First Name</label>
        <asp:TextBox class="form-control" placeholder="First Name" ID="inputFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="firstNameValidator" runat="server" ControlToValidate="inputFirstName" ErrorMessage="Firstname is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        
        <label for="inputPassword" class="sr-only">Last Name</label>
        <asp:TextBox class="form-control" placeholder="Last Name" ID="inputLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="lastNameValidator" runat="server" ControlToValidate="inputLastName" ErrorMessage="Lastname is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        
        <label for="inputEmail" class="sr-only">Last Name</label>
        <asp:TextBox class="form-control" placeholder="Email" ID="inputEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="emailValidator" runat="server" ControlToValidate="inputEmail" ErrorMessage="Email is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator validationgroup="registerGroup" ID="emailValidatorRegex" runat="server" ErrorMessage="Invalid Email" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="inputEmail"></asp:RegularExpressionValidator>
        
        <label for="inputUsername" class="sr-only">Username</label>
        <asp:TextBox class="form-control" placeholder="Username" ID="inputUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="usernameValidator" runat="server" ControlToValidate="inputUsername" ErrorMessage="Username is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
       
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox class="form-control" TextMode="Password" placeholder="Password" ID="inputPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="passwordValidator" runat="server" ControlToValidate="inputPassword" ErrorMessage="Password is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>

         <label for="inputConfirmPassword" class="sr-only">Password</label>
        <asp:TextBox class="form-control" placeholder="Confirm Password" ID="inputConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator validationgroup="registerGroup" ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="inputPassword" ForeColor="#FF3300" ControlToValidate="inputConfirmPassword"></asp:CompareValidator>
        <asp:RequiredFieldValidator validationgroup="registerGroup" ID="confirmPasswordValidator" runat="server" ControlToValidate="inputConfirmPassword" ErrorMessage="Password is mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>

        <asp:Button validationgroup="registerGroup" class="btn btn-lg btn-primary btn-block" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <asp:Label ID="lblError" ForeColor="#FF3300" runat="server"></asp:Label>
        <br />
    </div>
</asp:Content>
