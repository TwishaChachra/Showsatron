using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Showsatron.Models
{
    public class Platform
    {
        public int PlatformId { get; set; }
       [Required]
        public string Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<AccountInfo> AccountInfos { get; set; }
    }
}
