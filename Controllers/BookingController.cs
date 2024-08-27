using movieApplicationWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace movieApplicationWithDB.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Book(int id)
        {
            foreach (var movie in MovieList.movieList)
            {
                if (movie.MovieID == id)
                {
                    Movie showMovie = movie;
                    ViewData["movieDetails"] = showMovie;
                }
            }
            foreach (var show in MovieList.showTimeList)
            {
                if (show.MovieID == id)
                {
                    ShowTime movieTime = show;
                    ViewData["showTime"] = movieTime;
                }
            }

            return View();
        }
        public ActionResult Confirm(Booking book)
        {
            int movieId = book.MovieId;
            int showID = book.ShowTimeID;
            foreach (var item in MovieList.movieList)
            {
                if (item.MovieID == movieId)
                {
                    ViewBag.movieTitle = item.Title;


                }
            }
            foreach (var item in MovieList.showTimeList)
            {
                if (item.MovieID == showID)
                {
                    ViewBag.showTime = item.Showtime;

                }
            }

            ViewBag.username = book.UserName;
            ViewBag.email = book.UserEmail;
            ViewBag.seats = book.NumberOfSeats;


            return View();
        }
        [HttpPost]
        public ActionResult book(Booking book)
        {


            int showId = (int)Session["showId"];
            var movieId = (int)Session["movieId"];
            Booking book1 = new Booking(movieId, showId, book.NumberOfSeats, book.UserName, book.UserEmail);
            MovieList.BookingSeat(book.NumberOfSeats, movieId);
            MovieList.bookedList.Add(book1);
            ViewData["bookedShow"] = book1;

            return RedirectToAction("Confirm", "Booking", new RouteValueDictionary(book1));
        }
    }
}