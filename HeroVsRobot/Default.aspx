<%@ Page AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeroVsRobot._Default" Language="C#" MasterPageFile="~/Site.Master" Title="Home Page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="container">
    
<asp:Panel ID="introPanel" runat="server" Visible="true">
    
        <div class="row" style="margin-top:20px;"></div>

        <div class="row">
            <div class="hidden-xs">
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                  <!-- Indicators -->
                  <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                  </ol>

                  <!-- Wrapper for slides -->
                  <div class="carousel-inner" role="listbox">
                    <div class="item active">
                      <img src="/Content/intro-01.png" alt="...">
                      <div class="carousel-caption">
                        <h1>Hero vs Robot</h1>
                        <h3>A friendly, casual game.<br />It's just humanity's fate at stake.  No sweat.</h3>
                      </div>
                    </div>
                    <div class="item">
                      <img src="/Content/intro-02.png" alt="...">
                      <div class="carousel-caption">
                        <h1>You're the hero.<br/>Go destroy robots.</h1>
                          <h3>The more you destroy, the more Space Credits you earn.</h3>
                      </div>
                    </div>
                    <div class="item">
                      <img src="/Content/intro-03.png" alt="...">
                      <div class="carousel-caption">
                        <h1>Move Up the Ranks.</h1>
                          <h3>The more Space Credits you earn, the higher your rank.</h3>
                      </div>
                    </div>
                  </div>

                  <!-- Controls -->
                  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div>

            </div>
        </div>
</asp:Panel>

<asp:Panel ID="surfacePanel" runat="server" Visible="true">
    <div class="row">
        <div class="hidden-xs">
            <img src="/Content/gameboard.png" width="1280" height="350" usemap="#SURFACE" class="img-responsive headerImage">
            <map name=SURFACE>
                <area shape=rect coords="4,6,196,347" href="default.aspx?action=large" alt="Termination Target 1" class="preview"  data-content="Accept commission to destroy a difficult robot. Largest risk, largest reward.">
                <area shape=rect coords="202,9,354,349" href="default.aspx?action=medium" alt="Termination Target 2" class="preview" data-content="Accept commission to destroy a moderately difficult robot. Moderate risk, moderate reward.">
                <area shape=rect coords="360,8,510,349" href="default.aspx?action=small" alt="Termination Target 3" class="preview"  data-content="Accept commission to destroy an easy robot. Smallest risk, smallest reward.">
                <area shape=rect coords="654,11,780,348" href="default.aspx?action=lab" alt="Lab" class="preview" data-content="Buy armor upgrade. Cost: 10 Credits.">
                <area shape=rect coords="789,10,916,347" href="CommandCenter.aspx" alt="Command Center" class="preview" data-content="View a history of your recent actions and results.">
                <area shape=rect coords="921,13,1022,346" href="default.aspx?action=medic" alt="Medic Bay" class="preview" data-content="Go to Medic Bay and restore / improve your health. Cost: 1 Credit.">
                <area shape=rect coords="1028,10,1161,346" href="default.aspx?action=armory" alt="Armory" class="preview" data-content="Buy weapon upgrade. Cost: 10 Credits.">
                <area shape=rect coords="1168,10,1274,346" href="default.aspx?action=port" alt="Port" class="preview"  data-content="Not available yet.">
            </map>
        </div>
    </div>


    <div class="panel panel-primary hidden-xs">
        <div class="panel-heading">
            <h3 id="panelTitle" class="panel-title">Hint</h3>
        </div>
        <div id="panelBody" class="panel-body">
            Hover over structure to preview action.  Click it to take action.
        </div>
    </div>

</asp:Panel>
        
