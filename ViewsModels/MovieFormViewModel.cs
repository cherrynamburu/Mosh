using Mosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mosh.ViewsModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

        public String Title
        {
            get
            {
                return Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

    }           
}