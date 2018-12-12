using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarRestServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(RentalCarService.RentalCarRestService)))
            {
                host.Open();
                Console.WriteLine("Host started @" + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
