using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarService
{
    [ServiceContract]
    interface IRentalCarRestService
    {
        [OperationContract(Name = "AddCarRest")]
        [WebInvoke(Method = "POST", UriTemplate = "Cars", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddCar(Car car);

        [OperationContract(Name = "RemoveCarRest")]
        [WebInvoke(Method = "DELETE", UriTemplate = "Cars/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void RemoveCar(string id);

        [OperationContract(Name = "GetCarByIdRest")]
        [WebGet(UriTemplate = "Cars/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Car GetCarById(string id);

        [OperationContract(Name = "GetAllCarsRest")]
        [WebGet(UriTemplate = "Cars", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Car[] GetAllCars();
    }
}
