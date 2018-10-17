using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataClient = new DAL.RentalCarDbClient();
            var booking = new Booking()
            {
                CarId = 1,
                CustomerId = 2,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(1)
            };
            dataClient.RemoveBooking(1);
        }
    }
}
