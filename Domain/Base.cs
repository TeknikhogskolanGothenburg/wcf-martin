using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [KnownType(typeof(Car))]
    [KnownType(typeof(Booking))]
    [KnownType(typeof(Customer))]

    [DataContract]
    public class Base
    {
        private int _id;

        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
    }
}
