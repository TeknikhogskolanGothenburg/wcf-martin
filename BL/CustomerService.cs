using Domain;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class CustomerService
    {
        public void Add(Customer customer)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.AddCustomer(customer);
        }

        public void Remove(Customer customer)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.RemoveCustomer(customer.Id);
        }

        public void Edit(Customer customer)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.UpdateCustomer(customer);
        }

        public Customer GetById(int id)
        {
            var dataClient = new RentalCarDbClient();
            var customer = dataClient.GetCustomer(id);
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            var dataClient = new RentalCarDbClient();
            var customers = dataClient.GetAllCustomers();
            return customers;
        }
    }
}
