using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppSignalRCoreWithChannel.Application
{
    public static class ContextUser
    {
        public static ClaimsPrincipal Create(string username)
        {

            var claims = new List<Claim>(){
                    new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, "https://yourdomain.com")
                };
            var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            //    userPrincipal,
            //    new AuthenticationProperties
            //    {
            //        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
            //        IsPersistent = false,
            //        AllowRefresh = false
            //    });
            //HttpContext.User = userPrincipal;

            return userPrincipal;

        }
    }
}
