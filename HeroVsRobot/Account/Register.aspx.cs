using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using HeroVsRobot.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using HeroVsRobot.Models;

namespace HeroVsRobot.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            
            var user = new ApplicationUser
            {
                UserName = EmailTextBox.Text,
                Email = EmailTextBox.Text
            };

          IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

              using (var heroContext = new HeroContext())
              {
                var hero = new Hero
                {
                  UserId = user.Id,
                  Name = HeroNameTextbox.Text,
                  MovesRemaining = 25,
                  Credits = 10,
                  Health = 50,
                  TrainingLevel = 0,
                  ArmorBonus = 0,
                  WeaponBonus = 0,
                  Wins = 0,
                  Losses = 0
                };
                heroContext.Heroes.Add(hero);
                heroContext.SaveChanges();
              }
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}