using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Remove(string regNr)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.RemoveCar(regNr);
        }

        public List<int> GetAllAvailable(DateTime fromDate, DateTime toDate)
        {
            var dataClient = new RentalCarDbClient();
            var ids = dataClient.GetAllAvailableCars(fromDate, toDate);
            return ids;
        }

        public List<Car> GetById(List<int> Ids)
        {
            var dataClient = new RentalCarDbClient();
            var cars = dataClient.GetCarsById(Ids);
            return cars;
        }

        // TEST!

        public List<Car> GetAllCars()
        {
            var dataClient = new RentalCarDbClient();
            var cars = dataClient.GetAllCars();
            return cars;
        }

        public List<Car> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            var dataClient = new RentalCarDbClient();
            var allBookings = dataClient.GetAllBookings();
            var availableCars = GetAllCars();

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
