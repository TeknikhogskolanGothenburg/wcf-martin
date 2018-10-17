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
    }
}
