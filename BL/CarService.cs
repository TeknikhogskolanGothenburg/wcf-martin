using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain;

namespace BL
{
    public class CarService
    {
        public void Add(Car car)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.AddCar(car);
        }

        public void Remove(Car car)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.RemoveCar(car.Id);
        }

        public Car GetById(int id)
        {
            var dataClient = new RentalCarDbClient();
            var cars = dataClient.GetCarById(id);
            return cars;
        }

        public List<Car> GetAll()
        {
            var dataClient = new RentalCarDbClient();
            var cars = dataClient.GetAllCars();
            return cars;
        }

        // GetAvailableCars methods
        public List<Car> GetAvailable(DateTime startDate, DateTime endDate)
        {
            var dataClient = new RentalCarDbClient();
            var allBookings = dataClient.GetAllBookings();
            var availableCars = GetAll();

            var dateBetween = GetDates(startDate, endDate);

            foreach (var booking in allBookings)
            {
                var booked = GetDates(booking.FromDate, booking.ToDate);
                foreach (var date in booked)
                {
                    if (CompareDates(dateBetween, date))
                    {
                        availableCars.RemoveAll(x => x.Id == booking.CarId);
                    }
                }
            }
            return availableCars;
        }

        public bool CompareDates(List<DateTime> dateBetween, DateTime booked)
        {
            var isBooked = false;
            if (dateBetween.Any(x => x.ToShortDateString() == booked.ToShortDateString()))
            {
                isBooked = true;
            }
            else
            {
                isBooked = false;
            }
            return isBooked;
        }

        public List<DateTime> GetDates(DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }
    }
}



//Temp

//public List<int> GetAllAvailable(DateTime fromDate, DateTime toDate)
//{
//    var dataClient = new RentalCarDbClient();
//    var ids = dataClient.GetAllAvailableCars(fromDate, toDate);
//    return ids;
//}