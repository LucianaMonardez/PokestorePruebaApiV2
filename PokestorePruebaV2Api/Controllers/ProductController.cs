using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokestorePruebaV2Api.Models;
using PokestorePruebaV2Api.Data;

namespace PokestorePruebaV2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            //usamos EF para traer a los productos
            var productos = _context.Products.ToList();
            foreach (var producto in productos)
            {
                producto.Categories = _context.Categories.Find(producto.IdCategory);
                producto.Pokemons = _context.Pokemons.Find(producto.IdPokemon);
                producto.Pokemons.PokemonTypes = _context.PokemonTypes.Find(producto.Pokemons.TypeId);
            }
            return _context.Products.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            //usamos EF para traer a las personas
            return _context.Products.Find(id);
        }
        [HttpPost("{id}")]
        public ActionResult Post(Products Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();

            //return Ok();
            return new CreatedAtRouteResult("ObtenerProducto", new { id = Product.Id }, Product);

        }

        [HttpGet("TraerProducto/{id}", Name = "ObtenerProducto")]
        public ActionResult<Products> ObtenerPersona(int id)
        {
            return _context.Products.Find(id);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Products Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();

            }

            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Products> Delete(int id)
        {
            var products = _context.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            _context.Products.Remove(products);
            _context.SaveChanges();

            return products;
        }
    }
}
