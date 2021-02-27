using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,
namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IAlmacenarImagen _almacenarImagen;
        private readonly IMapper _mapper;
        private readonly string contenedor = "productos";
        public ProductoController(IProductoService productoService, IMapper mapper,IAlmacenarImagen almacenarImagen)
        {
            this._productoService = productoService;
            this._mapper = mapper;
            this._almacenarImagen = almacenarImagen;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos= await _productoService.GetProductos();
            var productosDto = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoResponseDto>>(productos);
            var response = new ApiResponse<IEnumerable<ProductoResponseDto>>(productosDto);
            if (productosDto.Count() <= 0)
                return Ok(response);
            return Ok(response);
        }
        [Authorize(Roles = "1")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _productoService.GetProducto(id);
            var productoDto = _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productoDto);
            /*if (producto.Status == false)
                return Ok(response);*/
            return Ok(response);
        }

        [HttpGet("prod/{id:int}")]
        public async Task<IActionResult> GetbyCode(int id)
        {
            var productos = await _productoService.GetProductos();
            var producto = productos.SingleOrDefault(x => x.CodigoProducto == id);
            var productoDto= _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productoDto);
            return Ok(response);
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> Post(ProductoRequestDto productolDto)
        {
            var producto = _mapper.Map<ProductoRequestDto, Producto>(productolDto);
            producto.CreateAt = DateTime.Now;

            producto.PrecioCompra = 1;

            await _productoService.AddProducto(producto);
            var productoresponseDto = _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productoresponseDto);
            return Ok(response);
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productoService.DeleteProducto(id);
            var result = new ApiResponse<bool>(true);            
            return Ok(result);
        }
        [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult> Put(int id,[FromForm]ProductoRequestDto productoResponse)
        {
            var producto = await _productoService.GetProducto(id);
            producto = _mapper.Map<Producto>(productoResponse);
            producto.Id = id;
            producto.PrecioCompra = 1;

            producto.UpdateAt = DateTime.Now;

            if (productoResponse.Imagen != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await productoResponse.Imagen.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(productoResponse.Imagen.FileName);
                    producto.Imagen = await _almacenarImagen.EditarArchivo(contenido, extension, contenedor,producto.Imagen,productoResponse.Imagen.ContentType);
                }
            }

            await _productoService.UpdateProducto(producto);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
