using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieApplicationWithDB.Models

{
    public static class MovieList
    {


        public static List<Movie> movieList = new List<Movie>();
        public static List<ShowTime> showTimeList = new List<ShowTime>();
        public static List<Booking> bookedList = new List<Booking>();
        private static int count = 0;

        public static void AddMovies()
        {
            if (count == 0)
            {
                Movie m1 = new Movie(" Kalki", "Kalki 2898 AD is a 2024" +
                " Indian Telugu-language epic science fiction film directed " +
                "by Nag Ashwin and produced by Vyjayanthi Movies.", "Sci-Fi/Action", 124, new DateTime(2024, 5, 30));


                ShowTime sw1 = new ShowTime(0, new DateTime(2024, 11, 10, 22, 10, 00));
                movieList.Add(m1);
                showTimeList.Add(sw1);
                Movie m2 = new Movie("Munjiya", "Munjya is a 2024 Indian Hindi-language comedy horror film directed by " +
                    "Aditya Sarpotdar and starring Sharvari, Abhay Verma, Sathyaraj and Mona Singh.", "Horror/Comedy", 130, new DateTime(2024, 6, 7));
                ShowTime sw2 = new ShowTime(1, new DateTime(2024, 11, 10, 17, 30, 00));

                movieList.Add(m2);
                showTimeList.Add(sw2);
                count++;
            }

        }
        public static void BookingSeat(int seats, int movieID)
        {


            for (int i = 0; i < showTimeList.Count; i++)
            {
                if (showTimeList[i].MovieID == movieID)
                {
                    showTimeList[i].AvailableSeats -= seats;
                }
            }
        }



    }
}