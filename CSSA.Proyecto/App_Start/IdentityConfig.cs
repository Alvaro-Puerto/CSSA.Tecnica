using CSSA.Proyecto.DBContext;
using CSSA.Proyecto.Util;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.App_Start
{
    public class IdentityConfig : UserManager<ConfiguracionUsuario>
    {
        public IdentityConfig(IUserStore<ConfiguracionUsuario> store)
            : base(store)
        {
        }

        public static IdentityConfig Create(IdentityFactoryOptions<IdentityConfig> options, IOwinContext context)
        {
            var manager = new IdentityConfig(new UserStore<ConfiguracionUsuario>(context.Get<CSSAContext>()));
          
            manager.UserValidator = new UserValidator<ConfiguracionUsuario>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };


            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ConfiguracionUsuario>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}