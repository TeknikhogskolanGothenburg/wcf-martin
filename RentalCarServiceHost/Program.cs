using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarServiceHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(RentalCarService.RentalCarService)))
            {
                host.Open();
                Console.WriteLine("Host started @" + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
