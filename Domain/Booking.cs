using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Domain
{
    [DataContract]
    public class Booking : Base
    {
        private int _carId;
        private int _customerId;
        private DateTime _fromDate;
        private DateTime _toDate;
        private bool _isReturned;

        [DataMember]
        public int CarId
        {
            get { return _carId; }
            set
            {
                _carId = value;
            }
        }

        [DataMember]
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
            }
        }

        [DataMember]
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
            }
        }

        [DataMember]
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
            }
        }

        [DataMember]
        public bool IsReturned
        {
            get { return _isReturned; }
            set
            {
                _isReturned = value;
            }
        }

        public Booking() { }
    }

    [MessageContract(IsWrapped = true, WrapperName = "BookingRequestObject", 
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class BookingRequest
    {
        [MessageHeader(Namespace = "http://example.com/Martin/11/05")]
        public string License { get; set; }
        [MessageBodyMember(Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "BookingInfoObject",
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class BookingInfo
    {
        [MessageBodyMember(Order = 1, Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://example.com/Martin/11/05")]
        public int CarId { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://example.com/Martin/11/05")]
        public int CustomerId { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://example.com/Martin/11/05")]
        public DateTime FromDate { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://example.com/Martin/11/05")]
        public DateTime ToDate { get; set; }
        [MessageBodyMember(Order = 6, Namespace = "http://example.com/Martin/11/05")]
        public bool IsReturned { get; set; }

        public BookingInfo() { }

        public BookingInfo(Booking booking)
        {
            this.Id = booking.Id;
            this.CarId = booking.CarId;
            this.CustomerId = booking.CustomerId;
            this.FromDate = booking.FromDate;
            this.ToDate = booking.ToDate;
            this.IsReturned = booking.IsReturned;
        }
    }
}
