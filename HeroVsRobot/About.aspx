<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HeroVsRobot.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>This project was purely for fun.  It was an opportunity to learn a lot 
        about Microsoft Azure Websites (deployment, administration, etc.), WebJobs, 
        ASP.NET Identity 2.0, Bootstrap 3, Entity Framework Code First Migrations
        and more.
    </p>
    <h3>Version History</h3>
    <h4>Version 0.3</h4>
    <p>
        <ul>
            <li>Changed from Monsters to Robots (Yay!)</li>
            <li>Added Bootstrap Carousel and other images on home page.</li>
            <li>Improved the backstory.</li>
            <li>Improved the rules explanation.</li>
            <li>Improved user interface with planet surface image, imagemaps, hover-over explanations, etc.</li>
            <li>Added Command Center to log all player actions using CQRS design pattern with Azure queues and tables.</li>
            <li>Changed the Leaderboard, put it on its own page to reduce database hits.</li>
            <li>Improved battle details feedback.</li>
            <li>Improved gameplay by making more elements random. (Thanks to @MauRiEEZZZ for his persistence, and my buddy starrzan for his feedback.)</li>
            <li>Improved error screen.  Now friendlier. (Now quit breaking my stuff @Hermitization ;)</li>
            <li>Fixed the persistent issue with dashes in email addresses.  This time, you should be able to both register AND ACTUALLY PLAY without the "Enter a valid email address" error. (Sorry again, @Hermitization ... hopefully we got it this time)</li>
            <li>Under the hood: dramatic changes.  Restructured the code to be more layered and OO to enable future change.</li>
        </ul>
    </p>
    <p>Also, shortly after Version 0.2, I was alerted to several breaking changes / issues that I fixed:</p>
    <ul>
        <li>Fixed the DNS mapping issue. (Thank you @JoelBennett)</li>
        <li>Fixed the loss of social logins. (Thanks again, @JoelBennet)</li>
        <li>Fixed the problem with the Facebook login not setup correctly. (Thanks yet once again @JoelBennett and @cradtabor)</li>
    </ul>
    <h4>Version 0.2</h4>
    <p>
        <ul>
            <li>Improved mobile experience dramatically. (Big thanks to @Scimac)</li>
            <li>Relaxed password strength requirements. (Thanks to @azizyoqubjanov)</li>
            <li>Fixed Cross-Site Scripting Issue when you double-tap the Register button. (HUGE thanks to @Hermitization)</li>
            <li>Fixed issue allowing email addresses with dashes to be used. (Thanks to @TVsBen)</li>
            <li>Fixed minor confusing wording. (Thanks to @MauRiEEZZZ)</li>
            <li>Fixed Leaderboard not updating after an action. (Thanks to @desync0 and @MauRiEEZZZ)</li>
            <li>Fixed registration link; removed once logged in (Thanks to @azizyoqubjanov)</li>
        </ul>
    </p>
    <h4>Version 0.1</h4>
    <p>Initial release.</p>
</asp:Content>
