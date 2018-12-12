using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Domain;

namespace RentalCarService
{
    public class RentalCarRestService : IRentalCarRestService
    {
        public void AddCar(Car car)
        {
            var carData = new CarService();
            carData.Add(car);
        }

        public Car[] GetAllCars()
        {
            var carData = new CarService();
            var cars = carData.GetAll().ToArray();
            return cars;
        }

        public Car GetCarById(string id)
        {
            var carData = new CarService();
            var car = carData.GetById(int.Parse(id));
            return car;
        }

        public void RemoveCar(string id)
        {
            var carData = new CarService();
            carData.Remove(new Car { Id = int.Parse(id)});
        }
    }
}