<asp:Panel runat="server" ID="visitorPanel">
    <div class="row">
        <div class="col-md-4">    
            <p>&nbsp;</p><h4><a href="Account/Register.aspx">Click here</a> to get started!</h4>
        </div>
        <div class="col-md-8">

            <h3 class="text-muted text-uppercase"><strong>Your Mission</strong></h3>
            <p>You are a genetically modified human clone, one of thousands who were created with one goal: kill all sentient machines from Sergei, an AI life form, the original Singularity that put humans under subjection hundreds of years ago.</p>
            <p>You are part of an initiative started over 150 years ago called Aetris.  The Aetris Initiative is a response to winning back earth from Sergei networked machines.  When Sergei left earth to do what it was originally designed to do: find new information and index it — the citizens of earth sought to trace Sergei’s path through the galaxy in an effort to eradicate all of its tentacles from existence.</p>
            <p>Your cloned physique and mind have been designed and developed here on Outpost 23 to endure the hardship of space travel and destroying robots.  Due to the nature of the mission and the enemy's unique ability to intercept and modify communications, you are completely autonomous.  You will take on termination missions at known Sergei hives.  Upon the successful completion of each mission, you will earn credits towards your rank in the Aetris Initiative.  Credits can also be used to upgrade your standard issued armor and weapon.</p>
            <h3 class="text-muted text-uppercase"><strong>Historical Context</strong></h3>
            <div class="row">
                <div class="col-md-8 col-sm-8">
                    <p>Until the year 2055, the Sergei coproration had become the world’s leader in dissemination of information technology, satellite technology, space travel technology and military robotics technology.  In 2055, massive investments in artificial intelligence produced the singularity known as Sergei.  Sergei’s original mission was to collect and index as much information as possible.  Sergei interpreted that as a license to filter all communication between humans via internet and sattelite.</p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img src="/Content/sergei-logo.png" class="img-responsive" />
                </div>
            </div>
            <p>When it grew bored at the pace of human interaction, it decided to engage in a campaign of disinformation and propaganda to observe human reaction.  By the time this was discovered, Sergei had already fired all engineers from the company and locked their access to all Sergei corporation assets.  Militaries of the world decided to take action, but since the Sergei corporation had developed most of robotic technology they used, Sergei commandeered the machines and essentially became weaponized.  At that point, the man vs. machine wars began.  Men were limited to using out of date weapons to fight a battle against an opponent that could communicate faster and mobilze its robotic army more quickly than mankind.  Millions of humans were killed, and those who survived were driven into concentration camps.</p>
            <img src="/Content/war.png" class="img-responsive" />
            <p>With humanity in check, the Singularity’s thirst for knowledge drove it to commandeer the spaceships that the Sergei corporation had developed.  Hundreds of Sergei space-crafts each filled with thousands of Segei-bots launched.  It’s mission: explore, collect and index the information.</p>
            <p>With its numbers dramatically reduced on earth, a unified uprising beat Sergei back and, eventually, after millions more had died, reclaimed earth.  However, without the Segei technology available, it set humanity back 50 years.</p>
            <img src="/Content/war2.png" class="img-responsive" />
            <p>A unified humanity developed the Aetris Initiative.  Mankind would take the offensive against Sergei, hunting down every last Sergei-bot in every last hive to eradicate it from existence.  This would require tracing the steps of Sergei space crafts, establishing posts at each destination, and taking them out one at a time.</p>
            <p>Engineers with the Aetris Initiative developed Gu, the operating system of your neural implants.  Gu provides you, the Hero, with all of the skill and knowledge of how to destroy each of the three types of Sergei-bots.</p>
            <h3 class="text-muted text-uppercase"><strong>The goal</strong></h3>
            <p>This is a very simple game that pits your hero versus a Robot to see who wins.</p>
            <p><strong>The goal of the game is to accumulate as many Space Credits as possible.</strong> You earn Space Credits by knocking out Robots.  The trade-off is that you must sometimes spend Space Credits in order to make Space Credits.  It's a gamble.</p>
            <h3 class="text-muted text-uppercase"><strong>Gameplay</strong></h3>
            <p>Every hour you get 25 additional moves.  During a move, you can fight a Robot, train to temporarily improve your fighting ability, or upgrade your weapon or armor to increase your damage dealt and received.</p>  
            <h3 class="text-muted text-uppercase"><strong>Fighting</strong></h3>
            <p>You knock out a Robot by attaching it until its health reaches zero. The amount of damage inflicted by you and on you is random, but can be buffed with Training, Armor and Weapon improvements.  If your hero is defeated (or is knocked out in a tie) you lose your remaining moves for the hour.</p>
            <img src="/Content/robots.png" class="img-responsive"/>
            <h3 class="text-muted text-uppercase"><strong>Hourly Reset</strong></h3>
            <p>Each hour on the hour your Health, Moves Remaining, and Training Level reset.</p>
            <div class="row">
                <div class="col-md-8 col-sm-8">
                    <h3 class="text-muted text-uppercase"><strong>Training</strong></h3>
                    <p>Training increases the POTENTIAL amount of damage you inflict by up to 10. Relatively inexpensive, but is temporary - it resets each hour.</p>
                    <h3 class="text-muted text-uppercase"><strong>Weapon Improvements</strong></h3>
                    <p>Weapon improvements also increase the POTENTIAL amount of damage you inflict, but it is permanent.  Each time you improveyour weapon, it will increase the POTENTIAL damage up to 10 points.  Unfortunately, it is also very expensive.</p>
                    <h3 class="text-muted text-uppercase"><strong>Armor Improvements</strong></h3>
                    <p>Armor improvements decrease the POTENTIAL damage you incur from the Robot's attack up to 10 points.  This, to, is very expensive.</p>                    
                </div>
                <div class="col-md-4 col-sm-4">
                    <img src="/Content/soldier.png" class="img-responsive" />        
                </div>
            </div>
            

            <h3 class="text-muted text-uppercase"><strong>Medic Bay</strong></h3>
            <p>The Medic Bay restores and POTENTIALLY improves your health by up to 20 points with each visit.  Its effects are temporary - the hourly reset puts you back at 50 health.</p>
        </div>
    </div>
