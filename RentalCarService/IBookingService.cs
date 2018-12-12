using Domain;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace RentalCarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookingService" in both code and config file together.
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IBookingService
    {
        [OperationContract]
        void AddBooking(Booking booking);

        [OperationContract]
        void RemoveBooking(Booking booking);

        [OperationContract]
        void IsReturned(Booking booking);

        [OperationContract]
        void IsRented(Booking booking);

        [OperationContract]
        BookingInfo GetBookingById(BookingRequest request);

        [OperationContract]
        Booking[] GetAllBookings();
    }
}
