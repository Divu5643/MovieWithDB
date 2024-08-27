using movieApplicationWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieApplicationWithDB.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime time { get; set; }

        public Movie() { }
        public Movie(string title, string desc, string genre, int duration, DateTime releaseDate)
        {

            MovieID = MovieList.movieList.Count;
            Title = title;
            Description = desc;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
        }
    }
}