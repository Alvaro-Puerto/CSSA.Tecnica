using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CSSA.Proyecto.Util
{
    public class ConfiguracionUsuario : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ConfiguracionUsuario> manager, string authenticationType)
        {
            var userEntity = await manager.CreateIdentityAsync(this, authenticationType);

            return userEntity;
        }
    }
}