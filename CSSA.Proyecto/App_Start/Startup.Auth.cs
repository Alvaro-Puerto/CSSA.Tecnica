using CSSA.Proyecto.DBContext;
using CSSA.Proyecto.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.App_Start
{
	public class Startup
	{
	public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            
            app.CreatePerOwinContext(CSSAContext.Create);
            app.CreatePerOwinContext<IdentityConfig>(IdentityConfig.Create);

            // Habilitar la aplicación para que use una cookie para almacenar la información del usuario que inició sesión
            // y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new OAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
               
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);

        }
	}
}