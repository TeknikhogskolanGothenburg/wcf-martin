using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

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
            dataClient.RemoveCustomer(customer);
        }
        public Customer Get(int id)
        {
            var dataClient = new RentalCarDbClient();
            var customer = dataClient.GetCustomer(id);
            return customer;
        }
        public void Update(Customer customer)
        {
            var dataClient = new RentalCarDbClient();
            dataClient.UpdateCustomer(customer);
        }
    }
}
