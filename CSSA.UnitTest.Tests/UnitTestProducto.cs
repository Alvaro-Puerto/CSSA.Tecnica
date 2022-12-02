using CSSA.Proyecto.Controllers;
using CSSA.Proyecto.Dtos;
using CSSA.Proyecto.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CSSA.UnitTest.Tests
{
    [TestClass]
    public class UnitTestProducto
    {

        [TestClass]
        public class ProductoTesting
        {

            [TestMethod]
            public void ObtenerProducto404()
            {
                var controller = new ProductoController();

                var result = controller.Show(999);

                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }

            [TestMethod]
            public void InsertarProducto()
            {
                var controller = new ProductoController();

                var producto = new ProductoDto()
                {

                    Nombre = "Cafe Test",
                    Descripcion = "Cafe Test",
                    Precio = 25,
                    Moneda = "C$",
                };

                var productoR = controller.Post(producto);

                Assert.IsNotInstanceOfType(productoR, typeof(OkResult));

            }

            [TestMethod]
            public async Task ListarProducto()
            {

                var controller = new ProductoController();

                var producto = new ProductoDto()
                {

                    Nombre = "Cafe Test",
                    Descripcion = "Cafe Test",
                    Precio = 25,
                    Moneda = "C$",
                };

                var productoR = controller.Post(producto);

                var _result = await controller.Get() as OkNegotiatedContentResult<List<Producto>>;

                Assert.AreEqual(_result.Content[0].Nombre, "Cafe Test");
            }

            [TestMethod]
            public async Task ActualizarProducto()
            {

                var controller = new ProductoController();

                var producto = new ProductoDto()
                {

                    Nombre = "Cafe Test",
                    Descripcion = "Cafe Test",
                    Precio = 25,
                    Moneda = "C$",
                };

                var productoR = controller.Post(producto) as OkNegotiatedContentResult<Producto>;

                var productoUpdate = new ProductoDto()
                {
                    Nombre = "Cafe Test Actualizado",
                    Descripcion = "Cafe Test Actualizado",
                    Precio = 50,
                    Moneda = "C$",
                };

                _ = await controller.Put(productoR.Content.ProductoId, productoUpdate);

                var result = controller.Show(productoR.Content.ProductoId) as OkNegotiatedContentResult<Producto>;

                Assert.AreEqual(result.Content.Nombre, productoUpdate.Nombre);


            }

            [TestMethod]
            public async Task EliminarProducto()
            {
                var controller = new ProductoController();

                var producto = new ProductoDto()
                {

                    Nombre = "Cafe Test",
                    Descripcion = "Cafe Test",
                    Precio = 25,
                    Moneda = "C$",
                };

                var productoR = controller.Post(producto) as OkNegotiatedContentResult<Producto>;

                await controller.Delete(productoR.Content.ProductoId);

                var result = controller.Show(productoR.Content.ProductoId);

                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }
    }
}
