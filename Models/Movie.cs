using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [StringLength(60, MinimumLength = 3), Required]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date"), DataType(DataType.Date), ClassicMovie(1960)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Genre { get; set; }
        [Range(1, 100), DataType(DataType.Currency)]

        public decimal Price { get; set; }
        public int MovieStudioID { get; set; }
        public MovieStudio Studio { get; set; }

    }
}