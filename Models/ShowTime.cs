using movieApplicationWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieApplicationWithDB.Models

{
    public class ShowTime
    {
        public int Id { get; set; }

        public int MovieID { get; set; }

        public DateTime Showtime { get; set; }

        public int AvailableSeats { get; set; } = 100;

        public ShowTime(int movieID, DateTime showTime)
        {

            Id = MovieList.showTimeList.Count;
            MovieID = movieID;
            Showtime = showTime;
            AvailableSeats = 100;

        }
        public ShowTime() { }
    }
}