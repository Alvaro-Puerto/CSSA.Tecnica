using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSSA.Proyecto.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string Moneda { get; set; }

        public DateTime FechaHoraCreacion { get; set; } = DateTime.Now;
    }
}