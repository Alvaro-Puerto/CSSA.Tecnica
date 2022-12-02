using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string Moneda { get; set; }
    }
}