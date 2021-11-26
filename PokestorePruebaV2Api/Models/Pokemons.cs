using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokestorePruebaV2Api.Models
{
    public class Pokemons
    {
        [Key]
        [JsonIgnore]
        public int IdPokemon { get; set; }
        [Required]
        [StringLength(15)]
        public string PokemonName { get; set; }
        [Required]
        [JsonIgnore]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public PokemonTypes PokemonTypes { get; set; }
    }
}
