using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.Dtos
{
    public class RegistroDto
    {

        [Required]
        public string username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasena { get; set; }

        [Required]
        public string ConfirmarContrasena { get; set; }
    }
}