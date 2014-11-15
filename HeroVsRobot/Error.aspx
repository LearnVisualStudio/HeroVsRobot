<%@ Page Title="You Opened the Gates of Hell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HeroVsRobot.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Uh oh...</h4>
                    <hr />
                    <p>You unearthed a rare and dangerous form of evil, the likes
                        of which mankind has never seen before.  You should contact
                        <a href="mailto:bob@learnvisualstudio.net">the most 
                            powerful Hero in this domain</a> 
                        by messenger pigeon email and tell him what you did so that 
                        he can try to save humanity from this evil fate!
                    </p>
                    <p>(In other words, if you think this is a bug, please
                        write me:  <a href="mailto:bob@learnvisualstudio.net">bob@Learnvisualstudio.net</a> 
                        and let me know what you did.  Screenshots
                        and detailed explanations are appreciated!)
                    </p>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
