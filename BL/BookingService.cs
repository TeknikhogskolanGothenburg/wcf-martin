using DAL;
using Domain;
using System.Collections.Generic;

namespace BL
{
    public class BookingService
    {
        public void Add(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.AddBooking(booking);
        }

        public void Remove(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.RemoveBooking(booking.Id);
        }

        public void IsReturned(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.IsReturned(booking.Id, true);
        }

        public void IsRented(Booking booking)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.IsReturned(booking.Id, false);
        }

        public Booking GetById(int id)
        {
            var dataClient = new RentalCarDbClient();
            var booking = dataClient.GetBooking(id);
            return booking;
        }

        public List<Booking> GetAll()
        {
            var dataClient = new RentalCarDbClient();
            return dataClient.GetAllBookings();
        }
    }
}
