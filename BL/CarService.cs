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
    }
}
