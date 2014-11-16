using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

// Unfortunately this is poorly documented.  
// XSRF = Cross Site Request Forgery.  
// (1) You have a membership on this website.  You're
//     already logged in.
// (2) You visit a different website or receive an 
//     email with a disguised malicious hyperlink.
//     That hyperlink will cause you to take some
//     action on this website, like clicking a
//     link to delete something.
// (3) You click the link and the browser attaches
//     cookies for the requested domain.  The cookies
//     are how ASP.NET keeps track of your identity 
//     and is part of the authentication system.
// (4) The webserver for this site receives the
//     request and the cookies and processes, validates
//     authentication, and performs the undesired 
//     malicious action on your behalf.

// Unfortunately, the solution below only works for POSTs.
// You could implement similar functionality for GETs that
// stick the anti-xcrf token in the querystring for each
// outgoing URL.

// To combat this:
// (1) You log into the website and are authenticated.
// (2) You are redirected to some page, say, the home
//     page.  ASP.NET Web Forms will add a cookie along 
//     with the response that contains a "token" 
//     (a "single use hall pass" called a "nonce").
//     Also, an anti-csrf "token" that is paired with the
//     nonce is added to ViewState (for POSTs).  This
//     is the ViewStateUserKey that you'll see below.
// (3) The you click a link on the home page and the
//     request, along with the nonce and anti-csrf ViewState
//     value, is sent to the server.
// (4) The server validates the nonce against the anti-csrf
//     ViewState value before allowing the requested action to 
//     be performed.
// (5) The process repeats for each webpage request with a
//     new nonce and anti-csrf ViewState.

// Note line 59:  private string _antiXsrfTokenValue;
// That value is set in the Page_Init, but then referenced
// in the master_Page_PreLoad, which was added to handle
// the page's PreLoad event in line 100.

namespace HeroVsRobot
{
  public partial class SiteMaster : MasterPage
  {
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
      // The code below helps to protect against XSRF attacks
      var requestCookie = Request.Cookies[AntiXsrfTokenKey];
      Guid requestCookieGuidValue;

      // If the user already has a cookie and it seems to work, 
      // then grab out the anti-csrf value from the cookie and
      // set it to the Page's ViewStateUserKey, which is where
      // the anti-csrf is stored in ViewState (see #2, above).

      if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
      {
        // Capture the EXISTING Anti-XSRF token from the cookie
        // to be evaluated in line 130.
        _antiXsrfTokenValue = requestCookie.Value;
        Page.ViewStateUserKey = _antiXsrfTokenValue;
      }
      else
      {
        // Generate a new Anti-XSRF token and save to the cookie
        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        Page.ViewStateUserKey = _antiXsrfTokenValue;

        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        {
          HttpOnly = true,
          Value = _antiXsrfTokenValue
        };
        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        {
          responseCookie.Secure = true;
        }
        Response.Cookies.Set(responseCookie);
      }

      Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // Set Anti-XSRF token
        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
      }
      else
      {
        // THIS IS WHERE ALL THE MAGIC HAPPENS
        // First, this is a postback situation.
        // Next, there are two conditions ...
        // (1) IF the cookie and ViewState do not match, 
        //     then throw an error.
        // (2) IF the ViewState USER NAME and the Logged In 
        //     User's Name do not match, then throw an error.
        //     Confusingly, ViewState[AntiXsrfUserNameKey]
        //     is never set. 

        // Validate the Anti-XSRF token

        /* Commented out by Bob ... see note below ...
         * 
        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
            || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        {
            throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        }
         */
        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue)
        {
          throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        }
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
      Context.GetOwinContext().Authentication.SignOut();
    }
  }

}

// So, I think this solution is kind of fragile.  First, to my knowledge
// it does nothing for GETs because (a) a GET is not a postback and therefore
// line 126 never happens, and the larger issue, (b) ViewState is not sent
// in a GET request.
//
// Second, line #126 is wrong ... if the user double-clicks the button to
// Register (and possibly log in, although I've not tested it) they will
// trigger the error.  The problem is that the first click is processed
// and the user is now logged in, thus their Context.User.Identity.Name
// is not an empty string.  So on the second click,  Context.User.Identity.Name
// is not an empty string but ViewState[AntiXsrfUserNameKey] is
// never set in this project template and therefore it will always be
// an empty string, this it will trigger this exception.
// I've fixed this by removing the or || check.

// If the GET functionality is important to you, you may want to check out
// https://www.owasp.org/index.php/.Net_CSRF_Guard
// Note: I've not tried it.