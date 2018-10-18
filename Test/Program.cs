using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now.AddDays(6);
            var end = DateTime.Now.AddDays(8);

            var carData = new CarService();
            var cars = carData.GetAvailableCars(start, end);
        }
    }
}