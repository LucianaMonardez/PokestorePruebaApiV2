using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokestorePruebaV2Api.Models
{
    public class PokemonTypes
    {
        [Key]
        [JsonIgnore]
        public int TypeId { get; set; }
        [Required]
        [StringLength(10)]
        public string Type { get; set; }
    }
}
