using Microsoft.Ajax.Utilities;
using movieApplicationWithDB.DataAccess;
using movieApplicationWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace movieApplicationWithDB.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()

        {

            //MovieList.AddMovies();
            List<Movie> moviess = MovieDAL.GetData(); 
            Session["movieList"] = moviess;
            Session["showtimes"] = MovieList.showTimeList;
            return View();
        }
        //public ActionResult Details()
        //{

        //    return RedirectToAction("Index");
        //}
        public ActionResult Details(int id)
        {

            foreach (var movie in MovieList.movieList)
            {

                if (movie.MovieID == id)
                {
                    Movie showMovie = movie;
                    System.Diagnostics.Debug.WriteLine("booking email" + showMovie.Title);
                    ViewData["movieDetails"] = showMovie;
                }
            }
            foreach (var show in MovieList.showTimeList)
            {
                if (show.MovieID == id)
                {
                    ShowTime movieTime = show;
                    System.Diagnostics.Debug.WriteLine("booking email" + movieTime.MovieID);
                    ViewData["showTime"] = movieTime;
                }
            }



            return View();
        }
        public ActionResult AddMovie()
        {
            return View();
        }



        [HttpPost]
        public ActionResult createMovie(Movie movie)
        {

            List<Movie> movieList = (List<Movie>)Session["movieList"];

            Movie tempMovie = new Movie(movie.Title, movie.Description, movie.Genre, movie.Duration, movie.ReleaseDate);
            MovieDAL.AddMovie(tempMovie);
            int movieId = tempMovie.MovieID;
            ShowTime tempShow = new ShowTime(movieId, movie.time);
            MovieList.showTimeList.Add(tempShow);
            movieList.Add(tempMovie);
            Session["movieList"] = movieList;

            return RedirectToAction("Index");

        }
    }
}