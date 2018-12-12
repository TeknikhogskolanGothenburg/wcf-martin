using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Domain
{
    [DataContract]
    public class Car : Base
    {
        private string _brand;
        private string _model;
        private int _year;
        private string _regNr;

        [DataMember]
        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
            }
        }

        [DataMember]
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }

        [DataMember]
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
            }
        }

        [DataMember]
        public string RegNr
        {
            get { return _regNr; }
            set
            {
                _regNr = value;
            }
        }

        public Car() { }

        public Car(CarInfo carInfo)
        {
            this.Id = carInfo.Id;
            this.Brand = carInfo.Brand;
            this.Model = carInfo.Model;
            this.Year = carInfo.Year;
            this.RegNr = carInfo.RegNr;
        }
    }

    [MessageContract(IsWrapped = true, WrapperName = "CarRequestObject", 
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class CarRequest
    {
        [MessageHeader(Namespace = "http://example.com/Martin/11/05")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "CarInfoObject",
        WrapperNamespace = "http://example.com/Martin/11/05")]
    public class CarInfo
    {
        [MessageBodyMember(Order = 1, Namespace = "http://example.com/Martin/11/05")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://example.com/Martin/11/05")]
        public string Brand { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://example.com/Martin/11/05")]
        public string Model { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://example.com/Martin/11/05")]
        public int Year { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://example.com/Martin/11/05")]
        public string RegNr { get; set; }

        public CarInfo() { }

        public CarInfo(Car car)
        {
            this.Id = car.Id;
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.Year = car.Year;
            this.RegNr = car.RegNr;
        }
    }
}
