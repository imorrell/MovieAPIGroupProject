using System;
using System.Collections.Generic;

namespace MoviesAPIApp.Models
{
    public partial class FavoriteMovies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public int? IdbmmovieRating { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }

        public FavoriteMovies()
        {

        }
    }
}
