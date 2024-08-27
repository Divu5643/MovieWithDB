using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using movieApplicationWithDB.Models;

namespace movieApplicationWithDB.DataAccess
{
    public class MovieDAL
    {

        public static void AddMovie(Movie m ) {

            using (SqlConnection conn = new SqlConnection("data source=BFL-COMP-7473\\SQLEXPRESS;database=MovieBookingDB;Trusted_Connection=True"))
            {
                conn.Open();

                string sqlQuery = "INSERT INTO Movies(Title,Description,Genre,Duration,ReleaseDate) VALUES(@Title,@Description,@Genre,@Duration,@ReleaseDate)";
                
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@Title", m.Title);
                cmd.Parameters.AddWithValue("@Description", m.Description);
                cmd.Parameters.AddWithValue("@Genre", m.Genre);
                cmd.Parameters.AddWithValue("@Duration", m.Duration);
                cmd.Parameters.AddWithValue("@ReleaseDate", m.ReleaseDate);
                cmd.ExecuteNonQuery();
            }

        }

        public static List<Movie> GetData() {

            using (SqlConnection conn =  new SqlConnection("data source=BFL-COMP-7473\\SQLEXPRESS;database=MovieBookingDB;Trusted_Connection=True")) 
            {
                List<Movie> movies = new List<Movie>();
                conn.Open();
                string queryString = "SELECT * FROM Movies";
                SqlCommand cmd = new SqlCommand(queryString,conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int movieId = Convert.ToInt32(reader["movieId"]);
                    string title = reader["Title"].ToString();
                    string Description = reader["Description"].ToString();
                    string Genre = reader["Genre"].ToString();
                    int Duration = Convert.ToInt32(reader["Duration"]);
                    //string ReleaseDate = reader["ReleaseDate"].ToString();
                    DateTime ReleaseDate = (DateTime)reader["ReleaseDate"];
                    System.Diagnostics.Debug.WriteLine("reader : " + title + ReleaseDate.ToString());
                    Movie m1 = new Movie(title,Description,Genre,Duration,ReleaseDate);
                    movies.Add(m1);
                }

                return movies;


                
            }
        
        }
    }
}