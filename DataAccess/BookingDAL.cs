using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace movieApplicationWithDB.DataAccess
{
    public class BookingDAL
    {
        private string connectionString = "data source=BFL-COMP-7473\\SQLEXPRESS;database=MovieBookingDB;Trusted_Connection=True";
        public static void createBookingTable()
        {
            using (SqlConnection conn = new SqlConnection("data source=BFL-COMP-7473\\SQLEXPRESS;database=MovieBookingDB;Trusted_Connection=True"))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("CREATE TABLE Booking()", conn);
                cmd.ExecuteNonQuery();

            }
        }
    }
}