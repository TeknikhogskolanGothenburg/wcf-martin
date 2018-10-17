using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookingService
    {
        public void Create(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.AddBooking(booking);
        }

        public void Remove(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.RemoveBooking(booking.Id);
        }
        public Booking Get(int id)
        {
            var dataClient = new RentalCarDbClient();
            var booking = dataClient.GetBooking(id);
            return booking;
        }
    }
}
