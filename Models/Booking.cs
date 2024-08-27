
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieApplicationWithDB.Models
{
    public class Booking
    {
        static int count = 0;
        public int BookingId { get; set; }

        public int ShowTimeID { get; set; }
        public int MovieId { get; set; }
        public int NumberOfSeats { get; set; } = 100;

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public Booking() { }
        public Booking(int movieId, int showId, int seats, string name, string email)
        {

            BookingId = count;
            ShowTimeID = showId;
            MovieId = movieId;
            NumberOfSeats = seats;
            UserName = name;
            UserEmail = email;

        }
    }
}