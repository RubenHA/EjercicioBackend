using EjercicioBackend.Models;
using EjercicioBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product producto)
        {
            if (producto == null) return BadRequest();
            if (producto.name == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del producto no puede ser vacío");
            }

            await db.InsertProduct(producto);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product producto, string id)
        {
            if (producto == null) return BadRequest();
            if (producto.name == string.Empty) { 
                ModelState.AddModelError("Nombre", "El nombre del producto no puede ser vacío");
            }

            producto.id = id;
            await db.UpdateProduct(producto);
            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleProduct(string id) {
            await db.DeleteProduct(id);
            return NoContent();
        }
    }
}
