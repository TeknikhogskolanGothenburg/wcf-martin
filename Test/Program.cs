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
            //var dataClient = new DAL.RentalCarDbClient();
            //var booking = new Booking()
            //{
            //    CarId = 4,
            //    CustomerId = 1,
            //    FromDate = new DateTime(2018, 01, 01),
            //    ToDate = new DateTime(2018, 12, 31),
            //    IsReturned = false
            //};

            var bs = new BookingService();

            bs.IsReturned(5);
            //bs.Create(booking);

            //var fromDate = DateTime.Now;
            //var toDate = DateTime.Now.AddDays(2);

            //var carService = new CarService();
            //var test = carService.GetAllAvailable(fromDate, toDate);
            //var test2 = carService.GetById(test);



            //var car = new Car()
            //{
            //    Brand = "Volvo",
            //    Model = "XC90",
            //    Year = 2018,
            //    RegNr = "LHF912"
            //};


            //var carService = new CarService();
            //carService.Remove(car.RegNr);
            //carService.Add(car);

            //var customer = new Customer()
            //{
            //    Firstname = "Nisse",
            //    Lastname = "Svensson",
            //    Email = "ns@gmail.com",
            //    Telephone = "0701234567"
            //};

            //var customerService = new CustomerService();
            //var customer = customerService.Get(1);
            //customer.Firstname = "Martin";
            //customer.Lastname = "Molin";

            //customerService.Update(customer);

            //dataClient.AddCar(car);
            //dataClient.AddCustomer(customer);
            //dataClient.AddBooking(booking);
        }
    }
}