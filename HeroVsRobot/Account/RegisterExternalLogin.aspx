﻿<%@ Page Title="Register an external login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="HeroVsRobot.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Register with your <%: ProviderName %> account</h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Association Form</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                You've authenticated with <strong><%: ProviderName %></strong>. Please enter an Email Address and a Hero Name below for the current site
                and click the Log in button.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="EmailTextBox" CssClass="col-md-2 control-label">Email:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="EmailTextBox" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailTextBox"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="The Email field is required." />
                    <asp:ModelErrorMessage runat="server" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="HeroNameTextbox" CssClass="col-md-2 control-label">Hero Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="HeroNameTextbox" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="HeroNameTextbox"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Hero Name is required" />
                    <asp:ModelErrorMessage runat="server" CssClass="text-error" />
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
