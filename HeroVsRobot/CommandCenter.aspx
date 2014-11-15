<%@ Page Title="Command Center" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommandCenter.aspx.cs" Inherits="HeroVsRobot.CommandCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <p>Showing only the last 10 events in descending order 
        (most recent items are first).  All times are 
        Greenwich Mean Time (GMT).  Current time: <%: Time %></p>
    <asp:Literal ID="historyLiteral" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>