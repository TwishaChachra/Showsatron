using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Showsatron.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
