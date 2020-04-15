using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
        public string Title
        {
            get
            {
                return Movie.Id == 0 ? "New Movie" : "Edit Movie";
            }
        }
    }
    
}