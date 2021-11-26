using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokestorePruebaV2Api.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [JsonIgnore]
        public int IdCategory { get; set; }
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }
    }
}
