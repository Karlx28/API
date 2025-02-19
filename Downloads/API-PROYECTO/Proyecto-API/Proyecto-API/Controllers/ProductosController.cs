using Microsoft.AspNetCore.Mvc;
using Proyecto_API.Context;
using Proyecto_API.Model;
using Proyecto_API.Repositories;

namespace Proyecto_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductosController : ControllerBase
        {
            private readonly ProductosRepository _repository;

            public ProductosController(ProductosContext context)
            {
                _repository = new ProductosRepository(context);
            }

            [HttpGet("ObtenerTodos")]
            public async Task<IActionResult> GetAll() => Ok(await _repository.Get());


            [HttpGet("ObtenerPorId/{id}")]
            public async Task<ActionResult<Productos>> ObtenerPorId(int id)
            {
                var producto = await _repository.GetById(id);

                if (producto == null)
                {
                    return NotFound($"No se encontró el producto con ID {id}");
                }
                return Ok(producto);
            }

            [HttpPost("InsertarProducto")]
            public async Task<ActionResult> InsertarProducto([FromBody] Productos productoDTO)
            {
                if (productoDTO == null || string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Stock < 0 || productoDTO.Precio <= 0)
                {
                    return BadRequest("Datos de producto inválidos.");
                }

                var nuevoProducto = new Productos
                {
                    Nombre = productoDTO.Nombre,
                    Stock = productoDTO.Stock,
                    Precio = productoDTO.Precio
                };

                await _repository.Add(nuevoProducto);
                await _repository.Save();

                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoProducto.Id }, nuevoProducto);
            }

            [HttpPut("EditarProducto/{id}")]
            public async Task<ActionResult> ActualizarProducto(int id, [FromBody] Productos producto)
            {
                if (producto == null || string.IsNullOrWhiteSpace(producto.Nombre) || producto.Stock < 0 || producto.Precio <= 0)
                {
                    return BadRequest("Datos de producto inválidos.");
                }

                var productoExistente = await _repository.GetById(id);
                if (productoExistente == null)
                {
                    return NotFound("Producto no encontrado.");
                }

                productoExistente.Nombre = producto.Nombre;
                productoExistente.Stock = producto.Stock;
                productoExistente.Precio = producto.Precio;

                _repository.Update(productoExistente);
                await _repository.Save();

                return Ok(productoExistente);
            }

            [HttpDelete("EliminarProducto/{id}")]
            public async Task<ActionResult> EliminarProducto(int id)
            {
                try
                {
                    var producto = await _repository.GetById(id);
                    if (producto == null)
                    {
                        return NotFound("Producto no encontrado.");
                    }

                    _repository.Delete(producto);
                    await _repository.Save();

                    return Ok(new { mensaje = "Producto eliminado con éxito" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
                }
            }
        }
}
