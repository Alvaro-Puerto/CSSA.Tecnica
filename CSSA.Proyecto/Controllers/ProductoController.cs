using CSSA.Proyecto.DBContext;
using CSSA.Proyecto.Dtos;
using CSSA.Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSSA.Proyecto.Controllers
{
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {

        CSSAContext _context = new CSSAContext();

        /// <summary>
        /// Lista todos los articulos
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var productos = new List<Producto>();

            productos = await _context.Producto.ToListAsync();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        /// <summary>
        /// Lista un articulo determinado 
        /// </summary>
        [HttpGet]
        [Route("Show")]
        public IHttpActionResult Show(int id)
        {
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        ///<summary>
        /// Buscar un articulo por su nombre
        ///</summary>
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string parametro)
        {
            var productos = new List<Producto>();

            productos = _context.Producto.Where(p => p.Nombre.Contains(parametro)).ToList();

            if (productos.Count < 0)
            {
                return NotFound();
            }

            return Ok(productos);

        }



        ///<summary>
        /// Crea un nuevo producto 
        ///</summary>
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(ProductoDto producto)
        {
            var productoR = new Producto();

            productoR.Nombre = producto.Nombre;
            productoR.Precio = producto.Precio;
            productoR.Moneda = producto.Moneda;
            productoR.Descripcion = producto.Descripcion;

            var result = _context.Producto.Add(productoR);
            _context.SaveChanges();

            return Ok(productoR);
        }


        ///<summary>
        /// Actualiza un producto
        ///</summary>
        [Route("Put")]
        public async Task<IHttpActionResult> Put(int id, ProductoDto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productoR = await _context.Producto.FindAsync(id);

            if (productoR == null)
            {
                return NotFound();
            }

            productoR.Nombre = producto.Nombre;
            productoR.Precio = producto.Precio;
            productoR.Moneda = producto.Moneda;
            productoR.Descripcion = producto.Descripcion;

            _context.SaveChanges();

            return Ok(productoR);
        }


        ///<summary>
        /// Borra un registro 
        ///</summary>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var productoR = await _context.Producto.FindAsync(id);

            if (productoR == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(productoR);
            _context.SaveChanges();

            return Ok(productoR);
        }

    }
}
