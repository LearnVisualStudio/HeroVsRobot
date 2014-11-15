using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeroVsRobot
{
  public class CustomUserValidator<TUser> : IIdentityValidator<TUser>
  where TUser : class, IUser
  {
    private readonly static Regex EmailRegex;

    private readonly UserManager<TUser> _manager;

    static CustomUserValidator()
    {
      CustomUserValidator<TUser>.EmailRegex = new Regex("^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    public CustomUserValidator()
    {
    }

    public CustomUserValidator(UserManager<TUser> manager)
    {
      this._manager = manager;
    }

    public async Task<IdentityResult> ValidateAsync(TUser item)
    {
      IdentityResult identityResult;
      List<string> strs = new List<string>();
      if (!CustomUserValidator<TUser>.EmailRegex.IsMatch(item.UserName))
      {
        strs.Add("Enter a valid email address.");
      }
      if (this._manager != null)
      {
        TUser tUser = await this._manager.FindByNameAsync(item.UserName);
        if (tUser != null && tUser.Id != item.Id)
        {
          strs.Add("Select a different email address. An account has already been created with this email address.");
        }
      }
      identityResult = (strs.Any<string>() ? IdentityResult.Failed(strs.ToArray()) : IdentityResult.Success);
      return identityResult;
    }
  }
}