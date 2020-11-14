using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            this._productoService = productoService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos= await _productoService.GetProductos();
            var productosDto = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoResponseDto>>(productos);
            var response = new ApiResponse<IEnumerable<ProductoResponseDto>>(productosDto);
            if (productosDto.Count() <= 0)
                return Ok(response);
            return Ok(productosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _productoService.GetProducto(id);
            var productoDto = _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productoDto);
            /*if (producto.Status == false)
                return Ok(response);*/
            return Ok(productoDto);
        }

        [HttpGet("prod/{id:int}")]
        public async Task<IActionResult> GetbyCode(int id)
        {
            var productos = await _productoService.GetProductos();
            var producto = productos.SingleOrDefault(x => x.CodigoProducto == id);
            var productoDto= _mapper.Map<Producto, ProductoResponseDto>(producto);
            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoRequestDto productolDto)
        {
            var producto = _mapper.Map<ProductoRequestDto, Producto>(productolDto);
            await _productoService.AddProducto(producto);
            var productoresponseDto = _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productoresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productoService.DeleteProducto(id);
            var result = new ApiResponse<bool>(true);            
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ProductoRequestDto productoResponse)
        {
            var producto = _mapper.Map<Producto>(productoResponse);
            producto.Id = id;
            producto.UpdateAt = DateTime.Now;
            producto.UpdatedBy = 1;
            await _productoService.UpdateProducto(producto);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
