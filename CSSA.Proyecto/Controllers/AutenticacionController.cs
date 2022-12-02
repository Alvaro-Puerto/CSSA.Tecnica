using CSSA.Proyecto.App_Start;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using CSSA.Proyecto.Dtos;
using CSSA.Proyecto.Util;
using System.Linq;

namespace CSSA.Proyecto.Controllers
{
    public class AutenticacionController : ApiController
    {
        private IdentityConfig _manager;

        public AutenticacionController()
        {
        }

        public AutenticacionController(IdentityConfig userManager)
        {
            UserManager = userManager;
        }

        public IdentityConfig UserManager
        {
            
            get
            {
                return _manager ?? Request.GetOwinContext().GetUserManager<IdentityConfig>();
            }
            private set
            {
                _manager = value;
            }
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        [HttpPost]
        [Route("Registro")]
        public async Task<IHttpActionResult> Register(RegistroDto registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ConfiguracionUsuario() { Email = registro.Email, UserName = registro.username };

            IdentityResult result = await UserManager.CreateAsync(user, registro.Contrasena);

            if (!result.Succeeded)
            {
                return ObtenerErrores(result);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(LoginDto login)
        {
            return Ok(new { Token = "ok" });
        }

        private IHttpActionResult ObtenerErrores(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}
