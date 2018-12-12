using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public void RemoveCar(int id)
        {
            using (var conn = _connection)
            {
                var delete = "DELETE FROM dbo.Car WHERE Id = @ID";
                var isSuccess = conn.Execute(delete, new { ID = id });
            }
        }

        public List<Car> GetAllCars()
        {
            using (var conn = _connection)
            {
                var queryResult = conn.Query<Car>("SELECT * FROM dbo.Car").ToList();
                return queryResult;
            }
        }

        public Car GetCarById(int carId)
        {
            using (var conn = _connection)
            {
                var queryResult = conn.Query<Car>("SELECT * FROM dbo.Car WHERE Id = @Id", new { Id = carId }).FirstOrDefault();
                return queryResult;
            }
        }

        public List<int> GetAllAvailableCars(DateTime fromDate, DateTime toDate)
        {
            using (var conn = _connection)
            {
                var query = "SELECT CarId FROM Booking WHERE @fromDate < FromDate AND @toDate <= FromDate OR @fromDate >= ToDate AND @toDate > ToDate";
                var queryResult = conn.Query<int>(query, new { fromDate, toDate }).ToList();
                return queryResult;
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

        //Does this one work?
        public void UpdateCustomer(Customer customer)
        {
            using (var conn = _connection)
            {
                var query = "UPDATE Customer SET Firstname = @firstname, Lastname = @lastname, Telephone = @telephone, Email = @email WHERE Id = @id";
                var result = conn.Execute(query, new { customer.Firstname, customer.Lastname, customer.Telephone, customer.Email, customer.Id });
            }
        }

        public Customer GetCustomer(int id)
        {
            using (var conn = _connection)
            {
                var customer = conn.Query<Customer>("SELECT * FROM dbo.customer WHERE Id = @ID", new { id }).FirstOrDefault();
                return customer;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (var conn = _connection)
            {
                var customers = conn.Query<Customer>("SELECT * FROM dbo.customer").ToList();
                return customers;
            }
        }

        //Booking queries

        public void AddBooking(Booking booking)
        {
            using (var conn = _connection)
            {
                var insertQuery = @"INSERT INTO [dbo].[Booking]([CarId], [CustomerId], [FromDate], [ToDate], [IsReturned]) VALUES (@CarId, @CustomerId, @FromDate, @ToDate, @IsReturned)";
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

        public Booking GetBooking(int id)
        {
            using (var conn = _connection)
            {
                var booking = conn.Query<Booking>("SELECT * FROM dbo.booking WHERE Id = @ID", new { id }).FirstOrDefault();
                return booking;
            }
        }

        public void IsReturned(int bookingId, bool isReturned)
        {
            using (var conn = _connection)
            {
                var query = "UPDATE dbo.Booking SET IsReturned = @returned WHERE Id = @BookingID";
                conn.Execute(query, new { returned = isReturned, BookingID = bookingId });
            }
        }


        // TEST!

        public List<Booking> GetAllBookings()
        {
            using (var conn = _connection)
            {
                var query = "SELECT * FROM Booking";
                var result = conn.Query<Booking>(query).ToList();
                return result;
            }
        }
    }
}

// TEMP

//public void RemoveCustomer(Customer customer)
//{
//    using (var conn = _connection)
//    {
//        var delete = "DELETE FROM dbo.Customer WHERE Id = @ID";
//        var isSuccess = conn.Execute(delete, new { ID = customer.Id });
//    }
//}

//public List<Car> GetCarsById(List<int> carIds)
//{
//    List<Car> cars = new List<Car>();
//    using (var conn = _connection)
//    {
//        foreach (var id in carIds)
//        {
//            var queryResult = conn.Query<Car>("SELECT * FROM dbo.Car WHERE Id = @Id", new { Id = id }).FirstOrDefault();
//            cars.Add(queryResult);
//        }
//    }
//    return cars;
//}
