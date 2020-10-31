using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        //primary key for db
        public int Id {get; set;}

        //The attributes here are used for add validation to the user's input
        //for these models
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title {get; set;}


        //this specifies what to display for the name of the field.
        [Display(Name="Release Date")]
        //Specifies the type of the data Date
        //Now the user is not required to enter time info in the date field
        // only the date is displayed, not time information
        [DataType(DataType.Date)]
        public DateTime ReleaseDate {get; set;}

        //Data annotation is required so the EF core can correctly map
        //price to currency in the db
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;}        

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Genre {get; set;}


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating {get; set;}
    }
}