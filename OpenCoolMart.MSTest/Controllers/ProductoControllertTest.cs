using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCoolMart.Gui.Controllers;
using OpenCoolMart.Gui.Models;
using System.Threading.Tasks;

namespace OpenCoolMart.MSTest
{
    [TestClass]
    public class ProductoControllertTest
    {
        [TestMethod]
        public async Task ObtenerTodosLosProductos()
        {
            var controller = new ProductoController();
            var respuesta = await controller.Index() as ViewResult;
            
            Assert.IsNotNull(respuesta.Model);
        }

        [TestMethod]
        public async Task ObtenerProductoPorId()
        {
            var controller = new ProductoController();
            var respuesta = await controller.Details(1) as ViewResult;

            Assert.IsNotNull(respuesta.Model);
        }

        [TestMethod]
        public async Task ProductoNullPorId()
        {
            var controller = new ProductoController();
            var respuesta = await controller.Details(1003000) as ViewResult;

            Assert.IsNull(respuesta.Model);
        }

        [TestMethod]
        public async Task DesactivarProductoConCamposVacios()
        {
            var controller = new ProductoController();
            var producto = new ProductoRequestDto();
            producto.Status = false;
            ViewResult result = controller.Update(1, producto) as ViewResult;
            await Task.Delay(10);
            Assert.IsNotNull(result.ViewData["Message"]);
        }

        [TestMethod]
        public async Task DesactivarProductoExitoso()
        {
            var controller = new ProductoController();
            var producto = new ProductoRequestDto();
            producto.CodigoProducto = 1001000;
            producto.Clasificacion = "Equipo de computo";
            producto.Descripcion = "Producto 1";
            producto.Marca = "Samsung";
            producto.Precio = 100;
            producto.Status = false;
            producto.Stock = 10;
            producto.CreatedBy = 1;
            var result =(RedirectToActionResult)controller.Update(1, producto) ;
            await Task.Delay(10);
            Assert.AreEqual("Index", result.ActionName);
        }
        [TestMethod]
        public async Task ReactivarProductoConCamposVacios()
        {
            var controller = new ProductoController();
            var producto = new ProductoRequestDto();
            producto.Status = true;
            ViewResult result = controller.Update(1, producto) as ViewResult;
            await Task.Delay(10);
            Assert.IsNotNull(result.ViewData["Message"]);
        }

        [TestMethod]
        public async Task ReactivarProductoExitoso()
        {
            var controller = new ProductoController();
            var producto = new ProductoRequestDto();
            producto.CodigoProducto = 1002000;
            producto.Clasificacion = "Equipo de computo";
            producto.Descripcion = "Producto 1";
            producto.Marca = "Samsung";
            producto.Precio = 100;
            producto.Status = true;
            producto.Stock = 10;
            producto.CreatedBy = 1;
            var result = (RedirectToActionResult)controller.Update(2, producto);
            await Task.Delay(10);
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
