using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class MovieStudio
    {
        public int MovieStudioID { get; set; }
        [StringLength(60, MinimumLength = 3), Required]
        public string Name { get; set; }
        [Range(1888, 3000), Required]
        public int Founded { get; set; }
        public List<Movie> Movies { get; set; }
    }
}