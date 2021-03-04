// using Microsoft.AspNetCore.Mvc;
// using NUnit.Framework;
// using OpenCoolMart.Gui.Models;
// using OpenCoolMart.Gui.Controllers;
// using System.Threading.Tasks;
//
// namespace OpenCoolMart.NUnitTest
// {
//     public class Tests
//     {
//         //gracias por ver este video
//         //Agregar Producto
//         [Test]
//         //Este es el caso de prueba cuado todos los campos del formulario son llenados correctamente
//         public async Task Agregar_Producto_Todos_Los_Campos_Llenos_Async()
//         {
//             ProductoController controller = new ProductoController();
//             var producto = new ProductoRequestDto()
//             {
//                 CodigoProducto = 10002500,
//                 Clasificacion = "Electronica",
//                 Descripcion = "Macbook Pro 512G",
//                 Marca = "Apple",
//                 PrecioVenta = 12000,
//                 Descuento = 0.12,
//                 Status = true,
//                 Stock = 3500,
//                 CreatedBy = 1
//             };
//             var respuesta = await controller.Create(producto) as ViewResult;
//             Assert.IsNotNull(respuesta.Model);
//         }
//         [Test]
//         //Este es el caso de prueba cuado todos los campos del formulario son estan vacios
//         public async Task Agregar_Producto_Todos_Los_Campos_Vacios_Async()
//         {
//             var controller = new ProductoController();
//             var producto = new ProductoRequestDto();
//             var respuesta = await controller.Create(producto) as ViewResult;
//             Assert.IsNull(respuesta.ViewName);
//         }
//         [Test]
//         //Este es el caso de prueba cuado alguno de los campos del formulario no tiene el formato correcto
//         public async Task Agregar_Producto_Forrmato_Invalid_Async()
//         {
//             var controller = new ProductoController();
//             var producto = new ProductoRequestDto()
//             {
//                 CodigoProducto = 10002500,
//                 Clasificacion = "Electronica",
//                 Descripcion = "Macbook Pro 512G",
//                 Marca = "Apple",
//                 PrecioVenta = 12000,
//                 Descuento = 0.12,
//                 Status = true,
//                 Stock = -20,
//                 CreatedBy = 1
//             };
//             var respuesta = await controller.Create(producto) as ViewResult;
//             Assert.IsNull(respuesta.ViewName);
//         }
//
//         //Actualizar Producto
//         [Test]
//         //Este es el caso de prueba cuado alguno de los campos del formulario es actualizado
//         public async Task Actualizar_Producto_Cambiando_Algun_Campo()
//         {
//             var controller = new ProductoController();
//             var producto = new ProductoRequestDto()
//             {
//                 CodigoProducto = 10002500,
//                 Clasificacion = "Electronica",
//                 Descripcion = "Macbook Pro 512G",
//                 Marca = "Apple",
//                 PrecioVenta = 12000,
//                 Descuento = 0.12,
//                 Status = true,
//                 Stock = 4500,
//                 CreatedBy = 1
//             };
//             var respuesta = (RedirectToActionResult)controller.UpdateAsync(2,producto);
//             await Task.Delay(10);
//             Assert.AreEqual("Index", respuesta.ActionName);
//         }
//         [Test]
//         //Este es el caso de prueba cuado todoslos campos del formulario estan vacios
//         public async Task Actualizar_Producto_Todos_Los_Campos_VaciosAsync()
//         {
//             var controller = new ProductoController();
//             var producto = new ProductoRequestDto();
//             ViewResult result = controller.UpdateAsync(2, producto) as ViewResult;
//             await Task.Delay(10);
//             Assert.IsNotNull(result.ViewData["Message"]);
//         }
//
//     }
// }