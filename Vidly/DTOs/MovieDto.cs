using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        [Key]      
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }
       
        [Required]
        [CustomValidationError]
        [Range(1, 20, ErrorMessage = "The number must be between 1 and 20")]
        public int NumberInStock { get; set; }

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