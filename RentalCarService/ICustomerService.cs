using Domain;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace RentalCarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ICustomerService
    {
        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]
        void RemoveCustomer(Customer customer);

        [OperationContract]
        void EditCustomer(Customer customer);

        [OperationContract]
        CustomerInfo GetCustomerById(CustomerRequest request);

        [OperationContract]
        Customer[] GetAllCustomers();
    }
}
