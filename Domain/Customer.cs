using System.Runtime.Serialization;
using System.ServiceModel;

namespace Domain
{
    [DataContract]
    public class Customer : Base
    {
        private string _firstname;
        private string _lastname;
        private string _telephone;
        private string _email;

        [DataMember]
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        [DataMember]
        public string Lastname
        {
            get { return _lastname; }
            set
            { _lastname = value; }
        }

        [DataMember]
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value;}
        }

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Customer() { }

        public Customer(CustomerInfo customerInfo)
        {
            this.Id = customerInfo.Id;
            this.Firstname = customerInfo.Firstname;
            this.Lastname = customerInfo.Lastname;
            this.Telephone = customerInfo.Telephone;
            this.Email = customerInfo.Email;
        }
    }

    [MessageContract(IsWrapped = true, WrapperName = "CustomerRequestObject", 
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class CustomerRequest
    {
        [MessageHeader(Namespace = "http://example.com/Martin/11/05")]
        public string License { get; set; }
        [MessageBodyMember(Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "CustomerInfoObject",
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class CustomerInfo
    {
        [MessageBodyMember(Order = 1, Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://example.com/Martin/11/05")]
        public string Firstname { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://example.com/Martin/11/05")]
        public string Lastname { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://example.com/Martin/11/05")]
        public string Telephone { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://example.com/Martin/11/05")]
        public string Email { get; set; }

        public CustomerInfo() { }

        public CustomerInfo(Customer customer)
        {
            this.Id = customer.Id;
            this.Firstname = customer.Firstname;
            this.Lastname = customer.Lastname;
            this.Telephone = customer.Telephone;
            this.Email = customer.Email;
        }
    }
} 