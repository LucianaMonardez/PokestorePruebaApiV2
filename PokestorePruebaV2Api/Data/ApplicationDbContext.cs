using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokestorePruebaV2Api.Models;

namespace PokestorePruebaV2Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Products> Products {get;set;}
        public DbSet<Categories> Categories {get;set;}
        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<PokemonTypes> PokemonTypes { get; set; }

    }
}
