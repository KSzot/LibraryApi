using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApi;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serwer Biblioteki");
            ServiceHost host = new ServiceHost(typeof(LibraryService));

            host.Open();
            Console.WriteLine("Serwer działa. Aby przerwać nacisnij dowolny przycisk");
            Console.ReadKey();
        }
    }
}
