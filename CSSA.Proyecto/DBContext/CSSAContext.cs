using CSSA.Proyecto.Util;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.DBContext
{
    public class CSSAContext : IdentityDbContext<ConfiguracionUsuario>
    {
        public CSSAContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CSSAContext Create()
        {
            return new CSSAContext();
        }
    }
}