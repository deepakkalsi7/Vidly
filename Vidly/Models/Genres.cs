using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{[Table("Genres")]
    public class Genres
    {   [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}