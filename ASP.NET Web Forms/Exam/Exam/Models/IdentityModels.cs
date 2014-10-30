namespace NewsSite.Models
{
    using System;
    using System.Data.Entity;

    using NewsSite.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
            : base("NewsSiteConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Like> Likes { get; set; }

    }
}

#region Helpers

namespace NewsSite
{
    using System;
    using System.Web;
    using NewsSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";
        
        public static void SignIn(ApplicationUserManager manager, AppUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        
        public const string ProviderNameKey = "providerName";
        
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }
        
        public const string CodeKey = "code";
        
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }
        
        public const string UserIdKey = "userId";
        
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }
        
        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = string.Format("/Account/ResetPassword?{0}={1}", CodeKey, HttpUtility.UrlEncode(code));
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }
        
        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = string.Format("/Account/Confirm?{0}={1}&{2}={3}", CodeKey, HttpUtility.UrlEncode(code), UserIdKey, HttpUtility.UrlEncode(userId));
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }
        
        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }
        
        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}

#endregion