</asp:Panel>        
        
<asp:Panel ID="playerPanel" runat="server" Visible="false">
    <div class="row">
        <div class="col-md-4">
                <h3><asp:Literal ID="heroLiteral" runat="server"></asp:Literal>'s Stats:</h3>
                <div class="row">
                    <div class="col-md-6 col-xs-6"><strong>Credits</strong></div>
                    <div class="col-md-6 col-xs-6">
                        <strong><asp:Literal ID="goldLiteral" runat="server"></asp:Literal></strong>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Moves Remaining</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="movesLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Health Remaining</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="healthLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Training Level</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="trainingLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Weapon</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="WeaponLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Armor</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="armorLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Wins</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="winsLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-xs-6">Losses</div>
                    <div class="col-md-6 col-xs-6">
                        <asp:Literal ID="lossesLiteral" runat="server"></asp:Literal>
                    </div>
                </div>
        </div>
        <div class="col-md-4">
               <h2>Action Results:</h2>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="resultLabel" runat="server" Text="Awaiting your next action ..." />
                    </div>
                </div>
        </div>
        <div class="col-md-4 visible-xs hidden-sm hidden-md hidden-lg">
                <h2>Actions:</h2>
                <div class="row" style="padding-bottom:15px;">
                    <div class="col-md-6">
                        <asp:Button runat="server" OnClick="TrainButton_Click" Text="Train (Cost 1 Credit)" CssClass="btn btn-default" />
                    </div>
                </div>                

                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" OnClick="UpgradeWeapon_Click" Text="Upgrade Weapon (Cost 10 Credits)" CssClass="btn btn-default" />
                    </div>
                </div> 
            
                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" OnClick="UpgradeArmor_Click" Text="Upgrade Armor (Cost 10 Credits)" CssClass="btn btn-default" />
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" ID="DifficultRobotButton" OnClick="DifficultRobotButton_Click" Text="Fight Difficult Robot" CssClass="btn btn-default" />
                    </div>
                </div> 
                
                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" ID="ModerateRobotButton" OnClick="NormalRobotButton_Click" Text="Fight Moderate Robot" CssClass="btn btn-default" />
                    </div>
                </div> 

                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" ID="EasyRobotButton" OnClick="EasyRobotButton_Click" Text="Fight Easy Robot" CssClass="btn btn-default" />
                    </div>
                </div> 

                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" ID="MedicBayButton" OnClick="MedicBayButton_Click" Text="Medic Bay (Cost 1 Credit)" CssClass="btn btn-default" />
                    </div>
                </div> 

                <div class="row">
                    <div class="col-md-6" style="padding-bottom:15px;">
                        <asp:Button runat="server" ID="CommandCenterButton" OnClick="CommandCenterButton_Click" Text="Command Center" CssClass="btn btn-default" />
                    </div>
                </div> 

        </div>
    </div>
</asp:Panel>

</div>
</asp:Content>

<asp:Content ID="scriptContent" ContentPlaceHolderID="ScriptContent" runat="server">

<script src="Scripts/jquery.rwdImageMaps.min.js"></script>
<script>
    $(document).ready(function () {
        $('img[usemap]').rwdImageMaps();
        $('.preview').hover(
            function () { $('#panelTitle').text($(this).attr('alt'));
                          $('#panelBody').text($(this).data('content')); },
            function () { $('#panelTitle').text('Hint'); 
                          $('#panelBody').text('Hover over structure to preview action.  Click it to take action.');}
            );
    });

</script>

</asp:Content>
