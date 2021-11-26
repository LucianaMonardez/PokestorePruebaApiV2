using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokestorePruebaV2Api.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]
        [JsonIgnore]
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Categories Categories { get; set; }
        [Required]
        [JsonIgnore]
        public int IdPokemon { get; set; }
        [ForeignKey("IdPokemon")]

        public Pokemons Pokemons { get; set; }
    }
}
