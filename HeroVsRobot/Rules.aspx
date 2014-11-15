<%@ Page Title="Backstory and Rules" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="HeroVsRobot.Rules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>

    <div class="container">
    <div class="row">
        <div class="col-md-4">    
            <img src="/Content/commander.png" class="hidden-xs hidden-sm img-responsive" style="margin-top:20px;" />
        </div>
        <div class="col-md-8">
            <h3 class="text-muted text-uppercase"><strong>Your Mission</strong></h3>
            <p>You are a genetically modified human clone, one of thousands who were created with one goal: kill all sentient machines from Sergei, an AI life form, the original Singularity that put humans under subjection hundreds of years ago.</p>
            <p>You are part of an initiative started over 150 years ago called Aetris.  The Aetris Initiative is a response to winning back earth from Sergei networked machines.  When Sergei left earth to do what it was originally designed to do: find new information and index it — the citizens of earth sought to trace Sergei’s path through the galaxy in an effort to eradicate all of its tentacles from existence.</p>
            <p>Your cloned physique and mind have been designed and developed here on Outpost 23 to endure the hardship of space travel and destroying robots.  Due to the nature of the mission and the enemy's unique ability to intercept and modify communications, you are completely autonomous.  You will take on termination missions at known Sergei hives.  Upon the successful completion of each mission, you will earn credits towards your rank in the Aetris Initiative.  Credits can also be used to upgrade your standard issued armor and weapon.</p>
            <h3 class="text-muted text-uppercase"><strong>Historical Context</strong></h3>
            <p>Until the year 2055, the Sergei coproration had become the world’s leader in dissemination of information technology, satellite technology, space travel technology and military robotics technology.  In 2055, massive investments in artificial intelligence produced the singularity known as Sergei.  Sergei’s original mission was to collect and index as much information as possible.  Sergei interpreted that as a license to filter all communication between humans via internet and sattelite.</p>
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
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
