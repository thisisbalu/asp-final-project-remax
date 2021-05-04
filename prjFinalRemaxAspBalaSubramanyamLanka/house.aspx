<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/house.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card">
            <h5 style="margin-bottom: 40px;"><u>HOUSE DETAILS</u></h5>
            <div class="container-fliud">
                <div class="wrapper row">
                    <div class="preview col-md-6">
                        <div class="preview-pic tab-content">
                            <div class="tab-pane active" id="pic-1">
                                <asp:Image ID="imgHouse" runat="server" Width="500" ImageUrl="http://placekitten.com/400/252" />
                            </div>
                        </div>
                    </div>
                    <div class="details col-md-6">
                        <h3 class="product-title">
                            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                        </h3>
                        <h5>
                            <asp:Label ID="lblCityProvince" runat="server" Text="Label"></asp:Label>
                        </h5>
                        <p class="product-description">
                            <asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label>
                        </p>
                        <h4 class="price">current price: <span>
                            <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></span></h4>
                        <p class="vote">
                            <strong>Beds: </strong>
                            <asp:Label ID="lblBeds" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <strong>Baths: </strong>
                            <asp:Label ID="lblBaths" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <strong>SqFeet: </strong>
                            <asp:Label ID="lblSqFtArea" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="vote">
                            <strong>MLS: </strong>
                            <asp:Label ID="lblMLS" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <strong>Type: </strong>
                            <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
                <h5 style="margin-bottom: 40px; margin-top: 40px;"><u>AGENT DETAILS</u></h5>
                <div class="wrapper row">
                    <div class="preview col-md-3">
                        <div class="preview-pic tab-content">
                            <div class="tab-pane active" id="pic-1">
                                <asp:Image ID="imgAgent" runat="server" Width="200" ImageUrl="http://placekitten.com/400/252" />
                            </div>
                        </div>
                    </div>
                    <div class="details col-md-9">
                        <p class="vote">
                            <strong>Name: </strong>
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblID" Visible="false" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="vote">
                            <strong>Email: </strong>
                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="vote">
                            <strong>                            
                                <asp:Label ID="lblSendMessageTitle" Text="Send a quick message" runat="server"></asp:Label>
                            </strong>
                        </p>
                        <p class="vote">
                            <asp:TextBox ID="txtSubject"  placeholder="Subject" runat="server" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="subjectValidator" runat="server" ErrorMessage="Subject is mandatory" ForeColor="#FF3300" ValidationGroup="houseAgentMessage" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                        </p>
                        <p class="vote">
                            <asp:TextBox ID="txtMessage" placeholder="Message" runat="server" Rows="5" TextMode="MultiLine" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="messageValidator" runat="server" ErrorMessage="Message is mandatory" ForeColor="#FF3300" ValidationGroup="houseAgentMessage" ControlToValidate="txtMessage"></asp:RequiredFieldValidator>
                        </p>
                        <p class="vote">
                            <asp:Button ValidationGroup="houseAgentMessage" type="button" ID="btnSend" runat="server"  OnClick="btnSendMessage_Click" Text="Send" />
                        </p>
                        <p class="vote">
                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
