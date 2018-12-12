using System;
using System.Collections.Generic;
using Domain;
using BL;
using System.ServiceModel;
using System.Linq;
using System.ServiceModel.Web;
using System.Net;

namespace RentalCarService
{
    public class RentalCarService : ICarService, ICustomerService, IBookingService
    {
        // Booking Operations
        public void AddBooking(Booking booking)
        {
            var bookingData = new BookingService();
            bookingData.Add(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            var bookingData = new BookingService();
            bookingData.Remove(booking);
        }

        public void IsReturned(Booking booking)
        {
            var bookingData = new BookingService();
            bookingData.IsReturned(booking);
        }

        public void IsRented(Booking booking)
        {
            var bookingData = new BookingService();
            bookingData.IsRented(booking);
        }

        public BookingInfo GetBookingById(BookingRequest request)
        {
            try
            {
                var bookingData = new BookingService();
                var booking = bookingData.GetById(request.Id);
                return new BookingInfo(booking);
            }
            catch
            {
                throw new FaultException("Please provide a valid booking id");
            }
        }

        public Booking[] GetAllBookings()
        {
            var bookingData = new BookingService();
            var bookings = bookingData.GetAll().ToArray();
            return bookings;
        }


        //Car Operations
        public void AddCar(Car car)
        {
            var carData = new CarService();
            carData.Add(car);
        }

        public void RemoveCar(Car car)
        {
            var carData = new CarService();
            carData.Remove(car);
        }

        public CarInfo GetCarById(CarRequest request)
        {
            if(request.LicenseKey != "CAReful")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                    HttpStatusCode.Forbidden);
            }
            else
            {
                try
                {
                    var carData = new CarService();
                    var car = carData.GetById(request.Id);
                    return new CarInfo(car);
                }
                catch
                {
                    throw new FaultException("Please provide a valid car id");
                }
            }
        }

        public Car[] GetAllCars()
        {
                var carData = new CarService();
                var cars = carData.GetAll().ToArray();
                return cars;
        }

        public Car[] GetAvailableCars(DateTime fromDate, DateTime toDate)
        {
            var carData = new CarService();
            var cars = carData.GetAvailable(fromDate, toDate).ToArray();
            return cars;
        }


        //Customer Operations
        public void AddCustomer(Customer customer)
        {
            var customerData = new CustomerService();
            customerData.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            var customerData = new CustomerService();
            customerData.Remove(customer);
        }

        public void EditCustomer(Customer customer)
        {
            var customerData = new CustomerService();
            customerData.Edit(customer);
        }

        public CustomerInfo GetCustomerById(CustomerRequest request)
        {
            try
            {
                var customerData = new CustomerService();
                var customer = customerData.GetById(request.Id);
                return new CustomerInfo(customer);
            }
            catch
            {
                throw new FaultException("Please provide a valid Customer ID");
            }
        }

        public Customer[] GetAllCustomers()
        {
            var customerData = new CustomerService();
            var customers = customerData.GetAllCustomers().ToArray();
            return customers;
        }
    }
}
