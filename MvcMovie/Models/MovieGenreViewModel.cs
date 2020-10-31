using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        //list of movies
       public List<Movie> Movies { get; set; }
       // select list of genres
       public SelectList Genres {get; set;}
       //the selected genre.
       public string MovieGenre {get; set;}
       //the user's search string
       public string SearchString {get; set;} 
    }
}