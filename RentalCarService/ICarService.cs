using Domain;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Net.Security;

namespace RentalCarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarService" in both code and config file together.
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ICarService
    {
        [OperationContract]
        void AddCar(Car car);

        [OperationContract]
        void RemoveCar(Car car);

        [OperationContract]
        CarInfo GetCarById(CarRequest request);

        [OperationContract]
        Car[] GetAllCars();

        [OperationContract]
        Car[] GetAvailableCars(DateTime fromDate, DateTime toDate);
    }
}
