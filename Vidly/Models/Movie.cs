using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {   [Key]
        [Column("MovieID")]
        public int Id { get; set; }

        [Column("MovieName")]
        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Column("Number in Stock")]
        [Display(Name="Number in Stock")]
        [Required]
        [CustomValidationError]
        [Range(1,20,ErrorMessage ="The number must be between 1 and 20")]
         public int NumberInStock { get; set; }

        
        public Genres Genres { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime Loaddate { get; set; }





    }
}