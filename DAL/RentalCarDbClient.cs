using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RentalCarDbClient
    {
        private SqlConnection _connection;

        public RentalCarDbClient()
        {
            _connection = new SqlConnection("Server=.\\SQLEXPRESS; Database=RentalCar; Trusted_connection=true");
        }


        // Car queries

        public void AddCar(Car car)
        {
            using (var conn = _connection)
            {
                var insertQuery = @"INSERT INTO [dbo].[Car]([Brand], [Model], [Year], [RegNr]) VALUES (@Brand, @Model, @Year, @RegNr)";
                var result = conn.Execute(insertQuery, car);
            }
            
        }

        public void RemoveCar(string regNr)
        {
            using (var conn = _connection)
            {
                var delete = "DELETE FROM dbo.Car WHERE RegNr = @reg";
                var isSuccess = conn.Execute(delete, new { reg = regNr });
            }
        }

        public List<Car> GetAllCars()
        {
            using (var conn = _connection)
            {
                var queryresult = conn.Query<Car>("Select * From dbo.Car").ToList();
                return queryresult;
            }
        }

        //Customer queries

        public void AddCustomer(Customer customer)
        {
            using (var conn = _connection)
            {
                var insertQuery = @"INSERT INTO [dbo].[Customer]([Firstname], [Lastname], [Telephone], [Email]) VALUES (@Firstname, @Lastname, @Telephone, @Email)";
                var result = conn.Execute(insertQuery, customer);
            }

        }

        public void RemoveCustomer(int id)
        {
            using (var conn = _connection)
            {
                var delete = "DELETE FROM dbo.Customer WHERE Id = @ID";
                var isSuccess = conn.Execute(delete, new { ID = id });
            }
        }

        //Bookings queries

        public void AddBooking(Booking booking)
        {
            using (var conn = _connection)
            {
                var insertQuery = @"INSERT INTO [dbo].[Booking]([CarId], [CustomerId], [FromDate], [ToDate]) VALUES (@CarId, @CustomerId, @FromDate, @ToDate)";
                var result = conn.Execute(insertQuery, booking);
            }

        }

        public void RemoveBooking(int id)
        {
            using (var conn = _connection)
            {
                var delete = "DELETE FROM dbo.Booking WHERE Id = @ID";
                var isSuccess = conn.Execute(delete, new { ID = id });
            }
        }
    }
}
